// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCustomDrawColHdrEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.CustomDrawColHdrBackground" /> and <see cref="E:TenTec.Windows.iGridLib.iGrid.CustomDrawColHdrForeground" /> events of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGCustomDrawColHdrEventArgs : EventArgs
  {
    /// <summary>The row index of the column header being drawn.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the column header being drawn.</summary>
    public readonly int ColIndex;
    /// <summary>The graphics surface to draw the column header on.</summary>
    public readonly Graphics Graphics;
    /// <summary>The bounds of the column header being drawn. The coordinates are relative to the upper left corner of the grid.</summary>
    public readonly Rectangle Bounds;
    /// <summary>The state of the column header being drawn. Note that the <see cref="F:TenTec.Windows.iGridLib.iGControlState.HotPressed" /> state is not supported for the column headers.</summary>
    public readonly iGControlState State;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCustomDrawColHdrEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the column header being drawn.</param>
    /// <param name="colIndex">The column index of the column header being drawn.</param>
    /// <param name="graphics">The graphics surface to draw the column header on.</param>
    /// <param name="bounds">The bounds of the column header being drawn. The coordinates are relative to the upper left corner of the grid.</param>
    /// <param name="state">The state of the column header being drawn.</param>
    public iGCustomDrawColHdrEventArgs(int rowIndex, int colIndex, Graphics graphics, Rectangle bounds, iGControlState state)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
      this.Graphics = graphics;
      this.Bounds = bounds;
      this.State = state;
    }
  }
}
