// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGFillWithDataRowAddedEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Data;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.FillWithDataRowAdded" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGFillWithDataRowAddedEventArgs : EventArgs
  {
    /// <summary>The row index of the row which has been created and populated while executing the <see cref="Overload:TenTec.Windows.iGridLib.iGrid.FillWithData" /> method.</summary>
    public readonly int RowIndex;
    /// <summary>A <see cref="T:System.Data.DataRow" /> object used to populate the row which has been created while executing the <see cref="Overload:TenTec.Windows.iGridLib.iGrid.FillWithData" /> method.</summary>
    public readonly DataRow DataRow;
    /// <summary>An <see cref="T:System.Data.IDataReader" /> object used to populate the row which has been created while executing the <see cref="Overload:TenTec.Windows.iGridLib.iGrid.FillWithData" /> method.</summary>
    public readonly IDataReader DataReader;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGFillWithDataRowAddedEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the row which has been created and populated while executing the <see cref="Overload:TenTec.Windows.iGridLib.iGrid.FillWithData" /> method.</param>
    /// <param name="dataRow">A <see cref="T:System.Data.DataRow" /> object used to populate the row which has been created while executing the <see cref="Overload:TenTec.Windows.iGridLib.iGrid.FillWithData" /> method.</param>
    /// <param name="dataReader">An <see cref="T:System.Data.IDataReader" /> object used to populate the row which has been created while executing the <see cref="Overload:TenTec.Windows.iGridLib.iGrid.FillWithData" /> method.</param>
    public iGFillWithDataRowAddedEventArgs(int rowIndex, DataRow dataRow, IDataReader dataReader)
    {
      this.RowIndex = rowIndex;
      this.DataRow = dataRow;
      this.DataReader = dataReader;
    }
  }
}
