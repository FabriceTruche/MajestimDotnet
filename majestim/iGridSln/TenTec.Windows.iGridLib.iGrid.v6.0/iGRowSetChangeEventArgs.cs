// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGRowSetChangeEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.RowsAdded" />, <see cref="E:TenTec.Windows.iGridLib.iGrid.RowsRemoving" /> and <see cref="E:TenTec.Windows.iGridLib.iGrid.RowsRemoved" /> events of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGRowSetChangeEventArgs : EventArgs
  {
    /// <summary>The index of the first row in the current row set change.</summary>
    public readonly int RowIndex;
    /// <summary>The number of rows in the current row set change.</summary>
    public readonly int RowCount;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGRowSetChangeEventArgs" /> class.</summary>
    /// <param name="rowIndex">The index of the first row in the current row set change.</param>
    /// <param name="rowCount">The number of rows in the current row set change.</param>
    public iGRowSetChangeEventArgs(int rowIndex, int rowCount)
    {
      this.RowIndex = rowIndex;
      this.RowCount = rowCount;
    }
  }
}
