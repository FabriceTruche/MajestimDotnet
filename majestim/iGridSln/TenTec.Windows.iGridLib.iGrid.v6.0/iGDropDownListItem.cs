// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGDropDownListItem
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
  /// <summary>Represents an item in an <see cref="T:TenTec.Windows.iGridLib.iGDropDownList" /> object.</summary>
  [TypeConverter("TenTec.Windows.iGridLib.Design.iGDropDownListItemConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
  public class iGDropDownListItem : IiGImageListProvider, IComparable
  {
    private bool fSelectable = true;
    private Color fBackColor = iGStyleBase.ConstDefaultBackColor;
    private Color fForeColor = iGStyleBase.ConstDefaultForeColor;
    private int fImageIndex = -1;
    private bool fVisible = true;
    private const bool cDefaultSelectable = true;
    private object fValue;
    private string fText;
    internal iGDropDownList fDropDownList;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGDropDownListItem" /> class.</summary>
    public iGDropDownListItem()
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGDropDownListItem" /> class with the specified value.</summary>
    /// <param name="value">The value that is set to a cell when the item in the drop-down list is selected. If the <see cref="P:TenTec.Windows.iGridLib.iGDropDownListItem.Text" /> property of the item is null (Nothing in VB), this property is used to display the text in the drop-down list.</param>
    public iGDropDownListItem(object value)
    {
      this.fValue = value;
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGDropDownListItem" /> class with the specified value and image index.</summary>
    /// <param name="value">The value that is set to a cell when the item in the drop-down list is selected. If the <see cref="P:TenTec.Windows.iGridLib.iGDropDownListItem.Text" /> property of the item is null (Nothing in VB), this property is used to display the text in the drop-down list.</param>
    /// <param name="imageIndex">The index of the image displayed in the new drop-down list item and in the cells, to which this item is attached.</param>
    public iGDropDownListItem(object value, int imageIndex)
    {
      this.fValue = value;
      this.fImageIndex = imageIndex;
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGDropDownListItem" /> class with the specified value and text.</summary>
    /// <param name="value">The value that is set to a cell when the item in the drop-down list is selected. If the <see cref="P:TenTec.Windows.iGridLib.iGDropDownListItem.Text" /> property of the item is null (Nothing in VB), this property is used to display the text in the drop-down list.</param>
    /// <param name="text">The text displayed in the drop-down list item. This property is also used to display the text in cells to which this drop-down list item is attached.</param>
    public iGDropDownListItem(object value, string text)
    {
      this.fValue = value;
      this.fText = text;
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGDropDownListItem" /> class with the specified value, text, and image index.</summary>
    /// <param name="value">The value that is set to a cell when the item in the drop-down list is selected. If the <see cref="P:TenTec.Windows.iGridLib.iGDropDownListItem.Text" /> property of the item is null (Nothing in VB), this property is used to display the text in the drop-down list.</param>
    /// <param name="text">The text displayed in the drop-down list item. This property is also used to display the text in cells to which this drop-down list item is attached.</param>
    /// <param name="imageIndex">The index of the image displayed in the new drop-down list item and in the cells, to which this item is attached.</param>
    public iGDropDownListItem(object value, string text, int imageIndex)
    {
      this.fValue = value;
      this.fImageIndex = imageIndex;
      this.fText = text;
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGDropDownListItem" /> class with the specified value, text, image index, and visibility.</summary>
    /// <param name="value">The value that is set to a cell when the item in the drop-down list is selected. If the <see cref="P:TenTec.Windows.iGridLib.iGDropDownListItem.Text" /> property of the item is null (Nothing in VB), this property is used to display the text in the drop-down list.</param>
    /// <param name="text">The text displayed in the drop-down list item. This property is also used to display the text in cells to which this drop-down list item is attached.</param>
    /// <param name="imageIndex">The index of the image displayed in the new drop-down list item and in the cells, to which this item is attached.</param>
    /// <param name="visible">Specifies whether the new drop-down list item is visible in the drop-down list.</param>
    public iGDropDownListItem(object value, string text, int imageIndex, bool visible)
    {
      this.fValue = value;
      this.fImageIndex = imageIndex;
      this.fText = text;
      this.fVisible = visible;
    }

    /// <summary>This member overrides <see cref="T:System.Object" />.<see cref="M:System.Object.ToString" />.</summary>
    /// <returns>A string representation of the drop-down list item.</returns>
    public override string ToString()
    {
      if (this.fText != null)
        return this.fText;
      if (this.fValue != null)
        return this.fValue.ToString();
      return string.Empty;
    }

    private bool ShouldSerializeBackColor()
    {
      return this.BackColor != iGStyleBase.ConstDefaultBackColor;
    }

    private void ResetBackColor()
    {
      this.BackColor = iGStyleBase.ConstDefaultBackColor;
    }

    private bool ShouldSerializeForeColor()
    {
      return this.ForeColor != iGStyleBase.ConstDefaultForeColor;
    }

    private void ResetForeColor()
    {
      this.ForeColor = iGStyleBase.ConstDefaultForeColor;
    }

    /// <summary>Gets or sets the value that is set to a cell when an item in the drop-down list is selected. If the <see cref="P:TenTec.Windows.iGridLib.iGDropDownListItem.Text" /> property of the item is null (Nothing in VB), this property is used to display the text in the drop-down list.</summary>
    /// <value>An object of any type.</value>
    [DefaultValue(null)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGStringConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Description("Determines the value that is set to a cell when the item in the drop down list is selected. If the DisplayValue property of the item is null (Nothing in VB), this property is used to display the text in the drop down list.")]
    public object Value
    {
      get
      {
        return this.fValue;
      }
      set
      {
        this.fValue = value;
        if (this.fDropDownList == null)
          return;
        this.fDropDownList.OnItemValueChanged(this);
      }
    }

    /// <summary>Gets or sets the text displayed in the drop-down list item. This property is also used to display the text in cells to which this drop-down list item is attached.</summary>
    /// <value>A string. The default is null (Nothing in VB).</value>
    [DefaultValue(null)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGStringConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Description("Determines the value used to display the text in the drop down list and in the cells, which Value property equals to the item's Value property.")]
    public string Text
    {
      get
      {
        return this.fText;
      }
      set
      {
        if (this.fText == value)
          return;
        this.fText = value;
        if (this.fDropDownList == null)
          return;
        this.fDropDownList.OnItemTextChanged(this);
      }
    }

    /// <summary>Gets or sets the index of the image displayed in the drop-down list item. Also, the value of this property is saved to a cell's <see cref="P:TenTec.Windows.iGridLib.iGCell.ImageIndex" /> property when the drop-down list item is selected by the user.</summary>
    /// <value>A zero-based index value that represents the image position in the image list assigned to the <see cref="P:TenTec.Windows.iGridLib.iGDropDownList.ImageList" /> property of the drop-down list or in the image list used to display the image in the edited cell. The default is -1.</value>
    [DefaultValue(-1)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGImageIndexConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Editor("TenTec.Windows.iGridLib.Design.iGImageIndexEditor, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0", typeof (UITypeEditor))]
    [Description("Determines the index of the image displayed in the drop down list and in the cells, which Value property is equal to the item's Value property.")]
    public int ImageIndex
    {
      get
      {
        return this.fImageIndex;
      }
      set
      {
        this.fImageIndex = value;
        if (this.fDropDownList == null)
          return;
        this.fDropDownList.OnItemPropertyChanged(this);
      }
    }

    /// <summary>Get or sets a value that determines whether the drop-down list item is visible.</summary>
    /// <value>True if the item is visible; otherwise, False. The default is True.</value>
    [DefaultValue(true)]
    [Description("Determines whether the item is visible.")]
    public bool Visible
    {
      get
      {
        return this.fVisible;
      }
      set
      {
        this.fVisible = value;
      }
    }

    /// <summary>Gets or sets the foreground color of the drop-down list item.</summary>
    /// <value>Gets or sets the foreground color of the drop-down list item. The default value is <see cref="F:System.Drawing.Color.Empty" /> (i.e. not set).</value>
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGColorEmptyAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Description("Determines the foreground color of the item.")]
    public Color ForeColor
    {
      get
      {
        return this.fForeColor;
      }
      set
      {
        this.fForeColor = value;
        if (this.fDropDownList == null)
          return;
        this.fDropDownList.OnItemPropertyChanged(this);
      }
    }

    /// <summary>Gets or sets the background color of the drop-down list item.</summary>
    /// <value>Gets or sets the background color of the drop-down list item. The default value is <see cref="F:System.Drawing.Color.Empty" /> (i.e. not set).</value>
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGColorEmptyAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Description("Determines the background color of the item.")]
    public Color BackColor
    {
      get
      {
        return this.fBackColor;
      }
      set
      {
        this.fBackColor = value;
        if (this.fDropDownList == null)
          return;
        this.fDropDownList.OnItemPropertyChanged(this);
      }
    }

    /// <summary>Gets or sets a value indicating whether the drop-down list item can be selected with the mouse and/or keyboard.</summary>
    /// <value>True if the cell can be selected; otherwise, False. The default value is True.</value>
    [DefaultValue(true)]
    [Description("Determines whether the item can be selected.")]
    public bool Selectable
    {
      get
      {
        return this.fSelectable;
      }
      set
      {
        this.fSelectable = value;
        if (this.fDropDownList == null)
          return;
        this.fDropDownList.OnItemPropertyChanged(this);
      }
    }

    ImageList IiGImageListProvider.GetImageList(string propertyName)
    {
      if (this.fDropDownList == null)
        return (ImageList) null;
      return this.fDropDownList.ImageList;
    }

    int IComparable.CompareTo(object obj)
    {
      iGDropDownListItem gdropDownListItem = obj as iGDropDownListItem;
      if (gdropDownListItem == null)
        return 1;
      string fValue1 = gdropDownListItem.fValue as string;
      string fValue2 = this.fValue as string;
      if (fValue1 != null && fValue2 != null)
        return string.Compare(fValue2, fValue1, false);
      return iGManagerCompare.CompareObjects(this.fValue, gdropDownListItem.fValue);
    }
  }
}
