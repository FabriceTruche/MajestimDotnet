// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGGroupBox
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.ComponentModel;
using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents the group box in an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGGroupBox
  {
    internal static readonly Color cDefaultHintForeColor = Color.Empty;
    internal static readonly Color cDefaultHintBackColor = Color.Empty;
    internal static readonly Color cDefaultBackColor = Color.Empty;
    internal static readonly Color cDefaultColHdrBorderColor = Color.Empty;
    private iGrid fGrid;
    internal const bool cDefaultVisible = false;

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

    internal iGGroupBox(iGrid grid)
    {
      this.fGrid = grid;
    }

    private bool ShouldSerializeHintForeColor()
    {
      return this.fGrid.fGroupBoxHintForeColor != iGGroupBox.cDefaultHintForeColor;
    }

    private bool ShouldSerializeHintBackColor()
    {
      return this.fGrid.fGroupBoxHintBackColor != iGGroupBox.cDefaultHintBackColor;
    }

    private bool ShouldSerializeBackColor()
    {
      return this.fGrid.fGroupBoxBackColor != iGGroupBox.cDefaultBackColor;
    }

    private bool ShouldSerializeColHdrBorderColor()
    {
      return this.fGrid.fGroupBoxColHdrBorderColor != iGGroupBox.cDefaultColHdrBorderColor;
    }

    private void ResetHintForeColor()
    {
      this.HintForeColor = Color.Empty;
    }

    private void ResetHintBackColor()
    {
      this.HintBackColor = Color.Empty;
    }

    private void ResetBackColor()
    {
      this.BackColor = iGGroupBox.cDefaultBackColor;
    }

    private void ResetColHdrBorderColor()
    {
      this.ColHdrBorderColor = iGGroupBox.cDefaultColHdrBorderColor;
    }

    /// <summary>Gets or sets a value indicating whether the group box is visible or not.</summary>
    /// <value>True if the group box is visible; otherwise, False. The default is False.</value>
    [DefaultValue(false)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines whether the group box is visible or not.")]
    public bool Visible
    {
      get
      {
        return this.fGrid.GroupBoxVisible;
      }
      set
      {
        this.fGrid.GroupBoxVisible = value;
      }
    }

    /// <summary>Gets or sets the color of the text displayed in the group box when none of the columns are grouped. If not set, the <see cref="P:TenTec.Windows.iGridLib.iGrid.ForeColorDisabled" /> property is used.</summary>
    /// <value>A <see cref="T:System.Drawing.Color" /> that represents the foreground color of the group box's hint. The default is <see cref="F:System.Drawing.Color.Empty" /> which means that the color is obtained from the <see cref="P:TenTec.Windows.iGridLib.iGrid.ForeColorDisabled" /> property..</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The color of the text displayed in the group box when none of the columns are grouped. If not set, the ForeColorDisabled property is used.")]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGColorEmptyAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    public Color HintForeColor
    {
      get
      {
        return this.fGrid.fGroupBoxHintForeColor;
      }
      set
      {
        this.fGrid.fGroupBoxHintForeColor = value;
        if (!this.Visible)
          return;
        this.fGrid.InvalidateHeaderIfRedraw();
      }
    }

    /// <summary>Gets or sets the background color of the text displayed in the group box when none of the columns are grouped. If not set, the <see cref="P:TenTec.Windows.iGridLib.iGHeader.BackColor" /> property of the header is used.</summary>
    /// <value>A <see cref="T:System.Drawing.Color" /> that represents the background color of the group box's hint. The default is <see cref="F:System.Drawing.Color.Empty" /> which means that the color is obtained from the header's background color.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The background color of the text displayed in the group box when none of the columns are grouped. If not set, the BackColor property of the header is used.")]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGColorEmptyAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    public Color HintBackColor
    {
      get
      {
        return this.fGrid.fGroupBoxHintBackColor;
      }
      set
      {
        this.fGrid.fGroupBoxHintBackColor = value;
        if (!this.Visible)
          return;
        this.fGrid.InvalidateHeaderIfRedraw();
      }
    }

    /// <summary>Gets or sets the color of the group box's background. If not set, the color is calculated from the <see cref="P:TenTec.Windows.iGridLib.iGHeader.BackColor" /> property of the header.</summary>
    /// <value>A <see cref="T:System.Drawing.Color" /> that represents the background color of the group box. The default is <see cref="F:System.Drawing.Color.Empty" /> which means that the color is obtained from the header's background color.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The color of the group box's background. If not set, the color is calculated from the BackColor property of the header.")]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGColorEmptyAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    public Color BackColor
    {
      get
      {
        return this.fGrid.fGroupBoxBackColor;
      }
      set
      {
        this.fGrid.fGroupBoxBackColor = value;
        if (!this.Visible)
          return;
        this.fGrid.InvalidateHeaderIfRedraw();
      }
    }

    /// <summary>Gets or sets the color of the column headers' borders in the group box and of the lines connecting the column headers in the group box. If not set, the color is calculated from the <see cref="P:TenTec.Windows.iGridLib.iGHeader.BackColor" /> property of the header.</summary>
    /// <value>A <see cref="T:System.Drawing.Color" /> that represents the group box's border color. The default is <see cref="F:System.Drawing.Color.Empty" /> which means that the color is obtained from the header's background color.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The color of the column header borders in the group box and of the lines connecting the column headers in the group box. If not set, the color is calculated from the BackColor property of the header.")]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGColorEmptyAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    public Color ColHdrBorderColor
    {
      get
      {
        return this.fGrid.fGroupBoxColHdrBorderColor;
      }
      set
      {
        this.fGrid.fGroupBoxColHdrBorderColor = value;
        if (!this.Visible)
          return;
        this.fGrid.InvalidateHeaderIfRedraw();
      }
    }

    /// <summary>Gets the height of the group box area.</summary>
    /// <value>The height of the group box area.</value>
    [Browsable(false)]
    public int Height
    {
      get
      {
        return this.fGrid.GetGroupBoxHeight();
      }
    }
  }
}
