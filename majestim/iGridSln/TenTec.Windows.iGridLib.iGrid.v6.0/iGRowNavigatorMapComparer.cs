// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGRowNavigatorMapComparer
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.Collections.Generic;

namespace TenTec.Windows.iGridLib
{
  internal class iGRowNavigatorMapComparer : IComparer<iGRowNavigatorMapItem>
  {
    private iGrid fGrid;
    private iGSortData[] fSortData;
    private bool fCompareGroupValues;

    public iGRowNavigatorMapComparer(iGrid grid, iGSortData[] sortData, bool compareGroupValues)
    {
      this.fGrid = grid;
      this.fSortData = sortData;
      this.fCompareGroupValues = compareGroupValues;
    }

    public int Compare(iGRowNavigatorMapItem x, iGRowNavigatorMapItem y)
    {
      if (x.Navigator.PageIndex == y.Navigator.PageIndex && x.Navigator.RowIndex == y.Navigator.RowIndex)
        return 0;
      iGPage fPage1 = this.fGrid.fPages[x.Navigator.PageIndex];
      iGPage fPage2 = this.fGrid.fPages[y.Navigator.PageIndex];
      int num = 0;
      for (int sortIndex = 0; sortIndex < this.fSortData.Length; ++sortIndex)
      {
        if (!this.fSortData[sortIndex].IsGrouped && this.fSortData[sortIndex].Type == iGSortType.ByValue)
        {
          int colIndex = this.fSortData[sortIndex].ColIndex;
          num = iGManagerCompare.CompareObjects(fPage1.GetCellValue(x.Navigator.RowIndex, colIndex), fPage2.GetCellValue(y.Navigator.RowIndex, colIndex));
          if (this.fSortData[sortIndex].Order == iGSortOrder.Descending)
            num = -num;
        }
        else
        {
          iGCellData cellData1 = fPage1.GetCellData(x.Navigator.RowIndex, this.fSortData[sortIndex].ColIndex);
          iGCellData cellData2 = fPage2.GetCellData(y.Navigator.RowIndex, this.fSortData[sortIndex].ColIndex);
          iGCellStyle cellStyle1 = fPage1.GetRowData(x.Navigator.RowIndex).CellStyle;
          iGCellStyle cellStyle2 = fPage2.GetRowData(y.Navigator.RowIndex).CellStyle;
          num = iGCellsComparer.CompareCells(this.fGrid, this.fSortData, sortIndex, cellData1, cellData2, cellStyle1, cellStyle2, x.InitialRowIndex, y.InitialRowIndex, x.InitialRowIndex, y.InitialRowIndex, false, this.fCompareGroupValues);
        }
        if (num != 0)
          return num;
      }
      return num;
    }
  }
}
