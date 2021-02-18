// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGBeforeRowStateChangedEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.BeforeRowStateChanged" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGBeforeRowStateChangedEventArgs : EventArgs
  {
    /// <summary>The index of the row to be expanded/collapsed.</summary>
    public readonly int RowIndex;
    /// <summary>The state of the row to be collapsed/expanded.</summary>
    public readonly bool Expanded;
    /// <summary>Determines whether to expand/collapse the row or not.</summary>
    public bool DoDefault;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGBeforeRowStateChangedEventArgs" /> class.</summary>
    /// <param name="rowIndex">The index of the row to be expanded/collapsed.</param>
    /// <param name="expanded">The state of the row to be collapsed/expanded.</param>
    public iGBeforeRowStateChangedEventArgs(int rowIndex, bool expanded)
    {
      this.RowIndex = rowIndex;
      this.Expanded = expanded;
      this.DoDefault = true;
    }
  }
}
