// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGColDesign
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGColDesign : IiGImageListProvider
  {
    private ArrayList fCollection;
    internal iGColPattern fPattern;
    internal iGrid Grid;
    internal int fColIndex;
    internal bool fIsTreeCol;
    internal bool fIsSearchCol;

    public iGColDesign(iGrid grid, ArrayList collection)
    {
      this.fPattern = grid.DefaultCol.Clone();
      this.Grid = grid;
      this.fCollection = collection;
      if (this.Grid.DefaultCol.CellStyle != null)
        this.fPattern.CellStyle=(this.Grid.DefaultCol.CellStyle.Clone());
      else
        this.fPattern.CellStyle=(new iGCellStyle(true));
      if (this.Grid.DefaultCol.ColHdrStyle != null)
        this.fPattern.ColHdrStyle=(this.Grid.DefaultCol.ColHdrStyle.Clone());
      else
        this.fPattern.ColHdrStyle=(new iGColHdrStyle(true));
      if (((Component) grid).Site != null)
      {
        IDesignerHost service = ((Component) grid).Site.GetService(typeof (IDesignerHost)) as IDesignerHost;
        if (service != null)
        {
          this.fPattern.CellStyle=((iGCellStyle) iGDesigner.CreateStyleDesignTime(service, ((Control) this.Grid).Name + "Col" + collection.Count.ToString() + nameof (CellStyle), typeof (iGCellStyle), (iGStyleBase) this.fPattern.CellStyle));
          this.fPattern.ColHdrStyle=((iGColHdrStyle) iGDesigner.CreateStyleDesignTime(service, ((Control) this.Grid).Name + "Col" + collection.Count.ToString() + nameof (ColHdrStyle), typeof (iGColHdrStyle), (iGStyleBase) this.fPattern.ColHdrStyle));
        }
      }
      this.fColIndex = -1;
    }

    public iGColDesign(iGrid grid, iGColPattern colPattern, int colIndex, bool isTreeCol, bool isSearchCol, ArrayList collection)
    {
      this.fPattern = colPattern;
      this.Grid = grid;
      this.fColIndex = colIndex;
      this.fCollection = collection;
      this.fIsTreeCol = isTreeCol;
      this.fIsSearchCol = isSearchCol;
    }

    private bool ShouldSerializeWidth()
    {
      return this.Width != this.Grid.DefaultCol.Width;
    }

    private bool ShouldSerializeVisible()
    {
      return this.Visible != this.Grid.DefaultCol.Visible;
    }

    private bool ShouldSerializeIncludeInSelect()
    {
      return this.IncludeInSelect != this.Grid.DefaultCol.IncludeInSelect;
    }

    private bool ShouldSerializeMinWidth()
    {
      return this.MinWidth != this.Grid.DefaultCol.MinWidth;
    }

    private bool ShouldSerializeMaxWidth()
    {
      return this.MaxWidth != this.Grid.DefaultCol.MaxWidth;
    }

    private bool ShouldSerializeAllowSizing()
    {
      return this.AllowSizing != this.Grid.DefaultCol.AllowSizing;
    }

    private bool ShouldSerializeAllowMoving()
    {
      return this.AllowMoving != this.Grid.DefaultCol.AllowMoving;
    }

    private bool ShouldSerializeAllowGrouping()
    {
      return this.AllowGrouping != this.Grid.DefaultCol.AllowGrouping;
    }

    private bool ShouldSerializeSortType()
    {
      return this.SortType != this.Grid.DefaultCol.SortType;
    }

    private bool ShouldSerializeSortOrder()
    {
      return this.SortOrder != this.Grid.DefaultCol.SortOrder;
    }

    private bool ShouldSerializeCustomGrouping()
    {
      return this.CustomGrouping != this.Grid.DefaultCol.CustomGrouping;
    }

    private bool ShouldSerializeCellStyle()
    {
      return iGInternalInfrastructure.iGSerializeManager.ShouldSerialize((object) this.CellStyle);
    }

    private bool ShouldSerializeText()
    {
      return this.Text as string != this.Grid.DefaultCol.Text as string;
    }

    private bool ShouldSerializeImageIndex()
    {
      return this.ImageIndex != this.Grid.DefaultCol.ImageIndex;
    }

    private bool ShouldSerializeColHdrStyle()
    {
      return iGInternalInfrastructure.iGSerializeManager.ShouldSerialize((object) this.ColHdrStyle);
    }

    private bool ShouldSerializeDefaultCellValue()
    {
      return this.DefaultCellValue as string != this.Grid.DefaultCol.DefaultCellValue as string;
    }

    private bool ShouldSerializeDefaultCellImageIndex()
    {
      return this.DefaultCellImageIndex != this.Grid.DefaultCol.DefaultCellImageIndex;
    }

    private bool ShouldSerializeShowWhenGrouped()
    {
      return this.ShowWhenGrouped != this.Grid.DefaultCol.ShowWhenGrouped;
    }

    public ImageList GetImageList(string propertyName)
    {
      if (propertyName == "DefaultCellImageIndex")
      {
        if (((iGStyleBase) this.CellStyle).ImageList != null)
          return ((iGStyleBase) this.CellStyle).ImageList;
        return this.Grid.ImageList;
      }
      if (((iGStyleBase) this.ColHdrStyle).ImageList != null)
        return ((iGStyleBase) this.ColHdrStyle).ImageList;
      return this.Grid.Header.ImageList;
    }

    public override string ToString()
    {
      string str = string.Empty;
      if (this.fPattern.Text != null)
        str = str + this.fPattern.Text.ToString() + " ";
      if (this.fPattern.Key != null)
        str = str + "[" + this.fPattern.Key.ToString() + "] ";
      if (str.Length == 0)
        return "Column";
      return str;
    }

    private void CheckKeyUnique(string value)
    {
      if (value == null)
        return;
      foreach (iGColDesign f in this.fCollection)
      {
        if (f != this && f.Key == value)
          throw new ArgumentException("Key already exists");
      }
    }

    [Description("The width of the column.")]
    [Category("Layout")]
    public int Width
    {
      get
      {
        return this.fPattern.Width;
      }
      set
      {
        this.fPattern.Width=(value);
      }
    }

    [Description("Determines whether the column is visible.")]
    [Category("Behavior")]
    public bool Visible
    {
      get
      {
        return this.fPattern.Visible;
      }
      set
      {
        this.fPattern.Visible=(value);
      }
    }

    [Description("Determines whether the cells of the column can be selected.")]
    [Category("Behavior")]
    public bool IncludeInSelect
    {
      get
      {
        return this.fPattern.IncludeInSelect;
      }
      set
      {
        this.fPattern.IncludeInSelect=(value);
      }
    }

    [Description("The minimal width of the column.")]
    [Category("Layout")]
    public int MinWidth
    {
      get
      {
        return this.fPattern.MinWidth;
      }
      set
      {
        this.fPattern.MinWidth=(value);
      }
    }

    [Description("The maximal width of the column.")]
    [Category("Layout")]
    public int MaxWidth
    {
      get
      {
        return this.fPattern.MaxWidth;
      }
      set
      {
        this.fPattern.MaxWidth=(value);
      }
    }

    [Description("Determines whether the column can be resized thru visual interface.")]
    [Category("Behavior")]
    public bool AllowSizing
    {
      get
      {
        return this.fPattern.AllowSizing;
      }
      set
      {
        this.fPattern.AllowSizing=(value);
      }
    }

    [Description("Determines whether the order of the column can be changed.")]
    [Category("Behavior")]
    public bool AllowMoving
    {
      get
      {
        return this.fPattern.AllowMoving;
      }
      set
      {
        this.fPattern.AllowMoving=(value);
      }
    }

    [Description("Determines whether the rows can be grouped by this column.")]
    [Category("Behavior")]
    public bool AllowGrouping
    {
      get
      {
        return this.fPattern.AllowGrouping;
      }
      set
      {
        this.fPattern.AllowGrouping=(value);
      }
    }

    [Description("The default sort type of the column.")]
    [Category("Behavior")]
    public iGSortType SortType
    {
      get
      {
        return this.fPattern.SortType;
      }
      set
      {
        this.fPattern.SortType=(value);
      }
    }

    [Description("The default sort order of the column.")]
    [Category("Behavior")]
    public iGSortOrder SortOrder
    {
      get
      {
        return this.fPattern.SortOrder;
      }
      set
      {
        this.fPattern.SortOrder=(value);
      }
    }

    [Description("Determines whether to apply custom grouping to the column.")]
    [Category("Behavior")]
    public bool CustomGrouping
    {
      get
      {
        return this.fPattern.CustomGrouping;
      }
      set
      {
        this.fPattern.CustomGrouping=(value);
      }
    }

    [TypeConverter(typeof (iGStringConverter))]
    [Description("The value that will have the new cells of the column.")]
    [Category("Data")]
    public object DefaultCellValue
    {
      get
      {
        return this.fPattern.DefaultCellValue;
      }
      set
      {
        this.fPattern.DefaultCellValue=(value);
      }
    }

    [TypeConverter(typeof (iGImageIndexConverter))]
    [Editor("TenTec.Windows.iGridLib.Design.iGImageIndexEditor, TenTec.Windows.iGridLib.Design", typeof (UITypeEditor))]
    [Description("The image index that will have the new cells of the column.")]
    [Category("Data")]
    public int DefaultCellImageIndex
    {
      get
      {
        return this.fPattern.DefaultCellImageIndex;
      }
      set
      {
        this.fPattern.DefaultCellImageIndex=(value);
      }
    }

    [TypeConverter(typeof (iGStringConverter))]
    [Description("The text displayed in the column's header.")]
    [Category("Appearance")]
    public object Text
    {
      get
      {
        return this.fPattern.Text;
      }
      set
      {
        this.fPattern.Text=(value);
      }
    }

    [TypeConverter(typeof (iGImageIndexConverter))]
    [Editor("TenTec.Windows.iGridLib.Design.iGImageIndexEditor, TenTec.Windows.iGridLib.Design", typeof (UITypeEditor))]
    [Description("The index of the image displayed in the column's header.")]
    [Category("Appearance")]
    public int ImageIndex
    {
      get
      {
        return this.fPattern.ImageIndex;
      }
      set
      {
        this.fPattern.ImageIndex=(value);
      }
    }

    [TypeConverter(typeof (iGColColHdrStyleConverter))]
    [Description("A style object determining the appearance and behavior of the column's header.")]
    [RefreshProperties(RefreshProperties.All)]
    [Category("Appearance and Behavior")]
    public iGColHdrStyle ColHdrStyle
    {
      get
      {
        return this.fPattern.ColHdrStyle;
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException();
        if (value is iGStyleConverterBase.iGColHdrStyleNew)
          value = iGDesigner.CreateStyleDesignTime(((Component) this.Grid).Site == null ? (IDesignerHost) null : ((Component) this.Grid).Site.GetService(typeof (IDesignerHost)) as IDesignerHost, (string) null, typeof (iGColHdrStyleDesign), (iGStyleBase) null) as iGColHdrStyle;
        this.fPattern.ColHdrStyle=(value);
      }
    }

    [TypeConverter(typeof (iGColCellStyleConverter))]
    [Description("A style object determining the appearance and behavior of the column's cells.")]
    [RefreshProperties(RefreshProperties.All)]
    [Category("Appearance and Behavior")]
    public iGCellStyle CellStyle
    {
      get
      {
        return this.fPattern.CellStyle;
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException();
        if (value is iGStyleConverterBase.iGCellStyleNew)
          value = iGDesigner.CreateStyleDesignTime(((Component) this.Grid).Site == null ? (IDesignerHost) null : ((Component) this.Grid).Site.GetService(typeof (IDesignerHost)) as IDesignerHost, (string) null, typeof (iGCellStyleDesign), (iGStyleBase) null) as iGCellStyle;
        this.fPattern.CellStyle=(value);
      }
    }

    [TypeConverter(typeof (iGStringConverter))]
    [DefaultValue(null)]
    [Description("The string key of the column.")]
    [Category("Behavior")]
    public string Key
    {
      get
      {
        return this.fPattern.Key;
      }
      set
      {
        this.CheckKeyUnique(value);
        this.fPattern.Key=(value);
      }
    }

    [Description("Determines whether to show the column when it is grouped.")]
    [Category("Behavior")]
    public bool ShowWhenGrouped
    {
      get
      {
        return this.fPattern.ShowWhenGrouped;
      }
      set
      {
        this.fPattern.ShowWhenGrouped=(value);
      }
    }
  }
}
