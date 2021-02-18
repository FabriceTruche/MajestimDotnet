// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGScrollBarBaseControl
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  internal abstract class iGScrollBarBaseControl : Control
  {
    private const iGInternalControlPaintStyle cControlPaintStyle = iGInternalControlPaintStyle.Style3D;
    internal bool fSomePressed;
    internal iGSubControl[] fSubControls;
    internal int fSubCount;
    internal iGControlPaintStyle fControlPaintStyle;
    internal IiGControlPaint fCustomControlPaint;
    private bool fDisposed;
    private bool fDoNotFocusOnMouseDown;

    public iGScrollBarBaseControl(int subControlsCount)
    {
      this.fSubControls = new iGSubControl[subControlsCount];
      this.ResizeRedraw = true;
      this.fControlPaintStyle = new iGControlPaintStyle();
      this.ForeColor = iGControlPaintStyle.cDefaultForeColor;
      this.BackColor = iGControlPaintStyle.cDefaultBackColor;
      SystemEvents.UserPreferenceChanged += new UserPreferenceChangedEventHandler(this.SystemEvents_UserPreferenceChanged);
    }

    protected override void Dispose(bool disposing)
    {
      if (!this.fDisposed && disposing)
      {
        SystemEvents.UserPreferenceChanged -= new UserPreferenceChangedEventHandler(this.SystemEvents_UserPreferenceChanged);
        if (this.fControlPaintStyle != null)
        {
          this.fControlPaintStyle.Dispose();
          this.fControlPaintStyle = (iGControlPaintStyle) null;
        }
      }
      this.fDisposed = true;
      base.Dispose(disposing);
    }

    private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
    {
      if (e.Category != UserPreferenceCategory.Window && e.Category != UserPreferenceCategory.Color)
        return;
      this.OnSettingChange();
    }

    internal virtual void OnSettingChange()
    {
      this.fControlPaintStyle.OnSettingChange();
      if (this.fCustomControlPaint == null)
        return;
      this.fCustomControlPaint.OnSettingChange();
    }

    internal abstract void SetSubControlsBounds();

    internal int AddSubControl(iGSubControl value)
    {
      this.ExtendSubControls();
      iGSubControl[] fSubControls = this.fSubControls;
      int fSubCount = this.fSubCount;
      this.fSubCount = fSubCount + 1;
      int index = fSubCount;
      iGSubControl iGsubControl = value;
      fSubControls[index] = iGsubControl;
      return this.fSubCount - 1;
    }

    private void ExtendSubControls()
    {
      if (this.fSubControls.Length != this.fSubCount)
        return;
      iGSubControl[] iGsubControlArray = new iGSubControl[this.fSubControls.Length * 2];
      Array.Copy((Array) this.fSubControls, 0, (Array) iGsubControlArray, 0, this.fSubControls.Length);
      this.fSubControls = iGsubControlArray;
    }

    internal void RemoveSubControlAt(int index)
    {
      this.CheckSubControlIndex(index);
      if (index != this.fSubCount - 1)
        Array.Copy((Array) this.fSubControls, index + 1, (Array) this.fSubControls, index, this.fSubCount - index - 1);
      this.fSubCount = this.fSubCount - 1;
    }

    internal int IndexOfSubControl(iGSubControl value)
    {
      for (int index = 0; index < this.fSubCount; ++index)
      {
        if (this.fSubControls[index] == value)
          return index;
      }
      return -1;
    }

    internal void InsertSubControl(int index, iGSubControl value)
    {
      if (index < 0 || index > this.fSubCount)
        throw new ArgumentOutOfRangeException();
      this.ExtendSubControls();
      if (index == this.fSubCount)
      {
        iGSubControl[] fSubControls = this.fSubControls;
        int fSubCount = this.fSubCount;
        this.fSubCount = fSubCount + 1;
        int index1 = fSubCount;
        iGSubControl iGsubControl = value;
        fSubControls[index1] = iGsubControl;
      }
      else
      {
        iGSubControl[] fSubControls = this.fSubControls;
        int fSubCount = this.fSubCount;
        this.fSubCount = fSubCount + 1;
        int index1 = fSubCount;
        iGSubControl fSubControl = this.fSubControls[index];
        fSubControls[index1] = fSubControl;
        this.fSubControls[index] = value;
      }
    }

    internal void CheckSubControlIndex(int index)
    {
      if (index < 0 || index >= this.fSubCount)
        throw new ArgumentOutOfRangeException();
    }

    private bool ShouldSerializeBackColor()
    {
      return this.BackColor != iGControlPaintStyle.cDefaultBackColor;
    }

    private bool ShouldSerializeForeColor()
    {
      return this.ForeColor != iGControlPaintStyle.cDefaultForeColor;
    }

    protected override void OnBackColorChanged(EventArgs e)
    {
      this.fControlPaintStyle.BackColor = this.BackColor;
      base.OnBackColorChanged(e);
    }

    protected override void OnForeColorChanged(EventArgs e)
    {
      this.fControlPaintStyle.ForeColor = this.ForeColor;
      base.OnForeColorChanged(e);
    }

    protected override void OnSizeChanged(EventArgs e)
    {
      this.SetSubControlsBounds();
      base.OnSizeChanged(e);
    }

    protected override void WndProc(ref Message m)
    {
      switch (m.Msg)
      {
        case 31:
          if (this.fSomePressed)
          {
            this.fSomePressed = false;
            this.ProcessMouseMove(Control.MousePosition);
            this.OnCancelMode(EventArgs.Empty);
            break;
          }
          break;
        case 33:
          if (this.fDoNotFocusOnMouseDown)
          {
            m.Result = (IntPtr) 3;
            return;
          }
          break;
      }
      base.WndProc(ref m);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      this.ProcessMouseMove(new Point(e.X, e.Y));
      base.OnMouseMove(e);
    }

    private void ProcessMouseMove(Point mousePos)
    {
      int index1 = -1;
      int index2 = -1;
      int index3 = -1;
      for (int index4 = 0; index4 < this.fSubCount; ++index4)
      {
        iGSubControl fSubControl = this.fSubControls[index4];
        Rectangle bounds = fSubControl.Bounds;
        bool invalidate;
        iGMouseEvents events;
        iGMouseEventsProcessing.MouseMove(fSubControl.Style, ref fSubControl.State, bounds.Contains(mousePos), out invalidate, this.fSomePressed, out events);
        if ((events & iGMouseEvents.Enter) != iGMouseEvents.None)
          index2 = index4;
        else if ((events & iGMouseEvents.Leave) != iGMouseEvents.None)
          index1 = index4;
        if ((events & iGMouseEvents.Move) != iGMouseEvents.None)
          index3 = index4;
        if (invalidate)
          this.Invalidate(bounds);
      }
      if (index1 >= 0)
        this.OnSubControlMouseLeave(index1);
      if (index2 >= 0)
        this.OnSubControlMouseEnter(index2);
      if (index3 < 0)
        return;
      this.OnSubControlMouseMove(index3, mousePos);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      if (this.fSomePressed)
        return;
      Point point = new Point(e.X, e.Y);
      int index1 = -1;
      for (int index2 = 0; index2 < this.fSubCount; ++index2)
      {
        iGSubControl fSubControl = this.fSubControls[index2];
        Rectangle bounds = fSubControl.Bounds;
        bool isMouseOver = bounds.Contains(point);
        if (e.Button == MouseButtons.Left)
        {
          bool invalidate;
          iGMouseEvents events;
          iGMouseEventsProcessing.MouseLeftDown(fSubControl.Style, ref fSubControl.State, isMouseOver, out invalidate, out events);
          if (invalidate)
            this.Invalidate(bounds);
          if ((events & iGMouseEvents.Down) != iGMouseEvents.None)
          {
            index1 = index2;
            this.fSomePressed = true;
          }
        }
        else if (isMouseOver)
          index1 = index2;
      }
      base.OnMouseDown(e);
      if (index1 < 0)
        return;
      if (e.Button == MouseButtons.Left)
        this.OnSubControlLeftDown(index1, point);
      this.OnSubControlMouseDown(index1, point, e.Button);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      Point point = new Point(e.X, e.Y);
      int index1 = -1;
      int index2 = -1;
      for (int index3 = 0; index3 < this.fSubCount; ++index3)
      {
        iGSubControl fSubControl = this.fSubControls[index3];
        Rectangle bounds = fSubControl.Bounds;
        bool isMouseOver = bounds.Contains(point);
        if (e.Button == MouseButtons.Left)
        {
          bool invalidate;
          iGMouseEvents events;
          iGMouseEventsProcessing.MouseLeftUp(fSubControl.Style, ref fSubControl.State, isMouseOver, this.fSomePressed, out invalidate, out events);
          if (invalidate)
            this.Invalidate(bounds);
          if ((events & iGMouseEvents.Click) != iGMouseEvents.None)
            index2 = index3;
          if ((events & iGMouseEvents.Up) != iGMouseEvents.None)
            index1 = index3;
        }
        else if (isMouseOver)
          index1 = index3;
      }
      this.fSomePressed = false;
      base.OnMouseUp(e);
      if (index1 >= 0)
        this.OnSubControlMouseUp(index1, point, e.Button);
      if (index2 < 0)
        return;
      this.OnSubControlLeftClick(index2);
    }

    internal virtual void OnSubControlLeftDown(int index, Point mousePos)
    {
    }

    internal virtual void OnSubControlLeftClick(int index)
    {
    }

    internal virtual void OnSubControlMouseDown(int index, Point mousePos, MouseButtons button)
    {
    }

    internal virtual void OnSubControlMouseUp(int index, Point mousePos, MouseButtons button)
    {
    }

    internal virtual void OnSubControlMouseEnter(int index)
    {
    }

    internal virtual void OnSubControlMouseLeave(int index)
    {
    }

    internal virtual void OnSubControlMouseMove(int index, Point mousePos)
    {
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      int index1 = -1;
      for (int index2 = 0; index2 < this.fSubCount; ++index2)
      {
        iGSubControl fSubControl = this.fSubControls[index2];
        Rectangle bounds = fSubControl.Bounds;
        bool invalidate;
        iGMouseEvents events;
        iGMouseEventsProcessing.MouseLeave(fSubControl.Style, ref fSubControl.State, out invalidate, out events);
        if ((events & iGMouseEvents.Leave) != iGMouseEvents.None)
          index1 = index2;
        if (invalidate)
          this.Invalidate(bounds);
      }
      this.fSomePressed = false;
      base.OnMouseLeave(e);
      if (index1 < 0)
        return;
      this.OnSubControlMouseLeave(index1);
    }

    protected virtual void OnCancelMode(EventArgs e)
    {
    }

    protected override void OnEnabledChanged(EventArgs e)
    {
      for (int index = 0; index < this.fSubCount; ++index)
        this.fSubControls[index].State = iGControlState.Normal;
      this.Invalidate();
      base.OnEnabledChanged(e);
    }

    [Category("Appearance")]
    [DefaultValue(true)]
    public bool UseXpStyles
    {
      get
      {
        return this.fControlPaintStyle.UseXP;
      }
      set
      {
        if (this.fControlPaintStyle.UseXP == value)
          return;
        this.fControlPaintStyle.UseXP = value;
        this.Invalidate();
      }
    }

    [Category("Appearance")]
    [DefaultValue(iGControlPaintAppearance.Style3D)]
    public iGControlPaintAppearance Appearance
    {
      get
      {
        return this.fControlPaintStyle.Appearance;
      }
      set
      {
        if (this.fControlPaintStyle.Appearance == value)
          return;
        this.fControlPaintStyle.Appearance = value;
        this.Invalidate();
      }
    }

    public override System.Drawing.Color BackColor
    {
      get
      {
        return base.BackColor;
      }
      set
      {
        base.BackColor = value;
      }
    }

    public override System.Drawing.Color ForeColor
    {
      get
      {
        return base.ForeColor;
      }
      set
      {
        base.ForeColor = value;
      }
    }

    internal bool DoNotFocusOnMouseDown
    {
      get
      {
        return this.fDoNotFocusOnMouseDown;
      }
      set
      {
        this.fDoNotFocusOnMouseDown = value;
      }
    }

    public IiGControlPaint CustomControlPaint
    {
      get
      {
        return this.fCustomControlPaint;
      }
      set
      {
        this.fCustomControlPaint = value;
        this.Invalidate();
      }
    }
  }
}
