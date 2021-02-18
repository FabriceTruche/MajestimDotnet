// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCustomDrawControlEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.CustomDrawBackground" /> and <see cref="E:TenTec.Windows.iGridLib.iGrid.PostPaint" /> events of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGCustomDrawControlEventArgs : EventArgs
  {
    /// <summary>The graphics surface to draw the background on.</summary>
    public readonly Graphics Graphics;
    /// <summary>The bounds of the grid area.</summary>
    public readonly Rectangle Bounds;
    /// <summary>Gets the rectangle in which to paint (which really requires update).</summary>
    public readonly Rectangle ClipRectangle;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCustomDrawControlEventArgs" /> class.</summary>
    /// <param name="graphics">The graphics surface to draw the background on.</param>
    /// <param name="bounds">The bounds of the grid background area.</param>
    /// <param name="clipRectangle">Gets the rectangle in which to paint (which really requires update).</param>
    public iGCustomDrawControlEventArgs(Graphics graphics, Rectangle bounds, Rectangle clipRectangle)
    {
      this.Graphics = graphics;
      this.Bounds = bounds;
      this.ClipRectangle = clipRectangle;
    }
  }
}
