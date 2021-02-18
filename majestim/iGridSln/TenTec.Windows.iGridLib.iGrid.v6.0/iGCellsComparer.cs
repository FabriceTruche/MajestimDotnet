// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCellsComparer
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  internal class iGCellsComparer
  {
    private static int CompareCellBySortCriterion(iGrid grid, iGSortData sortData, iGCellData cellX, iGCellData cellY, iGCellStyle rowStyleX, iGCellStyle rowStyleY, int rowIndexX, int rowIndexY)
    {
      int num1 = 0;
      switch (sortData.Type)
      {
        case iGSortType.BySelected:
          if (rowIndexX == -1)
          {
            num1 = 1;
            break;
          }
          if (rowIndexY == -1)
          {
            num1 = -1;
            break;
          }
          bool selectedInternal1;
          bool selectedInternal2;
          if (grid.fRowMode)
          {
            selectedInternal1 = grid.GetRowSelectedInternal(rowIndexX);
            selectedInternal2 = grid.GetRowSelectedInternal(rowIndexY);
          }
          else
          {
            selectedInternal1 = grid.GetCellSelectedInternal(rowIndexX, sortData.ColIndex);
            selectedInternal2 = grid.GetCellSelectedInternal(rowIndexY, sortData.ColIndex);
          }
          num1 = selectedInternal2.CompareTo(selectedInternal1);
          break;
        case iGSortType.Custom:
          iGCustomSortEventArgs e = new iGCustomSortEventArgs(cellX.Value, cellY.Value, sortData.IsGrouped, sortData.ColIndex - 1, rowIndexX, rowIndexY);
          grid.OnCustomSort(e);
          num1 = e.Result;
          break;
        case iGSortType.ByBackColor:
          iGCellStyle cellStyle1 = grid.GetColDataInternal(sortData.ColIndex).CellStyle;
          iGControlState state1 = !grid.Enabled || !grid.GetPropFromStyles_Enabled(cellX.Style, rowStyleX, cellStyle1) ? iGControlState.Disabled : iGControlState.Normal;
          iGControlState state2 = !grid.Enabled || !grid.GetPropFromStyles_Enabled(cellY.Style, rowStyleY, cellStyle1) ? iGControlState.Disabled : iGControlState.Normal;
          num1 = grid.GetUniCellBackColorNoSelected(iGGridSection.Cells, rowIndexX, sortData.ColIndex, (iGStyleBase) cellX.Style, (iGStyleBase) rowStyleX, (iGStyleBase) cellStyle1, state1, false, false, false, false).ToArgb().CompareTo(grid.GetUniCellBackColorNoSelected(iGGridSection.Cells, rowIndexY, sortData.ColIndex, (iGStyleBase) cellY.Style, (iGStyleBase) rowStyleY, (iGStyleBase) cellStyle1, state2, false, false, false, false).ToArgb());
          break;
        case iGSortType.ByFont:
          iGCellStyle cellStyle2 = grid.GetColDataInternal(sortData.ColIndex).CellStyle;
          iGControlState state3 = !grid.Enabled || !grid.GetPropFromStyles_Enabled(cellX.Style, rowStyleX, cellStyle2) ? iGControlState.Disabled : iGControlState.Normal;
          iGControlState state4 = !grid.Enabled || !grid.GetPropFromStyles_Enabled(cellY.Style, rowStyleY, cellStyle2) ? iGControlState.Disabled : iGControlState.Normal;
          Font uniCellFont1 = grid.GetUniCellFont(iGGridSection.Cells, rowIndexX, sortData.ColIndex, (iGStyleBase) cellX.Style, (iGStyleBase) rowStyleX, (iGStyleBase) cellStyle2, state3, false, false, false, false);
          Font uniCellFont2 = grid.GetUniCellFont(iGGridSection.Cells, rowIndexY, sortData.ColIndex, (iGStyleBase) cellY.Style, (iGStyleBase) rowStyleY, (iGStyleBase) cellStyle2, state4, false, false, false, false);
          num1 = string.CompareOrdinal(uniCellFont1.FontFamily.Name, uniCellFont2.FontFamily.Name);
          if (num1 == 0)
          {
            num1 = uniCellFont1.Size.CompareTo(uniCellFont2.Size);
            if (num1 == 0)
            {
              FontStyle style1 = uniCellFont1.Style;
              FontStyle style2 = uniCellFont2.Style;
              int num2 = (int) (style1 & FontStyle.Bold);
              num1 = num2.CompareTo((int) (style2 & FontStyle.Bold));
              if (num1 == 0)
              {
                num2 = (int) (style1 & FontStyle.Italic);
                num1 = num2.CompareTo((int) (style2 & FontStyle.Italic));
                if (num1 == 0)
                {
                  num2 = (int) (style1 & FontStyle.Underline);
                  num1 = num2.CompareTo((int) (style2 & FontStyle.Underline));
                  if (num1 == 0)
                  {
                    num2 = (int) (style1 & FontStyle.Strikeout);
                    num1 = num2.CompareTo((int) (style2 & FontStyle.Strikeout));
                    break;
                  }
                  break;
                }
                break;
              }
              break;
            }
            break;
          }
          break;
        case iGSortType.ByImageIndex:
          iGCellStyle cellStyle3 = grid.GetColDataInternal(sortData.ColIndex).CellStyle;
          num1 = grid.GetUniCellImageIndexInternal(iGGridSection.Cells, rowIndexX, sortData.ColIndex, cellX.Value, cellX.AuxValue, cellX.ImageIndex, (iGStyleBase) cellX.Style, (iGStyleBase) rowStyleX, (iGStyleBase) cellStyle3).CompareTo(grid.GetUniCellImageIndexInternal(iGGridSection.Cells, rowIndexY, sortData.ColIndex, cellY.Value, cellY.AuxValue, cellY.ImageIndex, (iGStyleBase) cellY.Style, (iGStyleBase) rowStyleY, (iGStyleBase) cellStyle3));
          break;
        case iGSortType.ByForeColor:
          iGCellStyle cellStyle4 = grid.GetColDataInternal(sortData.ColIndex).CellStyle;
          iGControlState state5 = !grid.Enabled || !grid.GetPropFromStyles_Enabled(cellX.Style, rowStyleX, cellStyle4) ? iGControlState.Disabled : iGControlState.Normal;
          iGControlState state6 = !grid.Enabled || !grid.GetPropFromStyles_Enabled(cellY.Style, rowStyleY, cellStyle4) ? iGControlState.Disabled : iGControlState.Normal;
          num1 = grid.GetUniCellForeColorNoSelected(iGGridSection.Cells, rowIndexX, sortData.ColIndex, (iGStyleBase) cellX.Style, (iGStyleBase) rowStyleX, (iGStyleBase) cellStyle4, state5, false, false, false, false).ToArgb().CompareTo(grid.GetUniCellForeColorNoSelected(iGGridSection.Cells, rowIndexY, sortData.ColIndex, (iGStyleBase) cellY.Style, (iGStyleBase) rowStyleY, (iGStyleBase) cellStyle4, state6, false, false, false, false).ToArgb());
          break;
        case iGSortType.ByValue:
          num1 = iGManagerCompare.CompareObjects(cellX.Value, cellY.Value);
          break;
        case iGSortType.ByAuxValue:
          num1 = iGManagerCompare.CompareObjects(cellX.AuxValue, cellY.AuxValue);
          break;
        case iGSortType.ByText:
        case iGSortType.ByTextNoCase:
          iGCellStyle cellStyle5 = grid.GetColDataInternal(sortData.ColIndex).CellStyle;
          num1 = string.Compare(grid.GetUniCellTextInternal(iGGridSection.Cells, rowIndexX, sortData.ColIndex, cellX.Value, cellX.AuxValue, cellX.ImageIndex, (iGStyleBase) cellX.Style, (iGStyleBase) rowStyleX, (iGStyleBase) cellStyle5), grid.GetUniCellTextInternal(iGGridSection.Cells, rowIndexY, sortData.ColIndex, cellY.Value, cellY.AuxValue, cellY.ImageIndex, (iGStyleBase) cellY.Style, (iGStyleBase) rowStyleY, (iGStyleBase) cellStyle5), sortData.Type == iGSortType.ByTextNoCase);
          break;
      }
      if (sortData.Order == iGSortOrder.Descending)
        num1 = -num1;
      return num1;
    }

    public static int CompareCells(iGrid grid, iGSortData[] sortData, int sortIndex, iGCellData cellX, iGCellData cellY, iGCellStyle rowStyleX, iGCellStyle rowStyleY, int rowIndexX, int rowIndexY, int rowIndexXOld, int rowIndexYOld, bool compareOnlyGroupValues, bool compareGroupValues)
    {
      if (!sortData[sortIndex].IsGrouped)
        return iGCellsComparer.CompareCellBySortCriterion(grid, sortData[sortIndex], cellX, cellY, rowStyleX, rowStyleY, rowIndexX, rowIndexY);
      if (sortData[sortIndex].CustomGrouping)
      {
        if (compareGroupValues)
        {
          int num = iGManagerCompare.CompareObjects(sortData[sortIndex].CustomGroupValues[rowIndexXOld], sortData[sortIndex].CustomGroupValues[rowIndexYOld]);
          if (compareOnlyGroupValues || num != 0)
          {
            if (sortData[sortIndex].Order == iGSortOrder.Descending)
              num = -num;
            return num;
          }
          if (sortIndex == sortData.Length - 1)
            return iGCellsComparer.CompareCellBySortCriterion(grid, sortData[sortIndex], cellX, cellY, rowStyleX, rowStyleY, rowIndexX, rowIndexY);
          return 0;
        }
        if (sortIndex == sortData.Length - 1)
          return iGCellsComparer.CompareCellBySortCriterion(grid, sortData[sortIndex], cellX, cellY, rowStyleX, rowStyleY, rowIndexX, rowIndexY);
        return 0;
      }
      if (compareGroupValues)
        return iGCellsComparer.CompareCellBySortCriterion(grid, sortData[sortIndex], cellX, cellY, rowStyleX, rowStyleY, rowIndexX, rowIndexY);
      return 0;
    }
  }
}
