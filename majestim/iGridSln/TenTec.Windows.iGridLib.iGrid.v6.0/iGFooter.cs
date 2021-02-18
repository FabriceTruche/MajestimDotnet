// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGFooter
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents the footer in an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGFooter
  {
    internal static readonly iGPenStyle cDefaultSeparatingLine = new iGPenStyle(SystemColors.ControlDark, 1, DashStyle.Solid);
    internal static readonly Color cDefaultBackColor = SystemColors.Info;
    internal static readonly Color cDefaultForeColor = SystemColors.InfoText;
    internal const bool cDefaultVisible = false;
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

    internal iGFooter(iGrid grid)
    {
      this.fGrid = grid;
    }

    /// <summary>Gets the collection of the footer rows.</summary>
    /// <value>The <see cref="T:TenTec.Windows.iGridLib.iGFooterRowCollection" /> object that allows you to access the footer's rows.</value>
    [Browsable(false)]
    public iGFooterRowCollection Rows
    {
      get
      {
        return this.fGrid.fFooterRowCollection;
      }
    }

    /// <summary>Gets the collection of the footer cells.</summary>
    /// <value>The <see cref="T:TenTec.Windows.iGridLib.iGFooterCellCollection" /> object that provides access to the footer cells.</value>
    [Browsable(false)]
    public iGFooterCellCollection Cells
    {
      get
      {
        return this.fGrid.fFooterCellCollection;
      }
    }

    /// <summary>Gets or sets a value indicating whether the footer is visible.</summary>
    /// <value>A <see cref="T:System.Boolean" /> value that indicates whether the footer is visible. The default value is False.</value>
    [DefaultValue(false)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines whether the footer is visible or not.")]
    public bool Visible
    {
      get
      {
        return this.fGrid.FooterVisible;
      }
      set
      {
        this.fGrid.FooterVisible = value;
      }
    }

    /// <summary>Gets or sets the height of the footer (the total height of all the footer rows).</summary>
    /// <value>The height of the footer. The default is 17.</value>
    [DefaultValue(17)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The height of visible footer rows (if auto-height events are not used).")]
    public int Height
    {
      get
      {
        return this.fGrid.FooterVisibleRowsTotalHeight;
      }
      set
      {
        this.fGrid.FooterVisibleRowsTotalHeight = value;
      }
    }

    /// <summary>Retrieves the bounds of the footer area. The coordinates are relative to the upper left corner of the grid.</summary>
    /// <value>A <see cref="T:System.Drawing.Rectangle" /> that represents the size and location of the footer area. The coordinates are relative to the upper left corner of the grid.</value>
    [Browsable(false)]
    public Rectangle Bounds
    {
      get
      {
        return this.fGrid.GetFooterAreaBounds();
      }
    }

    /// <summary>Gets or sets the background color of the footer. If not set, the <see cref="P:TenTec.Windows.iGridLib.iGrid.BackColor" /> property of <see cref="T:TenTec.Windows.iGridLib.iGrid" /> is used.</summary>
    /// <value>A <see cref="T:System.Drawing.Color" /> value. The default value is <see cref="P:System.Drawing.SystemColors.Info" />.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The background color of the footer.")]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGColorEmptyAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    public Color BackColor
    {
      get
      {
        return this.fGrid.fFooterBackColor;
      }
      set
      {
        if (this.fGrid.fFooterBackColor == value)
          return;
        this.fGrid.fFooterBackColor = value;
        this.fGrid.InvalidateFooterIfRedraw();
      }
    }

    private bool ShouldSerializeBackColor()
    {
      return this.BackColor != iGFooter.cDefaultBackColor;
    }

    private void ResetBackColor()
    {
      this.BackColor = iGFooter.cDefaultBackColor;
    }

    /// <summary>Gets or sets the color of the text displayed in the footer. If not set, the <see cref="P:TenTec.Windows.iGridLib.iGrid.ForeColor" /> property of <see cref="T:TenTec.Windows.iGridLib.iGrid" /> is used.</summary>
    /// <value>A <see cref="T:System.Drawing.Color" /> value. The default value is <see cref="P:System.Drawing.SystemColors.InfoText" />.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The color of the text displayed in the footer.")]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGColorEmptyAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    public Color ForeColor
    {
      get
      {
        return this.fGrid.fFooterForeColor;
      }
      set
      {
        this.fGrid.fFooterForeColor = value;
        this.fGrid.InvalidateFooterIfRedraw();
      }
    }

    private bool ShouldSerializeForeColor()
    {
      return this.ForeColor != iGFooter.cDefaultForeColor;
    }

    private void ResetForeColor()
    {
      this.ForeColor = iGFooter.cDefaultForeColor;
    }

    /// <summary>Gets or sets the font used to display the text in the footer. If not set, the <see cref="P:System.Windows.Forms.Control.Font" /> property of the grid is used.</summary>
    /// <value>A <see cref="T:System.Drawing.Font" /> object. The default is null (Nothing in VB).</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The font used to display the text in the header. If not set, the Font property of the grid is used.")]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGFontNoneAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    public Font Font
    {
      get
      {
        return this.fGrid.fFooterFont;
      }
      set
      {
        this.fGrid.fFooterFont = value;
        this.fGrid.AutoHeightFooterOnEvent(iGAutoHeightEvents.OnContentsChange, true);
        this.fGrid.InvalidateFooterIfRedraw();
      }
    }

    private bool ShouldSerializeFont()
    {
      return this.fGrid.fFooterFont != null;
    }

    private void ResetFont()
    {
      this.Font = (Font) null;
    }

    /// <summary>Gets or sets the style of the special grid line at the top of the footer area that separates it from the cells area.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGPenStyle" /> object.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The style of the grid line that separates the footer from the cells.")]
    public iGPenStyle SeparatingLine
    {
      get
      {
        return this.fGrid.fFooterSeparatingLine;
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException();
        this.fGrid.fFooterSeparatingLine = value;
        if (!this.fGrid.fRedraw)
          return;
        this.fGrid.Invalidate();
      }
    }

    private bool ShouldSerializeSeparatingLine()
    {
      return !this.SeparatingLine.Equals(iGFooter.cDefaultSeparatingLine);
    }

    private void ResetSeparatingLine()
    {
      this.SeparatingLine = iGFooter.cDefaultSeparatingLine.Clone();
    }

    /// <summary>Gets or sets images to display in the footer.</summary>
    /// <value>An <see cref="T:System.Windows.Forms.ImageList" /> object. The default is null (Nothing in VB).</value>
    [DefaultValue(null)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Images to display in the footer.")]
    public ImageList ImageList
    {
      get
      {
        return this.fGrid.fFooterImageList;
      }
      set
      {
        this.fGrid.SetFooterImageList(value);
      }
    }

    /// <summary>Defines a set of events when the height of the footer should be adjusted automatically.</summary>
    /// <value>A set of the <see cref="T:TenTec.Windows.iGridLib.iGAutoHeightEvents" /> enumeration values. The default is <see cref="F:TenTec.Windows.iGridLib.iGAutoHeightEvents.OnAddCol" />, <see cref="F:TenTec.Windows.iGridLib.iGAutoHeightEvents.OnRemoveRow" />, <see cref="F:TenTec.Windows.iGridLib.iGAutoHeightEvents.OnContentsChange" /> and <see cref="F:TenTec.Windows.iGridLib.iGAutoHeightEvents.OnThemeChange" />.</value>
    [DefaultValue(iGAutoHeightEvents.OnAddCol | iGAutoHeightEvents.OnContentsChange | iGAutoHeightEvents.OnThemeChange | iGAutoHeightEvents.OnRemoveRow)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines when footer row heights are adjusted automatically.")]
    public iGAutoHeightEvents AutoHeightEvents
    {
      get
      {
        return this.fGrid.fFooterAutoHeightEvents;
      }
      set
      {
        this.fGrid.fFooterAutoHeightEvents = value;
      }
    }

    /// <summary>Adjusts the height of all footer rows to display the contents of their cells entirely.</summary>
    public void AutoHeight()
    {
      this.fGrid.AutoHeightFooter(true);
    }

    /// <summary>Removes all existing footer rows except the first one, clears the contents of footer cells and splits all merged footer cells.</summary>
    public void Reset()
    {
      this.fGrid.FooterResetData();
    }
  }
}
