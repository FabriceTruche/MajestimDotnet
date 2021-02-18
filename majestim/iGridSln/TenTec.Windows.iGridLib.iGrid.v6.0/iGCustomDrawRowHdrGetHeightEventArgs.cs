// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCustomDrawRowHdrGetHeightEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.CustomDrawRowHdrGetHeight" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGCustomDrawRowHdrGetHeightEventArgs : EventArgs
  {
    /// <summary>The index of the row which header height is being requested.</summary>
    public readonly int RowIndex;
    /// <summary>The graphics surface where the row header is drawn.</summary>
    public readonly Graphics Graphics;
    /// <summary>The height of the area where the row header's glyph is drawn.</summary>
    public int GlyphAreaHeight;
    /// <summary>The height of the empty area on the right (left in right-to-left mode) of the glyph area.</summary>
    public int CustomAreaHeight;
    /// <summary>Indicates whether the values of the <see cref="F:TenTec.Windows.iGridLib.iGCustomDrawRowHdrGetHeightEventArgs.CustomAreaHeight" /> and <see cref="F:TenTec.Windows.iGridLib.iGCustomDrawRowHdrGetHeightEventArgs.GlyphAreaHeight" /> fields include the system indents (the indents which are used in order not to draw on the system style  border (3D, Flat, XP).</summary>
    public bool IncludeIndents;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCustomDrawRowHdrGetHeightEventArgs" /> class.</summary>
    /// <param name="rowIndex">The index of the row which header height is being requested.</param>
    /// <param name="graphics">The graphics surface where the row header is drawn.</param>
    /// <param name="glyphAreaHeight">The height of the area where the row header's glyph is drawn.</param>
    public iGCustomDrawRowHdrGetHeightEventArgs(int rowIndex, Graphics graphics, int glyphAreaHeight)
    {
      this.RowIndex = rowIndex;
      this.Graphics = graphics;
      this.GlyphAreaHeight = glyphAreaHeight;
      this.CustomAreaHeight = 0;
      this.IncludeIndents = false;
    }
  }
}
