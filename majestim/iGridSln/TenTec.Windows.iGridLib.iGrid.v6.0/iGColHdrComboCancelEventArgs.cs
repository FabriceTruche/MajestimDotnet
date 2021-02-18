// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGColHdrComboCancelEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.ColHdrComboCancel" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGColHdrComboCancelEventArgs : EventArgs
  {
    /// <summary>The row index of the edited column header.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the edited column header.</summary>
    public readonly int ColIndex;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGColHdrComboCancelEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the edited column header.</param>
    /// <param name="colIndex">The column index of the edited column header.</param>
    public iGColHdrComboCancelEventArgs(int rowIndex, int colIndex)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
    }
  }
}
