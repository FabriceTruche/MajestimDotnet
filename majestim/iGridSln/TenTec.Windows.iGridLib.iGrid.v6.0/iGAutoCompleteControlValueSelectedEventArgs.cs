﻿// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGAutoCompleteControlValueSelectedEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.IiGAutoCompleteControl.ValueSelected" /> event of an <see cref="T:TenTec.Windows.iGridLib.IiGAutoCompleteControl" /> interface.</summary>
  public class iGAutoCompleteControlValueSelectedEventArgs : EventArgs
  {
    /// <summary>The value that has been selected in the auto-complete control.</summary>
    public readonly object Value;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGAutoCompleteControlValueSelectedEventArgs" /> class.</summary>
    /// <param name="value">The value that has been selected in the auto-complete control.</param>
    public iGAutoCompleteControlValueSelectedEventArgs(object value)
    {
      this.Value = value;
    }
  }
}
