// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGFooterCellStyle
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.ComponentModel;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Defines the appearance and behavior of a footer cell.</summary>
  [DesignTimeVisible(false)]
  [ToolboxItem(false)]
  public class iGFooterCellStyle : iGStyleBase, ICloneable
  {
    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGFooterCellStyle" /> class.</summary>
    public iGFooterCellStyle()
      : base(false)
    {
    }

    internal override iGCellDrawType DrawType
    {
      get
      {
        return iGCellDrawType.Text;
      }
    }

    internal override iGCellDrawTypeFlags DrawTypeFlags
    {
      get
      {
        return iGCellDrawTypeFlags.None;
      }
    }

    internal override iGCellDrawFlags DrawFlags
    {
      get
      {
        return iGCellDrawFlags.DisplayText | iGCellDrawFlags.DisplayImage;
      }
    }

    /// <summary>Creates an exact copy of this <see cref="T:TenTec.Windows.iGridLib.iGCellStyle" /> object.</summary>
    /// <returns>The exact copy of this object.</returns>
    public iGFooterCellStyle Clone()
    {
      iGFooterCellStyle gfooterCellStyle = new iGFooterCellStyle();
      gfooterCellStyle.CloneProperties((iGStyleBase) this);
      return gfooterCellStyle;
    }

    private void CloneOwnProperties(iGFooterCellStyle fromStyle)
    {
    }

    /// <summary>Copies the properties from the specified footer cell style object into this object.</summary>
    /// <param name="fromStyle">The <see cref="T:TenTec.Windows.iGridLib.iGStyleBase" /> object to copy the properties from.</param>
    public override void CloneProperties(iGStyleBase fromStyle)
    {
      this.CloneOwnProperties((iGFooterCellStyle) fromStyle);
      base.CloneProperties(fromStyle);
    }

    object ICloneable.Clone()
    {
      return (object) this.Clone();
    }
  }
}
