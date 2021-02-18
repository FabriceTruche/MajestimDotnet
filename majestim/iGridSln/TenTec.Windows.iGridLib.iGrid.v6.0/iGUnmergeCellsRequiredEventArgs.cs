// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGUnmergeCellsRequiredEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.UnmergeCellsRequired" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGUnmergeCellsRequiredEventArgs : EventArgs
  {
    /// <summary>A Boolean value that indicates whether the merged cells were unmerged to proceed.</summary>
    public bool CellsUnmerged;
    /// <summary>The reason of the event.</summary>
    public readonly iGUnmergeCellsRequiredReason Reason;
    /// <summary>The index of the column the event is related to.</summary>
    public readonly int ColIndex;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGUnmergeCellsRequiredEventArgs" /> class.</summary>
    /// <param name="cellsUnmerged">A Boolean value that indicates whether the merged cells were unmerged to proceed.</param>
    /// <param name="reason">The reason of the event.</param>
    /// <param name="colIndex">The index of the column the event is related to.</param>
    public iGUnmergeCellsRequiredEventArgs(bool cellsUnmerged, iGUnmergeCellsRequiredReason reason, int colIndex)
    {
      this.CellsUnmerged = cellsUnmerged;
      this.Reason = reason;
      this.ColIndex = colIndex;
    }
  }
}
