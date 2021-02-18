// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGColOrderChangedEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.ColOrderChanged" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGColOrderChangedEventArgs : EventArgs
  {
    /// <summary>The original position of the group of columns.</summary>
    public readonly int SrcOrder;
    /// <summary>The new position of the group of columns.</summary>
    public readonly int DstOrder;
    /// <summary>The number of columns in the group.</summary>
    public readonly int Count;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGColOrderChangedEventArgs" /> class.</summary>
    /// <param name="srcOrder">The original position of the group of columns.</param>
    /// <param name="dstOrder">The new position of the group of columns.</param>
    /// <param name="count">The number of columns in the group.</param>
    public iGColOrderChangedEventArgs(int srcOrder, int dstOrder, int count)
    {
      this.SrcOrder = srcOrder;
      this.DstOrder = dstOrder;
      this.Count = count;
    }
  }
}
