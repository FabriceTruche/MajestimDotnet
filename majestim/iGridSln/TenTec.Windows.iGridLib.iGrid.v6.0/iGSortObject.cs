// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGSortObject
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents the sort or group data of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGSortObject
  {
    private const iGSortOrder cDefaultSortOrder = iGSortOrder.Ascending;
    internal iGColSortParams[] fParams;
    private int fCount;
    internal iGrid fGrid;
    private bool fIsGroupObject;

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

    private iGSortObject()
    {
    }

    private void SetNotSorted(int colIndex)
    {
      this.fParams[colIndex].SortIndex = -1;
      this.fParams[colIndex].SortOrder = iGSortOrder.None;
      this.fParams[colIndex].SortType = iGSortType.None;
    }

    private void RemoveSortFromColumn(int colIndex, int count)
    {
      for (int colIndex1 = colIndex + count - 1; colIndex1 >= colIndex; --colIndex1)
      {
        int sortIndex = this.fParams[colIndex1].SortIndex;
        if (sortIndex >= 0)
        {
          this.SetNotSorted(colIndex1);
          for (int index = this.fParams.Length - 1; index >= 0; --index)
          {
            if (this.fParams[index].SortIndex > sortIndex)
              --this.fParams[index].SortIndex;
          }
          this.fCount = this.fCount - 1;
        }
      }
    }

    internal int GetColIndexFromSortIndex(int index)
    {
      this.CheckIndex(index);
      for (int index1 = this.fParams.Length - 1; index1 >= 0; --index1)
      {
        if (this.fParams[index1].SortIndex == index)
          return index1;
      }
      throw new ArgumentOutOfRangeException();
    }

    private void CheckIndex(int index)
    {
      if (index >= this.fCount || index < 0)
        throw new ArgumentOutOfRangeException();
    }

    private int GetColIndexFromKey(string colKey)
    {
      return this.fGrid.ColKeyToIndex(colKey, true);
    }

    private iGSortType GetColSortType(int colIndex)
    {
      iGSortType iGsortType = this.fGrid.GetColData(colIndex).SortType;
      if (iGsortType == iGSortType.None)
        iGsortType = iGSortType.ByValue;
      return iGsortType;
    }

    internal iGSortObject(int colCount, iGrid grid, bool isGroupObject)
    {
      this.fParams = new iGColSortParams[colCount];
      for (int colIndex = 0; colIndex < colCount; ++colIndex)
        this.SetNotSorted(colIndex);
      this.fCount = 0;
      this.fGrid = grid;
      this.fIsGroupObject = isGroupObject;
    }

    internal void OnGridAddCol(int colBefore, int count)
    {
      this.fParams = (iGColSortParams[]) iGArrayManager.ExtendArray((Array) this.fParams, typeof (iGColSortParams), colBefore, count, this.fParams.Length, true);
      for (int colIndex = colBefore + count - 1; colIndex >= colBefore; --colIndex)
        this.SetNotSorted(colIndex);
    }

    internal void OnGridRemoveCol(int colIndex, int count)
    {
      this.RemoveSortFromColumn(colIndex, count);
      this.fParams = (iGColSortParams[]) iGArrayManager.ShortenArray((Array) this.fParams, typeof (iGColSortParams), colIndex, count, this.fParams.Length, true);
    }

    internal bool DoDefaultSort(int colOrder, int colCount, Keys keyModifiers, iGSortOrder sortOrder)
    {
      iGSortOrder iGsortOrder1 = iGSortOrder.None;
      int num1 = colOrder + colCount;
      int num2 = 0;
      for (int index1 = colOrder; index1 < num1; ++index1)
      {
        int index2 = this.fGrid.fColIdxFromOrd[index1];
        if (this.fGrid.fColDatas[index2].SortType != iGSortType.None)
        {
          if (num2 == 0)
            iGsortOrder1 = this.fParams[index2].SortOrder;
          else if (this.fParams[index2].SortOrder != iGsortOrder1)
            iGsortOrder1 = iGSortOrder.None;
          ++num2;
        }
      }
      if (num2 == 0)
        return false;
      if ((keyModifiers & Keys.Shift) != Keys.Shift && (keyModifiers & Keys.Control) != Keys.Control && (keyModifiers & Keys.Alt) != Keys.Alt)
        this.Clear();
      iGSortOrder iGsortOrder2;
      if (sortOrder != iGSortOrder.None)
      {
        iGsortOrder2 = sortOrder;
      }
      else
      {
        iGSortOrder sortOrder1 = this.fGrid.fColDatas[this.fGrid.fColIdxFromOrd[colOrder]].SortOrder;
        iGsortOrder2 = iGsortOrder1 != iGSortOrder.Ascending ? (iGsortOrder1 == iGSortOrder.Descending || sortOrder1 == iGSortOrder.None ? iGSortOrder.Ascending : sortOrder1) : iGSortOrder.Descending;
      }
      for (int index1 = colOrder; index1 < num1; ++index1)
      {
        int index2 = this.fGrid.fColIdxFromOrd[index1];
        iGColData fColData = this.fGrid.fColDatas[index2];
        if (fColData.SortType != iGSortType.None && fColData.SortOrder != iGSortOrder.None)
        {
          if (this.fParams[index2].SortIndex == -1)
          {
// FABRICE

            //// ISSUE: explicit reference operation
            //// ISSUE: variable of a reference type
            //iGColSortParams& local = @this.fParams[index2];
            //int fCount = this.fCount;
            //this.fCount = fCount + 1;
            //int num3 = fCount;
            //// ISSUE: explicit reference operation
            //(^local).SortIndex = num3;
          }
          //this.fParams[index2].SortOrder = iGsortOrder2;
          //this.fParams[index2].SortType = fColData.SortType;
        }
      }
      return true;
    }

    internal int GetSortIndexOfColumn(int colIndex)
    {
      this.fGrid.CheckColIndex(colIndex);
      return this.fParams[colIndex].SortIndex;
    }

    internal void SetSortParamsOfColumn(int colIndex, iGColSortParams sortParams)
    {
      if (sortParams.SortIndex > this.fCount)
        throw new ArgumentOutOfRangeException();
      int sortIndex = this.fParams[colIndex].SortIndex;
      if (this.fParams[colIndex].SortOrder == iGSortOrder.None)
      {
        this.fCount = this.fCount + 1;
        for (int index = this.fParams.Length - 1; index >= 0; --index)
        {
          if (this.fParams[index].SortIndex >= sortParams.SortIndex)
            ++this.fParams[index].SortIndex;
        }
      }
      else
      {
        if (sortParams.SortIndex == this.fCount)
          sortParams.SortIndex = this.fCount - 1;
        if (sortIndex != sortParams.SortIndex)
        {
          for (int index = this.fParams.Length - 1; index >= 0; --index)
          {
            if (this.fParams[index].SortIndex < sortIndex && this.fParams[index].SortIndex >= sortParams.SortIndex)
              ++this.fParams[index].SortIndex;
            else if (this.fParams[index].SortIndex > sortIndex && this.fParams[index].SortIndex <= sortParams.SortIndex)
              --this.fParams[index].SortIndex;
          }
        }
      }
      this.fParams[colIndex] = sortParams;
    }

    internal void OnColsChanged(iGSortObject.iGSortedColsChangedEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.ColsChanged == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.ColsChanged((object) this, e);
    }

    internal void OnOrderTypeOrIndexChanged(EventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.OrderTypeOrIndexChanged == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.OrderTypeOrIndexChanged((object) this, e);
    }

    private static int GetCompoundCount(iGSortObject mainSortObject, iGSortObject secondSortObject, int colCount)
    {
      int num = 0;
      for (int index = 0; index < colCount; ++index)
      {
        if (mainSortObject != null && mainSortObject.fParams[index].SortType != iGSortType.None)
          ++num;
        else if (secondSortObject != null && secondSortObject.fParams[index].SortType != iGSortType.None)
          ++num;
      }
      return num;
    }

    internal static iGSortData[] GetData(iGSortObject mainSortObject)
    {
      iGSortData[] compoundData;
      iGSortData[] mainSortObjData;
      iGSortObject.GetData(mainSortObject, (iGSortObject) null, false, true, false, out compoundData, out mainSortObjData);
      return mainSortObjData;
    }

    internal static void GetData(iGSortObject mainSortObject, iGSortObject secondSortObject, bool retCompoundData, bool retMainSortObjData, bool fillCustomGroupValues, out iGSortData[] compoundData, out iGSortData[] mainSortObjData)
    {
      compoundData = (iGSortData[]) null;
      mainSortObjData = (iGSortData[]) null;
      if (mainSortObject == null && secondSortObject == null)
        return;
      int colCount = mainSortObject == null ? secondSortObject.fParams.Length : mainSortObject.fParams.Length;
      int compoundCount = iGSortObject.GetCompoundCount(mainSortObject, secondSortObject, colCount);
      if (retCompoundData && compoundCount > 0)
        compoundData = new iGSortData[compoundCount];
      int length;
      if (mainSortObject != null)
      {
        length = mainSortObject.Count;
        if (retMainSortObjData && length > 0)
          mainSortObjData = new iGSortData[length];
        for (int colIndex = 0; colIndex < colCount; ++colIndex)
        {
          iGColSortParams fParam = mainSortObject.fParams[colIndex];
          if (fParam.SortType != iGSortType.None)
          {
            object[] customGroupValues;
            bool customGrouping;
            if (fillCustomGroupValues)
            {
              customGroupValues = mainSortObject.fGrid.GetCustomGroupValuesIfExist(colIndex);
              customGrouping = customGroupValues != null;
            }
            else
            {
              customGroupValues = (object[]) null;
              customGrouping = mainSortObject.fGrid.CustomGroupValuesExist(colIndex);
            }
            iGSortData iGsortData = new iGSortData(colIndex, fParam.SortOrder, fParam.SortType, mainSortObject.fIsGroupObject, customGrouping, customGroupValues);
            if (retCompoundData)
              compoundData[fParam.SortIndex] = iGsortData;
            if (retMainSortObjData)
              mainSortObjData[fParam.SortIndex] = iGsortData;
          }
        }
      }
      else
        length = 0;
      if (!(secondSortObject != null & retCompoundData))
        return;
      int index1 = length;
      for (int index2 = 0; index2 < secondSortObject.Count; ++index2)
      {
        int indexFromSortIndex = secondSortObject.GetColIndexFromSortIndex(index2);
        if (mainSortObject == null || mainSortObject.fParams[indexFromSortIndex].SortOrder == iGSortOrder.None)
        {
          compoundData[index1] = new iGSortData(indexFromSortIndex, secondSortObject.fParams[indexFromSortIndex].SortOrder, secondSortObject.fParams[indexFromSortIndex].SortType, false, false, (object[]) null);
          ++index1;
        }
      }
    }

    internal void SetSortCol(int sortIndex, int colIndex)
    {
      if (colIndex < 0 || colIndex >= this.fParams.Length)
        throw new ArgumentOutOfRangeException();
      int indexFromSortIndex = this.GetColIndexFromSortIndex(sortIndex);
      if (colIndex == indexFromSortIndex)
        return;
      iGColSortParams fParam = this.fParams[colIndex];
      this.fParams[colIndex] = this.fParams[indexFromSortIndex];
      this.fParams[indexFromSortIndex] = fParam;
      if (fParam.SortOrder == iGSortOrder.None)
      {
        bool[] changedCols = new bool[this.fParams.Length];
        changedCols[indexFromSortIndex] = true;
        changedCols[colIndex] = true;
        this.OnColsChanged(new iGSortObject.iGSortedColsChangedEventArgs(changedCols));
      }
      this.OnOrderTypeOrIndexChanged(EventArgs.Empty);
    }

    internal void MoveGroupCol(int srcColIndex, int dstGroupIndex)
    {
      int sortIndex1 = this.fParams[srcColIndex].SortIndex;
      if (sortIndex1 == -1)
        throw new Exception();
      if (sortIndex1 == dstGroupIndex)
        return;
      if (sortIndex1 < dstGroupIndex)
      {
        for (int index = this.fParams.Length - 1; index >= 0; --index)
        {
          int sortIndex2 = this.fParams[index].SortIndex;
          if (sortIndex2 == sortIndex1)
            this.fParams[index].SortIndex = dstGroupIndex;
          else if (sortIndex2 > sortIndex1 && sortIndex2 <= dstGroupIndex)
            this.fParams[index].SortIndex = sortIndex2 - 1;
        }
      }
      else
      {
        for (int index = this.fParams.Length - 1; index >= 0; --index)
        {
          int sortIndex2 = this.fParams[index].SortIndex;
          if (sortIndex2 == sortIndex1)
            this.fParams[index].SortIndex = dstGroupIndex;
          else if (sortIndex2 >= dstGroupIndex && sortIndex2 < sortIndex1)
            this.fParams[index].SortIndex = sortIndex2 + 1;
        }
      }
      this.OnOrderTypeOrIndexChanged(EventArgs.Empty);
    }

    internal void InsertVisibleCols(int sortIndex, int colOrder, int colCount)
    {
      int num1 = 0;
      int num2 = sortIndex;
      bool[] changedCols = new bool[this.fParams.Length];
      for (int index = colOrder; index < colOrder + colCount; ++index)
      {
        int colIndex = this.fGrid.fColIdxFromOrd[index];
        iGColData fColData = this.fGrid.fColDatas[colIndex];
        if (this.fParams[colIndex].SortOrder == iGSortOrder.None && this.fGrid.IsColVisible(fColData.Visible, fColData.ShowWhenGrouped, colIndex) && fColData.SortType != iGSortType.None)
        {
          changedCols[colIndex] = true;
          this.fCount = this.fCount + 1;
          ++num1;
          this.fParams[colIndex].SortIndex = num2++;
          iGSortOrder iGsortOrder = this.fGrid.SortObject.fParams[colIndex].SortOrder;
          if (iGsortOrder == iGSortOrder.None)
            iGsortOrder = iGSortOrder.Ascending;
          this.fParams[colIndex].SortOrder = iGsortOrder;
          this.fParams[colIndex].SortType = fColData.SortType;
        }
      }
      if (num1 <= 0)
        return;
      for (int index = this.fParams.Length - 1; index >= 0; --index)
      {
        if (!changedCols[index] && this.fParams[index].SortIndex >= sortIndex)
          this.fParams[index].SortIndex += num1;
      }
      this.OnColsChanged(new iGSortObject.iGSortedColsChangedEventArgs(changedCols));
      this.OnOrderTypeOrIndexChanged(EventArgs.Empty);
    }

    internal void CopyPropertiesTo(iGSortObject dst)
    {
      for (int index = this.fParams.Length - 1; index >= 0; --index)
        dst.fParams[index] = this.fParams[index];
      dst.fCount = this.fCount;
    }

    /// <summary>Removes all the columns from the sort (group) criteria.</summary>
    public void Clear()
    {
      if (this.fCount == 0)
        return;
      bool[] changedCols = new bool[this.fParams.Length];
      for (int colIndex = this.fParams.Length - 1; colIndex >= 0; --colIndex)
      {
        if (this.fParams[colIndex].SortOrder != iGSortOrder.None)
        {
          this.SetNotSorted(colIndex);
          changedCols[colIndex] = true;
        }
      }
      this.fCount = 0;
      this.OnColsChanged(new iGSortObject.iGSortedColsChangedEventArgs(changedCols));
      this.OnOrderTypeOrIndexChanged(EventArgs.Empty);
    }

    internal iGCol GetSortCol(int sortIndex)
    {
      return new iGCol(this.fGrid, this.GetColIndexFromSortIndex(sortIndex));
    }

    internal void SetSortCol(int sortIndex, iGCol col)
    {
      if (col == null)
        throw new ArgumentNullException();
      this.SetSortCol(sortIndex, col.fIndex);
    }

    internal iGSortOrder GetSortOrder(int sortIndex)
    {
      return this.fParams[this.GetColIndexFromSortIndex(sortIndex)].SortOrder;
    }

    internal void SetSortOrder(int sortIndex, iGSortOrder value)
    {
      int indexFromSortIndex = this.GetColIndexFromSortIndex(sortIndex);
      if (value == iGSortOrder.None)
      {
        this.RemoveSortFromColumn(indexFromSortIndex, 1);
        bool[] changedCols = new bool[this.fParams.Length];
        changedCols[indexFromSortIndex] = true;
        this.OnColsChanged(new iGSortObject.iGSortedColsChangedEventArgs(changedCols));
        this.OnOrderTypeOrIndexChanged(EventArgs.Empty);
      }
      else
      {
        if (this.fParams[indexFromSortIndex].SortOrder == value)
          return;
        this.fParams[indexFromSortIndex].SortOrder = value;
        this.OnOrderTypeOrIndexChanged(EventArgs.Empty);
      }
    }

    internal iGSortType GetSortType(int sortIndex)
    {
      return this.fParams[this.GetColIndexFromSortIndex(sortIndex)].SortType;
    }

    internal void SetSortType(int sortIndex, iGSortType value)
    {
      int indexFromSortIndex = this.GetColIndexFromSortIndex(sortIndex);
      if (value == iGSortType.None)
      {
        this.RemoveSortFromColumn(indexFromSortIndex, 1);
        bool[] changedCols = new bool[this.fParams.Length];
        changedCols[indexFromSortIndex] = true;
        this.OnColsChanged(new iGSortObject.iGSortedColsChangedEventArgs(changedCols));
        this.OnOrderTypeOrIndexChanged(EventArgs.Empty);
      }
      else
      {
        if (this.fParams[indexFromSortIndex].SortType == value)
          return;
        this.fParams[indexFromSortIndex].SortType = value;
        this.OnOrderTypeOrIndexChanged(EventArgs.Empty);
      }
    }

    /// <summary>Adds the specified column to the sort (group) criteria.</summary>
    /// <param name="colIndex">The zero-based index of the column to add to the sort (group) criteria. Specify -1 if you wish to sort (group) by the row text column.</param>
    /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGSortItem" /> object that represents the added sort criterion.</returns>
    public iGSortItem Add(int colIndex)
    {
      return this.Add(colIndex, iGSortOrder.Ascending, this.GetColSortType(colIndex + 1));
    }

    /// <summary>Adds the specified column to the sort (group) criteria.</summary>
    /// <param name="colKey">The string key of the column to add to the sort (group) criteria.</param>
    /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGSortItem" /> object that represents the added sort criterion.</returns>
    public iGSortItem Add(string colKey)
    {
      return this.Add(this.GetColIndexFromKey(colKey) - 1);
    }

    /// <summary>Adds the specified column to the sort (group) criteria and sets its sort order.</summary>
    /// <param name="colIndex">The zero-based index of the column to add to the sort (group) criteria. Specify -1 if you wish to sort (group) by the row text column.</param>
    /// <param name="sortOrder">The order in which the rows should be sorted (grouped) by the column to add.</param>
    /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGSortItem" /> object that represents the added sort criterion.</returns>
    public iGSortItem Add(int colIndex, iGSortOrder sortOrder)
    {
      return this.Add(colIndex, sortOrder, this.GetColSortType(colIndex + 1));
    }

    /// <summary>Adds the specified column to the sort (group) criteria and sets its sort order.</summary>
    /// <param name="colKey">The string key of the column to add to the sort (group) criteria.</param>
    /// <param name="sortOrder">The order in which the rows should be sorted (grouped) by the column to add.</param>
    /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGSortItem" /> object that represents the added sort criterion.</returns>
    public iGSortItem Add(string colKey, iGSortOrder sortOrder)
    {
      return this.Add(this.GetColIndexFromKey(colKey) - 1, sortOrder);
    }

    /// <summary>Adds the specified column to the sort (group) criteria and sets its sort order and type.</summary>
    /// <param name="colKey">The string key of the column to add to the sort (group) criteria.</param>
    /// <param name="sortOrder">The order in which the rows should be sorted (grouped) by the column to add.</param>
    /// <param name="sortType">Specifies how to sort (group) the rows by the column to add.</param>
    /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGSortItem" /> object that represents the added sort criterion.</returns>
    public iGSortItem Add(string colKey, iGSortOrder sortOrder, iGSortType sortType)
    {
      return this.Add(this.GetColIndexFromKey(colKey) - 1, sortOrder, sortType);
    }

    /// <summary>Adds the specified column to the sort (group) criteria and sets its sort order and type.</summary>
    /// <param name="colIndex">The zero-based index of the column to add to the sort (group) criteria. Specify -1 if you wish to sort (group) by the row text column.</param>
    /// <param name="sortOrder">The order in which the rows should be sorted (grouped) by the column to add.</param>
    /// <param name="sortType">Specifies how to sort (group) the rows by the column to add.</param>
    /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGSortItem" /> object that represents the added sort criterion.</returns>
    public iGSortItem Add(int colIndex, iGSortOrder sortOrder, iGSortType sortType)
    {
      ++colIndex;
      this.fGrid.CheckColIndex(colIndex);
      if (sortOrder == iGSortOrder.None || sortType == iGSortType.None)
        throw new ArgumentException();
      this.SetSortParamsOfColumn(colIndex, new iGColSortParams(sortType, sortOrder, this.fCount));
      if (this.fGrid.fRedraw)
        this.fGrid.Invalidate();
      return this[this.Count - 1];
    }

    /// <summary>Inserts the specified column to the specified position in the sort (group) criteria.</summary>
    /// <param name="index">The zero-based position in the sort (group) criteria to insert the column to.</param>
    /// <param name="colIndex">The zero-based index of the column to insert to the sort (group) criteria. Specify -1 if you wish to sort (group) by the row text column.</param>
    /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGSortItem" /> object that represents the added sort criterion.</returns>
    public iGSortItem Insert(int index, int colIndex)
    {
      return this.Insert(index, colIndex, iGSortOrder.Ascending, this.GetColSortType(colIndex + 1));
    }

    /// <summary>Inserts the specified column to the specified position in the sort (group) criteria.</summary>
    /// <param name="index">The zero-based position in the sort (group) criteria to insert the column to.</param>
    /// <param name="colKey">The string key of the column to insert to the sort (group) criteria.</param>
    /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGSortItem" /> object that represents the added sort criterion.</returns>
    public iGSortItem Insert(int index, string colKey)
    {
      return this.Insert(index, this.GetColIndexFromKey(colKey) - 1);
    }

    /// <summary>Inserts the specified column to the specified position in the sort (group) criteria and sets its sort order.</summary>
    /// <param name="index">The zero-based position in the sort (group) criteria to insert the column to.</param>
    /// <param name="colIndex">The zero-based index of the column to insert to the sort (group) criteria. Specify -1 if you wish to sort (group) by the row text column.</param>
    /// <param name="sortOrder">The order in which the rows should be sorted (grouped) by the column to insert.</param>
    /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGSortItem" /> object that represents the added sort criterion.</returns>
    public iGSortItem Insert(int index, int colIndex, iGSortOrder sortOrder)
    {
      return this.Insert(index, colIndex, sortOrder, this.GetColSortType(colIndex + 1));
    }

    /// <summary>Inserts the specified column to the specified position in the sort (group) criteria and sets its sort order.</summary>
    /// <param name="index">The zero-based position in the sort (group) criteria to insert the column to.</param>
    /// <param name="colKey">The string key of the column to insert to the sort (group) criteria.</param>
    /// <param name="sortOrder">The order in which the rows should be sorted (grouped) by the column to insert.</param>
    /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGSortItem" /> object that represents the added sort criterion.</returns>
    public iGSortItem Insert(int index, string colKey, iGSortOrder sortOrder)
    {
      return this.Insert(index, this.GetColIndexFromKey(colKey) - 1, sortOrder);
    }

    /// <summary>Inserts the specified column to the specified position in the sort (group) criteria and sets its sort order and type.</summary>
    /// <param name="index">The zero-based position in the sort (group) criteria to insert the column to.</param>
    /// <param name="colKey">The string key of the column to insert to the sort (group) criteria.</param>
    /// <param name="sortOrder">The order in which the rows should be sorted (grouped) by the column to insert.</param>
    /// <param name="sortType">Specifies how to sort (group) the rows by the column to insert.</param>
    /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGSortItem" /> object that represents the added sort criterion.</returns>
    public iGSortItem Insert(int index, string colKey, iGSortOrder sortOrder, iGSortType sortType)
    {
      return this.Insert(index, this.GetColIndexFromKey(colKey) - 1, sortOrder, sortType);
    }

    /// <summary>Inserts the specified column to the specified position in the sort (group) criteria and sets its sort order and type.</summary>
    /// <param name="index">The zero-based position in the sort (group) criteria to insert the column to.</param>
    /// <param name="colIndex">The zero-based index of the column to insert to the sort (group) criteria. Specify -1 if you wish to sort (group) by the row text column.</param>
    /// <param name="sortOrder">The order in which the rows should be sorted (grouped) by the column to insert.</param>
    /// <param name="sortType">Specifies how to sort (group) the rows by the column to insert.</param>
    /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGSortItem" /> object that represents the added sort criterion.</returns>
    public iGSortItem Insert(int index, int colIndex, iGSortOrder sortOrder, iGSortType sortType)
    {
      ++colIndex;
      this.fGrid.CheckColIndex(colIndex);
      if (sortOrder == iGSortOrder.None || sortType == iGSortType.None)
        throw new ArgumentException();
      if (index != this.fCount)
        this.CheckIndex(index);
      this.SetSortParamsOfColumn(colIndex, new iGColSortParams(sortType, sortOrder, index));
      if (this.fGrid.fRedraw)
        this.fGrid.Invalidate();
      return this[index];
    }

    /// <summary>Removes the sort item with the specified index from the sort (group) criteria.</summary>
    /// <param name="index">The zero-based index of the sort item to remove.</param>
    public void RemoveAt(int index)
    {
      this.CheckIndex(index);
      this.SetSortOrder(index, iGSortOrder.None);
      if (!this.fGrid.fRedraw)
        return;
      this.fGrid.Invalidate();
    }

    /// <summary>Retrieves the index of the specified column in the sort (group) criteria.</summary>
    /// <param name="colIndex">The zero-based index of the column to locate. Specify -1 if it is the row text column.</param>
    /// <returns>The index of the column within the sort (group) criteria, or -1 if the column is not included to the criteria.</returns>
    public int IndexOf(int colIndex)
    {
      ++colIndex;
      this.fGrid.CheckColIndex(colIndex);
      return this.fParams[colIndex].SortIndex;
    }

    /// <summary>Retrieves the index of the specified column in the sort (group) criteria.</summary>
    /// <param name="colKey">The string key of the column to locate.</param>
    /// <returns>The index of the column within the sort (group) criteria, or -1 if the column is not included to the criteria.</returns>
    public int IndexOf(string colKey)
    {
      return this.IndexOf(this.GetColIndexFromKey(colKey) - 1);
    }

    /// <summary>Retrieves a value indicating whether the specified column is included in the sort (group) criteria.</summary>
    /// <param name="colIndex">The zero-based index of the column to locate. Specify -1 if it is the row text column.</param>
    /// <returns>True if the column is included to the sort (group) criteria; otherwise, False.</returns>
    public bool Contains(int colIndex)
    {
      return this.IndexOf(colIndex) >= 0;
    }

    /// <summary>Retrieves a value indicating whether the specified column is included in the sort (group) criteria.</summary>
    /// <param name="colKey">The string key of the column to locate.</param>
    /// <returns>True if the column is included to the sort (group) criteria; otherwise, False.</returns>
    public bool Contains(string colKey)
    {
      return this.IndexOf(colKey) >= 0;
    }

    /// <summary>Gets the sort item with the specified index within the collection.</summary>
    /// <param name="index">The zero-based index of the sort item to retrieve.</param>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGSortItem" /> object.</value>
    public iGSortItem this[int index]
    {
      get
      {
        this.CheckIndex(index);
        return new iGSortItem(this, index);
      }
    }

    /// <summary>Gets the number of the columns included in the sort (group) criteria.</summary>
    /// <value>A number.</value>
    public int Count
    {
      get
      {
        return this.fCount;
      }
      set
      {
        if (this.fCount == value)
          return;
        if (value > this.fParams.Length)
          throw new ArgumentOutOfRangeException();
        int colDrawOrder = 0;
        int fCount = this.fCount;
        int num = value - this.fCount;
        bool[] changedCols = new bool[this.fParams.Length];
        if (num > 0)
        {
          while (num > 0)
          {
            int index = this.fGrid.fColIdxFromOrd[this.fGrid.DrawColOrderToColOrder(colDrawOrder)];
            if (this.fParams[index].SortIndex == -1)
            {
              this.fParams[index].SortType = iGSortType.ByValue;
              this.fParams[index].SortIndex = fCount++;
              this.fParams[index].SortOrder = iGSortOrder.Ascending;
              changedCols[index] = true;
              --num;
            }
            ++colDrawOrder;
          }
        }
        else
        {
          for (int colIndex = 0; colIndex < this.fParams.Length; ++colIndex)
          {
            if (this.fParams[colIndex].SortOrder != iGSortOrder.None && this.fParams[colIndex].SortIndex >= value)
            {
              changedCols[colIndex] = true;
              this.SetNotSorted(colIndex);
            }
          }
        }
        this.fCount = value;
        this.OnColsChanged(new iGSortObject.iGSortedColsChangedEventArgs(changedCols));
        this.OnOrderTypeOrIndexChanged(EventArgs.Empty);
        if (!this.fGrid.fRedraw)
          return;
        this.fGrid.Invalidate();
      }
    }

    /// <summary>Returns an array of integer values representing the columns in the sort (group) criteria.</summary>
    /// <value>An array of integer values representing the columns in the sort (group) criteria.</value>
    public int[] ColArray
    {
      get
      {
        int[] numArray = new int[this.fCount];
        for (int index = 0; index < this.fParams.Length; ++index)
        {
          if (this.fParams[index].SortOrder != iGSortOrder.None)
            numArray[this.fParams[index].SortIndex] = index - 1;
        }
        return numArray;
      }
    }

    internal event iGSortObject.iGSortedColsChangedEventHandler ColsChanged;

    internal event EventHandler OrderTypeOrIndexChanged;

    internal class iGSortedColsChangedEventArgs : EventArgs
    {
      public readonly bool[] ChangedCols;

      public iGSortedColsChangedEventArgs(bool[] changedCols)
      {
        this.ChangedCols = changedCols;
      }
    }

    internal delegate void iGSortedColsChangedEventHandler(object sender, iGSortObject.iGSortedColsChangedEventArgs e);
  }
}
