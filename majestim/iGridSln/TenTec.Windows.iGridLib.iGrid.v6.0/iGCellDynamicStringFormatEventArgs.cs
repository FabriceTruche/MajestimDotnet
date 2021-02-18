// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCellDynamicStringFormatEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.CellDynamicStringFormat" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGCellDynamicStringFormatEventArgs : EventArgs
  {
    /// <summary>The row index of the cell which string format is being requested.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the cell which string format is being requested, or -1 if it is a row text cell.</summary>
    public readonly int ColIndex;
    /// <summary>The string format used to display the cell's text.</summary>
    public StringFormat StringFormat;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCellDynamicStringFormatEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the cell which string format is being requested.</param>
    /// <param name="colIndex">The column index of the cell which string format is being requested, or -1 if it is a row text cell.</param>
    /// <param name="stringFormat">The string format used to display the cell's text.</param>
    public iGCellDynamicStringFormatEventArgs(int rowIndex, int colIndex, StringFormat stringFormat)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
      this.StringFormat = stringFormat;
    }
  }
}
