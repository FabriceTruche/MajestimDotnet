// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGScrollBarCustomButtonMouseMoveEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.HScrollBarCustomButtonMouseMove" /> and <see cref="E:TenTec.Windows.iGridLib.iGrid.VScrollBarCustomButtonMouseMove" /> events of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGScrollBarCustomButtonMouseMoveEventArgs : EventArgs
  {
    /// <summary>The zero-based index of the scroll bar custom button under the mouse pointer.</summary>
    public readonly int Index;
    /// <summary>The coordinates of the mouse pointer. The coordinates are relative to the upper left corner of the scroll bar.</summary>
    public readonly Point MousePos;
    /// <summary>The bounds of the scroll bar custom button under the mouse pointer. The coordinates are relative to the upper left corner of the scroll bar.</summary>
    public readonly Rectangle Bounds;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGScrollBarCustomButtonMouseMoveEventArgs" /> class.</summary>
    /// <param name="index">The zero-based index of the scroll bar custom button under the mouse pointer.</param>
    /// <param name="mousePos">The coordinates of the mouse pointer. The coordinates are relative to the upper left corner of the scroll bar.</param>
    /// <param name="bounds">The bounds of the scroll bar custom button under the mouse pointer. The coordinates are relative to the upper left corner of the scroll bar.</param>
    public iGScrollBarCustomButtonMouseMoveEventArgs(int index, Point mousePos, Rectangle bounds)
    {
      this.Index = index;
      this.MousePos = mousePos;
      this.Bounds = bounds;
    }
  }
}
