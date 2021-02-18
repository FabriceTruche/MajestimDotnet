// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGScrollBar
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.ComponentModel;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents a scroll bar in an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  [TypeConverter("TenTec.Windows.iGridLib.Design.iGExpandableTypeConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
  public class iGScrollBar
  {
    internal const bool cDefaultScrollBarEnabled = true;
    internal const iGScrollBarVisibility cDefaultVisibility = iGScrollBarVisibility.OnDemand;
    private iGrid fGrid;
    private bool fVertical;

    /// <summary>Returns the <see cref="T:TenTec.Windows.iGridLib.iGrid" /> object this instance belongs to.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGrid" /> object.</value>
    [Browsable(false)]
    public iGrid Grid
    {
      get
      {
        return this.fGrid;
      }
    }

    internal iGScrollBar(iGrid grid, bool vertical)
    {
      this.fGrid = grid;
      this.fVertical = vertical;
    }

    private bool ShouldSerializeSmallChange()
    {
      if (this.fVertical)
        return this.SmallChange != 16;
      return this.SmallChange != 10;
    }

    private bool ShouldSerializeCustomButtons()
    {
      return this.CustomButtons.Count > 0;
    }

    private void ResetSmallChange()
    {
      if (this.fVertical)
        this.SmallChange = 16;
      else
        this.SmallChange = 10;
    }

    private void ResetCustomButtons()
    {
      this.CustomButtons.Clear();
    }

    /// <summary>Gets or sets a value indicating whether the scroll bar is enabled when the cells does not room the client area.</summary>
    /// <value>True if the scroll bar is enabled; otherwise, False. The default is True.</value>
    [DefaultValue(true)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines whether the scroll bar is enabled when the cells does not room the client area.")]
    public bool Enabled
    {
      get
      {
        if (this.fVertical)
          return this.fGrid.fVScrollBar.Enabled;
        return this.fGrid.fHScrollBar.Enabled;
      }
      set
      {
        if (this.fVertical)
        {
          if (value == this.fGrid.fVScrollBar.Enabled)
            return;
          this.fGrid.fVScrollBar.Enabled = value;
        }
        else
        {
          if (value == this.fGrid.fHScrollBar.Enabled)
            return;
          this.fGrid.fHScrollBar.Enabled = value;
        }
      }
    }

    /// <summary>Gets a value to be added to or subtracted from the <see cref="P:TenTec.Windows.iGridLib.iGScrollBar.Value" /> property when the scroll box is moved a large distance.</summary>
    /// <value>A numeric value.</value>
    [Browsable(false)]
    public int LargeChange
    {
      get
      {
        if (this.fVertical)
          return this.fGrid.fVScrollBar.fLargeChange;
        return this.fGrid.fHScrollBar.fLargeChange;
      }
    }

    /// <summary>Gets or sets a value to be added to or subtracted from the Value property when the scroll box is moved a small distance.</summary>
    /// <value>A numeric value.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("A value to be added to or subtracted from the Value property when the scroll box is moved a small distance.")]
    public int SmallChange
    {
      get
      {
        if (this.fVertical)
          return this.fGrid.fVScrollBar.fSmallChange;
        return this.fGrid.fHScrollBar.fSmallChange;
      }
      set
      {
        if (this.fVertical)
          this.fGrid.fVScrollBar.SmallChange = value;
        else
          this.fGrid.fHScrollBar.SmallChange = value;
      }
    }

    /// <summary>Gets or sets a numeric value that represents the current position of the scroll box.</summary>
    /// <value>A numeric value that is within the <see cref="P:TenTec.Windows.iGridLib.iGScrollBar.Minimum" /> and <see cref="P:TenTec.Windows.iGridLib.iGScrollBar.Maximum" /> range.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int Value
    {
      get
      {
        if (this.fVertical)
          return this.fGrid.fVScrollBar.fValue;
        return this.fGrid.fHScrollBar.fValue;
      }
      set
      {
        if (this.fVertical)
          this.fGrid.fVScrollBar.Value = value;
        else
          this.fGrid.fHScrollBar.Value = value;
      }
    }

    /// <summary>Gets the lower limit of values of the scrollable range.</summary>
    /// <value>A numeric value.</value>
    [Browsable(false)]
    public int Minimum
    {
      get
      {
        if (this.fVertical)
          return this.fGrid.fVScrollBar.fMinimum;
        return this.fGrid.fHScrollBar.fMinimum;
      }
    }

    /// <summary>Gets the upper limit of values of the scrollable range.</summary>
    /// <value>A numeric value.</value>
    [Browsable(false)]
    public int Maximum
    {
      get
      {
        if (this.fVertical)
          return this.fGrid.fVScrollBar.fMaxScrollPos;
        return this.fGrid.fHScrollBar.fMaxScrollPos;
      }
    }

    /// <summary>Gets the collection of the additional scroll bar buttons.</summary>
    /// <value>The <see cref="T:TenTec.Windows.iGridLib.iGScrollBarCustomButtonCollection" /> collection that represents the scroll bar custom buttons.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The collection of the additional scroll bar buttons.")]
    public iGScrollBarCustomButtonCollection CustomButtons
    {
      get
      {
        if (this.fVertical)
          return this.fGrid.fVScrollBar.CustomButtons;
        return this.fGrid.fHScrollBar.CustomButtons;
      }
    }

    /// <summary>Gets or sets a value indicating whether the scroll bar is visible always, when necessary or never.</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGScrollBarVisibility" /> enumeration values. The default is <see cref="F:TenTec.Windows.iGridLib.iGScrollBarVisibility.OnDemand" />.</value>
    [DefaultValue(iGScrollBarVisibility.OnDemand)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines whether the scroll bar is visible always, when necessary or never.")]
    public iGScrollBarVisibility Visibility
    {
      get
      {
        if (this.fVertical)
          return this.fGrid.fVScrollBarVisibility;
        return this.fGrid.fHScrollBarVisibility;
      }
      set
      {
        if (value == this.Visibility)
          return;
        int borderSize = 0;
        int headerSize = 0;
        bool flag = false;
        if (this.fVertical && this.fGrid.fAutoResizeCols)
        {
          borderSize = this.fGrid.GetBorderSize();
          headerSize = this.fGrid.GetHeaderAreaHeight();
          flag = this.fGrid.GetVScrollBarVisible(headerSize, borderSize);
        }
        if (this.fVertical)
          this.fGrid.fVScrollBarVisibility = value;
        else
          this.fGrid.fHScrollBarVisibility = value;
        if (this.fVertical && this.fGrid.fAutoResizeCols && flag != this.fGrid.GetVScrollBarVisible(headerSize, borderSize))
          this.fGrid.DoAutoResizeCols(0, 0, false, true, true);
        this.fGrid.RefreshGridAndScrollBarsIfRedraw();
      }
    }

    /// <summary>Gets a value indicating whether the scroll bar can be scrolled.</summary>
    /// <value>True is the scroll bar cannot be scrolled; otherwise, False.</value>
    [Browsable(false)]
    public bool Locked
    {
      get
      {
        if (this.fVertical)
          return this.fGrid.fVScrollBar.Locked;
        return this.fGrid.fHScrollBar.Locked;
      }
    }

    /// <summary>Gets a value indicating whether the scroll bar is visible.</summary>
    /// <value>True if the scroll bar is visible; otherwise, False.</value>
    [Browsable(false)]
    public bool Visible
    {
      get
      {
        bool hScrollVisible;
        bool vScrollVisible;
        this.fGrid.GetScrollBarsVisible(out hScrollVisible, out vScrollVisible);
        if (this.fVertical)
          return vScrollVisible;
        return hScrollVisible;
      }
    }

    /// <summary>Gets the width of the scroll bar.</summary>
    /// <value>The width of the scroll bar.</value>
    [Browsable(false)]
    public int Width
    {
      get
      {
        if (this.fVertical)
          return this.fGrid.fVScrollBar.Width;
        return this.fGrid.fHScrollBar.Width;
      }
    }

    /// <summary>Gets the height of the scroll bar.</summary>
    /// <value>The height of the scroll bar.</value>
    [Browsable(false)]
    public int Height
    {
      get
      {
        if (this.fVertical)
          return this.fGrid.fVScrollBar.Height;
        return this.fGrid.fHScrollBar.Height;
      }
    }
  }
}
