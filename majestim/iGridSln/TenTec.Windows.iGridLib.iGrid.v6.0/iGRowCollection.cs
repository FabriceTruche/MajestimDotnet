// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGRowCollection
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
  /// <summary>Represents the collection of the rows in an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  [TypeConverter("TenTec.Windows.iGridLib.Design.iGTypeConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
  [DesignerSerializer("TenTec.Windows.iGridLib.Design.iGRowCollectionSerializer, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design")]
  [Editor("TenTec.Windows.iGridLib.Design.iGRowCollectionEditor, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0", typeof (UITypeEditor))]
  public class iGRowCollection : IiGEnumerableCollection, IEnumerable
  {
    internal iGrid fGrid;

    /// <summary>Returns the <see cref="T:TenTec.Windows.iGridLib.iGrid" /> object this instance belongs to.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGrid" /> object.</value>
    [Browsable(false)]
    public iGrid Grid
    {
      get
      {
        return this.fGrid;
      }
    }

    internal iGRowCollection(iGrid grid)
    {
      this.fGrid = grid;
    }

    /// <summary>Adds a new row to the grid.</summary>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGRow" /> object that represents the new row.</returns>
    public iGRow Add()
    {
      return new iGRow(this.fGrid, this.fGrid.AddRowRange(this.fGrid.fRowCount, 1));
    }

    /// <summary>Inserts a new row to the specified position.</summary>
    /// <param name="rowBefore">The zero-based index of the row to insert the new row before.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGRow" /> object that represents the new row.</returns>
    public iGRow Insert(int rowBefore)
    {
      return new iGRow(this.fGrid, this.fGrid.AddRowRange(rowBefore, 1));
    }

    /// <summary>Creates a new row from the specified pattern and adds it to the grid.</summary>
    /// <param name="rowPattern">The pattern to create the new row from.</param>
    /// <returns>The index of the new row.</returns>
    public iGRow Add(iGRowPattern rowPattern)
    {
      return new iGRow(this.fGrid, this.fGrid.AddRowRange(this.fGrid.fRowCount, 1, rowPattern));
    }

    /// <summary>Creates a new row from the specified pattern and inserts it to the specified position.</summary>
    /// <param name="rowBefore">The zero-based index of the row to insert the new row before.</param>
    /// <param name="rowPattern">The pattern to create the new row from.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGRow" /> object that represents the new row.</returns>
    public iGRow Insert(int rowBefore, iGRowPattern rowPattern)
    {
      return new iGRow(this.fGrid, this.fGrid.AddRowRange(rowBefore, 1, rowPattern));
    }

    /// <summary>Creates new rows from the specified row patterns, adds them to the grid and populates the rows' cells using the specified cell patterns.</summary>
    /// <param name="rowPatterns">The patterns to create the new rows from.</param>
    /// <param name="cellPatterns">The patterns to populate the new cells from.</param>
    /// <returns>The index of the first added row.</returns>
    public int AddRange(iGRowPattern[] rowPatterns, iGCellPattern[] cellPatterns)
    {
      if (rowPatterns == null || cellPatterns == null)
        throw new ArgumentNullException();
      if (cellPatterns.Length != rowPatterns.Length * this.fGrid.fColCount)
        throw new ArgumentException("Incorrect array length");
      for (int index = cellPatterns.Length - 1; index >= 0; --index)
      {
        if (cellPatterns[index] == null)
          throw new ArgumentException("Array element cannot be null");
      }
      for (int index = rowPatterns.Length - 1; index >= 0; --index)
      {
        if (rowPatterns[index] == null)
          throw new ArgumentException("Array element cannot be null");
      }
      int fRowCount = this.fGrid.fRowCount;
      int num = this.fGrid.AddRowRange(fRowCount, rowPatterns.Length);
      for (int index = 0; index < rowPatterns.Length; ++index)
      {
        this.fGrid.SetRowData(fRowCount + index, rowPatterns[index].fRowData);
        this.fGrid.SetRowCellsFromPatterns(fRowCount + index, cellPatterns, index * this.fGrid.fColCount);
      }
      return num;
    }

    /// <summary>Adds the specified range of new rows to the grid.</summary>
    /// <param name="count">The number of the rows to add.</param>
    /// <returns>The index of the first added row.</returns>
    public int AddRange(int count)
    {
      return this.fGrid.AddRowRange(this.fGrid.fRowCount, count);
    }

    /// <summary>Creates new rows from the specified patterns and adds them to the grid.</summary>
    /// <param name="rowPatterns">The patterns to create the new rows from.</param>
    /// <returns>The index of the first added row.</returns>
    public int AddRange(iGRowPattern[] rowPatterns)
    {
      return this.InsertRange(this.fGrid.fRowCount, rowPatterns);
    }

    /// <summary>Inserts the specified range of new rows to the specified position.</summary>
    /// <param name="rowBefore">The zero-based index of the row to insert the new rows before.</param>
    /// <param name="count">The number of the rows to insert.</param>
    /// <returns>The index of the first added row.</returns>
    public int InsertRange(int rowBefore, int count)
    {
      return this.fGrid.AddRowRange(rowBefore, count);
    }

    /// <summary>Creates new rows from the specified patterns and inserts the rows to the specified position.</summary>
    /// <param name="rowBefore">The zero-based index of the row to insert the new rows before.</param>
    /// <param name="rowPatterns">The patterns to create the new rows from.</param>
    /// <returns>The index of the first added row.</returns>
    public int InsertRange(int rowBefore, iGRowPattern[] rowPatterns)
    {
      if (rowPatterns == null)
        throw new ArgumentNullException();
      for (int index = rowPatterns.Length - 1; index >= 0; --index)
      {
        if (rowPatterns[index] == null)
          throw new ArgumentException("Array element cannot be null");
      }
      int num = this.fGrid.AddRowRange(this.fGrid.fRowCount, rowPatterns.Length);
      for (int index = rowPatterns.Length - 1; index >= 0; --index)
        this.fGrid.SetRowData(index + rowBefore, rowPatterns[index].fRowData);
      return num;
    }

    /// <summary>Removes all the rows from the grid.</summary>
    public void Clear()
    {
      this.fGrid.ClearRows();
    }

    /// <summary>Removes the row with the specified index from the grid.</summary>
    /// <param name="rowIndex">The zero-based index of the row to remove.</param>
    public void RemoveAt(int rowIndex)
    {
      this.fGrid.RemoveRowRange(rowIndex, 1);
    }

    /// <summary>Removes the range of rows specified by the index of the first element and count.</summary>
    /// <param name="rowIndex">The zero-based index of the first row in the range to remove.</param>
    /// <param name="count">The number of the rows to remove.</param>
    public void RemoveRange(int rowIndex, int count)
    {
      this.fGrid.RemoveRowRange(rowIndex, count);
    }

    /// <summary>Adjusts the height of all the rows to display the contents of all the cells entirely.</summary>
    public void AutoHeight()
    {
      this.fGrid.AutoHeightRows();
    }

    /// <summary>Retrieves the row located at the specified coordinates. The coordinates are relative to the upper left corner of the grid.</summary>
    /// <param name="y">The Y-coordinate specifying the location of the row to retrieve.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGRow" /> object that represents the row at the specified coordinates or null (Nothing in VB) if there is no row.</returns>
    public iGRow FromY(int y)
    {
      int rowIndex;
      int rowY;
      int rowHeight;
      if (!this.fGrid.GetRowFromY(y, out rowIndex, out rowY, out rowHeight))
        return (iGRow) null;
      return new iGRow(this.fGrid, rowIndex);
    }

    /// <summary>Retrieves the row located at the specified coordinates and its coordinates. The coordinates are relative to the upper left corner of the grid.</summary>
    /// <param name="y">The Y-coordinate specifying the location of the row to retrieve. The coordinate is relative to the upper left corner of the grid.</param>
    /// <param name="rowY">The Y-coordinate of the retrieved row's top edge. The coordinate is relative to the upper left corner of the grid.</param>
    /// <param name="rowHeight">The height of the retrieved row.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGRow" /> object that represents the row at the specified coordinates or null (Nothing in VB) if there is no row.</returns>
    public iGRow FromY(int y, out int rowY, out int rowHeight)
    {
      int rowIndex;
      if (!this.fGrid.GetRowFromY(y, out rowIndex, out rowY, out rowHeight))
        return (iGRow) null;
      return new iGRow(this.fGrid, rowIndex);
    }

    /// <summary>Expands all the rows with a tree button.</summary>
    public void ExpandAll()
    {
      this.fGrid.ExpandCollapseAll(true);
    }

    /// <summary>Collapses all the rows with a tree button.</summary>
    public void CollapseAll()
    {
      this.fGrid.ExpandCollapseAll(false);
    }

    /// <summary>Returns a value indicating whether the specified key is attached to a row.</summary>
    /// <param name="key">The key to look for.</param>
    /// <returns>True if the grid has a row with the specified key; otherwise, False.</returns>
    public bool KeyExists(string key)
    {
      return this.fGrid.RowKeyExists(key);
    }

    /// <summary>Gets or sets the number of the rows in the grid.</summary>
    /// <value>A non-negative integer value.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int Count
    {
      get
      {
        return this.fGrid.fRowCount;
      }
      set
      {
        if (value < 0)
          throw new ArgumentOutOfRangeException();
        if (value < this.Count)
        {
          if (value > 0)
            this.fGrid.RemoveRowRange(value, this.Count - value);
          else
            this.fGrid.ClearRows();
        }
        else
        {
          if (value <= this.Count)
            return;
          this.AddRange(value - this.fGrid.fRowCount);
        }
      }
    }

    /// <summary>Gets the row with the specified index.</summary>
    /// <param name="index">The zero-based index of the row to retrieve.</param>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGRow" /> object that represents the retrieved row.</value>
    public iGRow this[int index]
    {
      get
      {
        return new iGRow(this.fGrid, index);
      }
    }

    /// <summary>Gets the row with the specified key.</summary>
    /// <param name="key">The key of the row to retrieve.</param>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGRow" /> object that represents the retrieved row.</value>
    public iGRow this[string key]
    {
      get
      {
        return new iGRow(this.fGrid, this.fGrid.RowKeyToIndex(key, true));
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return (IEnumerator) new iGEnumerator((IiGEnumerableCollection) this);
    }

    int IiGEnumerableCollection.Count
    {
      get
      {
        return this.Count;
      }
    }

    object IiGEnumerableCollection.this[int index]
    {
      get
      {
        return (object) this[index];
      }
    }
  }
}
