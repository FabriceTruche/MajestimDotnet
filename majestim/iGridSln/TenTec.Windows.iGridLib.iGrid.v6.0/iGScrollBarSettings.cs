// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGScrollBarSettings
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents the common settings of the vertical and horizontal scroll bars in an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  [TypeConverter("TenTec.Windows.iGridLib.Design.iGExpandableTypeConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
  public class iGScrollBarSettings
  {
    internal const double cDefaultOpacity = 1.0;
    private iGrid fGrid;

    /// <summary>Returns the <see cref="T:TenTec.Windows.iGridLib.iGrid" /> object this instance belongs to.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGrid" /> object.</value>
    [Browsable(false)]
    public iGrid Grid
    {
      get
      {
        return this.fGrid;
      }
    }

    internal iGScrollBarSettings(iGrid grid)
    {
      this.fGrid = grid;
    }

    private bool ShouldSerializeBackColor()
    {
      return this.BackColor != iGControlPaintStyle.cDefaultBackColor;
    }

    private bool ShouldSerializeForeColor()
    {
      return this.ForeColor != iGControlPaintStyle.cDefaultForeColor;
    }

    private void ResetBackColor()
    {
      this.BackColor = iGControlPaintStyle.cDefaultBackColor;
    }

    private void ResetForeColor()
    {
      this.ForeColor = iGControlPaintStyle.cDefaultForeColor;
    }

    private void InvalidateSizeBox()
    {
      if (!this.fGrid.fRedraw || !this.fGrid.fVScrollBar.Visible || (!this.fGrid.fHScrollBar.Visible || this.fGrid.fVScrollBar.Parent == null))
        return;
      this.fGrid.Invalidate(new Rectangle(this.fGrid.fVScrollBar.Left, this.fGrid.fHScrollBar.Top, this.fGrid.fVScrollBar.Width, this.fGrid.fHScrollBar.Height));
    }

    /// <summary>Gets or sets a value indicating how opaque or transparent the scroll bars are. 0 are transparent, 1.0 are opaque.</summary>
    /// <value>A value between 0 and 1. The default is 1.</value>
    [DefaultValue(1.0)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines how opaque or transparent the scroll bars are. 0% are transparent, 100% are opaque.")]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGOpacityConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Editor("TenTec.Windows.iGridLib.Design.iGOpacityEditor, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0", typeof (UITypeEditor))]
    public double Opacity
    {
      get
      {
        return this.fGrid.fScrollBarOpacity;
      }
      set
      {
        if (this.fGrid.fScrollBarOpacity == value)
          return;
        if (value < 0.0 || value > 1.0)
          throw new ArgumentOutOfRangeException();
        this.fGrid.fScrollBarOpacity = value;
        this.fGrid.AdjustScrollsStyle();
        if (!this.fGrid.fRedraw)
          return;
        this.fGrid.Invalidate();
      }
    }

    /// <summary>Gets or sets the background color of the scroll bars.</summary>
    /// <value>A color. The default is <see cref="P:System.Drawing.SystemColors.Control" />.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The background color of the scroll bars. If not set, the CellCtrlBackColor property of the grid is used.")]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGColorEmptyAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    public Color BackColor
    {
      get
      {
        if ((this.fGrid.fSpecifiedColors & iGSpecifiedColors.ScrollBackColor) != iGSpecifiedColors.ScrollBackColor)
          return Color.Empty;
        return this.fGrid.fVScrollBar.BackColor;
      }
      set
      {
        if (this.BackColor == value)
          return;
        if (value == Color.Empty)
        {
          this.fGrid.fVScrollBar.BackColor = this.fGrid.fCellControlPaintStyle.BackColor;
          this.fGrid.fHScrollBar.BackColor = this.fGrid.fCellControlPaintStyle.BackColor;
          this.fGrid.fSpecifiedColors &= ~iGSpecifiedColors.ScrollBackColor;
        }
        else
        {
          this.fGrid.fVScrollBar.BackColor = value;
          this.fGrid.fHScrollBar.BackColor = value;
          this.fGrid.fSpecifiedColors |= iGSpecifiedColors.ScrollBackColor;
        }
        this.InvalidateSizeBox();
      }
    }

    /// <summary>Gets or sets the color of the scroll bars' arrows.</summary>
    /// <value>A color. The default is <see cref="P:System.Drawing.SystemColors.ControlText" />.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The color of the scroll bars' arrows. If not set, the CellCtrlForeColor property of the grid is used.")]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGColorEmptyAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    public Color ForeColor
    {
      get
      {
        if ((this.fGrid.fSpecifiedColors & iGSpecifiedColors.ScrollForeColor) != iGSpecifiedColors.ScrollForeColor)
          return Color.Empty;
        return this.fGrid.fVScrollBar.ForeColor;
      }
      set
      {
        if (value == this.ForeColor)
          return;
        if (value == Color.Empty)
        {
          this.fGrid.fVScrollBar.ForeColor = this.fGrid.fCellControlPaintStyle.ForeColor;
          this.fGrid.fHScrollBar.ForeColor = this.fGrid.fCellControlPaintStyle.ForeColor;
          this.fGrid.fSpecifiedColors &= ~iGSpecifiedColors.ScrollForeColor;
        }
        else
        {
          this.fGrid.fVScrollBar.ForeColor = value;
          this.fGrid.fHScrollBar.ForeColor = value;
          this.fGrid.fSpecifiedColors |= iGSpecifiedColors.ScrollForeColor;
        }
        this.InvalidateSizeBox();
      }
    }

    /// <summary>Gets or sets a value indicating whether to use the OS visual styles if they are available to display the scroll bars.</summary>
    /// <value>True if the scroll bars use the OS visual styles; otherwise, False. The default is True.</value>
    [DefaultValue(true)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines whether to use the WindowsXP visual styles if they are available to display the scroll bars.")]
    public bool UseXPStyles
    {
      get
      {
        return this.fGrid.fVScrollBar.UseXpStyles;
      }
      set
      {
        if (value == this.UseXPStyles)
          return;
        this.fGrid.fVScrollBar.UseXpStyles = value;
        this.fGrid.fHScrollBar.UseXpStyles = value;
        this.InvalidateSizeBox();
      }
    }

    /// <summary>Gets or sets the style of the scroll bars (3D or Flat).</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGControlPaintAppearance" /> enumeration values. The default is <see cref="F:TenTec.Windows.iGridLib.iGControlPaintAppearance.Style3D" />.</value>
    [DefaultValue(iGControlPaintAppearance.Style3D)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The style of the scroll bars (3D or Flat).")]
    public iGControlPaintAppearance Appearance
    {
      get
      {
        return this.fGrid.fVScrollBar.Appearance;
      }
      set
      {
        if (value == this.Appearance)
          return;
        this.fGrid.fVScrollBar.Appearance = value;
        this.fGrid.fHScrollBar.Appearance = value;
        this.InvalidateSizeBox();
      }
    }

    /// <summary>Gets or sets the images displayed in the scroll bars' custom buttons.</summary>
    /// <value>An image list. The default is null (Nothing in VB).</value>
    [DefaultValue(null)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The images displayed in the scroll bars' custom buttons.")]
    public ImageList ImageList
    {
      get
      {
        return this.fGrid.fVScrollBar.ImageList;
      }
      set
      {
        if (value == this.ImageList)
          return;
        this.fGrid.fVScrollBar.ImageList = value;
        this.fGrid.fHScrollBar.ImageList = value;
        this.InvalidateSizeBox();
      }
    }
  }
}
