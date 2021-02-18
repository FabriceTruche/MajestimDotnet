// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGRowHeightEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.RowHeightStartChange" />, <see cref="E:TenTec.Windows.iGridLib.iGrid.RowHeightChanging" />, and <see cref="E:TenTec.Windows.iGridLib.iGrid.RowHeightEndChange" /> events of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGRowHeightEventArgs : EventArgs
  {
    /// <summary>The index of the row which is being resized.</summary>
    public readonly int RowIndex;
    /// <summary>The new height of the row which is being resized. If the <see cref="P:TenTec.Windows.iGridLib.iGrid.ImmediateRowResizing" /> property is set to False, this argument contains the suppositional row height.</summary>
    public readonly int Height;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGRowHeightEventArgs" /> class.</summary>
    /// <param name="rowIndex">The index of the row which is being resized.</param>
    /// <param name="height">The new height of the row which is being resized. If the <see cref="P:TenTec.Windows.iGridLib.iGrid.ImmediateRowResizing" /> property is set to False, this argument contains the suppositional row height.</param>
    public iGRowHeightEventArgs(int rowIndex, int height)
    {
      this.RowIndex = rowIndex;
      this.Height = height;
    }
  }
}
