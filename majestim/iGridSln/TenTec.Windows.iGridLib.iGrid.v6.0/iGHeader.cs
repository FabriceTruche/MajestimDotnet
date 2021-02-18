// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGHeader
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents the header in an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGHeader
  {
    internal static readonly iGPenStyle cDefaultGridLinesStyle = new iGPenStyle(SystemColors.ControlDark, 0, DashStyle.Solid);
    internal static readonly Color cDefaultHotTrackForeColor = Color.Blue;
    internal static readonly iGPenStyle cDefaultSeparatingLine = new iGPenStyle(SystemColors.ControlDark, 0, DashStyle.Solid);
    internal const bool cDefaultVisible = true;
    internal const bool cDefaultDrawSystem = true;
    internal const iGHdrHotTrackFlags cDefaultHotTrackFlags = iGHdrHotTrackFlags.Text;
    internal const int cDefaultHotTrackIconDegree = -5;
    internal const iGHdrHotTrackFlags cDefaultHotTrackFlagsXPStyles = iGHdrHotTrackFlags.Background;
    internal const bool cDefaultHotTracking = true;
    internal const bool cDefaultAllowPress = true;
    internal const iGAutoHeightEvents cDefaultAutoHeightEvents = iGAutoHeightEvents.OnAddCol | iGAutoHeightEvents.OnContentsChange | iGAutoHeightEvents.OnThemeChange | iGAutoHeightEvents.OnRemoveRow;
    private iGrid fGrid;

    /// <summary>Returns the <see cref="T:TenTec.Windows.iGridLib.iGrid" /> object this instance belongs to.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGrid" /> object this instance belongs to.</value>
    [Browsable(false)]
    public iGrid Grid
    {
      get
      {
        return this.fGrid;
      }
    }

    internal iGHeader(iGrid grid)
    {
      this.fGrid = grid;
    }

    /// <summary>Adjusts the height of all the header rows to display the contents of all their cells (column headers) entirely.</summary>
    public void AutoHeight()
    {
      this.fGrid.AutoHeightHeader(true);
    }

    /// <summary>Removes all existing header rows except the first one, clears the contents of column headers and splits all merged column headers.</summary>
    public void Reset()
    {
      this.fGrid.HeaderResetData();
    }

    private bool ShouldSerializeHGridLinesStyle()
    {
      return !this.HGridLinesStyle.Equals(iGHeader.cDefaultGridLinesStyle);
    }

    private bool ShouldSerializeVGridLinesStyle()
    {
      return !this.VGridLinesStyle.Equals(iGHeader.cDefaultGridLinesStyle);
    }

    private bool ShouldSerializeHotTrackForeColor()
    {
      return this.HotTrackForeColor != iGHeader.cDefaultHotTrackForeColor;
    }

    private bool ShouldSerializeSeparatingLine()
    {
      return !this.SeparatingLine.Equals(iGHeader.cDefaultSeparatingLine);
    }

    private bool ShouldSerializeBackColor()
    {
      return (uint) (this.fGrid.fSpecifiedColors & iGSpecifiedColors.HeaderBackColor) > 0U;
    }

    private bool ShouldSerializeForeColor()
    {
      return this.fGrid.fHeaderForeColor != Color.Empty;
    }

    private bool ShouldSerializeSolidSortIconColor()
    {
      return (uint) (this.fGrid.fSpecifiedColors & iGSpecifiedColors.HeaderSolidSortIconColor) > 0U;
    }

    private bool ShouldSerializeFont()
    {
      return this.fGrid.fHeaderFont != null;
    }

    private void ResetForeColor()
    {
      this.ForeColor = Color.Empty;
    }

    private void ResetBackColor()
    {
      this.BackColor = Color.Empty;
    }

    private void ResetSolidSortIconColor()
    {
      this.SolidSortIconColor = Color.Empty;
    }

    private void ResetFont()
    {
      this.Font = (Font) null;
    }

    private void ResetHGridLinesStyle()
    {
      this.HGridLinesStyle = iGHeader.cDefaultGridLinesStyle.Clone();
    }

    private void ResetVGridLinesStyle()
    {
      this.VGridLinesStyle = iGHeader.cDefaultGridLinesStyle.Clone();
    }

    private void ResetHotTrackForeColor()
    {
      this.HotTrackForeColor = iGHeader.cDefaultHotTrackForeColor;
    }

    private void ResetSeparatingLine()
    {
      this.SeparatingLine = iGHeader.cDefaultSeparatingLine.Clone();
    }

    /// <summary>Gets or sets a value indicating whether the header is visible.</summary>
    /// <value>A <see cref="T:System.Boolean" /> value that indicates whether the header is visible. The default value is True.</value>
    [DefaultValue(true)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines whether the header is visible or not.")]
    public bool Visible
    {
      get
      {
        return this.fGrid.HeaderVisible;
      }
      set
      {
        this.fGrid.HeaderVisible = value;
      }
    }

    /// <summary>Get or sets the style of the header's vertical grid lines. Use this property when the <see cref="P:TenTec.Windows.iGridLib.iGHeader.DrawSystem" /> property is False.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGPenStyle" /> object.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The style of the header's vertical grid lines. Use this property when the DrawSystem is False.")]
    public iGPenStyle VGridLinesStyle
    {
      get
      {
        return this.fGrid.HeaderVGridLinesStyle;
      }
      set
      {
        this.fGrid.HeaderVGridLinesStyle = value;
      }
    }

    /// <summary>Gets or sets the style of the header's horizontal grid lines. Use this property when the <see cref="P:TenTec.Windows.iGridLib.iGHeader.DrawSystem" /> is False.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGPenStyle" /> object.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The style of the header's horizontal grid lines. Use this property when the DrawSystem is False.")]
    public iGPenStyle HGridLinesStyle
    {
      get
      {
        return this.fGrid.HeaderHGridLinesStyle;
      }
      set
      {
        this.fGrid.HeaderHGridLinesStyle = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether to display the header using the system styles. Use in conjunction with the <see cref="P:TenTec.Windows.iGridLib.iGHeader.UseXPStyles" /> and <see cref="P:TenTec.Windows.iGridLib.iGHeader.Appearance" /> properties.</summary>
    /// <value>True if the header is drawn using the system styles; otherwise, False.</value>
    [DefaultValue(true)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines whether to display the header using the system styles. Use in conjunction with the the UseXPStyles and Appearance properties.")]
    public bool DrawSystem
    {
      get
      {
        return this.fGrid.HeaderDrawSystem;
      }
      set
      {
        this.fGrid.HeaderDrawSystem = value;
      }
    }

    /// <summary>Gets or sets the background color of the header. If not set, the <see cref="P:TenTec.Windows.iGridLib.iGrid.CellCtrlBackColor" /> property is used.</summary>
    /// <value>A color. The default value is <see cref="F:System.Drawing.Color.Empty" />.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The background color of the header. If not set, the CellCtrlBackColor is used.")]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGColorEmptyAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    public Color BackColor
    {
      get
      {
        if ((this.fGrid.fSpecifiedColors & iGSpecifiedColors.HeaderBackColor) != iGSpecifiedColors.HeaderBackColor)
          return Color.Empty;
        return this.fGrid.GetHeaderBackColor();
      }
      set
      {
        if (this.fGrid.fHeaderControlPaintStyle.BackColor == value)
          return;
        if (value == Color.Empty)
        {
          this.fGrid.fHeaderControlPaintStyle.BackColor = this.fGrid.fCellControlPaintStyle.BackColor;
          this.fGrid.fSpecifiedColors &= ~iGSpecifiedColors.HeaderBackColor;
        }
        else
        {
          this.fGrid.fHeaderControlPaintStyle.BackColor = value;
          this.fGrid.fSpecifiedColors |= iGSpecifiedColors.HeaderBackColor;
        }
        this.fGrid.InvalidateHeaderIfRedraw();
      }
    }

    /// <summary>Gets or sets the color of the solid sort arrow (the Flat and OS visual styles). If not set, the <see cref="P:TenTec.Windows.iGridLib.iGrid.CellCtrlForeColor" /> property is used.</summary>
    /// <value>A color. The default is <see cref="F:System.Drawing.Color.Empty" />.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The color of the solid sort arrow (the Flat and XP styles). If not set, the CellCtrlForeColor property is used.")]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGColorEmptyAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    public Color SolidSortIconColor
    {
      get
      {
        if ((this.fGrid.fSpecifiedColors & iGSpecifiedColors.HeaderSolidSortIconColor) != iGSpecifiedColors.HeaderSolidSortIconColor)
          return Color.Empty;
        return this.fGrid.fHeaderControlPaintStyle.ForeColor;
      }
      set
      {
        if (this.fGrid.fHeaderControlPaintStyle.ForeColor == value)
          return;
        if (value == Color.Empty)
        {
          this.fGrid.fHeaderControlPaintStyle.ForeColor = this.fGrid.fCellControlPaintStyle.ForeColor;
          this.fGrid.fSpecifiedColors &= ~iGSpecifiedColors.HeaderSolidSortIconColor;
        }
        else
        {
          this.fGrid.fHeaderControlPaintStyle.ForeColor = value;
          this.fGrid.fSpecifiedColors |= iGSpecifiedColors.HeaderSolidSortIconColor;
        }
        this.fGrid.InvalidateHeaderIfRedraw();
      }
    }

    /// <summary>Gets or sets a value indicating whether to use the OS visual styles if they are available to display the header. Acts only if the <see cref="P:TenTec.Windows.iGridLib.iGHeader.DrawSystem" /> property is True.</summary>
    /// <value>True if the OS visual styles are used; otherwise, False.</value>
    [DefaultValue(true)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines whether to use the WindowsXP visual styles if they are available to display the header. Acts only if the DrawSystem is True.")]
    public bool UseXPStyles
    {
      get
      {
        return this.fGrid.fHeaderControlPaintStyle.UseXP;
      }
      set
      {
        if (this.fGrid.fHeaderControlPaintStyle.UseXP == value)
          return;
        this.fGrid.fHeaderControlPaintStyle.UseXP = value;
        this.fGrid.OnThemeChanged();
        this.fGrid.InvalidateHeaderIfRedraw();
      }
    }

    /// <summary>Gets or sets the style of the header (3D or Flat). Acts only if the <see cref="P:TenTec.Windows.iGridLib.iGHeader.DrawSystem" /> is True.</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGControlPaintAppearance" /> enumeration values. The default is <see cref="F:TenTec.Windows.iGridLib.iGControlPaintAppearance.Style3D" />.</value>
    [DefaultValue(iGControlPaintAppearance.Style3D)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The style of the header (3D or Flat). Acts only if the DrawSystem is True.")]
    public iGControlPaintAppearance Appearance
    {
      get
      {
        return this.fGrid.fHeaderControlPaintStyle.Appearance;
      }
      set
      {
        if (this.fGrid.fHeaderControlPaintStyle.Appearance == value)
          return;
        this.fGrid.fHeaderControlPaintStyle.Appearance = value;
        this.fGrid.OnThemeChanged();
        this.fGrid.InvalidateHeaderIfRedraw();
      }
    }

    /// <summary>Gets the collection of the column headers (header cells).</summary>
    /// <value>The <see cref="T:TenTec.Windows.iGridLib.iGColHdrCollection" /> object that provides access to the header cells.</value>
    [Browsable(false)]
    public iGColHdrCollection Cells
    {
      get
      {
        return this.fGrid.fColHdrCollection;
      }
    }

    /// <summary>Gets the collection of the header rows.</summary>
    /// <value>The <see cref="T:TenTec.Windows.iGridLib.iGHdrRowCollection" /> object that allows you to access the header's rows.</value>
    [Browsable(false)]
    public iGHdrRowCollection Rows
    {
      get
      {
        return this.fGrid.fHeaderRowCollection;
      }
    }

    /// <summary>Gets or sets the height of the header (the total height of all the header rows).</summary>
    /// <value>The height of the header. The default is 18.</value>
    [DefaultValue(19)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The height of visible header rows (if auto-height events are not used).")]
    public int Height
    {
      get
      {
        return this.fGrid.HeaderVisibleRowsTotalHeight;
      }
      set
      {
        this.fGrid.HeaderVisibleRowsTotalHeight = value;
      }
    }

    /// <summary>Retrieves the bounds of the header area. The coordinates are relative to the upper left corner of the grid.</summary>
    /// <value>A <see cref="T:System.Drawing.Rectangle" /> that represents the size and location of the header area. The coordinates are relative to the upper left corner of the grid.</value>
    [Browsable(false)]
    public Rectangle Bounds
    {
      get
      {
        return this.fGrid.GetHeaderAreaBounds();
      }
    }

    /// <summary>Gets or sets images to display in the header.</summary>
    /// <value>An <see cref="T:System.Windows.Forms.ImageList" /> object. The default is null (Nothing in VB).</value>
    [DefaultValue(null)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Images to display in the header.")]
    public ImageList ImageList
    {
      get
      {
        return this.fGrid.fHeaderImageList;
      }
      set
      {
        this.fGrid.SetHeaderImageList(value);
      }
    }

    /// <summary>Gets or sets a value indicating which parts of a header cell should indicate the hot state when the OS visual styles are not used.</summary>
    /// <value>A set of the <see cref="T:TenTec.Windows.iGridLib.iGHdrHotTrackFlags" /> enumeration values. The default is <see cref="F:TenTec.Windows.iGridLib.iGHdrHotTrackFlags.Text" />.</value>
    [DefaultValue(iGHdrHotTrackFlags.Text)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("A value indicating what part of a header cell should indicate hot state when the WindowsXP visual styles are not active.")]
    public iGHdrHotTrackFlags HotTrackFlags
    {
      get
      {
        return this.fGrid.fHotTrackFlags;
      }
      set
      {
        this.fGrid.fHotTrackFlags = value;
      }
    }

    /// <summary>Gets or sets a value determining whether the header cells should indicate hot state.</summary>
    /// <value>True if the hot tracking is active; otherwise, False.</value>
    [DefaultValue(true)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines whether the header cells should indicate hot state.")]
    public bool HotTracking
    {
      get
      {
        return this.fGrid.fHeaderHotTracking;
      }
      set
      {
        this.fGrid.fHeaderHotTracking = value;
      }
    }

    /// <summary>Gets or sets a value indicating which parts of a header cell should indicate hot state when the OS visual styles are not used.</summary>
    /// <value>A set of the <see cref="T:TenTec.Windows.iGridLib.iGHdrHotTrackFlags" /> enumeration values. The default is <see cref="F:TenTec.Windows.iGridLib.iGHdrHotTrackFlags.Background" />.</value>
    [DefaultValue(iGHdrHotTrackFlags.Background)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("A value indicating what part of a header cell should indicate hot state when the WindowsXP visual styles are active.")]
    public iGHdrHotTrackFlags HotTrackFlagsXPStyles
    {
      get
      {
        return this.fGrid.fHotTrackFlagsXPStyles;
      }
      set
      {
        this.fGrid.fHotTrackFlagsXPStyles = value;
      }
    }

    /// <summary>Gets or sets the color of the text in the hot header cell. Acts only if the <see cref="F:TenTec.Windows.iGridLib.iGHdrHotTrackFlags.Text" /> flag is included in the <see cref="P:TenTec.Windows.iGridLib.iGHeader.HotTrackFlags" /> or <see cref="P:TenTec.Windows.iGridLib.iGHeader.HotTrackFlagsXPStyles" /> property.</summary>
    /// <value>A color. The default value is <see cref="P:System.Drawing.Color.Blue" />.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The color of the text in the hot header cell. Acts only if the Text flag is included in the HotTrackFalgs or HotTrackFalgsXPStyles.")]
    public Color HotTrackForeColor
    {
      get
      {
        return this.fGrid.fHotTrackForeColor;
      }
      set
      {
        this.fGrid.fHotTrackForeColor = value;
      }
    }

    /// <summary>Gets or sets the intense of icon highlighting in the hot header cell. Acts only if the <see cref="F:TenTec.Windows.iGridLib.iGHdrHotTrackFlags.Icon" /> flag is included in the <see cref="P:TenTec.Windows.iGridLib.iGHeader.HotTrackFlags" /> or <see cref="P:TenTec.Windows.iGridLib.iGHeader.HotTrackFlagsXPStyles" /> property.</summary>
    /// <value>An integer value. The default is -5.</value>
    [DefaultValue(-5)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The intense of icon highlighting in the hot header cell. Acts only if the Icon flag is included in the HotTrackFalgs or HotTrackFalgsXPStyles.")]
    public int HotTrackIconDegree
    {
      get
      {
        return this.fGrid.fHotTrackIconDegree;
      }
      set
      {
        if (value < -100 || value > 100)
          throw new ArgumentOutOfRangeException();
        this.fGrid.fHotTrackIconDegree = value;
        this.fGrid.fHighlightIconAttributes = (ImageAttributes) null;
      }
    }

    /// <summary>Gets or sets the style of the grid line which separates the header area from the cells area.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGPenStyle" /> object.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The style of the grid line that separates the header from the cells.")]
    public iGPenStyle SeparatingLine
    {
      get
      {
        return this.fGrid.fHeaderSeparatingLine;
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException();
        this.fGrid.fHeaderSeparatingLine = value;
        if (!this.fGrid.fRedraw)
          return;
        this.fGrid.Invalidate();
      }
    }

    /// <summary>Gets or sets the font used to display the text in the header. If not set, the <see cref="P:System.Windows.Forms.Control.Font" /> property of the grid is used.</summary>
    /// <value>A <see cref="T:System.Drawing.Font" /> object. The default is null (Nothing in VB).</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The font used to display the text in the header. If not set, the Font property of the grid is used.")]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGFontNoneAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    public Font Font
    {
      get
      {
        return this.fGrid.fHeaderFont;
      }
      set
      {
        this.fGrid.fHeaderFont = value;
        this.fGrid.AutoHeightHeaderOnEvent(iGAutoHeightEvents.OnContentsChange, true);
        this.fGrid.InvalidateHeaderIfRedraw();
      }
    }

    /// <summary>Gets or sets the color of the text displayed in the header. If not set, the <see cref="P:TenTec.Windows.iGridLib.iGrid.ForeColor" /> property is used.</summary>
    /// <value>A color. The default is <see cref="F:System.Drawing.Color.Empty" />.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The color of the text displayed in the header. If not set, the CellCtrlForeColor property is used.")]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGColorEmptyAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    public Color ForeColor
    {
      get
      {
        return this.fGrid.fHeaderForeColor;
      }
      set
      {
        this.fGrid.fHeaderForeColor = value;
        this.fGrid.InvalidateHeaderIfRedraw();
      }
    }

    /// <summary>Gets or sets a value that allows you to prohibit sorting through visual interface for all the columns at once.</summary>
    /// <value>True if the column headers are clickable; otherwise, False. The default is True.</value>
    [DefaultValue(true)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Allows you to prohibit sorting thru visual interface for all the columns at once. If this property is False the header cells will not indicate pressed state.")]
    public bool AllowPress
    {
      get
      {
        return this.fGrid.fHeaderAllowPress;
      }
      set
      {
        this.fGrid.fHeaderAllowPress = value;
      }
    }

    /// <summary>Defines a set of events when the height of the header should be adjusted automatically.</summary>
    /// <value>A set of the <see cref="T:TenTec.Windows.iGridLib.iGAutoHeightEvents" /> enumeration values. The default is <see cref="F:TenTec.Windows.iGridLib.iGAutoHeightEvents.OnAddCol" />, <see cref="F:TenTec.Windows.iGridLib.iGAutoHeightEvents.OnRemoveRow" />, <see cref="F:TenTec.Windows.iGridLib.iGAutoHeightEvents.OnContentsChange" /> and <see cref="F:TenTec.Windows.iGridLib.iGAutoHeightEvents.OnThemeChange" />.</value>
    [DefaultValue(iGAutoHeightEvents.OnAddCol | iGAutoHeightEvents.OnContentsChange | iGAutoHeightEvents.OnThemeChange | iGAutoHeightEvents.OnRemoveRow)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines when header row heights are adjusted automatically.")]
    public iGAutoHeightEvents AutoHeightEvents
    {
      get
      {
        return this.fGrid.fHeaderAutoHeightEvents;
      }
      set
      {
        this.fGrid.fHeaderAutoHeightEvents = value;
      }
    }
  }
}
