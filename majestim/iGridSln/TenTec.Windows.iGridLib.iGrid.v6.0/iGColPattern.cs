// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGColPattern
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents a nameable preset that stores all column properties and can be applied to new or existing columns.</summary>
  [TypeConverter("TenTec.Windows.iGridLib.Design.iGPatternConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
  public class iGColPattern : ICloneable, IiGImageListProvider
  {
    internal iGrid fGrid;
    internal iGColData fColData;
    internal iGCellData fCellData;
    internal iGColHdrData fColHdrData;

    internal virtual bool ShouldSerializeCellStyle()
    {
      if (this.CellStyle != null)
        return this.CellStyle.Container != null;
      return false;
    }

    internal virtual bool ShouldSerializeColHdrStyle()
    {
      if (this.ColHdrStyle != null)
        return this.ColHdrStyle.Container != null;
      return false;
    }

    internal virtual void ResetCellStyle()
    {
    }

    internal virtual void ResetColHdrStyle()
    {
    }

    ImageList IiGImageListProvider.GetImageList(string propertyName)
    {
      if (this.fGrid == null)
        return (ImageList) null;
      if (propertyName == "DefaultCellImageIndex")
        return this.fGrid.ImageList;
      return this.fGrid.Header.ImageList;
    }

    internal iGColPattern(iGrid grid)
      : this()
    {
      this.fGrid = grid;
    }

    internal iGColPattern(iGCellStyle cellStyle, iGColHdrStyle colHdrStyle)
    {
      this.fColData = new iGColData(64, true, true, -1, -1, true, true, true, iGSortType.ByValue, iGSortOrder.Ascending, false, cellStyle, colHdrStyle, (object) null, (string) null, false);
      this.fCellData = new iGCellData((object) null);
      this.fColHdrData = new iGColHdrData((object) null);
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGColPattern" /> class.</summary>
    public iGColPattern()
      : this(new iGCellStyle(true), new iGColHdrStyle(true))
    {
    }

    internal iGColPattern(iGColData colData, iGColHdrData colHdr, iGCellData defaultCell)
    {
      this.fColData = colData;
      this.fCellData = defaultCell;
      this.fCellData.Style = (iGCellStyle) null;
      this.fColHdrData = colHdr;
      this.fColHdrData.Style = (iGColHdrStyle) null;
    }

    internal iGColPattern CloneWithoutStyles()
    {
      return new iGColPattern(this.fColData, this.fColHdrData, this.fCellData)
      {
        fColData = {
          CellStyle = (iGCellStyle) null,
          ColHdrStyle = (iGColHdrStyle) null
        }
      };
    }

    /// <summary>Creates an exact copy of this <see cref="T:TenTec.Windows.iGridLib.iGColPattern" /> object.</summary>
    /// <returns>If a cell style is attached to the pattern (the <see cref="P:TenTec.Windows.iGridLib.iGCellPattern.Style" /> property), it is not duplicated, and the returned copy will reference the same style object.</returns>
    public iGColPattern Clone()
    {
      return new iGColPattern(this.fColData, this.fColHdrData, this.fCellData);
    }

    internal iGColHdrData ColHdr
    {
      get
      {
        return this.fColHdrData;
      }
    }

    internal iGColData ColData
    {
      get
      {
        return this.fColData;
      }
    }

    internal iGCellData DefaultCell
    {
      get
      {
        return this.fCellData;
      }
    }

    /// <summary>Gets or sets the width of the column.</summary>
    /// <value>A value that determines the width of the column.</value>
    [DefaultValue(64)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The width of the column.")]
    public int Width
    {
      get
      {
        return this.fColData.Width;
      }
      set
      {
        iGrid.AdjustColWidthAfterMinMaxWidthChange(ref value, this.fColData.MinWidth, this.fColData.MaxWidth);
        this.fColData.Width = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether the column is visible.</summary>
    /// <value>True if the column is visible; otherwise, False.</value>
    [DefaultValue(true)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines whether the column is visible.")]
    public bool Visible
    {
      get
      {
        return this.fColData.Visible;
      }
      set
      {
        this.fColData.Visible = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether the cells of the column can be selected.</summary>
    /// <value>True if the column's cells can be selected; otherwise, False.</value>
    [DefaultValue(true)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines whether the cells of the column can be selected.")]
    public bool IncludeInSelect
    {
      get
      {
        return this.fColData.IncludeInSelect;
      }
      set
      {
        this.fColData.IncludeInSelect = value;
      }
    }

    /// <summary>Gets or sets the minimal width of the column.</summary>
    /// <value>A value that indicates the minimal width of the column. The default is -1 that means that the minimal width is not limited.</value>
    [DefaultValue(-1)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The minimal width of the column.")]
    public int MinWidth
    {
      get
      {
        return this.fColData.MinWidth;
      }
      set
      {
        iGrid.CheckColWidthMinMaxValues(value, this.fColData.MaxWidth);
        int width = this.fColData.Width;
        iGrid.AdjustColWidthAfterMinMaxWidthChange(ref width, value, this.fColData.MaxWidth);
        this.fColData.MinWidth = value;
        this.fColData.Width = width;
      }
    }

    /// <summary>Gets or sets the maximal width of the column.</summary>
    /// <value>A value that indicates the maximal width of the column. The default is -1 that means that the maximal width is not limited.</value>
    [DefaultValue(-1)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The maximal width of the column.")]
    public int MaxWidth
    {
      get
      {
        return this.fColData.MaxWidth;
      }
      set
      {
        iGrid.CheckColWidthMinMaxValues(this.fColData.MinWidth, value);
        int width = this.fColData.Width;
        iGrid.AdjustColWidthAfterMinMaxWidthChange(ref width, this.fColData.MinWidth, value);
        this.fColData.MaxWidth = value;
        this.fColData.Width = width;
      }
    }

    /// <summary>Gets or sets a value indicating whether the column can be resized through visual interface.</summary>
    /// <value>True if the column can be resized; otherwise, False.</value>
    [DefaultValue(true)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines whether the column can be resized thru visual interface.")]
    public bool AllowSizing
    {
      get
      {
        return this.fColData.AllowSizing;
      }
      set
      {
        this.fColData.AllowSizing = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether the display position of the column can be changed.</summary>
    /// <value>True if the column can be moved; otherwise, False.</value>
    [DefaultValue(true)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines whether the order of the column can be changed.")]
    public bool AllowMoving
    {
      get
      {
        return this.fColData.AllowMoving;
      }
      set
      {
        this.fColData.AllowMoving = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether the rows of the grid can be grouped by this column.</summary>
    /// <value>True if the column can be grouped; otherwise, False.</value>
    [DefaultValue(true)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines whether the rows can be grouped by this column.")]
    public bool AllowGrouping
    {
      get
      {
        return this.fColData.AllowGrouping;
      }
      set
      {
        this.fColData.AllowGrouping = value;
      }
    }

    /// <summary>Gets or sets the default sort type of the column.</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGSortType" /> values. If <see cref="F:TenTec.Windows.iGridLib.iGSortType.None" /> is specified, the column cannot be sorted and grouped through visual interface.</value>
    [DefaultValue(iGSortType.ByValue)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The default sort type of the column.")]
    public iGSortType SortType
    {
      get
      {
        return this.fColData.SortType;
      }
      set
      {
        this.fColData.SortType = value;
      }
    }

    /// <summary>Gets or sets the default sort order of the column.</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGSortOrder" /> values. If <see cref="F:TenTec.Windows.iGridLib.iGSortOrder.None" /> is specified, the column cannot be sorted and grouped through visual interface.</value>
    [DefaultValue(iGSortOrder.Ascending)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The default sort order of the column.")]
    public iGSortOrder SortOrder
    {
      get
      {
        return this.fColData.SortOrder;
      }
      set
      {
        this.fColData.SortOrder = value;
      }
    }

    /// <summary>Gets or sets a value determining whether to apply custom grouping to the column.</summary>
    /// <value>True if the column should be grouped using a custom criterion; otherwise, False.</value>
    [DefaultValue(false)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines whether to apply custom grouping to the column.")]
    public bool CustomGrouping
    {
      get
      {
        return this.fColData.CustomGrouping;
      }
      set
      {
        this.fColData.CustomGrouping = value;
      }
    }

    /// <summary>Gets or sets an object that contains data about the column.</summary>
    /// <value>An object that contains data about the column.</value>
    [DefaultValue(null)]
    [Browsable(false)]
    public object Tag
    {
      get
      {
        return this.fColData.Tag;
      }
      set
      {
        this.fColData.Tag = value;
      }
    }

    /// <summary>Gets or sets the text displayed in the column's header.</summary>
    /// <value>An instance of a class. The default value is null (Nothing in VB).</value>
    [DefaultValue(null)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGStringConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The text displayed in the column's header.")]
    public object Text
    {
      get
      {
        return this.fColHdrData.Value;
      }
      set
      {
        this.fColHdrData.Value = value;
      }
    }

    /// <summary>Gets or sets the string key of the column.</summary>
    /// <value>The string that is the key of the column or null (Nothing in VB) if the column does not have a key.</value>
    [Browsable(false)]
    [DefaultValue(null)]
    public string Key
    {
      get
      {
        return this.fColData.Key;
      }
      set
      {
        this.fColData.Key = value;
      }
    }

    /// <summary>Gets or sets the index of the image displayed in the column's header.</summary>
    /// <value>A zero-based index which represents the image position in an <see cref="T:System.Windows.Forms.ImageList" />. The default is -1 which means that the column's header has no image.</value>
    [DefaultValue(-1)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGImageIndexConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Editor("TenTec.Windows.iGridLib.Design.iGImageIndexEditor, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0", typeof (UITypeEditor))]
    [Description("The index of the image displayed in the column's header.")]
    public int ImageIndex
    {
      get
      {
        return this.fColHdrData.ImageIndex;
      }
      set
      {
        this.fColHdrData.ImageIndex = value;
      }
    }

    /// <summary>Gets or sets a style object determining appearance and behavior of the column's header.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGColHdrStyle" /> object that determines view and behavior of the column's headers.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGColColHdrStyleConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Description("A style object determining the appearance and behavior of the column's header.")]
    public iGColHdrStyle ColHdrStyle
    {
      get
      {
        return this.fColData.ColHdrStyle;
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException();
        this.fColData.ColHdrStyle = value;
      }
    }

    /// <summary>Gets or sets the value that will have the new cells of the column.</summary>
    /// <value>The object that will be assigned to the new cells' value.</value>
    [DefaultValue(null)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGStringConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The value that will have the new cells of the column.")]
    public object DefaultCellValue
    {
      get
      {
        return this.fCellData.Value;
      }
      set
      {
        this.fCellData.Value = value;
      }
    }

    /// <summary>Gets or sets the value that will be set to the <see cref="P:TenTec.Windows.iGridLib.iGCell.AuxValue" /> property of the new cells of the column.</summary>
    /// <value>The object that will be assigned to the <see cref="P:TenTec.Windows.iGridLib.iGCell.AuxValue" /> property of the new cells.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public object DefaultCellAuxValue
    {
      get
      {
        return this.fCellData.AuxValue;
      }
      set
      {
        this.fCellData.AuxValue = value;
      }
    }

    /// <summary>Gets or sets the image index that will have the new cells of the column.</summary>
    /// <value>A zero-based index which represents the image position in an <see cref="T:System.Windows.Forms.ImageList" />. The default is -1 which means that the cells has no image.</value>
    [DefaultValue(-1)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGImageIndexConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Editor("TenTec.Windows.iGridLib.Design.iGImageIndexEditor, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0", typeof (UITypeEditor))]
    [Description("The image index that will have the new cells of the column.")]
    public int DefaultCellImageIndex
    {
      get
      {
        return this.fCellData.ImageIndex;
      }
      set
      {
        this.fCellData.ImageIndex = value;
      }
    }

    /// <summary>Gets or sets a style object determining appearance and behavior of the column's cells.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGCellStyle" /> object that determines view and behavior of the cells in the column.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGColCellStyleConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Description("A style object determining the appearance and behavior of the column's cells.")]
    public iGCellStyle CellStyle
    {
      get
      {
        return this.fColData.CellStyle;
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException();
        this.fColData.CellStyle = value;
      }
    }

    /// <summary>Gets or sets a boolean value that indicates whether the column will be visible when iGrid is grouped by this column.</summary>
    /// <value>A boolean value that indicates whether the column will be visible when iGrid is grouped by this column. The default value is False.</value>
    [DefaultValue(false)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines whether to show the column when it is grouped.")]
    public bool ShowWhenGrouped
    {
      get
      {
        return this.fColData.ShowWhenGrouped;
      }
      set
      {
        this.fColData.ShowWhenGrouped = value;
      }
    }

    object ICloneable.Clone()
    {
      return (object) this.Clone();
    }
  }
}
