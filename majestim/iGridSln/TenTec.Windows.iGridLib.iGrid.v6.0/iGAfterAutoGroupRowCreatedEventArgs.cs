// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGAfterAutoGroupRowCreatedEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.AfterAutoGroupRowCreated" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGAfterAutoGroupRowCreatedEventArgs : EventArgs
  {
    /// <summary>The index of the auto group row that have just been created.</summary>
    public readonly int AutoGroupRowIndex;
    /// <summary>The index of the first row in the group that have just been created.</summary>
    public readonly int GroupedRowIndex;
    /// <summary>The index of the column used for grouping.</summary>
    public readonly int GroupedColIndex;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGAfterAutoGroupRowCreatedEventArgs" /> class.</summary>
    /// <param name="autoGroupRowIndex">The index of the auto group row that have just been created.</param>
    /// <param name="groupedRowIndex">The index of the first row in the group that have just been created.</param>
    /// <param name="groupedColIndex">The index of the column used for grouping.</param>
    public iGAfterAutoGroupRowCreatedEventArgs(int autoGroupRowIndex, int groupedRowIndex, int groupedColIndex)
    {
      this.AutoGroupRowIndex = autoGroupRowIndex;
      this.GroupedRowIndex = groupedRowIndex;
      this.GroupedColIndex = groupedColIndex;
    }
  }
}
