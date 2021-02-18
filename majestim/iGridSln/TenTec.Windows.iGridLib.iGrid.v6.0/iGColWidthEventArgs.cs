// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGColWidthEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.ColWidthStartChange" />, <see cref="E:TenTec.Windows.iGridLib.iGrid.ColWidthChanging" />, and <see cref="E:TenTec.Windows.iGridLib.iGrid.ColWidthEndChange" /> events of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGColWidthEventArgs : EventArgs
  {
    /// <summary>The row index of the header of the column(s) being resized.</summary>
    public readonly int RowIndex;
    /// <summary>The index of the column(s) being resized.</summary>
    public readonly int ColIndex;
    /// <summary>The new width of the column(s) being resized.</summary>
    public readonly int Width;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGColWidthEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the header of the column(s) being resized.</param>
    /// <param name="colIndex">The index of the column(s) being resized.</param>
    /// <param name="width">The new width of the column(s) being resized.</param>
    public iGColWidthEventArgs(int rowIndex, int colIndex, int width)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
      this.Width = width;
    }
  }
}
