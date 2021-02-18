// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCustomDrawFooterCellGetHeightEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.CustomDrawFooterCellGetHeight" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGCustomDrawFooterCellGetHeightEventArgs : EventArgs
  {
    /// <summary>The row index of the footer cell whose height is requested.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the footer cell whose height is requested.</summary>
    public readonly int ColIndex;
    /// <summary>The actual width of the footer cell whose height is requested.</summary>
    public readonly int Width;
    /// <summary>The height required to entirely display all the contents of the footer cell.</summary>
    public int Height;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCustomDrawFooterCellGetHeightEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the footer cell whose height is requested.</param>
    /// <param name="colIndex">The column index of the footer cell whose height is requested.</param>
    /// <param name="width">The actual width of the footer cell whose height is requested.</param>
    public iGCustomDrawFooterCellGetHeightEventArgs(int rowIndex, int colIndex, int width)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
      this.Width = width;
      this.Height = 0;
    }
  }
}
