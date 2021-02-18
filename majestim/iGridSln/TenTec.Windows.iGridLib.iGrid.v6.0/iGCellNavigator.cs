// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCellNavigator
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

namespace TenTec.Windows.iGridLib
{
  internal struct iGCellNavigator
  {
    public int RowIndex;
    public int ColIndex;

    public iGCellNavigator(int rowIndex, int colIndex)
    {
      this.ColIndex = colIndex;
      this.RowIndex = rowIndex;
    }

    public override bool Equals(object obj)
    {
      if (!(obj is iGCellNavigator))
        return false;
      iGCellNavigator iGcellNavigator = (iGCellNavigator) obj;
      if (iGcellNavigator.ColIndex == this.ColIndex)
        return iGcellNavigator.RowIndex == this.RowIndex;
      return false;
    }

    public override int GetHashCode()
    {
      return this.ColIndex ^ this.RowIndex;
    }

    public static bool operator ==(iGCellNavigator val1, iGCellNavigator val2)
    {
      if (val1.ColIndex == val2.ColIndex)
        return val1.RowIndex == val2.RowIndex;
      return false;
    }

    public static bool operator !=(iGCellNavigator val1, iGCellNavigator val2)
    {
      return !(val1 == val2);
    }

    public override string ToString()
    {
      return "{" + "RowIndex=" + this.RowIndex.ToString() + ",ColIndex=" + this.ColIndex.ToString() + "}";
    }

    public bool IsEmpty
    {
      get
      {
        if (this.RowIndex == -1)
          return this.ColIndex == -1;
        return false;
      }
    }

    public static iGCellNavigator Empty
    {
      get
      {
        return new iGCellNavigator(-1, -1);
      }
    }
  }
}
