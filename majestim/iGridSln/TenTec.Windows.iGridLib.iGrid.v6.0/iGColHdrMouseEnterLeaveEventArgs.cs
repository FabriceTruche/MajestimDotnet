// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGColHdrMouseEnterLeaveEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.ColHdrMouseEnter" /> and <see cref="E:TenTec.Windows.iGridLib.iGrid.ColHdrMouseLeave" /> events of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGColHdrMouseEnterLeaveEventArgs : EventArgs
  {
    /// <summary>The row index of the column header under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.ColHdrMouseEnter" /> event, or the row index of the previous hot column header for the <see cref="E:TenTec.Windows.iGridLib.iGrid.ColHdrMouseLeave" /> event.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the column header under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.ColHdrMouseEnter" /> event, or the column index of the previous hot column header for the <see cref="E:TenTec.Windows.iGridLib.iGrid.ColHdrMouseLeave" /> event, or -1 if the event is rased for the header area not occupied by a column.</summary>
    public readonly int ColIndex;
    /// <summary>The kind of the column header under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.ColHdrMouseEnter" /> event or the kind of the previous hot column header for the <see cref="E:TenTec.Windows.iGridLib.iGrid.ColHdrMouseLeave" /> event (<see cref="F:TenTec.Windows.iGridLib.iGColHdrKind.Normal" />, <see cref="F:TenTec.Windows.iGridLib.iGColHdrKind.RowText" />, <see cref="F:TenTec.Windows.iGridLib.iGColHdrKind.Extra" />).</summary>
    public readonly iGColHdrKind Kind;
    /// <summary>The bounds of the column header under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.ColHdrMouseEnter" /> event, or the bounds of the previous hot column header for the <see cref="E:TenTec.Windows.iGridLib.iGrid.ColHdrMouseLeave" /> event. The coordinates are relative to the upper left corner of the grid.</summary>
    public readonly Rectangle Bounds;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGColHdrMouseEnterLeaveEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the column header under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.ColHdrMouseEnter" /> event, or the row index of the previous hot column header for the <see cref="E:TenTec.Windows.iGridLib.iGrid.ColHdrMouseLeave" /> event.</param>
    /// <param name="colIndex">The column index of the column header under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.ColHdrMouseEnter" /> event, or the column index of the previous hot column header for the <see cref="E:TenTec.Windows.iGridLib.iGrid.ColHdrMouseLeave" /> event, or -1 if the event is rased for the header area not occupied by a column.</param>
    /// <param name="kind">The kind of the column header under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.ColHdrMouseEnter" /> event or the kind of the previous hot column header for the <see cref="E:TenTec.Windows.iGridLib.iGrid.ColHdrMouseLeave" /> event (<see cref="F:TenTec.Windows.iGridLib.iGColHdrKind.Normal" />, <see cref="F:TenTec.Windows.iGridLib.iGColHdrKind.RowText" />, <see cref="F:TenTec.Windows.iGridLib.iGColHdrKind.Extra" />).</param>
    /// <param name="bounds">The bounds of the column header under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.ColHdrMouseEnter" /> event, or the bounds of the previous hot column header for the <see cref="E:TenTec.Windows.iGridLib.iGrid.ColHdrMouseLeave" /> event. The coordinates are relative to the upper left corner of the grid.</param>
    public iGColHdrMouseEnterLeaveEventArgs(int rowIndex, int colIndex, iGColHdrKind kind, Rectangle bounds)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
      this.Kind = kind;
      this.Bounds = bounds;
    }
  }
}
