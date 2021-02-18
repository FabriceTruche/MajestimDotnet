// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCellMouseUpEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.CellMouseUp" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGCellMouseUpEventArgs : EventArgs
  {
    /// <summary>The row index of the cell under the mouse pointer.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the cell under the mouse pointer or -1 if it is a row text cell.</summary>
    public readonly int ColIndex;
    /// <summary>Indicates which mouse button was released.</summary>
    public readonly MouseButtons Button;
    /// <summary>The bounds of the cell under the mouse pointer. The coordinates are relative to the upper left corner of the grid.</summary>
    public readonly Rectangle Bounds;
    /// <summary>The coordinates of the mouse pointer. The coordinates are relative to the upper left corner of the grid.</summary>
    public readonly Point MousePos;
    /// <summary>Indicates which of the modifier keys (SHIFT, CTRL, and ALT) was in a pressed state.</summary>
    public readonly Keys ModifierKeys;
    /// <summary>The control under the mouse pointer if any.</summary>
    public readonly iGElemControl ElemControl;
    /// <summary>Determines whether to perform the default action (select the cell).</summary>
    public bool DoDefault;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCellMouseUpEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the cell under the mouse pointer.</param>
    /// <param name="colIndex">The column index of the cell under the mouse pointer or -1 if it is a row text cell.</param>
    /// <param name="button">Indicates which mouse button was released.</param>
    /// <param name="bounds">The bounds of the cell under the mouse pointer. The coordinates are relative to the upper left corner of the grid.</param>
    /// <param name="mousePos">The coordinates of the mouse pointer. The coordinates are relative to the upper left corner of the grid.</param>
    /// <param name="modifierKeys">Indicates which of the modifier keys (SHIFT, CTRL, and ALT) was in a pressed state.</param>
    /// <param name="elemControl">The control under the mouse pointer if any.</param>
    public iGCellMouseUpEventArgs(int rowIndex, int colIndex, MouseButtons button, Rectangle bounds, Point mousePos, Keys modifierKeys, iGElemControl elemControl)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
      this.Button = button;
      this.Bounds = bounds;
      this.MousePos = mousePos;
      this.ModifierKeys = modifierKeys;
      this.ElemControl = elemControl;
      this.DoDefault = true;
    }
  }
}
