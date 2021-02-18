// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGSearchAsType
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.ComponentModel;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Exposes all the properties related to the search-as-type functionality of iGrid.</summary>
  public class iGSearchAsType : IiGridProvider, IDisposable
  {
    internal iGrid fGrid;
    internal iGSearchAsTypeManager fManager;

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

    /// <summary>Cancels searching as typing and clears the search string.</summary>
    public void Cancel()
    {
      this.Cancel(true);
    }

    /// <summary>Moves the current cell to the next cell which matches the search criteria.</summary>
    /// <returns>True if the current cell was moved (there was a matching cell ahead); otherwise, False.</returns>
    public bool GoNext()
    {
      if (this.fManager == null)
        return false;
      return this.fManager.GoNext();
    }

    /// <summary>Moves the current cell to the previous cell which matches the search criteria.</summary>
    /// <returns>True if the current cell was moved (there was a matching cell before); otherwise, False.</returns>
    public bool GoPrev()
    {
      if (this.fManager == null)
        return false;
      return this.fManager.GoPrev();
    }

    internal iGSearchAsType(iGrid grid)
    {
      if (grid == null)
        throw new ArgumentNullException();
      this.fGrid = grid;
    }

    internal void Cancel(bool manually)
    {
      if (this.fManager == null)
        return;
      this.fManager.Cancel(manually);
    }

    internal void AdjustManager()
    {
      if (this.fManager != null)
        return;
      this.fManager = new iGSearchAsTypeManager(this.fGrid);
    }

    private bool ShouldSerializeSearchCol()
    {
      if (this.fManager == null)
        return false;
      return this.fManager.SearchColIndex != -1;
    }

    private void ResetSearchCol()
    {
      this.AdjustManager();
      this.fManager.SearchColIndex = -1;
    }

    /// <summary>Gets or sets a value indicating how the search-as-type functionality works (whether the rows are filtered or the matching row/cell becomes current).</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGSearchAsTypeMode" /> enumeration values. The default is <see cref="F:TenTec.Windows.iGridLib.iGSearchAsTypeMode.Seek" />.</value>
    [DefaultValue(iGSearchAsTypeMode.None)]
    [Description("Determines the search-as-type behavior.")]
    [Category("Behavior")]
    public iGSearchAsTypeMode Mode
    {
      get
      {
        if (this.fManager == null)
          return iGSearchAsTypeMode.None;
        return this.fManager.Mode;
      }
      set
      {
        this.AdjustManager();
        this.fManager.Mode = value;
      }
    }

    /// <summary>Gets or sets the criteria which iGrid uses to determine which cells match the string being sought.</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGMatchRule" /> enumeration values. The default is <see cref="F:TenTec.Windows.iGridLib.iGMatchRule.StartsWith" />.</value>
    [DefaultValue(iGMatchRule.StartsWith)]
    [Description("Indicates how to determine whether a cell text matches the search string when searching as typing.")]
    [Category("Behavior")]
    public iGMatchRule MatchRule
    {
      get
      {
        if (this.fManager == null)
          return iGMatchRule.StartsWith;
        return this.fManager.MatchRule;
      }
      set
      {
        this.AdjustManager();
        this.fManager.MatchRule = value;
      }
    }

    /// <summary>Gets or sets a value indicating which column should be used to compare the search text to cell values when searching as typing.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGCol" /> object which represents the column to search by.</value>
    [Description("Determines the column to search by when searching as typing.")]
    [Category("Behavior")]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGColListConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public iGCol SearchCol
    {
      get
      {
        int index = this.fManager != null ? this.fManager.SearchColIndex : -1;
        if (index == -1)
          return (iGCol) null;
        return new iGCol(this.fGrid, index);
      }
      set
      {
        this.AdjustManager();
        if (value == null)
        {
          this.fManager.SearchColIndex = -1;
        }
        else
        {
          this.fGrid.CheckColIndex(value.fIndex);
          this.fManager.SearchColIndex = value.fIndex;
        }
      }
    }

    /// <summary>Gets or sets a value specifying whether to start searching from the current row or from the beginning of the grid.</summary>
    /// <value>True if searching should be started from the current row; otherwise, False. The default is False.</value>
    [DefaultValue(false)]
    [Description("Determines whether to start searching from the current row or from the first row when searching as typing.")]
    [Category("Behavior")]
    public bool StartFromCurRow
    {
      get
      {
        if (this.fManager == null)
          return false;
        return this.fManager.StartFromCurRow;
      }
      set
      {
        this.AdjustManager();
        this.fManager.StartFromCurRow = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether to display the keyboard hint (the search-as-type functionality key combinations) in the search window.</summary>
    /// <value>True if the keyboard hint should be displayed; otherwise, False. The default is True.</value>
    [DefaultValue(true)]
    [Description("Determines whether to show keyboard hint (next/previous key combinations) when searching as typing.")]
    [Category("Appearance")]
    public bool DisplayKeyboardHint
    {
      get
      {
        if (this.fManager == null)
          return true;
        return this.fManager.DisplayKeyboardHint;
      }
      set
      {
        this.AdjustManager();
        this.fManager.DisplayKeyboardHint = value;
      }
    }

    /// <summary>Gets or sets the current search text. When this property is modified, iGrid automatically moves the current cell to the matching one and/or filter the rows.</summary>
    /// <value>A string.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public string SearchText
    {
      get
      {
        if (this.fManager == null)
          return string.Empty;
        return this.fManager.SearchText;
      }
      set
      {
        this.AdjustManager();
        this.fManager.SearchText = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether to display the text which is currently being sought in the search window.</summary>
    /// <value>True if the search text should be displayed; otherwise, False. The default is True.</value>
    [DefaultValue(true)]
    [Description("Determines whether to show search text when searching as typing.")]
    [Category("Appearance")]
    public bool DisplaySearchText
    {
      get
      {
        if (this.fManager == null)
          return true;
        return this.fManager.DisplaySearchText;
      }
      set
      {
        this.AdjustManager();
        this.fManager.DisplaySearchText = value;
      }
    }

    /// <summary>Gets a value indicating whether the currently specified search text has matches in the grid.</summary>
    /// <value>True if there are matched the grid; otherwise, False.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public bool HasMatches
    {
      get
      {
        if (this.fManager == null)
          return false;
        return this.fManager.HasMatches;
      }
    }

    /// <summary>Gets or sets a value indicating whether the current row is not changed when in filter mode.</summary>
    /// <value>True if the current row should not be changed; otherwise, False. The default is False.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public bool FilterKeepCurRow
    {
      get
      {
        if (this.fManager == null)
          return false;
        return this.fManager.FilterKeepCurRow;
      }
      set
      {
        this.AdjustManager();
        this.fManager.FilterKeepCurRow = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether to automatically cancel searching as typing when the grid loses the focus, the form the grid is located on is deactivated etc.</summary>
    /// <value>True if searching should be automatically cancelled when needed; otherwise, False. The default is True.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public bool AutoCancel
    {
      get
      {
        if (this.fManager == null)
          return true;
        return this.fManager.AutoCancel;
      }
      set
      {
        this.AdjustManager();
        this.fManager.AutoCancel = value;
      }
    }

    /// <summary>Gets a value indicating whether the searching as typing is currently active.</summary>
    /// <value>True if searching is active; otherwise, False.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public bool IsActive
    {
      get
      {
        if (this.fManager == null)
          return false;
        return this.fManager.IsActive;
      }
    }

    /// <summary>Gets or sets a value indicating whether to continue searching from the beginning of the grid when the end is reached.</summary>
    /// <value>True if searching should be started from the beginning when the end is reached; otherwise, False. The default is False.</value>
    [DefaultValue(false)]
    [Description("Indicates whether searching should be started from the beginning of the grid when no elements after the current row match the search criteria.")]
    [Category("Behavior")]
    public bool LoopSearch
    {
      get
      {
        if (this.fManager == null)
          return false;
        return this.fManager.LoopSearch;
      }
      set
      {
        this.AdjustManager();
        this.fManager.LoopSearch = value;
      }
    }

    iGrid IiGridProvider.Grid
    {
      get
      {
        return this.fGrid;
      }
    }

    /// <summary>Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.</summary>
    ~iGSearchAsType()
    {
      this.Dispose(false);
    }

    /// <summary>Releases all the resources used by the object.</summary>
    public void Dispose()
    {
      this.Dispose(true);
    }

    /// <summary>Releases all the resources used by the object.</summary>
    /// <param name="disposing">The Boolean <b>disposing</b> tells the code whether your code initiated the object's disposal (True) or whether the .NET Garbage Collector did it (as part of the Finalize method).</param>
    protected virtual void Dispose(bool disposing)
    {
      if (!disposing || this.fManager == null)
        return;
      this.fManager.Dispose();
      this.fManager = (iGSearchAsTypeManager) null;
    }
  }
}
