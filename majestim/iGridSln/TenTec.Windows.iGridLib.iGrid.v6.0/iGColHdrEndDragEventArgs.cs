// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGColHdrEndDragEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.ColHdrEndDrag" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGColHdrEndDragEventArgs : EventArgs
  {
    /// <summary>The row index of the column header being dragged.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the column header being dragged.</summary>
    public readonly int ColIndex;
    /// <summary>The new display position of the columns being dragged if they are dragged to the header, or their new group index if they are dragged to the group box.</summary>
    public readonly int NewOrder;
    /// <summary>Indicates whether the column header is dragged to the group box or header.</summary>
    public readonly bool ToGroupBox;
    /// <summary>Allows to prohibit to move the columns to the new position or to group the columns.</summary>
    public bool DoDefault;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGColHdrEndDragEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the column header being dragged.</param>
    /// <param name="colIndex">The column index of the column header being dragged.</param>
    /// <param name="newOrder">The new display position of the columns being dragged if they are dragged to the header, or their new group index if they are dragged to the group box.</param>
    /// <param name="toGroupBox">Indicates whether the column header is dragged to the group box or header.</param>
    public iGColHdrEndDragEventArgs(int rowIndex, int colIndex, int newOrder, bool toGroupBox)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
      this.NewOrder = newOrder;
      this.ToGroupBox = toGroupBox;
      this.DoDefault = true;
    }
  }
}
