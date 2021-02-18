// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGIncludeRowInTotalsCalculationEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.IncludeRowInTotalsCalculation" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGIncludeRowInTotalsCalculationEventArgs : EventArgs
  {
    internal int fRowIndex;
    internal int fColIndex;
    internal int fFooterRowIndex;
    internal bool fDoDefault;

    /// <summary>The row index of the grid cell.</summary>
    /// <value>An integer row index of the grid cell.</value>
    public int RowIndex
    {
      get
      {
        return this.fRowIndex;
      }
    }

    /// <summary>The column index of the grid cell.</summary>
    /// <value>An integer colum nindex of the grid cell.</value>
    public int ColIndex
    {
      get
      {
        return this.fColIndex;
      }
    }

    /// <summary>The index of the footer row the aggregate function is calculated for.</summary>
    /// <value>An integer index of the footer row the aggregate function is calculated for.</value>
    public int FooterRowIndex
    {
      get
      {
        return this.fFooterRowIndex;
      }
    }

    /// <summary>Indicates whether the grid cell should be included into the calculation of the aggregate function.</summary>
    /// <value>A Boolean value that indicates whether the grid cell should be included into the calculation of the aggregate function.</value>
    public bool DoDefault
    {
      get
      {
        return this.fDoDefault;
      }
      set
      {
        this.fDoDefault = value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGIncludeRowInTotalsCalculationEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the grid cell.</param>
    /// <param name="colIndex">The column index of the grid cell.</param>
    /// <param name="footerRowIndex">The index of the footer row the aggregate function is calculated for.</param>
    public iGIncludeRowInTotalsCalculationEventArgs(int rowIndex, int colIndex, int footerRowIndex)
    {
      this.fRowIndex = rowIndex;
      this.fColIndex = colIndex;
      this.fFooterRowIndex = footerRowIndex;
      this.fDoDefault = true;
    }
  }
}
