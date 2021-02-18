// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGSelectedRowsCollection
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Collections;
using System.ComponentModel;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents the collection of the selected rows in an iGrid control.</summary>
  public class iGSelectedRowsCollection : IList, ICollection, IEnumerable, IiGEnumerableCollection
  {
    private iGInternalOrderedRowCollection fItems;
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

    internal iGSelectedRowsCollection(iGrid grid, iGInternalOrderedRowCollection items)
    {
      if (grid == null)
        throw new ArgumentNullException(nameof (grid));
      if (items == null)
        throw new ArgumentNullException(nameof (items));
      this.fGrid = grid;
      this.fItems = items;
    }

    /// <summary>Retrieves a value indicating whether the specified row is selected.</summary>
    /// <param name="value">The row to locate in the collection of selected rows.</param>
    /// <returns>True if the specified row is selected; otherwise, False.</returns>
    public bool Contains(iGRow value)
    {
      return this.IndexOf(value) >= 0;
    }

    /// <summary>Copies the selected rows to the specified array.</summary>
    /// <param name="array">The one-dimensional Array that is the destination of the rows copied from the collection. The Array must have zero-based indexing.</param>
    /// <param name="index">The zero-based index in the array at which copying begins.</param>
    public void CopyTo(Array array, int index)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      if (index < array.GetLowerBound(0) || index + this.fItems.Count > array.GetUpperBound(0))
        throw new ArgumentOutOfRangeException(nameof (index));
      for (int index1 = 0; index1 < this.fItems.Count; ++index1)
        array.SetValue((object) new iGRow(this.fGrid, this.fItems.GetItem(index1)), index + index1);
    }

    /// <summary>Gets the zero-based index of the specified row within this collection.</summary>
    /// <param name="value">The row to locate in the collection.</param>
    /// <returns>The zero-based index of the specified row within this collection, or a negative number if the row is not found.</returns>
    public int IndexOf(iGRow value)
    {
      if (value == null)
        throw new ArgumentNullException();
      if (value.fGrid != this.fGrid)
        return -1;
      return this.fItems.IndexOf(value.fIndex);
    }

    /// <summary>Gets a row by its index within this collection.</summary>
    /// <param name="index">The zero-based index of the row within this collection to retrieve.</param>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGRow" /> object that represents the retrieved row.</value>
    public iGRow this[int index]
    {
      get
      {
        return new iGRow(this.fGrid, this.fItems.GetItem(index));
      }
    }

    /// <summary>Gets the number of the selected rows.</summary>
    /// <value>The number of the selected rows.</value>
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
      return this.Contains((iGRow) value);
    }

    int IList.IndexOf(object value)
    {
      return this.IndexOf((iGRow) value);
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
