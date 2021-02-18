// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGFooterCellData
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

namespace TenTec.Windows.iGridLib
{
  internal struct iGFooterCellData
  {
    internal const int cDefaultImageIndex = -1;
    public object Value;
    public object AuxValue;
    public int ImageIndex;
    public iGFooterCellStyle Style;
    public iGAggregateFunction AggregateFunction;

    public static iGFooterCellData DefaultFactory()
    {
      return new iGFooterCellData() { ImageIndex = -1 };
    }

    public static iGFooterCellData[] DefaultArrayFactory(int capacity)
    {
      iGFooterCellData[] iGfooterCellDataArray = new iGFooterCellData[capacity];
      for (int index = 0; index < capacity; ++index)
        iGfooterCellDataArray[index].ImageIndex = -1;
      return iGfooterCellDataArray;
    }
  }
}
