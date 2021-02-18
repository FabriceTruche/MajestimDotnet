// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGColHdrMouseMoveEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.ColHdrMouseMove" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGColHdrMouseMoveEventArgs : EventArgs
  {
    /// <summary>The row index of the column header under the mouse pointer.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the column header under the mouse pointer, or -1 if the mouse pointer is over the header area not occupied by a column.</summary>
    public readonly int ColIndex;
    /// <summary>Determines the kind of the column header under the mouse pointer (<see cref="F:TenTec.Windows.iGridLib.iGColHdrKind.Normal" />, <see cref="F:TenTec.Windows.iGridLib.iGColHdrKind.RowText" />, <see cref="F:TenTec.Windows.iGridLib.iGColHdrKind.Extra" />).</summary>
    public readonly iGColHdrKind Kind;
    /// <summary>Indicates which mouse button was pressed.</summary>
    public readonly MouseButtons Button;
    /// <summary>The bounds of the column header under the mouse pointer. The coordinates are relative to the upper left corner of the grid.</summary>
    public readonly Rectangle Bounds;
    /// <summary>The coordinates of the mouse pointer. The coordinates are relative to the upper left corner of the grid.</summary>
    public readonly Point MousePos;
    /// <summary>Indicates which of the modifier keys (SHIFT, CTRL, and ALT) was in a pressed state.</summary>
    public readonly Keys ModifierKeys;
    /// <summary>The elementary cell control (like the combo button) under the mouse pointer.</summary>
    public readonly iGElemControl ElemControl;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGColHdrMouseMoveEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the column header under the mouse pointer.</param>
    /// <param name="colIndex">The column index of the column header under the mouse pointer, or -1 if the mouse pointer is over the header area not occupied by a column.</param>
    /// <param name="kind">The kind of the column header under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.ColHdrMouseEnter" /> event or the kind of the previous hot column header for the <see cref="E:TenTec.Windows.iGridLib.iGrid.ColHdrMouseLeave" /> event (<see cref="F:TenTec.Windows.iGridLib.iGColHdrKind.Normal" />, <see cref="F:TenTec.Windows.iGridLib.iGColHdrKind.RowText" />, <see cref="F:TenTec.Windows.iGridLib.iGColHdrKind.Extra" />).</param>
    /// <param name="button">Indicates which mouse button was pressed.</param>
    /// <param name="bounds">The bounds of the column header under the mouse pointer. The coordinates are relative to the upper left corner of the grid.</param>
    /// <param name="mousePos">The coordinates of the mouse pointer. The coordinates are relative to the upper left corner of the grid.</param>
    /// <param name="modifierKeys">Indicates which of the modifier keys (SHIFT, CTRL, and ALT) was in a pressed state.</param>
    /// <param name="elemControl">The elementary cell control (like the combo button) under the mouse pointer.</param>
    public iGColHdrMouseMoveEventArgs(int rowIndex, int colIndex, iGColHdrKind kind, MouseButtons button, Rectangle bounds, Point mousePos, Keys modifierKeys, iGElemControl elemControl)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
      this.Kind = kind;
      this.Button = button;
      this.Bounds = bounds;
      this.MousePos = mousePos;
      this.ModifierKeys = modifierKeys;
      this.ElemControl = elemControl;
    }
  }
}
