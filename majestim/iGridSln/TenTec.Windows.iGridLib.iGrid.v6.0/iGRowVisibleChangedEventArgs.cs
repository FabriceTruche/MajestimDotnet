// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGRowVisibleChangedEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.RowVisibleChanged" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGRowVisibleChangedEventArgs : EventArgs
  {
    /// <summary>The index of the row.</summary>
    public readonly int RowIndex;
    /// <summary>True if the row became visible; otherwise False.</summary>
    public readonly bool Visible;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGRowVisibleChangedEventArgs" /> class.</summary>
    /// <param name="rowIndex">The index of the row.</param>
    /// <param name="visible">True if the row became visible; otherwise False.</param>
    public iGRowVisibleChangedEventArgs(int rowIndex, bool visible)
    {
      this.RowIndex = rowIndex;
      this.Visible = visible;
    }
  }
}
