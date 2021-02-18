// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGRowHdrDynamicColorEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.RowHdrDynamicBackColor" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGRowHdrDynamicColorEventArgs : EventArgs
  {
    /// <summary>The index of the row which header is being drawn.</summary>
    public readonly int RowIndex;
    /// <summary>The background color of the row header which is being drawn.</summary>
    public Color Color;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGRowHdrDynamicColorEventArgs" /> class.</summary>
    /// <param name="rowIndex">The index of the row which header is being drawn.</param>
    /// <param name="color">The background color of the row header which is being drawn.</param>
    public iGRowHdrDynamicColorEventArgs(int rowIndex, Color color)
    {
      this.RowIndex = rowIndex;
      this.Color = color;
    }
  }
}
