// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGFooterRowCellCollection
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Collections;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents the collection of the cells in a footer row.</summary>
  public sealed class iGFooterRowCellCollection : IiGEnumerableCollection, IEnumerable
  {
    private iGFooterRow fFooterRow;
    private iGrid fGrid;

    internal iGFooterRowCellCollection(iGFooterRow row)
    {
      this.fFooterRow = row;
      this.fGrid = this.fFooterRow.fGrid;
    }

    /// <summary>Gets the footer cell with the specified column index.</summary>
    /// <param name="colIndex">The column index of the footer cell to retrieve.</param>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGFooterCell" /> object that represents the footer cell with the specified column index.</value>
    public iGFooterCell this[int colIndex]
    {
      get
      {
        ++colIndex;
        return new iGFooterCell(this.fGrid, this.fFooterRow.fIndex, colIndex);
      }
    }

    /// <summary>Gets the footer cell with the specified column key.</summary>
    /// <param name="colKey">The column key of the footer cell to retrieve.</param>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGFooterCell" /> object that represents the footer cell with the specified column key.</value>
    public iGFooterCell this[string colKey]
    {
      get
      {
        int index = this.fGrid.ColKeyToIndex(colKey, true);
        if (index < 1)
          throw new ArgumentException("Invalid key");
        return new iGFooterCell(this.fGrid, this.fFooterRow.fIndex, index);
      }
    }

    /// <summary>Gets the number of the cells in the footer row.</summary>
    /// <value>The number of cells in the footer row.</value>
    public int Count
    {
      get
      {
        return this.fGrid.Cols.Count;
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
