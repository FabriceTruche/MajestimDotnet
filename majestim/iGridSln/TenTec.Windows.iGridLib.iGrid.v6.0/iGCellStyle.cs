// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCellStyle
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.ComponentModel;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Defines the appearance and behavior of a cell.</summary>
  [TypeConverter("TenTec.Windows.iGridLib.Design.iGCellStyleConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
  [DesignTimeVisible(false)]
  [ToolboxItem(false)]
  public class iGCellStyle : iGStyleBase, ICloneable
  {
    /// <summary>The default value for the <see cref="P:TenTec.Windows.iGridLib.iGCellStyle.Type" /> property.</summary>
    public const iGCellType ConstDefaultType = iGCellType.NotSet;
    /// <summary>The default value for the <see cref="P:TenTec.Windows.iGridLib.iGCellStyle.Enabled" /> property.</summary>
    public const iGBool ConstDefaultEnabled = iGBool.NotSet;
    /// <summary>The default value for the <see cref="P:TenTec.Windows.iGridLib.iGCellStyle.Selectable" /> property.</summary>
    public const iGBool ConstDefaultSelectable = iGBool.NotSet;
    /// <summary>The default value for the <see cref="P:TenTec.Windows.iGridLib.iGCellStyle.TypeFlags" /> property.</summary>
    public const iGCellTypeFlags ConstDefaultTypeFlags = iGCellTypeFlags.NotSet;
    /// <summary>The default value for the <see cref="P:TenTec.Windows.iGridLib.iGCellStyle.ReadOnly" /> property.</summary>
    public const iGBool ConstDefaultReadOnly = iGBool.NotSet;
    /// <summary>The default value for the <see cref="P:TenTec.Windows.iGridLib.iGCellStyle.SingleClickEdit" /> property.</summary>
    public const iGBool ConstDefaultSingleClickEdit = iGBool.NotSet;
    /// <summary>The default value for the <see cref="P:TenTec.Windows.iGridLib.iGCellStyle.ValueType" /> property.</summary>
    public const System.Type ConstDefaultValueType = null;
    /// <summary>The default value for the <see cref="P:TenTec.Windows.iGridLib.iGCellStyle.EmptyStringAs" /> property.</summary>
    public const iGEmptyStringAs ConstDefaultEmptyStringAs = iGEmptyStringAs.NotSet;
    /// <summary>The default value for the <see cref="P:TenTec.Windows.iGridLib.iGCellStyle.Flags" /> property.</summary>
    public const iGCellFlags ConstDefaultFlags = iGCellFlags.NotSet;
    /// <summary>The default value for the <see cref="P:TenTec.Windows.iGridLib.iGCellStyle.CustomEditor" /> property.</summary>
    public const iGCellEditorBase ConstDefaultCustomEditor = null;
    /// <summary>The default value for the <see cref="P:TenTec.Windows.iGridLib.iGCellStyle.MaxInputLength" /> property.</summary>
    public const int ConstDefaultMaxInputLength = 0;
    /// <summary>The default value for the <see cref="P:TenTec.Windows.iGridLib.iGCellStyle.FitContentsInViewport" /> property.</summary>
    public const iGCellFitContentsInViewport ConstDefaultFitContentsInViewport = iGCellFitContentsInViewport.NotSet;
    internal const iGCellType cSuperType = iGCellType.Text;
    internal const iGBool cSuperEnabled = iGBool.True;
    internal const iGBool cSuperSelectable = iGBool.True;
    internal const iGCellTypeFlags cSuperTypeFlags = iGCellTypeFlags.None;
    internal const iGBool cSuperReadOnly = iGBool.False;
    internal const iGBool cSuperSingleClickEdit = iGBool.NotSet;
    internal const System.Type cSuperValueType = null;
    internal const iGEmptyStringAs cSuperEmptyStringAs = iGEmptyStringAs.Null;
    internal const iGCellFlags cSuperFlags = iGCellFlags.DisplayText | iGCellFlags.DisplayImage;
    internal const iGCellEditorBase cSuperCustomEditor = null;
    internal const int cSuperMaxInputLength = 0;
    internal const iGCellFitContentsInViewport cSuperFitContentsInViewport = iGCellFitContentsInViewport.None;
    internal iGCellType fType;
    internal iGBool fEnabled;
    internal iGBool fSelectable;
    internal iGCellTypeFlags fTypeFlags;
    internal iGBool fReadOnly;
    internal iGBool fSingleClickEdit;
    internal System.Type fValueType;
    internal iGEmptyStringAs fEmptyStringAs;
    internal iGCellFlags fFlags;
    internal iGCellEditorBase fCustomEditor;
    internal int fMaxInputLength;
    internal iGCellFitContentsInViewport fFitContentsInViewport;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCellStyle" /> class.</summary>
    public iGCellStyle()
      : this(false)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCellStyle" /> class with all the properties set either to the 'NotSet' (transparent) values or to the definite default values.</summary>
    /// <param name="setPropsToNonTransparentValues">If True, all the properties will be set to the definite default values; otherwise, all the properties will be set to the 'NotSet' (transparent) values.</param>
    public iGCellStyle(bool setPropsToNonTransparentValues)
      : base(setPropsToNonTransparentValues)
    {
      if (setPropsToNonTransparentValues)
      {
        this.fType = iGCellType.Text;
        this.fEnabled = iGBool.True;
        this.fReadOnly = iGBool.False;
        this.fSelectable = iGBool.True;
        this.fTypeFlags = iGCellTypeFlags.None;
        this.fSingleClickEdit = iGBool.NotSet;
        this.fValueType = (System.Type) null;
        this.fEmptyStringAs = iGEmptyStringAs.Null;
        this.fFlags = iGCellFlags.DisplayText | iGCellFlags.DisplayImage;
        this.fCustomEditor = (iGCellEditorBase) null;
        this.fMaxInputLength = 0;
        this.fFitContentsInViewport = iGCellFitContentsInViewport.None;
      }
      else
      {
        this.fType = iGCellType.NotSet;
        this.fEnabled = iGBool.NotSet;
        this.fReadOnly = iGBool.NotSet;
        this.fSelectable = iGBool.NotSet;
        this.fTypeFlags = iGCellTypeFlags.NotSet;
        this.fSingleClickEdit = iGBool.NotSet;
        this.fValueType = (System.Type) null;
        this.fEmptyStringAs = iGEmptyStringAs.NotSet;
        this.fFlags = iGCellFlags.NotSet;
        this.fCustomEditor = (iGCellEditorBase) null;
        this.fMaxInputLength = 0;
        this.fFitContentsInViewport = iGCellFitContentsInViewport.NotSet;
      }
    }

    /// <summary>Creates an exact copy of this <see cref="T:TenTec.Windows.iGridLib.iGCellStyle" /> object.</summary>
    /// <returns>The exact copy of this object.</returns>
    public iGCellStyle Clone()
    {
      iGCellStyle iGcellStyle = new iGCellStyle();
      iGcellStyle.CloneProperties((iGStyleBase) this);
      return iGcellStyle;
    }

    private void CloneOwnProperties(iGCellStyle fromStyle)
    {
      this.fType = fromStyle.fType;
      this.fEnabled = fromStyle.fEnabled;
      this.fReadOnly = fromStyle.fReadOnly;
      this.fSelectable = fromStyle.fSelectable;
      this.fTypeFlags = fromStyle.fTypeFlags;
      this.fSingleClickEdit = fromStyle.fSingleClickEdit;
      this.fValueType = fromStyle.fValueType;
      this.fEmptyStringAs = fromStyle.fEmptyStringAs;
      this.fFlags = fromStyle.fFlags;
      this.fCustomEditor = fromStyle.fCustomEditor;
      this.fMaxInputLength = fromStyle.fMaxInputLength;
      this.fFitContentsInViewport = fromStyle.fFitContentsInViewport;
    }

    /// <summary>Copies the properties from the specified cell style object into this object.</summary>
    /// <param name="fromStyle">The <see cref="T:TenTec.Windows.iGridLib.iGStyleBase" /> object to copy the properties from.</param>
    public override void CloneProperties(iGStyleBase fromStyle)
    {
      this.CloneOwnProperties((iGCellStyle) fromStyle);
      base.CloneProperties(fromStyle);
    }

    internal bool EqualsTo(iGCellStyle style)
    {
      if (this.BackColor == style.BackColor && (this.ContentIndent.EqualsTo(style.ContentIndent) && this.CustomDrawFlags == style.CustomDrawFlags && (this.Enabled == style.Enabled && this.ReadOnly == style.ReadOnly) && (object.Equals((object) this.Font, (object) style.Font) && this.ForeColor == style.ForeColor && (this.FormatString == style.FormatString && this.ImageAlign == style.ImageAlign)) && (this.Selectable == style.Selectable && this.TextAlign == style.TextAlign && (this.TextFormatFlags == style.TextFormatFlags && this.TextPosToImage == style.TextPosToImage) && (this.TextTrimming == style.TextTrimming && this.Type == style.Type && (this.TypeFlags == style.TypeFlags && this.SingleClickEdit == style.SingleClickEdit))) && (this.DropDownControl == style.DropDownControl && this.ValueType == style.ValueType && (this.ImageList == style.ImageList && this.EmptyStringAs == style.EmptyStringAs) && (this.Flags == style.Flags && this.CustomEditor == style.CustomEditor && this.MaxInputLength == style.MaxInputLength))))
        return this.FitContentsInViewport == style.FitContentsInViewport;
      return false;
    }

    private bool ShouldSerializeSingleClickEdit()
    {
      int num = this.fAreSuperValuesDefault ? 1 : 0;
      return this.fSingleClickEdit != iGBool.NotSet;
    }

    private bool ShouldSerializeType()
    {
      if (this.fAreSuperValuesDefault)
        return this.fType != iGCellType.Text;
      return (uint) this.fType > 0U;
    }

    private bool ShouldSerializeTypeFlags()
    {
      if (this.fAreSuperValuesDefault)
        return (uint) this.fTypeFlags > 0U;
      return this.fTypeFlags != iGCellTypeFlags.NotSet;
    }

    private bool ShouldSerializeEnabled()
    {
      if (this.fAreSuperValuesDefault)
        return (uint) this.fEnabled > 0U;
      return this.fEnabled != iGBool.NotSet;
    }

    private bool ShouldSerializeReadOnly()
    {
      if (this.fAreSuperValuesDefault)
        return this.fReadOnly != iGBool.False;
      return this.fReadOnly != iGBool.NotSet;
    }

    private bool ShouldSerializeSelectable()
    {
      if (this.fAreSuperValuesDefault)
        return (uint) this.fSelectable > 0U;
      return this.fSelectable != iGBool.NotSet;
    }

    private bool ShouldSerializeValueType()
    {
      int num = this.fAreSuperValuesDefault ? 1 : 0;
      return this.fValueType != (System.Type) null;
    }

    private bool ShouldSerializeEmptyStringAs()
    {
      if (this.fAreSuperValuesDefault)
        return this.fEmptyStringAs != iGEmptyStringAs.Null;
      return (uint) this.fEmptyStringAs > 0U;
    }

    private bool ShouldSerializeFlags()
    {
      if (this.fAreSuperValuesDefault)
        return this.fFlags != (iGCellFlags.DisplayText | iGCellFlags.DisplayImage);
      return this.fFlags != iGCellFlags.NotSet;
    }

    private bool ShouldSerializeCustomEditor()
    {
      int num = this.fAreSuperValuesDefault ? 1 : 0;
      return this.fCustomEditor != null;
    }

    private bool ShouldSerializeMaxInputLength()
    {
      int num = this.fAreSuperValuesDefault ? 1 : 0;
      return (uint) this.fMaxInputLength > 0U;
    }

    private bool ShouldSerializeFitContentsInViewport()
    {
      if (this.fAreSuperValuesDefault)
        return (uint) this.fFitContentsInViewport > 0U;
      return this.fFitContentsInViewport != iGCellFitContentsInViewport.NotSet;
    }

    private void ResetType()
    {
      if (this.fAreSuperValuesDefault)
        this.Type = iGCellType.Text;
      else
        this.Type = iGCellType.NotSet;
    }

    private void ResetTypeFlags()
    {
      if (this.fAreSuperValuesDefault)
        this.TypeFlags = iGCellTypeFlags.None;
      else
        this.TypeFlags = iGCellTypeFlags.NotSet;
    }

    private void ResetEnabled()
    {
      if (this.fAreSuperValuesDefault)
        this.Enabled = iGBool.True;
      else
        this.Enabled = iGBool.NotSet;
    }

    private void ResetReadOnly()
    {
      if (this.fAreSuperValuesDefault)
        this.ReadOnly = iGBool.False;
      else
        this.ReadOnly = iGBool.NotSet;
    }

    private void ResetSelectable()
    {
      if (this.fAreSuperValuesDefault)
        this.Selectable = iGBool.True;
      else
        this.Selectable = iGBool.NotSet;
    }

    private void ResetSingleClickEdit()
    {
      if (this.fAreSuperValuesDefault)
        this.SingleClickEdit = iGBool.NotSet;
      else
        this.SingleClickEdit = iGBool.NotSet;
    }

    private void ResetValueType()
    {
      if (this.fAreSuperValuesDefault)
        this.ValueType = (System.Type) null;
      else
        this.ValueType = (System.Type) null;
    }

    private void ResetEmptyStringAs()
    {
      if (this.fAreSuperValuesDefault)
        this.EmptyStringAs = iGEmptyStringAs.Null;
      else
        this.EmptyStringAs = iGEmptyStringAs.NotSet;
    }

    private void ResetFlags()
    {
      if (this.fAreSuperValuesDefault)
        this.Flags = iGCellFlags.DisplayText | iGCellFlags.DisplayImage;
      else
        this.Flags = iGCellFlags.NotSet;
    }

    private void ResetCustomEditor()
    {
      if (this.fAreSuperValuesDefault)
        this.CustomEditor = (iGCellEditorBase) null;
      else
        this.CustomEditor = (iGCellEditorBase) null;
    }

    private void ResetMaxInputLength()
    {
      if (this.fAreSuperValuesDefault)
        this.MaxInputLength = 0;
      else
        this.MaxInputLength = 0;
    }

    private void ResetFitContentsInViewport()
    {
      if (this.fAreSuperValuesDefault)
        this.FitContentsInViewport = iGCellFitContentsInViewport.None;
      else
        this.FitContentsInViewport = iGCellFitContentsInViewport.NotSet;
    }

    /// <summary>Indicates whether iGrid must reallocate the cell contents to draw them in the viewport area.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGCellFitContentsInViewport" /> enumeration value that specifies whether to reallocate the cell contents vertically and/or horizontally to draw them in the grid viewport. The default value is <see cref="F:TenTec.Windows.iGridLib.iGCellFitContentsInViewport.NotSet" /> meaning that this setting is obtained from a style up the hierarchy.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines whether iGrid forces drawing of cell contents in the viewport.")]
    public iGCellFitContentsInViewport FitContentsInViewport
    {
      get
      {
        return this.fFitContentsInViewport;
      }
      set
      {
        this.fFitContentsInViewport = value;
        this.DesignTimeInvalidate();
      }
    }

    /// <summary>Gets or sets the object used as the custom cell editor.</summary>
    /// <value>An instance of the <see cref="T:TenTec.Windows.iGridLib.iGCellEditorBase" /> class used as the custom cell editor.</value>
    [Browsable(false)]
    public iGCellEditorBase CustomEditor
    {
      get
      {
        return this.fCustomEditor;
      }
      set
      {
        this.fCustomEditor = value;
      }
    }

    /// <summary>Gets or sets the maximum number of characters that can be entered into the cell.</summary>
    /// <value>The maximum number of characters that can be entered into a cell.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Gets or sets the maximum number of characters the user can type or paste into the cell while editing.")]
    public int MaxInputLength
    {
      get
      {
        return this.fMaxInputLength;
      }
      set
      {
        if (value < 0)
          throw new ArgumentOutOfRangeException();
        this.fMaxInputLength = value;
      }
    }

    /// <summary>Gets or sets the type of the value the text entered while editing should be converted to.</summary>
    /// <value>An instance of the <see cref="T:System.Type" /> class which specifies the type of the cell value. The default value is null (Nothing in VB), meaning that the property value should be obtained from a style up the hierarchy.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines the type of the value to convert the edited text to.")]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGValueTypeConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    public System.Type ValueType
    {
      get
      {
        return this.fValueType;
      }
      set
      {
        this.fValueType = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether a single mouse click puts any cell into edit mode. If False, only the current cell can be edited with a single mouse click; otherwise, the single click starts editing of the cell regardless of whether it was current or not.</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGBool" /> enumeration values. The default value is <see cref="F:TenTec.Windows.iGridLib.iGBool.NotSet" />, meaning that the property value should be obtained from a style up the hierarchy.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines whether the single mouse click starts editing a not current cell. If False, only the current cell can be edited with the single mouse click; otherwise, the single click on any of the cells starts its editing.")]
    public iGBool SingleClickEdit
    {
      get
      {
        return this.fSingleClickEdit;
      }
      set
      {
        this.fSingleClickEdit = value;
      }
    }

    /// <summary>Gets or sets the type of the cell (a text or check box cell).</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGCellType" /> enumeration values. The default value is <see cref="F:TenTec.Windows.iGridLib.iGCellType.NotSet" />, meaning that the property value should be obtained from a style up the hierarchy.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The type of the cell (a text box cell, a check box cell, etc).")]
    public iGCellType Type
    {
      get
      {
        return this.fType;
      }
      set
      {
        this.fType = value;
        this.DesignTimeInvalidate();
      }
    }

    internal override iGCellDrawType DrawType
    {
      get
      {
        return (iGCellDrawType) this.Type;
      }
    }

    /// <summary>Gets or sets the additional flags used to modify some aspects of the cell type.</summary>
    /// <value>A bitwise combination of the <see cref="T:TenTec.Windows.iGridLib.iGCellTypeFlags" /> values. The default value is <see cref="F:TenTec.Windows.iGridLib.iGCellTypeFlags.NotSet" />, meaning that the property value should be obtained from a style up the hierarchy.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The additional flags used to modify some aspects of the cell type.")]
    public iGCellTypeFlags TypeFlags
    {
      get
      {
        return this.fTypeFlags;
      }
      set
      {
        this.fTypeFlags = value;
        this.DesignTimeInvalidate();
      }
    }

    internal override iGCellDrawTypeFlags DrawTypeFlags
    {
      get
      {
        return (iGCellDrawTypeFlags) this.fTypeFlags;
      }
    }

    /// <summary>Gets or sets a value indicating whether the cell is enabled. The disabled cells cannot be edited and the <see cref="P:TenTec.Windows.iGridLib.iGrid.ForeColorDisabled" /> color is used to draw their text.</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGBool" /> enumeration values. The default value is <see cref="F:TenTec.Windows.iGridLib.iGBool.NotSet" />, meaning that the property value should be obtained from a style up the hierarchy.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines whether the cell is enabled. The disabled cells cannot be edited and the ForeColorDisabled color is used to draw their text.")]
    public iGBool Enabled
    {
      get
      {
        return this.fEnabled;
      }
      set
      {
        this.fEnabled = value;
        this.DesignTimeInvalidate();
      }
    }

    /// <summary>Gets or sets a value indicating whether the cell can be edited.</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGBool" /> enumeration values.The default value is <see cref="F:TenTec.Windows.iGridLib.iGBool.NotSet" />, meaning that the property value should be obtained from a style up the hierarchy.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines whether the cell value can be edited.")]
    public iGBool ReadOnly
    {
      get
      {
        return this.fReadOnly;
      }
      set
      {
        this.fReadOnly = value;
      }
    }

    /// <summary>Determines whether the cell can be selected with the mouse and/or keyboard.</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGBool" /> enumeration values. The default value is <see cref="F:TenTec.Windows.iGridLib.iGBool.NotSet" />, meaning that the property value should be obtained from a style up the hierarchy.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines whether the cell can be selected with the mouse and/or keyboard.")]
    public iGBool Selectable
    {
      get
      {
        return this.fSelectable;
      }
      set
      {
        this.fSelectable = value;
        this.DesignTimeInvalidate();
      }
    }

    /// <summary>Gets or sets a value indicating how to interpret an empty string entered in the text box while editing the cell.</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGEmptyStringAs" /> enumeration values. The default value is <see cref="F:TenTec.Windows.iGridLib.iGEmptyStringAs.NotSet" />, meaning that the property value should be obtained from a style up the hierarchy.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines how to interpret an empty string entered in the text box while editing the cell.")]
    public iGEmptyStringAs EmptyStringAs
    {
      get
      {
        return this.fEmptyStringAs;
      }
      set
      {
        this.fEmptyStringAs = value;
      }
    }

    /// <summary>Gets or sets flags that determine which parts of the cell's contents (image, text) are displayed.</summary>
    /// <value>A set of the <see cref="T:TenTec.Windows.iGridLib.iGCellFlags" /> enumeration values.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Additional flags used to specify some options of the cell.")]
    public iGCellFlags Flags
    {
      get
      {
        return this.fFlags;
      }
      set
      {
        this.fFlags = value;
        this.DesignTimeInvalidate();
      }
    }

    internal override iGCellDrawFlags DrawFlags
    {
      get
      {
        return (iGCellDrawFlags) this.Flags;
      }
    }

    object ICloneable.Clone()
    {
      return (object) this.Clone();
    }
  }
}
