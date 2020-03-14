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

public class KeyGesture : InputGesture {
  internal new static KeyGesture CreateProxy(IntPtr cPtr, bool cMemoryOwn) {
    return new KeyGesture(cPtr, cMemoryOwn);
  }

  internal KeyGesture(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
  }

  internal static HandleRef getCPtr(KeyGesture obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  public KeyGesture() {
  }

  protected override IntPtr CreateCPtr(Type type, out bool registerExtend) {
    registerExtend = false;
    return NoesisGUI_PINVOKE.new_KeyGesture__SWIG_0();
  }

  public KeyGesture(Key key, ModifierKeys modifiers) : this(NoesisGUI_PINVOKE.new_KeyGesture__SWIG_1((int)key, (int)modifiers), true) {
  }

  public KeyGesture(Key key) : this(NoesisGUI_PINVOKE.new_KeyGesture__SWIG_2((int)key), true) {
  }

  public Key Key {
    get {
      Key ret = (Key)NoesisGUI_PINVOKE.KeyGesture_Key_get(swigCPtr);
      return ret;
    } 
  }

  public ModifierKeys Modifiers {
    get {
      ModifierKeys ret = (ModifierKeys)NoesisGUI_PINVOKE.KeyGesture_Modifiers_get(swigCPtr);
      return ret;
    } 
  }

  public string DisplayString {
    get {
      IntPtr strPtr = NoesisGUI_PINVOKE.KeyGesture_DisplayString_get(swigCPtr);
      string str = Noesis.Extend.StringFromNativeUtf8(strPtr);
      NoesisGUI_PINVOKE.FreeString(strPtr);
      return str;
    }
  }

}

}

