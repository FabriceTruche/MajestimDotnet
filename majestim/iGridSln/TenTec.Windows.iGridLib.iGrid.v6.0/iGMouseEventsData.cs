// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGMouseEventsData
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.Drawing;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  internal struct iGMouseEventsData
  {
    private static iGMouseEventsData fEmpty = new iGMouseEventsData();
    private const int cEmptyRowIndex = -1;
    private const int cEmptyColOrder = -1;
    private const int cBandExtraCellColOrder = 2147483647;
    private const int cBandExtraCellRowIndex = 0;
    private const int cBandRowHdrColOrder = -1;
    private const int cBandRowHdrRowIndex = 0;
    public int RowIndex;
    public int RowCount;
    public int ColOrder;
    public int ColCount;
    public Rectangle Bounds;
    public iGMouseArea Area;
    public Point MousePos;
    public MouseButtons Button;
    public Point MouseDownMousePos;
    public bool MouseDownOnTheCurCell;
    public bool MouseDownOnAColHdr;
    public object Tag;
    public iGControlState State;
    public bool IsGroupBox;
    public iGElemControl ElemControl;

    public static iGMouseEventsData Empty
    {
      get
      {
        return iGMouseEventsData.fEmpty;
      }
    }

    public bool IsEmpty
    {
      get
      {
        if (this.RowIndex == -1)
          return this.ColOrder == -1;
        return false;
      }
    }

    static iGMouseEventsData()
    {
      iGMouseEventsData.fEmpty.RowIndex = -1;
      iGMouseEventsData.fEmpty.ColOrder = -1;
    }

    public iGMouseEventsData(int rowIndex, int rowCount, int colOrder, int colCount, iGMouseArea area, iGControlState state, Rectangle bounds, Point mousePos, object tag, bool isGroupBox, iGElemControl elemControl, MouseButtons button)
    {
      this.RowIndex = rowIndex;
      this.RowCount = rowCount;
      this.ColOrder = colOrder;
      this.ColCount = colCount;
      this.Area = area;
      this.State = state;
      this.Bounds = bounds;
      this.MousePos = mousePos;
      this.MouseDownMousePos = Point.Empty;
      this.Tag = tag;
      this.IsGroupBox = isGroupBox;
      this.MouseDownOnTheCurCell = false;
      this.MouseDownOnAColHdr = false;
      this.ElemControl = elemControl;
      this.Button = button;
    }

    private static iGMouseEventsData CreateHeaderEmptyData(int rowCount, iGControlState state, Rectangle bounds, Point mousePos)
    {
      return new iGMouseEventsData()
      {
        Area = iGMouseArea.Header,
        RowCount = rowCount,
        State = state,
        Bounds = bounds,
        MousePos = mousePos
      };
    }

    public static iGMouseEventsData CreateHeaderExtraCellData(int rowCount, iGControlState state, Rectangle bounds, Point mousePos)
    {
      iGMouseEventsData headerEmptyData = iGMouseEventsData.CreateHeaderEmptyData(rowCount, state, bounds, mousePos);
      headerEmptyData.RowIndex = 0;
      headerEmptyData.ColOrder = int.MaxValue;
      return headerEmptyData;
    }

    public static iGMouseEventsData CreateHeaderRowHdrData(int rowCount, iGControlState state, Rectangle bounds, Point mousePos)
    {
      iGMouseEventsData headerEmptyData = iGMouseEventsData.CreateHeaderEmptyData(rowCount, state, bounds, mousePos);
      headerEmptyData.RowIndex = 0;
      headerEmptyData.ColOrder = -1;
      return headerEmptyData;
    }

    private static iGMouseEventsData CreateFooterEmptyData(int rowCount, Rectangle bounds, Point mousePos)
    {
      return new iGMouseEventsData()
      {
        Area = iGMouseArea.Footer,
        RowCount = rowCount,
        State = iGControlState.Normal,
        Bounds = bounds,
        MousePos = mousePos
      };
    }

    public static iGMouseEventsData CreateFooterExtraCellData(int rowCount, Rectangle bounds, Point mousePos)
    {
      iGMouseEventsData footerEmptyData = iGMouseEventsData.CreateFooterEmptyData(rowCount, bounds, mousePos);
      footerEmptyData.RowIndex = 0;
      footerEmptyData.ColOrder = int.MaxValue;
      return footerEmptyData;
    }

    public static iGMouseEventsData CreateFooterRowHdrData(int rowCount, Rectangle bounds, Point mousePos)
    {
      iGMouseEventsData footerEmptyData = iGMouseEventsData.CreateFooterEmptyData(rowCount, bounds, mousePos);
      footerEmptyData.RowIndex = 0;
      footerEmptyData.ColOrder = -1;
      return footerEmptyData;
    }

    public bool IsHeaderExtraCell
    {
      get
      {
        if (this.Area == iGMouseArea.Header && this.ColOrder == int.MaxValue)
          return this.RowIndex == 0;
        return false;
      }
    }

    public bool IsHeaderRowHdr
    {
      get
      {
        if (this.Area == iGMouseArea.Header && this.ColOrder == -1)
          return this.RowIndex == 0;
        return false;
      }
    }

    public bool IsFooterExtraCell
    {
      get
      {
        if (this.Area == iGMouseArea.Footer && this.ColOrder == int.MaxValue)
          return this.RowIndex == 0;
        return false;
      }
    }

    public bool IsFooterRowHdr
    {
      get
      {
        if (this.Area == iGMouseArea.Footer && this.ColOrder == -1)
          return this.RowIndex == 0;
        return false;
      }
    }
  }
}
