// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGScrollBarCustomButtonMouseEnterLeaveEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.HScrollBarCustomButtonMouseEnter" />,  <see cref="E:TenTec.Windows.iGridLib.iGrid.HScrollBarCustomButtonMouseLeave" />, <see cref="E:TenTec.Windows.iGridLib.iGrid.VScrollBarCustomButtonMouseEnter" />, and <see cref="E:TenTec.Windows.iGridLib.iGrid.VScrollBarCustomButtonMouseLeave" /> events of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGScrollBarCustomButtonMouseEnterLeaveEventArgs : EventArgs
  {
    /// <summary>The zero-based index of the scroll bar custom button under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.HScrollBarCustomButtonMouseEnter" /> and <see cref="E:TenTec.Windows.iGridLib.iGrid.VScrollBarCustomButtonMouseEnter" /> events, and of the previous hot button for the <see cref="E:TenTec.Windows.iGridLib.iGrid.HScrollBarCustomButtonMouseLeave" /> and <see cref="E:TenTec.Windows.iGridLib.iGrid.VScrollBarCustomButtonMouseLeave" /> events.</summary>
    public readonly int Index;
    /// <summary>The bounds of the scroll bar custom button under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.HScrollBarCustomButtonMouseEnter" /> and <see cref="E:TenTec.Windows.iGridLib.iGrid.VScrollBarCustomButtonMouseEnter" /> events, and of the previous hot button for the <see cref="E:TenTec.Windows.iGridLib.iGrid.HScrollBarCustomButtonMouseLeave" /> and <see cref="E:TenTec.Windows.iGridLib.iGrid.VScrollBarCustomButtonMouseLeave" /> events. The coordinates are relative to the upper left corner of the scroll bar.</summary>
    public readonly Rectangle Bounds;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGScrollBarCustomButtonMouseEnterLeaveEventArgs" /> class.</summary>
    /// <param name="index">The zero-based index of the scroll bar custom button under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.HScrollBarCustomButtonMouseEnter" /> and <see cref="E:TenTec.Windows.iGridLib.iGrid.VScrollBarCustomButtonMouseEnter" /> events, and of the previous hot button for the <see cref="E:TenTec.Windows.iGridLib.iGrid.HScrollBarCustomButtonMouseLeave" /> and <see cref="E:TenTec.Windows.iGridLib.iGrid.VScrollBarCustomButtonMouseLeave" /> events.</param>
    /// <param name="bounds">The bounds of the scroll bar custom button under the mouse pointer for the <see cref="E:TenTec.Windows.iGridLib.iGrid.HScrollBarCustomButtonMouseEnter" /> and <see cref="E:TenTec.Windows.iGridLib.iGrid.VScrollBarCustomButtonMouseEnter" /> events, and of the previous hot button for the <see cref="E:TenTec.Windows.iGridLib.iGrid.HScrollBarCustomButtonMouseLeave" /> and <see cref="E:TenTec.Windows.iGridLib.iGrid.VScrollBarCustomButtonMouseLeave" /> events. The coordinates are relative to the upper left corner of the scroll bar.</param>
    public iGScrollBarCustomButtonMouseEnterLeaveEventArgs(int index, Rectangle bounds)
    {
      this.Index = index;
      this.Bounds = bounds;
    }
  }
}
