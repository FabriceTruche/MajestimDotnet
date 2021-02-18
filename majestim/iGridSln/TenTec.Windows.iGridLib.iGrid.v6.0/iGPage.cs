// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGPage
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  internal class iGPage
  {
    private iGRowData[] fRowDatas;
    internal int fRowCount;
    private int fColCount;
    public readonly int fRowsCapacity;
    private iGCellData[] fCells;

    public iGPage(int rowsCapacity, int colCount)
    {
      if (rowsCapacity <= 0)
        throw new ArgumentOutOfRangeException();
      this.fRowDatas = new iGRowData[rowsCapacity];
      this.fRowCount = 0;
      this.fRowsCapacity = rowsCapacity;
      this.fColCount = colCount;
      this.fCells = new iGCellData[rowsCapacity * colCount];
    }

    public void RemoveCol(int index, int count)
    {
      if (index >= this.fColCount || index < 0)
        throw new ArgumentOutOfRangeException();
      this.fCells = iGPage.ShortenCellsArray(this.fCells, this.fColCount, index, count);
      this.fColCount = this.fColCount - count;
    }

    private static iGCellData[] ShortenCellsArray(iGCellData[] array, int arrayColCount, int removeIndex, int removeCount)
    {
      iGCellData[] iGcellDataArray = new iGCellData[(arrayColCount - removeCount) * array.Length / arrayColCount];
      int index1 = array.Length - 1;
      int index2 = iGcellDataArray.Length - 1;
      for (; index1 >= 0; --index1)
      {
        int num = index1 % arrayColCount;
        if (num < removeIndex || num >= removeIndex + removeCount)
        {
          iGcellDataArray[index2] = array[index1];
          --index2;
        }
      }
      return iGcellDataArray;
    }

    public static iGCellData[] ExtendCellsArray(iGCellData[] array, int arrayColCount, int colBefore, int insertCount, iGCellData[] defaultValues)
    {
      int num = arrayColCount + insertCount;
      iGCellData iGcellData = new iGCellData((object) null);
      iGCellData[] iGcellDataArray = new iGCellData[num * array.Length / arrayColCount];
      int index1 = array.Length - 1;
      for (int index2 = iGcellDataArray.Length - 1; index2 >= 0; --index2)
      {
        int index3 = index2 % num;
        if (index3 < colBefore || index3 >= colBefore + insertCount)
        {
          iGcellDataArray[index2] = array[index1];
          --index1;
        }
        else
          iGcellDataArray[index2] = defaultValues == null ? iGcellData : defaultValues[index3];
      }
      return iGcellDataArray;
    }

    public void AddCol(int colBefore, int count, iGCellData[] defaultCells)
    {
      this.fCells = iGPage.ExtendCellsArray(this.fCells, this.fColCount, colBefore, count, defaultCells);
      this.fColCount = this.fColCount + count;
    }

    public int AddRows(int count, iGCellData[] defaultRowCells, iGRowData defaultRowData)
    {
      if (!this.CanAddRows(count))
        throw new ArgumentException();
      if (defaultRowCells != null && defaultRowCells.Length != this.fColCount)
        throw new RankException();
      int fRowCount = this.fRowCount;
      for (int index = fRowCount + count - 1; index >= fRowCount; --index)
      {
        if (defaultRowCells != null)
          Array.Copy((Array) defaultRowCells, 0, (Array) this.fCells, index * this.fColCount, this.fColCount);
        this.fRowDatas[index] = defaultRowData;
        this.fRowCount = this.fRowCount + 1;
      }
      return fRowCount;
    }

    public bool CanAddRows(int count)
    {
      if (this.fRowCount + count <= this.fRowsCapacity)
        return count > 0;
      return false;
    }

    public iGCellData GetCellData(int rowIndex, int colIndex)
    {
      return this.fCells[rowIndex * this.fColCount + colIndex];
    }

    public object GetCellValue(int rowIndex, int colIndex)
    {
      return this.fCells[rowIndex * this.fColCount + colIndex].Value;
    }

    public void SetCellData(int rowIndex, int colIndex, iGCellData value)
    {
      this.fCells[rowIndex * this.fColCount + colIndex] = value;
    }

    public void SetCellValue(int rowIndex, int colIndex, object value)
    {
      this.fCells[rowIndex * this.fColCount + colIndex].Value = value;
    }

    public void SetCellAuxValue(int rowIndex, int colIndex, object value)
    {
      this.fCells[rowIndex * this.fColCount + colIndex].AuxValue = value;
    }

    public void SetCellImageIndex(int rowIndex, int colIndex, int value)
    {
      this.fCells[rowIndex * this.fColCount + colIndex].ImageIndex = value;
    }

    public void SetCellStyle(int rowIndex, int colIndex, iGCellStyle value)
    {
      this.fCells[rowIndex * this.fColCount + colIndex].Style = value;
    }

    public void SetCellSpanCols(int rowIndex, int colIndex, int value)
    {
      this.fCells[rowIndex * this.fColCount + colIndex].SpanCols = value;
    }

    public void SetCellSpanRows(int rowIndex, int colIndex, int value)
    {
      this.fCells[rowIndex * this.fColCount + colIndex].SpanRows = value;
    }

    public void SetCellSpanColsRows(int rowIndex, int colIndex, int valueCols, int valueRows)
    {
      int index = rowIndex * this.fColCount + colIndex;
      this.fCells[index].SpanCols = valueCols;
      this.fCells[index].SpanRows = valueRows;
    }

    public iGRowData GetRowData(int rowIndex)
    {
      return this.fRowDatas[rowIndex];
    }

    public void SetRowLevel(int rowIndex, int value)
    {
      this.fRowDatas[rowIndex].Level = value;
    }

    public void SetRowLevelAndExpanded(int rowIndex, int level, bool expanded)
    {
      this.fRowDatas[rowIndex].Level = level;
      this.fRowDatas[rowIndex].Expanded = expanded;
    }

    public void SetRowExpanded(int rowIndex, bool expanded)
    {
      this.fRowDatas[rowIndex].Expanded = expanded;
    }

    public void SetRowType(int rowIndex, iGRowType value)
    {
      this.fRowDatas[rowIndex].Type = value;
    }

    public void SetRowVisibleParentExpanded(int rowIndex, bool value)
    {
      this.fRowDatas[rowIndex].VisibleParentExpanded = value;
    }

    public void SetRowData(int rowIndex, iGRowData value)
    {
      this.fRowDatas[rowIndex] = value;
    }

    public void SetRowKey(int rowIndex, string value)
    {
      this.fRowDatas[rowIndex].Key = value;
    }

    private void CheckValues(object[] values)
    {
      if (values == null)
        throw new ArgumentNullException();
      if (values.Length != this.fColCount)
        throw new RankException();
    }

    public void SetRowValues(int rowIndex, object[] values)
    {
      this.CheckValues(values);
      int num = rowIndex * this.fColCount;
      int index1 = num + this.fColCount - 1;
      int index2 = this.fColCount - 1;
      while (index1 >= num)
      {
        this.fCells[index1].Value = values[index2];
        --index1;
        --index2;
      }
    }

    public void GetRowValues(int rowIndex, object[] values)
    {
      this.CheckValues(values);
      int num = rowIndex * this.fColCount;
      int index1 = num + this.fColCount - 1;
      int index2 = this.fColCount - 1;
      while (index1 >= num)
      {
        values[index2] = this.fCells[index1].Value;
        --index1;
        --index2;
      }
    }

    private void CheckCells(iGCellData[] cells)
    {
      if (cells == null)
        throw new ArgumentNullException();
      if (cells.Length != this.fColCount)
        throw new RankException();
    }

    public void SetRowCells(int rowIndex, iGCellData[] cells)
    {
      this.CheckCells(cells);
      int destinationIndex = rowIndex * this.fColCount;
      Array.Copy((Array) cells, 0, (Array) this.fCells, destinationIndex, this.fColCount);
    }

    public void GetRowCells(int rowIndex, iGCellData[] cells)
    {
      this.CheckCells(cells);
      int num = rowIndex * this.fColCount;
      int index1 = num + this.fColCount - 1;
      int index2 = this.fColCount - 1;
      while (index1 >= num)
      {
        cells[index2] = this.fCells[index1];
        --index1;
        --index2;
      }
    }

    public void SetRowSortable(int rowIndex, bool value)
    {
      this.fRowDatas[rowIndex].Sortable = value;
    }

    public void SetRowSelectable(int rowIndex, bool value)
    {
      this.fRowDatas[rowIndex].Selectable = value;
    }

    public void SetRowTreeButton(int rowIndex, iGTreeButtonState value)
    {
      this.fRowDatas[rowIndex].TreeButton = value;
    }

    public void SetRowCellStyle(int rowIndex, iGCellStyle value)
    {
      this.fRowDatas[rowIndex].CellStyle = value;
    }
  }
}
