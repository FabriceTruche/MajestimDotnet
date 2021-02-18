// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGScrollEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.HScrollBarScroll" /> and <see cref="E:TenTec.Windows.iGridLib.iGrid.VScrollBarScroll" /> events of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGScrollEventArgs : EventArgs
  {
    /// <summary>The value of the scroll bar.</summary>
    public readonly int NewValue;
    /// <summary>The type of scroll event that occurred.</summary>
    public readonly iGScrollEventType Type;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGScrollEventArgs" /> class.</summary>
    /// <param name="type">The type of scroll event that occurred.</param>
    /// <param name="newValue">The value of the scroll bar.</param>
    public iGScrollEventArgs(iGScrollEventType type, int newValue)
    {
      this.NewValue = newValue;
      this.Type = type;
    }
  }
}
