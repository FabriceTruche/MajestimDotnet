// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGStyleBase
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  /// <summary>The base class that defines the appearance and behavior of a cell or column header.</summary>
  [DesignerSerializer("TenTec.Windows.iGridLib.Design.iGStyleSerializer, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design")]
  public abstract class iGStyleBase : Component
  {
    /// <summary>The default background color for the styles.</summary>
    public static readonly Color ConstDefaultBackColor = Color.Empty;
    /// <summary>The default foreground color for the styles.</summary>
    public static readonly Color ConstDefaultForeColor = Color.Empty;
    /// <summary>The default indent for the styles.</summary>
    public static readonly iGIndent ConstDefaultIndent = iGIndent.NotSet;
    internal static readonly Color cSuperBackColor = Color.Empty;
    internal static readonly Color cSuperForeColor = Color.Empty;
    internal static readonly iGIndent cSuperIndent = new iGIndent(1, 1, 1, 1);
    internal const iGCellDrawType cDefaultDrawType = iGCellDrawType.NotSet;
    internal const iGCellDrawTypeFlags cDefaultDrawTypeFlags = iGCellDrawTypeFlags.NotSet;
    internal const iGCellDrawFlags cDefaultDrawFlags = iGCellDrawFlags.NotSet;
    /// <summary>The default font for the styles.</summary>
    public const Font ConstDefaultFont = null;
    /// <summary>The default image alignment for the styles.</summary>
    public const iGContentAlignment ConstDefaultImageAlign = iGContentAlignment.NotSet;
    /// <summary>The default position of the cell text against to the cell image alignment for the styles.</summary>
    public const iGTextPosToImage ConstDefaultTextPosToImage = iGTextPosToImage.NotSet;
    /// <summary>The default set of custom drawing flags for the styles.</summary>
    public const iGCustomDrawFlags ConstDefaultCustomDrawFlags = iGCustomDrawFlags.NotSet;
    /// <summary>The default format string for the styles.</summary>
    public const string ConstDefaultFormatString = null;
    /// <summary>The default format provider for the styles.</summary>
    public const IFormatProvider ConstDefaultFormatProvider = null;
    /// <summary>The default text alignment for the styles.</summary>
    public const iGContentAlignment ConstDefaultTextAlign = iGContentAlignment.NotSet;
    /// <summary>The default text format flags for the styles.</summary>
    public const iGStringFormatFlags ConstDefaultTextFormatFlags = iGStringFormatFlags.NotSet;
    /// <summary>The default text trimming option for the styles.</summary>
    public const iGStringTrimming ConstDefaultTextTrimming = iGStringTrimming.NotSet;
    /// <summary>The default image list for the styles.</summary>
    public const ImageList ConstDefaultImageList = null;
    internal const bool cDefaultNotSetTextAlignment = true;
    /// <summary>The default value for the <see cref="P:TenTec.Windows.iGridLib.iGStyleBase.DropDownControl" /> property.</summary>
    public const IiGDropDownControl ConstDefaultDropDownControl = null;
    internal const iGCellDrawType cSuperDrawType = iGCellDrawType.Text;
    internal const iGCellDrawTypeFlags cSuperDrawTypeFlags = iGCellDrawTypeFlags.None;
    internal const iGCellDrawFlags cSuperDrawFlags = iGCellDrawFlags.DisplayText | iGCellDrawFlags.DisplayImage;
    internal const Font cSuperFont = null;
    internal const iGContentAlignment cSuperImageAlign = iGContentAlignment.TopLeft;
    internal const iGTextPosToImage cSuperTextPosToImage = iGTextPosToImage.Horizontally;
    internal const iGCustomDrawFlags cSuperCustomDrawFlags = iGCustomDrawFlags.None;
    internal const string cSuperFormatString = null;
    internal const IFormatProvider cSuperFormatProvider = null;
    internal const iGStringFormatFlags cSuperTextFormatFlags = iGStringFormatFlags.None;
    internal const iGStringTrimming cSuperTextTrimming = iGStringTrimming.EllipsisCharacter;
    internal const iGContentAlignment cSuperTextAlign = iGContentAlignment.TopLeft;
    internal const StringAlignment cSuperTextHAlign = StringAlignment.Near;
    internal const StringAlignment cSuperTextVAlign = StringAlignment.Near;
    internal const ImageList cSuperImageList = null;
    internal const bool cSuperNotSetTextAlignment = false;
    internal const IiGDropDownControl cSuperDropDownControl = null;
    internal Font fFont;
    internal bool fNotSetTextAlignment;
    internal StringAlignment fTextHAlign;
    internal StringAlignment fTextVAlign;
    internal iGStringTrimming fTextTrimming;
    internal iGStringFormatFlags fTextFormatFlags;
    internal Color fForeColor;
    internal Color fBackColor;
    internal iGContentAlignment fImageAlign;
    internal iGIndent fContentIndent;
    internal iGTextPosToImage fTextPosToImage;
    internal string fFormatString;
    internal IFormatProvider fFormatProvider;
    internal iGCustomDrawFlags fCustomDrawFlags;
    internal ImageList fImageList;
    internal IiGDropDownControl fDropDownControl;
    internal bool fAreSuperValuesDefault;

    internal abstract iGCellDrawType DrawType { get; }

    internal abstract iGCellDrawTypeFlags DrawTypeFlags { get; }

    internal abstract iGCellDrawFlags DrawFlags { get; }

    internal iGStyleBase(bool setPropsToNonTransparentValues)
    {
      if (setPropsToNonTransparentValues)
      {
        this.fFont = (Font) null;
        this.fForeColor = iGStyleBase.cSuperForeColor;
        this.fBackColor = iGStyleBase.cSuperBackColor;
        this.fContentIndent = iGStyleBase.cSuperIndent;
        this.fTextPosToImage = iGTextPosToImage.Horizontally;
        this.fImageAlign = iGContentAlignment.TopLeft;
        this.fFormatString = (string) null;
        this.fFormatProvider = (IFormatProvider) null;
        this.fNotSetTextAlignment = false;
        this.fCustomDrawFlags = iGCustomDrawFlags.None;
        this.fTextTrimming = iGStringTrimming.EllipsisCharacter;
        this.fTextFormatFlags = iGStringFormatFlags.None;
        this.fImageList = (ImageList) null;
        this.fDropDownControl = (IiGDropDownControl) null;
      }
      else
      {
        this.fFont = (Font) null;
        this.fForeColor = iGStyleBase.ConstDefaultForeColor;
        this.fBackColor = iGStyleBase.ConstDefaultBackColor;
        this.fContentIndent = iGStyleBase.ConstDefaultIndent;
        this.fTextPosToImage = iGTextPosToImage.NotSet;
        this.fImageAlign = iGContentAlignment.NotSet;
        this.fFormatString = (string) null;
        this.fFormatProvider = (IFormatProvider) null;
        this.fNotSetTextAlignment = true;
        this.fCustomDrawFlags = iGCustomDrawFlags.NotSet;
        this.fTextTrimming = iGStringTrimming.NotSet;
        this.fTextFormatFlags = iGStringFormatFlags.NotSet;
        this.fImageList = (ImageList) null;
        this.fDropDownControl = (IiGDropDownControl) null;
      }
      this.fAreSuperValuesDefault = setPropsToNonTransparentValues;
    }

    internal void DesignTimeInvalidate()
    {
      if (!this.DesignMode)
        return;
      IReferenceService service = (IReferenceService) this.GetService(typeof (IReferenceService));
      if (service == null)
        return;
      object[] references = service.GetReferences(typeof (iGrid));
      if (references == null)
        return;
      foreach (iGrid iGrid in references)
      {
        if (iGrid != null)
          iGrid.Invalidate(false);
      }
    }

    internal IiGDropDownControl GetDropDownControl()
    {
      return this.DropDownControl;
    }

    /// <summary>Allows to copy the property values from the specified style into this object.</summary>
    /// <param name="fromStyle">A <see cref="T:TenTec.Windows.iGridLib.iGStyleBase" /> object to copy the property values from.</param>
    public virtual void CloneProperties(iGStyleBase fromStyle)
    {
      this.fBackColor = fromStyle.fBackColor;
      if (fromStyle.fFont != null)
        this.fFont = (Font) fromStyle.fFont.Clone();
      this.fForeColor = fromStyle.fForeColor;
      this.fImageAlign = fromStyle.fImageAlign;
      this.fContentIndent = fromStyle.fContentIndent;
      this.fTextPosToImage = fromStyle.fTextPosToImage;
      this.fTextFormatFlags = fromStyle.fTextFormatFlags;
      this.fTextVAlign = fromStyle.fTextVAlign;
      this.fTextHAlign = fromStyle.fTextHAlign;
      this.fTextTrimming = fromStyle.fTextTrimming;
      this.fNotSetTextAlignment = fromStyle.fNotSetTextAlignment;
      this.fFormatString = fromStyle.fFormatString;
      this.fFormatProvider = fromStyle.fFormatProvider;
      this.fCustomDrawFlags = fromStyle.fCustomDrawFlags;
      this.fImageList = fromStyle.fImageList;
      this.fDropDownControl = fromStyle.fDropDownControl;
      this.fAreSuperValuesDefault = fromStyle.fAreSuperValuesDefault;
    }

    private iGStringFormatFlags FlagsEnumDefaultValueTextFormatFlags()
    {
      return this.fAreSuperValuesDefault ? iGStringFormatFlags.None : iGStringFormatFlags.NotSet;
    }

    private iGCustomDrawFlags FlagsEnumDefaultValueCustomDrawFlags()
    {
      return this.fAreSuperValuesDefault ? iGCustomDrawFlags.None : iGCustomDrawFlags.NotSet;
    }

    private bool ShouldSerializeDropDownControl()
    {
      int num = this.fAreSuperValuesDefault ? 1 : 0;
      return this.fDropDownControl != null;
    }

    internal static bool ShouldSerializeIndent(iGIndent value, iGIndent defaultValue)
    {
      return !value.EqualsTo(defaultValue);
    }

    private bool ShouldSerializeFont()
    {
      int num = this.fAreSuperValuesDefault ? 1 : 0;
      return this.fFont != null;
    }

    private bool ShouldSerializeForeColor()
    {
      if (this.fAreSuperValuesDefault)
        return this.fForeColor != iGStyleBase.cSuperForeColor;
      return this.fForeColor != iGStyleBase.ConstDefaultForeColor;
    }

    private bool ShouldSerializeBackColor()
    {
      if (this.fAreSuperValuesDefault)
        return this.fBackColor != iGStyleBase.cSuperBackColor;
      return this.fBackColor != iGStyleBase.ConstDefaultBackColor;
    }

    private bool ShouldSerializeImageAlign()
    {
      if (this.fAreSuperValuesDefault)
        return this.fImageAlign != iGContentAlignment.TopLeft;
      return (uint) this.fImageAlign > 0U;
    }

    private bool ShouldSerializeContentIndent()
    {
      if (this.fAreSuperValuesDefault)
        return iGStyleBase.ShouldSerializeIndent(this.fContentIndent, iGStyleBase.cSuperIndent);
      return iGStyleBase.ShouldSerializeIndent(this.fContentIndent, iGStyleBase.ConstDefaultIndent);
    }

    private bool ShouldSerializeTextPosToImage()
    {
      if (this.fAreSuperValuesDefault)
        return (uint) this.fTextPosToImage > 0U;
      return this.fTextPosToImage != iGTextPosToImage.NotSet;
    }

    private bool ShouldSerializeTextAlign()
    {
      if (this.fAreSuperValuesDefault)
        return this.TextAlign != iGContentAlignment.TopLeft;
      return (uint) this.TextAlign > 0U;
    }

    private bool ShouldSerializeTextFormatFlags()
    {
      if (this.fAreSuperValuesDefault)
        return (uint) this.fTextFormatFlags > 0U;
      return this.fTextFormatFlags != iGStringFormatFlags.NotSet;
    }

    private bool ShouldSerializeTextTrimming()
    {
      if (this.fAreSuperValuesDefault)
        return this.fTextTrimming != iGStringTrimming.EllipsisCharacter;
      return this.fTextTrimming != iGStringTrimming.NotSet;
    }

    private bool ShouldSerializeFormatString()
    {
      int num = this.fAreSuperValuesDefault ? 1 : 0;
      return this.fFormatString != null;
    }

    private bool ShouldSerializeCustomDrawFlags()
    {
      if (this.fAreSuperValuesDefault)
        return (uint) this.fCustomDrawFlags > 0U;
      return this.fCustomDrawFlags != iGCustomDrawFlags.NotSet;
    }

    private bool ShouldSerializeImageList()
    {
      int num = this.fAreSuperValuesDefault ? 1 : 0;
      return this.fImageList != null;
    }

    private void ResetDropDownControl()
    {
      if (this.fAreSuperValuesDefault)
        this.DropDownControl = (IiGDropDownControl) null;
      else
        this.DropDownControl = (IiGDropDownControl) null;
    }

    private void ResetFont()
    {
      if (this.fAreSuperValuesDefault)
        this.fFont = (Font) null;
      else
        this.fFont = (Font) null;
    }

    private void ResetForeColor()
    {
      if (this.fAreSuperValuesDefault)
        this.fForeColor = iGStyleBase.cSuperForeColor;
      else
        this.fForeColor = iGStyleBase.ConstDefaultForeColor;
    }

    private void ResetBackColor()
    {
      if (this.fAreSuperValuesDefault)
        this.fBackColor = iGStyleBase.cSuperBackColor;
      else
        this.fBackColor = iGStyleBase.ConstDefaultBackColor;
    }

    private void ResetImageAlign()
    {
      if (this.fAreSuperValuesDefault)
        this.fImageAlign = iGContentAlignment.TopLeft;
      else
        this.fImageAlign = iGContentAlignment.NotSet;
    }

    private void ResetContentIndent()
    {
      if (this.fAreSuperValuesDefault)
        this.fContentIndent = iGStyleBase.cSuperIndent;
      else
        this.fContentIndent = iGStyleBase.ConstDefaultIndent;
    }

    private void ResetTextPosToImage()
    {
      if (this.fAreSuperValuesDefault)
        this.fTextPosToImage = iGTextPosToImage.Horizontally;
      else
        this.fTextPosToImage = iGTextPosToImage.NotSet;
    }

    private void ResetTextAlign()
    {
      if (this.fAreSuperValuesDefault)
        this.TextAlign = iGContentAlignment.TopLeft;
      else
        this.TextAlign = iGContentAlignment.NotSet;
    }

    private void ResetTextFormatFlags()
    {
      if (this.fAreSuperValuesDefault)
        this.fTextFormatFlags = iGStringFormatFlags.None;
      else
        this.fTextFormatFlags = iGStringFormatFlags.NotSet;
    }

    private void ResetTextTrimming()
    {
      if (this.fAreSuperValuesDefault)
        this.fTextTrimming = iGStringTrimming.EllipsisCharacter;
      else
        this.fTextTrimming = iGStringTrimming.NotSet;
    }

    private void ResetFormatString()
    {
      if (this.fAreSuperValuesDefault)
        this.fFormatString = (string) null;
      else
        this.fFormatString = (string) null;
    }

    private void ResetCustomDrawFlags()
    {
      if (this.fAreSuperValuesDefault)
        this.fCustomDrawFlags = iGCustomDrawFlags.None;
      else
        this.fCustomDrawFlags = iGCustomDrawFlags.NotSet;
    }

    private void ResetImageList()
    {
      if (this.fAreSuperValuesDefault)
        this.fImageList = (ImageList) null;
      else
        this.fImageList = (ImageList) null;
    }

    /// <summary>Gets or sets the control to show in the drop-down form when editing the object this property belongs to. This control is also used as the auto-complete control when editing the cell as text.</summary>
    /// <value>An instance of a class that implements the <see cref="T:TenTec.Windows.iGridLib.IiGDropDownControl" /> interface. The default value is null (Nothing in VB), that means that the property value should be obtained from a style up the hierarchy.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines the control to show in the drop down form when editing the cell.")]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGReferenceNullAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    public IiGDropDownControl DropDownControl
    {
      get
      {
        return this.fDropDownControl;
      }
      set
      {
        this.fDropDownControl = value;
      }
    }

    /// <summary>Gets or sets the font used to display the text in the object this property belongs to.</summary>
    /// <value>The <see cref="T:System.Drawing.Font" /> object to apply to the text displayed in the cell or column header. The default is null (Nothing in VB) that means that the font is obtained from a style up the hierarchy.</value>
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGFontNoneAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The font used to display the text in the cell or column header.")]
    public Font Font
    {
      get
      {
        return this.fFont;
      }
      set
      {
        this.fFont = value;
        this.DesignTimeInvalidate();
      }
    }

    /// <summary>Gets or sets the color of the text displayed in the object this property belongs to.</summary>
    /// <value>The foreground color of the cell or column header. The default is <see cref="F:System.Drawing.Color.Empty" /> which means that the property value is obtained from a style up the hierarchy.</value>
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGColorEmptyAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The color of the text displayed in the cell or column header.")]
    public Color ForeColor
    {
      get
      {
        return this.fForeColor;
      }
      set
      {
        this.fForeColor = value;
        this.DesignTimeInvalidate();
      }
    }

    /// <summary>Gets or sets the background color of the object this property belongs to.</summary>
    /// <value>A <see cref="T:System.Drawing.Color" /> object that represents the background color of the cell or column header, or <see cref="F:System.Drawing.Color.Empty" /> if the color is determined from a style up the hierarchy.</value>
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGColorEmptyAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The background color of the cell or column header.")]
    public Color BackColor
    {
      get
      {
        return this.fBackColor;
      }
      set
      {
        this.fBackColor = value;
        this.DesignTimeInvalidate();
      }
    }

    /// <summary>Gets or sets the horizontal and vertical alignment of the image displayed in the object this property belongs to.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGContentAlignment" /> enumeration value that specifies where to place the image. The default value is <see cref="F:TenTec.Windows.iGridLib.iGContentAlignment.NotSet" /> which means that the image alignment is obtained from a style up the hierarchy.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The horizontal and vertical alignment of the image displayed in the cell or column header.")]
    public iGContentAlignment ImageAlign
    {
      get
      {
        return this.fImageAlign;
      }
      set
      {
        this.fImageAlign = value;
        this.DesignTimeInvalidate();
      }
    }

    /// <summary>Gets or sets a value indicating the left, top, right, and bottom indents for the contents of the object this property belongs to.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGIndent" /> object that specifies the left, right, top and bottom indents. The default is the <see cref="P:TenTec.Windows.iGridLib.iGIndent.NotSet" /> value which means that the value of the property is got from a style up the hierarchy</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines the indents of the cell or column header contents.")]
    public iGIndent ContentIndent
    {
      get
      {
        return this.fContentIndent;
      }
      set
      {
        this.fContentIndent = value;
        this.DesignTimeInvalidate();
      }
    }

    /// <summary>Gets or sets the relative position of the image and text displayed in the object this property belongs to.</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGTextPosToImage" /> enumeration values. The default value is <see cref="F:TenTec.Windows.iGridLib.iGTextPosToImage.NotSet" /> which means that the property value is obtained from a style up the hierarchy.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The relative position of the image and text displayed in the cell or column header.")]
    public iGTextPosToImage TextPosToImage
    {
      get
      {
        return this.fTextPosToImage;
      }
      set
      {
        this.fTextPosToImage = value;
        this.DesignTimeInvalidate();
      }
    }

    /// <summary>Gets or sets the horizontal and vertical alignment of the text displayed in the object this property belongs to.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGContentAlignment" /> enumeration value that specifies where to place the text. The default value is <see cref="F:TenTec.Windows.iGridLib.iGContentAlignment.NotSet" /> which means that the text alignment is obtained from a style up the hierarchy.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The horizontal and vertical alignment of the text displayed in the cell or column header.")]
    public iGContentAlignment TextAlign
    {
      get
      {
        if (this.fNotSetTextAlignment)
          return iGContentAlignment.NotSet;
        int num;
        switch (this.fTextHAlign)
        {
          case StringAlignment.Near:
            num = 1;
            break;
          case StringAlignment.Center:
            num = 2;
            break;
          default:
            num = 4;
            break;
        }
        switch (this.fTextVAlign)
        {
          case StringAlignment.Center:
            num <<= 4;
            break;
          case StringAlignment.Far:
            num <<= 8;
            break;
        }
        return (iGContentAlignment) num;
      }
      set
      {
        if (value == iGContentAlignment.NotSet)
        {
          this.fNotSetTextAlignment = true;
        }
        else
        {
          this.fNotSetTextAlignment = false;
          int num = (int) value;
          if (num > 64)
          {
            this.fTextVAlign = StringAlignment.Far;
            num >>= 8;
          }
          else if (num > 4)
          {
            this.fTextVAlign = StringAlignment.Center;
            num >>= 4;
          }
          else
            this.fTextVAlign = StringAlignment.Near;
          this.fTextHAlign = num != 1 ? (num != 2 ? StringAlignment.Far : StringAlignment.Center) : StringAlignment.Near;
          this.DesignTimeInvalidate();
        }
      }
    }

    /// <summary>Gets or sets the text format flags of the object this property belongs to (similar to the <see cref="T:System.Drawing.StringFormatFlags" /> enumeration in .NET Framework).</summary>
    /// <value>A bitwise combination of the <see cref="T:TenTec.Windows.iGridLib.iGStringFormatFlags" /> values. The default value is <see cref="F:TenTec.Windows.iGridLib.iGStringFormatFlags.NotSet" /> which means that the property value is obtained from a style up the hierarchy.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines the text format flags of the cell or column header(similar to the StringFormatFlags enumeration in .NET Framework).")]
    public iGStringFormatFlags TextFormatFlags
    {
      get
      {
        return this.fTextFormatFlags;
      }
      set
      {
        this.fTextFormatFlags = value;
        this.DesignTimeInvalidate();
      }
    }

    /// <summary>Gets or sets a value determining the trimming options of the text displayed in the object this property belongs to (similar to the <see cref="T:System.Drawing.StringTrimming" /> enumeration in .NET Framework).</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGStringTrimming" /> enumeration values. The default value is <see cref="F:TenTec.Windows.iGridLib.iGStringTrimming.NotSet" /> which means that the property value is obtained from a style up the hierarchy.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines the trimming options of the text dispalyed in the cell or column header (similar to the StringTrimming enumeration in .NET Framework).")]
    public iGStringTrimming TextTrimming
    {
      get
      {
        return this.fTextTrimming;
      }
      set
      {
        this.fTextTrimming = value;
        this.DesignTimeInvalidate();
      }
    }

    /// <summary>Gets or sets the format string applied to the value of the object this property belongs to before the value is displayed (similar to the format string parameter in the <see cref="T:System.String" />.<see cref="M:System.String.Format(System.IFormatProvider,System.String,System.Object[])" /> method).</summary>
    /// <value>The <see cref="T:System.String" /> that is used as the format string to get the text displayed in the cell or column header. The default value is null (Nothing in VB) that means that the format string is obtained from a style up the hierarchy.</value>
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGStringNoneAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines the format string applied to the cell or column header value before it is displayed (similar to the format string parameter in the String.Format method).")]
    public string FormatString
    {
      get
      {
        return this.fFormatString;
      }
      set
      {
        if (value != null)
          value = value.Trim();
        this.fFormatString = value;
        this.DesignTimeInvalidate();
      }
    }

    /// <summary>Gets or sets a format provider used to get the string representation of the value of the object this property belongs to (similar to the format provider in the <see cref="T:System.String" />.<see cref="M:System.String.Format(System.String,System.Object[])" /> method).</summary>
    /// <value>The <see cref="T:System.IFormatProvider" /> object that is used to get the text displayed in the cell or column header. The default value is null (Nothing in VB) that means that the format provider is obtained from a style up the hierarchy.</value>
    [Browsable(false)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IFormatProvider FormatProvider
    {
      get
      {
        return this.fFormatProvider;
      }
      set
      {
        this.fFormatProvider = value;
        this.DesignTimeInvalidate();
      }
    }

    /// <summary>Gets or sets a value determining which parts of the object this property belongs to are custom drawn.</summary>
    /// <value>A bitwise combination of the <see cref="T:TenTec.Windows.iGridLib.iGCustomDrawFlags" /> values. The default value is <see cref="F:TenTec.Windows.iGridLib.iGCustomDrawFlags.NotSet" /> which means that the property value is got from a style up the hierarchy.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines which of the cell's parts are custom drawn.")]
    public iGCustomDrawFlags CustomDrawFlags
    {
      get
      {
        return this.fCustomDrawFlags;
      }
      set
      {
        this.fCustomDrawFlags = value;
        this.DesignTimeInvalidate();
      }
    }

    /// <summary>Gets or sets the image list that contains the images to display in the object this property belongs to.</summary>
    /// <value>An <see cref="T:System.Windows.Forms.ImageList" /> object that is used to draw the image in the cell or column header. The default value is null (Nothing in VB) which means that the image list is obtained from a style up the hierarchy.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The image list that contains the images to display in the cell or column header.")]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGReferenceNullAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    public ImageList ImageList
    {
      get
      {
        return this.fImageList;
      }
      set
      {
        this.fImageList = value;
        this.DesignTimeInvalidate();
      }
    }
  }
}
