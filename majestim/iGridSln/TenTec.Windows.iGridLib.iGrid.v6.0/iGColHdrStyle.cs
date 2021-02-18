// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGColHdrStyle
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.ComponentModel;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Defines the appearance and behavior of a column header in an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  [TypeConverter("TenTec.Windows.iGridLib.Design.iGColHdrStyleConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
  [DesignTimeVisible(false)]
  [ToolboxItem(false)]
  public class iGColHdrStyle : iGStyleBase, ICloneable
  {
    /// <summary>The default value for the <see cref="P:TenTec.Windows.iGridLib.iGColHdrStyle.Flags" /> property.</summary>
    public const iGColHdrFlags ConstDefaultFlags = iGColHdrFlags.NotSet;
    /// <summary>The default value for the <see cref="P:TenTec.Windows.iGridLib.iGColHdrStyle.SortInfoVisible" /> property.</summary>
    public const iGBool ConstDefaultSortInfoVisible = iGBool.NotSet;
    internal const iGColHdrFlags cSuperFlags = iGColHdrFlags.DisplayText | iGColHdrFlags.DisplayImage;
    internal const iGBool cSuperSortInfoVisible = iGBool.True;
    internal iGColHdrFlags fFlags;
    internal iGBool fSortInfoVisible;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGColHdrStyle" /> class.</summary>
    public iGColHdrStyle()
      : this(false)
    {
      this.fSortInfoVisible = iGBool.NotSet;
      this.fFlags = iGColHdrFlags.NotSet;
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGColHdrStyle" /> class with all the properties set either to the 'NotSet' (transparent) values or to the definite default values.</summary>
    /// <param name="setPropsToNonTransparentValues">If True, all the properties will be set to the definite default values; otherwise, all the properties will be set to the 'NotSet' (transparent) values.</param>
    public iGColHdrStyle(bool setPropsToNonTransparentValues)
      : base(setPropsToNonTransparentValues)
    {
      if (setPropsToNonTransparentValues)
      {
        this.fSortInfoVisible = iGBool.True;
        this.fFlags = iGColHdrFlags.DisplayText | iGColHdrFlags.DisplayImage;
      }
      else
      {
        this.fSortInfoVisible = iGBool.NotSet;
        this.fFlags = iGColHdrFlags.NotSet;
      }
    }

    /// <summary>Creates an exact copy of this <see cref="T:TenTec.Windows.iGridLib.iGColHdrStyle" /> object.</summary>
    /// <returns>The exact copy of this object.</returns>
    public iGColHdrStyle Clone()
    {
      iGColHdrStyle iGcolHdrStyle = new iGColHdrStyle();
      iGcolHdrStyle.CloneProperties((iGStyleBase) this);
      return iGcolHdrStyle;
    }

    private void CloneOwnProperties(iGColHdrStyle fromStyle)
    {
      this.fSortInfoVisible = fromStyle.fSortInfoVisible;
      this.fFlags = fromStyle.fFlags;
    }

    /// <summary>Copies the properties from the specified column header style object into this object.</summary>
    /// <param name="fromStyle">The <see cref="T:TenTec.Windows.iGridLib.iGStyleBase" /> object to copy the properties from.</param>
    public override void CloneProperties(iGStyleBase fromStyle)
    {
      this.CloneOwnProperties((iGColHdrStyle) fromStyle);
      base.CloneProperties(fromStyle);
    }

    private bool ShouldSerializeSortInfoVisible()
    {
      if (this.fAreSuperValuesDefault)
        return (uint) this.fSortInfoVisible > 0U;
      return this.fSortInfoVisible != iGBool.NotSet;
    }

    private bool ShouldSerializeFlags()
    {
      if (this.fAreSuperValuesDefault)
        return this.fFlags != (iGColHdrFlags.DisplayText | iGColHdrFlags.DisplayImage);
      return this.fFlags != iGColHdrFlags.NotSet;
    }

    private void ResetSortInfoVisible()
    {
      if (this.fAreSuperValuesDefault)
        this.SortInfoVisible = iGBool.True;
      else
        this.SortInfoVisible = iGBool.NotSet;
    }

    private void ResetFlags()
    {
      if (this.fAreSuperValuesDefault)
        this.Flags = iGColHdrFlags.DisplayText | iGColHdrFlags.DisplayImage;
      else
        this.Flags = iGColHdrFlags.NotSet;
    }

    internal override iGCellDrawType DrawType
    {
      get
      {
        return iGCellDrawType.Text;
      }
    }

    internal override iGCellDrawTypeFlags DrawTypeFlags
    {
      get
      {
        return iGCellDrawTypeFlags.None;
      }
    }

    /// <summary>Gets or sets flags that determine which parts of the column header's contents (image, text) are displayed.</summary>
    /// <value>A set of the <see cref="T:TenTec.Windows.iGridLib.iGColHdrFlags" /> enumeration values.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Additional flags used to specify some options of the column header.")]
    public iGColHdrFlags Flags
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
        return (iGCellDrawFlags) this.fFlags;
      }
    }

    /// <summary>Gets or sets a value determining whether to display the sort info in the column header when the column is sorted.</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGBool" /> values. The default is <see cref="F:TenTec.Windows.iGridLib.iGBool.NotSet" /> which means that the property is not set and its value is determined from the style of the column (if this style is attached to a column header) or a predefined value is used. The predefined value for this property is <see cref="F:TenTec.Windows.iGridLib.iGBool.True" />.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines whether to display the sort info in the column header when the column is sorted. Use this property for the narrow columns.")]
    public iGBool SortInfoVisible
    {
      get
      {
        return this.fSortInfoVisible;
      }
      set
      {
        this.fSortInfoVisible = value;
        this.DesignTimeInvalidate();
      }
    }

    object ICloneable.Clone()
    {
      return (object) this.Clone();
    }
  }
}
