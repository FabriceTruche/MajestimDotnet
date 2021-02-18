// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGResizeRowData
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

namespace TenTec.Windows.iGridLib
{
  internal struct iGResizeRowData
  {
    public int BaseRowHeight;
    public int BaseVScrollBarValue;
    public int NewRowHeight;
    public int MinHeight;
    public int MaxHeight;
    public bool IsOverRowHdr;

    public iGResizeRowData(int baseRowHeight, int baseVScrollBarValue, int newRowHeight, int minHeight, int maxHeight, bool isOverRowHdr)
    {
      this.BaseRowHeight = baseRowHeight;
      this.BaseVScrollBarValue = baseVScrollBarValue;
      this.NewRowHeight = newRowHeight;
      this.MinHeight = minHeight;
      this.MaxHeight = maxHeight;
      this.IsOverRowHdr = isOverRowHdr;
    }
  }
}
