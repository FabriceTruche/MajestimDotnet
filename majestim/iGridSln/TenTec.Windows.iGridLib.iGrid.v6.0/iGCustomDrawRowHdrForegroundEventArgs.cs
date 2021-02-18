// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCustomDrawRowHdrForegroundEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.CustomDrawRowHdrForeground" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGCustomDrawRowHdrForegroundEventArgs : EventArgs
  {
    /// <summary>The index of the row which header is being drawn.</summary>
    public readonly int RowIndex;
    /// <summary>The graphics surface to draw on.</summary>
    public readonly Graphics Graphics;
    /// <summary>The bounds of the glyph area of the row header being drawn.</summary>
    public readonly Rectangle GlyphAreaBounds;
    /// <summary>The bounds of the empty area on the right (left in right-to-left mode) of the glyph area.</summary>
    public readonly Rectangle CustomAreaBounds;
    /// <summary>The visual state of the row header (indicates whether it is pressed, hot etc).</summary>
    public readonly iGControlState State;
    /// <summary>Indicates whether the row which header is being drawn is selected.</summary>
    public readonly bool Selected;
    /// <summary>Determines whether the standard row header foreground (a standard glyph) should be drawn.</summary>
    public bool DoDefault;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCustomDrawRowHdrForegroundEventArgs" /> class.</summary>
    /// <param name="rowIndex">The index of the row which header is being drawn.</param>
    /// <param name="graphics">The graphics surface to draw on.</param>
    /// <param name="glyphAreaBounds">The bounds of the area where the row header glyph is drawn.</param>
    /// <param name="customAreaBounds">The bounds of the empty area on the right (left in right-to-left mode) of the glyph area.</param>
    /// <param name="state">The visual state of the row header (indicates whether it is pressed, hot etc).</param>
    /// <param name="selected">Indicates whether the row which header is being drawn is selected.</param>
    public iGCustomDrawRowHdrForegroundEventArgs(int rowIndex, Graphics graphics, Rectangle glyphAreaBounds, Rectangle customAreaBounds, iGControlState state, bool selected)
    {
      this.RowIndex = rowIndex;
      this.Graphics = graphics;
      this.GlyphAreaBounds = glyphAreaBounds;
      this.CustomAreaBounds = customAreaBounds;
      this.State = state;
      this.Selected = selected;
      this.DoDefault = true;
    }
  }
}
