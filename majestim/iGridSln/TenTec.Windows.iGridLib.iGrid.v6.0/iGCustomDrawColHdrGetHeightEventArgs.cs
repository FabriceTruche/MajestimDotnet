// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCustomDrawColHdrGetHeightEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.CustomDrawColHdrGetHeight" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGCustomDrawColHdrGetHeightEventArgs : EventArgs
  {
    /// <summary>The row index of the column header whose height is requested.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the column header whose height is requested.</summary>
    public readonly int ColIndex;
    /// <summary>The width of the column header whose height is requested.</summary>
    public readonly int Width;
    /// <summary>The height required to entirely display all the contents of the column header.</summary>
    public int Height;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCustomDrawColHdrGetHeightEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the column header whose height is requested.</param>
    /// <param name="colIndex">The column index of the column header whose height is requested.</param>
    /// <param name="width">The width of the column header whose height is requested.</param>
    public iGCustomDrawColHdrGetHeightEventArgs(int rowIndex, int colIndex, int width)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
      this.Width = width;
      this.Height = 0;
    }
  }
}
