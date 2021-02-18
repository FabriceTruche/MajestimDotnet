// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCell
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
  /// <summary>Represents a cell of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public sealed class iGCell : IiGImageListProvider
  {
    internal int fColIndex;
    internal int fRowIndex;
    internal iGrid fGrid;

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

    internal iGCell(iGrid grid, int rowIndex, int colIndex)
    {
      grid.CheckCellIndices(rowIndex, colIndex);
      this.fGrid = grid;
      this.fRowIndex = rowIndex;
      this.fColIndex = colIndex;
    }

    internal iGCell(iGrid grid, iGCellNavigator navigator)
    {
      this.fGrid = grid;
      this.fRowIndex = navigator.RowIndex;
      this.fColIndex = navigator.ColIndex;
    }

    private iGCellStyle AdjustStyle()
    {
      this.fGrid.CheckCellIndices(this.fRowIndex, this.fColIndex);
      iGCellStyle iGcellStyle = this.fGrid.GetCellDataInternal(this.fRowIndex, this.fColIndex).Style;
      if (iGcellStyle == null)
      {
        iGcellStyle = new iGCellStyle();
        this.fGrid.SetCellStyleInternal(this.fRowIndex, this.fColIndex, iGcellStyle);
      }
      else if (this.fGrid.fRedraw)
        this.fGrid.Invalidate();
      return iGcellStyle;
    }

    private iGCellStyle GetStyleForCellData(iGCellStyle cellDataStyle)
    {
      if (cellDataStyle == null)
        return new iGCellStyle();
      return cellDataStyle;
    }

    /// <summary>Ensures that the cell is visible, scrolling the grid as necessary.</summary>
    public void EnsureVisible()
    {
      this.fGrid.EnsureVisibleCell(this.fRowIndex, this.fColIndex);
    }

    /// <summary>Retrieves the string representation of the cell.</summary>
    /// <returns>A string that represents the cell.</returns>
    public override string ToString()
    {
      return string.Format("iGCell(RowIndex = {0}; ColIndex = {1})", (object) this.fRowIndex, (object) (this.fColIndex - 1));
    }

    /// <summary>Retrieves the bounds of the cell optionally including row level indent. The coordinates are relative to the upper left corner of the grid.</summary>
    /// <param name="includeLevel">If the cell is the first in the row, specifies whether to include the row's level indent to the result.</param>
    /// <returns>A <see cref="T:System.Drawing.Rectangle" /> that represents the size and location of the cell. The coordinates are relative to the upper left corner of the grid.</returns>
    public Rectangle GetBounds(bool includeLevel)
    {
      return this.fGrid.GetCellBounds(this.fRowIndex, this.fGrid.GetColOrder(this.fColIndex), includeLevel);
    }

    /// <summary>Returns a value indicating whether the specified cells parts are clipped.</summary>
    /// <param name="parts">The parts to be checked.</param>
    /// <returns>True if a cell part is clipped; otherwise, False.</returns>
    public bool IsCellPartClipped(iGClippedCellParts parts)
    {
      return this.IsCellPartClipped(parts, true);
    }

    /// <summary>Returns a value indicating whether the specified cells parts are clipped.</summary>
    /// <param name="parts">The parts to be checked.</param>
    /// <param name="checkIfPartiallyHidden">Indicates whether this method should check if a cell part is located out of the cells area. When the grid has more cells that it can be displayed in its view port (cells area), some cells can be partially or entirely hidden by the edges of the view port. In this case if you set the checkIfPartiallyHidden parameter to True, this method will return True for these cells.</param>
    /// <returns>True if a cell part is clipped; otherwise, False.</returns>
    public bool IsCellPartClipped(iGClippedCellParts parts, bool checkIfPartiallyHidden)
    {
      iGCellData cellData = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex);
      return this.fGrid.IsUniCellPartClippedInternal(iGGridSection.Cells, this.fRowIndex, this.fColIndex, parts, checkIfPartiallyHidden, cellData.Value, cellData.AuxValue, cellData.ImageIndex, (iGStyleBase) cellData.Style, (iGStyleBase) this.Row.CellStyle, (iGStyleBase) this.Col.CellStyle);
    }

    ImageList IiGImageListProvider.GetImageList(string propertyName)
    {
      return this.fGrid.GetUniCellImageList(iGGridSection.Cells, (iGStyleBase) this.Style, (iGStyleBase) this.Row.CellStyle, (iGStyleBase) this.Col.CellStyle);
    }

    private bool ShouldSerializeBackColor()
    {
      return this.BackColor != iGStyleBase.ConstDefaultBackColor;
    }

    private bool ShouldSerializeForeColor()
    {
      return this.ForeColor != iGStyleBase.ConstDefaultForeColor;
    }

    private bool ShouldSerializeContentIndent()
    {
      return iGStyleBase.ShouldSerializeIndent(this.ContentIndent, iGStyleBase.ConstDefaultIndent);
    }

    /// <summary>Gets or sets an object storing all the cell's data.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGCellPattern" /> object that stores a copy of the cell properties.</value>
    [Browsable(false)]
    public iGCellPattern Pattern
    {
      get
      {
        return new iGCellPattern(this.fGrid.GetCellDataPublicSpanProps(this.fRowIndex, this.fColIndex));
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException();
        this.fGrid.SetCellPattern(this.fRowIndex, this.fColIndex, value.fData);
      }
    }

    /// <summary>Gets or sets the value used to display the cell's text.</summary>
    /// <value>A value of any available type (a value type or an instance of a class). The default value is null (Nothing in VB).</value>
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGStringConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [DefaultValue(null)]
    [Description("The value used to display the cell's text.")]
    [Category("Data")]
    public object Value
    {
      get
      {
        return this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Value;
      }
      set
      {
        this.fGrid.SetCellValue(this.fRowIndex, this.fColIndex, value, false, true, true);
      }
    }

    /// <summary>Gets or sets an auxiliary value.</summary>
    /// <value>An object.</value>
    [Browsable(false)]
    [DefaultValue(null)]
    public object AuxValue
    {
      get
      {
        return this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).AuxValue;
      }
      set
      {
        this.fGrid.SetCellAuxValue(this.fRowIndex, this.fColIndex, value, false);
      }
    }

    /// <summary>Gets or sets the index of the image displayed in the cell.</summary>
    /// <value>A zero-based index that represents the image position in an <see cref="T:System.Windows.Forms.ImageList" />. The default is -1, which means that the cell has no image.</value>
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGImageIndexConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Editor("TenTec.Windows.iGridLib.Design.iGImageIndexEditor, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0", typeof (UITypeEditor))]
    [DefaultValue(-1)]
    [Description("The index of the image displayed in the cell.")]
    [Category("Data")]
    public int ImageIndex
    {
      get
      {
        return this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).ImageIndex;
      }
      set
      {
        this.fGrid.SetCellImageIndex(this.fRowIndex, this.fColIndex, value, false);
      }
    }

    /// <summary>Gets or sets an <see cref="T:TenTec.Windows.iGridLib.iGCellStyle" /> object determining the appearance and behavior of the cell.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGCellStyle" /> object that determines the appearance and behavior of the cell, or null (Nothing in VB) if the appearance and behavior of the cell is completely determined by the row and column styles and the grid's properties. The default value is null (Nothing in VB).</value>
    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(null)]
    [Description("A style object determining the appearance and behavior of the cell.")]
    [Category("Appearance and Behavior")]
    public iGCellStyle Style
    {
      get
      {
        return this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Style;
      }
      set
      {
        this.fGrid.SetCellStyle(this.fRowIndex, this.fColIndex, value, false);
      }
    }

    /// <summary>Gets or sets the number of columns the cell should span.</summary>
    /// <value>The number of columns the cell should span. The default value is 1.</value>
    [DefaultValue(1)]
    [Description("Gets or sets the number of columns to span.")]
    [Category("Appearance and Behavior")]
    public int SpanCols
    {
      get
      {
        return this.fGrid.GetCellDataPublicSpanProps(this.fRowIndex, this.fColIndex).SpanCols;
      }
      set
      {
        this.fGrid.SetCellSpanCols(this.fRowIndex, this.fColIndex, value);
      }
    }

    /// <summary>Gets or sets the number of rows the cell should span.</summary>
    /// <value>The number of rows the cell should span. The default value is 1.</value>
    [DefaultValue(1)]
    [Description("Gets or sets the number of rows to span.")]
    [Category("Appearance and Behavior")]
    public int SpanRows
    {
      get
      {
        return this.fGrid.GetCellDataPublicSpanProps(this.fRowIndex, this.fColIndex).SpanRows;
      }
      set
      {
        this.fGrid.SetCellSpanRows(this.fRowIndex, this.fColIndex, value);
      }
    }

    /// <summary>Returns the root cell (the top left cell) of the merged cell containing the cell.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGCell" /> object that represents the root cell of the merged cell containing the cell.</value>
    [Browsable(false)]
    public iGCell SpanRoot
    {
      get
      {
        iGCellData cellDataInternal = this.fGrid.GetCellDataInternal(this.fRowIndex, this.fColIndex);
        int rowIndex = cellDataInternal.SpanRows >= 1 ? this.fRowIndex : this.fRowIndex + cellDataInternal.SpanRows;
        int colOrder = this.fGrid.GetColOrder(this.fColIndex);
        int index = cellDataInternal.SpanCols >= 1 ? colOrder : colOrder + cellDataInternal.SpanCols;
        return new iGCell(this.fGrid, rowIndex, this.fGrid.fColIdxFromOrd[index]);
      }
    }

    /// <summary>Gets or sets a value indicating whether the cell is selected.</summary>
    /// <value>True if the cell is selected; otherwise, False.</value>
    [Browsable(false)]
    public bool Selected
    {
      get
      {
        return this.fGrid.GetCellSelected(this.fRowIndex, this.fColIndex);
      }
      set
      {
        this.fGrid.SetCellSelected(this.fRowIndex, this.fColIndex, value);
      }
    }

    /// <summary>Gets the column index of the cell or -1 if it is a row text cell.</summary>
    /// <value>A zero-based index representing the position of the column in the grid's collection of columns. Or -1 if it is a row text column.</value>
    [Browsable(false)]
    public int ColIndex
    {
      get
      {
        return this.fColIndex - 1;
      }
    }

    /// <summary>Gets the row index of the cell.</summary>
    /// <value>A zero-based index representing the position of the row in the grid's collection of rows.</value>
    [Browsable(false)]
    public int RowIndex
    {
      get
      {
        return this.fRowIndex;
      }
    }

    /// <summary>Retrieves the bounds of the cell. The coordinates are relative to the upper left corner of the grid.</summary>
    /// <value>A <see cref="T:System.Drawing.Rectangle" /> that represents the size and location of the cell. The coordinates are relative to the upper left corner of the grid.</value>
    [Browsable(false)]
    public Rectangle Bounds
    {
      get
      {
        return this.fGrid.GetCellBounds(this.fRowIndex, this.fGrid.GetColOrder(this.fColIndex), false);
      }
    }

    /// <summary>Gets the string key of the column that contains the cell.</summary>
    /// <value>The string that is the key of the column which contains the cell, or null (Nothing in VB) if the column does not have a key.</value>
    [Browsable(false)]
    public string ColKey
    {
      get
      {
        return this.fGrid.GetColData(this.fColIndex).Key;
      }
    }

    /// <summary>Gets the string key of the row the cell belongs to.</summary>
    /// <value>The string that is the key of the row which contains the cell, or null (Nothing in VB) if the row does not have a key.</value>
    [Browsable(false)]
    public string RowKey
    {
      get
      {
        return this.fGrid.GetRowData(this.fRowIndex).Key;
      }
    }

    /// <summary>Gets a value indicating whether the cell is a row text cell (the row text cells are displayed under normal cells and in the group rows).</summary>
    /// <value>True if this is a row text cell; otherwise, False.</value>
    [Browsable(false)]
    public bool IsRowText
    {
      get
      {
        return this.fColIndex == 0;
      }
    }

    /// <summary>Retrieves the bounds of the cell where the text is displayed. The coordinates are relative to the upper left corner of the grid.</summary>
    /// <value>A <see cref="T:System.Drawing.Rectangle" /> that represents the size and location of the cell's text area. The coordinates are relative to the upper left corner of the grid.</value>
    [Browsable(false)]
    public Rectangle TextBounds
    {
      get
      {
        return this.fGrid.GetCellTextAreaBounds(this.fRowIndex, this.fColIndex);
      }
    }

    /// <summary>Retrieves the bounds of the cell where the image is displayed. The coordinates are relative to the upper left corner of the grid.</summary>
    /// <value>A <see cref="T:System.Drawing.Rectangle" /> that represents the size and location of the cell's image area. The coordinates are relative to the upper left corner of the grid.</value>
    [Browsable(false)]
    public Rectangle ImageBounds
    {
      get
      {
        return this.fGrid.GetUniCellImageAreaBounds(iGGridSection.Cells, this.fRowIndex, this.fColIndex);
      }
    }

    /// <summary>Gets the row that contains the cell.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGRow" /> object that provides the properties and methods of the row that contains this cell.</value>
    [TypeConverter(typeof (ExpandableObjectConverter))]
    [Description("The row that contains the cell.")]
    public iGRow Row
    {
      get
      {
        return new iGRow(this.fGrid, this.fRowIndex);
      }
    }

    /// <summary>Gets the column that contains the cell.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGCol" /> object that provides the properties and methods of the column that contains this cell.</value>
    [TypeConverter(typeof (ExpandableObjectConverter))]
    [Description("The column that contains the cell.")]
    public iGCol Col
    {
      get
      {
        return new iGCol(this.fGrid, this.fColIndex);
      }
    }

    /// <summary>Gets the text displayed in the cell.</summary>
    /// <value>The text displayed in the cell.</value>
    [DefaultValue(null)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public string Text
    {
      get
      {
        return this.fGrid.GetCellText(this.fRowIndex, this.fColIndex);
      }
    }

    /// <summary>Gets the horizontal and vertical alignment of the text displayed in the cell used when drawing.</summary>
    /// <value>The horizontal and vertical alignment of the text displayed in the cell used when drawing.</value>
    [Browsable(false)]
    public iGContentAlignment EffectiveTextAlign
    {
      get
      {
        this.fGrid.CheckCellIndices(this.fRowIndex, this.fColIndex);
        return this.fGrid.GetPropFromStyles_TextAlign((iGStyleBase) this.fGrid.GetCellDataInternal(this.fRowIndex, this.fColIndex).Style, (iGStyleBase) this.fGrid.GetRowDataInternal(this.fRowIndex).CellStyle, (iGStyleBase) this.fGrid.GetColDataInternal(this.fColIndex).CellStyle);
      }
    }

    /// <summary>Gets the content indent used when drawing.</summary>
    /// <value>The indent for the cell content used when drawing.</value>
    [Browsable(false)]
    public iGIndent EffectiveContentIndent
    {
      get
      {
        this.fGrid.CheckCellIndices(this.fRowIndex, this.fColIndex);
        return this.fGrid.GetPropFromStyles_ContentIndent((iGStyleBase) this.fGrid.GetCellDataInternal(this.fRowIndex, this.fColIndex).Style, (iGStyleBase) this.fGrid.GetRowDataInternal(this.fRowIndex).CellStyle, (iGStyleBase) this.fGrid.GetColDataInternal(this.fColIndex).CellStyle);
      }
    }

    /// <summary>Gets the horizontal and vertical alignment of the image displayed in the cell used when drawing.</summary>
    /// <value>The horizontal and vertical alignment of the image displayed in the cell used when drawing.</value>
    [Browsable(false)]
    public iGContentAlignment EffectiveImageAlign
    {
      get
      {
        this.fGrid.CheckCellIndices(this.fRowIndex, this.fColIndex);
        return this.fGrid.GetPropFromStyles_ImageAlignNative((iGStyleBase) this.fGrid.GetCellDataInternal(this.fRowIndex, this.fColIndex).Style, (iGStyleBase) this.fGrid.GetRowDataInternal(this.fRowIndex).CellStyle, (iGStyleBase) this.fGrid.GetColDataInternal(this.fColIndex).CellStyle);
      }
    }

    /// <summary>Gets the relative position of the image and text displayed in the cell used when drawing.</summary>
    /// <value>The relative position of the image and text displayed in the cell used when drawing.</value>
    [Browsable(false)]
    public iGTextPosToImage EffectiveTextPosToImage
    {
      get
      {
        this.fGrid.CheckCellIndices(this.fRowIndex, this.fColIndex);
        return this.fGrid.GetPropFromStyles_TextPosToImage((iGStyleBase) this.fGrid.GetCellDataInternal(this.fRowIndex, this.fColIndex).Style, (iGStyleBase) this.fGrid.GetRowDataInternal(this.fRowIndex).CellStyle, (iGStyleBase) this.fGrid.GetColDataInternal(this.fColIndex).CellStyle);
      }
    }

    /// <summary>Gets the background color of the cell used when drawing.</summary>
    /// <value>The background color of the cell used when drawing or <see cref="F:System.Drawing.Color.Empty" /> if no background color is attached to the cell through its or its column's or row's style or <see cref="E:TenTec.Windows.iGridLib.iGrid.CellDynamicFormatting" /> event.</value>
    [Browsable(false)]
    public Color EffectiveBackColor
    {
      get
      {
        this.fGrid.CheckCellIndices(this.fRowIndex, this.fColIndex);
        iGCellStyle style = this.fGrid.GetCellDataInternal(this.fRowIndex, this.fColIndex).Style;
        iGCellStyle cellStyle1 = this.fGrid.GetRowDataInternal(this.fRowIndex).CellStyle;
        iGCellStyle cellStyle2 = this.fGrid.GetColDataInternal(this.fColIndex).CellStyle;
        bool isEven = false;
        bool isOdd = false;
        if (!this.fGrid.BackColorEvenRows.IsEmpty || !this.fGrid.BackColorOddRows.IsEmpty)
        {
          isEven = this.fGrid.IsEvenRowInternal(this.fRowIndex);
          isOdd = !isOdd;
        }
        return this.fGrid.GetUniCellBackColorNoSelected(iGGridSection.Cells, this.fRowIndex, this.fColIndex, (iGStyleBase) style, (iGStyleBase) cellStyle1, (iGStyleBase) cellStyle2, !this.fGrid.Enabled || !this.fGrid.GetPropFromStyles_Enabled(style, cellStyle1, cellStyle2) ? iGControlState.Disabled : iGControlState.Normal, isEven, isOdd, false, false);
      }
    }

    /// <summary>Gets the foreground color of the cell used when drawing.</summary>
    /// <value>The foreground color of the cell used when drawing.</value>
    [Browsable(false)]
    public Color EffectiveForeColor
    {
      get
      {
        this.fGrid.CheckCellIndices(this.fRowIndex, this.fColIndex);
        iGCellStyle style = this.fGrid.GetCellDataInternal(this.fRowIndex, this.fColIndex).Style;
        iGCellStyle cellStyle1 = this.fGrid.GetRowDataInternal(this.fRowIndex).CellStyle;
        iGCellStyle cellStyle2 = this.fGrid.GetColDataInternal(this.fColIndex).CellStyle;
        return this.fGrid.GetUniCellForeColorNoSelected(iGGridSection.Cells, this.fRowIndex, this.fColIndex, (iGStyleBase) style, (iGStyleBase) cellStyle1, (iGStyleBase) cellStyle2, !this.fGrid.Enabled || !this.fGrid.GetPropFromStyles_Enabled(style, cellStyle1, cellStyle2) ? iGControlState.Disabled : iGControlState.Normal, false, false, false, false);
      }
    }

    /// <summary>Gets the font used when drawing the cell text.</summary>
    /// <value>The font used when drawing the cell text.</value>
    [Browsable(false)]
    public Font EffectiveFont
    {
      get
      {
        this.fGrid.CheckCellIndices(this.fRowIndex, this.fColIndex);
        iGCellStyle style = this.fGrid.GetCellDataInternal(this.fRowIndex, this.fColIndex).Style;
        iGCellStyle cellStyle1 = this.fGrid.GetRowDataInternal(this.fRowIndex).CellStyle;
        iGCellStyle cellStyle2 = this.fGrid.GetColDataInternal(this.fColIndex).CellStyle;
        return this.fGrid.GetUniCellFont(iGGridSection.Cells, this.fRowIndex, this.fColIndex, (iGStyleBase) style, (iGStyleBase) cellStyle1, (iGStyleBase) cellStyle2, !this.fGrid.Enabled || !this.fGrid.GetPropFromStyles_Enabled(style, cellStyle1, cellStyle2) ? iGControlState.Disabled : iGControlState.Normal, false, false, false, false);
      }
    }

    /// <summary>Gets the type of the cell used when drawing.</summary>
    /// <value>The type of the cell used when drawing.</value>
    [Browsable(false)]
    public iGCellType EffectiveType
    {
      get
      {
        this.fGrid.CheckCellIndices(this.fRowIndex, this.fColIndex);
        iGCellStyle style = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Style;
        iGCellStyle cellStyle1 = this.fGrid.fColDatas[this.fColIndex].CellStyle;
        iGCellStyle cellStyle2 = this.fGrid.GetRowDataInternal(this.fRowIndex).CellStyle;
        return (iGCellType) this.fGrid.GetPropFromStyles_DrawType((iGStyleBase) style, (iGStyleBase) cellStyle2, (iGStyleBase) cellStyle1);
      }
    }

    /// <summary>Gets the type flags of the cell used when drawing.</summary>
    /// <value>The type flags of the cell used when drawing.</value>
    [Browsable(false)]
    public iGCellTypeFlags EffectiveTypeFlags
    {
      get
      {
        this.fGrid.CheckCellIndices(this.fRowIndex, this.fColIndex);
        iGCellStyle style = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Style;
        iGCellStyle cellStyle1 = this.fGrid.fColDatas[this.fColIndex].CellStyle;
        iGCellStyle cellStyle2 = this.fGrid.GetRowDataInternal(this.fRowIndex).CellStyle;
        return (iGCellTypeFlags) this.fGrid.GetPropFromStyles_DrawTypeFlags((iGStyleBase) style, (iGStyleBase) cellStyle2, (iGStyleBase) cellStyle1);
      }
    }

    /// <summary>Gets the check state of the cell check box used when drawing.</summary>
    /// <value>The check state of the cell check box used when drawing.</value>
    [Browsable(false)]
    public CheckState EffectiveCheckState
    {
      get
      {
        this.fGrid.CheckCellIndices(this.fRowIndex, this.fColIndex);
        iGCellStyle style = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Style;
        iGCellStyle cellStyle1 = this.fGrid.fColDatas[this.fColIndex].CellStyle;
        iGCellStyle cellStyle2 = this.fGrid.GetRowDataInternal(this.fRowIndex).CellStyle;
        return this.fGrid.GetCheckStateFromObjectValue(this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Value, this.fGrid.GetPropFromStyles_DrawTypeFlags((iGStyleBase) style, (iGStyleBase) cellStyle2, (iGStyleBase) cellStyle1));
      }
    }

    /// <summary>Gets or sets the background color of the cell.</summary>
    /// <value>A <see cref="T:System.Drawing.Color" /> object that represents the background color of the cell, or <see cref="F:System.Drawing.Color.Empty" /> if the color is determined from the row or column style or grid. The default is the <see cref="F:System.Drawing.Color.Empty" /> value.</value>
    [RefreshProperties(RefreshProperties.All)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGColorEmptyAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Description("Determines the background color of the cell.")]
    [Category("Appearance")]
    public Color BackColor
    {
      get
      {
        iGCellStyle style = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return Color.Empty;
        return style.BackColor;
      }
      set
      {
        this.fGrid.CheckCellIndices(this.fRowIndex, this.fColIndex);
        if (this.fGrid.NeedIndexAdjustAfterValueChange(this.fRowIndex, this.fColIndex, iGSortType.ByBackColor | iGSortType.Custom))
        {
          iGCellData cellData = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex);
          iGCellStyle styleForCellData = this.GetStyleForCellData(cellData.Style);
          this.fGrid.SetCellStyleInternal(this.fRowIndex, this.fColIndex, styleForCellData);
          cellData.Style = styleForCellData.Clone();
          cellData.Style.BackColor = value;
          this.fGrid.OnCellSortParamChanged(ref this.fRowIndex, this.fColIndex, cellData, this.fGrid.GetRowDataInternal(this.fRowIndex).CellStyle);
          styleForCellData.BackColor = value;
        }
        else
          this.AdjustStyle().BackColor = value;
      }
    }

    /// <summary>Gets or sets the color of the text displayed in the cell.</summary>
    /// <value>The foreground color of the cell. The default is <see cref="F:System.Drawing.Color.Empty" /> which means that the property value is obtained from the row or column style and grid.</value>
    [RefreshProperties(RefreshProperties.All)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGColorEmptyAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Description("Determines the color of the text displayed in the cell.")]
    [Category("Appearance")]
    public Color ForeColor
    {
      get
      {
        iGCellStyle style = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return Color.Empty;
        return style.ForeColor;
      }
      set
      {
        this.fGrid.CheckCellIndices(this.fRowIndex, this.fColIndex);
        if (this.fGrid.NeedIndexAdjustAfterValueChange(this.fRowIndex, this.fColIndex, iGSortType.ByForeColor | iGSortType.Custom))
        {
          iGCellData cellData = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex);
          iGCellStyle styleForCellData = this.GetStyleForCellData(cellData.Style);
          this.fGrid.SetCellStyleInternal(this.fRowIndex, this.fColIndex, styleForCellData);
          cellData.Style = styleForCellData.Clone();
          cellData.Style.ForeColor = value;
          this.fGrid.OnCellSortParamChanged(ref this.fRowIndex, this.fColIndex, cellData, this.fGrid.GetRowDataInternal(this.fRowIndex).CellStyle);
          styleForCellData.ForeColor = value;
        }
        else
          this.AdjustStyle().ForeColor = value;
      }
    }

    /// <summary>Gets or sets the font used to display the text in the cell.</summary>
    /// <value>The <see cref="T:System.Drawing.Font" /> object to apply to the text displayed in the cell. The default is null (Nothing in VB) that means that the font is obtained from the row or column style and grid.</value>
    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(null)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGFontNoneAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Description("Determines the font used to display the text in the cell.")]
    [Category("Appearance")]
    public Font Font
    {
      get
      {
        iGCellStyle style = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return (Font) null;
        return style.Font;
      }
      set
      {
        this.fGrid.CheckCellIndices(this.fRowIndex, this.fColIndex);
        if (this.fGrid.NeedIndexAdjustAfterValueChange(this.fRowIndex, this.fColIndex, iGSortType.ByFont | iGSortType.Custom))
        {
          iGCellData cellData = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex);
          iGCellStyle styleForCellData = this.GetStyleForCellData(cellData.Style);
          this.fGrid.SetCellStyleInternal(this.fRowIndex, this.fColIndex, styleForCellData);
          cellData.Style = styleForCellData.Clone();
          cellData.Style.Font = value;
          this.fGrid.OnCellSortParamChanged(ref this.fRowIndex, this.fColIndex, cellData, this.fGrid.GetRowDataInternal(this.fRowIndex).CellStyle);
          styleForCellData.Font = value;
        }
        else
          this.AdjustStyle().Font = value;
      }
    }

    /// <summary>Gets or sets a value indicating the left, top, right and bottom indents of the cell's contents.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGIndent" /> object that specifies the left, right, top and bottom indents. The default is the <see cref="P:TenTec.Windows.iGridLib.iGIndent.NotSet" /> value which means that the value of the property is got from the style of the row or column.</value>
    [RefreshProperties(RefreshProperties.All)]
    [Description("Determines the left, top, right, and bottom indents of the cell's contents.")]
    [Category("Appearance")]
    public iGIndent ContentIndent
    {
      get
      {
        iGCellStyle style = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return iGIndent.NotSet;
        return style.ContentIndent;
      }
      set
      {
        this.AdjustStyle().ContentIndent = value;
      }
    }

    /// <summary>Gets or sets the horizontal and vertical alignment of the image displayed in the cell.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGContentAlignment" /> enumeration value that specifies where to place the image. The default value is <see cref="F:TenTec.Windows.iGridLib.iGContentAlignment.NotSet" /> which means that the image alignment is obtained from the row or column style.</value>
    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(iGContentAlignment.NotSet)]
    [Description("Determines the horizontal and vertical alignment of the image displayed in the cell.")]
    [Category("Appearance")]
    public iGContentAlignment ImageAlign
    {
      get
      {
        iGCellStyle style = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Style;
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
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGTextPosToImage" /> enumeration values. The default value is <see cref="F:TenTec.Windows.iGridLib.iGTextPosToImage.NotSet" /> which means that the property value is obtained from the row or column style.</value>
    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(iGTextPosToImage.NotSet)]
    [Description("Determines the relative position of the image and text displayed in the cell.")]
    [Category("Appearance")]
    public iGTextPosToImage TextPosToImage
    {
      get
      {
        iGCellStyle style = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return iGTextPosToImage.NotSet;
        return style.TextPosToImage;
      }
      set
      {
        this.AdjustStyle().TextPosToImage = value;
      }
    }

    /// <summary>Gets or sets the type of the cell (a text or check box cell).</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGCellType" /> enumeration values. The default value is <see cref="F:TenTec.Windows.iGridLib.iGCellType.NotSet" /> which means that the property value is obtained from a style up the hierarchy (row's <see cref="P:TenTec.Windows.iGridLib.iGRow.CellStyle" /> or columns's <see cref="P:TenTec.Windows.iGridLib.iGCol.CellStyle" />).</value>
    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(iGCellType.NotSet)]
    [Description("Determines the type of the cell (a text box cell, a check box cell, etc).")]
    [Category("Behavior")]
    public iGCellType Type
    {
      get
      {
        iGCellStyle style = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return iGCellType.NotSet;
        return style.Type;
      }
      set
      {
        this.AdjustStyle().Type = value;
      }
    }

    /// <summary>Gets or sets the horizontal and vertical alignment of the text displayed in the cell.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGContentAlignment" /> enumeration value that specifies where to place the text. The default value is <see cref="F:TenTec.Windows.iGridLib.iGContentAlignment.NotSet" /> which means that the text alignment is obtained from the row or column style.</value>
    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(iGContentAlignment.NotSet)]
    [Description("Determines the horizontal and vertical alignment of the text displayed in the cell.")]
    [Category("Appearance")]
    public iGContentAlignment TextAlign
    {
      get
      {
        iGCellStyle style = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return iGContentAlignment.NotSet;
        return style.TextAlign;
      }
      set
      {
        this.AdjustStyle().TextAlign = value;
      }
    }

    /// <summary>Gets or sets the text format flags of the cell (similar to the <see cref="P:System.Drawing.StringFormat.FormatFlags" /> property of the <see cref="T:System.Drawing.StringFormat" /> class).</summary>
    /// <value>A bitwise combination of the <see cref="T:TenTec.Windows.iGridLib.iGStringFormatFlags" /> values. The default value is <see cref="F:TenTec.Windows.iGridLib.iGStringFormatFlags.NotSet" /> which means that the property value is obtained from the style of the row or column.</value>
    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(iGStringFormatFlags.NotSet)]
    [Description("Determines the text format flags of the cell (similar to the FormatFlags property of the StringFormat class).")]
    [Category("Appearance")]
    public iGStringFormatFlags TextFormatFlags
    {
      get
      {
        iGCellStyle style = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return iGStringFormatFlags.NotSet;
        return style.TextFormatFlags;
      }
      set
      {
        this.AdjustStyle().TextFormatFlags = value;
      }
    }

    /// <summary>Gets or sets a value determining the trimming options of the text displayed in the cell (similar to the <see cref="P:System.Drawing.StringFormat.Trimming" /> property of the <see cref="T:System.Drawing.StringFormat" /> class).</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGStringTrimming" /> enumeration values. The default value is <see cref="F:TenTec.Windows.iGridLib.iGStringTrimming.NotSet" /> which means that the property value is obtained from the row or column style.</value>
    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(iGStringTrimming.NotSet)]
    [Description("Determines the trimming options of the text dispalyed in the cell (similar to the Trimming property of the StringFormat class).")]
    [Category("Appearance")]
    public iGStringTrimming TextTrimming
    {
      get
      {
        iGCellStyle style = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return iGStringTrimming.NotSet;
        return style.TextTrimming;
      }
      set
      {
        this.AdjustStyle().TextTrimming = value;
      }
    }

    /// <summary>Gets or sets a value determining whether the cell is enabled. The disabled cells cannot be edited and the <see cref="P:TenTec.Windows.iGridLib.iGrid.ForeColorDisabled" /> color is used to draw their text.</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGBool" /> enumeration values. The default value is <see cref="F:TenTec.Windows.iGridLib.iGBool.NotSet" /> which means that the property value is obtained from the style of the row or column.</value>
    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(iGBool.NotSet)]
    [Description("Determines whether the cell is enabled. The disabled cells cannot be edited and the ForeColorDisabled color is used to draw their text.")]
    [Category("Behavior")]
    public iGBool Enabled
    {
      get
      {
        iGCellStyle style = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return iGBool.NotSet;
        return style.Enabled;
      }
      set
      {
        this.AdjustStyle().Enabled = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether the cell can be edited.</summary>
    /// <value><see cref="F:TenTec.Windows.iGridLib.iGBool.True" /> if the cell is read-only; otherwise, <see cref="F:TenTec.Windows.iGridLib.iGBool.False" />. The default value is <see cref="F:TenTec.Windows.iGridLib.iGBool.NotSet" /> which means that the property value is obtained from the row or column style.</value>
    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(iGBool.NotSet)]
    [Description("Determines whether the cell can be edited.")]
    [Category("Behavior")]
    public iGBool ReadOnly
    {
      get
      {
        iGCellStyle style = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return iGBool.NotSet;
        return style.ReadOnly;
      }
      set
      {
        this.AdjustStyle().ReadOnly = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether the cell can be selected with the mouse and/or keyboard.</summary>
    /// <value><see cref="F:TenTec.Windows.iGridLib.iGBool.True" /> if the cell can be selected; otherwise, <see cref="F:TenTec.Windows.iGridLib.iGBool.False" />. The default value is <see cref="F:TenTec.Windows.iGridLib.iGBool.NotSet" /> which means that the property value is obtained from the row or column style.</value>
    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(iGBool.NotSet)]
    [Description("Determines whether the cell can be selected with the mouse and/or keyboard.")]
    [Category("Behavior")]
    public iGBool Selectable
    {
      get
      {
        iGCellStyle style = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return iGBool.NotSet;
        return style.Selectable;
      }
      set
      {
        this.AdjustStyle().Selectable = value;
      }
    }

    /// <summary>Gets or sets the format string applied to the cell's value before it is displayed (similar to the formatString parameter in the <see cref="M:System.String.Format(System.IFormatProvider,System.String,System.Object[])" /> method of the <see cref="T:System.String" /> class).</summary>
    /// <value>The <see cref="T:System.String" /> that is used as the format string to get the text displayed in the cell. The default value is null (Nothing in VB) that means that the format string is obtained from the row or column style.</value>
    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(null)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGStringNoneAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Description("Determines the format string applied to the cell's value before it is displayed (similar to the formatString parameter in the Format method of the String class).")]
    [Category("Appearance")]
    public string FormatString
    {
      get
      {
        iGCellStyle style = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return (string) null;
        return style.FormatString;
      }
      set
      {
        this.AdjustStyle().FormatString = value;
      }
    }

    /// <summary>Gets or sets a format provider used to get the string representation of the cell's value (similar to the format provider in the <see cref="M:System.String.Format(System.IFormatProvider,System.String,System.Object[])" /> method of the <see cref="T:System.String" /> class).</summary>
    /// <value>An <see cref="T:System.IFormatProvider" /> object used to get the text displayed in the cell. The default value is null (Nothing in VB).</value>
    [Browsable(false)]
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

    /// <summary>Gets or sets a value determining which of the cell's parts are custom drawn.</summary>
    /// <value>A bitwise combination of the <see cref="T:TenTec.Windows.iGridLib.iGCustomDrawFlags" /> values. The default value is <see cref="F:TenTec.Windows.iGridLib.iGCustomDrawFlags.NotSet" /> which means that the property value is got from the style of the row or column.</value>
    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(iGCustomDrawFlags.NotSet)]
    [Description("Determines which of the cell's parts are custom drawn.")]
    [Category("Appearance")]
    public iGCustomDrawFlags CustomDrawFlags
    {
      get
      {
        iGCellStyle style = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return iGCustomDrawFlags.NotSet;
        return style.CustomDrawFlags;
      }
      set
      {
        this.AdjustStyle().CustomDrawFlags = value;
      }
    }

    /// <summary>Gets or sets the additional flags used to modify some aspects of the cell's type.</summary>
    /// <value>A bitwise combination of the <see cref="T:TenTec.Windows.iGridLib.iGCellTypeFlags" /> values. The default value is <see cref="F:TenTec.Windows.iGridLib.iGCellTypeFlags.NotSet" /> which means that the property value is obtained from the style of the row or column.</value>
    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(iGCellTypeFlags.NotSet)]
    [Description("Determines the additional flags used to modify some aspects of the cell's type.")]
    [Category("Behavior")]
    public iGCellTypeFlags TypeFlags
    {
      get
      {
        iGCellStyle style = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return iGCellTypeFlags.NotSet;
        return style.TypeFlags;
      }
      set
      {
        this.AdjustStyle().TypeFlags = value;
      }
    }

    /// <summary>Gets or sets flags that determine which parts of the cell's contents (image, text) are displayed.</summary>
    /// <value>A set of the <see cref="T:TenTec.Windows.iGridLib.iGCellFlags" /> enumeration values. The default value is <see cref="F:TenTec.Windows.iGridLib.iGCellFlags.NotSet" /> which means that the property value is obtained from the style of the row or column.</value>
    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(iGCellFlags.NotSet)]
    [Description("Flags that determine appearance and behavior of the cell.")]
    [Category("Appearance")]
    public iGCellFlags Flags
    {
      get
      {
        iGCellStyle style = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return iGCellFlags.NotSet;
        return style.Flags;
      }
      set
      {
        this.AdjustStyle().Flags = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether a single mouse click puts the cell into edit mode if it is not the current cell.</summary>
    /// <value><see cref="F:TenTec.Windows.iGridLib.iGBool.False" /> if only the current cell can be edited with the single mouse click; if <see cref="F:TenTec.Windows.iGridLib.iGBool.True" />, the single click starts edit the cell regardless of whether it was current or not. The default value is <see cref="F:TenTec.Windows.iGridLib.iGBool.NotSet" /> which means that the property value is obtained from the row or column style.</value>
    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(iGBool.NotSet)]
    [Description("Determines whether the single mouse click starts editing the cell if it is not current.")]
    [Category("Behavior")]
    public iGBool SingleClickEdit
    {
      get
      {
        iGCellStyle style = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return iGBool.NotSet;
        return style.SingleClickEdit;
      }
      set
      {
        this.AdjustStyle().SingleClickEdit = value;
      }
    }

    /// <summary>Gets or sets the type of the value the text entered while editing should be converted to.</summary>
    /// <value>An instance of the <see cref="T:System.Type" /> class which specifies the type of the cell value. The default value is null (Nothing in VB) which means that the value type is obtained from the row or column style.</value>
    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(null)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGValueTypeConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Description("Determines the type of the value to convert the edited text to.")]
    [Category("Behavior")]
    public System.Type ValueType
    {
      get
      {
        iGCellStyle style = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return (System.Type) null;
        return style.ValueType;
      }
      set
      {
        this.AdjustStyle().ValueType = value;
      }
    }

    /// <summary>Gets or sets the control to show in the drop-down form when editing the cell. This control is also used as the auto-complete control when editing the cell as text.</summary>
    /// <value>An instance of class that implements the <see cref="T:TenTec.Windows.iGridLib.IiGDropDownControl" /> interface.</value>
    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(null)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGReferenceNullAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Description("Determines the control to show in the drop-down form when editing the cell.")]
    [Category("Behavior")]
    public IiGDropDownControl DropDownControl
    {
      get
      {
        iGCellStyle style = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return (IiGDropDownControl) null;
        return style.DropDownControl;
      }
      set
      {
        this.AdjustStyle().DropDownControl = value;
      }
    }

    /// <summary>Gets or sets the image list used to display the image in the cell.</summary>
    /// <value>An <see cref="T:System.Windows.Forms.ImageList" /> object used to store the image in the cell. The default value is null (Nothing in VB), which means that the image list is obtained from the row or column style.</value>
    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(null)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGReferenceNullAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Description("Determines the image list used to display the image in the cell.")]
    [Category("Appearance")]
    public ImageList ImageList
    {
      get
      {
        iGCellStyle style = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return (ImageList) null;
        return style.ImageList;
      }
      set
      {
        this.AdjustStyle().ImageList = value;
      }
    }

    /// <summary>Gets or sets a value indicating how to interpret an empty string entered in the text box while editing the cell.</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGEmptyStringAs" /> enumeration values. The default value is <see cref="F:TenTec.Windows.iGridLib.iGEmptyStringAs.NotSet" /> which means that the property value is obtained from the style of the row or column.</value>
    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(iGEmptyStringAs.NotSet)]
    [Description("Determines how to interpret an empty string entered in the text box while editing the cell.")]
    [Category("Behavior")]
    public iGEmptyStringAs EmptyStringAs
    {
      get
      {
        iGCellStyle style = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return iGEmptyStringAs.NotSet;
        return style.EmptyStringAs;
      }
      set
      {
        this.AdjustStyle().EmptyStringAs = value;
      }
    }

    /// <summary>Gets or sets the object used as the custom cell editor.</summary>
    /// <value>An instance of the <see cref="T:TenTec.Windows.iGridLib.iGCellEditorBase" /> class used as the custom cell editor.</value>
    [Browsable(false)]
    public iGCellEditorBase CustomEditor
    {
      get
      {
        iGCellStyle style = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return (iGCellEditorBase) null;
        return style.CustomEditor;
      }
      set
      {
        this.AdjustStyle().CustomEditor = value;
      }
    }

    /// <summary>Gets or sets the maximum number of characters that can be entered into the cell.</summary>
    /// <value>The maximum number of characters that can be entered into a cell.</value>
    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(0)]
    [Description("Gets or sets the maximum number of characters the user can type or paste into the cell while editing.")]
    [Category("Behavior")]
    public int MaxInputLength
    {
      get
      {
        iGCellStyle style = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return 0;
        return style.MaxInputLength;
      }
      set
      {
        this.AdjustStyle().MaxInputLength = value;
      }
    }

    /// <summary>Indicates whether iGrid must reallocate the cell contents to draw them in the viewport area.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGCellFitContentsInViewport" /> enumeration value that specifies whether to reallocate the cell contents vertically and/or horizontally to draw it in the grid viewport. The default value is <see cref="F:TenTec.Windows.iGridLib.iGCellFitContentsInViewport.NotSet" /> meaning that this setting is obtained from the row or column style.</value>
    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(iGCellFitContentsInViewport.NotSet)]
    [Description("Determines whether iGrid forces drawing of cell contents in the viewport.")]
    [Category("Behavior")]
    public iGCellFitContentsInViewport FitContentsInViewport
    {
      get
      {
        iGCellStyle style = this.fGrid.GetCellData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return iGCellFitContentsInViewport.NotSet;
        return style.FitContentsInViewport;
      }
      set
      {
        this.AdjustStyle().FitContentsInViewport = value;
      }
    }
  }
}
