// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGFooterCell
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents a footer cell in an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public sealed class iGFooterCell
  {
    private int fColIndex;
    private int fRowIndex;
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

    internal iGFooterCell(iGrid grid, int rowIndex, int colIndex)
    {
      grid.CheckFooterCellIndices(rowIndex, colIndex);
      this.fGrid = grid;
      this.fRowIndex = rowIndex;
      this.fColIndex = colIndex;
    }

    private bool ShouldSerializeValue()
    {
      if (this.Value != null)
        return this.Value as string != string.Empty;
      return false;
    }

    /// <summary>Retrieves the string representation of the footer cell.</summary>
    /// <returns>A string that represents the footer cell.</returns>
    public override string ToString()
    {
      return string.Format("{0}(RowIndex = {1}; ColIndex = {2})", (object) this.GetType().Name, (object) this.fRowIndex, (object) (this.fColIndex - 1));
    }

    private iGFooterCellStyle AdjustStyle()
    {
      iGFooterCellStyle gfooterCellStyle = this.fGrid.GetFooterCellData(this.fRowIndex, this.fColIndex).Style;
      if (gfooterCellStyle == null)
      {
        gfooterCellStyle = new iGFooterCellStyle();
        this.fGrid.SetFooterCellStyle(this.fRowIndex, this.fColIndex, gfooterCellStyle);
      }
      else if (this.fGrid.fRedraw)
        this.fGrid.Invalidate();
      return gfooterCellStyle;
    }

    /// <summary>Gets the column index of the footer cell.</summary>
    /// <value>A zero-based index representing the position of the column in the grid's collection of columns.</value>
    public int ColIndex
    {
      get
      {
        return this.fColIndex - 1;
      }
    }

    /// <summary>Gets the row index of the footer cell.</summary>
    /// <value>A zero-based index representing the position of the footer row in the collection of footer rows.</value>
    public int RowIndex
    {
      get
      {
        return this.fRowIndex;
      }
    }

    /// <summary>Gets or sets the footer cell's value.</summary>
    /// <value>A value of any available type (a value type or an instance of a class). The default value is null (Nothing in VB).</value>
    public object Value
    {
      get
      {
        return this.fGrid.GetFooterCellData(this.fRowIndex, this.fColIndex).Value;
      }
      set
      {
        this.fGrid.SetFooterCellValue(this.fRowIndex, this.fColIndex, value);
      }
    }

    /// <summary>Gets or sets an auxiliary value.</summary>
    /// <value>An object.</value>
    public object AuxValue
    {
      get
      {
        return this.fGrid.GetFooterCellData(this.fRowIndex, this.fColIndex).AuxValue;
      }
      set
      {
        this.fGrid.SetFooterCellAuxValue(this.fRowIndex, this.fColIndex, value);
      }
    }

    /// <summary>Gets or sets the index of the image displayed in the cell.</summary>
    /// <value>A zero-based index that represents the image position in an <see cref="T:System.Windows.Forms.ImageList" />. The default is -1, which means that the cell has no image.</value>
    public int ImageIndex
    {
      get
      {
        return this.fGrid.GetFooterCellData(this.fRowIndex, this.fColIndex).ImageIndex;
      }
      set
      {
        this.fGrid.SetFooterCellImageIndex(this.fRowIndex, this.fColIndex, value);
      }
    }

    /// <summary>Gets or sets an <see cref="T:TenTec.Windows.iGridLib.iGFooterCellStyle" /> object determining the appearance and behavior of the footer cell.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGFooterCellStyle" /> object that determines the appearance and behavior of the footer cell, or null (Nothing in VB) if the appearance and behavior of the cell is completely determined by the cell style object of the column. The default value is null (Nothing in VB).</value>
    public iGFooterCellStyle Style
    {
      get
      {
        return this.fGrid.GetFooterCellData(this.fRowIndex, this.fColIndex).Style;
      }
      set
      {
        this.fGrid.SetFooterCellStyle(this.fRowIndex, this.fColIndex, value);
      }
    }

    /// <summary>Gets or sets the aggregate function calculated in the footer cell.</summary>
    /// <value>A value from the <see cref="T:TenTec.Windows.iGridLib.iGAggregateFunction" /> enumeration that specifies the aggregate function.</value>
    public iGAggregateFunction AggregateFunction
    {
      get
      {
        return this.fGrid.GetFooterCellData(this.fRowIndex, this.fColIndex).AggregateFunction;
      }
      set
      {
        this.fGrid.SetFooterCellAggregateFunction(this.fRowIndex, this.fColIndex, value);
      }
    }

    /// <summary>Gets the text displayed in the footer cell.</summary>
    /// <value>The text displayed in the footer cell.</value>
    public string Text
    {
      get
      {
        return this.fGrid.GetFooterCellText(this.fRowIndex, this.fColIndex);
      }
    }

    /// <summary>Gets or sets the background color of the footer cell.</summary>
    /// <value>The color of the footer cell's background.</value>
    public Color BackColor
    {
      get
      {
        iGFooterCellStyle style = this.fGrid.GetFooterCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return Color.Empty;
        return style.BackColor;
      }
      set
      {
        this.AdjustStyle().BackColor = value;
      }
    }

    /// <summary>Gets or sets the color of the text displayed in the footer cell.</summary>
    /// <value>The color of the footer cell's text.</value>
    public Color ForeColor
    {
      get
      {
        iGFooterCellStyle style = this.fGrid.GetFooterCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return Color.Empty;
        return style.ForeColor;
      }
      set
      {
        this.AdjustStyle().ForeColor = value;
      }
    }

    /// <summary>Gets or sets the font used to display the text in the footer cell.</summary>
    /// <value>The <see cref="T:System.Drawing.Font" /> object to apply to the text displayed in the footer cell. The default is null (Nothing in VB), which means that the property is not specified and the property value is obtained from the <see cref="P:TenTec.Windows.iGridLib.iGFooter.Font" /> property of the <see cref="P:TenTec.Windows.iGridLib.iGrid.Footer" /> object.</value>
    public Font Font
    {
      get
      {
        iGFooterCellStyle style = this.fGrid.GetFooterCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return (Font) null;
        return style.Font;
      }
      set
      {
        this.AdjustStyle().Font = value;
      }
    }

    /// <summary>Gets or sets a value indicating the left, top, right, and bottom indents of the footer cell contents.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGIndent" /> object that specifies the left, right, top and bottom indents. The default is <see cref="P:TenTec.Windows.iGridLib.iGIndent.NotSet" />, which means that the property is not specified and the property value is obtained from the <see cref="P:TenTec.Windows.iGridLib.iGStyleBase.ContentIndent" /> property of the cell style attached to the column (the <see cref="P:TenTec.Windows.iGridLib.iGCol.CellStyle" /> property of the column).</value>
    public iGIndent ContentIndent
    {
      get
      {
        iGFooterCellStyle style = this.fGrid.GetFooterCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return iGIndent.NotSet;
        return style.ContentIndent;
      }
      set
      {
        this.AdjustStyle().ContentIndent = value;
      }
    }

    /// <summary>Gets or sets the horizontal and vertical alignment of the text displayed in the footer cell.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGContentAlignment" /> enumeration value that specifies where to place the text. The default value is <see cref="F:TenTec.Windows.iGridLib.iGContentAlignment.NotSet" />, which means that the text alignment is obtained from the cell style object of the column.</value>
    public iGContentAlignment TextAlign
    {
      get
      {
        iGFooterCellStyle style = this.fGrid.GetFooterCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return iGContentAlignment.NotSet;
        return style.TextAlign;
      }
      set
      {
        this.AdjustStyle().TextAlign = value;
      }
    }

    /// <summary>Gets or sets the text format flags of the footer cell (similar to the <see cref="P:System.Drawing.StringFormat.FormatFlags" /> property of the <see cref="T:System.Drawing.StringFormat" /> class).</summary>
    /// <value>A bitwise combination of the <see cref="T:TenTec.Windows.iGridLib.iGStringFormatFlags" /> values. The default value is <see cref="F:TenTec.Windows.iGridLib.iGStringFormatFlags.NotSet" />, which means that the property value is obtained from the cell style object of the column.</value>
    public iGStringFormatFlags TextFormatFlags
    {
      get
      {
        iGFooterCellStyle style = this.fGrid.GetFooterCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return iGStringFormatFlags.NotSet;
        return style.TextFormatFlags;
      }
      set
      {
        this.AdjustStyle().TextFormatFlags = value;
      }
    }

    /// <summary>Gets or sets a value determining the trimming options of the text displayed in the footer cell (similar to the <see cref="P:System.Drawing.StringFormat.Trimming" /> property of the <see cref="T:System.Drawing.StringFormat" /> class).</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGStringTrimming" /> enumeration values. The default value is <see cref="F:TenTec.Windows.iGridLib.iGStringTrimming.NotSet" />, which means that the property value is obtained from the cell style object of the column.</value>
    public iGStringTrimming TextTrimming
    {
      get
      {
        iGFooterCellStyle style = this.fGrid.GetFooterCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return iGStringTrimming.NotSet;
        return style.TextTrimming;
      }
      set
      {
        this.AdjustStyle().TextTrimming = value;
      }
    }

    /// <summary>Gets or sets the format string applied to the footer cell's value before it is displayed (similar to the format string parameter in the <see cref="M:System.String.Format(System.IFormatProvider,System.String,System.Object[])" /> method of the <see cref="T:System.String" /> class).</summary>
    /// <value>The <see cref="T:System.String" /> used as the format string to get the text displayed in the cell. The default value is null (Nothing in VB).</value>
    public string FormatString
    {
      get
      {
        iGFooterCellStyle style = this.fGrid.GetFooterCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return (string) null;
        return style.FormatString;
      }
      set
      {
        this.AdjustStyle().FormatString = value;
      }
    }

    /// <summary>Gets or sets the format provider used to get the string representation of the footer cell's value (similar to the format provider in the <see cref="M:System.String.Format(System.IFormatProvider,System.String,System.Object[])" /> method of the <see cref="T:System.String" /> class).</summary>
    /// <value>The <see cref="T:System.IFormatProvider" /> object used to get the text displayed in the footer cell. The default value is null (Nothing in VB).</value>
    public IFormatProvider FormatProvider
    {
      get
      {
        iGCellStyle style = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return (IFormatProvider) null;
        return style.FormatProvider;
      }
      set
      {
        this.AdjustStyle().FormatProvider = value;
      }
    }

    /// <summary>Gets or sets the horizontal and vertical alignment of the image displayed in the cell.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGContentAlignment" /> enumeration value that specifies where to place the image. The default value is <see cref="F:TenTec.Windows.iGridLib.iGContentAlignment.NotSet" /> which means that the image alignment is obtained from the cell style object of the column.</value>
    public iGContentAlignment ImageAlign
    {
      get
      {
        iGFooterCellStyle style = this.fGrid.GetFooterCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return iGContentAlignment.NotSet;
        return style.ImageAlign;
      }
      set
      {
        this.AdjustStyle().ImageAlign = value;
      }
    }

    /// <summary>Gets or sets the relative position of the image and text displayed in the cell.</summary>
    /// <value>Gets or sets the relative position of the image and text displayed in the footer cell.</value>
    public iGTextPosToImage TextPosToImage
    {
      get
      {
        iGFooterCellStyle style = this.fGrid.GetFooterCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return iGTextPosToImage.NotSet;
        return style.TextPosToImage;
      }
      set
      {
        this.AdjustStyle().TextPosToImage = value;
      }
    }

    /// <summary>Gets or sets the image list used to display the image in the cell.</summary>
    /// <value>An <see cref="T:System.Windows.Forms.ImageList" /> object used to store the image in the footer cell. The default value is null (Nothing in VB), which means that the image list is obtained from the <see cref="P:TenTec.Windows.iGridLib.iGrid.Footer" /> object.</value>
    public ImageList ImageList
    {
      get
      {
        iGFooterCellStyle style = this.fGrid.GetFooterCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return (ImageList) null;
        return style.ImageList;
      }
      set
      {
        this.AdjustStyle().ImageList = value;
      }
    }

    /// <summary>Gets or sets a value determining which footer cell parts are custom drawn.</summary>
    /// <value>A bitwise combination of the <see cref="T:TenTec.Windows.iGridLib.iGCustomDrawFlags" /> values. The default is <see cref="F:TenTec.Windows.iGridLib.iGCustomDrawFlags.NotSet" />, which means that the property is not specified and the property value is obtained from the <see cref="P:TenTec.Windows.iGridLib.iGStyleBase.CustomDrawFlags" /> property of the column cell style.</value>
    public iGCustomDrawFlags CustomDrawFlags
    {
      get
      {
        iGFooterCellStyle style = this.fGrid.GetFooterCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return iGCustomDrawFlags.NotSet;
        return style.CustomDrawFlags;
      }
      set
      {
        this.AdjustStyle().CustomDrawFlags = value;
      }
    }

    /// <summary>Gets or sets the number of rows the footer cell should span.</summary>
    /// <value>The number of rows the footer cell should span. The default is 1.</value>
    public int SpanRows
    {
      get
      {
        return this.fGrid.Span__PropertySpanRowsGet(iGGridSection.Footer, this.fRowIndex, this.fColIndex);
      }
      set
      {
        this.fGrid.Span__PropertySpanRowsSet(iGGridSection.Footer, this.fRowIndex, this.fColIndex, value);
      }
    }

    /// <summary>Gets or sets the number of columns the footer cell should span.</summary>
    /// <value>The number of columns the footer cell should span. The default is 1.</value>
    public int SpanCols
    {
      get
      {
        return this.fGrid.Span__PropertySpanColsGet(iGGridSection.Footer, this.fRowIndex, this.fColIndex);
      }
      set
      {
        this.fGrid.Span__PropertySpanColsSet(iGGridSection.Footer, this.fRowIndex, this.fColIndex, value);
      }
    }

    /// <summary>Returns the root cell (the top left cell) of the merged footer cell that contains the specified footer cell.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGFooterCell" /> object that represents the root cell of the merged cell that covers the specified footer cell.</value>
    public iGFooterCell SpanRoot
    {
      get
      {
        return new iGFooterCell(this.fGrid, this.fRowIndex - (this.fGrid.Span__GetSpanRowsNear(iGGridSection.Footer, this.fRowIndex, this.fColIndex) - 1), this.fColIndex - (this.fGrid.Span__GetSpanColsNear(iGGridSection.Footer, this.fRowIndex, this.fColIndex) - 1));
      }
    }

    /// <summary>Gets the footer row that contains the footer cell.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGFooterRow" /> object that represents the footer row containing this footer cell.</value>
    [Browsable(false)]
    public iGFooterRow Row
    {
      get
      {
        return new iGFooterRow(this.fGrid, this.fRowIndex);
      }
    }

    /// <summary>Gets the column that contains the footer cell.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGCol" /> object that represents the column containing this footer cell.</value>
    [Browsable(false)]
    public iGCol Col
    {
      get
      {
        return new iGCol(this.fGrid, this.fColIndex);
      }
    }

    /// <summary>Retrieves the bounds of the footer cell. The coordinates are relative to the upper left corner of the grid.</summary>
    /// <value>A <see cref="T:System.Drawing.Rectangle" /> that represents the size and location of the footer cell. The coordinates are relative to the upper left corner of the grid.</value>
    public Rectangle Bounds
    {
      get
      {
        return this.fGrid.GetFooterCellBounds(this.fRowIndex, this.fGrid.GetColOrder(this.fColIndex));
      }
    }

    /// <summary>Retrieves the bounds of the footer cell where the text is displayed. The coordinates are relative to the upper left corner of the grid.</summary>
    /// <value>A <see cref="T:System.Drawing.Rectangle" /> that represents the size and location of the footer cell's text area. The coordinates are relative to the upper left corner of the grid.</value>
    public Rectangle TextBounds
    {
      get
      {
        return this.fGrid.GetFooterCellTextAreaBounds(this.fRowIndex, this.fColIndex);
      }
    }

    /// <summary>Retrieves the bounds of the footer cell where the image is displayed. The coordinates are relative to the upper left corner of the grid.</summary>
    /// <value>A <see cref="T:System.Drawing.Rectangle" /> that represents the size and location of the footer cell's image area. The coordinates are relative to the upper left corner of the grid.</value>
    public Rectangle ImageBounds
    {
      get
      {
        return this.fGrid.GetUniCellImageAreaBounds(iGGridSection.Footer, this.fRowIndex, this.fColIndex);
      }
    }
  }
}
