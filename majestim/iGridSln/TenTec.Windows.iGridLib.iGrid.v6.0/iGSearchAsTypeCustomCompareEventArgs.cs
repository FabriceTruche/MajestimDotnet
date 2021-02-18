// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGSearchAsTypeCustomCompareEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.SearchAsTypeCustomCompare" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGSearchAsTypeCustomCompareEventArgs : EventArgs
  {
    /// <summary>The row index of the cell which is being compared to the search text.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the cell which is being compared to the search text or -1 if it's a row text cell.</summary>
    public readonly int ColIndex;
    /// <summary>The text which is being sought.</summary>
    public readonly string SearchText;
    /// <summary>Indicates whether the cell matches the search text.</summary>
    public bool Match;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGSearchAsTypeCustomCompareEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the cell which is being compared to the search text.</param>
    /// <param name="colIndex">The column index of the cell which is being compared to the search text or -1 if it's a row text cell.</param>
    /// <param name="searchText">The text which is being sought.</param>
    public iGSearchAsTypeCustomCompareEventArgs(int rowIndex, int colIndex, string searchText)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
      this.SearchText = searchText;
    }
  }
}
