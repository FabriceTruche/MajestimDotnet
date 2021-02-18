// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGControlPaintStyle
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  internal class iGControlPaintStyle : IDisposable
  {
    internal static readonly Color cDefaultBackColor = SystemColors.Control;
    internal static readonly Color cDefaultForeColor = SystemColors.ControlText;
    private bool fUseXP = true;
    internal const bool cDefaultUseXP = true;
    internal const iGControlPaintAppearance cDefaultAppearance = iGControlPaintAppearance.Style3D;
    private IiGControlPaintInternal fControlPaint;
    private iGControlPaintXP fStyleXP;
    private bool fDisposed;

    internal void OnSettingChange()
    {
      if (this.fControlPaint != null)
        this.fControlPaint.OnSettingChange();
      if (this.fStyleXP == null)
        return;
      this.fStyleXP.OnSettingChange();
    }

    private IiGControlPaintInternal GetControlPaintFromStyle(iGControlPaintAppearance value)
    {
      if (value == iGControlPaintAppearance.StyleFlat)
        return (IiGControlPaintInternal) new iGControlPaintFlat();
      return (IiGControlPaintInternal) new iGControlPaint3D();
    }

    public bool IsXP
    {
      get
      {
        if (this.fUseXP)
          return Application.RenderWithVisualStyles;
        return false;
      }
    }

    public IiGControlPaintInternal ControlPaint
    {
      get
      {
        if (!this.IsXP)
          return this.InternalControlPaint;
        if (this.fStyleXP == null)
        {
          this.fStyleXP = new iGControlPaintXP();
          this.fStyleXP.ControlsForeColor = this.ForeColor;
          this.fStyleXP.ControlsBackColor = this.BackColor;
        }
        return (IiGControlPaintInternal) this.fStyleXP;
      }
    }

    private IiGControlPaintInternal InternalControlPaint
    {
      get
      {
        if (this.fControlPaint == null)
          this.fControlPaint = this.GetControlPaintFromStyle(iGControlPaintAppearance.Style3D);
        return this.fControlPaint;
      }
    }

    public iGControlPaintAppearance Appearance
    {
      set
      {
        IiGControlPaint fControlPaint = (IiGControlPaint) this.fControlPaint;
        this.fControlPaint = this.GetControlPaintFromStyle(value);
        if (fControlPaint == null)
          return;
        this.fControlPaint.ControlsForeColor = fControlPaint.ControlsForeColor;
        this.fControlPaint.ControlsBackColor = fControlPaint.ControlsBackColor;
      }
      get
      {
        return this.InternalControlPaint.GetStyle() == iGInternalControlPaintStyle.Flat ? iGControlPaintAppearance.StyleFlat : iGControlPaintAppearance.Style3D;
      }
    }

    public Color ForeColor
    {
      get
      {
        return this.InternalControlPaint.ControlsForeColor;
      }
      set
      {
        this.InternalControlPaint.ControlsForeColor = value;
        if (this.fStyleXP == null)
          return;
        this.fStyleXP.ControlsForeColor = value;
      }
    }

    public Color BackColor
    {
      get
      {
        return this.InternalControlPaint.ControlsBackColor;
      }
      set
      {
        this.InternalControlPaint.ControlsBackColor = value;
        if (this.fStyleXP == null)
          return;
        this.fStyleXP.ControlsBackColor = value;
      }
    }

    public bool UseXP
    {
      get
      {
        return this.fUseXP;
      }
      set
      {
        this.fUseXP = value;
      }
    }

    protected virtual void Dispose(bool disposing)
    {
      if (this.fDisposed)
        return;
      if (disposing && this.fStyleXP != null)
      {
        this.fStyleXP.Dispose();
        this.fStyleXP = (iGControlPaintXP) null;
      }
      this.fDisposed = true;
    }

    public void Dispose()
    {
      this.Dispose(true);
    }
  }
}
