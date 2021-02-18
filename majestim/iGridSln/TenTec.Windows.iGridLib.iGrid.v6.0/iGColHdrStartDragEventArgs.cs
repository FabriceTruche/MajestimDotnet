// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGColHdrStartDragEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.ColHdrStartDrag" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGColHdrStartDragEventArgs : EventArgs
  {
    /// <summary>The row index of the column header that is to be dragged.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the column header that is to be dragged.</summary>
    public readonly int ColIndex;
    /// <summary>Determines whether to start dragging of the column header.</summary>
    public bool DoDefault;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGColHdrStartDragEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the column header that is to be dragged.</param>
    /// <param name="colIndex">The column index of the column header that is to be dragged.</param>
    public iGColHdrStartDragEventArgs(int rowIndex, int colIndex)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
      this.DoDefault = true;
    }
  }
}
