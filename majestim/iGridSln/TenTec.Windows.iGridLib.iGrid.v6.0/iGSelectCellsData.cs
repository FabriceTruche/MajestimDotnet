// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGSelectCellsData
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  internal class iGSelectCellsData
  {
    public int EndRowIndex;
    public int EndColOrder;
    public Rectangle EndBounds;
    public Rectangle CellsAreaBounds;
    public int AutoScrollDX;
    public int AutoScrollDY;
    public int OldHScrollValue;
    public int OldVScrollValue;

    public iGSelectCellsData(int endRowIndex, int endColOrder, Rectangle endBounds, Rectangle cellsAreaBounds, int autoScrollDX, int autoScrollDY, int oldHScrollValue, int oldVScrollValue)
    {
      this.EndRowIndex = endRowIndex;
      this.EndColOrder = endColOrder;
      this.EndBounds = endBounds;
      this.CellsAreaBounds = cellsAreaBounds;
      this.AutoScrollDX = autoScrollDX;
      this.AutoScrollDY = autoScrollDY;
      this.OldHScrollValue = oldHScrollValue;
      this.OldVScrollValue = oldVScrollValue;
    }
  }
}
