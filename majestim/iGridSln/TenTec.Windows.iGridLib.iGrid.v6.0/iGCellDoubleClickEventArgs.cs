// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCellDoubleClickEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.CellDoubleClick" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGCellDoubleClickEventArgs : EventArgs
  {
    /// <summary>The row index of the cell that has been double clicked.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the cell that has been double clicked or -1 if it is a row text cell.</summary>
    public readonly int ColIndex;
    /// <summary>The bounds of the cell that has been double clicked. The coordinates are relative to the upper left corner of the grid.</summary>
    public readonly Rectangle Bounds;
    /// <summary>The control that has been double clicked if any.</summary>
    public readonly iGElemControl ElemControl;
    /// <summary>Determines whether to perform the default action (expand/collapse the row if its tree button is visible).</summary>
    public bool DoDefault;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCellDoubleClickEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the cell that has been double clicked.</param>
    /// <param name="colIndex">The column index of the cell that has been double clicked or -1 if it is a row text cell.</param>
    /// <param name="bounds">The bounds of the cell that has been double clicked. The coordinates are relative to the upper left corner of the grid.</param>
    /// <param name="elemControl">The control that has been clicked if any.</param>
    public iGCellDoubleClickEventArgs(int rowIndex, int colIndex, Rectangle bounds, iGElemControl elemControl)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
      this.Bounds = bounds;
      this.ElemControl = elemControl;
      this.DoDefault = true;
    }
  }
}
