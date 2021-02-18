// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGScrollBarValueChangingEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.HScrollBarValueChanging" /> and <see cref="E:TenTec.Windows.iGridLib.iGrid.VScrollBarValueChanging" /> events of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGScrollBarValueChangingEventArgs : EventArgs
  {
    /// <summary>The value that represents the position of the scroll box.</summary>
    public int Value;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGScrollBarValueChangingEventArgs" /> class.</summary>
    /// <param name="value">The value that represents the position of the scroll box.</param>
    public iGScrollBarValueChangingEventArgs(int value)
    {
      this.Value = value;
    }
  }
}
