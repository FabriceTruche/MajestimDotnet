// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGHScrollBar
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  internal class iGHScrollBar : iGScrollBarBase
  {
    private static int fDefaultBtnWidth = SystemInformation.HorizontalScrollBarArrowWidth;

    public iGHScrollBar(bool suppressOnPaint, bool selectable, bool fixedHeight)
      : base(suppressOnPaint, selectable)
    {
      if (fixedHeight)
        this.SetStyle(ControlStyles.FixedHeight, true);
      this.Initialize();
    }

    public iGHScrollBar()
    {
      this.Initialize();
    }

    private void Initialize()
    {
      this.fParts[this.fButtonBackIndex] = iGScrollBarPart.ButtonLeft;
      this.fParts[this.fButtonForwardIndex] = iGScrollBarPart.ButtonRight;
      this.fParts[this.fThumbIndex] = iGScrollBarPart.ThumbHorz;
      this.fParts[this.fTrackBackIndex] = iGScrollBarPart.UpperTrackHorz;
      this.fParts[this.fTrackForwardIndex] = iGScrollBarPart.LowerTrackHorz;
    }

    internal override void SetSubControlsBounds()
    {
      int buttonSize = this.GetButtonSize();
      int x1 = 0;
      int width = this.Width;
      bool rightToLeft = this.RightToLeft == RightToLeft.Yes;
      iGScrollBarCustomButtonAlign customButtonAlign = !rightToLeft ? iGScrollBarCustomButtonAlign.Near : iGScrollBarCustomButtonAlign.Far;
      for (int index = 5; index < this.fSubCount; ++index)
      {
        if (((iGScrollBarCustomButtonSubControl) this.fSubControls[index]).fAlignment == customButtonAlign)
        {
          this.fSubControls[index].Bounds = new Rectangle(x1, 0, buttonSize, this.Height);
          x1 += buttonSize;
        }
      }
      for (int index = this.fSubCount - 1; index >= 5; --index)
      {
        if (((iGScrollBarCustomButtonSubControl) this.fSubControls[index]).fAlignment != customButtonAlign)
        {
          this.fSubControls[index].Bounds = new Rectangle(width - buttonSize, 0, buttonSize, this.Height);
          width -= buttonSize;
        }
      }
      int x2 = x1;
      int x3 = width - buttonSize;
      int num1 = x2 + buttonSize;
      int trackRight = x3 - 1;
      this.fSubControls[this.fButtonBackIndex].Bounds = new Rectangle(x2, 0, buttonSize, this.Height);
      this.fSubControls[this.fButtonForwardIndex].Bounds = new Rectangle(x3, 0, buttonSize, this.Height);
      int num2 = this.GetThumbSizeFromKoef();
      if (num2 < 16)
        num2 = !this.IsShowThumb() ? 0 : 16;
      else if (!this.IsShowThumb())
        num2 = 0;
      int thumbPos = this.GetThumbPos(num1, trackRight, num2, rightToLeft);
      this.fSubControls[this.fThumbIndex].Bounds = new Rectangle(thumbPos, 0, num2, this.Height);
      this.fSubControls[this.fTrackBackIndex].Bounds = new Rectangle(num1, 0, thumbPos - num1, this.Height);
      this.fSubControls[this.fTrackForwardIndex].Bounds = new Rectangle(thumbPos + num2, 0, trackRight - thumbPos - num2 + 1, this.Height);
    }

    private int GetThumbPos(int trackLeft, int trackRight, int thumbSize, bool rightToLeft)
    {
      int num = thumbSize != 0 ? this.GetThumbPos() : 0;
      if (rightToLeft)
        return trackRight - num - thumbSize + 1;
      return trackLeft + num;
    }

    internal override int GetButtonSize()
    {
      int buttonCount = this.GetButtonCount();
      if (this.Width < buttonCount * iGHScrollBar.fDefaultBtnWidth)
        return this.Width / buttonCount;
      return iGHScrollBar.fDefaultBtnWidth;
    }

    internal override int GetThumbTrackSize()
    {
      return this.Width - this.GetButtonCount() * this.GetButtonSize();
    }

    internal override bool IsShowThumb()
    {
      if (this.Width - this.GetButtonCount() * iGHScrollBar.fDefaultBtnWidth >= 16)
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
        int pos = beginThumbLocation.X + this.PointToScreen(new Point(e.X, e.Y)).X - dragBeginMousePos.X;
        int width = this.fSubControls[this.fThumbIndex].Bounds.Width;
        int left = this.fSubControls[this.fTrackBackIndex].Bounds.Left;
        int right = this.fSubControls[this.fTrackForwardIndex].Bounds.Right;
        if (pos < left)
          pos = left;
        else if (pos + width > right)
          pos = right - width;
        if (pos == this.fSubControls[this.fThumbIndex].Bounds.X)
          return;
        this.fSubControls[this.fThumbIndex].Bounds.X = pos;
        this.fSubControls[this.fTrackBackIndex].Bounds.Width = pos - left;
        this.fSubControls[this.fTrackForwardIndex].Bounds.X = pos + width;
        this.fSubControls[this.fTrackForwardIndex].Bounds.Width = right - (pos + width);
        int valueFromPos = this.GetValueFromPos(left, right, width, pos);
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

    internal override void AdjustChange()
    {
      if (this.RightToLeft != RightToLeft.Yes)
        return;
      this.fChange = -this.fChange;
    }

    private int GetValueFromPos(int trackLeft, int trackRightPlusOne, int thumbWidth, int pos)
    {
      if (this.RightToLeft == RightToLeft.Yes)
        return this.GetValueFromPos(trackRightPlusOne, trackRightPlusOne + trackRightPlusOne - (pos + thumbWidth));
      return this.GetValueFromPos(trackLeft, pos);
    }

    internal override void OnSettingChange()
    {
      iGHScrollBar.fDefaultBtnWidth = SystemInformation.HorizontalScrollBarArrowWidth;
      this.AdjustKoef();
      this.SetSubControlsBounds();
      base.OnSettingChange();
    }

    protected override void OnRightToLeftChanged(EventArgs e)
    {
      this.SetSubControlsBounds();
      base.OnRightToLeftChanged(e);
    }

    public void SetDefaultHeight()
    {
      this.Height = SystemInformation.HorizontalScrollBarHeight;
    }

    protected override Size DefaultSize
    {
      get
      {
        return new Size(80, SystemInformation.HorizontalScrollBarHeight);
      }
    }
  }
}
