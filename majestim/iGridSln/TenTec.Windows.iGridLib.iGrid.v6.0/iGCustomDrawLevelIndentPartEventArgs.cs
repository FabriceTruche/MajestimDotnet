// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCustomDrawLevelIndentPartEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.CustomDrawLevelIndentPart" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGCustomDrawLevelIndentPartEventArgs : EventArgs
  {
    /// <summary>The index of the row which level indent parts are being drawn.</summary>
    public readonly int RowIndex;
    /// <summary>The index of the level indent part being drawn.</summary>
    public readonly int PartIndex;
    /// <summary>The graphics surface to draw on.</summary>
    public readonly Graphics Graphics;
    /// <summary>The bounds of the rectangle of the current level indent part.</summary>
    public readonly Rectangle Bounds;
    /// <summary>Specifies whether to use the default drawing.</summary>
    public bool DoDefault;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCustomDrawLevelIndentPartEventArgs" /> class.</summary>
    /// <param name="rowIndex">The index of the row which level indent parts are being drawn.</param>
    /// <param name="partIndex">The index of the level indent part being drawn.</param>
    /// <param name="graphics">The graphics surface to draw on.</param>
    /// <param name="bounds">The bounds of the rectangle of the current level indent part.</param>
    public iGCustomDrawLevelIndentPartEventArgs(int rowIndex, int partIndex, Graphics graphics, Rectangle bounds)
    {
      this.RowIndex = rowIndex;
      this.PartIndex = partIndex;
      this.Graphics = graphics;
      this.Bounds = bounds;
      this.DoDefault = true;
    }
  }
}
