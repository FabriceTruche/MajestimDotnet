// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGColHdrNavigator
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  internal struct iGColHdrNavigator
  {
    public int RowIndex;
    public int ColIndex;
    public Rectangle Bounds;

    public iGColHdrNavigator(int rowIndex, int colIndex, Rectangle bounds)
    {
      this.ColIndex = colIndex;
      this.RowIndex = rowIndex;
      this.Bounds = bounds;
    }

    private bool Equals(iGColHdrNavigator compareTo)
    {
      if (this.RowIndex == compareTo.RowIndex)
        return this.ColIndex == compareTo.ColIndex;
      return false;
    }

    public bool IsEmpty
    {
      get
      {
        if (this.RowIndex == -1 && this.ColIndex == -1)
          return this.Bounds.IsEmpty;
        return false;
      }
    }

    public static iGColHdrNavigator Empty
    {
      get
      {
        return new iGColHdrNavigator(-1, -1, Rectangle.Empty);
      }
    }
  }
}
