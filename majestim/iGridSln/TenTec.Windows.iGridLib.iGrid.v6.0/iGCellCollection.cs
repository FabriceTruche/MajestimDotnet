// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCellCollection
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents the collection of the cells in an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGCellCollection : IiGEnumerableCollection, IEnumerable
  {
    internal iGrid fGrid;
    private iGCell fLatterCell;

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

    internal iGCellCollection(iGrid grid)
    {
      this.fGrid = grid;
    }

    /// <summary>Retrieves the cell that is located at the specified coordinates. The coordinates are relative to the upper left corner of the grid.</summary>
    /// <param name="x">The X-coordinate of the point for which to retrieve the cell.</param>
    /// <param name="y">The Y-coordinate of the point for which to retrieve the cell.</param>
    /// <returns>The cell at the specified point in the grid coordinates, or null (Nothing in VB) if there is no cell.</returns>
    public iGCell FromPoint(int x, int y)
    {
      int rowIndex;
      int colIndex;
      Rectangle bounds;
      if (!this.fGrid.GetCellFromPoint(x, y, false, out rowIndex, out colIndex, out bounds))
        return (iGCell) null;
      this.fLatterCell = new iGCell(this.fGrid, rowIndex, colIndex);
      return this.fLatterCell;
    }

    /// <summary>Retrieves the cell that is located at the specified coordinates and its bounds. The coordinates are relative to the upper left corner of the grid.</summary>
    /// <param name="x">The X-coordinate of the point for which to retrieve the cell.</param>
    /// <param name="y">The Y-coordinate of the point for which to retrieve the cell.</param>
    /// <param name="bounds">The bounds of the retrieved cell.</param>
    /// <returns>The cell at the specified point in the grid coordinates, or null (Nothing in VB) if there is no cell.</returns>
    public iGCell FromPoint(int x, int y, out Rectangle bounds)
    {
      int rowIndex;
      int colIndex;
      if (!this.fGrid.GetCellFromPoint(x, y, false, out rowIndex, out colIndex, out bounds))
        return (iGCell) null;
      this.fLatterCell = new iGCell(this.fGrid, rowIndex, colIndex);
      return this.fLatterCell;
    }

    /// <summary>Retrieves the cell that is located at the specified coordinates and its bounds; optionally you can take into account the level indent. The coordinates are relative to the upper left corner of the grid.</summary>
    /// <param name="x">The X-coordinate of the point for which to retrieve the cell.</param>
    /// <param name="y">The Y-coordinate of the point for which to retrieve the cell.</param>
    /// <param name="includeLevel">A boolean value that indicates whether to take into account the level indent.</param>
    /// <param name="bounds">The bounds of the retrieved cell.</param>
    /// <returns>The cell at the specified point in the grid coordinates, or null (Nothing in VB) if there is no cell.</returns>
    public iGCell FromPoint(int x, int y, bool includeLevel, out Rectangle bounds)
    {
      int rowIndex;
      int colIndex;
      if (!this.fGrid.GetCellFromPoint(x, y, includeLevel, out rowIndex, out colIndex, out bounds))
        return (iGCell) null;
      this.fLatterCell = new iGCell(this.fGrid, rowIndex, colIndex);
      return this.fLatterCell;
    }

    /// <summary>Gets the cell with the specified row and column indices.</summary>
    /// <param name="rowIndex">The row index of the cell to retrieve.</param>
    /// <param name="colIndex">The column index of the cell to retrieve or -1 to get a row text cell.</param>
    /// <value>The cell with the specified row and column indices.</value>
    public iGCell this[int rowIndex, int colIndex]
    {
      get
      {
        ++colIndex;
        this.fLatterCell = new iGCell(this.fGrid, rowIndex, colIndex);
        return this.fLatterCell;
      }
    }

    /// <summary>Gets the cell with the specified row index and column key.</summary>
    /// <param name="rowIndex">The row index of the cell to retrieve.</param>
    /// <param name="colKey">The column key of the cell to retrieve.</param>
    /// <value>The cell with the specified row index and column key.</value>
    public iGCell this[int rowIndex, string colKey]
    {
      get
      {
        this.fLatterCell = new iGCell(this.fGrid, rowIndex, this.fGrid.ColKeyToIndex(colKey, true));
        return this.fLatterCell;
      }
    }

    /// <summary>Gets the cell with the specified row key and column index.</summary>
    /// <param name="rowKey">The row key of the cell to retrieve.</param>
    /// <param name="colIndex">The column index of the cell to retrieve or -1 to get a row text cell.</param>
    /// <value>The cell with the specified row key and column index.</value>
    public iGCell this[string rowKey, int colIndex]
    {
      get
      {
        ++colIndex;
        this.fLatterCell = new iGCell(this.fGrid, this.fGrid.RowKeyToIndex(rowKey, true), colIndex);
        return this.fLatterCell;
      }
    }

    /// <summary>Gets the cell with the specified row and column keys.</summary>
    /// <param name="rowKey">The row key of the cell to retrieve.</param>
    /// <param name="colKey">The column key of the cell to retrieve.</param>
    /// <value>The cell with the specified row and column keys.</value>
    public iGCell this[string rowKey, string colKey]
    {
      get
      {
        this.fLatterCell = new iGCell(this.fGrid, this.fGrid.RowKeyToIndex(rowKey, true), this.fGrid.ColKeyToIndex(colKey, true));
        return this.fLatterCell;
      }
    }

    /// <summary>Gets the last accessed cell.</summary>
    /// <value>The last accessed cell.</value>
    public iGCell LatterCell
    {
      get
      {
        return this.fLatterCell;
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return (IEnumerator) new iGEnumerator((IiGEnumerableCollection) this);
    }

    object IiGEnumerableCollection.this[int index]
    {
      get
      {
        return (object) this[index / (this.fGrid.fColCount - 1), index % (this.fGrid.fColCount - 1)];
      }
    }

    int IiGEnumerableCollection.Count
    {
      get
      {
        return (this.fGrid.fColCount - 1) * this.fGrid.fRowCount;
      }
    }
  }
}
