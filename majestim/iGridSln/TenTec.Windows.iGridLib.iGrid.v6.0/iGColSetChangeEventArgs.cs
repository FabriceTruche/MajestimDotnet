// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGColSetChangeEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.ColsAdded" />, <see cref="E:TenTec.Windows.iGridLib.iGrid.ColsRemoving" /> and <see cref="E:TenTec.Windows.iGridLib.iGrid.ColsRemoved" /> events of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGColSetChangeEventArgs : EventArgs
  {
    /// <summary>The index of the first column in the current column set change.</summary>
    public readonly int ColIndex;
    /// <summary>The number of columns in the current column set change.</summary>
    public readonly int ColCount;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGColSetChangeEventArgs" /> class.</summary>
    /// <param name="colIndex">The index of the first column in the current column set change.</param>
    /// <param name="colCount">The number of columns in the current column set change.</param>
    public iGColSetChangeEventArgs(int colIndex, int colCount)
    {
      this.ColIndex = colIndex;
      this.ColCount = colCount;
    }
  }
}
