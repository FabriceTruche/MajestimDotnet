// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCustomDrawComboButtonEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.CustomDrawCellComboButton" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGCustomDrawComboButtonEventArgs : EventArgs
  {
    /// <summary>The row index of the cell in which the combo button is drawn.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the cell in which the combo button is drawn.</summary>
    public readonly int ColIndex;
    /// <summary>The graphics surface to draw the combo button on.</summary>
    public readonly Graphics Graphics;
    /// <summary>The bounds of the combo button being drawn. The coordinates are relative to the upper left corner of the grid.</summary>
    public readonly Rectangle Bounds;
    /// <summary>The state of the combo button.</summary>
    public readonly iGControlState State;
    /// <summary>A Boolean value that indicates whether to use custom drawing for the combo button.</summary>
    public bool DoDefault;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCustomDrawComboButtonEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the cell in which the combo button is drawn.</param>
    /// <param name="colIndex">The column index of the cell in which the combo button is drawn.</param>
    /// <param name="graphics">The graphics surface to draw the combo button on.</param>
    /// <param name="bounds">The bounds of the combo button being drawn. The coordinates are relative to the upper left corner of the grid.</param>
    /// <param name="state">The state of the combo button.</param>
    public iGCustomDrawComboButtonEventArgs(int rowIndex, int colIndex, Graphics graphics, Rectangle bounds, iGControlState state)
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
