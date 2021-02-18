// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGRowHdrMouseEnterLeaveEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.RowHdrMouseEnter" /> and <see cref="E:TenTec.Windows.iGridLib.iGrid.RowHdrMouseLeave" /> events of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGRowHdrMouseEnterLeaveEventArgs : EventArgs
  {
    /// <summary>The row index of the row header under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.RowHdrMouseEnter" /> event, and the row index of the previous hot row header for the <see cref="E:TenTec.Windows.iGridLib.iGrid.RowHdrMouseLeave" /> event.</summary>
    public readonly int RowIndex;
    /// <summary>The bounds of the row header under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.RowHdrMouseEnter" /> event, and the bounds of the previous hot row header for the <see cref="E:TenTec.Windows.iGridLib.iGrid.RowHdrMouseLeave" /> event. The coordinates are relative to the upper left corner of the grid.</summary>
    public readonly Rectangle Bounds;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGRowHdrMouseEnterLeaveEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the row header under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.RowHdrMouseEnter" /> event, and the row index of the previous hot row header for the <see cref="E:TenTec.Windows.iGridLib.iGrid.RowHdrMouseLeave" /> event.</param>
    /// <param name="bounds">The bounds of the row header under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.RowHdrMouseEnter" /> event, and the bounds of the previous hot row header for the <see cref="E:TenTec.Windows.iGridLib.iGrid.RowHdrMouseLeave" /> event. The coordinates are relative to the upper left corner of the grid.</param>
    public iGRowHdrMouseEnterLeaveEventArgs(int rowIndex, Rectangle bounds)
    {
      this.RowIndex = rowIndex;
      this.Bounds = bounds;
    }
  }
}
