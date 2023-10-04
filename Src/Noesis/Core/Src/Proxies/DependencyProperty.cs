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

public partial class DependencyProperty : BaseComponent {
  internal new static DependencyProperty CreateProxy(IntPtr cPtr, bool cMemoryOwn) {
    return new DependencyProperty(cPtr, cMemoryOwn);
  }

  internal DependencyProperty(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
  }

  internal static HandleRef getCPtr(DependencyProperty obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  protected DependencyProperty() {
  }

  internal static IntPtr UnsetValuePtr = NoesisGUI_PINVOKE.DependencyProperty_GetUnsetValue();
  private static NamedObject _unsetValue;
  public static object UnsetValue {
    get {
      if (_unsetValue == null || _unsetValue.IsDisposed) {
        _unsetValue = new NamedObject("DependencyProperty.UnsetValue", UnsetValuePtr);
      }
      return _unsetValue;
    }
  }

  public Type OwnerType {
    get {
      return Noesis.Extend.GetNativeTypeInfo(GetOwnerTypeHelper()).Type;
    }
  }

  public Type PropertyType {
    get {
      if (OriginalPropertyType == null) {
        return Noesis.Extend.GetNativeTypeInfo(GetPropertyTypeHelper()).Type;
      }
      else {
        return OriginalPropertyType;
      }
    }
  }

  public Noesis.PropertyMetadata Metadata {
    get {
      return GetMetadataHelper(GetOwnerTypeHelper());
    }
  }

  public Noesis.PropertyMetadata GetMetadata(Type forType) {
    if (forType == null) {
      throw new ArgumentNullException("forType");
    }
    if (!typeof(DependencyObject).IsAssignableFrom(forType)) {
      throw new ArgumentException(
        "Can't get metadata for non-DependencyObject type " + forType);
    }
    return GetMetadataHelper(Noesis.Extend.GetNativeType(forType));
  }

  private static object GetUnsetValue() {
    IntPtr cPtr = NoesisGUI_PINVOKE.DependencyProperty_GetUnsetValue();
    return Noesis.Extend.GetProxy(cPtr, false);
  }

  public string Name {
    get {
      IntPtr strPtr = NoesisGUI_PINVOKE.DependencyProperty_Name_get(swigCPtr);
      string str = Noesis.Extend.StringFromNativeUtf8(strPtr);
      return str;
    }
  }

  public bool ReadOnly {
    get {
      bool ret = NoesisGUI_PINVOKE.DependencyProperty_ReadOnly_get(swigCPtr);
      return ret;
    } 
  }

  private IntPtr GetOwnerTypeHelper() {
    IntPtr ret = NoesisGUI_PINVOKE.DependencyProperty_GetOwnerTypeHelper(swigCPtr);
    return ret;
  }

  private IntPtr GetPropertyTypeHelper() {
    IntPtr ret = NoesisGUI_PINVOKE.DependencyProperty_GetPropertyTypeHelper(swigCPtr);
    return ret;
  }

  private PropertyMetadata GetMetadataHelper(IntPtr type) {
    IntPtr cPtr = NoesisGUI_PINVOKE.DependencyProperty_GetMetadataHelper(swigCPtr, type);
    return (PropertyMetadata)Noesis.Extend.GetProxy(cPtr, false);
  }

}

}

