// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCellData
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

namespace TenTec.Windows.iGridLib
{
  internal struct iGCellData
  {
    internal const int cDefaultImageIndex = -1;
    public object Value;
    public object AuxValue;
    public int ImageIndex;
    public iGCellStyle Style;
    public int SpanRows;
    public int SpanCols;

    public iGCellData(object value)
    {
      this.Value = value;
      this.AuxValue = (object) null;
      this.Style = (iGCellStyle) null;
      this.ImageIndex = -1;
      this.SpanCols = 1;
      this.SpanRows = 1;
    }

    public iGCellData(object value, int imageIndex)
    {
      this.Value = value;
      this.AuxValue = (object) null;
      this.Style = (iGCellStyle) null;
      this.ImageIndex = imageIndex;
      this.SpanCols = 1;
      this.SpanRows = 1;
    }

    public iGCellData(object value, object auxValue)
    {
      this.Value = value;
      this.AuxValue = auxValue;
      this.Style = (iGCellStyle) null;
      this.ImageIndex = -1;
      this.SpanCols = 1;
      this.SpanRows = 1;
    }

    public iGCellData(object value, int imageIndex, iGCellStyle style)
    {
      this.Value = value;
      this.AuxValue = (object) null;
      this.Style = style;
      this.ImageIndex = imageIndex;
      this.SpanCols = 1;
      this.SpanRows = 1;
    }

    public iGCellData(object value, object auxValue, int imageIndex, iGCellStyle style)
    {
      this.Value = value;
      this.AuxValue = auxValue;
      this.Style = style;
      this.ImageIndex = imageIndex;
      this.SpanCols = 1;
      this.SpanRows = 1;
    }

    public iGCellData(object value, object auxValue, int imageIndex, iGCellStyle style, int spanCols, int spanRows)
    {
      this.Value = value;
      this.AuxValue = auxValue;
      this.Style = style;
      this.ImageIndex = imageIndex;
      this.SpanCols = spanCols;
      this.SpanRows = spanRows;
    }
  }
}
