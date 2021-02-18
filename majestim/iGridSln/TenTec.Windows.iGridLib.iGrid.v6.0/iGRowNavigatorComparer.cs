// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGRowNavigatorComparer
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.Collections.Generic;

namespace TenTec.Windows.iGridLib
{
  internal class iGRowNavigatorComparer : IComparer<iGRowNavigator>
  {
    private iGrid fGrid;
    private iGSortData[] fSortData;
    private iGCellStyle fRowStyle;
    private iGCellData[] fCells;

    public iGRowNavigatorComparer(iGrid grid, iGSortData[] sortData, iGCellStyle rowStyle, iGCellData[] cells)
    {
      this.fGrid = grid;
      this.fSortData = sortData;
      this.fRowStyle = rowStyle;
      this.fCells = cells;
    }

    public int CompareCanEqual(iGRowNavigator x, iGRowNavigator y, out int sortIndex)
    {
      iGPage iGpage1 = (iGPage) null;
      iGPage iGpage2 = (iGPage) null;
      if (x.RowIndex != -1)
        iGpage1 = this.fGrid.fPages[x.PageIndex];
      if (y.RowIndex != -1)
        iGpage2 = this.fGrid.fPages[y.PageIndex];
      for (int sortIndex1 = 0; sortIndex1 < this.fSortData.Length; ++sortIndex1)
      {
        iGCellData cellX;
        iGCellStyle rowStyleX;
        if (x.RowIndex == -1)
        {
          cellX = this.fCells[this.fSortData[sortIndex1].ColIndex];
          rowStyleX = this.fRowStyle;
        }
        else
        {
          cellX = iGpage1.GetCellData(x.RowIndex, this.fSortData[sortIndex1].ColIndex);
          rowStyleX = iGpage1.GetRowData(x.RowIndex).CellStyle;
        }
        iGCellData cellY;
        iGCellStyle rowStyleY;
        if (y.RowIndex == -1)
        {
          cellY = this.fCells[this.fSortData[sortIndex1].ColIndex];
          rowStyleY = this.fRowStyle;
        }
        else
        {
          cellY = iGpage2.GetCellData(y.RowIndex, this.fSortData[sortIndex1].ColIndex);
          rowStyleY = iGpage2.GetRowData(y.RowIndex).CellStyle;
        }
        int num = iGCellsComparer.CompareCells(this.fGrid, this.fSortData, sortIndex1, cellX, cellY, rowStyleX, rowStyleY, x.RowIndex, y.RowIndex, x.RowIndex, y.RowIndex, false, false);
        if (num != 0)
        {
          sortIndex = sortIndex1;
          return num;
        }
      }
      sortIndex = 0;
      return 0;
    }

    public int Compare(iGRowNavigator x, iGRowNavigator y)
    {
      int sortIndex;
      int num = this.CompareCanEqual(x, y, out sortIndex);
      if (num == 0)
        num = x.RowIndex != -1 ? 1 : -1;
      return num;
    }
  }
}
