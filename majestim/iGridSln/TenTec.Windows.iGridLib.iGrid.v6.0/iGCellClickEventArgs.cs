// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCellClickEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.CellClick" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGCellClickEventArgs : EventArgs
  {
    /// <summary>The row index of the cell that has been clicked.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the cell that has been clicked or -1 if it is a row text cell.</summary>
    public readonly int ColIndex;
    /// <summary>The bounds of the cell that has been clicked. The coordinates are relative to the upper left corner of the grid.</summary>
    public readonly Rectangle Bounds;
    /// <summary>Indicates which of the modifier keys (SHIFT, CTRL, and ALT) was in a pressed state.</summary>
    public readonly Keys ModifierKeys;
    /// <summary>The control that has been clicked if any.</summary>
    public readonly iGElemControl ElemControl;
    /// <summary>Determines whether to perform the default action.</summary>
    public bool DoDefault;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCellClickEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the cell that has been clicked.</param>
    /// <param name="colIndex">The column index of the cell that has been clicked or -1 if it is a row text cell.</param>
    /// <param name="bounds">The bounds of the cell that has been clicked. The coordinates are relative to the upper left corner of the grid.</param>
    /// <param name="modifierKeys">Indicates which of the modifier keys (SHIFT, CTRL, and ALT) was in a pressed state.</param>
    /// <param name="elemControl">The control that has been clicked if any.</param>
    public iGCellClickEventArgs(int rowIndex, int colIndex, Rectangle bounds, Keys modifierKeys, iGElemControl elemControl)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
      this.Bounds = bounds;
      this.ModifierKeys = modifierKeys;
      this.ElemControl = elemControl;
      this.DoDefault = true;
    }
  }
}
