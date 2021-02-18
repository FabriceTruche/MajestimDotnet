// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCustomDrawEllipsisButtonEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.CustomDrawCellEllipsisButtonBackground" /> and <see cref="E:TenTec.Windows.iGridLib.iGrid.CustomDrawCellEllipsisButtonForeground" /> events of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGCustomDrawEllipsisButtonEventArgs : EventArgs
  {
    /// <summary>The row index of the cell in which the ellipsis button is drawn.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the cell in which the ellipsis button is drawn or -1 if it is a row text column.</summary>
    public readonly int ColIndex;
    /// <summary>The graphics surface to draw the ellipsis button on.</summary>
    public readonly Graphics Graphics;
    /// <summary>The bounds of the ellipsis button being drawn. The coordinates are relative to the upper left corned of the grid.</summary>
    public readonly Rectangle Bounds;
    /// <summary>The state of the ellipsis button being drawn. Note that the <see cref="F:TenTec.Windows.iGridLib.iGControlState.Pressed" /> state is not supported for the ellipsis buttons as the pressed ellipsis button is always drawn as hot and the <see cref="F:TenTec.Windows.iGridLib.iGControlState.HotPressed" /> state is used instead.</summary>
    public readonly iGControlState State;
    /// <summary>Indicates whether to perform default drawing of the ellipsis button.</summary>
    public bool DoDefault;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCustomDrawEllipsisButtonEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the cell in which the ellipsis button is drawn.</param>
    /// <param name="colIndex">The column index of the cell in which the ellipsis button is drawn.</param>
    /// <param name="graphics">The graphics surface to draw the ellipsis button on.</param>
    /// <param name="bounds">The bounds of the ellipsis button being drawn. The coordinates are relative to the upper left corned of the grid.</param>
    /// <param name="state">The state of the ellipsis button being drawn. Note that the <see cref="F:TenTec.Windows.iGridLib.iGControlState.Pressed" /> state is not supported for the ellipsis buttons as the pressed ellipsis button is always drawn as hot and the <see cref="F:TenTec.Windows.iGridLib.iGControlState.HotPressed" /> state is used instead.</param>
    public iGCustomDrawEllipsisButtonEventArgs(int rowIndex, int colIndex, Graphics graphics, Rectangle bounds, iGControlState state)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
      this.Graphics = graphics;
      this.Bounds = bounds;
      this.State = state;
      this.DoDefault = true;
    }
  }
}
