// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGInternalOrderedCellCollection
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Collections.Generic;

namespace TenTec.Windows.iGridLib
{
  internal class iGInternalOrderedCellCollection
  {
    private IComparer<iGCellNavigator> fComparer = (IComparer<iGCellNavigator>) new iGCellNavigatorComparer();
    private const int cDefaultCapacity = 8;
    private iGCellNavigator[] fItems;
    private int fCount;
    private iGrid fGrid;

    public iGInternalOrderedCellCollection(iGrid grid)
    {
      if (grid == null)
        throw new ArgumentNullException(nameof (grid));
      this.fGrid = grid;
    }

    public iGCellNavigator GetItem(int index)
    {
      this.CheckIndex(index);
      return this.fItems[index];
    }

    public bool Contains(iGCellNavigator value)
    {
      return this.IndexOf(value) >= 0;
    }

    public int IndexOf(iGCellNavigator value)
    {
      if (this.fCount == 0)
        return ~this.fCount;
      return Array.BinarySearch<iGCellNavigator>(this.fItems, 0, this.fCount, value, this.fComparer);
    }

    public int IndexOfRow(int rowIndex)
    {
      if (this.fCount == 0)
        return ~this.fCount;
      return this.IndexOfRow(rowIndex, 0);
    }

    public int IndexOfRow(int rowIndex, int startIndex)
    {
      this.CheckIndex(startIndex);
      int num = startIndex != 0 ? this.IndexOf(new iGCellNavigator(rowIndex, 0), startIndex) : this.IndexOf(new iGCellNavigator(rowIndex, 0));
      if (num >= 0)
        return num;
      int index = ~num;
      if (index < this.fCount && this.fItems[index].RowIndex == rowIndex)
        return index;
      return ~index;
    }

    public int IndexOf(iGCellNavigator value, int startIndex)
    {
      if (this.fCount == 0)
        return ~this.fCount;
      for (int index = startIndex; index < this.fCount; ++index)
      {
        int num = this.fComparer.Compare(this.fItems[index], value);
        if (num == 0)
          return index;
        if (num > 0)
          return ~index;
      }
      return ~this.fCount;
    }

    internal void SetCapacity(int value)
    {
      if (this.fCount != 0)
        throw new InvalidOperationException();
      if (this.fItems != null && this.fItems.Length >= value)
        return;
      this.fItems = new iGCellNavigator[value];
    }

    public void Insert(iGCellNavigator value, int index)
    {
      if (index != this.fCount)
        this.CheckIndex(index);
      if (this.fItems == null)
        this.fItems = new iGCellNavigator[8];
      this.fItems = (iGCellNavigator[]) iGArrayManager.ExtendArray((Array) this.fItems, typeof (iGCellNavigator), index, 1, this.fCount, false);
      this.fItems[index] = value;
      this.fCount = this.fCount + 1;
    }

    public void Add(iGCellNavigator value)
    {
      int index = this.fItems != null ? ~Array.BinarySearch<iGCellNavigator>(this.fItems, 0, this.fCount, value, this.fComparer) : 0;
      if (index < 0)
        throw new ArgumentException("The value is already within the collection.");
      this.Insert(value, index);
    }

    public void Remove(iGCellNavigator value)
    {
      int index = this.IndexOf(value);
      if (index < 0)
        throw new ArithmeticException("The collection does not contain the specified value.");
      this.RemoveAt(index);
    }

    public void RemoveAt(int index)
    {
      this.CheckIndex(index);
      this.fItems = (iGCellNavigator[]) iGArrayManager.ShortenArray((Array) this.fItems, typeof (iGCellNavigator), index, 1, this.fCount, false);
      this.fCount = this.fCount - 1;
    }

    public void Clear()
    {
      this.fCount = 0;
    }

    private void CheckIndex(int index)
    {
      if (index >= this.fCount || index < 0)
        throw new ArgumentOutOfRangeException(nameof (index));
    }

    public void OnRowRangeRemoved(int rowIndex, int count)
    {
      if (this.fCount == 0)
        return;
      int num1 = this.IndexOf(new iGCellNavigator(rowIndex, 0));
      if (num1 < 0)
        num1 = ~num1;
      int num2 = this.IndexOf(new iGCellNavigator(rowIndex + count - 1, this.fGrid.fColCount - 1));
      if (num2 < 0)
        num2 = ~num2 - 1;
      int index1 = num1;
      int index2 = num1;
      while (index1 < this.fCount)
      {
        iGCellNavigator fItem = this.fItems[index2];
        if (index2 <= num2)
        {
          this.fCount = this.fCount - 1;
        }
        else
        {
          fItem.RowIndex -= count;
          this.fItems[index1] = fItem;
          ++index1;
        }
        ++index2;
      }
    }

    public void OnRowRangeAdded(int rowIndex, int count)
    {
      if (this.fCount == 0)
        return;
      int num = this.IndexOf(new iGCellNavigator(rowIndex, 0));
      if (num < 0)
        num = ~num;
      for (int index = num; index < this.fCount; ++index)
        this.fItems[index].RowIndex += count;
    }

    public void OnRowRangeMoved(int srcRowIndex, int dstRowIndex, int count)
    {
      if (this.fCount == 0)
        return;
      bool flag = srcRowIndex < dstRowIndex;
      int num1 = this.IndexOf(new iGCellNavigator(srcRowIndex, 0));
      if (num1 < 0)
        num1 = ~num1;
      int num2 = this.IndexOf(new iGCellNavigator(srcRowIndex + count - 1, this.fGrid.fColCount - 1));
      if (num2 < 0)
        num2 = ~num2 - 1;
      int length = num2 - num1 + 1;
      iGCellNavigator[] iGcellNavigatorArray = new iGCellNavigator[length];
      for (int index = num1; index <= num2; ++index)
      {
        iGCellNavigator fItem = this.fItems[index];
        if (flag)
          fItem.RowIndex += dstRowIndex - srcRowIndex;
        else
          fItem.RowIndex -= srcRowIndex - dstRowIndex;
        iGcellNavigatorArray[index - num1] = fItem;
      }
      if (flag)
      {
        int num3 = this.IndexOf(new iGCellNavigator(dstRowIndex + count - 1, this.fGrid.fColCount - 1));
        if (num3 < 0)
          num3 = ~num3;
        int num4 = num3 - 1;
        for (int index = num2 + 1; index <= num4; ++index)
        {
          iGCellNavigator fItem = this.fItems[index];
          fItem.RowIndex -= count;
          this.fItems[index - length] = fItem;
        }
        if (iGcellNavigatorArray == null)
          return;
        Array.Copy((Array) iGcellNavigatorArray, 0, (Array) this.fItems, num4 - length + 1, length);
      }
      else
      {
        int destinationIndex = this.IndexOf(new iGCellNavigator(dstRowIndex, 0));
        if (destinationIndex < 0)
          destinationIndex = ~destinationIndex;
        for (int index = num1 - 1; index >= destinationIndex; --index)
        {
          iGCellNavigator fItem = this.fItems[index];
          fItem.RowIndex += count;
          this.fItems[index + length] = fItem;
        }
        if (iGcellNavigatorArray == null)
          return;
        Array.Copy((Array) iGcellNavigatorArray, 0, (Array) this.fItems, destinationIndex, length);
      }
    }

    public void OnSort(iGRowNavigatorMapItem[] map, int startSortRowIndex)
    {
      if (this.fCount == 0)
        return;
      int fCount = this.fCount;
      iGCellNavigator[] array = new iGCellNavigator[this.fItems.Length];
      Array.Copy((Array) this.fItems, (Array) array, this.fCount);
      for (int index1 = map.Length - 1; index1 >= 0; --index1)
      {
        int initialRowIndex = map[index1].InitialRowIndex;
        int index2 = this.IndexOfRow(initialRowIndex, 0);
        if (index2 >= 0)
        {
          while (index2 < this.fCount && this.fItems[index2].RowIndex == initialRowIndex)
          {
            array[index2] = this.fItems[index2];
            array[index2].RowIndex = startSortRowIndex + index1;
            ++index2;
            --fCount;
          }
        }
        if (fCount == 0)
          break;
      }
      Array.Sort<iGCellNavigator>(array, 0, this.fCount, this.fComparer);
      this.fItems = array;
    }

    public void OnColRangeRemoved(int colIndex, int count)
    {
      if (this.fCount == 0)
        return;
      int index1 = 0;
      int index2 = 0;
      while (index1 < this.fCount)
      {
        iGCellNavigator fItem = this.fItems[index2];
        if (fItem.ColIndex >= colIndex)
        {
          if (fItem.ColIndex < colIndex + count)
          {
            this.fCount = this.fCount - 1;
            goto label_8;
          }
          else
            fItem.ColIndex -= count;
        }
        this.fItems[index1] = fItem;
        ++index1;
label_8:
        ++index2;
      }
    }

    public void OnColRangeAdded(int colIndex, int count)
    {
      if (this.fCount == 0)
        return;
      for (int index = 0; index < this.fCount; ++index)
      {
        int colIndex1 = this.fItems[index].ColIndex;
        if (colIndex1 >= colIndex)
          this.fItems[index].ColIndex = colIndex1 + count;
      }
    }

    public int Count
    {
      get
      {
        return this.fCount;
      }
    }
  }
}
