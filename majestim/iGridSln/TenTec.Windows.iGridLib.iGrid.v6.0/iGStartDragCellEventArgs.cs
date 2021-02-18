// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGStartDragCellEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.StartDragCell" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGStartDragCellEventArgs : EventArgs
  {
    /// <summary>The row index of the cell being dragged.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the cell being dragged, or -1 if it is a row text cell.</summary>
    public readonly int ColIndex;
    /// <summary>The mouse button which is currently pressed.</summary>
    public readonly MouseButtons Button;
    /// <summary>The position of the mouse pointer. The coordinates are relative to the upper left corner of the grid.</summary>
    public readonly Point MousePos;
    /// <summary>Indicates which of the modifier keys (SHIFT, CTRL, and ALT) are in a pressed state.</summary>
    public readonly Keys ModifierKeys;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGStartDragCellEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the cell being dragged.</param>
    /// <param name="colIndex">The column index of the cell being dragged, or -1 if it is a row text cell.</param>
    /// <param name="button">The mouse button which is currently pressed.</param>
    /// <param name="mousePos">The position of the mouse pointer. The coordinates are relative to the upper left corner of the grid.</param>
    /// <param name="modifierKeys">Indicates which of the modifier keys (SHIFT, CTRL, and ALT) are in a pressed state.</param>
    public iGStartDragCellEventArgs(int rowIndex, int colIndex, MouseButtons button, Point mousePos, Keys modifierKeys)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
      this.Button = button;
      this.MousePos = mousePos;
      this.ModifierKeys = modifierKeys;
    }
  }
}
