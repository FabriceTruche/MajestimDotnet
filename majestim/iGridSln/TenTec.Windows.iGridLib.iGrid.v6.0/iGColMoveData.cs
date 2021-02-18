// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGColMoveData
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  internal class iGColMoveData
  {
    public Bitmap MoveColHdrBitmap;
    public Bitmap HeaderBitmap;
    public iGIndent ColHdrIndent;
    public int StartOrder;
    public int EndOrder;
    public bool[] Rows;
    public bool CanBeGrouped;
    public int MoveToOrderOrGroupIndex;
    public bool MoveToGroupBox;
    public bool CanPlaceTo;
    public int RealColOrder;
    public int RealColCount;
    public int AutoScrollDX;

    public iGColMoveData(Bitmap headerBitmap, Bitmap colHdrBitmap, iGIndent colHdrIndent, int startOrder, int endOrder, bool[] rows, bool canBeGrouped, int realColOrder, int realColCount, int autoScrollDX)
    {
      this.HeaderBitmap = headerBitmap;
      this.MoveColHdrBitmap = colHdrBitmap;
      this.ColHdrIndent = colHdrIndent;
      this.StartOrder = startOrder;
      this.EndOrder = endOrder;
      this.Rows = rows;
      this.CanBeGrouped = canBeGrouped;
      this.MoveToOrderOrGroupIndex = -1;
      this.CanPlaceTo = false;
      this.MoveToGroupBox = false;
      this.RealColOrder = realColOrder;
      this.RealColCount = realColCount;
      this.AutoScrollDX = autoScrollDX;
    }
  }
}
