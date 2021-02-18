// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGColData
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

namespace TenTec.Windows.iGridLib
{
  internal struct iGColData
  {
    internal const int cDefaultWidth = 64;
    internal const bool cDefaultVisible = true;
    internal const bool cDefaultIncludeInSelect = true;
    internal const int cDefaultMinWidth = -1;
    internal const int cDefaultMaxWidth = -1;
    internal const bool cDefaultAllowSizing = true;
    internal const bool cDefaultAllowMoving = true;
    internal const bool cDefaultAllowGrouping = true;
    internal const iGSortType cDefaultSortType = iGSortType.ByValue;
    internal const iGSortOrder cDefaultSortOrder = iGSortOrder.Ascending;
    internal const bool cDefaultCustomGrouping = false;
    internal const bool cDefaultShowWhenGrouped = false;
    public int Width;
    public bool Visible;
    public bool IncludeInSelect;
    public int MinWidth;
    public int MaxWidth;
    public bool AllowSizing;
    public bool AllowMoving;
    public bool AllowGrouping;
    public iGSortType SortType;
    public iGSortOrder SortOrder;
    public bool CustomGrouping;
    public iGCellStyle CellStyle;
    public iGColHdrStyle ColHdrStyle;
    public object Tag;
    public string Key;
    public bool ShowWhenGrouped;

    public iGColData(int width, bool visible, bool includeInSelect, int minWidth, int maxWidth, bool allowSizing, bool allowMoving, bool allowGrouping, iGSortType sortType, iGSortOrder sortOrder, bool customGrouping, iGCellStyle cellStyle, iGColHdrStyle colHdrStyle, object tag, string key, bool showWhenGrouped)
    {
      this.Width = width;
      this.Visible = visible;
      this.IncludeInSelect = includeInSelect;
      this.MinWidth = minWidth;
      this.MaxWidth = maxWidth;
      this.AllowSizing = allowSizing;
      this.AllowMoving = allowMoving;
      this.AllowGrouping = allowGrouping;
      this.SortType = sortType;
      this.SortOrder = sortOrder;
      this.CustomGrouping = customGrouping;
      this.CellStyle = cellStyle;
      this.ColHdrStyle = colHdrStyle;
      this.Tag = tag;
      this.Key = key;
      this.ShowWhenGrouped = showWhenGrouped;
    }
  }
}
