// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGRequestColHdrToolTipTextEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.RequestColHdrToolTipText" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGRequestColHdrToolTipTextEventArgs : EventArgs
  {
    /// <summary>The row index of the column header for which the tool tip text is being requested.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the column header for which the tool tip text is being requested, or -1 if it is a row text column's or row header's header.</summary>
    public readonly int ColIndex;
    /// <summary>The kind of the column header for which the tool tip text is being requested (<see cref="F:TenTec.Windows.iGridLib.iGColHdrKind.Normal" />, <see cref="F:TenTec.Windows.iGridLib.iGColHdrKind.RowText" />, <see cref="F:TenTec.Windows.iGridLib.iGColHdrKind.Extra" />).</summary>
    public readonly iGColHdrKind Kind;
    /// <summary>The text to be displayed in the column header tool tip.</summary>
    public string Text;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGRequestColHdrToolTipTextEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the column header for which the tool tip text is being requested.</param>
    /// <param name="colIndex">The column index of the column header for which the tool tip text is being requested, or -1 if it is a row text column's or row header's header.</param>
    /// <param name="kind">The kind of the column header for which the tool tip text is being requested (<see cref="F:TenTec.Windows.iGridLib.iGColHdrKind.Normal" />, <see cref="F:TenTec.Windows.iGridLib.iGColHdrKind.RowText" />, <see cref="F:TenTec.Windows.iGridLib.iGColHdrKind.Extra" />).</param>
    /// <param name="text">The text to be displayed in the column header tool tip.</param>
    public iGRequestColHdrToolTipTextEventArgs(int rowIndex, int colIndex, iGColHdrKind kind, string text)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
      this.Kind = kind;
      this.Text = text;
    }
  }
}
