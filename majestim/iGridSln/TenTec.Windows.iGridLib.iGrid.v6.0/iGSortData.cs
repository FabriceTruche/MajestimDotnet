// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGSortData
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

namespace TenTec.Windows.iGridLib
{
  internal struct iGSortData
  {
    public int ColIndex;
    public iGSortOrder Order;
    public iGSortType Type;
    public bool IsGrouped;
    public bool CustomGrouping;
    public object[] CustomGroupValues;

    public iGSortData(int colIndex, iGSortOrder order, iGSortType type, bool isGrouped, bool customGrouping, object[] customGroupValues)
    {
      this.ColIndex = colIndex;
      this.Order = order;
      this.Type = type;
      this.IsGrouped = isGrouped;
      this.CustomGrouping = customGrouping;
      this.CustomGroupValues = customGroupValues;
    }
  }
}
