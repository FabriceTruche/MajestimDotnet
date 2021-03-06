﻿// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCustomDrawFooterRowHdrEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.CustomDrawFooterRowHdr" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGCustomDrawFooterRowHdrEventArgs : EventArgs
  {
    /// <summary>The graphics surface to draw the footer row header cell on.</summary>
    public readonly Graphics Graphics;
    /// <summary>The bounds of the footer row header cell being drawn. The coordinates are relative to the upper left corner of the grid.</summary>
    public readonly Rectangle Bounds;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCustomDrawFooterRowHdrEventArgs" /> class.</summary>
    /// <param name="graphics">The graphics surface to draw the footer row header cell on.</param>
    /// <param name="bounds">The bounds of the footer row header cell being drawn. The coordinates are relative to the upper left corner of the grid.</param>
    public iGCustomDrawFooterRowHdrEventArgs(Graphics graphics, Rectangle bounds)
    {
      this.Graphics = graphics;
      this.Bounds = bounds;
    }
  }
}
