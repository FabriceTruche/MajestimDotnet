// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGRowCellCollection
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.Collections;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents the collection of a row's cells in an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public sealed class iGRowCellCollection : IiGEnumerableCollection, IEnumerable
  {
    internal iGRow fRow;

    internal iGRowCellCollection(iGRow row)
    {
      this.fRow = row;
    }

    /// <summary>Gets the cell with the specified column index.</summary>
    /// <param name="colIndex">The column index of the cell to retrieve.</param>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGCell" /> object that represents the cell with the specified column index.</value>
    public iGCell this[int colIndex]
    {
      get
      {
        return this.fRow.fGrid.Cells[this.fRow.fIndex, colIndex];
      }
    }

    /// <summary>Gets the cell with the specified column key.</summary>
    /// <param name="colKey">The column key of the cell to retrieve.</param>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGCell" /> object that represents the cell with the specified column key.</value>
    public iGCell this[string colKey]
    {
      get
      {
        return this.fRow.fGrid.Cells[this.fRow.fIndex, colKey];
      }
    }

    /// <summary>Gets the number of the cells in the row.</summary>
    /// <value>The number of cells in the row.</value>
    public int Count
    {
      get
      {
        return this.fRow.fGrid.Cols.Count;
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
