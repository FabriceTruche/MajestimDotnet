// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGRowHdrMouseUpEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.RowHdrMouseUp" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGRowHdrMouseUpEventArgs : EventArgs
  {
    /// <summary>The row index of the row header under the mouse pointer.</summary>
    public readonly int RowIndex;
    /// <summary>Indicates which mouse button has been released.</summary>
    public readonly MouseButtons Button;
    /// <summary>The bounds of the row header under the mouse pointer. The coordinates are relative to the upper left corner of the grid.</summary>
    public readonly Rectangle Bounds;
    /// <summary>The coordinates of the mouse pointer. The coordinates are relative to the upper left corner of the grid.</summary>
    public readonly Point MousePos;
    /// <summary>Indicates which of the modifier keys (SHIFT, CTRL, and ALT) was in a pressed state.</summary>
    public readonly Keys ModifierKeys;
    /// <summary>Indicates whether the grid should change the selection.</summary>
    public bool DoDefault;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGRowHdrMouseDownEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the row header under the mouse pointer.</param>
    /// <param name="button">Indicates which mouse button has been released.</param>
    /// <param name="bounds">The bounds of the row header under the mouse pointer. The coordinates are relative to the upper left corner of the grid.</param>
    /// <param name="mousePos">The coordinates of the mouse pointer. The coordinates are relative to the upper left corner of the grid.</param>
    /// <param name="modifierKeys">Indicates which of the modifier keys (SHIFT, CTRL, and ALT) was in a pressed state.</param>
    public iGRowHdrMouseUpEventArgs(int rowIndex, MouseButtons button, Rectangle bounds, Point mousePos, Keys modifierKeys)
    {
      this.RowIndex = rowIndex;
      this.Button = button;
      this.Bounds = bounds;
      this.MousePos = mousePos;
      this.ModifierKeys = modifierKeys;
      this.DoDefault = true;
    }
  }
}
