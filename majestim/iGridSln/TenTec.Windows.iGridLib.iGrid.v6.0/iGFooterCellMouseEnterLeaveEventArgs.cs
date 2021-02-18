// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGFooterCellMouseEnterLeaveEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.FooterCellMouseEnter" /> and <see cref="E:TenTec.Windows.iGridLib.iGrid.FooterCellMouseLeave" /> events of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGFooterCellMouseEnterLeaveEventArgs : EventArgs
  {
    /// <summary>The row index of the footer cell under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.FooterCellMouseEnter" /> event, or the row index of the previous footer cell for the <see cref="E:TenTec.Windows.iGridLib.iGrid.FooterCellMouseLeave" /> event.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the footer cell under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.FooterCellMouseEnter" /> event or the previous footer cell for the <see cref="E:TenTec.Windows.iGridLib.iGrid.FooterCellMouseLeave" /> event.</summary>
    public readonly int ColIndex;
    /// <summary>The kind of the current footer cell under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.FooterCellMouseEnter" /> event or the previous footer cell under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.FooterCellMouseLeave" /> event (see <see cref="T:TenTec.Windows.iGridLib.iGFooterCellKind" />).</summary>
    public readonly iGFooterCellKind Kind;
    /// <summary>The bounds of the current footer cell under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.FooterCellMouseEnter" /> event or the previous footer cell under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.FooterCellMouseLeave" /> event. The coordinates are relative to the upper left corner of the grid.</summary>
    public readonly Rectangle Bounds;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGFooterCellMouseEnterLeaveEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the current footer cell under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.FooterCellMouseEnter" /> event or the previous footer cell under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.FooterCellMouseLeave" /> event.</param>
    /// <param name="colIndex">The column index of the current footer cell under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.FooterCellMouseEnter" /> event or the previous footer cell under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.FooterCellMouseLeave" /> event.</param>
    /// <param name="kind">The kind of the current footer cell under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.FooterCellMouseEnter" /> event or the previous footer cell under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.FooterCellMouseLeave" /> event (see <see cref="T:TenTec.Windows.iGridLib.iGFooterCellKind" />).</param>
    /// <param name="bounds">The bounds of the current footer cell under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.FooterCellMouseEnter" /> event or the previous footer cell under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.FooterCellMouseLeave" /> event. The coordinates are relative to the upper left corner of the grid.</param>
    public iGFooterCellMouseEnterLeaveEventArgs(int rowIndex, int colIndex, iGFooterCellKind kind, Rectangle bounds)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
      this.Kind = kind;
      this.Bounds = bounds;
    }
  }
}
