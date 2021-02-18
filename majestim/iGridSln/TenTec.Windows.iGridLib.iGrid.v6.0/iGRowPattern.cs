// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGRowPattern
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.ComponentModel;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents a nameable preset that stores all row properties and can be applied to new or existing rows.</summary>
  [TypeConverter("TenTec.Windows.iGridLib.Design.iGPatternConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
  public class iGRowPattern : ICloneable
  {
    internal iGRowData fRowData;

    internal iGRowPattern(iGRowData rowData)
    {
      this.fRowData = rowData;
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGRowPattern" /> class.</summary>
    public iGRowPattern()
    {
      this.fRowData = new iGRowData(17);
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGRowPattern" /> class with the specified height.</summary>
    /// <param name="height">The height of the row.</param>
    public iGRowPattern(int height)
    {
      this.fRowData = new iGRowData(height);
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGRowPattern" /> class with the specified height and normal cell height.</summary>
    /// <param name="height">The height of the row.</param>
    /// <param name="normalCellHeight">The height of the cells above the row text cell.</param>
    public iGRowPattern(int height, int normalCellHeight)
    {
      this.fRowData = new iGRowData(height, normalCellHeight);
    }

    /// <summary>Gets or sets the height of the row.</summary>
    /// <value>The height of the whole row. The default is 16.</value>
    [DefaultValue(17)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The height of the row. Ignored if DefaultRowHeightAutoSet is True.")]
    public int Height
    {
      get
      {
        return this.fRowData.Height;
      }
      set
      {
        iGrid.CheckRowHeight(value);
        this.fRowData.Height = value;
      }
    }

    /// <summary>Gets or sets the height of the cells above the row text cell.</summary>
    /// <value>The height of the cells above the row text cell. The default is 16.</value>
    [DefaultValue(17)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The height of the cells above the row text cell. Ignored if DefaultRowHeightAutoSet is True.")]
    public int NormalCellHeight
    {
      get
      {
        return this.fRowData.NormalCellHeight;
      }
      set
      {
        this.fRowData.NormalCellHeight = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether the row is visible.</summary>
    /// <value>True if the row is visible; otherwise, False. The default is True.</value>
    [DefaultValue(true)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines whether the row is visible.")]
    public bool Visible
    {
      get
      {
        return this.fRowData.Visible;
      }
      set
      {
        this.fRowData.Visible = value;
      }
    }

    /// <summary>Gets or sets the type of the row.</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGRowType" /> enumeration values. The default is <see cref="F:TenTec.Windows.iGridLib.iGRowType.Normal" />.</value>
    [DefaultValue(iGRowType.Normal)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The type of the row.")]
    public iGRowType Type
    {
      get
      {
        return this.fRowData.Type;
      }
      set
      {
        this.fRowData.Type = value;
      }
    }

    /// <summary>Gets or sets the string key of the row.</summary>
    /// <value>A string that is associated with the row.</value>
    [Browsable(false)]
    [DefaultValue(null)]
    public string Key
    {
      get
      {
        return this.fRowData.Key;
      }
      set
      {
        this.fRowData.Key = value;
      }
    }

    /// <summary>Gets or sets the horizontal indent of the first cell in the row. Helps to create a treelike grid.</summary>
    /// <value>The zero-based hierarchical level of the row. The default is zero.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(0)]
    [Description("The horizontal indent of the first cell in the row. Helps to create a treelike grid.")]
    public int Level
    {
      get
      {
        return this.fRowData.Level;
      }
      set
      {
        iGrid.CheckRowLevel(value);
        this.fRowData.Level = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether the row is expanded or collapsed.</summary>
    /// <value>A Boolean value that indicates whether the row is expanded or collapsed. The default value is True.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(true)]
    [Description("Determines whether the row is expanded or collapsed.")]
    public bool Expanded
    {
      get
      {
        return this.fRowData.Expanded;
      }
      set
      {
        this.fRowData.Expanded = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether the row is visible when one of its parent group rows or tree nodes is collapsed or expanded.</summary>
    /// <value>A Boolean value indicating whether the row is visible when one of its parent group rows or tree nodes is collapsed or expanded. The default is True.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(true)]
    [Description("Determines whether the row is visible when its parent is expanded.")]
    public bool VisibleParentExpanded
    {
      get
      {
        return this.fRowData.VisibleParentExpanded;
      }
      set
      {
        this.fRowData.VisibleParentExpanded = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether the row can change its position while sorting.</summary>
    /// <value>True if the row is sortable; otherwise, False. The default is True.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(true)]
    [Description("Determines whether the row can change its position while sorting.")]
    public bool Sortable
    {
      get
      {
        return this.fRowData.Sortable;
      }
      set
      {
        this.fRowData.Sortable = value;
      }
    }

    /// <summary>Gets or sets the state of the row's tree button.</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGTreeButtonState" /> enumeration values. The default is <see cref="F:TenTec.Windows.iGridLib.iGTreeButtonState.Absent" />.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(iGTreeButtonState.Absent)]
    [Description("The state of the row's tree button.")]
    public iGTreeButtonState TreeButton
    {
      get
      {
        return this.fRowData.TreeButton;
      }
      set
      {
        this.fRowData.TreeButton = value;
      }
    }

    /// <summary>Gets or sets an object that contains data about the row.</summary>
    /// <value>An object that contains data about the row.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public object Tag
    {
      get
      {
        return this.fRowData.Tag;
      }
      set
      {
        this.fRowData.Tag = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether the row can be selected.</summary>
    /// <value>True if the row can be selected; otherwise, False.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(true)]
    [Description("Indicates whether the specified row can be selected.")]
    public bool Selectable
    {
      get
      {
        return this.fRowData.Selectable;
      }
      set
      {
        this.fRowData.Selectable = value;
      }
    }

    /// <summary>Gets or sets a style object determining the appearance and behavior of the row's cells.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGCellStyle" /> object that determines the view and behavior of the cells in the row.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGCellStyleConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Description("A style object determining the appearance and behavior of the row's cells.")]
    public iGCellStyle CellStyle
    {
      get
      {
        return this.fRowData.CellStyle;
      }
      set
      {
        this.fRowData.CellStyle = value;
      }
    }

    internal virtual bool ShouldSerializeCellStyle()
    {
      return this.CellStyle != null && this.CellStyle.Container != null;
    }

    internal virtual void ResetCellStyle()
    {
      this.CellStyle = (iGCellStyle) null;
    }

    /// <summary>Creates an exact copy of this <see cref="T:TenTec.Windows.iGridLib.iGRowPattern" /> object.</summary>
    /// <returns>The exact copy of this object.</returns>
    public iGRowPattern Clone()
    {
      return new iGRowPattern(this.fRowData);
    }

    object ICloneable.Clone()
    {
      return (object) this.Clone();
    }
  }
}
