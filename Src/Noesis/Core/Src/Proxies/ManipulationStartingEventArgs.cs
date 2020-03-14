//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.10
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


using System;
using System.Runtime.InteropServices;

namespace Noesis
{

public class ManipulationStartingEventArgs : InputEventArgs {
  private HandleRef swigCPtr;

  internal ManipulationStartingEventArgs(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(ManipulationStartingEventArgs obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~ManipulationStartingEventArgs() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          NoesisGUI_PINVOKE.delete_ManipulationStartingEventArgs(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  internal static new void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args) {
    ManipulationStartingEventHandler handler_ = (ManipulationStartingEventHandler)handler;
    if (handler_ != null) {
      handler_(Extend.GetProxy(sender, false), new ManipulationStartingEventArgs(args, false));
    }
  }

  public UIElement ManipulationContainer {
    get {
      return GetManipulationContainerHelper();
    }
    set {
      SetManipulationContainerHelper(value);
    }
  }

  public ManipulationModes Mode {
    set {
      NoesisGUI_PINVOKE.ManipulationStartingEventArgs_Mode_set(swigCPtr, (int)value);
    } 
    get {
      ManipulationModes ret = (ManipulationModes)NoesisGUI_PINVOKE.ManipulationStartingEventArgs_Mode_get(swigCPtr);
      return ret;
    } 
  }

  public ManipulationStartingEventArgs(object source, RoutedEvent arg1, Visual container) : this(NoesisGUI_PINVOKE.new_ManipulationStartingEventArgs(Noesis.Extend.GetInstanceHandle(source), RoutedEvent.getCPtr(arg1), Visual.getCPtr(container)), true) {
  }

  public bool Cancel() {
    bool ret = NoesisGUI_PINVOKE.ManipulationStartingEventArgs_Cancel(swigCPtr);
    return ret;
  }

  private UIElement GetManipulationContainerHelper() {
    IntPtr cPtr = NoesisGUI_PINVOKE.ManipulationStartingEventArgs_GetManipulationContainerHelper(swigCPtr);
    return (UIElement)Noesis.Extend.GetProxy(cPtr, false);
  }

  private void SetManipulationContainerHelper(UIElement container) {
    NoesisGUI_PINVOKE.ManipulationStartingEventArgs_SetManipulationContainerHelper(swigCPtr, UIElement.getCPtr(container));
  }

}

}

