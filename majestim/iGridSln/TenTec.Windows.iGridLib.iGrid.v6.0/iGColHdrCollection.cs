// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGColHdrCollection
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents the collection of the column headers (header cells) in an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGColHdrCollection : IiGEnumerableCollection, IEnumerable
  {
    internal iGrid fGrid;

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

    internal iGColHdrCollection(iGrid grid)
    {
      this.fGrid = grid;
    }

    /// <summary>Retrieves the column header that is located at the specified coordinates. The coordinates are relative to the upper left corner of the grid.</summary>
    /// <param name="x">The X-coordinate of the point for which to retrieve the column header.</param>
    /// <param name="y">The Y-coordinate of the point for which to retrieve the column header.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGColHdr" /> object that represents the column header at the specified point, or null (Nothing in VB) if there is no column header.</returns>
    public iGColHdr FromPoint(int x, int y)
    {
      int rowIndex;
      int rowCount;
      int colIndex;
      int colCount;
      Rectangle bounds;
      if (this.fGrid.GetColHdrFromPoint(x, y, out rowIndex, out rowCount, out colIndex, out colCount, out bounds))
        return new iGColHdr(this.fGrid, rowIndex, colIndex);
      return (iGColHdr) null;
    }

    /// <summary>Retrieves the column header that is located at the specified coordinates and its bounds. The coordinates are relative to the upper left corner of the grid.</summary>
    /// <param name="x">The X-coordinate of the point for which to retrieve the column header.</param>
    /// <param name="y">The Y-coordinate of the point for which to retrieve the column header.</param>
    /// <param name="bounds">The bounds of the retrieved column header.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGColHdr" /> object that represents the column header at the specified point, or null (Nothing in VB) if there is no column header.</returns>
    public iGColHdr FromPoint(int x, int y, out Rectangle bounds)
    {
      int rowIndex;
      int rowCount;
      int colIndex;
      int colCount;
      if (this.fGrid.GetColHdrFromPoint(x, y, out rowIndex, out rowCount, out colIndex, out colCount, out bounds))
        return new iGColHdr(this.fGrid, rowIndex, colIndex);
      return (iGColHdr) null;
    }

    /// <summary>Gets the column header with the specified row and column indices.</summary>
    /// <param name="rowIndex">The row index of the column header to retrieve.</param>
    /// <param name="colIndex">The column index of the column header to retrieve.</param>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGColHdr" /> object that represents the column header width the specified indices.</value>
    public iGColHdr this[int rowIndex, int colIndex]
    {
      get
      {
        ++colIndex;
        return new iGColHdr(this.fGrid, rowIndex, colIndex);
      }
    }

    /// <summary>Gets the column header with the specified row index and column key.</summary>
    /// <param name="rowIndex">The row index of the column header to retrieve.</param>
    /// <param name="colKey">The column key of the column header to retrieve.</param>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGColHdr" /> object that represents the column header width the specified row index and column key.</value>
    public iGColHdr this[int rowIndex, string colKey]
    {
      get
      {
        int index = this.fGrid.ColKeyToIndex(colKey, true);
        if (index < 1)
          throw new ArgumentException("Invalid key");
        return new iGColHdr(this.fGrid, rowIndex, index);
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
        return (this.fGrid.fColCount - 1) * this.fGrid.fHeaderRowCount;
      }
    }
  }
}
