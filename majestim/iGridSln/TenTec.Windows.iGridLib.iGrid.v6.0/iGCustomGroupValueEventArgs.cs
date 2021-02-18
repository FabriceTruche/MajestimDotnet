// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCustomGroupValueEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.CustomGroupValue" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGCustomGroupValueEventArgs : EventArgs
  {
    /// <summary>The row index of the cell which group value is requested.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the cell which group value is requested.</summary>
    public readonly int ColIndex;
    /// <summary>The group value of the cell.</summary>
    public object Value;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCustomGroupValueEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the cell which group value is requested.</param>
    /// <param name="colIndex">The column index of the cell which group value is requested.</param>
    public iGCustomGroupValueEventArgs(int rowIndex, int colIndex)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
    }
  }
}
