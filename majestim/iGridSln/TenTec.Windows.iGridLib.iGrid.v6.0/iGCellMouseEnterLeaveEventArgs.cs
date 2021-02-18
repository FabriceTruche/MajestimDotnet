// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCellMouseEnterLeaveEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.CellMouseEnter" /> and <see cref="E:TenTec.Windows.iGridLib.iGrid.CellMouseLeave" /> events of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGCellMouseEnterLeaveEventArgs : EventArgs
  {
    /// <summary>The row index of the cell under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.CellMouseEnter" /> event, and the row index of the previous hot cell for the <see cref="E:TenTec.Windows.iGridLib.iGrid.CellMouseLeave" /> event.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the cell under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.CellMouseEnter" /> event, and the column index of the previous hot cell for the <see cref="E:TenTec.Windows.iGridLib.iGrid.CellMouseLeave" /> event. If the cell is a row text cell its column index is -1.</summary>
    public readonly int ColIndex;
    /// <summary>The bounds of the cell under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.CellMouseEnter" /> event, and the bounds of the previous hot cell for the <see cref="E:TenTec.Windows.iGridLib.iGrid.CellMouseLeave" /> event. The coordinates are relative to the upper left corner of the grid.</summary>
    public readonly Rectangle Bounds;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCellMouseEnterLeaveEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the cell that the event is responding to.</param>
    /// <param name="colIndex">The column index of the cell that the event is responding to.</param>
    /// <param name="bounds">The bounds of the cell that the event is responding to. The coordinates are relative to the upper left corner of the grid.</param>
    public iGCellMouseEnterLeaveEventArgs(int rowIndex, int colIndex, Rectangle bounds)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
      this.Bounds = bounds;
    }
  }
}
