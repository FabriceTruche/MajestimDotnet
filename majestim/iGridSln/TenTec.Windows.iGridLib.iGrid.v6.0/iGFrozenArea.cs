// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGFrozenArea
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.ComponentModel;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents the non-scrollable rows and columns in an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGFrozenArea
  {
    private iGrid fGrid;

    /// <summary>Returns the <see cref="T:TenTec.Windows.iGridLib.iGrid" /> object this instance belongs to.</summary>
    /// <value>Returns the <see cref="T:TenTec.Windows.iGridLib.iGrid" /> object this instance belongs to.</value>
    [Browsable(false)]
    public iGrid Grid
    {
      get
      {
        return this.fGrid;
      }
    }

    internal iGFrozenArea(iGrid grid)
    {
      this.fGrid = grid;
    }

    private bool ShouldSerializeRowsEdge()
    {
      return !this.fGrid.fFrozenRowsSeparatingLineStyle.Equals(iGGridLines.cDefaultFrozenEdgeSeparatingLineStyle);
    }

    private bool ShouldSerializeColsEdge()
    {
      return !this.fGrid.fFrozenColsSeparatingLineStyle.Equals(iGGridLines.cDefaultFrozenEdgeSeparatingLineStyle);
    }

    private void ResetRowsEdge()
    {
      this.fGrid.fFrozenRowsSeparatingLineStyle = iGGridLines.cDefaultFrozenEdgeSeparatingLineStyle.Clone();
    }

    private void ResetColsEdge()
    {
      this.fGrid.fFrozenColsSeparatingLineStyle = iGGridLines.cDefaultFrozenEdgeSeparatingLineStyle.Clone();
    }

    /// <summary>Gets or sets the number of the non-scrollable rows.</summary>
    /// <value>The number of the non-scrollable rows. The default is 0.</value>
    [DefaultValue(0)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The count of the non-scrollable rows.")]
    public int RowCount
    {
      get
      {
        return this.fGrid.FrozenRowCount;
      }
      set
      {
        this.fGrid.FrozenRowCount = value;
      }
    }

    /// <summary>Gets or sets the number of the non-scrollable columns.</summary>
    /// <value>The number of the non-scrollable columns. The default is 0.</value>
    [DefaultValue(0)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The count of the non-scrollable columns.")]
    public int ColCount
    {
      get
      {
        return this.fGrid.FrozenColCount;
      }
      set
      {
        this.fGrid.FrozenColCount = value;
      }
    }

    /// <summary>Gets or sets the style of the grid line which separates the frozen rows from non-frozen.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGPenStyle" /> object. The default values for the <see cref="F:TenTec.Windows.iGridLib.iGPenStyle.Width" />, <see cref="F:TenTec.Windows.iGridLib.iGPenStyle.Color" /> and <see cref="F:TenTec.Windows.iGridLib.iGPenStyle.DashStyle" /> properties of this <see cref="T:TenTec.Windows.iGridLib.iGPenStyle" /> object are 2, <see cref="P:System.Drawing.SystemColors.ControlDarkDark" /> and <see cref="F:System.Drawing.Drawing2D.DashStyle.Solid" /> respectively.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The style of the grid line which separates the frozen rows from non-frozen.")]
    public iGPenStyle RowsEdge
    {
      get
      {
        return this.fGrid.FrozenRowsSeparatingLine;
      }
      set
      {
        this.fGrid.FrozenRowsSeparatingLine = value;
      }
    }

    /// <summary>Gets or sets the style of the grid line which separates the frozen columns from non-frozen.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGPenStyle" /> object. The default values for the <see cref="F:TenTec.Windows.iGridLib.iGPenStyle.Width" />, <see cref="F:TenTec.Windows.iGridLib.iGPenStyle.Color" /> and <see cref="F:TenTec.Windows.iGridLib.iGPenStyle.DashStyle" /> properties of this <see cref="T:TenTec.Windows.iGridLib.iGPenStyle" /> object are 2, <see cref="P:System.Drawing.SystemColors.ControlDarkDark" /> and <see cref="F:System.Drawing.Drawing2D.DashStyle.Solid" /> respectively.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The style of the grid line which separates the frozen columns from non-frozen.")]
    public iGPenStyle ColsEdge
    {
      get
      {
        return this.fGrid.FrozenColsSeparatingLine;
      }
      set
      {
        this.fGrid.FrozenColsSeparatingLine = value;
      }
    }

    /// <summary>Gets or sets a value determining whether to sort the frozen rows.</summary>
    /// <value>True if frozen rows should take part in sorting; otherwise, False.</value>
    [DefaultValue(false)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines whether to sort the frozen rows.")]
    public bool SortFrozenRows
    {
      get
      {
        return this.fGrid.SortFrozenRows;
      }
      set
      {
        this.fGrid.SortFrozenRows = value;
      }
    }
  }
}
