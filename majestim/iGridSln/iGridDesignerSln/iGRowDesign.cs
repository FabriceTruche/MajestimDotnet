// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGRowDesign
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib.Design
{
  [TypeConverter(typeof (iGRowDesignConverter))]
  internal class iGRowDesign
  {
    internal iGRowPattern fPattern;
    internal iGCellPattern[] fNormalCells;
    internal iGCellPattern fRowTextCell;
    internal iGrid fGrid;
    internal ArrayList fRowDesignCollection;

    public iGRowDesign(iGrid grid, ArrayList rowDesignCollection)
    {
      this.fGrid = grid;
      this.fPattern = grid.DefaultRow.Clone();
      this.fNormalCells = new iGCellPattern[grid.Cols.Count];
      for (int index = 0; index < grid.Cols.Count; ++index)
        this.fNormalCells[index] = iGColCollectionEditor.CreateNewCellForColumn(grid.Cols[index].Pattern);
      this.fRowTextCell = iGColCollectionEditor.CreateNewCellForColumn(grid.RowTextCol.Pattern);
      this.fRowDesignCollection = rowDesignCollection;
    }

    public iGRowDesign(iGrid grid, iGRowPattern rowPattern, int rowIndex, ArrayList rowDesignCollection)
    {
      this.fGrid = grid;
      this.fPattern = rowPattern;
      this.fNormalCells = new iGCellPattern[grid.Cols.Count];
      for (int index = 0; index < grid.Cols.Count; ++index)
        this.fNormalCells[index] = grid.Rows[rowIndex].Cells[index].Pattern;
      this.fRowTextCell = grid.Rows[rowIndex].RowTextCell.Pattern;
      this.fRowDesignCollection = rowDesignCollection;
    }

    public override string ToString()
    {
      StringBuilder stringBuilder = new StringBuilder();
      if (this.fPattern.Key != null)
      {
        stringBuilder.Append("[");
        stringBuilder.Append(this.fPattern.Key.ToString());
        stringBuilder.Append("] ");
      }
      for (int index1 = 0; index1 < this.fNormalCells.Length; ++index1)
      {
        if (this.fNormalCells[index1].Value != null)
        {
          for (int index2 = 0; index2 < this.fNormalCells.Length; ++index2)
          {
            stringBuilder.Append('(');
            stringBuilder.Append(this.fNormalCells[index2].Value);
            stringBuilder.Append(')');
          }
          stringBuilder.Append(' ');
          break;
        }
      }
      if (this.fRowTextCell.Value != null)
      {
        stringBuilder.Append('<');
        stringBuilder.Append(this.fRowTextCell.Value);
        stringBuilder.Append('>');
      }
      if (stringBuilder.Length == 0)
        return "Row";
      return stringBuilder.ToString();
    }

    private void CheckKeyUnique(string value)
    {
      if (value == null)
        return;
      foreach (iGRowDesign fRowDesign in this.fRowDesignCollection)
      {
        if (fRowDesign != this && fRowDesign.Key == value)
          throw new ArgumentException("Key already exists");
      }
    }

    private iGCellStyle AdjustCellStyle()
    {
      if (this.fPattern.CellStyle == null)
      {
        if (((Component) this.fGrid).Site != null && ((Component) this.fGrid).Site.DesignMode)
          this.fPattern.CellStyle = ((iGCellStyle) iGDesigner.CreateStyleDesignTime((IDesignerHost) ((Component) this.fGrid).Site.GetService(typeof (IDesignerHost)), ((Control) this.fGrid).Name + "RowStyle" + this.fRowDesignCollection.IndexOf((object) this).ToString(), typeof (iGCellStyle), (iGStyleBase) null));
        else
          this.fPattern.CellStyle = (new iGCellStyle());
      }
      return this.fPattern.CellStyle;
    }

    private bool ShouldSerializeHeight()
    {
      return this.fGrid.DefaultRow.Height != this.Height;
    }

    private bool ShouldSerializeNormalCellHeight()
    {
      return this.fGrid.DefaultRow.NormalCellHeight != this.NormalCellHeight;
    }

    private bool ShouldSerializeVisible()
    {
      return this.fGrid.DefaultRow.Visible != this.Visible;
    }

    private bool ShouldSerializeType()
    {
      return this.fGrid.DefaultRow.Type != this.Type;
    }

    private bool ShouldSerializeLevel()
    {
      return this.fGrid.DefaultRow.Level != this.Level;
    }

    private bool ShouldSerializeSortable()
    {
      return this.fGrid.DefaultRow.Sortable != this.Sortable;
    }

    private bool ShouldSerializeTreeButton()
    {
      return this.fGrid.DefaultRow.TreeButton != this.TreeButton;
    }

    private bool ShouldSerializeSelectable()
    {
      return this.fGrid.DefaultRow.Selectable != this.Selectable;
    }

    private bool ShouldSerializeCellStyle()
    {
      return this.CellStyle != null;
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

    [Description("The height of the row.")]
    [Category("Layout")]
    public int Height
    {
      get
      {
        return this.fPattern.Height;
      }
      set
      {
        this.fPattern.Height = (value);
      }
    }

    [Description("The height of the cells above the row text cell.")]
    [Category("Layout")]
    public int NormalCellHeight
    {
      get
      {
        return this.fPattern.NormalCellHeight;
      }
      set
      {
        this.fPattern.NormalCellHeight = (value);
      }
    }

    [Description("Determines whether the row is visible.")]
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

    [Description("The type of the row.")]
    [Category("Behavior")]
    public iGRowType Type
    {
      get
      {
        return this.fPattern.Type;
      }
      set
      {
        this.fPattern.Type=(value);
      }
    }

    [TypeConverter(typeof (iGStringConverter))]
    [DefaultValue(null)]
    [Description("The string key of the row.")]
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

    [Description("The horizontal indent of the first cell in the row. Helps to create a treelike grid.")]
    [Category("Behavior")]
    public int Level
    {
      get
      {
        return this.fPattern.Level;
      }
      set
      {
        this.fPattern.Level=(value);
      }
    }

    [Description("Determines whether the row can change its position while sorting.")]
    [Category("Behavior")]
    public bool Sortable
    {
      get
      {
        return this.fPattern.Sortable;
      }
      set
      {
        this.fPattern.Sortable=(value);
      }
    }

    [Description("The state of the row's tree button.")]
    [Category("Behavior")]
    public iGTreeButtonState TreeButton
    {
      get
      {
        return this.fPattern.TreeButton;
      }
      set
      {
        this.fPattern.TreeButton=(value);
      }
    }

    [Description("Indicates whether the specified row can be selected.")]
    [Category("Behavior")]
    public bool Selectable
    {
      get
      {
        return this.fPattern.Selectable;
      }
      set
      {
        this.fPattern.Selectable=(value);
      }
    }

    [TypeConverter(typeof (iGCellStyleConverter))]
    [Description("A style object determining the appearance and behavior of the row's cells.")]
    [RefreshProperties(RefreshProperties.All)]
    [Category("Cell Appearance and Behavior")]
    [ParenthesizePropertyName]
    public iGCellStyle CellStyle
    {
      get
      {
        return this.fPattern.CellStyle;
      }
      set
      {
        if (value is iGStyleConverterBase.iGCellStyleNew)
          value = iGDesigner.CreateStyleDesignTime(((Component) this.fGrid).Site == null ? (IDesignerHost) null : ((Component) this.fGrid).Site.GetService(typeof (IDesignerHost)) as IDesignerHost, (string) null, typeof (iGCellStyleDesign), (iGStyleBase) null) as iGCellStyle;
        this.fPattern.CellStyle=(value);
      }
    }

    [RefreshProperties(RefreshProperties.All)]
    [TypeConverter(typeof (iGColorEmptyAsNotSetConverter))]
    [Description("Determines the background color of the row.")]
    [Category("Cell Appearance and Behavior")]
    public Color BackColor
    {
      get
      {
        iGCellStyle cellStyle = this.fPattern.CellStyle;
        if (cellStyle == null)
          return Color.Empty;
        return ((iGStyleBase) cellStyle).BackColor;
      }
      set
      {
        ((iGStyleBase) this.AdjustCellStyle()).BackColor=(value);
      }
    }

    [RefreshProperties(RefreshProperties.All)]
    [TypeConverter(typeof (iGColorEmptyAsNotSetConverter))]
    [Description("Determines the color of the text displayed in the cells in the row.")]
    [Category("Cell Appearance and Behavior")]
    public Color ForeColor
    {
      get
      {
        iGCellStyle cellStyle = this.fPattern.CellStyle;
        if (cellStyle == null)
          return Color.Empty;
        return ((iGStyleBase) cellStyle).ForeColor;
      }
      set
      {
        ((iGStyleBase) this.AdjustCellStyle()).ForeColor=(value);
      }
    }

    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(null)]
    [TypeConverter(typeof (iGFontNoneAsNotSetConverter))]
    [Description("Determines the font used to display the text in the cells in the row.")]
    [Category("Cell Appearance and Behavior")]
    public Font Font
    {
      get
      {
        iGCellStyle cellStyle = this.fPattern.CellStyle;
        if (cellStyle == null)
          return (Font) null;
        return ((iGStyleBase) cellStyle).Font;
      }
      set
      {
        ((iGStyleBase) this.AdjustCellStyle()).Font=(value);
      }
    }

    [RefreshProperties(RefreshProperties.All)]
    // [DefaultValue]
    [Description("Determines the horizontal and vertical alignment of the images displayed in the cells in the row.")]
    [Category("Cell Appearance and Behavior")]
    public iGContentAlignment ImageAlign
    {
      get
      {
        iGCellStyle cellStyle = this.fPattern.CellStyle;
        if (cellStyle == null)
          return (iGContentAlignment) 0;
        return ((iGStyleBase) cellStyle).ImageAlign;
      }
      set
      {
        ((iGStyleBase) this.AdjustCellStyle()).ImageAlign=(value);
      }
    }

    [RefreshProperties(RefreshProperties.All)]
    [Description("Determines the indents of the contents in the cells in the row.")]
    [Category("Cell Appearance and Behavior")]
    public iGIndent ContentIndent
    {
      get
      {
        iGCellStyle cellStyle = this.fPattern.CellStyle;
        if (cellStyle == null)
          return iGIndent.NotSet;
        return ((iGStyleBase) cellStyle).ContentIndent;
      }
      set
      {
        ((iGStyleBase) this.AdjustCellStyle()).ContentIndent=(value);
      }
    }

    [RefreshProperties(RefreshProperties.All)]
    // [DefaultValue]
    [Description("Determines the relative position of the images and text displayed in the cells in the row.")]
    [Category("Cell Appearance and Behavior")]
    public iGTextPosToImage TextPosToImage
    {
      get
      {
        iGCellStyle cellStyle = this.fPattern.CellStyle;
        if (cellStyle == null)
          return (iGTextPosToImage) 3;
        return ((iGStyleBase) cellStyle).TextPosToImage;
      }
      set
      {
        ((iGStyleBase) this.AdjustCellStyle()).TextPosToImage=(value);
      }
    }

    [RefreshProperties(RefreshProperties.All)]
    // [DefaultValue]
    [Description("Determines the type of the cell (a text box cell, combo box cell, or a check box cell).")]
    [Category("Cell Appearance and Behavior")]
    public iGCellType CellType
    {
      get
      {
        iGCellStyle cellStyle = this.fPattern.CellStyle;
        if (cellStyle == null)
          return (iGCellType) 0;
        return cellStyle.Type;
      }
      set
      {
        this.AdjustCellStyle().Type=(value);
      }
    }

    [RefreshProperties(RefreshProperties.All)]
    // [DefaultValue]
    [Description("Determines the horizontal and vertical alignment of the text displayed in the cells in the row.")]
    [Category("Cell Appearance and Behavior")]
    public iGContentAlignment TextAlign
    {
      get
      {
        iGCellStyle cellStyle = this.fPattern.CellStyle;
        if (cellStyle == null)
          return (iGContentAlignment) 0;
        return ((iGStyleBase) cellStyle).TextAlign;
      }
      set
      {
        ((iGStyleBase) this.AdjustCellStyle()).TextAlign=(value);
      }
    }

    [RefreshProperties(RefreshProperties.All)]
    // [DefaultValue]
    [Description("Determines the text format flags of the cells in the row (similar to the FormatFlags property of the StringFormat class).")]
    [Category("Cell Appearance and Behavior")]
    public iGStringFormatFlags TextFormatFlags
    {
      get
      {
        iGCellStyle cellStyle = this.fPattern.CellStyle;
        if (cellStyle == null)
          return (iGStringFormatFlags) 32768;
        return ((iGStyleBase) cellStyle).TextFormatFlags;
      }
      set
      {
        ((iGStyleBase) this.AdjustCellStyle()).TextFormatFlags=(value);
      }
    }

    [RefreshProperties(RefreshProperties.All)]
    // [DefaultValue]
    [Description("Determines the trimming options of the text dispalyed in the cells in the row (similar to the Trimming property of the StringFormat class).")]
    [Category("Cell Appearance and Behavior")]
    public iGStringTrimming TextTrimming
    {
      get
      {
        iGCellStyle cellStyle = this.fPattern.CellStyle;
        if (cellStyle == null)
          return (iGStringTrimming) 6;
        return ((iGStyleBase) cellStyle).TextTrimming;
      }
      set
      {
        ((iGStyleBase) this.AdjustCellStyle()).TextTrimming=(value);
      }
    }

    [RefreshProperties(RefreshProperties.All)]
    // [DefaultValue]
    [Description("Determines whether the cells in the row are enabled. The disabled cells cannot be edited and the ForeColorDisabled color is used to draw their text.")]
    [Category("Cell Appearance and Behavior")]
    public iGBool Enabled
    {
      get
      {
        iGCellStyle cellStyle = this.fPattern.CellStyle;
        if (cellStyle == null)
          return (iGBool) 2;
        return cellStyle.Enabled;
      }
      set
      {
        this.AdjustCellStyle().Enabled=(value);
      }
    }

    [RefreshProperties(RefreshProperties.All)]
    // [DefaultValue]
    [Description("Determines whether the cells in the row can be edited.")]
    [Category("Cell Appearance and Behavior")]
    public iGBool ReadOnly
    {
      get
      {
        iGCellStyle cellStyle = this.fPattern.CellStyle;
        if (cellStyle == null)
          return (iGBool) 2;
        return cellStyle.ReadOnly;
      }
      set
      {
        this.AdjustCellStyle().ReadOnly=(value);
      }
    }

    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(null)]
    [TypeConverter(typeof (iGStringNoneAsNotSetConverter))]
    [Description("Determines the format string applied to the cell values in the row before they are displayed (similar to the formatString parameter in the Format method of the String class).")]
    [Category("Cell Appearance and Behavior")]
    public string FormatString
    {
      get
      {
        iGCellStyle cellStyle = this.fPattern.CellStyle;
        if (cellStyle == null)
          return (string) null;
        return ((iGStyleBase) cellStyle).FormatString;
      }
      set
      {
        ((iGStyleBase) this.AdjustCellStyle()).FormatString=(value);
      }
    }

    [RefreshProperties(RefreshProperties.All)]
    // [DefaultValue]
    [Description("Determines which of the parts of the cells are custom drawn in the row.")]
    [Category("Cell Appearance and Behavior")]
    public iGCustomDrawFlags CustomDrawFlags
    {
      get
      {
        iGCellStyle cellStyle = this.fPattern.CellStyle;
        if (cellStyle == null)
          return (iGCustomDrawFlags) 4;
        return ((iGStyleBase) cellStyle).CustomDrawFlags;
      }
      set
      {
        ((iGStyleBase) this.AdjustCellStyle()).CustomDrawFlags=(value);
      }
    }

    [RefreshProperties(RefreshProperties.All)]
    // [DefaultValue]
    [Description("Determines the additional flags used to modify some aspects of the cell types in the row.")]
    [Category("Cell Appearance and Behavior")]
    public iGCellTypeFlags CellTypeFlags
    {
      get
      {
        iGCellStyle cellStyle = this.fPattern.CellStyle;
        if (cellStyle == null)
          return (iGCellTypeFlags) 1;
        return cellStyle.TypeFlags;
      }
      set
      {
        this.AdjustCellStyle().TypeFlags=(value);
      }
    }

    [RefreshProperties(RefreshProperties.All)]
    // [DefaultValue]
    [Description("Flags that determine appearance and behavior of the cells in the row.")]
    [Category("Cell Appearance and Behavior")]
    public iGCellFlags Flags
    {
      get
      {
        iGCellStyle cellStyle = this.fPattern.CellStyle;
        if (cellStyle == null)
          return (iGCellFlags) 1;
        return cellStyle.Flags;
      }
      set
      {
        this.AdjustCellStyle().Flags=(value);
      }
    }

    [RefreshProperties(RefreshProperties.All)]
    // [DefaultValue]
    [Description("Determines whether the single mouse click starts editing a cell in the row if it is not current.")]
    [Category("Cell Appearance and Behavior")]
    public iGBool SingleClickEdit
    {
      get
      {
        iGCellStyle cellStyle = this.fPattern.CellStyle;
        if (cellStyle == null)
          return (iGBool) 2;
        return cellStyle.SingleClickEdit;
      }
      set
      {
        this.AdjustCellStyle().SingleClickEdit=(value);
      }
    }

    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(null)]
    [TypeConverter(typeof (iGValueTypeConverter))]
    [Description("Determines the type to convert an entered while editing text to in the cells in the row.")]
    [Category("Cell Appearance and Behavior")]
    public System.Type ValueType
    {
      get
      {
        iGCellStyle cellStyle = this.fPattern.CellStyle;
        if (cellStyle == null)
          return (System.Type) null;
        return cellStyle.ValueType;
      }
      set
      {
        this.AdjustCellStyle().ValueType=(value);
      }
    }

    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(null)]
    [TypeConverter(typeof (iGReferenceNullAsNotSetConverter))]
    [Description("Determines the control to show in the drop-down form when editing the cells in the row.")]
    [Category("Cell Appearance and Behavior")]
    public IiGDropDownControl DropDownControl
    {
      get
      {
        iGCellStyle cellStyle = this.fPattern.CellStyle;
        if (cellStyle == null)
          return (IiGDropDownControl) null;
        return ((iGStyleBase) cellStyle).DropDownControl;
      }
      set
      {
        ((iGStyleBase) this.AdjustCellStyle()).DropDownControl=(value);
      }
    }

    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(null)]
    [TypeConverter(typeof (iGReferenceNullAsNotSetConverter))]
    [Description("Determines the image list used to display the images in the cells in the row.")]
    [Category("Cell Appearance and Behavior")]
    public ImageList ImageList
    {
      get
      {
        iGCellStyle cellStyle = this.fPattern.CellStyle;
        if (cellStyle == null)
          return (ImageList) null;
        return ((iGStyleBase) cellStyle).ImageList;
      }
      set
      {
        ((iGStyleBase) this.AdjustCellStyle()).ImageList=(value);
      }
    }

    [RefreshProperties(RefreshProperties.All)]
    // [DefaultValue]
    [Description("Determines how to interpret an empty string entered in the text box while editing the cells in the row.")]
    [Category("Cell Appearance and Behavior")]
    public iGEmptyStringAs EmptyStringAs
    {
      get
      {
        iGCellStyle cellStyle = this.fPattern.CellStyle;
        if (cellStyle == null)
          return (iGEmptyStringAs) 0;
        return cellStyle.EmptyStringAs;
      }
      set
      {
        this.AdjustCellStyle().EmptyStringAs=(value);
      }
    }

    [RefreshProperties(RefreshProperties.All)]
    // [DefaultValue]
    [Description("Determines whether the cells in the row can be selected with the mouse and/or keyboard.")]
    [Category("Cell Appearance and Behavior")]
    public iGBool CellSelectable
    {
      get
      {
        iGCellStyle cellStyle = this.fPattern.CellStyle;
        if (cellStyle == null)
          return (iGBool) 2;
        return cellStyle.Selectable;
      }
      set
      {
        this.AdjustCellStyle().Selectable=(value);
      }
    }

    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(0)]
    [Description("Determines the maximum number of characters the user can type or paste into the cells in the row while editing.")]
    [Category("Cell Appearance and Behavior")]
    public int MaxInputLength
    {
      get
      {
        iGCellStyle cellStyle = this.fPattern.CellStyle;
        if (cellStyle == null)
          return 0;
        return cellStyle.MaxInputLength;
      }
      set
      {
        this.AdjustCellStyle().MaxInputLength=(value);
      }
    }

    [RefreshProperties(RefreshProperties.All)]
    // [DefaultValue]
    [Description("Determines whether iGrid forces drawing of cell contents in the viewport.")]
    [Category("Cell Appearance and Behavior")]
    public iGCellFitContentsInViewport FitContentsInViewport
    {
      get
      {
        iGCellStyle cellStyle = this.fPattern.CellStyle;
        if (cellStyle == null)
          return (iGCellFitContentsInViewport) 1;
        return cellStyle.FitContentsInViewport;
      }
      set
      {
        this.AdjustCellStyle().FitContentsInViewport=(value);
      }
    }
  }
}
