// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGDefaultAutoGroupRow
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.ComponentModel;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents the default data for the automatically created group rows in an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public sealed class iGDefaultAutoGroupRow
  {
    internal const int cDefaultHeight = 17;
    internal const bool cDefaultExpanded = true;
    internal const iGTreeButtonState cDefaultTreeButton = iGTreeButtonState.Visible;
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

    internal iGDefaultAutoGroupRow(iGrid grid)
    {
      this.fGrid = grid;
    }

    /// <summary>Gets or sets the default height of the automatically created group rows.</summary>
    /// <value>The height that will have the automatically created group rows. The default is 16.</value>
    [DefaultValue(17)]
    [Description("The default height of the automatically created group rows. Ignored if DefaultRowHeightAutoSet is True.")]
    public int Height
    {
      get
      {
        return this.fGrid.DefaultAutoGroupRowHeight;
      }
      set
      {
        this.fGrid.DefaultAutoGroupRowHeight = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether the automatically created group rows are expanded by default.</summary>
    /// <value>True if expanded; otherwise, False. The default is True.</value>
    [DefaultValue(true)]
    [Description("Determines whether the automatically created group rows are expanded by default.")]
    public bool Expanded
    {
      get
      {
        return this.fGrid.DefaultAutoGroupRowExpanded;
      }
      set
      {
        this.fGrid.DefaultAutoGroupRowExpanded = value;
      }
    }

    /// <summary>Gets or sets the default state of the tree button of the automatically created group rows.</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGTreeButtonState" /> enumeration values. The default is <see cref="F:TenTec.Windows.iGridLib.iGTreeButtonState.Visible" />.</value>
    [DefaultValue(iGTreeButtonState.Visible)]
    [Description("The default state of the tree button of the automatically created group rows.")]
    public iGTreeButtonState TreeButton
    {
      get
      {
        return this.fGrid.DefaultAutoGroupRowTreeButton;
      }
      set
      {
        this.fGrid.DefaultAutoGroupRowTreeButton = value;
      }
    }
  }
}
