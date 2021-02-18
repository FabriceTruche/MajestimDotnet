// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGSelectionChangingEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.SelectionChanging" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGSelectionChangingEventArgs : EventArgs
  {
    /// <summary>The row index of the first selected cell (the top left, or right in the right-to-left mode, cell in the selection).</summary>
    public readonly int RowIndex1;
    /// <summary>The column index of the first selected cell (the top left, or right in the right-to-left mode, cell in the selection) or -1 if it is a row text cell.</summary>
    public readonly int ColIndex1;
    /// <summary>The row index of the last selected cell (the bottom right, or left in the right-to-left mode, cell in the selection).</summary>
    public readonly int RowIndex2;
    /// <summary>The column index of the last selected cell (the bottom right, or left in the right-to-left mode, cell in the selection)  or -1 if it is a row text cell.</summary>
    public readonly int ColIndex2;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGSelectionChangingEventArgs" /> class.</summary>
    /// <param name="rowIndex1">The row index of the first selected cell (the top left, or right in the right-to-left mode, cell in the selection).</param>
    /// <param name="colIndex1">The column index of the first selected cell (the top left, or right in the right-to-left mode, cell in the selection) or -1 if it is a row text cell.</param>
    /// <param name="rowIndex2">The row index of the last selected cell (the bottom right, or left in the right-to-left mode, cell in the selection).</param>
    /// <param name="colIndex2">The column index of the last selected cell (the bottom right, or left in the right-to-left mode, cell in the selection) or -1 if it is a row text cell.</param>
    public iGSelectionChangingEventArgs(int rowIndex1, int colIndex1, int rowIndex2, int colIndex2)
    {
      this.RowIndex1 = rowIndex1;
      this.ColIndex1 = colIndex1;
      this.RowIndex2 = rowIndex2;
      this.ColIndex2 = colIndex2;
    }
  }
}
