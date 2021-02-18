// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGScrollEventHandler
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents the method that will handle the <see cref="E:TenTec.Windows.iGridLib.iGrid.HScrollBarScroll" /> and <see cref="E:TenTec.Windows.iGridLib.iGrid.VScrollBarScroll" /> events of an iGrid control.</summary>
  /// <param name="sender">The scroll bar control the event concerns.</param>
  /// <param name="e">An <see cref="T:TenTec.Windows.iGridLib.iGScrollEventArgs" /> that contains the event data.</param>
  public delegate void iGScrollEventHandler(object sender, iGScrollEventArgs e);
}
