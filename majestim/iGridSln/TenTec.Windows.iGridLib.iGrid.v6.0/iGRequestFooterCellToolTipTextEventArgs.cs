// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGRequestFooterCellToolTipTextEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.RequestFooterCellToolTipText" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGRequestFooterCellToolTipTextEventArgs : EventArgs
  {
    /// <summary>The row index of the footer cell for which the tool tip text is being requested.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the footer cell for which the tool tip text is being requested.</summary>
    public readonly int ColIndex;
    /// <summary>The kind of the footer cell for which the tool tip text is being requested (<see cref="F:TenTec.Windows.iGridLib.iGFooterCellKind.Normal" />, <see cref="F:TenTec.Windows.iGridLib.iGFooterCellKind.RowHdr" />, <see cref="F:TenTec.Windows.iGridLib.iGFooterCellKind.Extra" />).</summary>
    public readonly iGFooterCellKind Kind;
    /// <summary>The text to be displayed in the footer cell tool tip.</summary>
    public string Text;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGRequestFooterCellToolTipTextEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the footer cell for which the tool tip text is being requested.</param>
    /// <param name="colIndex">The column index of the footer cell for which the tool tip text is being requested.</param>
    /// <param name="kind">The kind of the footer cell for which the tool tip text is being requested (<see cref="F:TenTec.Windows.iGridLib.iGFooterCellKind.Normal" />, <see cref="F:TenTec.Windows.iGridLib.iGFooterCellKind.RowHdr" />, <see cref="F:TenTec.Windows.iGridLib.iGFooterCellKind.Extra" />).</param>
    /// <param name="text">The text to be displayed in the footer cell tool tip.</param>
    public iGRequestFooterCellToolTipTextEventArgs(int rowIndex, int colIndex, iGFooterCellKind kind, string text)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
      this.Kind = kind;
      this.Text = text;
    }
  }
}
