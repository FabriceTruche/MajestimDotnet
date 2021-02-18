// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGRequestRowResizeEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.RequestRowResize" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGRequestRowResizeEventArgs : EventArgs
  {
    /// <summary>The index of the row which is about to be resized.</summary>
    public readonly int RowIndex;
    /// <summary>Indicates whether resizing of the row is allowed.</summary>
    public bool AllowResizing;
    /// <summary>Specifies the minimal height of the row.</summary>
    public int MinHeight;
    /// <summary>Specifies the maximal height of the row.</summary>
    public int MaxHeight;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGRequestRowResizeEventArgs" /> class.</summary>
    /// <param name="rowIndex">The index of the row which is about to be resized.</param>
    public iGRequestRowResizeEventArgs(int rowIndex)
    {
      this.RowIndex = rowIndex;
      this.AllowResizing = true;
      this.MinHeight = -1;
      this.MaxHeight = -1;
    }
  }
}
