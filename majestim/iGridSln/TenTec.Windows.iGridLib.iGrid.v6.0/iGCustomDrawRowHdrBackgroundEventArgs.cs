// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCustomDrawRowHdrBackgroundEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.CustomDrawRowHdrBackground" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGCustomDrawRowHdrBackgroundEventArgs : EventArgs
  {
    /// <summary>The index of the row which header is being drawn.</summary>
    public readonly int RowIndex;
    /// <summary>The graphics surface to draw on.</summary>
    public readonly Graphics Graphics;
    /// <summary>The bounds of the row header being drawn. These bounds include all the area of the row header except for the area taken by the grid lines.</summary>
    public readonly Rectangle Bounds;
    /// <summary>The visual state of the row header (indicates whether it is pressed, hot etc).</summary>
    public readonly iGControlState State;
    /// <summary>Indicates whether the row which header is being drawn is selected.</summary>
    public readonly bool Selected;
    /// <summary>Determines whether the standard row header background should be drawn.</summary>
    public bool DoDefault;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCustomDrawRowHdrBackgroundEventArgs" /> class.</summary>
    /// <param name="rowIndex">The index of the row which header is being drawn.</param>
    /// <param name="graphics">The graphics surface to draw on.</param>
    /// <param name="bounds">The bounds of the row header being drawn. These bounds include all the area of the row header except for the area taken by the grid lines.</param>
    /// <param name="state">The visual state of the row header (indicates whether it is pressed, hot etc).</param>
    /// <param name="selected">Indicates whether the row which header is being drawn is selected.</param>
    public iGCustomDrawRowHdrBackgroundEventArgs(int rowIndex, Graphics graphics, Rectangle bounds, iGControlState state, bool selected)
    {
      this.RowIndex = rowIndex;
      this.Graphics = graphics;
      this.Bounds = bounds;
      this.State = state;
      this.Selected = selected;
      this.DoDefault = true;
    }
  }
}
