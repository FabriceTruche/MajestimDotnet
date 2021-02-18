// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGSortItem
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents the sort data of a column in an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGSortItem
  {
    private iGSortObject fSortObject;
    private int fSortIndex;

    internal iGSortItem(iGSortObject sortObject, int sortIndex)
    {
      if (sortObject == null)
        throw new ArgumentNullException();
      this.fSortObject = sortObject;
      this.fSortIndex = sortIndex;
    }

    /// <summary>The index of the column the sort item concerns.</summary>
    /// <value>The zero-based index of the column the sort item concerns or -1 if it is a row text column.</value>
    public int ColIndex
    {
      get
      {
        return this.fSortObject.GetColIndexFromSortIndex(this.fSortIndex) - 1;
      }
      set
      {
        this.fSortObject.SetSortCol(this.fSortIndex, value + 1);
        if (!this.fSortObject.fGrid.fRedraw)
          return;
        this.fSortObject.fGrid.Invalidate();
      }
    }

    /// <summary>The sort type of the column the sort item concerns.</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGSortType" /> enumeration values. The default is <see cref="F:TenTec.Windows.iGridLib.iGSortType.ByValue" />.</value>
    public iGSortType SortType
    {
      get
      {
        return this.fSortObject.GetSortType(this.fSortIndex);
      }
      set
      {
        if (value == iGSortType.None)
          throw new ArgumentException();
        this.fSortObject.SetSortType(this.fSortIndex, value);
      }
    }

    /// <summary>The sort order of the column the sort item concerns.</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGSortOrder" /> enumeration values. The default is <see cref="F:TenTec.Windows.iGridLib.iGSortOrder.Ascending" />.</value>
    public iGSortOrder SortOrder
    {
      get
      {
        return this.fSortObject.GetSortOrder(this.fSortIndex);
      }
      set
      {
        if (value == iGSortOrder.None)
          throw new ArgumentException();
        this.fSortObject.SetSortOrder(this.fSortIndex, value);
        if (!this.fSortObject.fGrid.fRedraw)
          return;
        this.fSortObject.fGrid.Invalidate();
      }
    }

    /// <summary>The index of the sort item in the collection.</summary>
    /// <value>The zero based index of the item within the sort or group criteria.</value>
    public int Index
    {
      get
      {
        return this.fSortIndex;
      }
    }
  }
}
