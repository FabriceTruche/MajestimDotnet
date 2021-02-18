// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGRow
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.ComponentModel;
using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents a row of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public sealed class iGRow
  {
    internal iGrid fGrid;
    internal int fIndex;
    private iGRowCellCollection fCells;

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

    internal iGRow(iGrid grid, int index)
    {
      grid.CheckRowIndex(index);
      this.fGrid = grid;
      this.fIndex = index;
    }

    /// <summary>Adjusts the height of the row to display the contents of all its cells entirely.</summary>
    public void AutoHeight()
    {
      this.fGrid.AutoHeightRow(this.fIndex);
    }

    /// <summary>Ensures that the row is visible, scrolling the grid as necessary.</summary>
    public void EnsureVisible()
    {
      this.fGrid.EnsureVisibleRow(this.fIndex);
    }

    /// <summary>Retrieves the string representation of the row.</summary>
    /// <returns>A string that represents the row.</returns>
    public override string ToString()
    {
      return string.Format("iGRow(RowIndex = {0})", (object) this.fIndex);
    }

    /// <summary>Moves the row to the specified position.</summary>
    /// <param name="rowBefore">The index of the row to place this row before.</param>
    public void Move(int rowBefore)
    {
      this.Move(rowBefore, 1);
    }

    /// <summary>Moves the specified rows to the specified position.</summary>
    /// <param name="rowBefore">The index of the row to place this row before.</param>
    /// <param name="count">The number of rows (starting from this row) to move.</param>
    public void Move(int rowBefore, int count)
    {
      this.fGrid.MoveRows(this.fIndex, count, rowBefore);
    }

    /// <summary>Gets the collection of the cell in the row.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGRowCellCollection" /> collection that represents the cells in the row.</value>
    [Browsable(false)]
    public iGRowCellCollection Cells
    {
      get
      {
        if (this.fCells == null)
          this.fCells = new iGRowCellCollection(this);
        return this.fCells;
      }
    }

    /// <summary>Gets the row text cell of the row. The row text cells are displayed in the group rows and under the normal cells in the normal rows.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGCell" /> object that represents the row text cell in this row.</value>
    [Browsable(false)]
    public iGCell RowTextCell
    {
      get
      {
        return new iGCell(this.fGrid, this.fIndex, 0);
      }
    }

    /// <summary>Gets or sets an object storing all the row's data.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGRowPattern" /> object that stores a copy of the row properties.</value>
    [Browsable(false)]
    public iGRowPattern Pattern
    {
      get
      {
        return new iGRowPattern(this.fGrid.GetRowData(this.fIndex));
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException();
        this.fGrid.SetRowData(this.fIndex, value.fRowData);
      }
    }

    /// <summary>Gets or sets the height of the row.</summary>
    /// <value>The height of the whole row. The default is 16.</value>
    [DefaultValue(17)]
    [Description("The height of the row. Ignored if DefaultRowHeightAutoSet is True.")]
    [Category("Layout")]
    public int Height
    {
      get
      {
        return this.fGrid.GetRowData(this.fIndex).Height;
      }
      set
      {
        this.fGrid.SetRowHeight(this.fIndex, value);
      }
    }

    /// <summary>Gets or sets a value indicating whether the row is visible.</summary>
    /// <value>True if the row is visible; otherwise, False. The default is True.</value>
    [DefaultValue(true)]
    [Description("Determines whether the row is visible.")]
    [Category("Behavior")]
    public bool Visible
    {
      get
      {
        return this.fGrid.GetRowData(this.fIndex).Visible;
      }
      set
      {
        this.fGrid.SetRowVisible(this.fIndex, value);
      }
    }

    /// <summary>Gets or sets the height of the cells above the row text cell.</summary>
    /// <value>The height of the cells above the row text cell. The default is 16.</value>
    [DefaultValue(17)]
    [Description("The height of the cells above the row text cell. Ignored if DefaultRowHeightAutoSet is True.")]
    [Category("Layout")]
    public int NormalCellHeight
    {
      get
      {
        return this.fGrid.GetRowData(this.fIndex).NormalCellHeight;
      }
      set
      {
        iGRowData rowData = this.fGrid.GetRowData(this.fIndex);
        rowData.NormalCellHeight = value;
        this.fGrid.SetRowDataNoVisibleHeightTypeSortableChange(this.fIndex, rowData);
      }
    }

    /// <summary>Gets or sets the type of the row.</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGRowType" /> enumeration values. The default is <see cref="F:TenTec.Windows.iGridLib.iGRowType.Normal" />.</value>
    [DefaultValue(iGRowType.Normal)]
    [Description("The type of the row.")]
    [Category("Behavior")]
    public iGRowType Type
    {
      get
      {
        return this.fGrid.GetRowData(this.fIndex).Type;
      }
      set
      {
        this.fGrid.SetRowType(this.fIndex, value);
      }
    }

    /// <summary>Gets or sets an object that contains data about the row.</summary>
    /// <value>An object that contains data about the row.</value>
    [Browsable(false)]
    public object Tag
    {
      get
      {
        return this.fGrid.GetRowData(this.fIndex).Tag;
      }
      set
      {
        iGRowData rowData = this.fGrid.GetRowData(this.fIndex);
        rowData.Tag = value;
        this.fGrid.SetRowDataNoVisibleHeightTypeSortableChange(this.fIndex, rowData);
      }
    }

    /// <summary>Gets the index of the row within the grid.</summary>
    /// <value>The zero-based index of the row within the grid's rows.</value>
    [Browsable(false)]
    public int Index
    {
      get
      {
        return this.fIndex;
      }
      set
      {
        if (value > this.fIndex)
          ++value;
        this.Move(value);
      }
    }

    /// <summary>Gets the Y-coordinate of the row. The coordinate is relative to the upper left corner of the grid.</summary>
    /// <value>The y-coordinate of the row. The coordinate is relative to the upper left corner of the grid.</value>
    [Browsable(false)]
    public int Y
    {
      get
      {
        return this.fGrid.RowToY(this.fIndex);
      }
    }

    /// <summary>Gets or sets the string key of the row.</summary>
    /// <value>A string that is associated with the row.</value>
    [DefaultValue(null)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGStringConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Description("The string key of the row.")]
    [Category("Behavior")]
    public string Key
    {
      get
      {
        return this.fGrid.GetRowData(this.fIndex).Key;
      }
      set
      {
        this.fGrid.SetRowKey(this.fIndex, value, true);
      }
    }

    /// <summary>Gets or sets a value indicating whether the row is expanded or collapsed.</summary>
    /// <value>True if the row is expanded; otherwise, False.</value>
    [DefaultValue(true)]
    [Description("Determines whether the row is expanded or collapsed.")]
    [Category("Behavior")]
    public bool Expanded
    {
      get
      {
        return this.fGrid.GetRowData(this.fIndex).Expanded;
      }
      set
      {
        iGRowData rowData = this.fGrid.GetRowData(this.fIndex);
        if (value == rowData.Expanded)
          return;
        this.fGrid.ExpandCollapseRow(this.fIndex, rowData, value);
      }
    }

    /// <summary>Gets or sets the horizontal indent of the first cell in the row. Helps to create a treelike grid.</summary>
    /// <value>The zero-based hierarchical level of the row. The default is zero.</value>
    [DefaultValue(0)]
    [Description("The horizontal indent of the first cell in the row. Helps to create a treelike grid.")]
    [Category("Behavior")]
    public int Level
    {
      get
      {
        return this.fGrid.GetRowData(this.fIndex).Level;
      }
      set
      {
        this.fGrid.SetRowLevel(this.fIndex, value);
      }
    }

    /// <summary>Gets or sets a value indicating whether the row is visible when one of its parent group rows or tree nodes is collapsed or expanded. The default value is True.</summary>
    /// <value>True if the row belongs to a group or tree node that is expanded; otherwise, False.</value>
    [Browsable(false)]
    [Category("Behavior")]
    public bool VisibleParentExpanded
    {
      get
      {
        return this.fGrid.GetRowData(this.fIndex).VisibleParentExpanded;
      }
      set
      {
        this.fGrid.SetRowVisibleParentExpanded(this.fIndex, value);
      }
    }

    /// <summary>Gets or sets a value indicating whether the row can change its position while sorting.</summary>
    /// <value>True if the row is sortable; otherwise, False. The default is True.</value>
    [DefaultValue(true)]
    [Description("Determines whether the row can change its position while sorting.")]
    [Category("Behavior")]
    public bool Sortable
    {
      get
      {
        return this.fGrid.GetRowData(this.fIndex).Sortable;
      }
      set
      {
        this.fGrid.SetRowSortable(this.fIndex, value);
      }
    }

    /// <summary>Gets or sets the state of the row's tree button.</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGTreeButtonState" /> enumeration values. The default is <see cref="F:TenTec.Windows.iGridLib.iGTreeButtonState.Absent" />.</value>
    [DefaultValue(iGTreeButtonState.Absent)]
    [Description("The state of the row's tree button.")]
    [Category("Behavior")]
    public iGTreeButtonState TreeButton
    {
      get
      {
        return this.fGrid.GetRowData(this.fIndex).TreeButton;
      }
      set
      {
        this.fGrid.SetRowTreeButton(this.fIndex, value);
      }
    }

    /// <summary>Gets a value indicating which glyph is currently displayed in the row.</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGRowHdrGlyph" /> enumeration values.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public iGRowHdrGlyph HdrGlyph
    {
      get
      {
        return this.fGrid.GetRowHdrGlyph(this.fIndex);
      }
    }

    /// <summary>Gets or sets a value indicating whether the row can be selected.</summary>
    /// <value>True if the row can be selected; otherwise, False.</value>
    [DefaultValue(true)]
    [Description("Indicates whether the specified row can be selected.")]
    [Category("Behavior")]
    public bool Selectable
    {
      get
      {
        return this.fGrid.GetRowData(this.fIndex).Selectable;
      }
      set
      {
        this.fGrid.SetRowSelectable(this.fIndex, value);
      }
    }

    /// <summary>Gets or sets a value indicating whether the row is selected.</summary>
    /// <value>True if the row is selected; otherwise, False.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool Selected
    {
      get
      {
        return this.fGrid.GetRowSelected(this.fIndex);
      }
      set
      {
        this.fGrid.SetRowSelected(this.fIndex, value);
      }
    }

    /// <summary>Gets the bounds of the row's header. The coordinates are relative to the upper left corner of the grid.</summary>
    /// <value>A <see cref="T:System.Drawing.Rectangle" /> that represents the size and location of the row's header. The coordinates are relative to the upper left corner of the grid.</value>
    [Browsable(false)]
    public Rectangle HdrBounds
    {
      get
      {
        return this.fGrid.GetRowHdrBounds(this.fIndex);
      }
    }

    /// <summary>Gets the parent row object.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGRow" /> object that refers to the parent row.</value>
    [Browsable(false)]
    public iGRow Parent
    {
      get
      {
        return this.fGrid.GetParentRow(this.fIndex);
      }
    }

    /// <summary>Gets or sets a style object determining the appearance and behavior of the row's cells.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGCellStyle" /> object that determines the view and behavior of the cells in the row.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGCellStyleConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Description("A style object determining the appearance and behavior of the row's cells.")]
    [Category("Appearance and Behavior")]
    public iGCellStyle CellStyle
    {
      get
      {
        iGCellStyle iGcellStyle = this.fGrid.GetRowData(this.fIndex).CellStyle;
        if (iGcellStyle == null && this.fGrid.fCreateRowCellStyleDynamically)
        {
          iGcellStyle = new iGCellStyle();
          this.fGrid.SetRowCellStyle(this.fIndex, iGcellStyle);
        }
        return iGcellStyle;
      }
      set
      {
        this.fGrid.SetRowCellStyle(this.fIndex, value);
      }
    }
  }
}
