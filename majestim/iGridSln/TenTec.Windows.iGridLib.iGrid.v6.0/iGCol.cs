// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCol
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing.Design;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents a column of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  [DesignerSerializer("TenTec.Windows.iGridLib.Design.iGColSerializer, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design")]
  public sealed class iGCol : IiGImageListProvider
  {
    internal iGrid fGrid;
    internal int fIndex;
    private iGColCellCollection fCells;

    /// <summary>Returns the <see cref="T:TenTec.Windows.iGridLib.iGrid" /> object this instance belongs to.</summary>
    /// <value>Returns the <see cref="T:TenTec.Windows.iGridLib.iGrid" /> object this instance belongs to.</value>
    [Browsable(false)]
    public iGrid Grid
    {
      get
      {
        return this.fGrid;
      }
    }

    internal iGCol(iGrid grid, int index)
    {
      grid.CheckColIndex(index);
      this.fIndex = index;
      this.fGrid = grid;
    }

    /// <summary>Resizes the column to display the contents of all its cells and headers entirely.</summary>
    public void AutoWidth()
    {
      this.fGrid.AutoWidthCol(this.fIndex, false, 0, this.fGrid.fRowCount, true);
    }

    /// <summary>Resizes the column to display the contents of all its cells entirely. You can optionally prohibit to decrease the column's width.</summary>
    /// <param name="allowDecrease">Specifies whether the width of the column can be decreased.</param>
    public void AutoWidth(bool allowDecrease)
    {
      this.fGrid.AutoWidthCol(this.fIndex, false, 0, this.fGrid.fRowCount, allowDecrease);
    }

    /// <summary>Resizes the column to display the contents of all its cells in the specified rows entirely. You can optionally prohibit to decrease the column's width.</summary>
    /// <param name="rowIndex">The starting index of the rows to adjust the column's width by.</param>
    /// <param name="rowCount">The number of the rows to adjust the column's width by.</param>
    /// <param name="allowDecrease">Specifies whether the width of the columns can be decreased.</param>
    public void AutoWidth(int rowIndex, int rowCount, bool allowDecrease)
    {
      this.fGrid.AutoWidthCol(this.fIndex, true, rowIndex, rowCount, allowDecrease);
    }

    /// <summary>Sorts the rows as if the user clicked over the column's header and the specified modifier keys were pressed.</summary>
    /// <param name="keyModifiers">The modifier keys that are pressed.</param>
    /// <param name="sortOrder">The <see cref="F:TenTec.Windows.iGridLib.iGSortOrder.None" /> value to emulate clicking the column's header, or the new sort order of the column.</param>
    public void DoDefaultSort(Keys keyModifiers, iGSortOrder sortOrder)
    {
      this.fGrid.DoDefaultSortInternal(this.fGrid.GetColOrder(this.fIndex), 1, keyModifiers, sortOrder, true);
    }

    /// <summary>Returns a Boolean value indicating whether row text is displayed in the column.</summary>
    /// <returns>A Boolean value indicating whether row text is displayed in the column.</returns>
    public bool ContainsRowText()
    {
      return this.fGrid.ColContainsRowText(this.fIndex);
    }

    /// <summary>Retrieves a value indicating whether the specified range of columns can change their order taking into account non-moveable columns and the header configuration.</summary>
    /// <param name="count">The number of the columns to move.</param>
    /// <returns>True if the column can be moved; otherwise, false.</returns>
    public bool CanMove(int count)
    {
      int dstStartOrder;
      int dstEndOrder;
      bool[] rowsMap;
      string reasonCantMove;
      return this.fGrid.CanMoveCols(this.fGrid.GetColOrder(this.fIndex), count, out dstStartOrder, out dstEndOrder, out rowsMap, out reasonCantMove);
    }

    /// <summary>Retrieves a value indicating whether the specified range of columns can change their order taking into account non-moveable columns and the header configuration; also determines the range of all the available new column positions and the array used by the <see cref="M:TenTec.Windows.iGridLib.iGCol.CanPlaceTo(System.Int32,System.Boolean[])" /> method.</summary>
    /// <param name="count">The number of the columns to move.</param>
    /// <param name="dstStartOrder">If the specified columns can be moved, indicates their leftmost (rightmost in right-to-left mode) possible display position.</param>
    /// <param name="dstEndOrder">If the specified columns can be moved, indicates their rightmost (leftmost in right-to-left mode) possible display position.</param>
    /// <param name="rowsMap">Intended to be used by the <see cref="M:TenTec.Windows.iGridLib.iGCol.CanPlaceTo(System.Int32,System.Int32,System.Boolean[])" /> method. Indicates which of the header rows should be checked by the <see cref="M:TenTec.Windows.iGridLib.iGCol.CanPlaceTo(System.Int32,System.Int32,System.Boolean[])" /> method. The subject of the check is whether the header cells can be separated by other columns.</param>
    /// <returns>True if the column can be moved; otherwise, false.</returns>
    public bool CanMove(int count, out int dstStartOrder, out int dstEndOrder, out bool[] rowsMap)
    {
      string reasonCantMove;
      int num = this.fGrid.CanMoveCols(this.fGrid.GetColOrder(this.fIndex), count, out dstStartOrder, out dstEndOrder, out rowsMap, out reasonCantMove) ? 1 : 0;
      if (num == 0)
        return num != 0;
      dstStartOrder = dstStartOrder - 1;
      dstEndOrder = dstEndOrder - 1;
      return num != 0;
    }

    /// <summary>Retrieves a value indicating whether the column can change its order taking into account non-moveable columns and the header configuration.</summary>
    /// <returns>True if the column can be moved; otherwise, false.</returns>
    public bool CanMove()
    {
      int dstStartOrder;
      int dstEndOrder;
      bool[] rowsMap;
      string reasonCantMove;
      return this.fGrid.CanMoveCols(this.fGrid.GetColOrder(this.fIndex), 1, out dstStartOrder, out dstEndOrder, out rowsMap, out reasonCantMove);
    }

    /// <summary>Retrieves a value indicating whether the column can change its order taking into account non-moveable columns and the header configuration; also determines the range of all the available new column positions and the array used by the <see cref="M:TenTec.Windows.iGridLib.iGCol.CanPlaceTo(System.Int32,System.Boolean[])" /> method.</summary>
    /// <param name="dstStartOrder">If the column can be moved, indicates its leftmost (rightmost in the right-to-left mode) possible display position.</param>
    /// <param name="dstEndOrder">If the column can be moved, indicates its rightmost (leftmost in right-to-left mode) possible display position.</param>
    /// <param name="rowsMap">Intended to be used by the <see cref="M:TenTec.Windows.iGridLib.iGCol.CanPlaceTo(System.Int32,System.Boolean[])" /> method. Indicates which of the header rows should be checked by the <see cref="M:TenTec.Windows.iGridLib.iGCol.CanPlaceTo(System.Int32,System.Boolean[])" /> method. The subject of the check is whether the header cells can be separated by other columns.</param>
    /// <returns>True if the column can be moved; otherwise, false.</returns>
    public bool CanMove(out int dstStartOrder, out int dstEndOrder, out bool[] rowsMap)
    {
      string reasonCantMove;
      int num = this.fGrid.CanMoveCols(this.fGrid.GetColOrder(this.fIndex), 1, out dstStartOrder, out dstEndOrder, out rowsMap, out reasonCantMove) ? 1 : 0;
      if (num == 0)
        return num != 0;
      dstStartOrder = dstStartOrder - 1;
      dstEndOrder = dstEndOrder - 1;
      return num != 0;
    }

    /// <summary>Retrieves a value indicating whether the specified range of the columns can be moved to the specified position taking into account non-moveable columns, the header configuration, and frozen columns.</summary>
    /// <param name="dstOrder">Specifies the destination display position of the specified columns.</param>
    /// <param name="count">The number of the columns to be moved.</param>
    /// <returns>True if the column can be moved to the specified position; otherwise, false.</returns>
    public bool CanPlaceTo(int dstOrder, int count)
    {
      ++dstOrder;
      int dstStartOrder;
      int dstEndOrder;
      bool[] rowsMap;
      string reasonCantMove;
      if (!this.fGrid.CanMoveCols(this.fGrid.GetColOrder(this.fIndex), count, out dstStartOrder, out dstEndOrder, out rowsMap, out reasonCantMove) || dstOrder < dstStartOrder || dstOrder > dstEndOrder)
        return false;
      string reasonCantPlace;
      return this.fGrid.CanPlaceColsTo(this.fGrid.GetColOrder(this.fIndex), dstOrder, count, rowsMap, out reasonCantPlace);
    }

    /// <summary>Retrieves a value indicating whether the specified range of the columns can be moved to the specified position taking into account non-moveable columns, the header configuration, and frozen columns.</summary>
    /// <param name="dstOrder">Specifies the destination display position of the specified columns.</param>
    /// <param name="count">The number of the columns to be moved.</param>
    /// <param name="rowsMap">This parameter should be obtained from the <see cref="M:TenTec.Windows.iGridLib.iGCol.CanMove(System.Int32,System.Int32@,System.Int32@,System.Boolean[]@)" /> method. Indicates which of the header rows should be checked on the subject of whether the header cells can be separated by other columns.</param>
    /// <returns>True if the column can be moved to the specified position; otherwise, false.</returns>
    public bool CanPlaceTo(int dstOrder, int count, bool[] rowsMap)
    {
      ++dstOrder;
      string reasonCantPlace;
      return this.fGrid.CanPlaceColsTo(this.fGrid.GetColOrder(this.fIndex), dstOrder, count, rowsMap, out reasonCantPlace);
    }

    /// <summary>Retrieves a value indicating whether the column can be moved to the specified position taking into account non-moveable columns, the header configuration, and frozen columns.</summary>
    /// <param name="dstOrder">Specifies the destination display position of the column.</param>
    /// <returns>True if the column can be moved to the specified position; otherwise, false.</returns>
    public bool CanPlaceTo(int dstOrder)
    {
      ++dstOrder;
      int dstStartOrder;
      int dstEndOrder;
      bool[] rowsMap;
      string reasonCantMove;
      if (!this.fGrid.CanMoveCols(this.fGrid.GetColOrder(this.fIndex), 1, out dstStartOrder, out dstEndOrder, out rowsMap, out reasonCantMove) || dstOrder < dstStartOrder || dstOrder > dstEndOrder)
        return false;
      string reasonCantPlace;
      return this.fGrid.CanPlaceColsTo(this.fGrid.GetColOrder(this.fIndex), dstOrder, 1, rowsMap, out reasonCantPlace);
    }

    /// <summary>Retrieves a value indicating whether the column can be moved to the specified position taking into account non-moveable columns, the header configuration, and frozen columns.</summary>
    /// <param name="dstOrder">Specifies the destination display position of the column.</param>
    /// <param name="rowsMap">This parameter should be obtained from the <see cref="M:TenTec.Windows.iGridLib.iGCol.CanMove(System.Int32@,System.Int32@,System.Boolean[]@)" /> method. Indicates which of the header rows should be checked on the subject of whether the header cells can be separated by other columns.</param>
    /// <returns>True if the column can be moved to the specified position; otherwise, false.</returns>
    public bool CanPlaceTo(int dstOrder, bool[] rowsMap)
    {
      ++dstOrder;
      string reasonCantPlace;
      return this.fGrid.CanPlaceColsTo(this.fGrid.GetColOrder(this.fIndex), dstOrder, 1, rowsMap, out reasonCantPlace);
    }

    /// <summary>Ensures that the column is visible, scrolling the grid as necessary.</summary>
    public void EnsureVisible()
    {
      this.fGrid.EnsureVisibleCol(this.fIndex);
    }

    /// <summary>Moves the column to the specified position.</summary>
    /// <param name="dstOrder">The new display position of the column.</param>
    public void Move(int dstOrder)
    {
      ++dstOrder;
      this.fGrid.MoveCols(this.fGrid.GetColOrder(this.fIndex), dstOrder, 1);
    }

    /// <summary>Moves the specified range of the columns to the specified position.</summary>
    /// <param name="dstOrder">The new display position of the specified columns.</param>
    /// <param name="count">The number of the columns to move.</param>
    public void Move(int dstOrder, int count)
    {
      ++dstOrder;
      this.fGrid.MoveCols(this.fGrid.GetColOrder(this.fIndex), dstOrder, count);
    }

    /// <summary>Retrieves the string representation of the column.</summary>
    /// <returns>A string that represents the column.</returns>
    public override string ToString()
    {
      return string.Format("iGCol(ColIndex = {0})", (object) (this.fIndex - 1));
    }

    ImageList IiGImageListProvider.GetImageList(string propertyName)
    {
      if (propertyName == "DefaultCellImageIndex")
        return this.fGrid.ImageList;
      return this.fGrid.Header.ImageList;
    }

    private bool ShouldSerializeCellStyle()
    {
      return iGInternalInfrastructure.iGSerializeManager.ShouldSerialize((object) this.CellStyle);
    }

    private void ResetCellStyle()
    {
      DesignerTransaction transaction = (DesignerTransaction) null;
      if (this.fGrid != null)
        transaction = this.fGrid.BeforeChangePropWithStyle("RowTextCol.CellStyle", "RowTextCol");
      try
      {
        this.CellStyle = new iGCellStyle(true);
      }
      finally
      {
        if (this.fGrid != null)
          this.fGrid.AfterChangePropWithStyle("RowTextCol", transaction);
      }
    }

    /// <summary>Gets the collection of the cells of the column.</summary>
    /// <value>The <see cref="T:TenTec.Windows.iGridLib.iGColCellCollection" /> object that represents the cells of the column.</value>
    [Browsable(false)]
    public iGColCellCollection Cells
    {
      get
      {
        if (this.fCells == null)
          this.fCells = new iGColCellCollection(this);
        return this.fCells;
      }
    }

    /// <summary>Gets or sets the width of the column.</summary>
    /// <value>A value that determines the width of the column.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(64)]
    [Description("The width of the column.")]
    [Category("Layout")]
    public int Width
    {
      get
      {
        return this.fGrid.GetColData(this.fIndex).Width;
      }
      set
      {
        this.fGrid.SetColWidth(this.fIndex, value);
      }
    }

    /// <summary>Gets or sets a value indicating whether the column is visible.</summary>
    /// <value>True if the column is visible; otherwise, False.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(true)]
    [Description("Determines whether the column is visible.")]
    [Category("Behavior")]
    public bool Visible
    {
      get
      {
        return this.fGrid.GetColData(this.fIndex).Visible;
      }
      set
      {
        iGColData colData = this.fGrid.GetColData(this.fIndex);
        colData.Visible = value;
        this.fGrid.SetColData(this.fIndex, colData);
      }
    }

    /// <summary>Gets or sets an object that contains data about the column.</summary>
    /// <value>An object that contains data about the column.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public object Tag
    {
      get
      {
        return this.fGrid.GetColData(this.fIndex).Tag;
      }
      set
      {
        iGColData colData = this.fGrid.GetColData(this.fIndex);
        colData.Tag = value;
        this.fGrid.SetColDataNoWidthNoIsRowTextNoAllowSizingChange(this.fIndex, colData);
      }
    }

    /// <summary>Gets or sets a value indicating whether the cells of the column can be selected.</summary>
    /// <value>True if the column's cells can be selected; otherwise, False.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(true)]
    [Description("Determines whether the cells of the column can be selected.")]
    [Category("Behavior")]
    public bool IncludeInSelect
    {
      get
      {
        return this.fGrid.GetColData(this.fIndex).IncludeInSelect;
      }
      set
      {
        iGColData colData = this.fGrid.GetColData(this.fIndex);
        colData.IncludeInSelect = value;
        this.fGrid.SetColDataNoWidthNoIsRowTextNoAllowSizingChange(this.fIndex, colData);
      }
    }

    /// <summary>Gets or sets the minimal width of the column.</summary>
    /// <value>A value that indicated the minimal width of the column. The default is -1 that means that the minimal width is not limited.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(-1)]
    [Description("The minimal width of the column.")]
    [Category("Layout")]
    public int MinWidth
    {
      get
      {
        return this.fGrid.GetColData(this.fIndex).MinWidth;
      }
      set
      {
        iGColData colData = this.fGrid.GetColData(this.fIndex);
        iGrid.CheckColWidthMinMaxValues(value, colData.MaxWidth);
        colData.MinWidth = value;
        if (iGrid.AdjustColWidthAfterMinMaxWidthChange(ref colData.Width, colData.MinWidth, colData.MaxWidth))
          this.fGrid.SetColData(this.fIndex, colData);
        else
          this.fGrid.SetColDataNoWidthNoIsRowTextNoAllowSizingChange(this.fIndex, colData);
      }
    }

    /// <summary>Gets or sets the maximal width of the column.</summary>
    /// <value>A value that indicated the maximal width of the column. The default is -1 that means that the maximal width is not limited.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(-1)]
    [Description("The maximal width of the column.")]
    [Category("Layout")]
    public int MaxWidth
    {
      get
      {
        return this.fGrid.GetColData(this.fIndex).MaxWidth;
      }
      set
      {
        iGColData colData = this.fGrid.GetColData(this.fIndex);
        iGrid.CheckColWidthMinMaxValues(colData.MinWidth, value);
        colData.MaxWidth = value;
        if (iGrid.AdjustColWidthAfterMinMaxWidthChange(ref colData.Width, colData.MinWidth, colData.MaxWidth))
          this.fGrid.SetColData(this.fIndex, colData);
        else
          this.fGrid.SetColDataNoWidthNoIsRowTextNoAllowSizingChange(this.fIndex, colData);
      }
    }

    /// <summary>Gets or sets a value indicating whether the column can be resized through visual interface.</summary>
    /// <value>True if the column can be resized; otherwise, False.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(true)]
    [Description("Determines whether the column can be resized thru visual interface.")]
    [Category("Behavior")]
    public bool AllowSizing
    {
      get
      {
        return this.fGrid.GetColData(this.fIndex).AllowSizing;
      }
      set
      {
        this.fGrid.SetColAllowSizing(this.fIndex, value);
      }
    }

    /// <summary>Gets or sets a value indicating whether the display position of the column can be changed.</summary>
    /// <value>True if the column can be moved; otherwise, False.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(true)]
    [Description("Determines whether the order of the column can be changed.")]
    [Category("Behavior")]
    public bool AllowMoving
    {
      get
      {
        return this.fGrid.GetColData(this.fIndex).AllowMoving;
      }
      set
      {
        iGColData colData = this.fGrid.GetColData(this.fIndex);
        colData.AllowMoving = value;
        this.fGrid.SetColDataNoWidthNoIsRowTextNoAllowSizingChange(this.fIndex, colData);
      }
    }

    /// <summary>Gets or sets a value indicating whether the rows can be grouped by this column.</summary>
    /// <value>True if the column can be grouped; otherwise, False.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(true)]
    [Description("Determines whether the rows can be grouped by this column.")]
    [Category("Behavior")]
    public bool AllowGrouping
    {
      get
      {
        return this.fGrid.GetColData(this.fIndex).AllowGrouping;
      }
      set
      {
        iGColData colData = this.fGrid.GetColData(this.fIndex);
        colData.AllowGrouping = value;
        this.fGrid.SetColDataNoWidthNoIsRowTextNoAllowSizingChange(this.fIndex, colData);
      }
    }

    /// <summary>Gets or sets the default sort type of the column.</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGSortType" /> values. If <see cref="F:TenTec.Windows.iGridLib.iGSortType.None" /> is specified, the column cannot be sorted and grouped through visual interface.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(iGSortType.ByValue)]
    [Description("The default sort type of the column.")]
    [Category("Behavior")]
    public iGSortType SortType
    {
      get
      {
        return this.fGrid.GetColData(this.fIndex).SortType;
      }
      set
      {
        iGColData colData = this.fGrid.GetColData(this.fIndex);
        colData.SortType = value;
        this.fGrid.SetColDataNoWidthNoIsRowTextNoAllowSizingChange(this.fIndex, colData);
      }
    }

    /// <summary>Gets or sets the default sort order of the column.</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGSortOrder" /> values. If <see cref="F:TenTec.Windows.iGridLib.iGSortOrder.None" /> is specified, the column cannot be sorted and grouped through visual interface.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(iGSortOrder.Ascending)]
    [Description("The default sort order of the column.")]
    [Category("Behavior")]
    public iGSortOrder SortOrder
    {
      get
      {
        return this.fGrid.GetColData(this.fIndex).SortOrder;
      }
      set
      {
        iGColData colData = this.fGrid.GetColData(this.fIndex);
        colData.SortOrder = value;
        this.fGrid.SetColDataNoWidthNoIsRowTextNoAllowSizingChange(this.fIndex, colData);
      }
    }

    /// <summary>Gets or sets a value determining whether to apply custom grouping to the column.</summary>
    /// <value>True if the column should be grouped using a custom criterion; otherwise, False.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(false)]
    [Description("Determines whether to apply custom grouping to the column.")]
    [Category("Behavior")]
    public bool CustomGrouping
    {
      get
      {
        return this.fGrid.GetColData(this.fIndex).CustomGrouping;
      }
      set
      {
        iGColData colData = this.fGrid.GetColData(this.fIndex);
        colData.CustomGrouping = value;
        this.fGrid.SetColDataNoWidthNoIsRowTextNoAllowSizingChange(this.fIndex, colData);
      }
    }

    /// <summary>Gets or sets an object storing all the column's data.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGColPattern" /> object that stores a copy of the column properties.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public iGColPattern Pattern
    {
      get
      {
        return new iGColPattern(this.fGrid.GetColData(this.fIndex), this.fGrid.GetColHdrData(0, this.fIndex), this.fGrid.GetDefaultCell(this.fIndex));
      }
      set
      {
        this.fGrid.SetColData(this.fIndex, value.ColData);
        this.fGrid.SetColHdrData(0, this.fIndex, value.ColHdr);
        this.fGrid.SetDefaultCell(this.fIndex, value.DefaultCell);
      }
    }

    /// <summary>Gets or sets the display position of the column.</summary>
    /// <value>A value that specifies the display position of the column.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int Order
    {
      get
      {
        return this.fGrid.GetColOrder(this.fIndex) - 1;
      }
      set
      {
        this.fGrid.MoveCols(this.fGrid.GetColOrder(this.fIndex), value + 1, 1);
      }
    }

    /// <summary>Gets or sets the value that will have the new cells of the column.</summary>
    /// <value>The object that will be assigned to the new cells' value.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(null)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGStringConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Description("The value that will have the new cells of the column.")]
    [Category("Data")]
    public object DefaultCellValue
    {
      get
      {
        return this.fGrid.GetDefaultCell(this.fIndex).Value;
      }
      set
      {
        this.fGrid.SetDefaultCellValue(this.fIndex, value);
      }
    }

    /// <summary>Gets or sets the value that will be set to the <see cref="P:TenTec.Windows.iGridLib.iGCell.AuxValue" /> property of the new cells of the column.</summary>
    /// <value>The object that will be assigned to the <see cref="P:TenTec.Windows.iGridLib.iGCell.AuxValue" /> property of the new cells.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public object DefaultCellAuxValue
    {
      get
      {
        return this.fGrid.GetDefaultCell(this.fIndex).AuxValue;
      }
      set
      {
        this.fGrid.SetDefaultCellAuxValue(this.fIndex, value);
      }
    }

    /// <summary>Gets or sets the image index that will have the new cells of the column.</summary>
    /// <value>A zero-based index which represents the image position in an <see cref="T:System.Windows.Forms.ImageList" />. The default is -1 which means that the cells has no image.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(-1)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGImageIndexConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Editor("TenTec.Windows.iGridLib.Design.iGImageIndexEditor, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0", typeof (UITypeEditor))]
    [Description("The image index that will have the new cells of the column.")]
    public int DefaultCellImageIndex
    {
      get
      {
        return this.fGrid.GetDefaultCell(this.fIndex).ImageIndex;
      }
      set
      {
        this.fGrid.SetDefaultCellImageIndex(this.fIndex, value);
      }
    }

    /// <summary>Gets or sets a style object determining the appearance and behavior of the column's cells.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGCellStyle" /> object that determines the view and behavior of the cells in the column.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGColCellStyleConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Description("A style object determining the appearance and behavior of the column's cells.")]
    [Category("Appearance and Behavior")]
    public iGCellStyle CellStyle
    {
      get
      {
        return this.fGrid.GetColData(this.fIndex).CellStyle;
      }
      set
      {
        this.fGrid.SetColCellStyle(this.fIndex, value);
      }
    }

    /// <summary>Gets the zero-based index of the column within the grid or -1 if the column is a row text column.</summary>
    /// <value>The zero-based index of the column within the grid or -1 if the column is a row text column.</value>
    [Browsable(false)]
    public int Index
    {
      get
      {
        return this.fIndex - 1;
      }
    }

    /// <summary>Gets the X-coordinate of the column. The coordinate is relative to the upper left corner of the grid.</summary>
    /// <value>The X-coordinate of the column. The coordinate is relative to the upper left corner of the grid.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int X
    {
      get
      {
        bool isFirstVisibleCol;
        return this.fGrid.ColToX(this.fGrid.GetColOrder(this.fIndex), false, out isFirstVisibleCol);
      }
    }

    /// <summary>Gets or sets the text displayed in the column's header.</summary>
    /// <value>An instance of a class. The default value is null (Nothing in VB).</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(null)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGStringConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Description("The text displayed in the column's header.")]
    [Category("Appearance")]
    public object Text
    {
      get
      {
        return this.fGrid.GetColHdrData(0, this.fIndex).Value;
      }
      set
      {
        this.fGrid.SetColHdrValue(0, this.fIndex, value);
      }
    }

    /// <summary>Gets or sets the index of the image displayed in the column's header.</summary>
    /// <value>A zero-based index which represents the image position in an <see cref="T:System.Windows.Forms.ImageList" />. The default is -1 which means that the column's header has no image.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(-1)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGImageIndexConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Editor("TenTec.Windows.iGridLib.Design.iGImageIndexEditor, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0", typeof (UITypeEditor))]
    [Description("The index of the image displayed in the column's header.")]
    [Category("Appearance")]
    public int ImageIndex
    {
      get
      {
        return this.fGrid.GetColHdrData(0, this.fIndex).ImageIndex;
      }
      set
      {
        this.fGrid.SetColHdrImageIndex(0, this.fIndex, value);
      }
    }

    /// <summary>Gets or sets a style object determining the appearance and behavior of the column's header.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGColHdrStyle" /> object that determines view and behavior of the column's headers.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGColColHdrStyleConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Description("A style object determining the appearance and behavior of the column's header.")]
    [Category("Appearance and Behavior")]
    public iGColHdrStyle ColHdrStyle
    {
      get
      {
        return this.fGrid.GetColData(this.fIndex).ColHdrStyle;
      }
      set
      {
        this.fGrid.SetColColHdrStyle(this.fIndex, value);
      }
    }

    /// <summary>Gets or sets the string key of the column.</summary>
    /// <value>The string that is the key of the column or null (Nothing in VB) if the column does not have a key.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGStringConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [DefaultValue(null)]
    [Description("The string key of the column.")]
    [Category("Behavior")]
    public string Key
    {
      get
      {
        return this.fGrid.GetColData(this.fIndex).Key;
      }
      set
      {
        this.fGrid.SetColKey(this.fIndex, value, true);
      }
    }

    /// <summary>Gets or sets a boolean value that indicates whether the column will be visible when iGrid is grouped by this column.</summary>
    /// <value>Gets or sets a boolean value that indicates whether the column will be visible when iGrid is grouped by this column. The default value is False.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(false)]
    [Description("Determines whether to show the column when it is grouped.")]
    [Category("Behavior")]
    public bool ShowWhenGrouped
    {
      get
      {
        return this.fGrid.GetColData(this.fIndex).ShowWhenGrouped;
      }
      set
      {
        iGColData colData = this.fGrid.GetColData(this.fIndex);
        colData.ShowWhenGrouped = value;
        this.fGrid.SetColData(this.fIndex, colData);
      }
    }

    /// <summary>Gets a value indicating whether this is the row text column (the row text column used to display the cells under the normal cells and to display the group rows).</summary>
    /// <value>True if this is the row text column; otherwise, False.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsRowText
    {
      get
      {
        return this.fIndex == 0;
      }
    }

    /// <summary>Gets the zero-based index of the column within the sort object (the sorting criteria) or -1 if it is not sorted.</summary>
    /// <value>The zero-based index of the column within the sort object (the sorting criteria) or -1 if it is not sorted.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int SortIndex
    {
      get
      {
        return this.fGrid.SortObject.GetSortIndexOfColumn(this.fIndex);
      }
    }

    /// <summary>Gets the zero-based index of the column within the group object or -1 if it is not grouped.</summary>
    /// <value>The zero-based index of the column within the group object or -1 if it is not grouped.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int GroupIndex
    {
      get
      {
        return this.fGrid.GroupObject.GetSortIndexOfColumn(this.fIndex);
      }
    }
  }
}
