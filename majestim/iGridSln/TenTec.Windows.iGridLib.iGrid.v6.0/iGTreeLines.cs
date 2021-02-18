// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGTreeLines
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Defines the style of the tree lines and their visibility.</summary>
  public class iGTreeLines
  {
    internal static readonly Color cDefaultColor = SystemColors.WindowText;
    internal const DashStyle cDefaultDashStyle = DashStyle.Dot;
    internal const bool cDefaultVisible = false;
    internal const bool cDefaultShowRootLines = true;
    private readonly iGrid fGrid;

    /// <summary>Returns the <see cref="T:TenTec.Windows.iGridLib.iGrid" /> object this instance belongs to.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGrid" /> object .</value>
    [Browsable(false)]
    public iGrid Grid
    {
      get
      {
        return this.fGrid;
      }
    }

    internal iGTreeLines(iGrid grid)
    {
      if (grid == null)
        throw new ArgumentNullException(nameof (grid));
      this.fGrid = grid;
    }

    private bool ShouldSerializeColor()
    {
      return this.Color != iGTreeLines.cDefaultColor;
    }

    private void ResetColor()
    {
      this.Color = iGTreeLines.cDefaultColor;
    }

    /// <summary>Specifies whether all the tree lines are visible or not.</summary>
    /// <value>Specifies whether all the tree lines are visible or not. The default value is True.</value>
    [Category("Appearance")]
    [Description("Determines whether to draw the tree lines.")]
    [DefaultValue(false)]
    public bool Visible
    {
      get
      {
        return this.fGrid.TreeLinesVisible;
      }
      set
      {
        this.fGrid.TreeLinesVisible = value;
      }
    }

    /// <summary>Specifies whether the tree lines between the items on the first level are drawn.</summary>
    /// <value>Specifies whether the tree lines between the items on the first level are drawn. The default value is True.</value>
    [Category("Appearance")]
    [Description("Determines whether lines are drawn between the tree nodes that are at the root.")]
    [DefaultValue(true)]
    public bool ShowRootLines
    {
      get
      {
        return this.fGrid.TreeLinesShowRootLines;
      }
      set
      {
        this.fGrid.TreeLinesShowRootLines = value;
      }
    }

    /// <summary>Gets or sets the color of the tree lines.</summary>
    /// <value>Gets or sets the color of the tree lines. The default is <see cref="P:System.Drawing.SystemColors.WindowText" />.</value>
    [Category("Appearance")]
    [Description("Determines the color of the tree lines.")]
    public Color Color
    {
      get
      {
        return this.fGrid.TreeLineColor;
      }
      set
      {
        this.fGrid.TreeLineColor = value;
      }
    }

    /// <summary>Gets or sets the dash style of the tree lines.</summary>
    /// <value>Gets or sets the dash style of the tree lines. The default is <see cref="F:System.Drawing.Drawing2D.DashStyle.Dot" />.</value>
    [Category("Appearance")]
    [Description("Determines the dash style of the tree lines.")]
    [DefaultValue(DashStyle.Dot)]
    public DashStyle DashStyle
    {
      get
      {
        return this.fGrid.TreeLineDashStyle;
      }
      set
      {
        this.fGrid.TreeLineDashStyle = value;
      }
    }
  }
}
