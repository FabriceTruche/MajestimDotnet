// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGColCollection
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing.Design;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents the collection of the columns in an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  [TypeConverter("TenTec.Windows.iGridLib.Design.iGTypeConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
  [Editor("TenTec.Windows.iGridLib.Design.iGColCollectionEditor, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0", typeof (UITypeEditor))]
  [DesignerSerializer("TenTec.Windows.iGridLib.Design.iGColCollectionSerializer, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design")]
  public class iGColCollection : IiGEnumerableCollection, IEnumerable
  {
    internal iGrid fGrid;

    /// <summary>Returns the <see cref="T:TenTec.Windows.iGridLib.iGrid" /> object this instance belongs to.</summary>
    /// <value>Returns the <see cref="T:TenTec.Windows.iGridLib.iGrid" /> object this instance belongs to.</value>
    [Browsable(false)]
    public iGrid Grid
    {
      get
      {
        return this.fGrid;
      }
    }

    internal iGColCollection(iGrid grid)
    {
      this.fGrid = grid;
    }

    /// <summary>Copies the data of the last columns to the first columns and removes the last columns. Intended to be used at design time.</summary>
    /// <param name="count">The number of the columns to be left.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void ShiftNearAndTrim(int count)
    {
      if (count < 0)
        throw new ArgumentOutOfRangeException();
      int num = this.Count - count;
      for (int index = num; index < this.Count; ++index)
        this[index - num].Pattern = this[index].Pattern;
      this.Count = count;
    }

    /// <summary>Resizes all the resizeable columns to display the contents of all the cells entirely.</summary>
    public void AutoWidth()
    {
      this.fGrid.AutoWidthCols(false, 0, this.fGrid.fRowCount);
    }

    /// <summary>Resizes all the resizeable columns to display entirely the contents of all the cells in the specified rows.</summary>
    /// <param name="rowIndex">The index of the first row to adjust the columns' width by.</param>
    /// <param name="rowCount">The number of the rows to adjust the columns' width by.</param>
    public void AutoWidth(int rowIndex, int rowCount)
    {
      this.fGrid.AutoWidthCols(true, rowIndex, rowCount);
    }

    /// <summary>Retrieves the column located at the specified coordinates and its coordinates. The coordinates are relative to the upper left corner of the grid.</summary>
    /// <param name="x">The X-coordinate specifying the location of the column to retrieve.</param>
    /// <param name="colX">The X-coordinate of the retrieved column's left edge.</param>
    /// <param name="colWidth">The width of the retrieved column.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGCol" /> object that represents the column at the specified coordinate, or null (Nothing in VB) if there is no column.</returns>
    public iGCol FromX(int x, out int colX, out int colWidth)
    {
      int colIndex;
      if (this.fGrid.GetColFromX(x, out colIndex, out colX, out colWidth))
        return new iGCol(this.fGrid, colIndex);
      return (iGCol) null;
    }

    /// <summary>Retrieves the column located at the specified coordinates. The coordinates are relative to the upper left corner of the grid.</summary>
    /// <param name="x">The X-coordinate specifying the location of the column to retrieve.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGCol" /> object that represents the column at the specified coordinate, or null (Nothing in VB) if there is no column.</returns>
    public iGCol FromX(int x)
    {
      int colX;
      int colWidth;
      return this.FromX(x, out colX, out colWidth);
    }

    /// <summary>Retrieves a column by its display position.</summary>
    /// <param name="colOrder">The display position of the column to retreave.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGCol" /> object that represents the column at the specified display position.</returns>
    public iGCol FromOrder(int colOrder)
    {
      return new iGCol(this.fGrid, this.fGrid.GetColIndex(colOrder + 1));
    }

    /// <summary>Returns a column by its index.</summary>
    /// <param name="colIndex">The index of the column to retrieve.</param>
    /// <returns>An instance of the <see cref="T:TenTec.Windows.iGridLib.iGCol" /> class which represents the column with the specified index.</returns>
    public iGCol FromIndex(int colIndex)
    {
      return this[colIndex];
    }

    /// <summary>Returns a value indicating whether the specified key is attached to a column.</summary>
    /// <param name="key">The key to look for.</param>
    /// <returns>True if the grid has a column with the specified key; otherwise, False.</returns>
    public bool KeyExists(string key)
    {
      return this.fGrid.ColKeyExists(key);
    }

    /// <summary>Removes the column at the specified index from the grid.</summary>
    /// <param name="colIndex">The index of the column to remove.</param>
    public void RemoveAt(int colIndex)
    {
      this.fGrid.RemoveColRange(colIndex + 1, 1);
    }

    /// <summary>Removes the column range specified by the index of the first column and column count.</summary>
    /// <param name="colIndex">The starting index of the range of columns to remove.</param>
    /// <param name="count">The number of columns to remove.</param>
    public void RemoveRange(int colIndex, int count)
    {
      this.fGrid.RemoveColRange(colIndex + 1, count);
    }

    /// <summary>Removes the column with the specified key from the grid.</summary>
    /// <param name="key">The string key of the column to remove.</param>
    public void RemoveAt(string key)
    {
      int index = this.fGrid.ColKeyToIndex(key, true);
      if (index < 1)
        throw new ArgumentException("Invalid key");
      this.fGrid.RemoveColRange(index, 1);
    }

    /// <summary>Removes the range of the columns specified by the key of the first element and count.</summary>
    /// <param name="key">The string key of the first column in the range of columns to remove.</param>
    /// <param name="count">The number of columns to remove.</param>
    public void RemoveRange(string key, int count)
    {
      int index = this.fGrid.ColKeyToIndex(key, true);
      if (index < 1)
        throw new ArgumentException("Invalid key");
      this.fGrid.RemoveColRange(index, count);
    }

    /// <summary>Removes all the columns from the grid.</summary>
    public void Clear()
    {
      this.fGrid.ClearCols();
    }

    /// <summary>Adds a new column to the grid.</summary>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGCol" /> object which refers to the added column.</returns>
    public iGCol Add()
    {
      return new iGCol(this.fGrid, this.fGrid.AddColRange(this.fGrid.fColCount, (iGColPattern[]) null, 1));
    }

    /// <summary>Adds a new column with the specified header <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" /> to the grid.</summary>
    /// <param name="text">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" /> that will be displayed in the new column's header.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGCol" /> object which refers to the added column.</returns>
    public iGCol Add(string text)
    {
      iGColPattern iGcolPattern = this.fGrid.fDefaultCol.CloneWithoutStyles();
      iGcolPattern.Text = (object) text;
      return new iGCol(this.fGrid, this.fGrid.AddColRange(this.fGrid.fColCount, new iGColPattern[1]
      {
        iGcolPattern
      }, 1));
    }

    /// <summary>Adds a new column with the specified header <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" /> and <see cref="P:TenTec.Windows.iGridLib.iGCol.Width" /> to the grid.</summary>
    /// <param name="text">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" /> that will be displayed in the new column's header.</param>
    /// <param name="width">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Width" /> of the new column.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGCol" /> object which refers to the added column.</returns>
    public iGCol Add(string text, int width)
    {
      iGColPattern iGcolPattern = this.fGrid.fDefaultCol.CloneWithoutStyles();
      iGcolPattern.Text = (object) text;
      iGcolPattern.Width = width;
      return new iGCol(this.fGrid, this.fGrid.AddColRange(this.fGrid.fColCount, new iGColPattern[1]
      {
        iGcolPattern
      }, 1));
    }

    /// <summary>Adds a new column with the specified <see cref="P:TenTec.Windows.iGridLib.iGCol.Key" /> and header <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" /> to the grid.</summary>
    /// <param name="key">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Key" /> of the new column.</param>
    /// <param name="text">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" /> that will be displayed in the new column's header.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGCol" /> object which refers to the added column.</returns>
    public iGCol Add(string key, string text)
    {
      iGColPattern iGcolPattern = this.fGrid.fDefaultCol.CloneWithoutStyles();
      iGcolPattern.Key = key;
      iGcolPattern.Text = (object) text;
      return new iGCol(this.fGrid, this.fGrid.AddColRange(this.fGrid.fColCount, new iGColPattern[1]
      {
        iGcolPattern
      }, 1));
    }

    /// <summary>Adds a new column with the specified <see cref="P:TenTec.Windows.iGridLib.iGCol.Key" />, header <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" />, and <see cref="P:TenTec.Windows.iGridLib.iGCol.Width" /> to the grid.</summary>
    /// <param name="key">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Key" /> of the new column.</param>
    /// <param name="text">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" /> that will be displayed in the new column's header.</param>
    /// <param name="width">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Width" /> of the new column.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGCol" /> object which refers to the added column.</returns>
    public iGCol Add(string key, string text, int width)
    {
      iGColPattern iGcolPattern = this.fGrid.fDefaultCol.CloneWithoutStyles();
      iGcolPattern.Key = key;
      iGcolPattern.Text = (object) text;
      iGcolPattern.Width = width;
      return new iGCol(this.fGrid, this.fGrid.AddColRange(this.fGrid.fColCount, new iGColPattern[1]
      {
        iGcolPattern
      }, 1));
    }

    /// <summary>Creates a new column from the specified <see cref="P:TenTec.Windows.iGridLib.iGCol.Pattern" /> and adds it to the grid.</summary>
    /// <param name="colPattern">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Pattern" /> to create the new column from.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGCol" /> object which refers to the added column.</returns>
    public iGCol Add(iGColPattern colPattern)
    {
      return new iGCol(this.fGrid, this.fGrid.AddColRange(this.fGrid.fColCount, new iGColPattern[1]
      {
        colPattern
      }, 1));
    }

    /// <summary>Creates a new column from the specified <see cref="P:TenTec.Windows.iGridLib.iGCol.Pattern" />, overrides its header <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" /> with the specified value, and adds the column to the grid.</summary>
    /// <param name="text">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" /> that will be displayed in the new column's header.</param>
    /// <param name="colPattern">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Pattern" /> to create the new column from.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGCol" /> object which refers to the added column.</returns>
    public iGCol Add(string text, iGColPattern colPattern)
    {
      colPattern.Text = (object) text;
      return new iGCol(this.fGrid, this.fGrid.AddColRange(this.fGrid.fColCount, new iGColPattern[1]
      {
        colPattern
      }, 1));
    }

    /// <summary>Creates a new column from the specified <see cref="P:TenTec.Windows.iGridLib.iGCol.Pattern" />, overrides its header <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" /> and <see cref="P:TenTec.Windows.iGridLib.iGCol.Width" /> with the specified values, and adds the column to the grid.</summary>
    /// <param name="text">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" /> that will be displayed in the new column's header.</param>
    /// <param name="width">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Width" /> of the new column.</param>
    /// <param name="colPattern">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Pattern" /> to create the new column from.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGCol" /> object which refers to the added column.</returns>
    public iGCol Add(string text, int width, iGColPattern colPattern)
    {
      colPattern.Text = (object) text;
      colPattern.Width = width;
      return new iGCol(this.fGrid, this.fGrid.AddColRange(this.fGrid.fColCount, new iGColPattern[1]
      {
        colPattern
      }, 1));
    }

    /// <summary>Creates a new column from the specified <see cref="P:TenTec.Windows.iGridLib.iGCol.Pattern" />, overrides its <see cref="P:TenTec.Windows.iGridLib.iGCol.Key" /> and header <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" /> with the specified values, and adds the column to the grid.</summary>
    /// <param name="key">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Key" /> of the new column.</param>
    /// <param name="text">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" /> that will be displayed in the new column's header.</param>
    /// <param name="colPattern">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Pattern" /> to create the new column from.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGCol" /> object which refers to the added column.</returns>
    public iGCol Add(string key, string text, iGColPattern colPattern)
    {
      colPattern.Key = key;
      colPattern.Text = (object) text;
      return new iGCol(this.fGrid, this.fGrid.AddColRange(this.fGrid.fColCount, new iGColPattern[1]
      {
        colPattern
      }, 1));
    }

    /// <summary>Creates a new column from the specified <see cref="P:TenTec.Windows.iGridLib.iGCol.Pattern" />, overrides its <see cref="P:TenTec.Windows.iGridLib.iGCol.Key" />, header <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" />, and <see cref="P:TenTec.Windows.iGridLib.iGCol.Width" /> with the specified values, and adds the column to the grid.</summary>
    /// <param name="key">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Key" /> of the new column.</param>
    /// <param name="text">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" /> that will be displayed in the new column's header.</param>
    /// <param name="width">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Width" /> of the new column.</param>
    /// <param name="colPattern">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Pattern" /> to create the new column from.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGCol" /> object which refers to the added column.</returns>
    public iGCol Add(string key, string text, int width, iGColPattern colPattern)
    {
      colPattern.Key = key;
      colPattern.Text = (object) text;
      colPattern.Width = width;
      return new iGCol(this.fGrid, this.fGrid.AddColRange(this.fGrid.fColCount, new iGColPattern[1]
      {
        colPattern
      }, 1));
    }

    /// <summary>Inserts a new column to the specified position in the grid.</summary>
    /// <param name="colBefore">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Index" /> of the column to insert the new column before.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGCol" /> object that represents the added column.</returns>
    public iGCol Insert(int colBefore)
    {
      return new iGCol(this.fGrid, this.fGrid.AddColRange(colBefore + 1, (iGColPattern[]) null, 1));
    }

    /// <summary>Inserts a new column with the specified header <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" /> to the specified position in the grid.</summary>
    /// <param name="colBefore">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Index" /> of the column to insert the new column before.</param>
    /// <param name="text">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" /> that will be displayed in the new column's header.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGCol" /> object which refers to the added column.</returns>
    public iGCol Insert(int colBefore, string text)
    {
      iGColPattern iGcolPattern = this.fGrid.fDefaultCol.CloneWithoutStyles();
      iGcolPattern.Text = (object) text;
      return new iGCol(this.fGrid, this.fGrid.AddColRange(colBefore + 1, new iGColPattern[1]
      {
        iGcolPattern
      }, 1));
    }

    /// <summary>Inserts a new column with the specified header <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" /> and <see cref="P:TenTec.Windows.iGridLib.iGCol.Width" /> to the specified position in the grid.</summary>
    /// <param name="colBefore">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Index" /> of the column to insert the new column before.</param>
    /// <param name="text">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" /> that will be displayed in the new column's header.</param>
    /// <param name="width">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Width" /> of the new column.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGCol" /> object which refers to the added column.</returns>
    public iGCol Insert(int colBefore, string text, int width)
    {
      iGColPattern iGcolPattern = this.fGrid.fDefaultCol.CloneWithoutStyles();
      iGcolPattern.Text = (object) text;
      iGcolPattern.Width = width;
      return new iGCol(this.fGrid, this.fGrid.AddColRange(colBefore + 1, new iGColPattern[1]
      {
        iGcolPattern
      }, 1));
    }

    /// <summary>Inserts a new column with the specified <see cref="P:TenTec.Windows.iGridLib.iGCol.Key" /> and header <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" /> to the specified position in the grid.</summary>
    /// <param name="colBefore">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Index" /> of the column to insert the new column before.</param>
    /// <param name="key">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Key" /> of the new column.</param>
    /// <param name="text">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" /> that will be displayed in the new column's header.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGCol" /> object which refers to the added column.</returns>
    public iGCol Insert(int colBefore, string key, string text)
    {
      iGColPattern iGcolPattern = this.fGrid.fDefaultCol.CloneWithoutStyles();
      iGcolPattern.Key = key;
      iGcolPattern.Text = (object) text;
      return new iGCol(this.fGrid, this.fGrid.AddColRange(colBefore + 1, new iGColPattern[1]
      {
        iGcolPattern
      }, 1));
    }

    /// <summary>Inserts a new column with the specified <see cref="P:TenTec.Windows.iGridLib.iGCol.Key" />, header <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" /> and <see cref="P:TenTec.Windows.iGridLib.iGCol.Width" /> to the specified position in the grid.</summary>
    /// <param name="colBefore">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Index" /> of the column to insert the new column before.</param>
    /// <param name="key">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Key" /> of the new column.</param>
    /// <param name="text">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" /> that will be displayed in the new column's header.</param>
    /// <param name="width">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Width" /> of the new column.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGCol" /> object which refers to the added column.</returns>
    public iGCol Insert(int colBefore, string key, string text, int width)
    {
      iGColPattern iGcolPattern = this.fGrid.fDefaultCol.CloneWithoutStyles();
      iGcolPattern.Key = key;
      iGcolPattern.Text = (object) text;
      iGcolPattern.Width = width;
      return new iGCol(this.fGrid, this.fGrid.AddColRange(colBefore + 1, new iGColPattern[1]
      {
        iGcolPattern
      }, 1));
    }

    /// <summary>Creates a new column from the specified <see cref="P:TenTec.Windows.iGridLib.iGCol.Pattern" />, and inserts this column to the specified position in the grid.</summary>
    /// <param name="colBefore">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Index" /> of the column to insert the new column before.</param>
    /// <param name="colPattern">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Pattern" /> to create the new column from.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGCol" /> object which refers to the added column.</returns>
    public iGCol Insert(int colBefore, iGColPattern colPattern)
    {
      return new iGCol(this.fGrid, this.fGrid.AddColRange(colBefore + 1, new iGColPattern[1]
      {
        colPattern
      }, 1));
    }

    /// <summary>Creates a new column from the specified <see cref="P:TenTec.Windows.iGridLib.iGCol.Pattern" />, overrides its header <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" /> with the specified value, and inserts the column to the specified position in the grid.</summary>
    /// <param name="colBefore">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Index" /> of the column to insert the new column before.</param>
    /// <param name="text">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" /> that will be displayed in the new column's header.</param>
    /// <param name="colPattern">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Pattern" /> to create the new column from.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGCol" /> object which refers to the added column.</returns>
    public iGCol Insert(int colBefore, string text, iGColPattern colPattern)
    {
      colPattern.Text = (object) text;
      return new iGCol(this.fGrid, this.fGrid.AddColRange(colBefore + 1, new iGColPattern[1]
      {
        colPattern
      }, 1));
    }

    /// <summary>Creates a new column from the specified <see cref="P:TenTec.Windows.iGridLib.iGCol.Pattern" />, overrides its header <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" /> and <see cref="P:TenTec.Windows.iGridLib.iGCol.Width" /> with the specified values, and inserts the column to the specified position in the grid.</summary>
    /// <param name="colBefore">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Index" /> of the column to insert the new column before.</param>
    /// <param name="text">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" /> that will be displayed in the new column's header.</param>
    /// <param name="width">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Width" /> of the new column.</param>
    /// <param name="colPattern">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Pattern" /> to create the new column from.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGCol" /> object which refers to the added column.</returns>
    public iGCol Insert(int colBefore, string text, int width, iGColPattern colPattern)
    {
      colPattern.Text = (object) text;
      colPattern.Width = width;
      return new iGCol(this.fGrid, this.fGrid.AddColRange(colBefore + 1, new iGColPattern[1]
      {
        colPattern
      }, 1));
    }

    /// <summary>Creates a new column from the specified <see cref="P:TenTec.Windows.iGridLib.iGCol.Pattern" />, overrides its <see cref="P:TenTec.Windows.iGridLib.iGCol.Key" /> and header <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" /> with the specified values, and inserts the column to the specified position in the grid.</summary>
    /// <param name="colBefore">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Index" /> of the column to insert the new column before.</param>
    /// <param name="key">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Key" /> of the new column.</param>
    /// <param name="text">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" /> that will be displayed in the new column's header.</param>
    /// <param name="colPattern">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Pattern" /> to create the new column from.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGCol" /> object which refers to the added column.</returns>
    public iGCol Insert(int colBefore, string key, string text, iGColPattern colPattern)
    {
      colPattern.Key = key;
      colPattern.Text = (object) text;
      return new iGCol(this.fGrid, this.fGrid.AddColRange(colBefore + 1, new iGColPattern[1]
      {
        colPattern
      }, 1));
    }

    /// <summary>Creates a new column from the specified <see cref="P:TenTec.Windows.iGridLib.iGCol.Pattern" />, overrides its <see cref="P:TenTec.Windows.iGridLib.iGCol.Key" />, header <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" /> and <see cref="P:TenTec.Windows.iGridLib.iGCol.Width" /> with the specified values, and inserts the column to the specified position in the grid.</summary>
    /// <param name="colBefore">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Index" /> of the column to insert the new column before.</param>
    /// <param name="key">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Key" /> of the new column.</param>
    /// <param name="text">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Text" /> that will be displayed in the new column's header.</param>
    /// <param name="width">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Width" /> of the new column.</param>
    /// <param name="colPattern">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Pattern" /> to create the new column from.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGCol" /> object which refers to the added column.</returns>
    public iGCol Insert(int colBefore, string key, string text, int width, iGColPattern colPattern)
    {
      colPattern.Key = key;
      colPattern.Text = (object) text;
      colPattern.Width = width;
      return new iGCol(this.fGrid, this.fGrid.AddColRange(colBefore + 1, new iGColPattern[1]
      {
        colPattern
      }, 1));
    }

    /// <summary>Adds the specified range of new columns to the grid.</summary>
    /// <param name="count">The number of the columns to add.</param>
    /// <returns>The <see cref="P:TenTec.Windows.iGridLib.iGCol.Index" /> of the first added column.</returns>
    public int AddRange(int count)
    {
      return this.fGrid.AddColRange(this.fGrid.fColCount, (iGColPattern[]) null, count);
    }

    /// <summary>Creates new columns from the specified <see cref="P:TenTec.Windows.iGridLib.iGCol.Pattern" />s, and adds them to the grid.</summary>
    /// <param name="colPatterns">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Pattern" />s to create the new columns from.</param>
    /// <returns>The <see cref="P:TenTec.Windows.iGridLib.iGCol.Index" /> of the first added column.</returns>
    public int AddRange(iGColPattern[] colPatterns)
    {
      if (colPatterns == null)
        throw new ArgumentNullException();
      return this.fGrid.AddColRange(this.fGrid.fColCount, colPatterns, colPatterns.Length);
    }

    /// <summary>Inserts the specified range of new columns to the specified position in the grid.</summary>
    /// <param name="colBefore">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Index" /> of the columns to insert the new column before.</param>
    /// <param name="count">The number of the columns to insert.</param>
    /// <returns>The <see cref="P:TenTec.Windows.iGridLib.iGCol.Index" /> of the first added column.</returns>
    public int InsertRange(int colBefore, int count)
    {
      return this.fGrid.AddColRange(colBefore + 1, (iGColPattern[]) null, count);
    }

    /// <summary>Creates new columns from the specified <see cref="P:TenTec.Windows.iGridLib.iGCol.Pattern" />s, and inserts the columns to the specified position in the grid.</summary>
    /// <param name="colBefore">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Index" /> of the column to insert the new columns before.</param>
    /// <param name="colPatterns">The <see cref="P:TenTec.Windows.iGridLib.iGCol.Pattern" />s to create the new columns from.</param>
    /// <returns>The <see cref="P:TenTec.Windows.iGridLib.iGCol.Index" /> of the first added column.</returns>
    public int InsertRange(int colBefore, iGColPattern[] colPatterns)
    {
      if (colPatterns == null)
        throw new ArgumentNullException();
      return this.fGrid.AddColRange(colBefore + 1, colPatterns, colPatterns.Length);
    }

    /// <summary>Gets the column with the specified index.</summary>
    /// <param name="index">The index of the column to retrieve.</param>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGCol" /> object that represents the column with the specified index.</value>
    public iGCol this[int index]
    {
      get
      {
        ++index;
        return new iGCol(this.fGrid, index);
      }
    }

    /// <summary>Gets the column with the specified key.</summary>
    /// <param name="key">The string key of the column to retrieve.</param>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGCol" /> object that represents the column with the specified key.</value>
    public iGCol this[string key]
    {
      get
      {
        return new iGCol(this.fGrid, this.fGrid.ColKeyToIndex(key, true));
      }
    }

    /// <summary>Gets or sets the number of the columns in the grid.</summary>
    /// <value>The number of the columns.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int Count
    {
      get
      {
        return this.fGrid.fColCount - 1;
      }
      set
      {
        if (value < 0)
          throw new ArgumentOutOfRangeException();
        ++value;
        if (value < this.fGrid.fColCount)
        {
          this.fGrid.RemoveColRange(value, this.fGrid.fColCount - value);
        }
        else
        {
          if (value <= this.fGrid.fColCount)
            return;
          this.AddRange(value - this.fGrid.fColCount);
        }
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return (IEnumerator) new iGEnumerator((IiGEnumerableCollection) this);
    }

    object IiGEnumerableCollection.this[int index]
    {
      get
      {
        return (object) this[index];
      }
    }

    int IiGEnumerableCollection.Count
    {
      get
      {
        return this.Count;
      }
    }
  }
}
