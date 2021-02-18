// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGDesignTimeDefaultColPattern
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.ComponentModel;
using System.ComponentModel.Design;

namespace TenTec.Windows.iGridLib
{
  [TypeConverter("TenTec.Windows.iGridLib.Design.iGTypeConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
  internal class iGDesignTimeDefaultColPattern : iGColPattern
  {
    public iGDesignTimeDefaultColPattern(iGrid grid)
      : base(grid)
    {
    }

    internal override bool ShouldSerializeCellStyle()
    {
      return base.ShouldSerializeCellStyle();
    }

    internal override bool ShouldSerializeColHdrStyle()
    {
      return base.ShouldSerializeColHdrStyle();
    }

    internal override void ResetCellStyle()
    {
      DesignerTransaction transaction = (DesignerTransaction) null;
      if (this.fGrid != null)
        transaction = this.fGrid.BeforeChangePropWithStyle("DefaultCol.CellStyle", "DefaultCol");
      try
      {
        this.CellStyle = new iGCellStyle(true);
      }
      finally
      {
        if (this.fGrid != null)
          this.fGrid.AfterChangePropWithStyle("DefaultCol", transaction);
      }
    }

    internal override void ResetColHdrStyle()
    {
      DesignerTransaction transaction = (DesignerTransaction) null;
      if (this.fGrid != null)
        transaction = this.fGrid.BeforeChangePropWithStyle("DefaultCol.ColHdrStyle", "DefaultCol");
      try
      {
        this.ColHdrStyle = new iGColHdrStyle(true);
      }
      finally
      {
        if (this.fGrid != null)
          this.fGrid.AfterChangePropWithStyle("DefaultCol", transaction);
      }
    }
  }
}
