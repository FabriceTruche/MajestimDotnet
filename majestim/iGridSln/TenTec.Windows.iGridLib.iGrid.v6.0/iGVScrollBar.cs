// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGVScrollBar
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  internal class iGVScrollBar : iGScrollBarBase
  {
    private static int fDefaultBtnHeight = SystemInformation.VerticalScrollBarArrowHeight;

    public iGVScrollBar(bool suppressOnPaint, bool selectable, bool fixedWidth)
      : base(suppressOnPaint, selectable)
    {
      if (fixedWidth)
        this.SetStyle(ControlStyles.FixedWidth, true);
      this.Initialize();
    }

    public iGVScrollBar()
    {
      this.Initialize();
    }

    private void Initialize()
    {
      this.fParts[this.fButtonBackIndex] = iGScrollBarPart.ButtonUp;
      this.fParts[this.fButtonForwardIndex] = iGScrollBarPart.ButtonDown;
      this.fParts[this.fThumbIndex] = iGScrollBarPart.ThumbVert;
      this.fParts[this.fTrackBackIndex] = iGScrollBarPart.UpperTrackVert;
      this.fParts[this.fTrackForwardIndex] = iGScrollBarPart.LowerTrackVert;
    }

    internal override void SetSubControlsBounds()
    {
      int buttonSize = this.GetButtonSize();
      int y1 = 0;
      int height1 = this.Height;
      for (int index = 5; index < this.fSubCount; ++index)
      {
        if (((iGScrollBarCustomButtonSubControl) this.fSubControls[index]).fAlignment == iGScrollBarCustomButtonAlign.Near)
        {
          this.fSubControls[index].Bounds = new Rectangle(0, y1, this.Width, buttonSize);
          y1 += buttonSize;
        }
      }
      for (int index = this.fSubCount - 1; index >= 5; --index)
      {
        if (((iGScrollBarCustomButtonSubControl) this.fSubControls[index]).fAlignment == iGScrollBarCustomButtonAlign.Far)
        {
          this.fSubControls[index].Bounds = new Rectangle(0, height1 - buttonSize, this.Width, buttonSize);
          height1 -= buttonSize;
        }
      }
      int y2 = y1;
      int y3 = height1 - buttonSize;
      int y4 = y2 + buttonSize;
      int num = y3 - 1;
      this.fSubControls[this.fButtonBackIndex].Bounds = new Rectangle(0, y2, this.Width, buttonSize);
      this.fSubControls[this.fButtonForwardIndex].Bounds = new Rectangle(0, y3, this.Width, buttonSize);
      int height2 = this.GetThumbSizeFromKoef();
      if (height2 < 16)
        height2 = !this.IsShowThumb() ? 0 : 16;
      else if (!this.IsShowThumb())
        height2 = 0;
      int y5 = height2 != 0 ? y4 + this.GetThumbPos() : y4;
      this.fSubControls[this.fThumbIndex].Bounds = new Rectangle(0, y5, this.Width, height2);
      this.fSubControls[this.fTrackBackIndex].Bounds = new Rectangle(0, y4, this.Width, y5 - y4);
      this.fSubControls[this.fTrackForwardIndex].Bounds = new Rectangle(0, y5 + height2, this.Width, num - y5 - height2 + 1);
    }

    internal override int GetButtonSize()
    {
      int buttonCount = this.GetButtonCount();
      if (this.Height < buttonCount * iGVScrollBar.fDefaultBtnHeight)
        return this.Height / buttonCount;
      return iGVScrollBar.fDefaultBtnHeight;
    }

    internal override int GetThumbTrackSize()
    {
      return this.Height - this.GetButtonCount() * this.GetButtonSize();
    }

    internal override bool IsShowThumb()
    {
      if (this.Height - this.GetButtonCount() * iGVScrollBar.fDefaultBtnHeight >= 16)
        return base.IsShowThumb();
      return false;
    }

    internal void ProcessMouseDown(MouseEventArgs e)
    {
      this.OnMouseDown(e);
    }

    internal void ProcessMouseUp(MouseEventArgs e)
    {
      this.OnMouseUp(e);
    }

    internal void ProcessMouseMove(MouseEventArgs e)
    {
      this.OnMouseMove(e);
    }

    internal void ProcessMouseLeave(EventArgs e)
    {
      this.OnMouseLeave(e);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      if (this.fSubControls[this.fThumbIndex].State == iGControlState.Pressed)
      {
        Point beginThumbLocation = this.fDragBeginThumbLocation;
        Point dragBeginMousePos = this.fDragBeginMousePos;
        int pos = beginThumbLocation.Y + this.PointToScreen(new Point(e.X, e.Y)).Y - dragBeginMousePos.Y;
        int height = this.fSubControls[this.fThumbIndex].Bounds.Height;
        int top = this.fSubControls[this.fTrackBackIndex].Bounds.Top;
        int bottom = this.fSubControls[this.fTrackForwardIndex].Bounds.Bottom;
        if (pos < top)
          pos = top;
        else if (pos + height > bottom)
          pos = bottom - height;
        if (pos == this.fSubControls[this.fThumbIndex].Bounds.Y)
          return;
        this.fSubControls[this.fThumbIndex].Bounds.Y = pos;
        this.fSubControls[this.fTrackBackIndex].Bounds.Height = pos - top;
        this.fSubControls[this.fTrackForwardIndex].Bounds.Y = pos + height;
        this.fSubControls[this.fTrackForwardIndex].Bounds.Height = bottom - (pos + height);
        int valueFromPos = this.GetValueFromPos(this.fSubControls[this.fTrackBackIndex].Bounds.Top, pos);
        this.DoValueChanging(ref valueFromPos);
        if (this.fValue != valueFromPos)
        {
          this.OnScroll(new iGScrollEventArgs(iGScrollEventType.ThumbTrack, valueFromPos));
          this.fValue = valueFromPos;
          this.OnValueChanged(EventArgs.Empty);
        }
        this.Invalidate();
        this.Update();
      }
      base.OnMouseMove(e);
    }

    internal override void OnSettingChange()
    {
      iGVScrollBar.fDefaultBtnHeight = SystemInformation.VerticalScrollBarArrowHeight;
      this.AdjustKoef();
      this.SetSubControlsBounds();
      base.OnSettingChange();
    }

    public void SetDefaultWidth()
    {
      this.Width = SystemInformation.VerticalScrollBarWidth;
    }

    protected override Size DefaultSize
    {
      get
      {
        return new Size(SystemInformation.VerticalScrollBarWidth, 80);
      }
    }
  }
}
