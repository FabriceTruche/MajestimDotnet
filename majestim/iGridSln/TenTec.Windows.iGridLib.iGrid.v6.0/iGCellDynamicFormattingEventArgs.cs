// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCellDynamicFormattingEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.CellDynamicFormatting" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGCellDynamicFormattingEventArgs : EventArgs
  {
    /// <summary>The row index of the cell which formatting is being requested.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the cell which contents are being requested or -1 if it is a row text cell.</summary>
    public readonly int ColIndex;
    /// <summary>Indicates whether the cell is selected.</summary>
    public readonly bool Selected;
    /// <summary>Indicates whether the row which the cell is located in is selected.</summary>
    public readonly bool RowSelected;
    /// <summary>The color of the cell background.</summary>
    public Color BackColor;
    /// <summary>The color of the cell text.</summary>
    public Color ForeColor;
    /// <summary>The font of the cell text.</summary>
    public Font Font;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCellDynamicFormattingEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the cell which formatting is being requested.</param>
    /// <param name="colIndex">The column index of the cell which formatting are being requested or -1 if it is a row text cell.</param>
    /// <param name="selected">Indicates whether the cell is selected.</param>
    /// <param name="rowSelected">Indicates whether the row which the cell is located in is selected.</param>
    /// <param name="backColor">The color of the cell background.</param>
    /// <param name="foreColor">The color of the cell text.</param>
    /// <param name="font">The font of the cell text.</param>
    public iGCellDynamicFormattingEventArgs(int rowIndex, int colIndex, bool selected, bool rowSelected, Color backColor, Color foreColor, Font font)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
      this.Selected = selected;
      this.RowSelected = rowSelected;
      this.BackColor = backColor;
      this.ForeColor = foreColor;
      this.Font = font;
    }
  }
}
