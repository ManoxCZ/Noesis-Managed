﻿using System;
using System.Runtime.InteropServices;
using Noesis;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using SharpDX.DXGI;

namespace NoesisApp
{
    public class RenderContextD3D11 : RenderContext
    {
        public RenderContextD3D11()
        {
        }

        public override RenderDevice Device
        {
            get { return _device; }
        }

        private IntPtr _display;
        private IntPtr _window;
        private RenderDeviceD3D11 _device;
        private SharpDX.Direct3D11.Device1 _dev;
        private SwapChain1 _swapChain;
        private RenderTargetView _renderTarget;
        private DepthStencilView _depthStencil;
        private SharpDX.Mathematics.Interop.RawViewportF _viewport;
        private bool _vsync;
        private ImageCapture _imageCapture;

        public override void Init(IntPtr display, IntPtr window, uint samples, bool vsync, bool sRGB)
        {
            _display = display;
            _window = window;
            _vsync = vsync;

            FeatureLevel[] features =
            {
                FeatureLevel.Level_11_1,
                FeatureLevel.Level_11_0
            };

            SharpDX.Direct3D11.Device dev11 = new SharpDX.Direct3D11.Device(DriverType.Hardware, DeviceCreationFlags.None, features);
            _dev = dev11.QueryInterfaceOrNull<SharpDX.Direct3D11.Device1>();

            SampleDescription sampleDesc = new SampleDescription();
            do
            {
                if (_dev.CheckMultisampleQualityLevels(Format.R8G8B8A8_UNorm, (int)samples) > 0)
                {
                    sampleDesc.Count = (int)samples;
                    sampleDesc.Quality = 0;
                    break;
                }
                else
                {
                    samples >>= 1;
                }
            } while (samples > 0);

            SwapChainDescription1 desc = new SwapChainDescription1();
            desc.Width = 0;
            desc.Height = 0;
            desc.Format = sRGB ? Format.R8G8B8A8_UNorm_SRgb : Format.R8G8B8A8_UNorm;
            desc.Scaling = Scaling.None;
            desc.SampleDescription = sampleDesc;
            desc.Usage = Usage.RenderTargetOutput;
            desc.BufferCount = 2;
            desc.SwapEffect = SwapEffect.FlipSequential;
            desc.Flags = SwapChainFlags.None;

            SharpDX.DXGI.Device2 dev = _dev.QueryInterface<SharpDX.DXGI.Device2>();
            Adapter adapter = dev.Adapter;
            Factory2 factory = adapter.GetParent<Factory2>();
            if (display == IntPtr.Zero)
            {
                GCHandle handle = (GCHandle)window;
                SharpDX.ComObject coreWindow = new SharpDX.ComObject(handle.Target as object);
                _swapChain = new SwapChain1(factory, _dev, coreWindow, ref desc);
            }
            else
            {
                _swapChain = new SwapChain1(factory, _dev, window, ref desc);
            }

            _device = new RenderDeviceD3D11(_dev.ImmediateContext.NativePointer, sRGB);
        }

        public override void SetWindow(IntPtr window) { }

        public override void BeginRender() { }

        public override void EndRender() { }

        public override void SetDefaultRenderTarget(int width, int height, bool doClearColor)
        {
            if (doClearColor)
            {
                _dev.ImmediateContext.ClearRenderTargetView(_renderTarget, new SharpDX.Mathematics.Interop.RawColor4(0.0f, 0.0f, 0.0f, 0.0f));
            }

            _dev.ImmediateContext.ClearDepthStencilView(_depthStencil, DepthStencilClearFlags.Stencil, 0.0f, 0);
            _dev.ImmediateContext.OutputMerger.SetRenderTargets(_depthStencil, _renderTarget);
            _dev.ImmediateContext.Rasterizer.SetViewport(_viewport);

            _device.DisableScissorRect();
        }

        public override ImageCapture CaptureRenderTarget(RenderTarget surface)
        {
            IntPtr texNativePtr = RenderDeviceD3D11.GetTextureNativePointer(surface.Texture);
            ShaderResourceView view = new ShaderResourceView(texNativePtr);
            using (Texture2D source = view.Resource.QueryInterface<Texture2D>())
            {
                Texture2DDescription desc = source.Description;
                desc.CpuAccessFlags = CpuAccessFlags.Read;
                desc.Usage = ResourceUsage.Staging;
                desc.BindFlags = BindFlags.None;

                using (Texture2D dest = new Texture2D(_dev, desc))
                {
                    _dev.ImmediateContext.CopyResource(source, dest);

                    SharpDX.DataBox data = _dev.ImmediateContext.MapSubresource(dest, 0,
                        MapMode.Read, SharpDX.Direct3D11.MapFlags.None);

                    if (_imageCapture == null || _imageCapture.Width != desc.Width || _imageCapture.Height != desc.Height)
                    {
                        _imageCapture = new ImageCapture((uint)desc.Width, (uint)desc.Height);
                    }

                    byte[] dst = _imageCapture.Pixels;
                    IntPtr src = data.DataPointer;

                    for (int i = 0; i < desc.Height; ++i)
                    {
                        int dstRow = i * (int)_imageCapture.Stride;
                        int srcRow = i * data.RowPitch;

                        for (int j = 0; j < desc.Width; j++)
                        {
                            // RGBA -> BGRA
                            dst[dstRow + 4 * j + 2] = Noesis.Marshal.ReadByte(src, srcRow + 4 * j + 0);
                            dst[dstRow + 4 * j + 1] = Noesis.Marshal.ReadByte(src, srcRow + 4 * j + 1);
                            dst[dstRow + 4 * j + 0] = Noesis.Marshal.ReadByte(src, srcRow + 4 * j + 2);
                            dst[dstRow + 4 * j + 3] = Noesis.Marshal.ReadByte(src, srcRow + 4 * j + 3);
                        }
                    }

                    _dev.ImmediateContext.UnmapSubresource(dest, 0);
                }
            }

            return _imageCapture;
        }

        public override void Swap()
        {
            _swapChain.Present(_vsync ? 1 : 0, PresentFlags.None);
        }

        public override void Resize()
        {
            _dev.ImmediateContext.OutputMerger.SetRenderTargets(null, (RenderTargetView)null);
            _renderTarget?.Dispose();
            _depthStencil?.Dispose();
            _swapChain.ResizeBuffers(0, 0, 0, Format.Unknown, SwapChainFlags.None);

            SwapChainDescription1 desc = _swapChain.Description1;
            Texture2D color = _swapChain.GetBackBuffer<Texture2D>(0);
            _renderTarget = new RenderTargetView(_dev, color);
            color.Dispose();

            Texture2DDescription textureDesc = new Texture2DDescription();
            textureDesc.Width = desc.Width;
            textureDesc.Height = desc.Height;
            textureDesc.MipLevels = 1;
            textureDesc.ArraySize = 1;
            textureDesc.SampleDescription = desc.SampleDescription;
            textureDesc.Usage = ResourceUsage.Default;
            textureDesc.BindFlags = BindFlags.DepthStencil;
            textureDesc.CpuAccessFlags = CpuAccessFlags.None;
            textureDesc.OptionFlags = ResourceOptionFlags.None;
            textureDesc.Format = Format.D24_UNorm_S8_UInt;

            Texture2D depthStencil = new Texture2D(_dev, textureDesc);
            _depthStencil = new DepthStencilView(_dev, depthStencil);
            depthStencil.Dispose();

            _viewport.X = 0.0f;
            _viewport.Y = 0.0f;
            _viewport.Width = (float)desc.Width;
            _viewport.Height = (float)desc.Height;
            _viewport.MinDepth = 0.0f;
            _viewport.MaxDepth = 1.0f;
        }

    }
}
