// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGScrollBarBase
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  internal abstract class iGScrollBarBase : iGScrollBarBaseControl
  {
    internal int fSmallChange = 1;
    internal int fLargeChange = 10;
    internal int fMaximum = 100;
    internal iGScrollBarPart[] fParts = new iGScrollBarPart[5];
    private bool fHotTracking = true;
    private const int cDefaultLargeChange = 10;
    private const int cDefaultSmallChange = 1;
    private const int cDefaultMaximum = 100;
    private const int cDefaultMinimum = 0;
    private const int cDefaultValue = 0;
    private const bool cSuppressOnPaint = false;
    private const bool cDefaultLocked = false;
    private const bool cDefaultMouseDownLocked = false;
    private const bool cDefaultHotTracking = true;
    internal const int cButtonsCount = 5;
    internal const int cThumbMinSize = 16;
    internal const int cDefaultLength = 80;
    private const int cLargeInterval = 500;
    private const int cSmallInterval = 50;
    internal const double cEps = 9.99999974737875E-06;
    private bool fLocked;
    internal int fButtonBackIndex;
    internal int fButtonForwardIndex;
    internal int fThumbIndex;
    internal int fTrackBackIndex;
    internal int fTrackForwardIndex;
    internal int fMinimum;
    internal int fMaxScrollPos;
    internal int fValue;
    private Timer fTimer;
    internal int fChange;
    private int fPressedIndex;
    internal double fKoef;
    internal iGScrollEventType fScrollEventType;
    internal Point fDragBeginMousePos;
    internal Point fDragBeginThumbLocation;
    private bool fThumbDragging;
    private bool fSuppressOnPaint;
    internal iGScrollBarCustomButtonCollection fCustomButtons;
    private ImageList fImageList;
    private iGNativeToolTip fToolTip;
    private iGScrollBarCustomButtonSubControl fToolTipObject;
    private bool fMouseDownLocked;
    private bool fDisposed;

    public iGScrollBarBase(bool suppressOnPaint, bool selectable)
      : base(5)
    {
      this.fSuppressOnPaint = suppressOnPaint;
      if (!selectable)
        this.SetStyle(ControlStyles.Selectable, false);
      this.Initialize();
    }

    public iGScrollBarBase()
      : base(5)
    {
      this.Initialize();
    }

    private void Initialize()
    {
      this.fTimer = new Timer();
      this.fTimer.Tick += new EventHandler(this.TimerTick);
      this.AdjustStyle();
      this.fButtonBackIndex = this.AddSubControl(new iGSubControl(iGMouseProcessingStyle.PushButton, true));
      this.fButtonForwardIndex = this.AddSubControl(new iGSubControl(iGMouseProcessingStyle.PushButton, true));
      this.fThumbIndex = this.AddSubControl(new iGSubControl(iGMouseProcessingStyle.Thumb, true));
      this.fTrackBackIndex = this.AddSubControl(new iGSubControl(iGMouseProcessingStyle.PushButton, true));
      this.fTrackForwardIndex = this.AddSubControl(new iGSubControl(iGMouseProcessingStyle.PushButton, true));
      this.SetSubControlsBounds();
      this.AdjustMaxScrollPos();
    }

    protected override void Dispose(bool disposing)
    {
      if (!this.fDisposed && disposing && this.fTimer != null)
      {
        this.fTimer.Stop();
        this.fTimer.Dispose();
        this.fTimer = (Timer) null;
      }
      this.fDisposed = true;
      base.Dispose(disposing);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      if (this.fMouseDownLocked)
        return;
      base.OnMouseDown(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      this.ToolTipRemoveObject();
      base.OnMouseLeave(e);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      int index;
      for (index = 5; index < this.fSubCount; ++index)
      {
        iGScrollBarCustomButtonSubControl fSubControl = this.fSubControls[index] as iGScrollBarCustomButtonSubControl;
        if (fSubControl != null && fSubControl.Bounds.Contains(e.X, e.Y))
        {
          this.ToolTipSetObject(fSubControl);
          break;
        }
      }
      if (index == this.fSubCount)
        this.ToolTipRemoveObject();
      base.OnMouseMove(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
        this.StopTimer();
      if (this.fThumbDragging)
        this.OnThumbEndDrag();
      base.OnMouseUp(e);
    }

    private void AdjustSmallChange()
    {
      if (this.fSmallChange >= 0)
        return;
      this.fSmallChange = 0;
    }

    private void AdjustLargeChange()
    {
      if (this.fLargeChange < 0)
        this.fLargeChange = 0;
      if (this.fLargeChange <= this.fMaximum - this.fMinimum + 1)
        return;
      this.fLargeChange = this.fMaximum - this.fMinimum + 1;
    }

    private void AdjustMaxScrollPos()
    {
      this.fMaxScrollPos = this.fMaximum - Math.Max(this.fLargeChange - 1, 0);
    }

    internal void AdjustValue(ref int value)
    {
      if (value > this.fMaxScrollPos)
        value = this.fMaxScrollPos;
      if (value >= this.fMinimum)
        return;
      value = this.fMinimum;
    }

    protected void StopTimer()
    {
      if (!this.fTimer.Enabled)
        return;
      this.fTimer.Stop();
      this.OnScroll(new iGScrollEventArgs(iGScrollEventType.EndScroll, this.fValue));
    }

    protected void TimerTick(object sender, EventArgs e)
    {
      if (this.fTimer.Interval == 500)
        this.fTimer.Interval = 50;
      iGSubControl fSubControl = this.fSubControls[this.fPressedIndex];
      if (fSubControl.State != iGControlState.Pressed && fSubControl.State != iGControlState.HotPressed)
      {
        this.StopTimer();
      }
      else
      {
        if (this.fPressedIndex == this.fTrackBackIndex || this.fPressedIndex == this.fTrackForwardIndex)
        {
          Point client = this.PointToClient(Control.MousePosition);
          this.OnMouseMove(new MouseEventArgs(MouseButtons.None, 0, client.X, client.Y, 0));
        }
        int newValue = this.Value + this.fChange;
        this.AdjustValue(ref newValue);
        if (fSubControl.State != iGControlState.HotPressed)
          return;
        this.OnScroll(new iGScrollEventArgs(this.fScrollEventType, newValue));
        this.Value = newValue;
      }
    }

    protected void StartTimer()
    {
      if (this.fTimer.Enabled)
        return;
      this.fTimer.Interval = 500;
      this.fTimer.Start();
    }

    internal void OnThumbPressed(Point mousePos)
    {
      if (this.fLocked)
        return;
      this.fDragBeginMousePos = mousePos;
      this.fDragBeginThumbLocation = this.fSubControls[this.fThumbIndex].Bounds.Location;
      this.fThumbDragging = true;
      // ISSUE: reference to a compiler-generated field
      if (this.Scroll == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.Scroll((object) this, new iGScrollEventArgs(iGScrollEventType.ThumbTrack, this.fValue));
    }

    internal override void OnSubControlLeftDown(int index, Point mousePos)
    {
      if (this.fLocked)
        return;
      if (index == this.fThumbIndex)
      {
        this.OnThumbPressed(this.PointToScreen(mousePos));
      }
      else
      {
        if (index == this.fButtonBackIndex)
        {
          this.fScrollEventType = iGScrollEventType.SmallDecrement;
          this.fChange = -this.fSmallChange;
        }
        else if (index == this.fButtonForwardIndex)
        {
          this.fScrollEventType = iGScrollEventType.SmallIncrement;
          this.fChange = this.fSmallChange;
        }
        else if (index == this.fTrackBackIndex)
        {
          this.fScrollEventType = iGScrollEventType.LargeDecrement;
          this.fChange = -this.fLargeChange;
        }
        else
        {
          if (index != this.fTrackForwardIndex)
            return;
          Rectangle bounds = this.fSubControls[this.fThumbIndex].Bounds;
          if (bounds.Height == 0 || bounds.Width == 0)
            return;
          this.fScrollEventType = iGScrollEventType.LargeIncrement;
          this.fChange = this.fLargeChange;
        }
        this.AdjustChange();
        int newValue = this.Value + this.fChange;
        this.AdjustValue(ref newValue);
        this.OnScroll(new iGScrollEventArgs(this.fScrollEventType, newValue));
        this.Value = newValue;
        this.fPressedIndex = index;
        this.StartTimer();
      }
    }

    internal virtual void AdjustChange()
    {
    }

    protected override void OnSizeChanged(EventArgs e)
    {
      this.AdjustKoef();
      base.OnSizeChanged(e);
    }

    internal int GetThumbSizeFromKoef()
    {
      return (int) (this.fKoef * (double) this.fLargeChange + 9.99999974737875E-06);
    }

    protected override void OnCancelMode(EventArgs e)
    {
      if (!this.fThumbDragging)
        return;
      this.OnThumbEndDrag();
    }

    private void OnThumbEndDrag()
    {
      this.SetSubControlsBounds();
      this.fThumbDragging = false;
      this.Invalidate();
      // ISSUE: reference to a compiler-generated field
      if (this.Scroll == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.Scroll((object) this, new iGScrollEventArgs(iGScrollEventType.ThumbPosition, this.fValue));
      // ISSUE: reference to a compiler-generated field
      this.Scroll((object) this, new iGScrollEventArgs(iGScrollEventType.EndScroll, this.fValue));
    }

    protected virtual void OnValueChanging(iGScrollBarValueChangingEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.ValueChanging == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.ValueChanging((object) this, e);
    }

    protected virtual void OnValueChanged(EventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.ValueChanged == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.ValueChanged((object) this, e);
    }

    protected virtual void OnScroll(iGScrollEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.Scroll == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.Scroll((object) this, e);
    }

    internal abstract int GetButtonSize();

    internal abstract int GetThumbTrackSize();

    internal void AdjustKoef()
    {
      int thumbTrackSize = this.GetThumbTrackSize();
      this.fKoef = (double) thumbTrackSize / (double) (this.fMaximum - this.fMinimum + 1);
      if (this.GetThumbSizeFromKoef() >= 16)
        return;
      if (this.IsShowThumb())
        this.fKoef = (double) (thumbTrackSize - 16) / (double) (this.fMaxScrollPos - this.fMinimum);
      else
        this.fKoef = 0.0;
    }

    private iGControlState GetCommonElementState(int index)
    {
      if (!this.Enabled || !this.fSubControls[index].Enabled || this.fLocked)
        return iGControlState.Disabled;
      iGControlState iGcontrolState = this.fSubControls[index].State;
      if (!this.fHotTracking && iGcontrolState == iGControlState.Hot)
        iGcontrolState = iGControlState.Normal;
      return iGcontrolState;
    }

    public void PaintTo(Graphics g, int xOffset, int yOffset)
    {
      IiGControlPaint iGcontrolPaint1;
      if (this.fCustomControlPaint != null && (this.fCustomControlPaint.SupportedFunctions & iGControlPaintFunctions.ScrollBar) == iGControlPaintFunctions.ScrollBar)
      {
        iGcontrolPaint1 = this.fCustomControlPaint;
      }
      else
      {
        iGcontrolPaint1 = (IiGControlPaint) this.fControlPaintStyle.ControlPaint;
        g.Clear(iGcontrolPaint1.ControlsBackColor);
      }
      bool enabled = this.Enabled;
      if (this.Width <= 1 || this.Height <= 1)
        return;
      Rectangle bounds = this.fSubControls[this.fButtonBackIndex].Bounds;
      iGControlState commonElementState1 = this.GetCommonElementState(this.fButtonBackIndex);
      iGcontrolPaint1.DrawScrollBar(g, bounds.X + xOffset, bounds.Y + yOffset, bounds.Width, bounds.Height, this.fParts[this.fButtonBackIndex], commonElementState1);
      bounds = this.fSubControls[this.fButtonForwardIndex].Bounds;
      iGControlState commonElementState2 = this.GetCommonElementState(this.fButtonForwardIndex);
      iGcontrolPaint1.DrawScrollBar(g, bounds.X + xOffset, bounds.Y + yOffset, bounds.Width, bounds.Height, this.fParts[this.fButtonForwardIndex], commonElementState2);
      int num1 = this.IsShowThumb() ? 1 : 0;
      bool flag = this.RightToLeft == RightToLeft.Yes;
      int num2 = flag ? 1 : 0;
      if ((num1 | num2) != 0)
      {
        bounds = this.fSubControls[this.fTrackBackIndex].Bounds;
        iGControlState commonElementState3 = this.GetCommonElementState(this.fTrackBackIndex);
        iGcontrolPaint1.DrawScrollBar(g, bounds.X + xOffset, bounds.Y + yOffset, bounds.Width, bounds.Height, this.fParts[this.fTrackBackIndex], commonElementState3);
      }
      if (num1 != 0 || !flag)
      {
        bounds = this.fSubControls[this.fTrackForwardIndex].Bounds;
        iGControlState commonElementState3 = this.GetCommonElementState(this.fTrackForwardIndex);
        iGcontrolPaint1.DrawScrollBar(g, bounds.X + xOffset, bounds.Y + yOffset, bounds.Width, bounds.Height, this.fParts[this.fTrackForwardIndex], commonElementState3);
      }
      if (num1 != 0)
      {
        bounds = this.fSubControls[this.fThumbIndex].Bounds;
        iGControlState controlState = enabled ? this.fSubControls[this.fThumbIndex].State : iGControlState.Disabled;
        if (!this.fHotTracking && controlState == iGControlState.Hot)
          controlState = iGControlState.Normal;
        iGcontrolPaint1.DrawScrollBar(g, bounds.X + xOffset, bounds.Y + yOffset, bounds.Width, bounds.Height, this.fParts[this.fThumbIndex], controlState);
      }
      IiGControlPaint iGcontrolPaint2 = this.fCustomControlPaint == null || (this.fCustomControlPaint.SupportedFunctions & iGControlPaintFunctions.ScrollBarCustomButton) != iGControlPaintFunctions.ScrollBarCustomButton ? (IiGControlPaint) this.fControlPaintStyle.ControlPaint : this.fCustomControlPaint;
      iGIndent customButtonIndent = iGcontrolPaint2.GetScrollBarCustomButtonIndent;
      for (int index = 5; index < this.fSubCount; ++index)
      {
        iGScrollBarCustomButtonSubControl fSubControl = this.fSubControls[index] as iGScrollBarCustomButtonSubControl;
        if (fSubControl != null)
        {
          bounds = fSubControl.Bounds;
          if (bounds.Width > 0 && bounds.Height > 0)
          {
            iGControlState iGcontrolState = !enabled || !this.fSubControls[index].Enabled ? iGControlState.Disabled : fSubControl.State;
            if (!this.fHotTracking && iGcontrolState == iGControlState.Hot)
              iGcontrolState = iGControlState.Normal;
            bounds.Offset(xOffset, yOffset);
            iGScrollBarCustomButtonDrawEventArgs e = new iGScrollBarCustomButtonDrawEventArgs(index - 5, bounds, iGcontrolState, g);
            this.OnCustBtnDrawBackground(e);
            if (!e.Handled)
              iGcontrolPaint2.DrawScrollBarCustomButton(g, bounds.X, bounds.Y, bounds.Width, bounds.Height, iGcontrolState);
            bounds.X += customButtonIndent.fLeft;
            bounds.Width -= customButtonIndent.fLeft + customButtonIndent.fRight;
            bounds.Y += customButtonIndent.fTop;
            bounds.Height -= customButtonIndent.fTop + customButtonIndent.fBottom;
            if (iGcontrolPaint2.OffsetScrollBarCustomButtonImageWhenPressed && iGcontrolState == iGControlState.HotPressed)
              bounds.Offset(1, 1);
            e.Handled = false;
            this.OnCustBtnDrawForeground(e);
            if (!e.Handled && this.fImageList != null && (fSubControl.fImageIndex >= 0 && fSubControl.fImageIndex < this.fImageList.Images.Count))
            {
              int x = bounds.X;
              int y = bounds.Y;
              Size imageSize = this.fImageList.ImageSize;
              int width = imageSize.Width;
              imageSize = this.fImageList.ImageSize;
              int height = imageSize.Height;
              iGAligner.AdjustImageLocation(ref x, ref y, bounds.Width, bounds.Height, width, height, ContentAlignment.MiddleCenter, new iGIndent(), false);
              this.fImageList.Draw(g, x, y, width, height, fSubControl.fImageIndex);
            }
          }
        }
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      if (this.fSuppressOnPaint)
        return;
      this.PaintTo(e.Graphics, 0, 0);
      base.OnPaint(e);
    }

    private void AdjustStyle()
    {
      this.SetStyle(ControlStyles.DoubleBuffer, !this.fSuppressOnPaint);
      this.SetStyle(ControlStyles.Opaque, this.fSuppressOnPaint);
    }

    internal virtual bool IsShowThumb()
    {
      return !this.fLocked;
    }

    protected void OnCustBtnDrawBackground(iGScrollBarCustomButtonDrawEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.CustBtnDrawBackground == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.CustBtnDrawBackground((object) this, e);
    }

    protected void OnCustBtnDrawForeground(iGScrollBarCustomButtonDrawEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.CustBtnDrawForeground == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.CustBtnDrawForeground((object) this, e);
    }

    internal override void OnSubControlLeftClick(int index)
    {
      if (index >= 5 && this.fSubControls[index].Enabled)
        this.OnCustBtnClick(new iGScrollBarCustomButtonClickEventArgs(index - 5, Control.ModifierKeys));
      base.OnSubControlLeftClick(index);
    }

    protected void OnCustBtnClick(iGScrollBarCustomButtonClickEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.CustBtnClick == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.CustBtnClick((object) this, e);
    }

    internal override void OnSubControlMouseDown(int index, Point mousePos, MouseButtons buttons)
    {
      if (index >= 5 && this.fSubControls[index].Enabled)
        this.OnCustBtnMouseDown(new iGScrollBarCustomButtonMouseDownUpEventArgs(index - 5, mousePos, buttons, Control.ModifierKeys, this.fSubControls[index].Bounds));
      base.OnSubControlMouseDown(index, mousePos, buttons);
    }

    protected void OnCustBtnMouseDown(iGScrollBarCustomButtonMouseDownUpEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.CustBtnMouseDown == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.CustBtnMouseDown((object) this, e);
    }

    internal override void OnSubControlMouseUp(int index, Point mousePos, MouseButtons buttons)
    {
      if (index >= 5 && this.fSubControls[index].Enabled)
        this.OnCustBtnMouseUp(new iGScrollBarCustomButtonMouseDownUpEventArgs(index - 5, mousePos, buttons, Control.ModifierKeys, this.fSubControls[index].Bounds));
      base.OnSubControlMouseUp(index, mousePos, buttons);
    }

    protected void OnCustBtnMouseUp(iGScrollBarCustomButtonMouseDownUpEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.CustBtnMouseUp == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.CustBtnMouseUp((object) this, e);
    }

    internal override void OnSubControlMouseLeave(int index)
    {
      if (index >= 5 && this.fSubControls[index].Enabled)
        this.OnCustBtnMouseLeave(new iGScrollBarCustomButtonMouseEnterLeaveEventArgs(index - 5, this.fSubControls[index].Bounds));
      base.OnSubControlMouseLeave(index);
    }

    internal override void OnSubControlMouseEnter(int index)
    {
      if (index >= 5 && this.fSubControls[index].Enabled)
        this.OnCustBtnMouseEnter(new iGScrollBarCustomButtonMouseEnterLeaveEventArgs(index - 5, this.fSubControls[index].Bounds));
      base.OnSubControlMouseEnter(index);
    }

    internal override void OnSubControlMouseMove(int index, Point mousePos)
    {
      if (index >= 5 && this.fSubControls[index].Enabled)
        this.OnCustBtnMouseMove(new iGScrollBarCustomButtonMouseMoveEventArgs(index - 5, mousePos, this.fSubControls[index].Bounds));
      base.OnSubControlMouseMove(index, mousePos);
    }

    protected void OnCustBtnMouseLeave(iGScrollBarCustomButtonMouseEnterLeaveEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.CustBtnMouseLeave == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.CustBtnMouseLeave((object) this, e);
    }

    protected void OnCustBtnMouseEnter(iGScrollBarCustomButtonMouseEnterLeaveEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.CustBtnMouseEnter == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.CustBtnMouseEnter((object) this, e);
    }

    protected void OnCustBtnMouseMove(iGScrollBarCustomButtonMouseMoveEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.CustBtnMouseMove == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.CustBtnMouseMove((object) this, e);
    }

    internal int GetButtonCount()
    {
      return 2 + this.fSubCount - 5;
    }

    internal int GetThumbPos()
    {
      int fValue = this.fValue;
      this.AdjustValue(ref fValue);
      return (int) Math.Ceiling((double) (fValue - this.fMinimum) * this.fKoef - 9.99999974737875E-06);
    }

    internal int GetValueFromPos(int trackNear, int pos)
    {
      if (pos == trackNear)
        return this.fMinimum;
      return (int) (((double) (pos - trackNear) + 9.99999974737875E-06) / this.fKoef) + this.fMinimum;
    }

    internal void DoValueChanging(ref int value)
    {
      this.AdjustValue(ref value);
      iGScrollBarValueChangingEventArgs e = new iGScrollBarValueChangingEventArgs(value);
      this.OnValueChanging(e);
      value = e.Value;
      this.AdjustValue(ref value);
    }

    private void ToolTipSetObject(iGScrollBarCustomButtonSubControl subControl)
    {
      if (this.fToolTipObject == subControl)
        return;
      if (subControl.fToolTipText != null)
      {
        if (this.fToolTip == null)
          this.fToolTip = new iGNativeToolTip((Control) this, false);
        if (!this.fToolTip.Visible)
          this.fToolTip.Active = false;
        this.fToolTip.SetText(subControl.fToolTipText);
        this.fToolTipObject = subControl;
        this.fToolTip.Active = true;
      }
      else
        this.ToolTipRemoveObject();
    }

    private void ToolTipRemoveObject()
    {
      if (this.fToolTip == null)
        return;
      this.fToolTipObject = (iGScrollBarCustomButtonSubControl) null;
      this.fToolTip.Reset();
    }

    [DefaultValue(10)]
    public int LargeChange
    {
      get
      {
        return this.fLargeChange;
      }
      set
      {
        if (this.fLargeChange == value)
          return;
        this.fLargeChange = value;
        this.AdjustLargeChange();
        this.AdjustMaxScrollPos();
        this.AdjustKoef();
        this.SetSubControlsBounds();
        this.Invalidate();
      }
    }

    [DefaultValue(1)]
    public int SmallChange
    {
      get
      {
        return this.fSmallChange;
      }
      set
      {
        if (this.fSmallChange == value)
          return;
        this.fSmallChange = value;
        this.AdjustSmallChange();
        this.Invalidate();
      }
    }

    [DefaultValue(0)]
    public int Value
    {
      get
      {
        return this.fValue;
      }
      set
      {
        this.DoValueChanging(ref value);
        if (value == this.fValue)
          return;
        this.fValue = value;
        this.SetSubControlsBounds();
        this.Invalidate();
        this.Update();
        this.OnValueChanged(EventArgs.Empty);
      }
    }

    [DefaultValue(0)]
    public int Minimum
    {
      get
      {
        return this.fMinimum;
      }
      set
      {
        if (this.fMinimum == value)
          return;
        this.fMinimum = value;
        if (this.fMinimum >= this.fMaximum)
          this.fMinimum = this.fMaximum - 1;
        this.AdjustLargeChange();
        this.AdjustSmallChange();
        this.AdjustKoef();
        this.SetSubControlsBounds();
        this.Invalidate();
      }
    }

    [DefaultValue(100)]
    public int Maximum
    {
      get
      {
        return this.fMaximum;
      }
      set
      {
        if (this.fMaximum == value)
          return;
        this.fMaximum = value;
        if (this.fMaximum <= this.fMinimum)
          this.fMaximum = this.fMinimum + 1;
        this.AdjustLargeChange();
        this.AdjustSmallChange();
        this.AdjustMaxScrollPos();
        this.AdjustKoef();
        this.SetSubControlsBounds();
        this.Invalidate();
      }
    }

    public int MaxScrollPos
    {
      get
      {
        return this.fMaxScrollPos;
      }
    }

    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams createParams = base.CreateParams;
        if (this.fSuppressOnPaint)
          createParams.ExStyle |= 32;
        return createParams;
      }
    }

    [DefaultValue(false)]
    public bool SuppressOnPaint
    {
      get
      {
        return this.fSuppressOnPaint;
      }
      set
      {
        if (this.fSuppressOnPaint == value)
          return;
        this.fSuppressOnPaint = value;
        this.AdjustStyle();
        this.UpdateStyles();
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public iGScrollBarCustomButtonCollection CustomButtons
    {
      get
      {
        if (this.fCustomButtons == null)
          this.fCustomButtons = new iGScrollBarCustomButtonCollection(this);
        return this.fCustomButtons;
      }
    }

    [Category("Appearance")]
    [DefaultValue(null)]
    public ImageList ImageList
    {
      get
      {
        return this.fImageList;
      }
      set
      {
        if (this.fImageList == value)
          return;
        this.fImageList = value;
        this.Invalidate();
      }
    }

    [DefaultValue(false)]
    public bool Locked
    {
      get
      {
        return this.fLocked;
      }
      set
      {
        if (this.fLocked == value)
          return;
        this.fLocked = value;
        this.SetSubControlsBounds();
        this.AdjustKoef();
        this.Invalidate();
      }
    }

    [DefaultValue(false)]
    [Browsable(false)]
    public bool MouseDownLocked
    {
      get
      {
        return this.fMouseDownLocked;
      }
      set
      {
        this.fMouseDownLocked = value;
      }
    }

    [DefaultValue(true)]
    [Browsable(false)]
    public bool HotTracking
    {
      get
      {
        return this.fHotTracking;
      }
      set
      {
        this.fHotTracking = value;
      }
    }

    [Category("Action")]
    public event iGScrollEventHandler Scroll;

    [Category("Action")]
    public event EventHandler ValueChanged;

    [Category("Action")]
    public event iGScrollBarValueChangingEventHandler ValueChanging;

    [Category("Appearance")]
    public event iGScrollBarCustomButtonDrawEventHandler CustBtnDrawBackground;

    [Category("Appearance")]
    public event iGScrollBarCustomButtonDrawEventHandler CustBtnDrawForeground;

    [Category("Mouse")]
    public event iGScrollBarCustomButtonMouseDownUpEventHandler CustBtnMouseDown;

    [Category("Mouse")]
    public event iGScrollBarCustomButtonMouseDownUpEventHandler CustBtnMouseUp;

    [Category("Mouse")]
    public event iGScrollBarCustomButtonMouseEnterLeaveEventHandler CustBtnMouseEnter;

    [Category("Mouse")]
    public event iGScrollBarCustomButtonMouseEnterLeaveEventHandler CustBtnMouseLeave;

    [Category("Mouse")]
    public event iGScrollBarCustomButtonMouseMoveEventHandler CustBtnMouseMove;

    [Category("Action")]
    public event iGScrollBarCustomButtonClickEventHandler CustBtnClick;
  }
}
