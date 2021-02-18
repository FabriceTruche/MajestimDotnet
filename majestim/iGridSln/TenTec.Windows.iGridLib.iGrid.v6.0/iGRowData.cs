// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGRowData
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

namespace TenTec.Windows.iGridLib
{
  internal struct iGRowData
  {
    internal const int cDefaultHeight = 17;
    internal const int cDefaultNormalCellHeight = 17;
    internal const bool cDefaultVisible = true;
    internal const iGRowType cDefaultRowType = iGRowType.Normal;
    internal const int cDefaultLevel = 0;
    internal const bool cDefaultExpanded = true;
    internal const bool cDefaultVisibleParentExpanded = true;
    internal const bool cDefaultSortable = true;
    internal const iGTreeButtonState cDefaultTreeButton = iGTreeButtonState.Absent;
    internal const bool cDefaultSelectable = true;
    public int Height;
    public int NormalCellHeight;
    public bool Visible;
    public iGRowType Type;
    public string Key;
    public bool Expanded;
    public bool VisibleParentExpanded;
    public int Level;
    public bool Sortable;
    public iGTreeButtonState TreeButton;
    public object Tag;
    public bool Selectable;
    public iGCellStyle CellStyle;

    public iGRowData(int height)
    {
      this.Height = height;
      this.NormalCellHeight = 17;
      this.Visible = true;
      this.Type = iGRowType.Normal;
      this.Tag = (object) null;
      this.Key = (string) null;
      this.Expanded = true;
      this.VisibleParentExpanded = true;
      this.Level = 0;
      this.Sortable = true;
      this.TreeButton = iGTreeButtonState.Absent;
      this.Selectable = true;
      this.CellStyle = (iGCellStyle) null;
    }

    public iGRowData(int height, int normalCellHeight)
    {
      this.Height = height;
      this.NormalCellHeight = normalCellHeight;
      this.Visible = true;
      this.Type = iGRowType.Normal;
      this.Tag = (object) null;
      this.Key = (string) null;
      this.Expanded = true;
      this.VisibleParentExpanded = true;
      this.Level = 0;
      this.Sortable = true;
      this.TreeButton = iGTreeButtonState.Absent;
      this.Selectable = true;
      this.CellStyle = (iGCellStyle) null;
    }
  }
}
