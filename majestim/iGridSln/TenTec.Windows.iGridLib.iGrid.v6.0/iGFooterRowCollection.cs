// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGFooterRowCollection
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Collections;
using System.ComponentModel;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents the collection of the footer rows in an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGFooterRowCollection : IiGEnumerableCollection, IEnumerable
  {
    internal iGrid fGrid;

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

    internal iGFooterRowCollection(iGrid grid)
    {
      this.fGrid = grid;
    }

    /// <summary>Adds a new footer row to the grid.</summary>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGFooterRow" /> object that represents the new footer row.</returns>
    public iGFooterRow Add()
    {
      this.fGrid.SetFooterRowCount(this.fGrid.fFooterRowCount + 1);
      return new iGFooterRow(this.fGrid, this.fGrid.fFooterRowCount - 1);
    }

    /// <summary>Adds the specified range of new footer rows to the grid.</summary>
    /// <param name="count">The number of the footer rows to add.</param>
    /// <returns>The index of the first added footer row.</returns>
    public int AddRange(int count)
    {
      int fFooterRowCount = this.fGrid.fFooterRowCount;
      this.fGrid.SetFooterRowCount(this.fGrid.fFooterRowCount + count);
      return fFooterRowCount;
    }

    /// <summary>Removes the row with the specified index from the footer.</summary>
    /// <param name="rowIndex">The zero-based index of the footer row to remove.</param>
    public void RemoveAt(int rowIndex)
    {
      this.fGrid.RemoveFooterRowRange(rowIndex, 1);
    }

    /// <summary>Removes the range of footer rows specified by the index of the first element and count.</summary>
    /// <param name="rowIndex">The zero-based index of the first footer row in the range to remove.</param>
    /// <param name="count">The number of the rows to remove.</param>
    public void RemoveRange(int rowIndex, int count)
    {
      this.fGrid.RemoveFooterRowRange(rowIndex, count);
    }

    /// <summary>Retrieves the footer row located at the specified Y-coordinate. The coordinates are relative to the upper left corner of the grid.</summary>
    /// <param name="y">The Y-coordinate specifying the location of the row to retrieve.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGFooterRow" /> object that represents the footer row at the specified Y-coordinate or null (Nothing in VB) if there is no footer row at that location.</returns>
    public iGFooterRow FromY(int y)
    {
      int rowIndex;
      int rowY;
      int rowHeight;
      if (!this.fGrid.GetFooterRowFromY(y, out rowIndex, out rowY, out rowHeight))
        return (iGFooterRow) null;
      return new iGFooterRow(this.fGrid, rowIndex);
    }

    /// <summary>Retrieves the footer row located at the specified Y-coordinate and the coordinates of that row. The coordinates are relative to the upper left corner of the grid.</summary>
    /// <param name="y">The Y-coordinate specifying the location of the footer row to retrieve. The coordinate is relative to the upper left corner of the grid.</param>
    /// <param name="rowY">The Y-coordinate of the retrieved footer row's top edge. The coordinate is relative to the upper left corner of the grid.</param>
    /// <param name="rowHeight">The height of the retrieved footer row.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGFooterRow" /> object that represents the footer row at the specified Y-coordinate or null (Nothing in VB) if there is no footer row at that location.</returns>
    public iGFooterRow FromY(int y, out int rowY, out int rowHeight)
    {
      int rowIndex;
      if (!this.fGrid.GetFooterRowFromY(y, out rowIndex, out rowY, out rowHeight))
        return (iGFooterRow) null;
      return new iGFooterRow(this.fGrid, rowIndex);
    }

    /// <summary>Gets or sets the number of footer rows in the grid.</summary>
    /// <value>A non-negative integer value.</value>
    public int Count
    {
      get
      {
        return this.fGrid.fFooterRowCount;
      }
      set
      {
        if (value < 1)
          throw new ArgumentOutOfRangeException();
        this.fGrid.SetFooterRowCount(value);
      }
    }

    /// <summary>Gets the footer row with the specified index.</summary>
    /// <param name="index">The zero-based index of the footer row to retrieve.</param>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGFooterRow" /> object that represents the retrieved footer row.</value>
    public iGFooterRow this[int index]
    {
      get
      {
        return new iGFooterRow(this.fGrid, index);
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return (IEnumerator) new iGEnumerator((IiGEnumerableCollection) this);
    }

    int IiGEnumerableCollection.Count
    {
      get
      {
        return this.Count;
      }
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
