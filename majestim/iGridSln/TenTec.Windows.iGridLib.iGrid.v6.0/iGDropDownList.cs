// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGDropDownList
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Text;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents a drop-down list that can be used to edit cells in <see cref="T:TenTec.Windows.iGridLib.iGrid" />.</summary>
  [ToolboxBitmap(typeof (iGrid), "Resources.ToolBoxiGDropDownList.bmp")]
  [Description("The iGrid built-in drop-down list control. Stores value lists used to edit the iGrid cells.")]
  //[Designer("TenTec.Windows.iGridLib.Design.iGDropDownListDesigner, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
  [Designer("TenTec.Windows.iGridLib.Design.iGDropDownListDesigner")]
    public class iGDropDownList : Component, IiGAutoCompleteControl, IiGDropDownControl
  {
    private bool fAllValuesComparable = true;
    private int fMaxVisibleRowCount = 8;
    private bool fACLSelFirstWhenFilter = true;
    private bool fAutoSubstitution = true;
    private int fMinWidth = 10;
    private int fWidth = -1;
    private Color fSelItemBackColor = Color.Empty;
    private bool fAdjustHeightBeforeShow = true;
    private iGContentAlignment fTextAlign = iGContentAlignment.MiddleLeft;
    private iGContentAlignment fImageAlign = iGContentAlignment.MiddleLeft;
    private const int cDefaultMaxVisibleRowCount = 8;
    private const bool cDefaultACLSelFirstWhenFilter = true;
    private const bool cDefaultAutoSubstitution = true;
    private const bool cDefaultAutoSubstitutionCustomCompare = false;
    private const int cDefaultMinWidth = 10;
    private const bool cDefaultAutoWidth = false;
    private const iGContentAlignment cDefaultTextAlign = iGContentAlignment.MiddleLeft;
    private const iGContentAlignment cDefaultImageAlign = iGContentAlignment.MiddleLeft;
    private const iGTextPosToImage cDefaultTextPosToImage = iGTextPosToImage.Horizontally;
    private const int cInitialSortedListCapacity = 16;
    private iGDropDownListItem[] fSortedList;
    private bool fIsSortedListSorted;
    private int fSortedListItemCount;
    private iGrid fGridList;
    private iGrid fParentGrid;
    private bool fAutoSubstitutionCustomCompare;
    private iGDropDownList.iGDropDownListItemCollection fCollection;
    private ImageList fImageList;
    private Font fFont;
    private Color fForeColor;
    private Color fBackColor;
    private Color fSelItemForeColor;
    private Type fInterfaceType;
    private iGDropDownList.iGSearchAsType fSearchAsType;
    private bool fGridIsUpdating;
    private bool fAdjustWidthBeforeShow;
    private bool fAutoWidth;
    private int fRowHeight;
    private Point fLastMousePos;
    private iGTextPosToImage fTextPosToImage;
    private iGAutoCompleteControlValueSelectedEventHandler fValueSelected;

    /// <summary>Releases all resources used by the object.</summary>
    /// <param name="disposing">If this parameter equals True, the method has been called directly or indirectly by a user's code. If this parameter equals False, the method has been called by the runtime from inside the finalizer and you should not reference other objects.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && this.fGridList != null)
      {
        this.fGridList.Dispose();
        this.fGridList = (iGrid) null;
      }
      base.Dispose(disposing);
    }

    internal void OnItemValueChanged(iGDropDownListItem item)
    {
      this.SortedList_OnItemValueChanged(item);
      this.Grid_OnItemValueChanged(item);
    }

    internal void OnItemTextChanged(iGDropDownListItem item)
    {
      this.Grid_OnItemTextChanged(item);
    }

    internal void OnItemPropertyChanged(iGDropDownListItem item)
    {
      this.Grid_OnItemPropertyChanged(item);
    }

    /// <summary>Raises the <see cref="E:TenTec.Windows.iGridLib.iGDropDownList.SelectedItemChanged" /> event.</summary>
    /// <param name="e">A <see cref="T:TenTec.Windows.iGridLib.iGSelectedItemChangedEventArgs" /> that contains the event data.</param>
    protected virtual void OnSelectedItemChanged(iGSelectedItemChangedEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.SelectedItemChanged == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.SelectedItemChanged((object) this, e);
    }

    private bool DoSearchAsTypeCustomCompare(iGDropDownListItem item, string searchText)
    {
      iGDropDownListCustomCompareEventArgs e = new iGDropDownListCustomCompareEventArgs(item, searchText);
      this.OnSearchAsTypeCustomCompare(e);
      return e.Match;
    }

    /// <summary>Raises the <see cref="E:TenTec.Windows.iGridLib.iGDropDownList.SearchAsTypeCustomCompare" /> event.</summary>
    /// <param name="e">An <see cref="T:TenTec.Windows.iGridLib.iGDropDownListCustomCompareEventArgs" /> that contains the event data.</param>
    protected virtual void OnSearchAsTypeCustomCompare(iGDropDownListCustomCompareEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.SearchAsTypeCustomCompare == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.SearchAsTypeCustomCompare((object) this, e);
    }

    private bool DoGetItemByTextCustomCompare(iGDropDownListItem item, string searchText)
    {
      iGDropDownListCustomCompareEventArgs e = new iGDropDownListCustomCompareEventArgs(item, searchText);
      this.OnGetItemByTextCustomCompare(e);
      return e.Match;
    }

    /// <summary>Raises the <see cref="E:TenTec.Windows.iGridLib.iGDropDownList.GetItemByTextCustomCompare" /> event.</summary>
    /// <param name="e">An <see cref="T:TenTec.Windows.iGridLib.iGDropDownListCustomCompareEventArgs" /> that contains the event data.</param>
    protected virtual void OnGetItemByTextCustomCompare(iGDropDownListCustomCompareEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.GetItemByTextCustomCompare == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.GetItemByTextCustomCompare((object) this, e);
    }

    private void AdjustSearchAsType()
    {
      if (this.fSearchAsType != null)
        return;
      this.fSearchAsType = new iGDropDownList.iGSearchAsType(this);
    }

    /// <summary>Populates the drop-down list with the values from the specified data source.</summary>
    /// <param name="dataSource">A <see cref="T:System.Data.DataTable" />, <see cref="T:System.Data.DataView" />, <see cref="T:System.Data.IDbCommand" />, or <see cref="T:System.Data.IDataReader" /> object to populate the grid with.</param>
    /// <param name="itemValueCol">The name of the column to read the values from.</param>
    public void FillWithData(object dataSource, string itemValueCol)
    {
      if (dataSource == null || string.IsNullOrEmpty(itemValueCol))
        throw new ArgumentNullException();
      if (dataSource is DataTable)
        this.FillWithData((DataTable) dataSource, itemValueCol, (string) null);
      else if (dataSource is DataView)
        this.FillWithData((DataView) dataSource, itemValueCol, (string) null);
      else if (dataSource is IDataReader)
      {
        this.FillWithData((IDataReader) dataSource, itemValueCol, (string) null);
      }
      else
      {
        if (!(dataSource is IDbCommand))
          throw new ArgumentException("The specified data source isn't supported", nameof (dataSource));
        this.FillWithData((IDbCommand) dataSource, itemValueCol, (string) null);
      }
    }

    /// <summary>Populates the drop-down list with the values and texts from the specified data source.</summary>
    /// <param name="dataSource">A <see cref="T:System.Data.DataTable" />, <see cref="T:System.Data.DataView" />, <see cref="T:System.Data.IDbCommand" />, or <see cref="T:System.Data.IDataReader" /> object to populate the grid with.</param>
    /// <param name="itemValueCol">The name of the column to read the values from.</param>
    /// <param name="itemTextCol">The name of the column to read the texts from.</param>
    public void FillWithData(object dataSource, string itemValueCol, string itemTextCol)
    {
      if (dataSource == null || string.IsNullOrEmpty(itemValueCol) || string.IsNullOrEmpty(itemTextCol))
        throw new ArgumentNullException();
      if (dataSource is DataTable)
        this.FillWithData((DataTable) dataSource, itemValueCol, itemTextCol);
      else if (dataSource is DataView)
        this.FillWithData((DataView) dataSource, itemValueCol, itemTextCol);
      else if (dataSource is IDataReader)
      {
        this.FillWithData((IDataReader) dataSource, itemValueCol, itemTextCol);
      }
      else
      {
        if (!(dataSource is IDbCommand))
          throw new ArgumentException("The specified data source isn't supported", nameof (dataSource));
        this.FillWithData((IDbCommand) dataSource, itemValueCol, itemTextCol);
      }
    }

    private void FillWithData(DataTable dataTable, string itemValueCol, string itemTextCol)
    {
      if (!dataTable.Columns.Contains(itemValueCol))
        throw new ArgumentException();
      if (itemTextCol != null && !dataTable.Columns.Contains(itemTextCol))
        throw new ArgumentException();
      this.FillWithData(new DataView(dataTable, (string) null, (string) null, DataViewRowState.CurrentRows), itemValueCol, itemTextCol);
    }

    private void FillWithData(DataView dataView, string itemValueCol, string itemTextCol)
    {
      if (!dataView.Table.Columns.Contains(itemValueCol))
        throw new ArgumentException();
      if (itemTextCol != null && !dataView.Table.Columns.Contains(itemTextCol))
        throw new ArgumentException();
      DataColumn column = dataView.Table.Columns[itemValueCol];
      DataColumn dataColumn = itemTextCol == null ? (DataColumn) null : dataView.Table.Columns[itemTextCol];
      this.Items.Clear();
      foreach (DataRowView dataRowView in dataView)
      {
        iGDropDownListItem gdropDownListItem = new iGDropDownListItem();
        gdropDownListItem.Value = dataRowView[column.Ordinal];
        if (dataColumn != null)
        {
          object obj = dataRowView[dataColumn.Ordinal];
          if (obj != null)
            gdropDownListItem.Text = obj.ToString();
        }
        this.Items.Add(gdropDownListItem);
      }
    }

    private void FillWithData(IDataReader dataReader, string itemValueCol, string itemTextCol)
    {
      int i1 = -1;
      int i2 = -1;
      DataTable schemaTable = dataReader.GetSchemaTable();
      for (int index = 0; index < schemaTable.Rows.Count; ++index)
      {
        string strA = schemaTable.Rows[index]["ColumnName"] as string;
        if (strA == itemValueCol)
        {
          i1 = index;
          if (itemTextCol == null)
            break;
        }
        else if (itemTextCol != null && string.Compare(strA, itemTextCol, true) == 0)
        {
          i2 = index;
          if (i1 >= 0)
            break;
        }
      }
      if (i1 < 0)
        throw new ArgumentException();
      if (itemTextCol != null && i2 < 0)
        throw new ArgumentException();
      this.Items.Clear();
      while (dataReader.Read())
      {
        iGDropDownListItem gdropDownListItem = new iGDropDownListItem();
        gdropDownListItem.Value = dataReader.GetValue(i1);
        if (i2 >= 0)
        {
          object obj = dataReader.GetValue(i2);
          gdropDownListItem.Text = obj.ToString();
        }
        this.Items.Add(gdropDownListItem);
      }
    }

    private void FillWithData(IDbCommand command, string itemValueCol, string itemTextCol)
    {
      IDataReader dataReader = command.ExecuteReader();
      try
      {
        this.FillWithData(dataReader, itemValueCol, itemTextCol);
      }
      finally
      {
        dataReader.Close();
      }
    }

    Control IiGDropDownControl.GetDropDownControl(iGrid grid, Font font, Type interfaceType)
    {
      this.fParentGrid = grid;
      this.Grid_Adjust();
      this.Grid_SetParentLook(grid);
      this.Grid_SetColors(grid);
      this.Grid_SetRowsVisibilityAccordingToDropDownItems();
      this.Grid_PrepareToShow();
      Font font1 = this.fGridList.Font;
      if (this.fFont != null)
        this.Grid_SetFont(this.fFont);
      else
        this.Grid_SetFont(font);
      this.Grid_SetImageList(this.fImageList);
      this.Grid_SetRightToLeft(grid.RightToLeft);
      this.Grid_SetImageTextAlign(grid.CurCell);
      if (this.fGridList.Font != font1)
      {
        this.Grid_AdjustRowsHeight();
        if (this.fAutoWidth)
          this.Grid_AutoWidth();
      }
      else
      {
        if (this.fAdjustHeightBeforeShow)
          this.Grid_AdjustRowsHeight();
        if (this.fAdjustWidthBeforeShow)
          this.Grid_AutoWidth();
      }
      this.Grid_SetUIStrings(grid.UIStrings.SearchWindowLabelNext, grid.UIStrings.SearchWindowLabelPrev);
      this.AdjustSearchAsType();
      if (interfaceType == typeof (IiGDropDownControl))
        this.Grid_AdjustForParticularInterface(false, this.fSearchAsType.fDropDownMode, false, this.fSearchAsType.fDisplaySearchTextIfNeeded, this.fSearchAsType.fDropDownMode == iGSearchAsTypeMode.Seek && this.fSearchAsType.fDisplayKeyboardHintIfNeeded);
      else if (interfaceType == typeof (IiGAutoCompleteControl))
        this.Grid_AdjustForParticularInterface(true, this.fSearchAsType.fAutoCompleteMode, !this.ACLSelFirstWhenFilter, false, this.fSearchAsType.fAutoCompleteMode == iGSearchAsTypeMode.Seek && this.fSearchAsType.fDisplayKeyboardHintIfNeeded);
      this.fInterfaceType = interfaceType;
      return (Control) this.fGridList;
    }

    object IiGDropDownControl.GetItemByValue(object value, bool firstByOrder)
    {
      if (firstByOrder)
        return (object) this.Grid_GetItemByValue(value);
      return (object) this.SortedList_GetItemByValue(value);
    }

    object IiGDropDownControl.GetItemByText(string text)
    {
      return (object) this.Grid_GetItemByText(text, true);
    }

    int IiGDropDownControl.GetItemImageIndex(object item)
    {
      if (item == null)
        throw new ArgumentNullException();
      iGDropDownListItem gdropDownListItem = item as iGDropDownListItem;
      if (gdropDownListItem == null)
        return -1;
      return gdropDownListItem.ImageIndex;
    }

    object IiGDropDownControl.GetItemValue(object item)
    {
      if (item == null)
        throw new ArgumentNullException();
      iGDropDownListItem gdropDownListItem = item as iGDropDownListItem;
      if (gdropDownListItem == null)
        return (object) null;
      return gdropDownListItem.Value;
    }

    void IiGDropDownControl.SetTextRenderingHint(TextRenderingHint textRenderingHint)
    {
      this.fGridList.TextRenderingHint = textRenderingHint;
    }

    void IiGDropDownControl.OnShowing()
    {
    }

    void IiGDropDownControl.OnShow()
    {
      this.fLastMousePos = Control.MousePosition;
      if (!(this.fInterfaceType == typeof (IiGAutoCompleteControl)))
        return;
      this.AdjustSearchAsType();
      this.Grid_SetSearchText(this.fSearchAsType.fAutoCompleteSearchText);
    }

    void IiGDropDownControl.OnHide()
    {
      if (this.fInterfaceType == typeof (IiGAutoCompleteControl))
      {
        this.AdjustSearchAsType();
        this.fSearchAsType.fAutoCompleteSearchText = (string) null;
      }
      this.Grid_SetSearchText((string) null);
    }

    bool IiGAutoCompleteControl.OnCellTextChange(string text)
    {
      this.AdjustSearchAsType();
      if (this.fSearchAsType.fAutoCompleteMode == iGSearchAsTypeMode.Filter)
        this.Grid_SetSelectedItem((iGDropDownListItem) null);
      this.fSearchAsType.fAutoCompleteSearchText = text;
      bool flag = this.Grid_SetSearchText(this.fSearchAsType.fAutoCompleteSearchText);
      if (this.fSearchAsType.fAutoCompleteSearchText == null || this.fSearchAsType.fAutoCompleteSearchText.Length == 0)
        return false;
      this.Grid_PrepareToShow();
      return flag;
    }

    void IiGAutoCompleteControl.ProcessKeyDown(KeyEventArgs e)
    {
      switch (e.KeyData)
      {
        case Keys.Tab | Keys.Shift:
        case Keys.Up:
          this.Grid_PrevRow();
          break;
        case Keys.Up | Keys.Alt:
          this.Grid_PrevMatchingRow();
          break;
        case Keys.Down | Keys.Alt:
          this.Grid_NextMatchingRow();
          break;
        case Keys.Return:
          iGDropDownListItem selectedItem = this.Grid_GetSelectedItem();
          if (selectedItem == null)
            return;
          if (this.fValueSelected != null)
          {
            this.fValueSelected((object) this, new iGAutoCompleteControlValueSelectedEventArgs(selectedItem.Value));
            break;
          }
          break;
        case Keys.Down:
          this.Grid_NextRow();
          break;
        default:
          return;
      }
      e.Handled = true;
    }

    void IiGAutoCompleteControl.ProcessKeyUp(KeyEventArgs e)
    {
    }

    void IiGAutoCompleteControl.ProcessKeyPress(KeyPressEventArgs e)
    {
    }

    private void SortedList_Adjust()
    {
      if (this.fSortedList != null)
        return;
      this.fSortedList = new iGDropDownListItem[16];
    }

    private iGDropDownListItem SortedList_GetItemByValue(object value)
    {
      int indexOf = this.SortedList_GetIndexOf(new iGDropDownListItem(value), true);
      if (indexOf < 0)
        return (iGDropDownListItem) null;
      return this.fSortedList[indexOf];
    }

    private int SortedList_GetIndexOf(iGDropDownListItem item, bool searchForValueOnly)
    {
      if (item == null)
        throw new ArgumentNullException();
      this.SortedList_Adjust();
      if (this.fAllValuesComparable)
      {
        if (!this.fIsSortedListSorted)
        {
          Array.Sort<iGDropDownListItem>(this.fSortedList, 0, this.fSortedListItemCount);
          this.fIsSortedListSorted = true;
        }
        int index = Array.BinarySearch<iGDropDownListItem>(this.fSortedList, 0, this.fSortedListItemCount, item);
        if (searchForValueOnly || index < 0)
          return index;
        while (index > 0 && ((IComparable) this.fSortedList[index - 1]).CompareTo((object) item) == 0)
          --index;
        while (this.fSortedList[index] != item)
        {
          ++index;
          if (index >= this.fSortedListItemCount || ((IComparable) this.fSortedList[index]).CompareTo((object) item) != 0)
            return ~index;
        }
        return index;
      }
      if (searchForValueOnly)
      {
        for (int index = 0; index < this.fSortedListItemCount; ++index)
        {
          if (this.fSortedList[index].Value.Equals(item.Value))
            return index;
        }
      }
      else
      {
        for (int index = 0; index < this.fSortedListItemCount; ++index)
        {
          if (this.fSortedList[index] == item)
            return index;
        }
      }
      return -1;
    }

    private void SortedList_AddItem(iGDropDownListItem item)
    {
      if (item == null)
        throw new ArgumentNullException();
      this.SortedList_Adjust();
      if (this.fSortedList.Length == this.fSortedListItemCount)
        this.fSortedList = iGArrayManager.ExtendArray((Array) this.fSortedList, typeof (iGDropDownListItem), this.fSortedListItemCount, 1, this.fSortedListItemCount, false) as iGDropDownListItem[];
      this.fSortedList[this.fSortedListItemCount] = item;
      this.fSortedListItemCount = this.fSortedListItemCount + 1;
      this.fIsSortedListSorted = false;
      if (item.Value is IComparable)
        return;
      this.fAllValuesComparable = false;
    }

    private void SortedList_RemoveItem(iGDropDownListItem item)
    {
      if (item == null)
        throw new ArgumentNullException();
      int indexOf = this.SortedList_GetIndexOf(item, false);
      if (indexOf < 0)
        throw new ArgumentException();
      this.fSortedList = iGArrayManager.ShortenArray((Array) this.fSortedList, typeof (iGDropDownListItem), indexOf, 1, this.fSortedListItemCount, false) as iGDropDownListItem[];
      this.fSortedList[this.fSortedListItemCount - 1] = (iGDropDownListItem) null;
      this.fSortedListItemCount = this.fSortedListItemCount - 1;
    }

    private void SortedList_Clear()
    {
      for (int index = this.fSortedListItemCount - 1; index >= 0; --index)
        this.fSortedList[index] = (iGDropDownListItem) null;
      this.fSortedListItemCount = 0;
    }

    private void SortedList_OnItemValueChanged(iGDropDownListItem item)
    {
      if (item == null)
        throw new ArgumentNullException();
      this.fIsSortedListSorted = false;
    }

    private void Grid_Adjust()
    {
      if (this.fGridList != null)
        return;
      this.fGridList = new iGrid();
      this.fGridList.BorderStyle = iGBorderStyle.None;
      this.fGridList.GridLines.Mode = iGGridLinesMode.None;
      this.fGridList.Header.Visible = false;
      this.fGridList.ReadOnly = true;
      this.fGridList.CellMouseDown += new iGCellMouseDownEventHandler(this.Grid_CellMouseDown);
      this.fGridList.CellMouseMove += new iGCellMouseMoveEventHandler(this.Grid_CellMouseMove);
      this.fGridList.CurCellChanged += new EventHandler(this.Grid_CurCellChanged);
      this.fGridList.KeyDown += new KeyEventHandler(this.Grid_KeyDown);
      this.fGridList.DrawAsFocused = true;
      this.fGridList.FocusRect = false;
      this.fGridList.ImageList = this.fImageList;
      iGCol iGcol = this.fGridList.Cols.Add();
      this.fGridList.AutoResizeCols = true;
      this.fGridList.SearchAsType.SearchCol = iGcol;
      this.fGridList.SearchAsType.AutoCancel = false;
      this.fGridList.SearchAsType.MatchRule = iGMatchRule.Custom;
      this.fGridList.SearchAsTypeCustomCompare += new iGSearchAsTypeCustomCompareEventHandler(this.Grid_SearchAsTypeCustomCompare);
      this.fGridList.SearchAsTypeRowSetChanged += new EventHandler(this.Grid_SearchAsTypeRowSetChanged);
    }

    private void Grid_SearchAsTypeRowSetChanged(object sender, EventArgs e)
    {
      if (!(this.fInterfaceType == typeof (IiGDropDownControl)) || this.fParentGrid == null)
        return;
      this.fParentGrid.UpdateDropDownLocationAndSize();
    }

    private void Grid_SearchAsTypeCustomCompare(object sender, iGSearchAsTypeCustomCompareEventArgs e)
    {
      iGDropDownListItem gdropDownListItem = this.Grid_GetItem(e.RowIndex);
      if (!gdropDownListItem.Visible)
      {
        e.Match = false;
      }
      else
      {
        this.AdjustSearchAsType();
        switch (this.fSearchAsType.fMatchRule)
        {
          case iGMatchRule.StartsWith:
            if (e.SearchText == null || e.SearchText.Length == 0)
            {
              e.Match = true;
              break;
            }
            e.Match = this.Grid_GetCellTextUpper(e.RowIndex, e.ColIndex).StartsWith(e.SearchText.ToUpper());
            break;
          case iGMatchRule.Contains:
            if (e.SearchText == null || e.SearchText.Length == 0)
            {
              e.Match = true;
              break;
            }
            e.Match = this.Grid_GetCellTextUpper(e.RowIndex, e.ColIndex).Contains(e.SearchText.ToUpper());
            break;
          case iGMatchRule.Custom:
            e.Match = this.DoSearchAsTypeCustomCompare(gdropDownListItem, e.SearchText);
            break;
        }
      }
    }

    private string Grid_GetCellTextUpper(int rowIndex, int colIndex)
    {
      string text = this.fGridList.Cells[rowIndex, colIndex].Text;
      if (text == null)
        return string.Empty;
      return text.ToUpper();
    }

    private void Grid_PrepareToModify()
    {
      this.Grid_Adjust();
      if (this.fGridIsUpdating)
        return;
      this.fGridList.BeginUpdate();
      this.fGridIsUpdating = true;
    }

    private void Grid_PrepareToShow()
    {
      this.Grid_Adjust();
      if (!this.fGridIsUpdating)
        return;
      this.fGridList.EndUpdate();
      this.fGridIsUpdating = false;
    }

    private void Grid_SetRightToLeft(RightToLeft value)
    {
      this.Grid_Adjust();
      this.fGridList.RightToLeft = value;
    }

    private void Grid_SetImageTextAlign(iGCell curCell)
    {
      iGCellStyle cellStyle = this.fGridList.Cols[0].CellStyle;
      if (this.fTextAlign != iGContentAlignment.NotSet)
        cellStyle.TextAlign = this.fTextAlign;
      else
        cellStyle.TextAlign = curCell != null ? curCell.EffectiveTextAlign : iGContentAlignment.MiddleLeft;
      if (this.fImageAlign != iGContentAlignment.NotSet)
        cellStyle.ImageAlign = this.fImageAlign;
      else
        cellStyle.ImageAlign = curCell != null ? curCell.EffectiveImageAlign : iGContentAlignment.MiddleLeft;
      if (this.fTextPosToImage != iGTextPosToImage.NotSet)
        cellStyle.TextPosToImage = this.fTextPosToImage;
      else
        cellStyle.TextPosToImage = curCell != null ? curCell.EffectiveTextPosToImage : iGTextPosToImage.Horizontally;
    }

    private void Grid_SetImageList(ImageList imageList)
    {
      this.Grid_Adjust();
      this.fGridList.ImageList = imageList;
    }

    private void Grid_SetFont(Font value)
    {
      this.Grid_Adjust();
      this.fGridList.Font = value;
      this.fAdjustHeightBeforeShow = true;
    }

    private void Grid_AdjustForParticularInterface(bool doNotFocusOnMouseDown, iGSearchAsTypeMode searchAsTypeMode, bool searchAsTypeFilterOnly, bool searchAsTypeDisplaySearchText, bool searchAsTypeDisplayKeyboardHint)
    {
      this.Grid_Adjust();
      this.fGridList.DoNotFocusOnMouseDown = doNotFocusOnMouseDown;
      this.fGridList.SearchAsType.Mode = searchAsTypeMode;
      this.fGridList.SearchAsType.FilterKeepCurRow = searchAsTypeFilterOnly;
      this.fGridList.SearchAsType.DisplaySearchText = searchAsTypeDisplaySearchText;
      this.fGridList.SearchAsType.DisplayKeyboardHint = searchAsTypeDisplayKeyboardHint;
    }

    private void Grid_SetRow(int index, iGDropDownListItem item)
    {
      this.Grid_Adjust();
      if (item == null)
        throw new ArgumentNullException();
      if (index < 0 || index >= this.fGridList.Rows.Count)
        throw new ArgumentOutOfRangeException();
      this.Grid_PrepareToModify();
      this.fGridList.SetCellDataInternal(index, 1, new iGCellData((object) item, item.ImageIndex));
      this.fGridList.Rows[index].Visible = item.Visible;
      iGCell cell = this.fGridList.Cells[index, 0];
      if (!item.Selectable)
        cell.Selectable = iGBool.False;
      Color color = item.BackColor;
      if (!color.IsEmpty)
        cell.BackColor = item.BackColor;
      color = item.ForeColor;
      if (!color.IsEmpty)
        cell.ForeColor = item.ForeColor;
      this.fAdjustHeightBeforeShow = true;
      this.fAdjustWidthBeforeShow = this.fAutoWidth;
    }

    private int Grid_AddRow(iGDropDownListItem item)
    {
      if (item == null)
        throw new ArgumentNullException();
      this.Grid_PrepareToModify();
      int index = this.fGridList.Rows.Add().Index;
      this.Grid_SetRow(index, item);
      item.fDropDownList = this;
      return index;
    }

    private void Grid_InsertRow(int rowBefore, iGDropDownListItem item)
    {
      this.Grid_Adjust();
      if (rowBefore < 0 || rowBefore > this.fGridList.Rows.Count)
        throw new ArgumentOutOfRangeException();
      if (item == null)
        throw new ArgumentNullException();
      this.Grid_PrepareToModify();
      this.fGridList.Rows.Insert(rowBefore);
      this.Grid_SetRow(rowBefore, item);
      item.fDropDownList = this;
    }

    private void Grid_Clear()
    {
      this.Grid_Adjust();
      for (int rowIndex = this.fGridList.Rows.Count - 1; rowIndex >= 0; --rowIndex)
        (this.fGridList.GetCellDataInternal(rowIndex, 1).Value as iGDropDownListItem).fDropDownList = (iGDropDownList) null;
      this.Grid_PrepareToModify();
      this.fGridList.Rows.Clear();
      this.fAdjustWidthBeforeShow = this.fAutoWidth;
      this.fAdjustHeightBeforeShow = true;
    }

    private int Grid_GetCount()
    {
      if (this.fGridList == null)
        return 0;
      return this.fGridList.Rows.Count;
    }

    private bool Grid_SetSearchText(string text)
    {
      this.Grid_Adjust();
      this.fGridList.SearchAsType.SearchText = text;
      return this.fGridList.SearchAsType.HasMatches;
    }

    private int Grid_GetItemIndex(iGDropDownListItem item)
    {
      if (item == null)
        throw new ArgumentNullException();
      this.Grid_Adjust();
      for (int rowIndex = this.fGridList.Rows.Count - 1; rowIndex >= 0; --rowIndex)
      {
        if (this.fGridList.GetCellDataInternal(rowIndex, 1).Value == item)
          return rowIndex;
      }
      return -1;
    }

    private void Grid_CopyTo(Array array, int index)
    {
      this.Grid_Adjust();
      if (array == null)
        throw new ArgumentNullException();
      if (index < 0)
        throw new ArgumentOutOfRangeException();
      if (array.Rank != 1 || this.fGridList.Rows.Count > array.Length - index)
        throw new ArgumentException();
      if (!array.GetType().GetElementType().IsAssignableFrom(typeof (iGDropDownListItem)))
        throw new InvalidCastException();
      for (int rowIndex = this.fGridList.Rows.Count - 1; rowIndex >= 0; --rowIndex)
        array.SetValue((object) (this.fGridList.GetCellDataInternal(rowIndex, 1).Value as iGDropDownListItem), index + rowIndex);
    }

    private void Grid_RemoveAt(int index)
    {
      this.Grid_Adjust();
      if (index < 0 || index >= this.fGridList.Rows.Count)
        throw new ArgumentOutOfRangeException();
      this.Grid_PrepareToModify();
      (this.fGridList.GetCellDataInternal(index, 1).Value as iGDropDownListItem).fDropDownList = (iGDropDownList) null;
      this.fGridList.Rows.RemoveAt(index);
      this.fAdjustWidthBeforeShow = this.fAutoWidth;
      this.fAdjustHeightBeforeShow = true;
    }

    private iGDropDownListItem Grid_GetItem(int index)
    {
      this.Grid_Adjust();
      if (index < 0 || index >= this.fGridList.Rows.Count)
        throw new ArgumentOutOfRangeException();
      return this.fGridList.GetCellDataInternal(index, 1).Value as iGDropDownListItem;
    }

    private void Grid_OnItemValueChanged(iGDropDownListItem item)
    {
      if (item == null)
        throw new ArgumentNullException();
      this.fAdjustHeightBeforeShow = true;
      this.fAdjustWidthBeforeShow = this.fAutoWidth;
      if (this.fGridList == null)
        return;
      this.fGridList.Invalidate();
    }

    private void Grid_OnItemTextChanged(iGDropDownListItem item)
    {
      if (item == null)
        throw new ArgumentNullException();
      this.fAdjustHeightBeforeShow = true;
      this.fAdjustWidthBeforeShow = this.fAutoWidth;
      if (this.fGridList == null)
        return;
      this.fGridList.Invalidate();
    }

    private void Grid_OnItemPropertyChanged(iGDropDownListItem item)
    {
      if (item == null)
        throw new ArgumentNullException();
      if (item.fDropDownList != this)
        throw new ArgumentException();
      this.Grid_SetRow(this.Grid_GetItemIndex(item), item);
    }

    private void Grid_CellMouseDown(object sender, iGCellMouseDownEventArgs e)
    {
      if (!(this.fGridList.Cells[e.RowIndex, e.ColIndex].Value as iGDropDownListItem).Selectable)
        return;
      if (this.fInterfaceType == typeof (IiGDropDownControl))
      {
        if (this.fParentGrid == null)
          return;
        this.fGridList.SetCurCell(e.RowIndex, e.ColIndex);
        this.fParentGrid.CommitAnyEdit();
      }
      else
      {
        if (!(this.fInterfaceType == typeof (IiGAutoCompleteControl)) || this.fValueSelected == null)
          return;
        this.fValueSelected((object) this, new iGAutoCompleteControlValueSelectedEventArgs(this.Grid_GetItem(e.RowIndex).Value));
      }
    }

    private void Grid_ClearCurCell()
    {
      this.Grid_Adjust();
      if (this.fGridList.CurCell != null)
        this.fGridList.CurCell = (iGCell) null;
      else
        this.Grid_DoSelectedItemChanged();
    }

    private void Grid_GetRowsParams(iGCellStyle colStyle, out bool hasText, out bool hasImage, out int multilineHeight)
    {
      hasImage = false;
      hasText = false;
      multilineHeight = -1;
      for (int rowIndex = this.fGridList.Rows.Count - 1; rowIndex >= 0; --rowIndex)
      {
        iGCellData cellDataInternal = this.fGridList.GetCellDataInternal(rowIndex, 1);
        if (!hasImage && this.fImageList != null)
          hasImage = cellDataInternal.ImageIndex >= 0 && cellDataInternal.ImageIndex < this.fImageList.Images.Count;
        if (cellDataInternal.Value != null)
        {
          hasText = true;
          if (this.fGridList.GetUniCellTextInternal(iGGridSection.Cells, rowIndex, 1, cellDataInternal.Value, (object) null, cellDataInternal.ImageIndex, (iGStyleBase) null, (iGStyleBase) null, (iGStyleBase) colStyle).IndexOf('\n') >= 0)
          {
            int num = this.fGridList.AutoHeightRow(rowIndex);
            if (num > multilineHeight)
              multilineHeight = num;
          }
        }
      }
    }

    private void Grid_AdjustRowsHeight()
    {
      this.fGridList.BeginUpdate();
      try
      {
        bool hasText;
        bool hasImage;
        int multilineHeight;
        this.Grid_GetRowsParams(this.fGridList.Cols[0].CellStyle, out hasText, out hasImage, out multilineHeight);
        int preferredRowHeight = this.fGridList.GetPreferredRowHeight(hasText, hasImage);
        int num = Math.Max(multilineHeight, preferredRowHeight);
        if (num == this.fRowHeight)
          return;
        this.fRowHeight = num;
        this.fGridList.VScrollBar.SmallChange = this.fRowHeight;
        for (int rowIndex = this.fGridList.Rows.Count - 1; rowIndex >= 0; --rowIndex)
          this.fGridList.SetRowHeight(rowIndex, this.fRowHeight);
      }
      finally
      {
        this.fGridList.EndUpdate();
      }
      this.fAdjustHeightBeforeShow = false;
    }

    private void Grid_AutoWidth()
    {
      this.fGridList.BeginUpdate();
      try
      {
        this.fGridList.Height = ((IiGDropDownControl) this).Height;
        this.fGridList.AutoResizeCols = false;
        this.fGridList.Cols[0].AutoWidth();
        this.fWidth = this.fGridList.Cols[0].Width + 2 * this.fGridList.BorderWidth;
        if (this.fGridList.VScrollBar.Visible)
          this.fWidth = this.fWidth + this.fGridList.VScrollBar.Width;
        this.fGridList.AutoResizeCols = true;
      }
      finally
      {
        this.fGridList.EndUpdate();
      }
      this.fAdjustWidthBeforeShow = false;
    }

    private void Grid_CellMouseMove(object sender, iGCellMouseMoveEventArgs e)
    {
      Point screen = this.fGridList.PointToScreen(e.MousePos);
      if (!(this.fLastMousePos != screen))
        return;
      if ((this.fGridList.Cells[e.RowIndex, e.ColIndex].Value as iGDropDownListItem).Selectable)
        this.fGridList.SetCurCell(e.RowIndex, e.ColIndex);
      else
        this.fGridList.CurCell = (iGCell) null;
      this.fLastMousePos = screen;
    }

    private void Grid_CurCellChanged(object sender, EventArgs e)
    {
      this.Grid_DoSelectedItemChanged();
    }

    private void Grid_DoSelectedItemChanged()
    {
      this.OnSelectedItemChanged(new iGSelectedItemChangedEventArgs(this.fGridList.CurCell == null ? (iGDropDownListItem) null : this.fGridList.CurCell.Value as iGDropDownListItem));
    }

    private void Grid_KeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Return:
          this.fParentGrid.CommitAnyEdit();
          break;
        case Keys.Escape:
          this.fParentGrid.CancelAnyEdit();
          break;
      }
    }

    private int Grid_GetHeight()
    {
      this.Grid_Adjust();
      int num1 = this.fRowHeight * this.fMaxVisibleRowCount;
      int num2 = this.fGridList.fVisibleRowsHeight;
      if (num2 > num1)
        num2 = num1;
      return num2;
    }

    private iGDropDownListItem Grid_GetSelectedItem()
    {
      this.Grid_Adjust();
      if (this.fGridList.CurCell == null)
        return (iGDropDownListItem) null;
      return this.fGridList.CurCell.Value as iGDropDownListItem;
    }

    private void Grid_SetSelectedItem(iGDropDownListItem item)
    {
      this.Grid_PrepareToShow();
      this.fGridList.fVScrollBar.Value = 0;
      if (item == null)
      {
        this.Grid_ClearCurCell();
      }
      else
      {
        int itemIndex = this.Grid_GetItemIndex(item);
        if (itemIndex < 0)
          this.Grid_ClearCurCell();
        else if (this.fGridList.CurCell == null || this.fGridList.CurCell.RowIndex != itemIndex)
        {
          this.fGridList.SetCurCell(itemIndex, 0);
        }
        else
        {
          this.fGridList.CurCell.EnsureVisible();
          this.Grid_DoSelectedItemChanged();
        }
      }
    }

    private iGDropDownListItem Grid_GetItemByValue(object value)
    {
      this.Grid_Adjust();
      iGDropDownListItem gdropDownListItem1 = new iGDropDownListItem(value);
      int count = this.fGridList.Rows.Count;
      for (int rowIndex = 0; rowIndex < count; ++rowIndex)
      {
        iGDropDownListItem gdropDownListItem2 = this.fGridList.GetCellDataInternal(rowIndex, 1).Value as iGDropDownListItem;
        if (((IComparable) gdropDownListItem2).CompareTo((object) gdropDownListItem1) == 0)
          return gdropDownListItem2;
      }
      return (iGDropDownListItem) null;
    }

    private iGDropDownListItem Grid_GetItemByText(string text, bool ignoreCase)
    {
      this.Grid_Adjust();
      int count = this.fGridList.Rows.Count;
      for (int rowIndex = 0; rowIndex < count; ++rowIndex)
      {
        iGDropDownListItem gdropDownListItem = this.fGridList.GetCellDataInternal(rowIndex, 1).Value as iGDropDownListItem;
        if (!this.AutoSubstitutionCustomCompare ? string.Compare(gdropDownListItem.ToString(), text, ignoreCase) == 0 : this.DoGetItemByTextCustomCompare(gdropDownListItem, text))
          return gdropDownListItem;
      }
      return (iGDropDownListItem) null;
    }

    private void Grid_SetRowVisible(int rowIndex, bool value)
    {
      this.Grid_PrepareToModify();
      if (rowIndex < 0 || rowIndex >= this.fGridList.Rows.Count)
        throw new ArgumentNullException();
      if (this.fGridList.Rows[rowIndex].Visible == value)
        return;
      this.fGridList.Rows[rowIndex].Visible = value;
      this.fAdjustWidthBeforeShow = this.fAutoWidth;
      this.fAdjustHeightBeforeShow = true;
    }

    private void Grid_PrevRow()
    {
      this.Grid_Adjust();
      this.fGridList.PerformAction(iGActions.GoPrevRow);
    }

    private void Grid_NextRow()
    {
      this.Grid_Adjust();
      this.fGridList.PerformAction(iGActions.GoNextRow);
    }

    private void Grid_PrevMatchingRow()
    {
      this.Grid_Adjust();
      if (this.fGridList.SearchAsType.Mode == iGSearchAsTypeMode.Filter)
        this.fGridList.PerformAction(iGActions.GoPrevRow);
      else if (this.fGridList.SearchAsType.IsActive)
      {
        this.fGridList.SearchAsType.GoPrev();
      }
      else
      {
        this.AdjustSearchAsType();
        if (this.fSearchAsType.fAutoCompleteSearchText == null || this.fSearchAsType.fAutoCompleteSearchText.Length == 0)
          return;
        this.fGridList.BeginUpdate();
        try
        {
          iGCell curCell = this.fGridList.CurCell;
          this.fGridList.SearchAsType.StartFromCurRow = true;
          try
          {
            this.fGridList.SearchAsType.SearchText = this.fSearchAsType.fAutoCompleteSearchText;
          }
          finally
          {
            this.fGridList.SearchAsType.StartFromCurRow = false;
          }
          if (!this.fGridList.SearchAsType.HasMatches || curCell == null)
            return;
          if (this.fGridList.CurCell.RowIndex >= curCell.RowIndex)
          {
            this.fGridList.SearchAsType.GoPrev();
          }
          else
          {
            do
              ;
            while (this.fGridList.SearchAsType.GoNext());
          }
        }
        finally
        {
          this.fGridList.EndUpdate();
          if (this.fGridList.CurCell != null)
            this.fGridList.CurCell.Row.EnsureVisible();
        }
      }
    }

    private void Grid_NextMatchingRow()
    {
      this.Grid_Adjust();
      if (this.fGridList.SearchAsType.Mode == iGSearchAsTypeMode.Filter)
        this.fGridList.PerformAction(iGActions.GoNextRow);
      else if (this.fGridList.SearchAsType.IsActive)
      {
        this.fGridList.SearchAsType.GoNext();
      }
      else
      {
        this.AdjustSearchAsType();
        if (this.fSearchAsType.fAutoCompleteSearchText == null || this.fSearchAsType.fAutoCompleteSearchText.Length == 0)
          return;
        this.fGridList.BeginUpdate();
        try
        {
          iGCell curCell1 = this.fGridList.CurCell;
          this.fGridList.SearchAsType.StartFromCurRow = true;
          try
          {
            this.fGridList.SearchAsType.SearchText = this.fSearchAsType.fAutoCompleteSearchText;
          }
          finally
          {
            this.fGridList.SearchAsType.StartFromCurRow = false;
          }
          if (!this.fGridList.SearchAsType.HasMatches || curCell1 == null)
            return;
          iGCell curCell2 = this.fGridList.CurCell;
          if (curCell2.RowIndex == curCell1.RowIndex)
          {
            this.fGridList.SearchAsType.GoNext();
          }
          else
          {
            if (curCell2.RowIndex >= curCell1.RowIndex)
              return;
            do
              ;
            while (this.fGridList.SearchAsType.GoNext());
          }
        }
        finally
        {
          this.fGridList.EndUpdate();
          if (this.fGridList.CurCell != null)
            this.fGridList.CurCell.Row.EnsureVisible();
        }
      }
    }

    private void Grid_SetRowsVisibilityAccordingToDropDownItems()
    {
      this.Grid_Adjust();
      int count = this.fGridList.Rows.Count;
      for (int rowIndex = 0; rowIndex < count; ++rowIndex)
      {
        iGDropDownListItem gdropDownListItem = this.fGridList.GetCellDataInternal(rowIndex, 1).Value as iGDropDownListItem;
        this.Grid_SetRowVisible(rowIndex, gdropDownListItem.Visible);
      }
    }

    private void Grid_SetParentLook(iGrid parentGrid)
    {
      this.fGridList.CustomControlPaint = parentGrid.CustomControlPaint;
      this.fGridList.Appearance = parentGrid.Appearance;
      this.fGridList.UseXPStyles = parentGrid.UseXPStyles;
      this.fGridList.CellCtrlBackColor = parentGrid.CellCtrlBackColor;
      this.fGridList.CellCtrlForeColor = parentGrid.CellCtrlForeColor;
    }

    private void Grid_SetColors(iGrid parentGrid)
    {
      if (this.fBackColor.IsEmpty)
        this.fGridList.BackColor = Color.FromArgb((int) byte.MaxValue, parentGrid.BackColor);
      else
        this.fGridList.BackColor = this.fBackColor;
      if (this.fForeColor.IsEmpty)
        this.fGridList.ForeColor = parentGrid.ForeColor;
      else
        this.fGridList.ForeColor = this.fForeColor;
      Color color;
      if (this.fSelItemForeColor.IsEmpty)
      {
        if (parentGrid.RowMode)
        {
          color = parentGrid.SelRowsForeColor;
          this.fGridList.SelCellsForeColor = !color.IsEmpty ? parentGrid.SelRowsForeColor : parentGrid.SelCellsForeColor;
        }
        else
          this.fGridList.SelCellsForeColor = parentGrid.SelCellsForeColor;
      }
      else
        this.fGridList.SelCellsForeColor = this.fSelItemForeColor;
      if (this.fSelItemBackColor.IsEmpty)
      {
        if (parentGrid.RowMode)
        {
          color = parentGrid.SelRowsBackColor;
          if (color.IsEmpty)
            this.fGridList.SelRowsBackColor = parentGrid.SelRowsBackColor;
          else
            this.fGridList.SelRowsBackColor = parentGrid.SelRowsBackColor;
        }
        else
          this.fGridList.SelCellsBackColor = parentGrid.SelCellsBackColor;
      }
      else
        this.fGridList.SelCellsBackColor = this.fSelItemBackColor;
    }

    private void Grid_SetUIStrings(string searchWindowLabelNext, string searchWindowLabelPrev)
    {
      this.Grid_Adjust();
      this.fGridList.UIStrings.SearchWindowLabelNext = searchWindowLabelNext;
      this.fGridList.UIStrings.SearchWindowLabelPrev = searchWindowLabelPrev;
    }

    private bool ShouldSerializeSearchAsType()
    {
      return iGInternalInfrastructure.iGSerializeManager.ShouldSerialize((object) this.SearchAsType);
    }

    private void ResetSearchAsType()
    {
      iGInternalInfrastructure.iGSerializeManager.Reset((object) this.SearchAsType);
    }

    private bool ShouldSerializeBackColor()
    {
      return this.fBackColor != Color.Empty;
    }

    private bool ShouldSerializeForeColor()
    {
      return this.fForeColor != Color.Empty;
    }

    private bool ShouldSerializeSelItemBackColor()
    {
      return this.fSelItemBackColor != Color.Empty;
    }

    private bool ShouldSerializeSelItemForeColor()
    {
      return this.fSelItemForeColor != Color.Empty;
    }

    private void ResetForeColor()
    {
      this.fForeColor = Color.Empty;
    }

    private void ResetBackColor()
    {
      this.fBackColor = Color.Empty;
    }

    private void ResetSelItemForeColor()
    {
      this.fSelItemForeColor = Color.Empty;
    }

    private void ResetSelItemBackColor()
    {
      this.fSelItemBackColor = Color.Empty;
    }

    private bool ShouldSerializeItems()
    {
      if (this.fCollection != null)
        return this.fCollection.Count > 0;
      return false;
    }

    private void ResetItems()
    {
      if (this.fCollection == null)
        return;
      this.fCollection.Clear();
    }

    /// <summary>Gets or sets the horizontal and vertical alignment of the text displayed in the list items.</summary>
    /// <value>The horizontal and vertical alignment of the text displayed in the list items.</value>
    [Category("Appearance")]
    [DefaultValue(iGContentAlignment.MiddleLeft)]
    [Description("Determines the horizontal and vertical alignment of the item text.")]
    public iGContentAlignment TextAlign
    {
      get
      {
        return this.fTextAlign;
      }
      set
      {
        this.fTextAlign = value;
      }
    }

    /// <summary>Gets or sets the horizontal and vertical alignment of the image displayed in the list items.</summary>
    /// <value>The horizontal and vertical alignment of the image displayed in the list items.</value>
    [Category("Appearance")]
    [DefaultValue(iGContentAlignment.MiddleLeft)]
    [Description("Determines the horizontal and vertical alignment of the images displayed in the items.")]
    public iGContentAlignment ImageAlign
    {
      get
      {
        return this.fImageAlign;
      }
      set
      {
        this.fImageAlign = value;
      }
    }

    /// <summary>Gets or sets the relative position of the image and text displayed in the list items.</summary>
    /// <value>The relative position of the image and text displayed in the list items.</value>
    [Category("Appearance")]
    [DefaultValue(iGTextPosToImage.Horizontally)]
    [Description("Determines the relative position of the image and text displayed in the items.")]
    public iGTextPosToImage TextPosToImage
    {
      get
      {
        return this.fTextPosToImage;
      }
      set
      {
        this.fTextPosToImage = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether the drop-down list is of the fixed width needed to show all its contents entirely.</summary>
    /// <value>True if the drop-down list is has the fixed width; otherwise, False. The default is False.</value>
    [Category("Behavior")]
    [DefaultValue(false)]
    [Description("Determines whether the drop down list is of the fixed width, needed to show all its contents entirely.")]
    public bool AutoWidth
    {
      get
      {
        return this.fAutoWidth;
      }
      set
      {
        if (value == this.fAutoWidth)
          return;
        this.fAutoWidth = value;
        this.fAdjustWidthBeforeShow = value;
        if (!value)
          return;
        this.fWidth = -1;
      }
    }

    /// <summary>Gets or sets the maximal number of the rows visible in the drop-down list simultaneously.</summary>
    /// <value>The maximal number of visible items. The default is 8.</value>
    [Category("Behavior")]
    [DefaultValue(8)]
    [Description("Determines the maximal count of the rows visible in the drop down list simultaneously.")]
    public int MaxVisibleRowCount
    {
      get
      {
        return this.fMaxVisibleRowCount;
      }
      set
      {
        this.fMaxVisibleRowCount = value;
      }
    }

    /// <summary>Gets the collection of the items of the drop-down list.</summary>
    /// <value>The <see cref="T:TenTec.Windows.iGridLib.iGDropDownList.iGDropDownListItemCollection" /> object that provides access to the items of the drop-down list.</value>
    [Category("Data")]
    [Editor("TenTec.Windows.iGridLib.Design.iGDropDownListItemCollectionEditor, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0", typeof (UITypeEditor))]
    [TypeConverter(typeof (CollectionConverter))]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Description("The items of the drop down list.")]
    public iGDropDownList.iGDropDownListItemCollection Items
    {
      get
      {
        if (this.fCollection == null)
          this.fCollection = new iGDropDownList.iGDropDownListItemCollection(this);
        return this.fCollection;
      }
    }

    /// <summary>The minimal width of the drop-down list.</summary>
    /// <value>The minimal width. The default is 10.</value>
    [Category("Behavior")]
    [DefaultValue(10)]
    [Description("The minimal width of the drop down list.")]
    public int MinWidth
    {
      get
      {
        return this.fMinWidth;
      }
      set
      {
        if (value < 0)
          this.fMinWidth = -1;
        else
          this.fMinWidth = value;
      }
    }

    /// <summary>Gets or sets the image list that contains the images displayed in the drop-down list. If an image list is not assigned to a cell, this property will also be used to display the image in the cell.</summary>
    /// <value>An <see cref="T:System.Windows.Forms.ImageList" /> object. The default is null (Nothing in VB).</value>
    [Category("Appearance")]
    [DefaultValue(null)]
    [Description("The ImageList that contains the images displayed in the drop down list. If a cell style is not assigned to a cell, the image list also will be used to display the image in the cell.")]
    public ImageList ImageList
    {
      get
      {
        return this.fImageList;
      }
      set
      {
        if (this.fImageList == value)
          return;
        this.fImageList = value;
        if (this.fGridList == null)
          return;
        this.Grid_SetImageList(this.fImageList);
      }
    }

    /// <summary>Gets or sets the font used to display the items in the drop-down list. If not set, the cell font is used.</summary>
    /// <value>The <see cref="T:System.Drawing.Font" /> object used to draw the text in the drop-down list. The default is null (Nothing in VB).</value>
    [Category("Appearance")]
    [DefaultValue(null)]
    [Description("The font used to display the items in the drop down list. If not set, the cell font is used.")]
    public Font Font
    {
      get
      {
        return this.fFont;
      }
      set
      {
        if (this.fFont == value)
          return;
        this.fFont = value;
        if (this.fGridList == null)
          return;
        this.Grid_SetFont(this.fFont);
      }
    }

    /// <summary>Get an object which allows you to set up the search-as-type functionality used in the drop-down list.</summary>
    /// <value>The instance of the <see cref="T:TenTec.Windows.iGridLib.iGDropDownList.iGSearchAsType" /> object which represents the search-as-type functionality in this drop-down list.</value>
    [Category("Behavior")]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGExpandableTypeConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Description("Determines the search as type behavior of the drop-down list.")]
    public iGDropDownList.iGSearchAsType SearchAsType
    {
      get
      {
        this.AdjustSearchAsType();
        return this.fSearchAsType;
      }
    }

    /// <summary>Gets or sets the foreground color of the drop-down list.</summary>
    /// <value>Gets or sets the foreground color of the drop-down list. The default value is <see cref="F:System.Drawing.Color.Empty" /> (i.e. not set).</value>
    [Category("Appearance")]
    [Description("Determines the color of the text of the list items.")]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGColorEmptyAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    public Color ForeColor
    {
      get
      {
        return this.fForeColor;
      }
      set
      {
        this.fForeColor = value;
      }
    }

    /// <summary>Gets or sets the background color of the drop-down list.</summary>
    /// <value>Gets or sets the background color of the drop-down list. The default value is <see cref="F:System.Drawing.Color.Empty" /> (i.e. not set).</value>
    [Category("Appearance")]
    [Description("Determines the background color of the list items.")]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGColorEmptyAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    public Color BackColor
    {
      get
      {
        return this.fBackColor;
      }
      set
      {
        this.fBackColor = value;
      }
    }

    /// <summary>Gets or sets the foreground color of the selected item in the drop-down list.</summary>
    /// <value>Gets or sets the foreground color of the selected item in the drop-down list. The default value is <see cref="F:System.Drawing.Color.Empty" /> (i.e. not set).</value>
    [Category("Appearance")]
    [Description("Determines the color of the text of the selected item.")]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGColorEmptyAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    public Color SelItemForeColor
    {
      get
      {
        return this.fSelItemForeColor;
      }
      set
      {
        this.fSelItemForeColor = value;
      }
    }

    /// <summary>Gets or sets the background color of the selected item in the drop-down list.</summary>
    /// <value>Gets or sets the background color of the selected item in the drop-down list. The default value is <see cref="F:System.Drawing.Color.Empty" /> (i.e. not set).</value>
    [Category("Appearance")]
    [Description("Determines the background color of the selected item.")]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGColorEmptyAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    public Color SelItemBackColor
    {
      get
      {
        return this.fSelItemBackColor;
      }
      set
      {
        this.fSelItemBackColor = value;
      }
    }

    /// <summary>Determines whether to automatically highlight the first item in the auto-complete list when it works in filter mode.</summary>
    /// <value>Determines whether to automatically highlight the first item in the auto-complete list when it works in filter mode. The default value is True.</value>
    [Category("Behavior")]
    [DefaultValue(true)]
    [Description("Determines whether to select the first item in auto-complete list in filter mode.")]
    public bool ACLSelFirstWhenFilter
    {
      get
      {
        return this.fACLSelFirstWhenFilter;
      }
      set
      {
        this.fACLSelFirstWhenFilter = value;
      }
    }

    /// <summary>Determines whether iGrid substitutes the text entered into a combo box cell with the corresponding item from the attached drop-down list when you hit the ENTER key.</summary>
    /// <value>Determines whether iGrid substitutes the text entered into a combo box cell with the corresponding item from the attached drop-down list when you hit the ENTER key. The default value is True.</value>
    [Category("Behavior")]
    [DefaultValue(true)]
    [Description("Determines whether to automatically substitute the entered text with the corresponding value from the drop-down list.")]
    public bool AutoSubstitution
    {
      get
      {
        return this.fAutoSubstitution;
      }
      set
      {
        this.fAutoSubstitution = value;
      }
    }

    /// <summary>Enables to use custom compare algorithm when auto-substituion is on.</summary>
    /// <value>Enables to use custom compare algorithm when auto-substituion is on. The default value is False.</value>
    [Category("Behavior")]
    [DefaultValue(false)]
    [Description("Determines whether to use custom comparison when automatically substituting the entered text with the corresponding value from the drop-down list.")]
    public bool AutoSubstitutionCustomCompare
    {
      get
      {
        return this.fAutoSubstitutionCustomCompare;
      }
      set
      {
        this.fAutoSubstitutionCustomCompare = value;
      }
    }

    ImageList IiGDropDownControl.ImageList
    {
      get
      {
        return this.ImageList;
      }
    }

    int IiGDropDownControl.Width
    {
      get
      {
        return this.fWidth;
      }
    }

    int IiGDropDownControl.Height
    {
      get
      {
        return this.Grid_GetHeight();
      }
    }

    object IiGDropDownControl.SelectedItem
    {
      get
      {
        return (object) this.Grid_GetSelectedItem();
      }
      set
      {
        this.Grid_SetSelectedItem(value as iGDropDownListItem);
      }
    }

    bool IiGDropDownControl.CommitOnHide
    {
      get
      {
        return false;
      }
    }

    bool IiGDropDownControl.Sizeable
    {
      get
      {
        return false;
      }
    }

    string IiGDropDownControl.Text
    {
      get
      {
        return (string) null;
      }
    }

    bool IiGDropDownControl.CloseButton
    {
      get
      {
        return false;
      }
    }

    bool IiGDropDownControl.HideColHdrDropDown
    {
      get
      {
        return true;
      }
    }

    bool IiGDropDownControl.AutoSubstitution
    {
      get
      {
        throw new NotImplementedException();
      }
    }

    /// <summary>Occurs when the selected item in the drop-down list is changed.</summary>
    [Description("Occurs when the selected item in the drop down list is changed.")]
    public event iGSelectedItemChangedEventHandler SelectedItemChanged;

    /// <summary>Is raised when the grid needs to know whether a drop-down list item matches a text being sought.</summary>
    [Description("Occurs when searching as typing by a custom criterion and allows you to specify whether an item matches the search criterion.")]
    public event iGDropDownListCustomCompareEventHandler SearchAsTypeCustomCompare;

    /// <summary>Is raised for each item when custom compare algorithm is used in auto-substitution.</summary>
    [Description("Occurs when the grid tries to find a drop-down item by the entered text.")]
    public event iGDropDownListCustomCompareEventHandler GetItemByTextCustomCompare;

    /// <summary>Occurs when a value in the drop-down list is selected if the drop-down list works in auto-complete mode.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public event iGAutoCompleteControlValueSelectedEventHandler ValueSelected
    {
      add
      {
        this.fValueSelected = this.fValueSelected + value;
      }
      remove
      {
        this.fValueSelected = this.fValueSelected - value;
      }
    }

    /// <summary>Represents a collection of drop-down list items.</summary>
    public class iGDropDownListItemCollection : IList, ICollection, IEnumerable, IiGEnumerableCollection
    {
      private iGDropDownList fList;

      internal iGDropDownListItemCollection(iGDropDownList list)
      {
        if (list == null)
          throw new ArgumentNullException();
        this.fList = list;
      }

      /// <summary>Adds a new item to the collection.</summary>
      /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGDropDownListItem" /> object that represents the added item.</returns>
      public iGDropDownListItem Add()
      {
        iGDropDownListItem gdropDownListItem = new iGDropDownListItem();
        this.Add(gdropDownListItem);
        return gdropDownListItem;
      }

      /// <summary>Adds a new item with the specified value to the collection.</summary>
      /// <param name="value">The value that is set to a cell when the item in the drop-down list is selected. If the <see cref="P:TenTec.Windows.iGridLib.iGDropDownListItem.Text" /> property of the item is null (Nothing in VB), this property is used to display the text in the drop-down list.</param>
      /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGDropDownListItem" /> object that represents the added item.</returns>
      public iGDropDownListItem Add(object value)
      {
        iGDropDownListItem gdropDownListItem = new iGDropDownListItem(value);
        this.Add(gdropDownListItem);
        return gdropDownListItem;
      }

      /// <summary>Adds a new item with the specified value and image index to the collection.</summary>
      /// <param name="value">The value that is set to a cell when the item in the drop-down list is selected. If the <see cref="P:TenTec.Windows.iGridLib.iGDropDownListItem.Text" /> property of the item is null (Nothing in VB), this property is used to display the text in the drop-down list.</param>
      /// <param name="imageIndex">The index of the image displayed in the new drop-down list item and in the cells, to which this item is attached.</param>
      /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGDropDownListItem" /> object that represents the added item.</returns>
      public iGDropDownListItem Add(object value, int imageIndex)
      {
        iGDropDownListItem gdropDownListItem = new iGDropDownListItem(value, imageIndex);
        this.Add(gdropDownListItem);
        return gdropDownListItem;
      }

      /// <summary>Adds a new item with the specified value and text to the collection.</summary>
      /// <param name="value">The value that is set to a cell when the item in the drop-down list is selected. If the <see cref="P:TenTec.Windows.iGridLib.iGDropDownListItem.Text" /> property of the item is null (Nothing in VB), this property is used to display the text in the drop-down list.</param>
      /// <param name="text">The text displayed in the drop-down list. This text is also displayed in the cells to which this drop-down list item is attached.</param>
      /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGDropDownListItem" /> object that represents the added item.</returns>
      public iGDropDownListItem Add(object value, string text)
      {
        iGDropDownListItem gdropDownListItem = new iGDropDownListItem(value, text);
        this.Add(gdropDownListItem);
        return gdropDownListItem;
      }

      /// <summary>Adds a new item with the specified value, image index, and text to the collection.</summary>
      /// <param name="value">The value that is set to a cell when the item in the drop-down list is selected. If the <see cref="P:TenTec.Windows.iGridLib.iGDropDownListItem.Text" /> property of the item is null (Nothing in VB), this property is used to display the text in the drop-down list.</param>
      /// <param name="text">The text displayed in the drop-down list. This text is also displayed in the cells to which this drop-down list item is attached.</param>
      /// <param name="imageIndex">The index of the image displayed in the new drop-down list item and in the cells, to which this item is attached.</param>
      /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGDropDownListItem" /> object that represents the added item.</returns>
      public iGDropDownListItem Add(object value, string text, int imageIndex)
      {
        iGDropDownListItem gdropDownListItem = new iGDropDownListItem(value, text, imageIndex);
        this.Add(gdropDownListItem);
        return gdropDownListItem;
      }

      /// <summary>Adds the item to the collection.</summary>
      /// <param name="item">The item to add to the collection.</param>
      /// <returns>The index of the added item within this collection.</returns>
      public int Add(iGDropDownListItem item)
      {
        if (item.fDropDownList != null)
          throw new ArgumentException();
        int num = this.fList.Grid_AddRow(item);
        this.fList.SortedList_AddItem(item);
        return num;
      }

      /// <summary>Adds the specified range of items to the collection.</summary>
      /// <param name="items">The items to add.</param>
      public void AddRange(iGDropDownListItem[] items)
      {
        if (items == null)
          throw new ArgumentNullException();
        for (int index = 0; index < items.Length; ++index)
        {
          if (items[index] == null)
            throw new ArgumentException();
        }
        for (int index = 0; index < items.Length; ++index)
          this.Add(items[index]);
      }

      /// <summary>Removes all the items from the collection.</summary>
      public void Clear()
      {
        this.fList.Grid_Clear();
        this.fList.SortedList_Clear();
      }

      /// <summary>Inserts the specified item to the collection at the specified location.</summary>
      /// <param name="index">The zero-based indexed location within the collection to insert the item.</param>
      /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGDropDownListItem" /> object that represents the added item.</returns>
      public iGDropDownListItem Insert(int index)
      {
        iGDropDownListItem gdropDownListItem = new iGDropDownListItem();
        this.Insert(index, gdropDownListItem);
        return gdropDownListItem;
      }

      /// <summary>Inserts a new item with the specified value to the collection at the specified location.</summary>
      /// <param name="index">The indexed location within the collection to insert the item.</param>
      /// <param name="value">The value that is set to a cell when the item in the drop-down list is selected. If the <see cref="P:TenTec.Windows.iGridLib.iGDropDownListItem.Text" /> property of the item is null (Nothing in VB), this property is used to display the text in the drop-down list.</param>
      /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGDropDownListItem" /> object that represents the added item.</returns>
      public iGDropDownListItem Insert(int index, object value)
      {
        iGDropDownListItem gdropDownListItem = new iGDropDownListItem(value);
        this.Insert(index, gdropDownListItem);
        return gdropDownListItem;
      }

      /// <summary>Inserts a new item with the specified value and image index to the collection at the specified location.</summary>
      /// <param name="index">The indexed location within the collection to insert the item.</param>
      /// <param name="value">The value that is set to a cell when the item in the drop-down list is selected. If the <see cref="P:TenTec.Windows.iGridLib.iGDropDownListItem.Text" /> property of the item is null (Nothing in VB), this property is used to display the text in the drop-down list.</param>
      /// <param name="imageIndex">The index of the image displayed in the new drop-down list item and in the cells, to which this item is attached.</param>
      /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGDropDownListItem" /> object that represents the added item.</returns>
      public iGDropDownListItem Insert(int index, object value, int imageIndex)
      {
        iGDropDownListItem gdropDownListItem = new iGDropDownListItem(value, imageIndex);
        this.Insert(index, gdropDownListItem);
        return gdropDownListItem;
      }

      /// <summary>Inserts a new item with the specified value, image index, and text to the collection at the specified location.</summary>
      /// <param name="index">The indexed location within the collection to insert the item.</param>
      /// <param name="value">The value that is set to a cell when the item in the drop-down list is selected. If the <see cref="P:TenTec.Windows.iGridLib.iGDropDownListItem.Text" /> property of the item is null (Nothing in VB), this property is used to display the text in the drop-down list.</param>
      /// <param name="text">The text displayed in the drop-down list. This text is also displayed in the cells to which this drop-down list item is attached.</param>
      /// <param name="imageIndex">The index of the image displayed in the new drop-down list item and in the cells, to which this item is attached.</param>
      /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGDropDownListItem" /> object that represents the added item.</returns>
      public iGDropDownListItem Insert(int index, object value, string text, int imageIndex)
      {
        iGDropDownListItem gdropDownListItem = new iGDropDownListItem(value, text, imageIndex);
        this.Insert(index, gdropDownListItem);
        return gdropDownListItem;
      }

      /// <summary>Inserts a new item with the specified value and text to the collection at the specified location.</summary>
      /// <param name="index">The indexed location within the collection to insert the item.</param>
      /// <param name="value">The value that is set to a cell when the item in the drop-down list is selected. If the <see cref="P:TenTec.Windows.iGridLib.iGDropDownListItem.Text" /> property of the item is null (Nothing in VB), this property is used to display the text in the drop-down list.</param>
      /// <param name="text">The text displayed in the drop-down list. This text is also displayed in the cells to which this drop-down list item is attached.</param>
      /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGDropDownListItem" /> object that represents the added item.</returns>
      public iGDropDownListItem Insert(int index, object value, string text)
      {
        iGDropDownListItem gdropDownListItem = new iGDropDownListItem(value, text);
        this.Insert(index, gdropDownListItem);
        return gdropDownListItem;
      }

      /// <summary>Inserts the specified item to the collection at the specified location.</summary>
      /// <param name="index">The indexed location within the collection to insert the item.</param>
      /// <param name="item">The item to insert.</param>
      public void Insert(int index, iGDropDownListItem item)
      {
        if (index < 0 || index > this.fList.Grid_GetCount())
          throw new ArgumentOutOfRangeException();
        if (item.fDropDownList != null)
          throw new ArgumentException();
        this.fList.Grid_InsertRow(index, item);
        this.fList.SortedList_AddItem(item);
      }

      /// <summary>Determines whether the specified item is a member of the collection.</summary>
      /// <param name="item">The item to locate in the collection.</param>
      /// <returns>True if the specified item is a part of this collection; otherwise, False.</returns>
      public bool Contains(iGDropDownListItem item)
      {
        if (item == null)
          throw new ArgumentNullException();
        return item.fDropDownList == this.fList;
      }

      /// <summary>Returns the index of the specified item in the collection.</summary>
      /// <param name="item">The item to locate in the collection.</param>
      /// <returns>The zero-based index of the item found in the collection; otherwise, -1.</returns>
      public int IndexOf(iGDropDownListItem item)
      {
        if (item == null)
          throw new ArgumentNullException();
        if (item.fDropDownList != this.fList)
          return -1;
        return this.fList.Grid_GetItemIndex(item);
      }

      /// <summary>Searches the item collection for an <see cref="T:TenTec.Windows.iGridLib.iGDropDownListItem" /> with the <see cref="P:TenTec.Windows.iGridLib.iGDropDownListItem.Value" /> property that equals the specified value.</summary>
      /// <param name="value">The item value to search for.</param>
      /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGDropDownListItem" /> that contains the specified value.</returns>
      public iGDropDownListItem FindByValue(object value)
      {
        return this.fList.SortedList_GetItemByValue(value);
      }

      /// <summary>Searches the item collection for an <see cref="T:TenTec.Windows.iGridLib.iGDropDownListItem" /> with the <see cref="P:TenTec.Windows.iGridLib.iGDropDownListItem.Text" /> property that equals the specified text.</summary>
      /// <param name="text">The item text to search for.</param>
      /// <param name="ignoreCase">True to ignore case during the comparison; otherwise, False.</param>
      /// <returns>An <see cref="T:TenTec.Windows.iGridLib.iGDropDownListItem" /> that contains the specified text.</returns>
      public iGDropDownListItem FindByText(string text, bool ignoreCase)
      {
        return this.fList.Grid_GetItemByText(text, ignoreCase);
      }

      /// <summary>Copies the entire collection into an existing array at a specified location within the array.</summary>
      /// <param name="array">The destination array.</param>
      /// <param name="index">The index in the destination array at which storing begins.</param>
      public void CopyTo(Array array, int index)
      {
        this.fList.Grid_CopyTo(array, index);
      }

      /// <summary>Removes the item from the collection at the specified index.</summary>
      /// <param name="index">The index of the item to remove within this collection.</param>
      public void RemoveAt(int index)
      {
        if (index < 0 || index >= this.fList.Grid_GetCount())
          throw new ArgumentOutOfRangeException();
        iGDropDownListItem gdropDownListItem = this.fList.Grid_GetItem(index);
        this.fList.Grid_RemoveAt(index);
        this.fList.SortedList_RemoveItem(gdropDownListItem);
      }

      /// <summary>Removes the specified item from the collection.</summary>
      /// <param name="item">The item to remove.</param>
      public void Remove(iGDropDownListItem item)
      {
        if (item == null)
          throw new ArgumentNullException();
        if (item.fDropDownList != this.fList)
          throw new ArgumentException();
        this.RemoveAt(this.fList.Grid_GetItemIndex(item));
      }

      void IList.Insert(int index, object value)
      {
        this.Insert(index, (iGDropDownListItem) value);
      }

      void IList.Remove(object value)
      {
        this.Remove((iGDropDownListItem) value);
      }

      bool IList.Contains(object value)
      {
        return this.Contains((iGDropDownListItem) value);
      }

      int IList.IndexOf(object value)
      {
        return this.IndexOf((iGDropDownListItem) value);
      }

      int IList.Add(object value)
      {
        return this.Add((iGDropDownListItem) value);
      }

      bool IList.IsReadOnly
      {
        get
        {
          return false;
        }
      }

      object IList.this[int index]
      {
        get
        {
          return (object) this[index];
        }
        set
        {
          this[index] = (iGDropDownListItem) value;
        }
      }

      bool IList.IsFixedSize
      {
        get
        {
          return false;
        }
      }

      bool ICollection.IsSynchronized
      {
        get
        {
          return false;
        }
      }

      object ICollection.SyncRoot
      {
        get
        {
          return (object) this;
        }
      }

      object IiGEnumerableCollection.this[int index]
      {
        get
        {
          return (object) this[index];
        }
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
        return (IEnumerator) new iGEnumerator((IiGEnumerableCollection) this);
      }

      /// <summary>Indicates the item at the specified indexed location in the collection.</summary>
      /// <param name="index">The zero-based indexed location of the item in the collection.</param>
      /// <value>The <see cref="T:TenTec.Windows.iGridLib.iGDropDownListItem" /> object that represents the item at the specified location.</value>
      public iGDropDownListItem this[int index]
      {
        get
        {
          return this.fList.Grid_GetItem(index);
        }
        set
        {
          this.RemoveAt(index);
          this.Insert(index, value);
        }
      }

      /// <summary>Gets the total number of the items in the collection.</summary>
      /// <value>The total number of <see cref="T:TenTec.Windows.iGridLib.iGDropDownListItem" /> objects in the collection.</value>
      public int Count
      {
        get
        {
          return this.fList.Grid_GetCount();
        }
      }
    }

    /// <summary>Represents the search-as-type functionality in the <see cref="T:TenTec.Windows.iGridLib.iGSearchAsType" /> class.</summary>
    public class iGSearchAsType
    {
      internal iGSearchAsTypeMode fDropDownMode = iGSearchAsTypeMode.Seek;
      internal iGSearchAsTypeMode fAutoCompleteMode = iGSearchAsTypeMode.Filter;
      internal bool fDisplaySearchTextIfNeeded = true;
      internal bool fDisplayKeyboardHintIfNeeded = true;
      private const iGSearchAsTypeMode cDefaultDropDownMode = iGSearchAsTypeMode.Seek;
      private const iGSearchAsTypeMode cDefaultAutoCompleteMode = iGSearchAsTypeMode.Filter;
      private const bool cDefaultDisplaySearchTextIfNeeded = true;
      private const bool cDefaultDisplayKeyboardHintIfNeeded = true;
      private iGDropDownList fList;
      internal string fAutoCompleteSearchText;
      internal iGMatchRule fMatchRule;

      internal iGSearchAsType(iGDropDownList list)
      {
        if (list == null)
          throw new ArgumentNullException();
        this.fList = list;
      }

      /// <summary>Gets or sets the mode which the drop-down list works in when it is shown as a drop-down control.</summary>
      /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGSearchAsTypeMode" /> enumeration values.</value>
      [DefaultValue(iGSearchAsTypeMode.Seek)]
      [Description("Determines the search-as-type behavior when the list is shown as a drop-down control.")]
      public iGSearchAsTypeMode DropDownMode
      {
        get
        {
          return this.fDropDownMode;
        }
        set
        {
          this.fDropDownMode = value;
        }
      }

      /// <summary>Gets or sets the mode which the drop-down list works in when it is shown as an auto-complete control.</summary>
      /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGSearchAsTypeMode" /> enumeration values.</value>
      [DefaultValue(iGSearchAsTypeMode.Filter)]
      [Description("Determines the search-as-type behavior when the list is shown as an auto-complete control.")]
      public iGSearchAsTypeMode AutoCompleteMode
      {
        get
        {
          return this.fAutoCompleteMode;
        }
        set
        {
          this.fAutoCompleteMode = value;
        }
      }

      /// <summary>Gets or sets the criteria used in the search-as-type functionality.</summary>
      /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGMatchRule" /> enumeration values.</value>
      [DefaultValue(iGMatchRule.StartsWith)]
      [Description("Indicates how to determine whether a drop-down item matches the search criterion when searching as typing.")]
      public iGMatchRule MatchRule
      {
        get
        {
          return this.fMatchRule;
        }
        set
        {
          this.fMatchRule = value;
        }
      }

      /// <summary>Gets or sets a value indicating whether the search text should be shown when it is needed.</summary>
      /// <value>True if the search text should be displayed; otherwise, False.</value>
      [DefaultValue(true)]
      [Description("Determines whether to display the search text when searching as typing if needed.")]
      public bool DisplaySearchTextIfNeeded
      {
        get
        {
          return this.fDisplaySearchTextIfNeeded;
        }
        set
        {
          this.fDisplaySearchTextIfNeeded = value;
        }
      }

      /// <summary>Gets or sets a value indicating whether the keyboard hint should be shown when it is needed.</summary>
      /// <value>True if the hint should be displayed; otherwise, False.</value>
      [DefaultValue(true)]
      [Description("Determines whether to display the keyboard hint when searching as typing if needed.")]
      public bool DisplayKeyboardHintIfNeeded
      {
        get
        {
          return this.fDisplayKeyboardHintIfNeeded;
        }
        set
        {
          this.fDisplayKeyboardHintIfNeeded = value;
        }
      }
    }
  }
}
