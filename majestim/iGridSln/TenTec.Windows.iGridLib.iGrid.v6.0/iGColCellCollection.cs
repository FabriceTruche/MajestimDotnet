// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGColCellCollection
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.Collections;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents the collection of the cells of a column in an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public sealed class iGColCellCollection : IiGEnumerableCollection, IEnumerable
  {
    internal iGCol fCol;

    internal iGColCellCollection(iGCol col)
    {
      this.fCol = col;
    }

    /// <summary>Gets the cell with the specified row index.</summary>
    /// <param name="rowIndex">The row index of the cell to retrieve.</param>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGCell" /> object that exposes the specified cell's properties.</value>
    public iGCell this[int rowIndex]
    {
      get
      {
        return new iGCell(this.fCol.fGrid, rowIndex, this.fCol.fIndex);
      }
    }

    /// <summary>Gets the cell with the specified row key.</summary>
    /// <param name="rowKey">The row key of the cell to retrieve.</param>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGCell" /> object that exposes the specified cell's properties.</value>
    public iGCell this[string rowKey]
    {
      get
      {
        return new iGCell(this.fCol.fGrid, this.fCol.fGrid.RowKeyToIndex(rowKey, true), this.fCol.fIndex);
      }
    }

    /// <summary>Gets the number of the cells in the column.</summary>
    /// <value>The number of the cells in the column.</value>
    public int Count
    {
      get
      {
        return this.fCol.fGrid.Rows.Count;
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
        return (object) this[index];
      }
    }
  }
}
