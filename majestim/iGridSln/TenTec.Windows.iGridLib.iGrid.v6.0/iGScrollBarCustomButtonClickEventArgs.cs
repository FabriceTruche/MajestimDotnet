// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGScrollBarCustomButtonClickEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.HScrollBarCustomButtonClick" /> and <see cref="E:TenTec.Windows.iGridLib.iGrid.VScrollBarCustomButtonClick" /> events of an iGrid control.</summary>
  public class iGScrollBarCustomButtonClickEventArgs : EventArgs
  {
    /// <summary>The index of the scroll bar button that has been clicked.</summary>
    public readonly int Index;
    /// <summary>Indicates which of the modifier keys (SHIFT, CTRL, and ALT) was in a pressed state.</summary>
    public readonly Keys ModifierKeys;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGScrollBarCustomButtonClickEventArgs" /> class.</summary>
    /// <param name="index">The index of the scroll bar button that has been clicked.</param>
    /// <param name="modifierKeys">Specifies which of the modifier keys (SHIFT, CTRL, and ALT) is in a pressed state.</param>
    public iGScrollBarCustomButtonClickEventArgs(int index, Keys modifierKeys)
    {
      this.Index = index;
      this.ModifierKeys = modifierKeys;
    }
  }
}
