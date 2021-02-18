// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGPenStyle
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents the style of a pen used to draw grid lines in an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  [TypeConverter("TenTec.Windows.iGridLib.Design.iGPenStyleConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
  public class iGPenStyle : ICloneable
  {
    private static readonly Color cDefaultColor = SystemColors.ControlDark;
    private const int cDefaultWidth = 1;
    private const DashStyle cDefaultDashStyle = DashStyle.Solid;
    /// <summary>Gets or sets the color of the grid line.</summary>
    [Description("The color of the grid line.")]
    public Color Color;
    /// <summary>Gets or sets the width of the grid line.</summary>
    [Description("The width of the grid line.")]
    public int Width;
    /// <summary>Gets or sets the dash style of the grid line.</summary>
    [Description("The dash style of the grid line.")]
    public DashStyle DashStyle;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGPenStyle" /> class.</summary>
    public iGPenStyle()
    {
      this.Color = iGPenStyle.cDefaultColor;
      this.Width = 1;
      this.DashStyle = DashStyle.Solid;
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGPenStyle" /> class with the specified property values.</summary>
    /// <param name="color">Specifies the color of a grid line.</param>
    /// <param name="width">Specifies the width of a grid line.</param>
    /// <param name="dashStyle">Specifies the dash style of a grid line.</param>
    public iGPenStyle(Color color, int width, DashStyle dashStyle)
    {
      this.Color = color;
      this.Width = width;
      this.DashStyle = dashStyle;
    }

    internal bool Equals(iGPenStyle value)
    {
      if (this.Color == value.Color && this.DashStyle == value.DashStyle)
        return this.Width == value.Width;
      return false;
    }

    /// <summary>Creates an exact copy of this <see cref="T:TenTec.Windows.iGridLib.iGPenStyle" /> object.</summary>
    /// <returns>The exact copy of this object.</returns>
    public iGPenStyle Clone()
    {
      return new iGPenStyle(this.Color, this.Width, this.DashStyle);
    }

    object ICloneable.Clone()
    {
      return (object) this.Clone();
    }
  }
}
