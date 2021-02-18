// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCurCellChangeRequestEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.CurCellChangeRequest" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGCurCellChangeRequestEventArgs : EventArgs
  {
    /// <summary>The row index of the new cell the user is going to make current.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the new cell the user is going to make current.</summary>
    public readonly int ColIndex;
    /// <summary>A Boolean value that indicates whether the cell change is allowed.</summary>
    public bool DoDefault;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCurCellChangeRequestEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the new cell the user is going to make current.</param>
    /// <param name="colIndex">The column index of the new cell the user is going to make current.</param>
    /// <param name="doDefault">A Boolean value that indicates whether the cell change is allowed.</param>
    public iGCurCellChangeRequestEventArgs(int rowIndex, int colIndex, bool doDefault)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
      this.DoDefault = doDefault;
    }
  }
}
