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

public class RoutedEventArgs : EventArgs {
  private HandleRef swigCPtr;

  internal RoutedEventArgs(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(RoutedEventArgs obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~RoutedEventArgs() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          NoesisGUI_PINVOKE.delete_RoutedEventArgs(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  internal static new void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args) {
    RoutedEventHandler handler_ = (RoutedEventHandler)handler;
    if (handler_ != null) {
      handler_(Extend.GetProxy(sender, false), new RoutedEventArgs(args, false));
    }
  }

  public object Source {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.RoutedEventArgs_Source_get(swigCPtr);
      return Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public RoutedEvent RoutedEvent {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.RoutedEventArgs_RoutedEvent_get(swigCPtr);
      return (RoutedEvent)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public bool Handled {
    set {
      NoesisGUI_PINVOKE.RoutedEventArgs_Handled_set(swigCPtr, value);
    } 
    get {
      bool ret = NoesisGUI_PINVOKE.RoutedEventArgs_Handled_get(swigCPtr);
      return ret;
    } 
  }

  public RoutedEventArgs(RoutedEvent routedEvent, object source) : this(NoesisGUI_PINVOKE.new_RoutedEventArgs(RoutedEvent.getCPtr(routedEvent), Noesis.Extend.GetInstanceHandle(source)), true) {
  }

}

}

