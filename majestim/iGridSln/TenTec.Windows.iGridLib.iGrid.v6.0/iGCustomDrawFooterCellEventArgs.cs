// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCustomDrawFooterCellEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.CustomDrawFooterCellBackground" /> and <see cref="E:TenTec.Windows.iGridLib.iGrid.CustomDrawFooterCellForeground" /> events of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGCustomDrawFooterCellEventArgs : EventArgs
  {
    /// <summary>The row index of the footer cell being drawn.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the footer cell being drawn.</summary>
    public readonly int ColIndex;
    /// <summary>The graphics surface to draw the footer cell on.</summary>
    public readonly Graphics Graphics;
    /// <summary>The bounds of the footer cell being drawn. The coordinates are relative to the upper left corner of the grid.</summary>
    public readonly Rectangle Bounds;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCustomDrawFooterCellEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the footer cell being drawn.</param>
    /// <param name="colIndex">The column index of the footer cell being drawn.</param>
    /// <param name="graphics">The graphics surface to draw the footer cell on.</param>
    /// <param name="bounds">The bounds of the footer cell being drawn. The coordinates are relative to the upper left corner of the grid.</param>
    public iGCustomDrawFooterCellEventArgs(int rowIndex, int colIndex, Graphics graphics, Rectangle bounds)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
      this.Graphics = graphics;
      this.Bounds = bounds;
    }
  }
}
