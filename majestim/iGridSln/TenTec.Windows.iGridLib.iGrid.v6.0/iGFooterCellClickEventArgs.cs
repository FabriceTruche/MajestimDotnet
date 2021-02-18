// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGFooterCellClickEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.FooterCellClick" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGFooterCellClickEventArgs : EventArgs
  {
    /// <summary>The row index of the footer cell that has been clicked.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the footer cell that has been clicked.</summary>
    public readonly int ColIndex;
    /// <summary>The kind of the footer cell (see the <see cref="T:TenTec.Windows.iGridLib.iGFooterCellKind" /> enumeration).</summary>
    public readonly iGFooterCellKind Kind;
    /// <summary>The bounds of the footer cell that has been clicked. The coordinates are relative to the upper left corner of the grid.</summary>
    public readonly Rectangle Bounds;
    /// <summary>Indicates which of the modifier keys (SHIFT, CTRL, and ALT) was in a pressed state.</summary>
    public readonly Keys ModifierKeys;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGFooterCellClickEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the footer cell that has been clicked.</param>
    /// <param name="colIndex">The column index of the footer cell that has been clicked.</param>
    /// <param name="kind">The kind of the footer cell (see the <see cref="T:TenTec.Windows.iGridLib.iGFooterCellKind" /> enumeration).</param>
    /// <param name="bounds">The bounds of the footer cell that has been clicked. The coordinates are relative to the upper left corner of the grid.</param>
    /// <param name="modifierKeys">Indicates which of the modifier keys (SHIFT, CTRL, and ALT) was in a pressed state.</param>
    public iGFooterCellClickEventArgs(int rowIndex, int colIndex, iGFooterCellKind kind, Rectangle bounds, Keys modifierKeys)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
      this.Kind = kind;
      this.Bounds = bounds;
      this.ModifierKeys = modifierKeys;
    }
  }
}
