// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGFooterRow
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.ComponentModel;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents a footer row in an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public sealed class iGFooterRow
  {
    internal iGrid fGrid;
    internal int fIndex;
    private iGFooterRowCellCollection fCells;

    /// <summary>Returns the <see cref="T:TenTec.Windows.iGridLib.iGrid" /> object this instance belongs to.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGrid" /> object.</value>
    [Browsable(false)]
    public iGrid Grid
    {
      get
      {
        return this.fGrid;
      }
    }

    internal iGFooterRow(iGrid grid, int index)
    {
      grid.CheckFooterRowIndex(index);
      this.fGrid = grid;
      this.fIndex = index;
    }

    /// <summary>Retrieves the string representation of the footer row.</summary>
    /// <returns>A string that represents the footer row.</returns>
    public override string ToString()
    {
      return string.Format("{0}(RowIndex = {1})", (object) this.GetType().Name, (object) this.fIndex);
    }

    /// <summary>Gets or sets the height of the footer row.</summary>
    /// <value>The height of the whole footer row. The default is 17.</value>
    public int Height
    {
      get
      {
        return this.fGrid.GetFooterRowData(this.fIndex).Height;
      }
      set
      {
        this.fGrid.SetFooterRowHeight(this.fIndex, value, true);
      }
    }

    /// <summary>Gets or sets a value indicating whether the footer row is visible.</summary>
    /// <value>A Boolean value that indicates whether a footer row is visible (True) or hidden (False). The default is True.</value>
    public bool Visible
    {
      get
      {
        return this.fGrid.GetFooterRowData(this.fIndex).Visible;
      }
      set
      {
        this.fGrid.SetFooterRowVisible(this.fIndex, value);
      }
    }

    /// <summary>Gets the index of the footer row within the footer area.</summary>
    /// <value>The zero-based index of the footer row within the grid's footer area.</value>
    public int Index
    {
      get
      {
        return this.fIndex;
      }
    }

    /// <summary>Gets the Y-coordinate of the footer row. The coordinate is relative to the upper left corner of the grid.</summary>
    /// <value>The y-coordinate of the footer row. The coordinate is relative to the upper left corner of the grid.</value>
    public int Y
    {
      get
      {
        return this.fGrid.FooterRowToY(this.fIndex);
      }
    }

    /// <summary>Gets the collection of the cell in the footer row.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGFooterRowCellCollection" /> collection that represents the cells in the footer row.</value>
    public iGFooterRowCellCollection Cells
    {
      get
      {
        if (this.fCells == null)
          this.fCells = new iGFooterRowCellCollection(this);
        return this.fCells;
      }
    }

    /// <summary>Adjusts the height of the footer row to display the contents of all its cells entirely.</summary>
    public void AutoHeight()
    {
      this.fGrid.AutoHeightFooterRow(this.fIndex, true);
    }
  }
}
