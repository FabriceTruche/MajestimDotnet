// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGMouseEventsProcessing
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

namespace TenTec.Windows.iGridLib
{
  internal class iGMouseEventsProcessing
  {
    public static void MouseMove(iGMouseProcessingStyle style, ref iGControlState state, bool isMouseOver, out bool invalidate, bool somePressed, out iGMouseEvents events)
    {
      events = iGMouseEvents.None;
      iGControlState iGcontrolState = state;
      if (style != iGMouseProcessingStyle.PushButton)
      {
        if (style == iGMouseProcessingStyle.Thumb)
        {
          if (somePressed)
          {
            invalidate = false;
            return;
          }
          state = !isMouseOver ? iGControlState.Normal : iGControlState.Hot;
        }
      }
      else
        state = !somePressed ? (!isMouseOver ? iGControlState.Normal : iGControlState.Hot) : (state == iGControlState.Pressed || state == iGControlState.HotPressed ? (!isMouseOver ? iGControlState.Pressed : iGControlState.HotPressed) : iGControlState.Normal);
      if (iGcontrolState == iGControlState.Normal)
      {
        if (state == iGControlState.Hot)
          events = events | iGMouseEvents.Enter;
      }
      else if (state == iGControlState.Normal && (iGcontrolState == iGControlState.Hot || iGcontrolState == iGControlState.Pressed))
        events = events | iGMouseEvents.Leave;
      if (somePressed)
      {
        if (state == iGControlState.Pressed || state == iGControlState.HotPressed)
          events = events | iGMouseEvents.Move;
      }
      else if (isMouseOver)
        events = events | iGMouseEvents.Move;
      invalidate = state != iGcontrolState;
    }

    public static void MouseLeave(iGMouseProcessingStyle style, ref iGControlState state, out bool invalidate, out iGMouseEvents events)
    {
      events = iGMouseEvents.None;
      if (state == iGControlState.Normal)
      {
        invalidate = false;
      }
      else
      {
        events = events | iGMouseEvents.Leave;
        state = iGControlState.Normal;
        invalidate = true;
      }
    }

    public static void MouseLeftDown(iGMouseProcessingStyle style, ref iGControlState state, bool isMouseOver, out bool invalidate, out iGMouseEvents events)
    {
      events = iGMouseEvents.None;
      if (isMouseOver)
      {
        state = style != iGMouseProcessingStyle.Thumb ? iGControlState.HotPressed : iGControlState.Pressed;
        events = events | iGMouseEvents.Down;
        invalidate = true;
      }
      else
        invalidate = false;
    }

    public static void MouseLeftUp(iGMouseProcessingStyle style, ref iGControlState state, bool isMouseOver, bool somePressed, out bool invalidate, out iGMouseEvents events)
    {
      iGControlState iGcontrolState = state;
      events = iGMouseEvents.None;
      if (isMouseOver)
        state = iGControlState.Hot;
      else if (iGcontrolState == iGControlState.Pressed || iGcontrolState == iGControlState.HotPressed)
        state = iGControlState.Normal;
      if (iGcontrolState == iGControlState.Pressed || iGcontrolState == iGControlState.HotPressed)
      {
        if (state == iGControlState.Hot)
          events = events | iGMouseEvents.Up | iGMouseEvents.Click;
        else if (state == iGControlState.Normal)
          events = events | iGMouseEvents.Up;
      }
      else if (!somePressed && state == iGControlState.Hot)
        events = events | iGMouseEvents.Up;
      invalidate = state != iGcontrolState;
    }
  }
}
