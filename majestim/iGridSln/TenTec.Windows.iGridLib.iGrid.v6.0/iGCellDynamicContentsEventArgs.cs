// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCellDynamicContentsEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.CellDynamicContents" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGCellDynamicContentsEventArgs : EventArgs
  {
    /// <summary>The row index of the cell which contents are being requested.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the cell which contents are being requested or -1 if it is a row text cell.</summary>
    public readonly int ColIndex;
    /// <summary>The text of the cell.</summary>
    public string Text;
    /// <summary>The index of the image displayed in the cell.</summary>
    public int ImageIndex;
    /// <summary>The state of the check box control in the cell.</summary>
    public CheckState CheckState;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCellDynamicContentsEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the cell which contents are being requested.</param>
    /// <param name="colIndex">The column index of the cell which contents are being requested or -1 if it is a row text cell.</param>
    /// <param name="text">The text of the cell.</param>
    /// <param name="imageIndex">The index of the image displayed in the cell.</param>
    /// <param name="checkState">The state of the check box control in the cell.</param>
    public iGCellDynamicContentsEventArgs(int rowIndex, int colIndex, string text, int imageIndex, CheckState checkState)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
      this.Text = text;
      this.ImageIndex = imageIndex;
      this.CheckState = checkState;
    }
  }
}
