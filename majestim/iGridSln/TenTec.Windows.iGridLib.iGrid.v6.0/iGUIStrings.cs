// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGUIStrings
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.ComponentModel;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides you with the properties which allow you to set and get the standard user interface strings of iGrid.</summary>
  [Localizable(true)]
  public sealed class iGUIStrings
  {
    internal string fGroupBoxHintText = "Drag a column header here to group by that column";
    internal string fSearchWindowLabelNext = "Next";
    internal string fSearchWindowLabelPrev = "Previous";
    private const string cDefaultGroupBoxHintText = "Drag a column header here to group by that column";
    private const string cDefaultSearchWindowLabelNext = "Next";
    private const string cDefaultSearchWindowLabelPrev = "Previous";
    private readonly iGrid fGrid;

    /// <summary>Returns the <see cref="T:TenTec.Windows.iGridLib.iGrid" /> object this instance belongs to.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGrid" /> object this object belongs to.</value>
    [Browsable(false)]
    public iGrid Grid
    {
      get
      {
        return this.fGrid;
      }
    }

    internal iGUIStrings(iGrid grid)
    {
      if (grid == null)
        throw new ArgumentNullException();
      this.fGrid = grid;
    }

    /// <summary>Gets or sets the text displayed in the group box when none of the columns are grouped.</summary>
    /// <value>A string. The default is "Drag a column header here to group by that column".</value>
    [DefaultValue("Drag a column header here to group by that column")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The text displayed in the group box when none of the columns are grouped.")]
    [Localizable(true)]
    public string GroupBoxHintText
    {
      get
      {
        return this.fGroupBoxHintText;
      }
      set
      {
        this.fGroupBoxHintText = value;
        this.fGrid.OnGroupBoxHintTextChanged();
      }
    }

    /// <summary>Gets or sets the standard text of the next keyboard hint in the search window of the search-as-type functionality.</summary>
    /// <value>A string. The default is "Next".</value>
    [DefaultValue("Next")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The text which labels the next key combination in the search window (which appears while searching as typing).")]
    [Localizable(true)]
    public string SearchWindowLabelNext
    {
      get
      {
        return this.fSearchWindowLabelNext;
      }
      set
      {
        this.fSearchWindowLabelNext = value;
      }
    }

    /// <summary>Gets or sets the standard text of the previous keyboard hint in the search window of the search-as-type functionality.</summary>
    /// <value>A string. The default is "Previous".</value>
    [DefaultValue("Previous")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The text which labels the previous key combination in the search window (which appears while searching as typing).")]
    [Localizable(true)]
    public string SearchWindowLabelPrev
    {
      get
      {
        return this.fSearchWindowLabelPrev;
      }
      set
      {
        this.fSearchWindowLabelPrev = value;
      }
    }
  }
}
