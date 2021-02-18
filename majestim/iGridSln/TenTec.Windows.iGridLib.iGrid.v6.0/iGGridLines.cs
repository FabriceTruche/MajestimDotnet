// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGGridLines
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents the grid lines in an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGGridLines
  {
    internal static readonly iGPenStyle cDefaultGridLineStyle = new iGPenStyle(SystemColors.ControlDark, 1, DashStyle.Solid);
    internal static readonly iGPenStyle cDefaultGroupRows = new iGPenStyle(SystemColors.ControlDark, 1, DashStyle.Solid);
    internal static readonly iGPenStyle cDefaultFrozenEdgeSeparatingLineStyle = new iGPenStyle(SystemColors.ControlDarkDark, 2, DashStyle.Solid);
    internal const iGGridLinesMode cDefaultExtendMode = iGGridLinesMode.None;
    internal const iGGridLinesMode cDefaultMode = iGGridLinesMode.Both;
    private iGrid fGrid;

    /// <summary>Returns the <see cref="T:TenTec.Windows.iGridLib.iGrid" /> object this instance belongs to.</summary>
    /// <value>Returns the <see cref="T:TenTec.Windows.iGridLib.iGrid" /> object this instance belongs to.</value>
    [Browsable(false)]
    public iGrid Grid
    {
      get
      {
        return this.fGrid;
      }
    }

    internal iGGridLines(iGrid grid)
    {
      this.fGrid = grid;
    }

    private bool ShouldSerializeVertical()
    {
      return !this.Vertical.Equals(iGGridLines.cDefaultGridLineStyle);
    }

    private bool ShouldSerializeHorizontal()
    {
      return !this.Horizontal.Equals(iGGridLines.cDefaultGridLineStyle);
    }

    private bool ShouldSerializeGroupRows()
    {
      return !this.GroupRows.Equals(iGGridLines.cDefaultGroupRows);
    }

    private bool ShouldSerializeVerticalLastCol()
    {
      return !this.VerticalLastCol.Equals(iGGridLines.cDefaultGridLineStyle);
    }

    private bool ShouldSerializeHorizontalLastRow()
    {
      return !this.HorizontalLastRow.Equals(iGGridLines.cDefaultGridLineStyle);
    }

    private bool ShouldSerializeVerticalExtended()
    {
      return !this.VerticalExtended.Equals(iGGridLines.cDefaultGridLineStyle);
    }

    private bool ShouldSerializeHorizontalExtended()
    {
      return !this.HorizontalExtended.Equals(iGGridLines.cDefaultGridLineStyle);
    }

    private void ResetHorizontal()
    {
      this.Horizontal = iGGridLines.cDefaultGridLineStyle.Clone();
    }

    private void ResetVertical()
    {
      this.Vertical = iGGridLines.cDefaultGridLineStyle;
    }

    private void ResetGroupRows()
    {
      this.GroupRows = iGGridLines.cDefaultGroupRows.Clone();
    }

    private void ResetVerticalLastCol()
    {
      this.VerticalLastCol = iGGridLines.cDefaultGridLineStyle.Clone();
    }

    private void ResetHorizontalLastRow()
    {
      this.HorizontalLastRow = iGGridLines.cDefaultGridLineStyle.Clone();
    }

    private void ResetHorizontalExtended()
    {
      this.HorizontalExtended = iGGridLines.cDefaultGridLineStyle.Clone();
    }

    private void ResetVerticalExtended()
    {
      this.VerticalExtended = iGGridLines.cDefaultGridLineStyle.Clone();
    }

    /// <summary>Gets or sets the style of the vertical grid lines.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGPenStyle" /> object.</value>
    [Description("The style of the vertical grid lines.")]
    public iGPenStyle Vertical
    {
      get
      {
        return this.fGrid.fVGridLinesStyle;
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException();
        if (object.Equals((object) this.fGrid.fVGridLinesStyle, (object) value))
          return;
        if (value.Width < 0)
          throw new ArgumentOutOfRangeException();
        this.fGrid.fVGridLinesStyle = value;
        if (!this.fGrid.fRedraw)
          return;
        this.fGrid.Invalidate();
      }
    }

    /// <summary>Gets or sets the style of the horizontal grid lines.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGPenStyle" /> object.</value>
    [Description("The style of the horizontal grid lines.")]
    public iGPenStyle Horizontal
    {
      get
      {
        return this.fGrid.fHGridLinesStyle;
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException();
        if (object.Equals((object) this.fGrid.fHGridLinesStyle, (object) value))
          return;
        if (value.Width < 0)
          throw new ArgumentOutOfRangeException();
        this.fGrid.fHGridLinesStyle = value;
        if (!this.fGrid.fRedraw)
          return;
        this.fGrid.Invalidate();
      }
    }

    /// <summary>Gets or sets the style of the extended vertical grid lines.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGPenStyle" /> object.</value>
    [Description("The style of the extended vertical grid lines.")]
    public iGPenStyle VerticalExtended
    {
      get
      {
        return this.fGrid.fVExtendedGridLineStyle;
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException();
        if (object.Equals((object) this.fGrid.fVExtendedGridLineStyle, (object) value))
          return;
        if (value.Width < 0)
          throw new ArgumentOutOfRangeException();
        this.fGrid.fVExtendedGridLineStyle = value;
        if (!this.fGrid.fRedraw)
          return;
        this.fGrid.Invalidate();
      }
    }

    /// <summary>Gets or sets the style of the extended horizontal grid lines.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGPenStyle" /> object.</value>
    [Description("The style of the extended horizontal grid lines.")]
    public iGPenStyle HorizontalExtended
    {
      get
      {
        return this.fGrid.fHExtendedGridLineStyle;
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException();
        if (object.Equals((object) this.fGrid.fHExtendedGridLineStyle, (object) value))
          return;
        if (value.Width < 0)
          throw new ArgumentOutOfRangeException();
        this.fGrid.fHExtendedGridLineStyle = value;
        if (!this.fGrid.fRedraw)
          return;
        this.fGrid.Invalidate();
      }
    }

    /// <summary>Gets or sets a value indicating whether to extend the grid lines horizontally or vertically.</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGGridLinesMode" /> enumeration values. The default is <see cref="F:TenTec.Windows.iGridLib.iGGridLinesMode.None" />.</value>
    [DefaultValue(iGGridLinesMode.None)]
    [Description("Allows you to specify whether to extend the grid lines horizontally or vertically.")]
    public iGGridLinesMode ExtendMode
    {
      get
      {
        return this.fGrid.fExtendGridLinesMode;
      }
      set
      {
        if (value == this.fGrid.fExtendGridLinesMode)
          return;
        this.fGrid.fExtendGridLinesMode = value;
        if (!this.fGrid.fRedraw)
          return;
        this.fGrid.Invalidate();
      }
    }

    /// <summary>Gets or sets a value indicating which of the grid lines are visible.</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGGridLinesMode" /> enumeration values. The default is <see cref="F:TenTec.Windows.iGridLib.iGGridLinesMode.Both" />.</value>
    [DefaultValue(iGGridLinesMode.Both)]
    [Description("Determines which of the grid lines are visible.")]
    public iGGridLinesMode Mode
    {
      get
      {
        return this.fGrid.fGridLinesMode;
      }
      set
      {
        if (value == this.fGrid.fGridLinesMode)
          return;
        this.fGrid.fGridLinesMode = value;
        if (!this.fGrid.fRedraw)
          return;
        this.fGrid.Invalidate();
      }
    }

    /// <summary>Gets or sets the style of the horizontal grid lines in the group rows.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGPenStyle" /> object.</value>
    [Description("The style of the horizontal grid lines in the group rows.")]
    public iGPenStyle GroupRows
    {
      get
      {
        return this.fGrid.fGroupRowsGridLinesStyle;
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException();
        if (object.Equals((object) this.fGrid.fGroupRowsGridLinesStyle, (object) value))
          return;
        this.fGrid.fGroupRowsGridLinesStyle = value;
        if (!this.fGrid.fRedraw)
          return;
        this.fGrid.Invalidate();
      }
    }

    /// <summary>Gets or sets the style of the vertical grid line in the last visible column.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGPenStyle" /> object.</value>
    [Description("The style of the vertical grid line in the last visible column.")]
    public iGPenStyle VerticalLastCol
    {
      get
      {
        return this.fGrid.fVLastColGridLineStyle;
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException();
        if (object.Equals((object) this.fGrid.fVLastColGridLineStyle, (object) value))
          return;
        if (value.Width < 0)
          throw new ArgumentOutOfRangeException();
        this.fGrid.fVLastColGridLineStyle = value;
        if (!this.fGrid.fRedraw)
          return;
        this.fGrid.Invalidate();
      }
    }

    /// <summary>Gets or sets the style of the horizontal grid line in the last visible row.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGPenStyle" /> object.</value>
    [Description("The style of the horizontal grid line in the last visible row.")]
    public iGPenStyle HorizontalLastRow
    {
      get
      {
        return this.fGrid.fHLastRowGridLineStyle;
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException();
        if (object.Equals((object) this.fGrid.fHLastRowGridLineStyle, (object) value))
          return;
        if (value.Width < 0)
          throw new ArgumentOutOfRangeException();
        this.fGrid.fHLastRowGridLineStyle = value;
        if (!this.fGrid.fRedraw)
          return;
        this.fGrid.Invalidate();
      }
    }
  }
}
