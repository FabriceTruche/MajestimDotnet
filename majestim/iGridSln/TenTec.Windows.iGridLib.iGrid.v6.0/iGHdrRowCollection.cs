// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGHdrRowCollection
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Collections;
using System.ComponentModel;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents the collection of the header rows in an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGHdrRowCollection : IEnumerable, IiGEnumerableCollection
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

    internal iGHdrRowCollection(iGrid grid)
    {
      this.fGrid = grid;
    }

    /// <summary>Adds a new header row to the header.</summary>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGHdrRow" /> object that represents the new header row.</returns>
    public iGHdrRow Add()
    {
      return new iGHdrRow(this.fGrid, this.fGrid.AddHeaderRows(1));
    }

    /// <summary>Adds a new header row with the specified height to the header.</summary>
    /// <param name="height">The height of the new header row.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGHdrRow" /> object that represents the new header row.</returns>
    public iGHdrRow Add(int height)
    {
      return new iGHdrRow(this.fGrid, this.fGrid.AddHeaderRows(1, new iGHdrRowPattern(height, true)));
    }

    /// <summary>Creates a new header row from the specified pattern, and adds it to the header.</summary>
    /// <param name="headerRowPattern">The pattern to create the new header row from.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGHdrRow" /> object that represents the new header row.</returns>
    public iGHdrRow Add(iGHdrRowPattern headerRowPattern)
    {
      return new iGHdrRow(this.fGrid, this.fGrid.AddHeaderRows(1, headerRowPattern));
    }

    /// <summary>Adds the specified amount of new header rows to the header.</summary>
    /// <param name="count">The number of the header rows to add.</param>
    /// <returns>The index of the first added header row.</returns>
    public int AddRange(int count)
    {
      return this.fGrid.AddHeaderRows(count);
    }

    /// <summary>Adds the specified amount of new header rows with the specified height to the header.</summary>
    /// <param name="count">The number of the header rows to add.</param>
    /// <param name="height">The height of the new header rows.</param>
    /// <returns>The index of the first added header row.</returns>
    public int AddRange(int count, int height)
    {
      return this.fGrid.AddHeaderRows(count, new iGHdrRowPattern(height, true));
    }

    /// <summary>Creates the specified amount of new header rows from the specified pattern, and adds them to the header.</summary>
    /// <param name="count">The number of the header rows to add.</param>
    /// <param name="headerRowPattern">The pattern to create the new header rows from.</param>
    /// <returns>The index of the first added header row.</returns>
    public int AddRange(int count, iGHdrRowPattern headerRowPattern)
    {
      return this.fGrid.AddHeaderRows(count, headerRowPattern);
    }

    /// <summary>Creates new header rows from the specified patters, and adds them to the header.</summary>
    /// <param name="headerRowPatterns">The patterns to create the new header rows from.</param>
    /// <returns>The index of the first added header row.</returns>
    public int AddRange(iGHdrRowPattern[] headerRowPatterns)
    {
      if (headerRowPatterns == null)
        throw new ArgumentNullException();
      for (int index = headerRowPatterns.Length - 1; index >= 0; --index)
      {
        if (headerRowPatterns[index] == null)
          throw new ArgumentException("Array element cannot be null");
      }
      int num = this.fGrid.AddHeaderRows(headerRowPatterns.Length);
      for (int rowIndex = num + headerRowPatterns.Length - 1; rowIndex >= num; --rowIndex)
        this.fGrid.SetHeaderRowDirect(rowIndex, headerRowPatterns[rowIndex - num].fData);
      this.fGrid.RefreshGridAndScrollBarsIfRedraw();
      return num;
    }

    /// <summary>Removes the row with the specified index from the header.</summary>
    /// <param name="rowIndex">The zero-based index of the header row to remove.</param>
    public void RemoveAt(int rowIndex)
    {
      this.fGrid.RemoveHeaderRowRange(rowIndex, 1);
    }

    /// <summary>Removes the range of header rows specified by the index of the first element and count.</summary>
    /// <param name="rowIndex">The zero-based index of the first header row in the range to remove.</param>
    /// <param name="count">The number of the rows to remove.</param>
    public void RemoveRange(int rowIndex, int count)
    {
      this.fGrid.RemoveHeaderRowRange(rowIndex, count);
    }

    /// <summary>Retrieves the header row that is located at the specified coordinates. The coordinates are relative to the upper left corner of the grid.</summary>
    /// <param name="y">The Y-coordinate specifying the location of the header row to retrieve.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGHdrRow" /> object that represents the header row at the specified coordinate, or null if there is no header row.</returns>
    public iGHdrRow FromY(int y)
    {
      int rowIndex;
      int rowY;
      int rowHeight;
      if (!this.fGrid.GetHeaderRowFromY(y, out rowIndex, out rowY, out rowHeight))
        return (iGHdrRow) null;
      return new iGHdrRow(this.fGrid, rowIndex);
    }

    /// <summary>Retrieves the header row that is located at the specified coordinates and its coordinates. The coordinates are relative to the upper left corner of the grid.</summary>
    /// <param name="y">The Y-coordinate specifying the location of the header row to retrieve.</param>
    /// <param name="rowY">The Y-coordinate of the retrieved header row's top edge.</param>
    /// <param name="rowHeight">The height of the retrieved header row.</param>
    /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGHdrRow" /> object that represents the header row at the specified coordinate, or null if there is no header row.</returns>
    public iGHdrRow FromY(int y, out int rowY, out int rowHeight)
    {
      int rowIndex;
      if (!this.fGrid.GetHeaderRowFromY(y, out rowIndex, out rowY, out rowHeight))
        return (iGHdrRow) null;
      return new iGHdrRow(this.fGrid, rowIndex);
    }

    /// <summary>Gets or sets the number of the header rows in the grid.</summary>
    /// <value>The number of the header rows. The default is 1.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int Count
    {
      get
      {
        return this.fGrid.fHeaderRowCount;
      }
      set
      {
        if (value < 1)
          throw new ArgumentOutOfRangeException();
        this.fGrid.SetHeaderRowCount(value);
      }
    }

    /// <summary>Gets the header row with the specified index.</summary>
    /// <param name="index">The zero-based index of the header row to retrieve.</param>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGHdrRow" /> object that represents the header row with the specified index.</value>
    public iGHdrRow this[int index]
    {
      get
      {
        return new iGHdrRow(this.fGrid, index);
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
