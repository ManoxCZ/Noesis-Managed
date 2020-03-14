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

public class ThicknessAnimation : BaseAnimation {
  internal new static ThicknessAnimation CreateProxy(IntPtr cPtr, bool cMemoryOwn) {
    return new ThicknessAnimation(cPtr, cMemoryOwn);
  }

  internal ThicknessAnimation(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
  }

  internal static HandleRef getCPtr(ThicknessAnimation obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  public static DependencyProperty ByProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.ThicknessAnimation_ByProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty FromProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.ThicknessAnimation_FromProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty ToProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.ThicknessAnimation_ToProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public Nullable<Thickness> From {
    set {
      NullableThickness tempvalue = value;
      NoesisGUI_PINVOKE.ThicknessAnimation_From_set(swigCPtr, ref tempvalue);
    }

    get {
      IntPtr ret = NoesisGUI_PINVOKE.ThicknessAnimation_From_get(swigCPtr);
      if (ret != IntPtr.Zero) {
        return Marshal.PtrToStructure<NullableThickness>(ret);
      }
      else {
        return new Nullable<Thickness>();
      }
    }

  }

  public Nullable<Thickness> To {
    set {
      NullableThickness tempvalue = value;
      NoesisGUI_PINVOKE.ThicknessAnimation_To_set(swigCPtr, ref tempvalue);
    }

    get {
      IntPtr ret = NoesisGUI_PINVOKE.ThicknessAnimation_To_get(swigCPtr);
      if (ret != IntPtr.Zero) {
        return Marshal.PtrToStructure<NullableThickness>(ret);
      }
      else {
        return new Nullable<Thickness>();
      }
    }

  }

  public Nullable<Thickness> By {
    set {
      NullableThickness tempvalue = value;
      NoesisGUI_PINVOKE.ThicknessAnimation_By_set(swigCPtr, ref tempvalue);
    }

    get {
      IntPtr ret = NoesisGUI_PINVOKE.ThicknessAnimation_By_get(swigCPtr);
      if (ret != IntPtr.Zero) {
        return Marshal.PtrToStructure<NullableThickness>(ret);
      }
      else {
        return new Nullable<Thickness>();
      }
    }

  }

  public ThicknessAnimation() {
  }

  protected override IntPtr CreateCPtr(Type type, out bool registerExtend) {
    registerExtend = false;
    return NoesisGUI_PINVOKE.new_ThicknessAnimation();
  }

}

}

