// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGRowHdrClickEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.RowHdrClick" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGRowHdrClickEventArgs : EventArgs
  {
    /// <summary>The index of the row which header has been clicked.</summary>
    public readonly int RowIndex;
    /// <summary>The bounds of the row header which has been clicked. The coordinates are relative to the upper-left corner of the grid.</summary>
    public readonly Rectangle Bounds;
    /// <summary>Indicates which of the modifier keys (SHIFT, CTRL, and ALT) was in a pressed state.</summary>
    public readonly Keys ModifierKeys;

    /// <summary>Initializes a new instance of the <see cref="E:TenTec.Windows.iGridLib.iGrid.RowHdrClick" /> class.</summary>
    /// <param name="rowIndex">The index of the row which header has been clicked.</param>
    /// <param name="bounds">The bounds of the row header which has been clicked. The coordinates are relative to the upper-left corner of the grid.</param>
    /// <param name="modifierKeys">Indicates which of the modifier keys (SHIFT, CTRL, and ALT) was in a pressed state.</param>
    public iGRowHdrClickEventArgs(int rowIndex, Rectangle bounds, Keys modifierKeys)
    {
      this.RowIndex = rowIndex;
      this.Bounds = bounds;
      this.ModifierKeys = modifierKeys;
    }
  }
}
