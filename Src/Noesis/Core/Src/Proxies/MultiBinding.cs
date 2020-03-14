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

public class MultiBinding : BindingBase {
  internal new static MultiBinding CreateProxy(IntPtr cPtr, bool cMemoryOwn) {
    return new MultiBinding(cPtr, cMemoryOwn);
  }

  internal MultiBinding(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
  }

  internal static HandleRef getCPtr(MultiBinding obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  public object ProvideValue(object targetObject, DependencyProperty targetProperty) {
    IntPtr cPtr = ProvideValueHelper(targetObject, targetProperty);
    return Noesis.Extend.GetProxy(cPtr, true);
  }

  public Noesis.IMultiValueConverter Converter {
    get {
      return GetConverterHelper() as Noesis.IMultiValueConverter;
    }
    set {
      SetConverterHelper(value);
    }
  }

  public MultiBinding() {
  }

  protected override IntPtr CreateCPtr(Type type, out bool registerExtend) {
    registerExtend = false;
    return NoesisGUI_PINVOKE.new_MultiBinding();
  }

  public BindingCollection Bindings {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.MultiBinding_Bindings_get(swigCPtr);
      return (BindingCollection)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public object ConverterParameter {
    set {
      NoesisGUI_PINVOKE.MultiBinding_ConverterParameter_set(swigCPtr, Noesis.Extend.GetInstanceHandle(value));
    }
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.MultiBinding_ConverterParameter_get(swigCPtr);
      return Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public BindingMode Mode {
    set {
      NoesisGUI_PINVOKE.MultiBinding_Mode_set(swigCPtr, (int)value);
    } 
    get {
      BindingMode ret = (BindingMode)NoesisGUI_PINVOKE.MultiBinding_Mode_get(swigCPtr);
      return ret;
    } 
  }

  public UpdateSourceTrigger UpdateSourceTrigger {
    set {
      NoesisGUI_PINVOKE.MultiBinding_UpdateSourceTrigger_set(swigCPtr, (int)value);
    } 
    get {
      UpdateSourceTrigger ret = (UpdateSourceTrigger)NoesisGUI_PINVOKE.MultiBinding_UpdateSourceTrigger_get(swigCPtr);
      return ret;
    } 
  }

  private IntPtr ProvideValueHelper(object targetObject, DependencyProperty targetProperty) {
    IntPtr ret = NoesisGUI_PINVOKE.MultiBinding_ProvideValueHelper(swigCPtr, Noesis.Extend.GetInstanceHandle(targetObject), DependencyProperty.getCPtr(targetProperty));
    return ret;
  }

  private object GetConverterHelper() {
    IntPtr cPtr = NoesisGUI_PINVOKE.MultiBinding_GetConverterHelper(swigCPtr);
    return Noesis.Extend.GetProxy(cPtr, false);
  }

  private void SetConverterHelper(object converter) {
    NoesisGUI_PINVOKE.MultiBinding_SetConverterHelper(swigCPtr, Noesis.Extend.GetInstanceHandle(converter));
  }

}

}

