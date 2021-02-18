// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGSelectedCellsCollection
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Collections;
using System.ComponentModel;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents the collection of the selected cells in an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGSelectedCellsCollection : IList, ICollection, IEnumerable, IiGEnumerableCollection
  {
    private iGInternalOrderedCellCollection fItems;
    private iGrid fGrid;

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

    internal iGSelectedCellsCollection(iGrid grid, iGInternalOrderedCellCollection items)
    {
      if (grid == null)
        throw new ArgumentNullException(nameof (grid));
      if (items == null)
        throw new ArgumentNullException(nameof (items));
      this.fGrid = grid;
      this.fItems = items;
    }

    /// <summary>Retrieves a value indicating whether the specified cell is selected.</summary>
    /// <param name="value">The cell to locate in the collection of selected cell.</param>
    /// <returns>True if the specified cell is selected; otherwise, False.</returns>
    public bool Contains(iGCell value)
    {
      return this.IndexOf(value) >= 0;
    }

    /// <summary>Copies the selected cells to the specified array.</summary>
    /// <param name="array">The one-dimensional <see cref="T:System.Array" /> that is the destination of the cells copied from the collection. The <see cref="T:System.Array" /> must have zero-based indexing.</param>
    /// <param name="index">The zero-based index in the array at which copying begins.</param>
    public void CopyTo(Array array, int index)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      if (index < array.GetLowerBound(0) || index + this.fItems.Count > array.GetUpperBound(0))
        throw new ArgumentOutOfRangeException(nameof (index));
      for (int index1 = 0; index1 < this.fItems.Count; ++index1)
        array.SetValue((object) new iGCell(this.fGrid, this.fItems.GetItem(index1)), index + index1);
    }

    /// <summary>Gets the zero-based index of the specified cell within this collection.</summary>
    /// <param name="value">The cell to locate in the collection.</param>
    /// <returns>The zero-based index of the specified cell within this collection, or a negative number if the cell is not found.</returns>
    public int IndexOf(iGCell value)
    {
      if (value == null)
        throw new ArgumentNullException();
      if (value.fGrid != this.fGrid)
        return -1;
      return this.fItems.IndexOf(new iGCellNavigator(value.fRowIndex, value.fColIndex));
    }

    /// <summary>Gets a cell by its index within this collection.</summary>
    /// <param name="index">The zero-based index of the cell within this collection to retrieve.</param>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGCell" /> object that represents the retrieved cell.</value>
    public iGCell this[int index]
    {
      get
      {
        return new iGCell(this.fGrid, this.fItems.GetItem(index));
      }
    }

    /// <summary>Gets the number of the selected cells.</summary>
    /// <value>The number of the selected cells.</value>
    public int Count
    {
      get
      {
        return this.fItems.Count;
      }
    }

    bool IList.IsReadOnly
    {
      get
      {
        return true;
      }
    }

    object IList.this[int index]
    {
      get
      {
        return (object) this[index];
      }
      set
      {
        throw new NotSupportedException();
      }
    }

    void IList.Insert(int index, object value)
    {
      throw new NotSupportedException();
    }

    void IList.Remove(object value)
    {
      throw new NotSupportedException();
    }

    bool IList.Contains(object value)
    {
      return this.Contains((iGCell) value);
    }

    int IList.IndexOf(object value)
    {
      return this.IndexOf((iGCell) value);
    }

    int IList.Add(object value)
    {
      throw new NotSupportedException();
    }

    void IList.Clear()
    {
      throw new NotSupportedException();
    }

    bool IList.IsFixedSize
    {
      get
      {
        return true;
      }
    }

    void IList.RemoveAt(int index)
    {
      throw new NotSupportedException();
    }

    bool ICollection.IsSynchronized
    {
      get
      {
        return false;
      }
    }

    object ICollection.SyncRoot
    {
      get
      {
        return (object) this;
      }
    }

    /// <summary>Returns an enumerator that can be used to iterate through the collection.</summary>
    /// <returns>An <see cref="T:System.Collections.IEnumerator" /> for this collection.</returns>
    public IEnumerator GetEnumerator()
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
