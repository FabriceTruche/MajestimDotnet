// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGColHdrPattern
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents a nameable preset that stores all column header properties and can be applied to new or existing column headers.</summary>
  public class iGColHdrPattern : ICloneable
  {
    internal iGColHdrData fData;

    internal iGColHdrPattern(iGColHdrData data)
    {
      this.fData = data;
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGColHdrPattern" /> class.</summary>
    public iGColHdrPattern()
    {
      this.fData = new iGColHdrData((object) null, -1);
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGColHdrPattern" /> class with the specified value.</summary>
    /// <param name="value">Specifies the value of the new pattern.</param>
    public iGColHdrPattern(object value)
    {
      this.fData = new iGColHdrData(value);
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGColHdrPattern" /> class with the specified value and image index.</summary>
    /// <param name="value">Specifies the value of the new pattern.</param>
    /// <param name="imageIndex">Specifies the image index of the new pattern.</param>
    public iGColHdrPattern(object value, int imageIndex)
    {
      this.fData = new iGColHdrData(value, imageIndex);
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGColHdrPattern" /> class with the specified value and auxiliary value.</summary>
    /// <param name="value">Specifies the value of the new pattern.</param>
    /// <param name="auxValue">Specifies the auxiliary value of the new pattern.</param>
    public iGColHdrPattern(object value, object auxValue)
    {
      this.fData = new iGColHdrData(value, auxValue);
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGColHdrPattern" /> class with the specified value, image index, and style.</summary>
    /// <param name="value">Specifies the value of the new pattern.</param>
    /// <param name="imageIndex">Specifies the image index of the new pattern.</param>
    /// <param name="style">The style of the new pattern.</param>
    public iGColHdrPattern(object value, int imageIndex, iGColHdrStyle style)
    {
      this.fData = new iGColHdrData(value, imageIndex, style);
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGColHdrPattern" /> class with the specified value, auxiliary value, image index, and style.</summary>
    /// <param name="value">Specifies the value of the new pattern.</param>
    /// <param name="auxValue">Specifies the auxiliary value of the new pattern.</param>
    /// <param name="imageIndex">Specifies the image index of the new pattern.</param>
    /// <param name="style">The style of the new pattern.</param>
    public iGColHdrPattern(object value, object auxValue, int imageIndex, iGColHdrStyle style)
    {
      this.fData = new iGColHdrData(value, auxValue, imageIndex, style);
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGColHdrPattern" /> class with the specified value, auxiliary value, image index, style and span columns/rows data.</summary>
    /// <param name="value">Specifies the value of the new pattern.</param>
    /// <param name="auxValue">Specifies the auxiliary value of the new pattern.</param>
    /// <param name="imageIndex">Specifies the image index of the new pattern.</param>
    /// <param name="style">The style of the new pattern.</param>
    /// <param name="spanCols">The number of columns to span across.</param>
    /// <param name="spanRows">The number of rows to span across.</param>
    public iGColHdrPattern(object value, object auxValue, int imageIndex, iGColHdrStyle style, int spanCols, int spanRows)
    {
      this.fData = new iGColHdrData(value, auxValue, imageIndex, style, spanCols, spanRows);
    }

    /// <summary>Creates an exact copy of this <see cref="T:TenTec.Windows.iGridLib.iGColHdrPattern" /> object.</summary>
    /// <returns>An exact copy of the column header pattern.</returns>
    public iGColHdrPattern Clone()
    {
      return new iGColHdrPattern(this.fData);
    }

    object ICloneable.Clone()
    {
      return (object) this.Clone();
    }

    /// <summary>Gets or sets the value of the column header used to display its text.</summary>
    /// <value>An instance of a class. The default value is null (Nothing in VB).</value>
    public object Value
    {
      get
      {
        return this.fData.Value;
      }
      set
      {
        this.fData.Value = value;
      }
    }

    /// <summary>Gets or sets an auxiliary value.</summary>
    /// <value>An object.</value>
    public object AuxValue
    {
      get
      {
        return this.fData.AuxValue;
      }
      set
      {
        this.fData.AuxValue = value;
      }
    }

    /// <summary>Gets or sets the index of the image displayed in the column header.</summary>
    /// <value>A zero-based index which represents the image position in an <see cref="T:System.Windows.Forms.ImageList" />. The default is -1 which means that the column header has no image.</value>
    public int ImageIndex
    {
      get
      {
        return this.fData.ImageIndex;
      }
      set
      {
        this.fData.ImageIndex = value;
      }
    }

    /// <summary>Gets or sets a style object determining the appearance and behavior of the column header.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGColHdrStyle" /> object that determines the appearance and behavior of the column header, or null (Nothing in VB) if the appearance and behavior of the column header is completely determined by the column style and the grid's properties. The default value is null (Nothing in VB).</value>
    public iGColHdrStyle Style
    {
      get
      {
        return this.fData.Style;
      }
      set
      {
        this.fData.Style = value;
      }
    }

    /// <summary>Gets or sets the number of rows the column header should span.</summary>
    /// <value>The number of rows the column header should span. The default is 1.</value>
    public int SpanRows
    {
      get
      {
        return this.fData.SpanRows;
      }
      set
      {
        iGrid.CheckSpanRowsValue(value);
        this.fData.SpanRows = value;
      }
    }

    /// <summary>Gets or sets the number of columns the column header should span.</summary>
    /// <value>The number of columns the column header should span. The default is 1.</value>
    public int SpanCols
    {
      get
      {
        return this.fData.SpanCols;
      }
      set
      {
        iGrid.CheckSpanColsValue(value);
        this.fData.SpanCols = value;
      }
    }
  }
}
