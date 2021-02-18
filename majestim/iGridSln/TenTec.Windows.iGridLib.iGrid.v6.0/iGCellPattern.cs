// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCellPattern
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.ComponentModel;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents a nameable preset that stores all cell properties and can be applied to new or existing cells.</summary>
  [TypeConverter("TenTec.Windows.iGridLib.Design.iGPatternConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
  public class iGCellPattern : ICloneable
  {
    internal iGCellData fData;

    internal iGCellPattern(iGCellData data)
    {
      this.fData = data;
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCellPattern" /> class.</summary>
    public iGCellPattern()
    {
      this.fData = new iGCellData((object) null, (object) null, -1, (iGCellStyle) null);
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCellPattern" /> class with the specified value.</summary>
    /// <param name="value">The value of the new cell.</param>
    public iGCellPattern(object value)
    {
      this.fData = new iGCellData(value);
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCellPattern" /> class with the specified value and image index.</summary>
    /// <param name="value">The value of the new cell.</param>
    /// <param name="imageIndex">The image index of the new cell.</param>
    public iGCellPattern(object value, int imageIndex)
    {
      this.fData = new iGCellData(value, imageIndex);
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCellPattern" /> class with the specified value and auxiliary value.</summary>
    /// <param name="value">The value of the new cell.</param>
    /// <param name="auxValue">The auxiliary value of the new cell.</param>
    public iGCellPattern(object value, object auxValue)
    {
      this.fData = new iGCellData(value, auxValue);
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCellPattern" /> class with the specified value, image index and style.</summary>
    /// <param name="value">The value of the new cell.</param>
    /// <param name="imageIndex">The image index of the new cell.</param>
    /// <param name="style">The style of the new cell.</param>
    public iGCellPattern(object value, int imageIndex, iGCellStyle style)
    {
      this.fData = new iGCellData(value, imageIndex, style);
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCellPattern" /> class with the specified value, auxiliary value, image index and style.</summary>
    /// <param name="value">The value of the new cell.</param>
    /// <param name="auxValue">The auxiliary value of the new cell.</param>
    /// <param name="imageIndex">The image index of the new cell.</param>
    /// <param name="style">The style of the new cell.</param>
    public iGCellPattern(object value, object auxValue, int imageIndex, iGCellStyle style)
    {
      this.fData = new iGCellData(value, auxValue, imageIndex, style);
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGCellPattern" /> class with the specified value, auxiliary value, image index, style and span columns/rows values.</summary>
    /// <param name="value">The value of the new cell.</param>
    /// <param name="auxValue">The auxiliary value of the new cell.</param>
    /// <param name="imageIndex">The image index of the new cell.</param>
    /// <param name="style">The style of the new cell.</param>
    /// <param name="spanCols">The number of columns to span across.</param>
    /// <param name="spanRows">The number of rows to span across.</param>
    public iGCellPattern(object value, object auxValue, int imageIndex, iGCellStyle style, int spanCols, int spanRows)
    {
      this.fData = new iGCellData(value, auxValue, imageIndex, style, spanCols, spanRows);
    }

    /// <summary>Creates an exact copy of this <see cref="T:TenTec.Windows.iGridLib.iGCellPattern" /> object.</summary>
    /// <returns>An exact copy of the cell pattern.</returns>
    public iGCellPattern Clone()
    {
      return new iGCellPattern(this.fData);
    }

    object ICloneable.Clone()
    {
      return (object) this.Clone();
    }

    /// <summary>Gets or sets the value of the cell used to dispaly its text.</summary>
    /// <value>An instance of a class. The default value is null (Nothing in VB).</value>
    [DefaultValue(null)]
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
    /// <value>An instance of an object.</value>
    [DefaultValue(null)]
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

    /// <summary>Gets or sets the index of the image displayed in the cell.</summary>
    /// <value>A zero-based index which represents the image position in an <see cref="T:System.Windows.Forms.ImageList" />. The default is -1.</value>
    [DefaultValue(-1)]
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

    /// <summary>Gets or sets a style object which determines appearance and behavior of the cell.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGCellStyle" /> object that determines the appearance and behavior of the cell, or null (Nothing in VB) if the appearance and behavior of the cell is completely determined by the column style and the grid's properties. The default value is null (Nothing in VB).</value>
    [DefaultValue(null)]
    public iGCellStyle Style
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

    /// <summary>Gets or sets the number of columns the cell should span.</summary>
    /// <value>The number of columns the cell should span. The default is 1.</value>
    [DefaultValue(1)]
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

    /// <summary>Gets or sets the number of rows the cell should span.</summary>
    /// <value>The number of rows the cell should span. The default is 1.</value>
    [DefaultValue(1)]
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
  }
}
