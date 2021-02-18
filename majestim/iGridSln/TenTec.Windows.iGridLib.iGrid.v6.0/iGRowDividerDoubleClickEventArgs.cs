// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGRowDividerDoubleClickEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.RowDividerDoubleClick" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGRowDividerDoubleClickEventArgs : EventArgs
  {
    /// <summary>The index of the row which divider has been double-clicked.</summary>
    public readonly int RowIndex;
    /// <summary>Indicates whether the row's height should be automatically adjusted to fit the row's contents.</summary>
    public bool DoDefault;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGRowDividerDoubleClickEventArgs" /> class.</summary>
    /// <param name="rowIndex">The index of the row which divider has been double-clicked.</param>
    public iGRowDividerDoubleClickEventArgs(int rowIndex)
    {
      this.RowIndex = rowIndex;
      this.DoDefault = true;
    }
  }
}
