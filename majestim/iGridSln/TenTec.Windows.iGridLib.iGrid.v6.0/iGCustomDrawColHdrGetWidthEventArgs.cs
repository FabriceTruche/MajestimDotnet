// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCustomDrawColHdrGetWidthEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.CustomDrawColHdrGetWidth" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGCustomDrawColHdrGetWidthEventArgs : EventArgs
  {
    /// <summary>The row index of the column header whose width is requested.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the column header whose width is requested.</summary>
    public readonly int ColIndex;
    /// <summary>The height of the column header whose width is requested.</summary>
    public readonly int Height;
    /// <summary>The width required to display all the contents of the column header entirely.</summary>
    public int Width;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCustomDrawColHdrGetWidthEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the column header whose width is requested.</param>
    /// <param name="colIndex">The column index of the column header whose width is requested.</param>
    /// <param name="height">The height of the column header whose width is requested.</param>
    public iGCustomDrawColHdrGetWidthEventArgs(int rowIndex, int colIndex, int height)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
      this.Height = height;
      this.Width = 0;
    }
  }
}
