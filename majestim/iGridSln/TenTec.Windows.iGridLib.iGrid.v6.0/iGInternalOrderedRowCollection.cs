// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGInternalOrderedRowCollection
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

namespace TenTec.Windows.iGridLib
{
  internal class iGInternalOrderedRowCollection
  {
    private iGInternalOrderedCellCollection fItems;

    public iGInternalOrderedRowCollection(iGrid grid)
    {
      this.fItems = new iGInternalOrderedCellCollection(grid);
    }

    public int GetItem(int index)
    {
      return this.fItems.GetItem(index).RowIndex;
    }

    public bool Contains(int value)
    {
      return this.fItems.Contains(new iGCellNavigator(value, 0));
    }

    public int IndexOf(int value)
    {
      return this.fItems.IndexOf(new iGCellNavigator(value, 0));
    }

    public int IndexOf(int value, int startIndex)
    {
      return this.fItems.IndexOf(new iGCellNavigator(value, 0), startIndex);
    }

    internal void SetCapacity(int value)
    {
      this.fItems.SetCapacity(value);
    }

    public void Insert(int value, int index)
    {
      this.fItems.Insert(new iGCellNavigator(value, 0), index);
    }

    public void Add(int value)
    {
      this.fItems.Add(new iGCellNavigator(value, 0));
    }

    public void Remove(int value)
    {
      this.fItems.Remove(new iGCellNavigator(value, 0));
    }

    public void RemoveAt(int index)
    {
      this.fItems.RemoveAt(index);
    }

    public void Clear()
    {
      this.fItems.Clear();
    }

    public void OnRowRangeRemoved(int rowIndex, int count)
    {
      this.fItems.OnRowRangeRemoved(rowIndex, count);
    }

    public void OnRowRangeAdded(int rowIndex, int count)
    {
      this.fItems.OnRowRangeAdded(rowIndex, count);
    }

    public void OnRowRangeMoved(int srcRowIndex, int dstRowIndex, int count)
    {
      this.fItems.OnRowRangeMoved(srcRowIndex, dstRowIndex, count);
    }

    public void OnSort(iGRowNavigatorMapItem[] map, int startSortRowIndex)
    {
      this.fItems.OnSort(map, startSortRowIndex);
    }

    public int Count
    {
      get
      {
        return this.fItems.Count;
      }
    }
  }
}
