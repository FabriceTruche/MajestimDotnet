// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCustomSortEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.CustomSort" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGCustomSortEventArgs : EventArgs
  {
    /// <summary>The value of the first cell being compared.</summary>
    public readonly object Value1;
    /// <summary>The value of the second cell being compared.</summary>
    public readonly object Value2;
    /// <summary>The result of the comparison of the cells.</summary>
    public int Result;
    /// <summary>Specifies whether the column that is used for sorting is in the group box (is grouped).</summary>
    public readonly bool IsGrouped;
    /// <summary>The index of the column used for sorting.</summary>
    public readonly int ColIndex;
    /// <summary>The row index of the first cell being compared.</summary>
    public readonly int RowIndex1;
    /// <summary>The row index of the second cell being compared.</summary>
    public readonly int RowIndex2;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCustomSortEventArgs" /> class.</summary>
    /// <param name="value1">The value of the first cell being compared.</param>
    /// <param name="value2">The value of the second cell being compared.</param>
    /// <param name="isGrouped">Specifies whether the column that is used for sorting is in the group box (is grouped).</param>
    /// <param name="colIndex">The index of the column used for sorting.</param>
    /// <param name="rowIndex1">The row index of the first cell being compared.</param>
    /// <param name="rowIndex2">The row index of the second cell being compared.</param>
    public iGCustomSortEventArgs(object value1, object value2, bool isGrouped, int colIndex, int rowIndex1, int rowIndex2)
    {
      this.Value1 = value1;
      this.Value2 = value2;
      this.Result = 0;
      this.IsGrouped = isGrouped;
      this.ColIndex = colIndex;
      this.RowIndex1 = rowIndex1;
      this.RowIndex2 = rowIndex2;
    }
  }
}
