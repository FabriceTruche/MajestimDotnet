// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGRowSetChangeEventHandler
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents the method that will handle the <see cref="E:TenTec.Windows.iGridLib.iGrid.RowsAdded" />, <see cref="E:TenTec.Windows.iGridLib.iGrid.RowsRemoving" /> or <see cref="E:TenTec.Windows.iGridLib.iGrid.RowsRemoved" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  /// <param name="sender">The source of the event.</param>
  /// <param name="e">An <see cref="T:TenTec.Windows.iGridLib.iGRowSetChangeEventArgs" /> that contains the event data.</param>
  public delegate void iGRowSetChangeEventHandler(object sender, iGRowSetChangeEventArgs e);
}
