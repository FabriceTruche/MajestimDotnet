// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGRequestElemControlToolTipTextEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.RequestCellElemControlToolTipText" /> and <see cref="E:TenTec.Windows.iGridLib.iGrid.RequestColHdrElemControlToolTipText" /> events of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGRequestElemControlToolTipTextEventArgs : EventArgs
  {
    /// <summary>The row index of the cell or column header which contains the elementary control.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the cell or column header which contains the elementary control.</summary>
    public readonly int ColIndex;
    /// <summary>The type of the elementary control.</summary>
    public readonly iGElemControl ElemControl;
    /// <summary>The text to be displayed in the elementary control tool tip.</summary>
    public string Text;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGRequestElemControlToolTipTextEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the cell or column header which contains the elementary control.</param>
    /// <param name="colIndex">The column index of the cell or column header which contains the elementary control.</param>
    /// <param name="elemControl">The type of the elementary control.</param>
    /// <param name="text">The text to be displayed in the elementary control tool tip.</param>
    public iGRequestElemControlToolTipTextEventArgs(int rowIndex, int colIndex, iGElemControl elemControl, string text)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
      this.ElemControl = elemControl;
      this.Text = text;
    }
  }
}
