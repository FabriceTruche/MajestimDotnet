// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCellStyleDesign
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.ComponentModel;
using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Defines the appearance and behavior of a cell. Intended to be used at design time.</summary>
  [DesignTimeVisible(true)]
  [ToolboxItem(true)]
  [TypeConverter("TenTec.Windows.iGridLib.Design.iGCellStyleDesignConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
  [ToolboxBitmap(typeof (iGrid), "Resources.ToolBoxiGCellStyle.bmp")]
  [Description("The iGrid cell style object designated for using at design time. Concentrates cell formatting options at one place to format a set of cells the same way.")]
  public class iGCellStyleDesign : iGCellStyle
  {
    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCellStyleDesign" /> class.</summary>
    public iGCellStyleDesign()
      : base(false)
    {
    }
  }
}
