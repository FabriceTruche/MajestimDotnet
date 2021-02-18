// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGSelectedItemChangedEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGDropDownList.SelectedItemChanged" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGDropDownList" /> component.</summary>
  public class iGSelectedItemChangedEventArgs : EventArgs
  {
    /// <summary>The new selected item.</summary>
    public readonly iGDropDownListItem SelectedItem;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGSelectedItemChangedEventArgs" /> class.</summary>
    /// <param name="selectedItem">The selected item.</param>
    public iGSelectedItemChangedEventArgs(iGDropDownListItem selectedItem)
    {
      this.SelectedItem = selectedItem;
    }
  }
}
