// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGColResizeData
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

namespace TenTec.Windows.iGridLib
{
  internal struct iGColResizeData
  {
    public int[] OldWidths;
    public int DeltaScrollPos;
    public int OldX;
    public int LastRight;
    public int VisibleAllowedCount;
    public int MinWidth;
    public int MaxWidth;
    public int ColsX;
    public int ColsWidth;

    public iGColResizeData(int[] oldWidthts, int deltaScrollPos, int oldX, int lastRight, int visibleAllowedCount, int minWidth, int maxWidth, int colsX, int colsWidth)
    {
      this.OldWidths = oldWidthts;
      this.DeltaScrollPos = deltaScrollPos;
      this.OldX = oldX;
      this.LastRight = lastRight;
      this.VisibleAllowedCount = visibleAllowedCount;
      this.MinWidth = minWidth;
      this.MaxWidth = maxWidth;
      this.ColsX = colsX;
      this.ColsWidth = colsWidth;
    }
  }
}
