// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGColHdr
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents a column header (header cell) of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public sealed class iGColHdr : IiGImageListProvider
  {
    private int fColIndex;
    private int fRowIndex;
    private iGrid fGrid;

    /// <summary>Returns the <see cref="T:TenTec.Windows.iGridLib.iGrid" /> object this instance belongs to.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGrid" /> object this instance belongs to.</value>
    [Browsable(false)]
    public iGrid Grid
    {
      get
      {
        return this.fGrid;
      }
    }

    private bool ShouldSerializeValue()
    {
      if (this.Value != null)
        return this.Value as string != string.Empty;
      return false;
    }

    internal iGColHdr(iGrid grid, int rowIndex, int colIndex)
    {
      grid.CheckColHdrIndices(rowIndex, colIndex);
      this.fGrid = grid;
      this.fRowIndex = rowIndex;
      this.fColIndex = colIndex;
    }

    private iGColHdrStyle AdjustStyle()
    {
      iGColHdrStyle iGcolHdrStyle = this.fGrid.GetColHdrData(this.fRowIndex, this.fColIndex).Style;
      if (iGcolHdrStyle == null)
      {
        iGcolHdrStyle = new iGColHdrStyle();
        this.fGrid.SetColHdrStyle(this.fRowIndex, this.fColIndex, iGcolHdrStyle);
      }
      else if (this.fGrid.fRedraw)
        this.fGrid.Invalidate();
      return iGcolHdrStyle;
    }

    /// <summary>Sorts the rows as if the user clicked over the column header and the specified modifier keys were pressed.</summary>
    /// <param name="keyModifiers">The modifier keys that are pressed.</param>
    /// <param name="sortOrder">The <see cref="F:TenTec.Windows.iGridLib.iGSortOrder.None" /> value to emulate clicking the header cell, or the new sort order of column(s) entitled by this header.</param>
    public void DoDefaultSort(Keys keyModifiers, iGSortOrder sortOrder)
    {
      this.fGrid.DoDefaultSortInternal(this.fGrid.GetColOrder(this.fColIndex), this.SpanCols, keyModifiers, sortOrder, true);
    }

    /// <summary>Retrieves the string representation of the column header.</summary>
    /// <returns>A string that represents the column header.</returns>
    public override string ToString()
    {
      return string.Format("iGColHdr(RowIndex = {0}; ColIndex = {1})", (object) this.fRowIndex, (object) (this.fColIndex - 1));
    }

    ImageList IiGImageListProvider.GetImageList(string propertyName)
    {
      return this.fGrid.GetUniCellImageList(iGGridSection.Header, (iGStyleBase) this.Style, (iGStyleBase) null, (iGStyleBase) this.Col.ColHdrStyle);
    }

    private bool ShouldSerializeBackColor()
    {
      return this.BackColor != iGStyleBase.ConstDefaultBackColor;
    }

    private bool ShouldSerializeForeColor()
    {
      return this.ForeColor != iGStyleBase.ConstDefaultForeColor;
    }

    private bool ShouldSerializeContentIndent()
    {
      return iGStyleBase.ShouldSerializeIndent(this.ContentIndent, iGStyleBase.ConstDefaultIndent);
    }

    /// <summary>Gets or sets the control to show in the drop-down form when editing the column header.</summary>
    /// <value>An instance of class that implements the <see cref="T:TenTec.Windows.iGridLib.IiGDropDownControl" /> interface.</value>
    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(null)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGReferenceNullAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Description("Determines the control to show in the drop-down form when clicking the column header's combo button.")]
    [Category("Behavior")]
    public IiGDropDownControl DropDownControl
    {
      get
      {
        iGColHdrStyle style = this.fGrid.GetColHdrData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return (IiGDropDownControl) null;
        return style.DropDownControl;
      }
      set
      {
        this.AdjustStyle().DropDownControl = value;
      }
    }

    /// <summary>Gets or sets an auxiliary value.</summary>
    /// <value>An object.</value>
    [Browsable(false)]
    [DefaultValue(null)]
    public object AuxValue
    {
      get
      {
        return this.fGrid.GetColHdrData(this.fRowIndex, this.fColIndex).AuxValue;
      }
      set
      {
        this.fGrid.SetColHdrAuxValue(this.fRowIndex, this.fColIndex, value);
      }
    }

    /// <summary>Gets or sets an object storing all the column header's data.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGColHdrPattern" /> object that stores a copy of the column header's properties.</value>
    [Browsable(false)]
    public iGColHdrPattern Pattern
    {
      get
      {
        iGColHdrData colHdrData = this.fGrid.GetColHdrData(this.fRowIndex, this.fColIndex);
        colHdrData.SpanCols = this.fGrid.Span__PropertySpanColsGet(iGGridSection.Header, this.fRowIndex, this.fColIndex);
        colHdrData.SpanRows = this.fGrid.Span__PropertySpanRowsGet(iGGridSection.Header, this.fRowIndex, this.fColIndex);
        return new iGColHdrPattern(colHdrData);
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException();
        this.fGrid.SetColHdrData(this.fRowIndex, this.fColIndex, value.fData);
      }
    }

    /// <summary>Gets or sets the number of columns the column header should span.</summary>
    /// <value>The number of columns the column header should span. The default is 1.</value>
    [DefaultValue(1)]
    [Description("Gets or sets the number of columns to span.")]
    [Category("Appearance")]
    public int SpanCols
    {
      get
      {
        return this.fGrid.Span__PropertySpanColsGet(iGGridSection.Header, this.fRowIndex, this.fColIndex);
      }
      set
      {
        this.fGrid.Span__PropertySpanColsSet(iGGridSection.Header, this.fRowIndex, this.fColIndex, value);
      }
    }

    /// <summary>Gets or sets the number of rows the column header should span.</summary>
    /// <value>The number of rows the column header should span. The default is 1.</value>
    [DefaultValue(1)]
    [Description("Gets or sets the number of rows to span.")]
    [Category("Appearance")]
    public int SpanRows
    {
      get
      {
        return this.fGrid.Span__PropertySpanRowsGet(iGGridSection.Header, this.fRowIndex, this.fColIndex);
      }
      set
      {
        this.fGrid.Span__PropertySpanRowsSet(iGGridSection.Header, this.fRowIndex, this.fColIndex, value);
      }
    }

    /// <summary>Returns the root cell (the bottom left cell) of the merged header cell that contains the column header.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGColHdr" /> object that represents the root cell of the merged cell that covers the specified column header.</value>
    [Description("The root cell of the merged header cell.")]
    [Category("Appearance")]
    [Browsable(false)]
    public iGColHdr SpanRoot
    {
      get
      {
        return new iGColHdr(this.fGrid, this.fRowIndex - (this.fGrid.Span__GetSpanRowsNear(iGGridSection.Header, this.fRowIndex, this.fColIndex) - 1), this.fColIndex - (this.fGrid.Span__GetSpanColsNear(iGGridSection.Header, this.fRowIndex, this.fColIndex) - 1));
      }
    }

    /// <summary>Gets or sets the value of the column header used to display its text.</summary>
    /// <value>A value of any available type (a value type or an instance of a class). The default value is null (Nothing in VB).</value>
    [DefaultValue(null)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGStringConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Description("Determines the value of the column header used to display its text.")]
    [Category("Data")]
    public object Value
    {
      get
      {
        return this.fGrid.GetColHdrData(this.fRowIndex, this.fColIndex).Value;
      }
      set
      {
        this.fGrid.SetColHdrValue(this.fRowIndex, this.fColIndex, value);
      }
    }

    /// <summary>Gets or sets the index of the image displayed in the column header.</summary>
    /// <value>A zero-based index which represents the image position in an <see cref="T:System.Windows.Forms.ImageList" />. The default is -1 which means that the column header has no image.</value>
    [DefaultValue(-1)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGImageIndexConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Editor("TenTec.Windows.iGridLib.Design.iGImageIndexEditor, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0", typeof (UITypeEditor))]
    [Description("Determines the index of the image displayed in the column header.")]
    [Category("Data")]
    public int ImageIndex
    {
      get
      {
        return this.fGrid.GetColHdrData(this.fRowIndex, this.fColIndex).ImageIndex;
      }
      set
      {
        this.fGrid.SetColHdrImageIndex(this.fRowIndex, this.fColIndex, value);
      }
    }

    /// <summary>Gets or sets a style object determining the appearance and behavior of the column header.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGColHdrStyle" /> object that determines the appearance and behavior of the column header, or null (Nothing in VB) if the appearance and behavior of the column header is completely determined by the column style and the grid's properties. The default value is null (Nothing in VB).</value>
    [DefaultValue(null)]
    [RefreshProperties(RefreshProperties.All)]
    [Description("A style object determining the appearance and behavior of the column header.")]
    [Category("Appearance and Behavior")]
    public iGColHdrStyle Style
    {
      get
      {
        return this.fGrid.GetColHdrData(this.fRowIndex, this.fColIndex).Style;
      }
      set
      {
        this.fGrid.SetColHdrStyle(this.fRowIndex, this.fColIndex, value);
      }
    }

    /// <summary>Gets the column index of the column header.</summary>
    /// <value>A zero-based index representing the position of the column in the grid's collection of columns.</value>
    [Browsable(false)]
    public int ColIndex
    {
      get
      {
        return this.fColIndex - 1;
      }
    }

    /// <summary>Gets the row index of the column header.</summary>
    /// <value>A zero-based index representing the position of the header row in the grid's collection of header rows.</value>
    [Browsable(false)]
    public int RowIndex
    {
      get
      {
        return this.fRowIndex;
      }
    }

    /// <summary>Retrieves the bounds of the column header. The coordinates are relative to the upper left corner of the grid.</summary>
    /// <value>A <see cref="T:System.Drawing.Rectangle" /> that represents the size and location of the column header. The coordinates are relative to the upper left corner of the grid.</value>
    [Browsable(false)]
    public Rectangle Bounds
    {
      get
      {
        return this.fGrid.GetColHdrBounds(this.fRowIndex, this.fGrid.GetColOrder(this.fColIndex));
      }
    }

    /// <summary>Gets or sets the background color of the column header.</summary>
    /// <value>The color of the column header's background. The default is <see cref="F:System.Drawing.Color.Empty" /> which means that the style is not attached to the column header or the style's property is not specified and the property value is obtained from the <see cref="P:TenTec.Windows.iGridLib.iGStyleBase.BackColor" /> property of the style attached to the column (the <see cref="P:TenTec.Windows.iGridLib.iGCol.ColHdrStyle" /> property of the column).</value>
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGColorEmptyAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [RefreshProperties(RefreshProperties.All)]
    [Description("Determines the background color of the column header.")]
    [Category("Appearance")]
    public Color BackColor
    {
      get
      {
        iGColHdrStyle style = this.fGrid.GetColHdrData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return Color.Empty;
        return style.BackColor;
      }
      set
      {
        this.AdjustStyle().BackColor = value;
      }
    }

    /// <summary>Gets or sets the color of the text displayed in the column header.</summary>
    /// <value>The foreground color of the column header. The default is null (Nothing in VB) which means the property is not specified and the property value is obtained from the <see cref="P:TenTec.Windows.iGridLib.iGStyleBase.ForeColor" /> property of the style attached to the column (the <see cref="P:TenTec.Windows.iGridLib.iGCol.ColHdrStyle" /> property of the column).</value>
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGColorEmptyAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [RefreshProperties(RefreshProperties.All)]
    [Description("Determines the color of the text displayed in the column header.")]
    [Category("Appearance")]
    public Color ForeColor
    {
      get
      {
        iGColHdrStyle style = this.fGrid.GetColHdrData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return Color.Empty;
        return style.ForeColor;
      }
      set
      {
        this.AdjustStyle().ForeColor = value;
      }
    }

    /// <summary>Gets or sets the font used to display the text in the column header.</summary>
    /// <value>The <see cref="T:System.Drawing.Font" /> object to apply to the text displayed in the column header. The default is null (Nothing in VB) which means the property is not specified and the property value is obtained from the <see cref="P:TenTec.Windows.iGridLib.iGStyleBase.Font" /> property of the style attached to the column (the <see cref="P:TenTec.Windows.iGridLib.iGCol.ColHdrStyle" /> property of the column).</value>
    [DefaultValue(null)]
    [RefreshProperties(RefreshProperties.All)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGFontNoneAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Description("Determines the font used to display the text in the column header.")]
    [Category("Appearance")]
    public Font Font
    {
      get
      {
        iGColHdrStyle style = this.fGrid.GetColHdrData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return (Font) null;
        return style.Font;
      }
      set
      {
        this.AdjustStyle().Font = value;
      }
    }

    /// <summary>Gets or sets the format string applied to the column header's value before it is displayed (similar to the format string parameter in the <see cref="M:System.String.Format(System.IFormatProvider,System.String,System.Object[])" /> method of the <see cref="T:System.String" /> class).</summary>
    /// <value>The <see cref="T:System.String" /> used as the format string to get the text displayed in the cell. The default value is null (Nothing in VB).</value>
    [DefaultValue(null)]
    [RefreshProperties(RefreshProperties.All)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGStringNoneAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Description("Determines the format string applied to the column header's value before it is displayed (similar to the format string parameter in the Format method of the String class).")]
    [Category("Appearance")]
    public string FormatString
    {
      get
      {
        iGColHdrStyle style = this.fGrid.GetColHdrData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return (string) null;
        return style.FormatString;
      }
      set
      {
        this.AdjustStyle().FormatString = value;
      }
    }

    /// <summary>Gets or sets the format provider used to get the string representation of the column header's value (similar to the format provider in the <see cref="M:System.String.Format(System.IFormatProvider,System.String,System.Object[])" /> method of the <see cref="T:System.String" /> class).</summary>
    /// <value>The <see cref="T:System.IFormatProvider" /> object used to get the text displayed in the column header. The default value is null (Nothing in VB).</value>
    [Browsable(false)]
    public IFormatProvider FormatProvider
    {
      get
      {
        iGColHdrStyle style = this.fGrid.GetColHdrData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return (IFormatProvider) null;
        return style.FormatProvider;
      }
      set
      {
        this.AdjustStyle().FormatProvider = value;
      }
    }

    /// <summary>Gets or sets the horizontal and vertical alignment of the image displayed in the column header.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGContentAlignment" /> enumeration value that specifies where to place the image. The default is <see cref="F:TenTec.Windows.iGridLib.iGContentAlignment.NotSet" /> which means the property is not specified and the property value is obtained from the <see cref="P:TenTec.Windows.iGridLib.iGStyleBase.ImageAlign" /> property of the style attached to the column (the <see cref="P:TenTec.Windows.iGridLib.iGCol.ColHdrStyle" /> property of the column).</value>
    [DefaultValue(iGContentAlignment.NotSet)]
    [RefreshProperties(RefreshProperties.All)]
    [Description("Determines the horizontal and vertical alignment of the image displayed in the column header.")]
    [Category("Appearance")]
    public iGContentAlignment ImageAlign
    {
      get
      {
        iGColHdrStyle style = this.fGrid.GetColHdrData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return iGContentAlignment.NotSet;
        return style.ImageAlign;
      }
      set
      {
        this.AdjustStyle().ImageAlign = value;
      }
    }

    /// <summary>Gets or sets a value indicating the left, top, right and bottom indents of the column header contents.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGIndent" /> object that specifies the left, right, top and bottom indents. The default is <see cref="P:TenTec.Windows.iGridLib.iGIndent.NotSet" />, which means that the property is not specified and the property value is obtained from the <see cref="P:TenTec.Windows.iGridLib.iGStyleBase.ContentIndent" /> property of the style attached to the column (the <see cref="P:TenTec.Windows.iGridLib.iGCol.ColHdrStyle" /> property of the column).</value>
    [RefreshProperties(RefreshProperties.All)]
    [Description("Determines the left, top, right, and bottom indents of the column header contents.")]
    [Category("Appearance")]
    public iGIndent ContentIndent
    {
      get
      {
        iGColHdrStyle style = this.fGrid.GetColHdrData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return iGIndent.NotSet;
        return style.ContentIndent;
      }
      set
      {
        this.AdjustStyle().ContentIndent = value;
      }
    }

    /// <summary>Gets or sets the relative position of the image and text displayed in the column header.</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGTextPosToImage" /> enumeration values. The default is <see cref="F:TenTec.Windows.iGridLib.iGTextPosToImage.NotSet" /> which means the property is not specified and the property value is obtained from the <see cref="P:TenTec.Windows.iGridLib.iGStyleBase.TextPosToImage" /> property of the style attached to the column (the <see cref="P:TenTec.Windows.iGridLib.iGCol.ColHdrStyle" /> property of the column).</value>
    [DefaultValue(iGTextPosToImage.NotSet)]
    [RefreshProperties(RefreshProperties.All)]
    [Description("Determines the relative position of the image and text displayed in the column header.")]
    [Category("Appearance")]
    public iGTextPosToImage TextPosToImage
    {
      get
      {
        iGColHdrStyle style = this.fGrid.GetColHdrData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return iGTextPosToImage.NotSet;
        return style.TextPosToImage;
      }
      set
      {
        this.AdjustStyle().TextPosToImage = value;
      }
    }

    /// <summary>Gets or sets the horizontal and vertical alignment of the text displayed in the column header.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGContentAlignment" /> enumeration value that specifies where to place the text. The default is <see cref="F:TenTec.Windows.iGridLib.iGContentAlignment.NotSet" /> which means the property is not specified and the property value is obtained from the <see cref="P:TenTec.Windows.iGridLib.iGStyleBase.TextAlign" /> property of the style attached to the column (the <see cref="P:TenTec.Windows.iGridLib.iGCol.ColHdrStyle" /> property of the column).</value>
    [DefaultValue(iGContentAlignment.NotSet)]
    [RefreshProperties(RefreshProperties.All)]
    [Description("Determines the horizontal and vertical alignment of the text displayed in the column header.")]
    [Category("Appearance")]
    public iGContentAlignment TextAlign
    {
      get
      {
        iGColHdrStyle style = this.fGrid.GetColHdrData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return iGContentAlignment.NotSet;
        return style.TextAlign;
      }
      set
      {
        this.AdjustStyle().TextAlign = value;
      }
    }

    /// <summary>Gets or sets the text format flags of the column header (similar to the <see cref="T:System.Drawing.StringFormatFlags" /> enumeration in .NET Framework).</summary>
    /// <value>A bitwise combination of the <see cref="T:TenTec.Windows.iGridLib.iGStringFormatFlags" /> values. The default is <see cref="F:TenTec.Windows.iGridLib.iGStringFormatFlags.NotSet" /> which means the property is not specified and the property value is obtained from the <see cref="P:TenTec.Windows.iGridLib.iGStyleBase.TextFormatFlags" /> property of the style attached to the column (the <see cref="P:TenTec.Windows.iGridLib.iGCol.ColHdrStyle" /> property of the column).</value>
    [DefaultValue(iGStringFormatFlags.NotSet)]
    [RefreshProperties(RefreshProperties.All)]
    [Description("Determines the text format flags of the column header (similar to the StringFormatFlags enumeration in .NET Framework).")]
    [Category("Appearance")]
    public iGStringFormatFlags TextFormatFlags
    {
      get
      {
        iGColHdrStyle style = this.fGrid.GetColHdrData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return iGStringFormatFlags.NotSet;
        return style.TextFormatFlags;
      }
      set
      {
        this.AdjustStyle().TextFormatFlags = value;
      }
    }

    /// <summary>Gets or sets a value determining the trimming options of the text displayed in the column header (similar to the <see cref="T:System.Drawing.StringTrimming" /> enumeration in .NET Framework).</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGStringTrimming" /> enumeration values. The default is <see cref="F:TenTec.Windows.iGridLib.iGStringTrimming.NotSet" /> which means the property is not specified and the property value is obtained from the <see cref="P:TenTec.Windows.iGridLib.iGStyleBase.TextTrimming" /> property of the style attached to the column (the <see cref="P:TenTec.Windows.iGridLib.iGCol.ColHdrStyle" /> property of the column).</value>
    [DefaultValue(iGStringTrimming.NotSet)]
    [RefreshProperties(RefreshProperties.All)]
    [Description("Determines the trimming options of the text dispalyed in the column header (similar to the StringTrimming enumeration in .NET Framework).")]
    [Category("Appearance")]
    public iGStringTrimming TextTrimming
    {
      get
      {
        iGColHdrStyle style = this.fGrid.GetColHdrData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return iGStringTrimming.NotSet;
        return style.TextTrimming;
      }
      set
      {
        this.AdjustStyle().TextTrimming = value;
      }
    }

    /// <summary>Gets the string key of the column that contains this column header.</summary>
    /// <value>A zero-based index representing the position of the column in the grid's collection of columns.</value>
    [Browsable(false)]
    public string ColKey
    {
      get
      {
        return this.fGrid.GetColData(this.fColIndex).Key;
      }
    }

    /// <summary>Gets or sets a value determining which column header parts are custom drawn.</summary>
    /// <value>A bitwise combination of the <see cref="T:TenTec.Windows.iGridLib.iGCustomDrawFlags" /> values. The default is <see cref="F:TenTec.Windows.iGridLib.iGCustomDrawFlags.NotSet" />, which means that the property is not specified and the property value is obtained from the <see cref="P:TenTec.Windows.iGridLib.iGStyleBase.CustomDrawFlags" /> property of the column cell style.</value>
    [DefaultValue(iGCustomDrawFlags.NotSet)]
    [RefreshProperties(RefreshProperties.All)]
    [Description("Determines which of the column header's parts are custom drawn.")]
    [Category("Appearance")]
    public iGCustomDrawFlags CustomDrawFlags
    {
      get
      {
        iGColHdrStyle style = this.fGrid.GetColHdrData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return iGCustomDrawFlags.NotSet;
        return style.CustomDrawFlags;
      }
      set
      {
        this.AdjustStyle().CustomDrawFlags = value;
      }
    }

    /// <summary>Gets or sets flags that determine which parts of the column header's contents (image, text) are displayed.</summary>
    /// <value>A set of the <see cref="T:TenTec.Windows.iGridLib.iGColHdrFlags" /> enumeration values. The default is <see cref="F:TenTec.Windows.iGridLib.iGColHdrFlags.NotSet" /> which means the property is not specified and the property value is obtained from the <see cref="P:TenTec.Windows.iGridLib.iGColHdrStyle.Flags" /> property of the style attached to the column (the <see cref="P:TenTec.Windows.iGridLib.iGCol.ColHdrStyle" /> property of the column).</value>
    [DefaultValue(iGColHdrFlags.NotSet)]
    [RefreshProperties(RefreshProperties.All)]
    [Description("Determines appearance and behavior of the column header.")]
    [Category("Appearance")]
    public iGColHdrFlags Flags
    {
      get
      {
        iGColHdrStyle style = this.fGrid.GetColHdrData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return iGColHdrFlags.NotSet;
        return style.Flags;
      }
      set
      {
        this.AdjustStyle().Flags = value;
      }
    }

    /// <summary>Gets or sets a value determining whether to display the sort info in the column header when the column is sorted.</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGBool" /> values. The default is <see cref="F:TenTec.Windows.iGridLib.iGBool.NotSet" /> which means the property is not specified and the property value is obtained from the <see cref="P:TenTec.Windows.iGridLib.iGColHdrStyle.SortInfoVisible" /> property of the style attached to the column (the <see cref="P:TenTec.Windows.iGridLib.iGCol.ColHdrStyle" /> property of the column).</value>
    [DefaultValue(iGBool.NotSet)]
    [RefreshProperties(RefreshProperties.All)]
    [Description("Determines whether to display the sort info in the column header when the column is sorted.")]
    [Category("Appearance")]
    public iGBool SortInfoVisible
    {
      get
      {
        iGColHdrStyle style = this.fGrid.GetColHdrData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return iGBool.NotSet;
        return style.SortInfoVisible;
      }
      set
      {
        this.AdjustStyle().SortInfoVisible = value;
      }
    }

    /// <summary>Gets a value indicating whether this is the header of the row text column (the row text column is used to display the cells under the normal cells and the group rows).</summary>
    /// <value>True if this is the header of the row text column; otherwise, false.</value>
    [Browsable(false)]
    public bool IsRowText
    {
      get
      {
        return this.fColIndex == 0;
      }
    }

    /// <summary>Retrieves the bounds of the column header where the text is displayed. The coordinates are relative to the upper left corner of the grid.</summary>
    /// <value>A <see cref="T:System.Drawing.Rectangle" /> that represents the size and location of the column header's text area. The coordinates are relative to the upper left corner of the grid.</value>
    [Browsable(false)]
    public Rectangle TextBounds
    {
      get
      {
        return this.fGrid.GetColHdrTextAreaBounds(this.fRowIndex, this.fColIndex);
      }
    }

    /// <summary>Retrieves the bounds of the column header where the image is displayed. The coordinates are relative to the upper left corner of the grid.</summary>
    /// <value>A <see cref="T:System.Drawing.Rectangle" /> that represents the size and location of the column header's image area. The coordinates are relative to the upper left corner of the grid.</value>
    [Browsable(false)]
    public Rectangle ImageBounds
    {
      get
      {
        return this.fGrid.GetUniCellImageAreaBounds(iGGridSection.Header, this.fRowIndex, this.fColIndex);
      }
    }

    /// <summary>Gets the header row that contains this column header.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGHdrRow" /> object that provides the properties and methods of the row that contains this column header.</value>
    [Browsable(false)]
    public iGHdrRow Row
    {
      get
      {
        return new iGHdrRow(this.fGrid, this.fRowIndex);
      }
    }

    /// <summary>Gets the column that contains the column header.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGCol" /> object that provides the properties and methods of the column.</value>
    [Browsable(false)]
    public iGCol Col
    {
      get
      {
        return new iGCol(this.fGrid, this.fColIndex);
      }
    }

    /// <summary>Gets or sets the image list used to display the image in the column header.</summary>
    /// <value>An <see cref="T:System.Windows.Forms.ImageList" /> object used to store the image in the column header. The default is null (Nothing in VB), which means that the image list is obtained from the <see cref="P:TenTec.Windows.iGridLib.iGStyleBase.ImageList" /> property of the style attached to the column (the <see cref="P:TenTec.Windows.iGridLib.iGCol.ColHdrStyle" /> property of the column).</value>
    [DefaultValue(null)]
    [RefreshProperties(RefreshProperties.All)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGReferenceNullAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Description("Determines the image list used to display the image in the column header.")]
    [Category("Appearance")]
    public ImageList ImageList
    {
      get
      {
        iGColHdrStyle style = this.fGrid.GetColHdrData(this.fRowIndex, this.fColIndex).Style;
        if (style == null)
          return (ImageList) null;
        return style.ImageList;
      }
      set
      {
        this.AdjustStyle().ImageList = value;
      }
    }
  }
}
