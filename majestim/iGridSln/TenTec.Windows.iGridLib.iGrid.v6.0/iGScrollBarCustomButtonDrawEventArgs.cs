// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGScrollBarCustomButtonDrawEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.HScrollBarCustomButtonDrawBackground" />,  <see cref="E:TenTec.Windows.iGridLib.iGrid.VScrollBarCustomButtonDrawBackground" />, <see cref="E:TenTec.Windows.iGridLib.iGrid.HScrollBarCustomButtonDrawForeground" />, and <see cref="E:TenTec.Windows.iGridLib.iGrid.VScrollBarCustomButtonDrawForeground" /> events of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGScrollBarCustomButtonDrawEventArgs : EventArgs
  {
    /// <summary>The zero-based index of the scroll bar custom button being drawn.</summary>
    public readonly int Index;
    /// <summary>The bounds of the scroll bar custom button being drawn. The coordinates are relative to the upper left corner of the scroll bar.</summary>
    public readonly Rectangle Bounds;
    /// <summary>The state of the scroll bar custom button being drawn.</summary>
    public readonly iGControlState State;
    /// <summary>The graphics surface to draw the custom button on.</summary>
    public readonly Graphics Graphics;
    /// <summary>Indicates whether the event was handled.</summary>
    public bool Handled;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGScrollBarCustomButtonDrawEventArgs" /> class.</summary>
    /// <param name="index">The zero-based index of the scroll bar custom button being drawn.</param>
    /// <param name="bounds">The bounds of the scroll bar custom button being drawn. The coordinates are relative to the upper left corner of the scroll bar.</param>
    /// <param name="state">The state of the scroll bar custom button being drawn.</param>
    /// <param name="graphics">The graphics surface to draw the custom button on.</param>
    public iGScrollBarCustomButtonDrawEventArgs(int index, Rectangle bounds, iGControlState state, Graphics graphics)
    {
      this.Index = index;
      this.Bounds = bounds;
      this.State = state;
      this.Graphics = graphics;
      this.Handled = false;
    }
  }
}
