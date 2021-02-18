// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGCellDesign
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib.Design
{
  public class iGCellDesign : IiGImageListProvider
  {
    private iGRowDesign fRow;
    private int fIndex;

    internal iGCellDesign(iGRowDesign row, int index)
    {
      this.fRow = row;
      this.fIndex = index;
    }

    private iGCellPattern GetCellPattern()
    {
      return this.fIndex != this.fRow.fGrid.RowTextCol.Index ? this.fRow.fNormalCells[this.fIndex] : this.fRow.fRowTextCell;
    }

    private iGCellStyle AdjustStyle()
    {
      iGCellPattern cellPattern = this.GetCellPattern();
      if (cellPattern.Style == null)
      {
        if (((Component) this.fRow.fGrid).Site != null && ((Component) this.fRow.fGrid).Site.DesignMode)
        {
          IDesignerHost service = (IDesignerHost) ((Component) this.fRow.fGrid).Site.GetService(typeof (IDesignerHost));
          string name;
          if (this.fRow.fGrid.Cols[this.fIndex].IsRowText)
            name = ((Control) this.fRow.fGrid).Name + "ExtraCellStyleR" + this.fRow.fRowDesignCollection.IndexOf((object) this.fRow).ToString();
          else
            name = ((Control) this.fRow.fGrid).Name + "CellStyleR" + this.fRow.fRowDesignCollection.IndexOf((object) this.fRow).ToString() + "C" + this.fIndex.ToString();
          cellPattern.Style=((iGCellStyle) iGDesigner.CreateStyleDesignTime(service, name, typeof (iGCellStyle), (iGStyleBase) null));
        }
        else
          cellPattern.Style=(new iGCellStyle());
      }
      return cellPattern.Style;
    }

    ImageList IiGImageListProvider.GetImageList(string propertyName)
    {
      return iGInternalInfrastructure.GetCellImageList(this.fRow.fGrid, (iGStyleBase) this.Style, (iGStyleBase) this.fRow.CellStyle, (iGStyleBase) this.fRow.fGrid.Cols[this.fIndex].CellStyle);
    }

    private bool ShouldSerializeValue()
    {
      return this.Value as string != this.fRow.fGrid.Cols[this.fIndex].DefaultCellValue as string;
    }

    private bool ShouldSerializeImageIndex()
    {
      return this.ImageIndex != this.fRow.fGrid.Cols[this.fIndex].DefaultCellImageIndex;
    }

    private bool ShouldSerializeStyle()
    {
      return this.Style != null;
    }

    private bool ShouldSerializeBackColor()
    {
      return this.BackColor != (Color) iGStyleBase.ConstDefaultBackColor;
    }

    private bool ShouldSerializeForeColor()
    {
      return this.ForeColor != (Color) iGStyleBase.ConstDefaultForeColor;
    }

    private bool ShouldSerializeContentIndent()
    {
      iGIndent contentIndent = this.ContentIndent;
      // ISSUE: explicit reference operation
      return !((iGIndent) @contentIndent).EqualsTo((iGIndent) iGStyleBase.ConstDefaultIndent);
    }

    [RefreshProperties(RefreshProperties.Repaint)]
    [TypeConverter(typeof (iGStringConverter))]
    [Description("The value used to display the cell's text.")]
    [ParenthesizePropertyName(true)]
    public object Value
    {
      get
      {
        return this.GetCellPattern().Value;
      }
      set
      {
        this.GetCellPattern().Value=(value);
      }
    }

    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The number of columns to span.")]
    [ParenthesizePropertyName(true)]
    [DefaultValue(1)]
    public int SpanCols
    {
      get
      {
        return this.GetCellPattern().SpanCols;
      }
      set
      {
        this.GetCellPattern().SpanCols=(value);
      }
    }

    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The number of rows to span.")]
    [ParenthesizePropertyName(true)]
    [DefaultValue(1)]
    public int SpanRows
    {
      get
      {
        return this.GetCellPattern().SpanRows;
      }
      set
      {
        this.GetCellPattern().SpanRows=(value);
      }
    }

    [RefreshProperties(RefreshProperties.Repaint)]
    [TypeConverter(typeof (iGImageIndexConverter))]
    [Editor("TenTec.Windows.iGridLib.Design.iGImageIndexEditor, TenTec.Windows.iGridLib.Design", typeof (UITypeEditor))]
    [Description("The index of the image displayed in the cell.")]
    [ParenthesizePropertyName(true)]
    public int ImageIndex
    {
      get
      {
        return this.GetCellPattern().ImageIndex;
      }
      set
      {
        this.GetCellPattern().ImageIndex=(value);
      }
    }

    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("A style object determining the appearance and behavior of the cell.")]
    [ParenthesizePropertyName(true)]
    public iGCellStyle Style
    {
      get
      {
        return this.GetCellPattern().Style;
      }
      set
      {
        iGStyleConverterBase.iGCellStyleNew iGcellStyleNew = value as iGStyleConverterBase.iGCellStyleNew;
        if (iGcellStyleNew != null)
          value = (iGCellStyle) iGDesigner.CreateStyleDesignTime(iGcellStyleNew.Host, (string) null, typeof (iGCellStyleDesign), (iGStyleBase) null);
        this.GetCellPattern().Style=(value);
      }
    }

    internal iGrid Grid
    {
      get
      {
        return this.fRow.fGrid;
      }
    }

    [RefreshProperties(RefreshProperties.Repaint)]
    [TypeConverter(typeof (iGColorEmptyAsNotSetConverter))]
    [Description("Determines the background color of the cell.")]
    [Category("Appearance")]
    public Color BackColor
    {
      get
      {
        iGCellStyle style = this.GetCellPattern().Style;
        if (style == null)
          return Color.Empty;
        return ((iGStyleBase) style).BackColor;
      }
      set
      {
        ((iGStyleBase) this.AdjustStyle()).BackColor=(value);
      }
    }

    [RefreshProperties(RefreshProperties.Repaint)]
    [TypeConverter(typeof (iGColorEmptyAsNotSetConverter))]
    [Description("Determines the color of the text displayed in the cell.")]
    [Category("Appearance")]
    public Color ForeColor
    {
      get
      {
        iGCellStyle style = this.GetCellPattern().Style;
        if (style == null)
          return Color.Empty;
        return ((iGStyleBase) style).ForeColor;
      }
      set
      {
        ((iGStyleBase) this.AdjustStyle()).ForeColor=(value);
      }
    }

    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(null)]
    [TypeConverter(typeof (iGFontNoneAsNotSetConverter))]
    [Description("Determines the font used to display the text in the cell.")]
    [Category("Appearance")]
    public Font Font
    {
      get
      {
        iGCellStyle style = this.GetCellPattern().Style;
        if (style == null)
          return (Font) null;
        return ((iGStyleBase) style).Font;
      }
      set
      {
        ((iGStyleBase) this.AdjustStyle()).Font=(value);
      }
    }

    [RefreshProperties(RefreshProperties.Repaint)]
    // [DefaultValue]
    [Description("Determines the horizontal and vertical alignment of the image displayed in the cell.")]
    [Category("Appearance")]
    public iGContentAlignment ImageAlign
    {
      get
      {
        iGCellStyle style = this.GetCellPattern().Style;
        if (style == null)
          return (iGContentAlignment) 0;
        return ((iGStyleBase) style).ImageAlign;
      }
      set
      {
        ((iGStyleBase) this.AdjustStyle()).ImageAlign=(value);
      }
    }

    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines the left, top, right, and bottom indents of the cell's contents.")]
    [Category("Appearance")]
    public iGIndent ContentIndent
    {
      get
      {
        iGCellStyle style = this.GetCellPattern().Style;
        if (style == null)
          return iGIndent.NotSet;
        return ((iGStyleBase) style).ContentIndent;
      }
      set
      {
        ((iGStyleBase) this.AdjustStyle()).ContentIndent=(value);
      }
    }

    [RefreshProperties(RefreshProperties.Repaint)]
    // // [DefaultValue]
    [Description("Determines the relative position of the image and text displayed in the cell.")]
    [Category("Appearance")]
    public iGTextPosToImage TextPosToImage
    {
      get
      {
        iGCellStyle style = this.GetCellPattern().Style;
        if (style == null)
          return (iGTextPosToImage) 3;
        return ((iGStyleBase) style).TextPosToImage;
      }
      set
      {
        ((iGStyleBase) this.AdjustStyle()).TextPosToImage=(value);
      }
    }

    [RefreshProperties(RefreshProperties.Repaint)]
    // [DefaultValue]
    [Description("Determines the type of the cell (a text box cell, combo box cell, or a check box cell).")]
    [Category("Behavior")]
    public iGCellType Type
    {
      get
      {
        iGCellStyle style = this.GetCellPattern().Style;
        if (style == null)
          return (iGCellType) 0;
        return style.Type;
      }
      set
      {
        this.AdjustStyle().Type=(value);
      }
    }

    [RefreshProperties(RefreshProperties.Repaint)]
    // [DefaultValue]
    [Description("Determines the horizontal and vertical alignment of the text displayed in the cell.")]
    [Category("Appearance")]
    public iGContentAlignment TextAlign
    {
      get
      {
        iGCellStyle style = this.GetCellPattern().Style;
        if (style == null)
          return (iGContentAlignment) 0;
        return ((iGStyleBase) style).TextAlign;
      }
      set
      {
        ((iGStyleBase) this.AdjustStyle()).TextAlign=(value);
      }
    }

    [RefreshProperties(RefreshProperties.Repaint)]
    // [DefaultValue]
    [Description("Determines the text format flags of the cell (similar to the FormatFlags property of the StringFormat class).")]
    [Category("Appearance")]
    public iGStringFormatFlags TextFormatFlags
    {
      get
      {
        iGCellStyle style = this.GetCellPattern().Style;
        if (style == null)
          return (iGStringFormatFlags) 32768;
        return ((iGStyleBase) style).TextFormatFlags;
      }
      set
      {
        ((iGStyleBase) this.AdjustStyle()).TextFormatFlags=(value);
      }
    }

    [RefreshProperties(RefreshProperties.Repaint)]
    // [DefaultValue]
    [Description("Determines the trimming options of the text dispalyed in the cell (similar to the Trimming property of the StringFormat class).")]
    [Category("Appearance")]
    public iGStringTrimming TextTrimming
    {
      get
      {
        iGCellStyle style = this.GetCellPattern().Style;
        if (style == null)
          return (iGStringTrimming) 6;
        return ((iGStyleBase) style).TextTrimming;
      }
      set
      {
        ((iGStyleBase) this.AdjustStyle()).TextTrimming=(value);
      }
    }

    [RefreshProperties(RefreshProperties.Repaint)]
    // [DefaultValue]
    [Description("Determines whether the cell is enabled. The disabled cells cannot be edited and the ForeColorDisabled color is used to draw their text.")]
    [Category("Behavior")]
    public iGBool Enabled
    {
      get
      {
        iGCellStyle style = this.GetCellPattern().Style;
        if (style == null)
          return (iGBool) 2;
        return style.Enabled;
      }
      set
      {
        this.AdjustStyle().Enabled=(value);
      }
    }

    [RefreshProperties(RefreshProperties.Repaint)]
    // [DefaultValue]
    [Description("Determines whether the cell can be edited.")]
    [Category("Behavior")]
    public iGBool ReadOnly
    {
      get
      {
        iGCellStyle style = this.GetCellPattern().Style;
        if (style == null)
          return (iGBool) 2;
        return style.ReadOnly;
      }
      set
      {
        this.AdjustStyle().ReadOnly=(value);
      }
    }

    [RefreshProperties(RefreshProperties.Repaint)]
    // [DefaultValue]
    [Description("Determines whether the cell can be selected with the mouse and/or keyboard.")]
    [Category("Behavior")]
    public iGBool Selectable
    {
      get
      {
        iGCellStyle style = this.GetCellPattern().Style;
        if (style == null)
          return (iGBool) 2;
        return style.Selectable;
      }
      set
      {
        this.AdjustStyle().Selectable=(value);
      }
    }

    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(null)]
    [TypeConverter(typeof (iGStringNoneAsNotSetConverter))]
    [Description("Determines the format string applied to the cell's value before it is displayed (similar to the formatString parameter in the Format method of the String class).")]
    [Category("Appearance")]
    public string FormatString
    {
      get
      {
        iGCellStyle style = this.GetCellPattern().Style;
        if (style == null)
          return (string) null;
        return ((iGStyleBase) style).FormatString;
      }
      set
      {
        ((iGStyleBase) this.AdjustStyle()).FormatString=(value);
      }
    }

    [Browsable(false)]
    public IFormatProvider FormatProvider
    {
      get
      {
        iGCellStyle style = this.GetCellPattern().Style;
        if (style == null)
          return (IFormatProvider) null;
        return ((iGStyleBase) style).FormatProvider;
      }
      set
      {
        ((iGStyleBase) this.AdjustStyle()).FormatProvider=(value);
      }
    }

    [RefreshProperties(RefreshProperties.Repaint)]
    // [DefaultValue]
    [Description("Determines which of the cell's parts are custom drawn.")]
    [Category("Appearance")]
    public iGCustomDrawFlags CustomDrawFlags
    {
      get
      {
        iGCellStyle style = this.GetCellPattern().Style;
        if (style == null)
          return (iGCustomDrawFlags) 4;
        return ((iGStyleBase) style).CustomDrawFlags;
      }
      set
      {
        ((iGStyleBase) this.AdjustStyle()).CustomDrawFlags=(value);
      }
    }

    [RefreshProperties(RefreshProperties.Repaint)]
    // [DefaultValue]
    [Description("Determines the additional flags used to modify some aspects of the cell's type.")]
    [Category("Behavior")]
    public iGCellTypeFlags TypeFlags
    {
      get
      {
        iGCellStyle style = this.GetCellPattern().Style;
        if (style == null)
          return (iGCellTypeFlags) 1;
        return style.TypeFlags;
      }
      set
      {
        this.AdjustStyle().TypeFlags=(value);
      }
    }

    [RefreshProperties(RefreshProperties.Repaint)]
    // [DefaultValue]
    [Description("Flags that determine appearance and behavior of the cell.")]
    [Category("Appearance")]
    public iGCellFlags Flags
    {
      get
      {
        iGCellStyle style = this.GetCellPattern().Style;
        if (style == null)
          return (iGCellFlags) 1;
        return style.Flags;
      }
      set
      {
        this.AdjustStyle().Flags=(value);
      }
    }

    [RefreshProperties(RefreshProperties.Repaint)]
    // [DefaultValue]
    [Description("Determines whether the single mouse click starts editing the cell if it is not current.")]
    [Category("Behavior")]
    public iGBool SingleClickEdit
    {
      get
      {
        iGCellStyle style = this.GetCellPattern().Style;
        if (style == null)
          return (iGBool) 2;
        return style.SingleClickEdit;
      }
      set
      {
        this.AdjustStyle().SingleClickEdit=(value);
      }
    }

    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(null)]
    [TypeConverter(typeof (iGValueTypeConverter))]
    [Description("Determines the type of the value the edited text will be converted to.")]
    [Category("Behavior")]
    public System.Type ValueType
    {
      get
      {
        iGCellStyle style = this.GetCellPattern().Style;
        if (style == null)
          return (System.Type) null;
        return style.ValueType;
      }
      set
      {
        this.AdjustStyle().ValueType=(value);
      }
    }

    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(null)]
    [TypeConverter(typeof (iGReferenceNullAsNotSetConverter))]
    [Description("Determines the control to show in the drop-down form when editing the cell.")]
    [Category("Behavior")]
    public IiGDropDownControl DropDownControl
    {
      get
      {
        iGCellStyle style = this.GetCellPattern().Style;
        if (style == null)
          return (IiGDropDownControl) null;
        return ((iGStyleBase) style).DropDownControl;
      }
      set
      {
        ((iGStyleBase) this.AdjustStyle()).DropDownControl=(value);
      }
    }

    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(null)]
    [TypeConverter(typeof (iGReferenceNullAsNotSetConverter))]
    [Description("Determines the image list used to display the image in the cell.")]
    [Category("Appearance")]
    public ImageList ImageList
    {
      get
      {
        iGCellStyle style = this.GetCellPattern().Style;
        if (style == null)
          return (ImageList) null;
        return ((iGStyleBase) style).ImageList;
      }
      set
      {
        ((iGStyleBase) this.AdjustStyle()).ImageList=(value);
      }
    }

    [RefreshProperties(RefreshProperties.Repaint)]
    // [DefaultValue]
    [Description("Determines how to interpret an empty string entered in the text box while editing the cell.")]
    [Category("Behavior")]
    public iGEmptyStringAs EmptyStringAs
    {
      get
      {
        iGCellStyle style = this.GetCellPattern().Style;
        if (style == null)
          return (iGEmptyStringAs) 0;
        return style.EmptyStringAs;
      }
      set
      {
        this.AdjustStyle().EmptyStringAs=(value);
      }
    }

    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(0)]
    [Description("Determines the maximum number of characters the user can type or paste into the cell while editing.")]
    [Category("Behavior")]
    public int MaxInputLength
    {
      get
      {
        iGCellStyle style = this.GetCellPattern().Style;
        if (style == null)
          return 0;
        return style.MaxInputLength;
      }
      set
      {
        this.AdjustStyle().MaxInputLength=(value);
      }
    }

    [RefreshProperties(RefreshProperties.Repaint)]
    // [DefaultValue]
    [Description("Determines whether iGrid forces drawing of cell contents in the viewport.")]
    [Category("Behavior")]
    public iGCellFitContentsInViewport FitContentsInViewport
    {
      get
      {
        iGCellStyle style = this.GetCellPattern().Style;
        if (style == null)
          return (iGCellFitContentsInViewport) 1;
        return style.FitContentsInViewport;
      }
      set
      {
        this.AdjustStyle().FitContentsInViewport=(value);
      }
    }
  }
}
