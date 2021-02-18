// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGHdrRow
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.ComponentModel;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents a header row in an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGHdrRow
  {
    private iGrid fGrid;
    private int fIndex;

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

    internal iGHdrRow(iGrid grid, int rowIndex)
    {
      this.fGrid = grid;
      this.fIndex = rowIndex;
    }

    /// <summary>Adjusts the height of the header row to display the contents of all its cells (column headers) entirely.</summary>
    public void AutoHeight()
    {
      this.fGrid.AutoHeightHeaderRow(this.fIndex, true);
    }

    /// <summary>Retrieves the string representation of the header row.</summary>
    /// <returns>A string that represents the header row.</returns>
    public override string ToString()
    {
      return string.Format("iGHdrRow(RowIndex = {0})", (object) this.fIndex);
    }

    /// <summary>Gets or sets the height of the header row.</summary>
    /// <value>The height of the header row. The default is 18.</value>
    public int Height
    {
      get
      {
        return this.fGrid.GetHeaderRow(this.fIndex).Height;
      }
      set
      {
        this.fGrid.SetHeaderRowHeight(this.fIndex, value, true);
      }
    }

    /// <summary>Gets or sets a value indicating whether the header row is visible or not.</summary>
    /// <value>True is the header row is visible; otherwise, False. The default value is True.</value>
    public bool Visible
    {
      get
      {
        return this.fGrid.GetHeaderRow(this.fIndex).Visible;
      }
      set
      {
        this.fGrid.SetHeaderRowVisible(this.fIndex, value);
      }
    }

    /// <summary>Gets or sets the index of the header row within the grid.</summary>
    /// <value>The zero-based index of the header row.</value>
    public int Index
    {
      get
      {
        return this.fIndex;
      }
    }

    /// <summary>Gets the y-coordinate of the header row. The coordinate is relative to the upper left corner of the grid.</summary>
    /// <value>The y-coordinate of the header row. The coordinate is relative to the upper left corner of the grid.</value>
    public int Y
    {
      get
      {
        return this.fGrid.HeaderRowToY(this.fIndex);
      }
    }
  }
}
