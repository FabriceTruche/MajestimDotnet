// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGDesignTimeDefaultRowPattern
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.ComponentModel;
using System.ComponentModel.Design;

namespace TenTec.Windows.iGridLib
{
  [TypeConverter("TenTec.Windows.iGridLib.Design.iGTypeConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
  internal class iGDesignTimeDefaultRowPattern : iGRowPattern
  {
    private iGrid fGrid;

    public iGDesignTimeDefaultRowPattern(iGrid grid)
    {
      this.fGrid = grid;
    }

    internal override bool ShouldSerializeCellStyle()
    {
      return base.ShouldSerializeCellStyle();
    }

    internal override void ResetCellStyle()
    {
      DesignerTransaction transaction = (DesignerTransaction) null;
      if (this.fGrid != null)
        transaction = this.fGrid.BeforeChangePropWithStyle("DefaultRow.CellStyle", "DefaultRow");
      try
      {
        this.CellStyle = (iGCellStyle) null;
      }
      finally
      {
        if (this.fGrid != null)
          this.fGrid.AfterChangePropWithStyle("DefaultRow", transaction);
      }
    }
  }
}
