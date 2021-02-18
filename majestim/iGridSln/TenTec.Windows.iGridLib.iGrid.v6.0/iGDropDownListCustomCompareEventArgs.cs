// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGDropDownListCustomCompareEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGDropDownList.SearchAsTypeCustomCompare" /> or <see cref="E:TenTec.Windows.iGridLib.iGDropDownList.GetItemByTextCustomCompare" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGDropDownList" /> component.</summary>
  public class iGDropDownListCustomCompareEventArgs : EventArgs
  {
    /// <summary>The drop-down list item which is being compared to the text being sought.</summary>
    public readonly iGDropDownListItem Item;
    /// <summary>The text which is being sought.</summary>
    public readonly string SearchText;
    /// <summary>Indicates whether the drop-down list item matches the string which is being sought.</summary>
    public bool Match;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGDropDownListCustomCompareEventArgs" /> class.</summary>
    /// <param name="item">The drop-down list item which is being compared to the text being sought.</param>
    /// <param name="searchText">The text which is being sought.</param>
    public iGDropDownListCustomCompareEventArgs(iGDropDownListItem item, string searchText)
    {
      this.Item = item;
      this.SearchText = searchText;
    }
  }
}
