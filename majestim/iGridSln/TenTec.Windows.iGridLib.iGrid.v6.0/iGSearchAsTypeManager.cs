// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGSearchAsTypeManager
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  internal class iGSearchAsTypeManager : IDisposable
  {
    private StringBuilder fText = new StringBuilder();
    private bool fAutoCancel = true;
    private int fSearchColIndex = -1;
    private bool fDisplayKeyboardHint = true;
    private bool fDisplaySearchText = true;
    private int fHScrollBarPosition = -1;
    private const char cBackspaceChar = '\b';
    internal const iGMatchRule cDefaultMatchRule = iGMatchRule.StartsWith;
    internal const int cDefaultSearchColIndex = -1;
    internal const bool cDefaultStartFromCurRow = false;
    internal const iGSearchAsTypeMode cDefaultMode = iGSearchAsTypeMode.None;
    internal const bool cDefaultFilterKeepCurRow = false;
    internal const bool cDefaultAutoCancel = true;
    internal const bool cDefaultLoopSearch = false;
    private iGrid fGrid;
    private bool fLastSymbolIncorrect;
    private bool fTemporaryLockCancel;
    private iGMatchRule fMatchRule;
    private int fCurSearchColIndex;
    private iGMatchRule fCurMatchRule;
    private bool fStartFromCurRow;
    private iGSearchAsTypeMode fMode;
    private bool fHasMatches;
    private bool fFilterKeepCurRow;
    private bool fLoopSearch;
    private const int cSearchWindowIndent = 2;
    private const int cSearchWindowBorderWidth = 1;
    private const int cSearchWindowElementOffset = 2;
    private const string cCtrlLeftPart = "(Alt+";
    private const string cCtrlRightPart = ")";
    internal const bool cDefaultDisplayKeyboardHint = true;
    internal const bool cDefaultDisplaySearchText = true;
    private iGToolTipWindowManager fToolTipWindowManager;
    private static Image fNextHintImage;
    private static Image fPrevHintImage;
    private static Image fErrorImage;
    private Control fTopLevelControl;

    public iGSearchAsTypeManager(iGrid grid)
    {
      if (grid == null)
        throw new ArgumentNullException(nameof (grid));
      this.fGrid = grid;
    }

    public void OnKeyDown(KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Space)
        e.Handled = true;
      if (!this.IsActive)
        return;
      if (e.KeyData == (Keys.Down | Keys.Alt))
      {
        this.GoNext();
        e.Handled = true;
      }
      else
      {
        if (e.KeyData != (Keys.Up | Keys.Alt))
          return;
        this.GoPrev();
        e.Handled = true;
      }
    }

    public void OnKeyPress(KeyPressEventArgs e)
    {
      if ((int) e.KeyChar == 8)
      {
        if (this.fText.Length <= 0)
          return;
        string textToFind = this.fText.ToString(0, this.fText.Length - 1);
        if (textToFind.Length == 0)
        {
          this.ClearText();
        }
        else
        {
          this.fText.Remove(this.fText.Length - 1, 1);
          this.fLastSymbolIncorrect = false;
          this.fHasMatches = this.SelectNextCellAndFilter(textToFind, true, false, false, this.fLoopSearch, true, true, false);
          this.AfterChangeText();
        }
        e.Handled = true;
      }
      else
      {
        if (char.IsControl(e.KeyChar) || this.fText.Length == 0 && !this.CanStartSearchAsType())
          return;
        string textToFind;
        bool flag;
        if (this.fLastSymbolIncorrect && this.fText.Length > 0)
        {
          textToFind = this.fText.ToString(0, this.fText.Length - 1) + e.KeyChar.ToString();
          flag = false;
        }
        else
        {
          textToFind = this.fText.ToString() + e.KeyChar.ToString();
          flag = true;
        }
        bool startFromFirstRow = this.fText.Length == 0 && !this.fStartFromCurRow;
        if (flag)
          this.fText.Append(e.KeyChar);
        else
          this.fText[this.fText.Length - 1] = e.KeyChar;
        this.fHasMatches = this.SelectNextCellAndFilter(textToFind, true, false, startFromFirstRow, this.fLoopSearch, true, !flag, true);
        this.fLastSymbolIncorrect = !this.fHasMatches;
        this.AfterChangeText();
        e.Handled = true;
      }
    }

    public void OnColRemoved(int colIndex, int count)
    {
      if (this.fSearchColIndex < colIndex)
        return;
      if (this.fSearchColIndex < colIndex + count)
        this.fSearchColIndex = -1;
      else
        this.fSearchColIndex = this.fSearchColIndex - count;
    }

    public void OnColAdded(int colIndex, int count)
    {
      if (this.fSearchColIndex < colIndex)
        return;
      this.fSearchColIndex = this.fSearchColIndex + count;
    }

    public bool IsInputChar(char charCode)
    {
      if ((int) charCode != 8)
        return !char.IsControl(charCode);
      return true;
    }

    public void Cancel(bool manually)
    {
      if (!manually && (this.fTemporaryLockCancel || !this.fAutoCancel))
        return;
      this.ClearText();
    }

    public bool GoNext()
    {
      int num = this.SelectNextCellAndFilter(this.fText.ToString(), false, false, false, false, false, false, false) ? 1 : 0;
      if (num != 0)
        this.fLastSymbolIncorrect = false;
      this.ShowHideSearchWindow();
      return num != 0;
    }

    public bool GoPrev()
    {
      int num = this.SelectNextCellAndFilter(this.fText.ToString(), false, true, false, false, false, false, false) ? 1 : 0;
      if (num != 0)
        this.fLastSymbolIncorrect = false;
      this.ShowHideSearchWindow();
      return num != 0;
    }

    private bool SelectNextCellAndFilter(string textToFind, bool doNotMoveIfCurrentAgrees, bool moveBackward, bool startFromFirstRow, bool searchFromStartWhenEndReached, bool filterIfNeeded, bool makeRowsVisibleWhenFilter, bool makeRowsInvisibleWhenFilter)
    {
      if (textToFind == null || textToFind.Length == 0 || (this.fGrid.fColCount == 0 || this.fGrid.fRowCount == 0) || this.fCurSearchColIndex == -1)
        return false;
      iGCellNavigator fCurCell1 = this.fGrid.fCurCell;
      int num1 = moveBackward ? -1 : 1;
      int num2;
      if (startFromFirstRow || fCurCell1.IsEmpty)
      {
        num2 = 0;
      }
      else
      {
        num2 = fCurCell1.RowIndex;
        if (!doNotMoveIfCurrentAgrees)
          num2 += num1;
      }
      string upper = textToFind.ToUpper();
      bool flag1 = false;
      bool beginUpdateWasInvoked = false;
      try
      {
        bool flag2 = false;
        int rowIndex1 = num2;
        if (!this.fFilterKeepCurRow || this.fMode != iGSearchAsTypeMode.Filter)
        {
          while (rowIndex1 != num2 || !flag2)
          {
            if (rowIndex1 == this.fGrid.fRowCount || rowIndex1 == -1)
            {
              if (searchFromStartWhenEndReached)
              {
                flag2 = true;
                rowIndex1 = num1 <= 0 ? this.fGrid.fRowCount : -1;
              }
              else
                break;
            }
            else if (this.DoesRowParticipateInSearch(this.fGrid.GetRowDataInternal(rowIndex1).Type))
            {
              if (this.DoesTextMatch(rowIndex1, this.fCurSearchColIndex, upper, textToFind))
              {
                if (filterIfNeeded && this.fMode == iGSearchAsTypeMode.Filter)
                {
                  if (!beginUpdateWasInvoked)
                  {
                    this.fGrid.BeginUpdate();
                    beginUpdateWasInvoked = true;
                  }
                  this.fGrid.SetRowVisible(rowIndex1, true);
                }
                this.fTemporaryLockCancel = true;
                try
                {
                  if (this.fGrid.CanSelectCell(rowIndex1, this.fGrid.GetColOrder(this.fCurSearchColIndex), false))
                  {
                    iGCellNavigator fCurCell2 = this.fGrid.fCurCell;
                    this.fGrid.SetCurCellWithEventsEnsureVisibleIfSpecified(new iGCellNavigator(rowIndex1, this.fCurSearchColIndex), true, false);
                    this.fGrid.ChangeSelectionOnCurCellKeyboardChange(fCurCell2, false, false);
                    flag1 = true;
                    break;
                  }
                }
                finally
                {
                  this.fTemporaryLockCancel = false;
                }
              }
              else if (makeRowsInvisibleWhenFilter & filterIfNeeded && this.fMode == iGSearchAsTypeMode.Filter)
              {
                if (!beginUpdateWasInvoked)
                {
                  this.fGrid.BeginUpdate();
                  beginUpdateWasInvoked = true;
                }
                this.fGrid.SetRowVisible(rowIndex1, false);
              }
            }
            rowIndex1 += num1;
          }
        }
        int num3 = rowIndex1;
        int num4;
        if (filterIfNeeded)
        {
          if (this.fMode == iGSearchAsTypeMode.Filter)
          {
            if (flag2)
            {
              num4 = num3;
              int rowIndex2 = num3;
              while (rowIndex2 != num2)
              {
                flag1 |= this.FilterRow(rowIndex2, this.fCurSearchColIndex, makeRowsVisibleWhenFilter, makeRowsInvisibleWhenFilter, upper, textToFind, ref beginUpdateWasInvoked);
                rowIndex2 += num1;
              }
            }
            else
            {
              num4 = num3;
              int rowIndex2 = num3;
              while (rowIndex2 != this.fGrid.fRowCount && rowIndex2 != -1)
              {
                flag1 |= this.FilterRow(rowIndex2, this.fCurSearchColIndex, makeRowsVisibleWhenFilter, makeRowsInvisibleWhenFilter, upper, textToFind, ref beginUpdateWasInvoked);
                rowIndex2 += num1;
              }
              int rowIndex3 = num1 > 0 ? 0 : this.fGrid.fRowCount - 1;
              while (rowIndex3 != num2)
              {
                flag1 |= this.FilterRow(rowIndex3, this.fCurSearchColIndex, makeRowsVisibleWhenFilter, makeRowsInvisibleWhenFilter, upper, textToFind, ref beginUpdateWasInvoked);
                rowIndex3 += num1;
              }
            }
          }
        }
      }
      finally
      {
        if (beginUpdateWasInvoked)
          this.fGrid.EndUpdate();
        if (this.fGrid.fRedraw && (!this.fFilterKeepCurRow || this.fMode == iGSearchAsTypeMode.Seek))
        {
          iGCellNavigator fCurCell2 = this.fGrid.fCurCell;
          if (this.fHScrollBarPosition >= 0)
            this.fGrid.HScrollBar.Value = this.fHScrollBarPosition;
          else if (!fCurCell2.IsEmpty)
          {
            this.fGrid.EnsureVisibleCol(fCurCell2.ColIndex);
            this.fHScrollBarPosition = this.fGrid.HScrollBar.Value;
          }
          if (!fCurCell2.IsEmpty)
            this.fGrid.EnsureVisibleRow(fCurCell2.RowIndex);
        }
      }
      if (filterIfNeeded && this.fMode == iGSearchAsTypeMode.Filter)
      {
        if (!flag1 && !this.fFilterKeepCurRow)
        {
          this.fTemporaryLockCancel = true;
          try
          {
            iGCellNavigator fCurCell2 = this.fGrid.fCurCell;
            this.fGrid.SetCurCellWithEventsEnsureVisibleIfSpecified(iGCellNavigator.Empty, true, false);
            this.fGrid.ChangeSelectionOnCurCellKeyboardChange(fCurCell2, false, false);
          }
          finally
          {
            this.fTemporaryLockCancel = false;
          }
        }
        this.fGrid.DoSearchAsTypeRowSetChanged();
      }
      return flag1;
    }

    private bool CanStartSearchAsType()
    {
      this.fCurSearchColIndex = -1;
      iGCellNavigator fCurCell = this.fGrid.fCurCell;
      if ((!this.fFilterKeepCurRow || this.fMode != iGSearchAsTypeMode.Filter) && fCurCell.IsEmpty)
      {
        this.fTemporaryLockCancel = true;
        try
        {
          this.fGrid.ActionNextCol(false);
          this.fGrid.ChangeSelectionOnCurCellKeyboardChange(iGCellNavigator.Empty, false, false);
        }
        finally
        {
          this.fTemporaryLockCancel = false;
        }
        fCurCell = this.fGrid.fCurCell;
        if (fCurCell.IsEmpty)
          return false;
      }
      if (this.fSearchColIndex >= 0)
      {
        if (this.fGrid.IsCellColVisible(this.fSearchColIndex))
          this.fCurSearchColIndex = this.fSearchColIndex;
      }
      else if (!fCurCell.IsEmpty && this.fGrid.GetRowDataInternal(fCurCell.RowIndex).Type == iGRowType.Normal && this.fGrid.IsCellColVisible(fCurCell.ColIndex))
        this.fCurSearchColIndex = fCurCell.ColIndex;
      if (this.fCurSearchColIndex < 0)
        return false;
      this.fCurMatchRule = this.fGrid.DoRequestSearchAsTypeMatchRule(fCurCell.ColIndex, this.fMatchRule);
      return true;
    }

    private bool DoesRowParticipateInSearch(iGRowType rowDataType)
    {
      return rowDataType == iGRowType.Normal;
    }

    private bool FilterRow(int rowIndex, int searchColIndex, bool makeRowVisibleWhenNeeded, bool makeRowInvisibleWhenNeeded, string textToFindUpperCase, string textToFind, ref bool beginUpdateWasInvoked)
    {
      iGRowData rowDataInternal = this.fGrid.GetRowDataInternal(rowIndex);
      if (!this.DoesRowParticipateInSearch(rowDataInternal.Type))
        return false;
      if (rowDataInternal.Visible)
      {
        if (!makeRowInvisibleWhenNeeded || this.DoesTextMatch(rowIndex, searchColIndex, textToFindUpperCase, textToFind))
          return true;
        if (!beginUpdateWasInvoked)
        {
          this.fGrid.BeginUpdate();
          beginUpdateWasInvoked = true;
        }
        this.fGrid.SetRowVisible(rowIndex, false);
        return false;
      }
      if (!makeRowVisibleWhenNeeded || !this.DoesTextMatch(rowIndex, searchColIndex, textToFindUpperCase, textToFind))
        return false;
      if (!beginUpdateWasInvoked)
      {
        this.fGrid.BeginUpdate();
        beginUpdateWasInvoked = true;
      }
      this.fGrid.SetRowVisible(rowIndex, true);
      return true;
    }

    private bool DoesTextMatch(int rowIndex, int colIndex, string textToFindUpperCase, string textToFind)
    {
      switch (this.fCurMatchRule)
      {
        case iGMatchRule.StartsWith:
          return this.fGrid.GetCellTextInternal(rowIndex, colIndex).ToUpper().StartsWith(textToFindUpperCase);
        case iGMatchRule.Contains:
          return this.fGrid.GetCellTextInternal(rowIndex, colIndex).ToUpper().Contains(textToFindUpperCase);
        case iGMatchRule.Custom:
          return this.fGrid.DoSearchAsTypeCustomCompare(rowIndex, colIndex, textToFind);
        default:
          return false;
      }
    }

    private void AfterChangeText()
    {
      this.ShowHideSearchWindow();
      if (this.fText.Length == 0)
      {
        if (this.fTopLevelControl == null)
          return;
        this.fTopLevelControl.Move -= new EventHandler(this.fTopLevelControl_Move);
        this.fTopLevelControl = (Control) null;
      }
      else
      {
        Control topLevelControl = this.fGrid.TopLevelControl;
        if (this.fTopLevelControl == topLevelControl)
          return;
        if (this.fTopLevelControl != null)
          this.fTopLevelControl.Move -= new EventHandler(this.fTopLevelControl_Move);
        this.fTopLevelControl = topLevelControl;
        if (this.fTopLevelControl == null)
          return;
        this.fTopLevelControl.Move += new EventHandler(this.fTopLevelControl_Move);
      }
    }

    private void ClearText()
    {
      if (this.fText.Length == 0)
        return;
      this.fText.Length = 0;
      if (this.fMode == iGSearchAsTypeMode.Filter)
      {
        this.fGrid.BeginUpdate();
        try
        {
          for (int rowIndex = 0; rowIndex < this.fGrid.fRowCount; ++rowIndex)
          {
            if (this.fMatchRule == iGMatchRule.Custom && this.fCurSearchColIndex >= 0)
            {
              if (this.DoesTextMatch(rowIndex, this.fCurSearchColIndex, string.Empty, string.Empty))
                this.fGrid.SetRowVisible(rowIndex, true);
            }
            else
              this.fGrid.SetRowVisible(rowIndex, true);
          }
        }
        finally
        {
          this.fGrid.EndUpdate();
        }
      }
      iGCellNavigator fCurCell = this.fGrid.fCurCell;
      if (!fCurCell.IsEmpty)
        this.fGrid.EnsureVisibleRow(fCurCell.RowIndex);
      this.fLastSymbolIncorrect = false;
      this.fCurSearchColIndex = -1;
      this.fHScrollBarPosition = -1;
      this.fHasMatches = false;
      if (this.fMode == iGSearchAsTypeMode.Filter)
        this.fGrid.DoSearchAsTypeRowSetChanged();
      this.AfterChangeText();
    }

    private Font GetFont()
    {
      return new Font(this.fGrid.Font, FontStyle.Bold);
    }

    private void fTopLevelControl_Move(object sender, EventArgs e)
    {
      this.Cancel(false);
    }

    public bool IsActive
    {
      get
      {
        return this.fText.Length > 0;
      }
    }

    public iGMatchRule MatchRule
    {
      get
      {
        return this.fMatchRule;
      }
      set
      {
        if (value == this.fMatchRule)
          return;
        this.Cancel(true);
        this.fMatchRule = value;
      }
    }

    public int SearchColIndex
    {
      get
      {
        return this.fSearchColIndex;
      }
      set
      {
        if (value == this.fSearchColIndex)
          return;
        this.Cancel(true);
        if (value != -1)
          this.fGrid.CheckColIndex(value);
        this.fSearchColIndex = value;
      }
    }

    public bool StartFromCurRow
    {
      get
      {
        return this.fStartFromCurRow;
      }
      set
      {
        this.fStartFromCurRow = value;
      }
    }

    public iGSearchAsTypeMode Mode
    {
      get
      {
        return this.fMode;
      }
      set
      {
        if (value == this.fMode)
          return;
        this.Cancel(true);
        this.fMode = value;
      }
    }

    public string SearchText
    {
      get
      {
        return this.fText.ToString();
      }
      set
      {
        if (value == this.fText.ToString())
        {
          this.ShowHideSearchWindow();
        }
        else
        {
          if (this.fText.Length == 0 && !this.CanStartSearchAsType())
            return;
          if (value == null || value.Length == 0)
          {
            this.ClearText();
          }
          else
          {
            string str = this.fText.ToString();
            this.fHasMatches = this.SelectNextCellAndFilter(value, true, false, this.fText.Length == 0 && !this.fStartFromCurRow, this.fLoopSearch, true, !value.StartsWith(str), !str.StartsWith(value));
            this.fText.Length = 0;
            this.fText.Append(value);
            this.fLastSymbolIncorrect = false;
            this.AfterChangeText();
          }
        }
      }
    }

    public bool HasMatches
    {
      get
      {
        return this.fHasMatches;
      }
    }

    public bool FilterKeepCurRow
    {
      get
      {
        return this.fFilterKeepCurRow;
      }
      set
      {
        if (value == this.fFilterKeepCurRow)
          return;
        this.Cancel(true);
        this.fFilterKeepCurRow = value;
      }
    }

    public bool AutoCancel
    {
      get
      {
        return this.fAutoCancel;
      }
      set
      {
        if (value == this.fAutoCancel)
          return;
        this.fAutoCancel = value;
      }
    }

    public bool LoopSearch
    {
      get
      {
        return this.fLoopSearch;
      }
      set
      {
        this.fLoopSearch = value;
      }
    }

    private void AdjustToolTipWindowManager()
    {
      if (this.fToolTipWindowManager != null)
        return;
      this.fToolTipWindowManager = new iGToolTipWindowManager(this.fGrid);
      this.fToolTipWindowManager.Paint += new iGToolTipWindowPaintEventHandler(this.fToolTipWindowManager_Paint);
    }

    private void fToolTipWindowManager_Paint(object sender, iGToolTipWindowPaintEventArgs e)
    {
      Rectangle bounds1 = e.Bounds;
      --bounds1.Width;
      --bounds1.Height;
      e.Graphics.DrawRectangle(SystemPens.ControlDark, bounds1);
      ++bounds1.X;
      ++bounds1.Y;
      --bounds1.Width;
      --bounds1.Height;
      e.Graphics.FillRectangle(SystemBrushes.Info, bounds1);
      bounds1.Inflate(-2, -2);
      StringFormat stringFormat = new StringFormat(StringFormatFlags.MeasureTrailingSpaces);
      stringFormat.LineAlignment = StringAlignment.Center;
      if (this.fGrid.RightToLeft == RightToLeft.Yes)
        stringFormat.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
      if (this.fDisplaySearchText)
      {
        this.AdjustErrorImage();
        Rectangle bounds2 = bounds1;
        bounds2.Height = (int) Math.Ceiling((double) e.Graphics.MeasureString(this.fText.ToString(), this.fGrid.Font, int.MaxValue, stringFormat).Height);
        if (this.fLastSymbolIncorrect && iGSearchAsTypeManager.fErrorImage.Height > bounds2.Height)
          bounds2.Height = iGSearchAsTypeManager.fErrorImage.Height;
        if (this.fLastSymbolIncorrect)
        {
          if (this.fText.Length > 1)
            this.DrawTextPreciselyAtLeft(e.Graphics, this.fText.ToString(0, this.fText.Length - 1), ref bounds2, stringFormat, this.fGrid.Font, SystemBrushes.InfoText, false);
          using (Font font = new Font(this.fGrid.Font, FontStyle.Bold))
            this.DrawTextPreciselyAtLeft(e.Graphics, this.fText.ToString(this.fText.Length - 1, 1), ref bounds2, stringFormat, font, Brushes.Red, true);
        }
        else
          this.DrawTextPreciselyAtLeft(e.Graphics, this.fText.ToString(), ref bounds2, stringFormat);
        if (this.fLastSymbolIncorrect)
        {
          int y = bounds2.Y + (bounds2.Height - iGSearchAsTypeManager.fErrorImage.Height) / 2;
          int x = this.fGrid.RightToLeft != RightToLeft.Yes ? bounds2.X : bounds2.Right - iGSearchAsTypeManager.fErrorImage.Width;
          e.Graphics.DrawImage(iGSearchAsTypeManager.fErrorImage, new Rectangle(x, y, iGSearchAsTypeManager.fErrorImage.Width, iGSearchAsTypeManager.fErrorImage.Height), new Rectangle(0, 0, iGSearchAsTypeManager.fErrorImage.Width, iGSearchAsTypeManager.fErrorImage.Height), GraphicsUnit.Pixel);
        }
        bounds1.Y += bounds2.Height + 2;
        bounds1.Height -= bounds2.Height + 2;
      }
      if (this.fDisplayKeyboardHint)
      {
        this.AdjustHintImages();
        this.DrawTextPreciselyAtLeft(e.Graphics, this.fGrid.fUIStrings.fSearchWindowLabelNext, ref bounds1, stringFormat);
        this.DrawTextPreciselyAtLeft(e.Graphics, "(Alt+", ref bounds1, stringFormat);
        int y1 = bounds1.Y + (bounds1.Height - iGSearchAsTypeManager.fNextHintImage.Height) / 2;
        int x1 = this.fGrid.RightToLeft != RightToLeft.Yes ? bounds1.X : bounds1.Right - iGSearchAsTypeManager.fNextHintImage.Width;
        e.Graphics.DrawImage(iGSearchAsTypeManager.fNextHintImage, new Rectangle(x1, y1, iGSearchAsTypeManager.fNextHintImage.Width, iGSearchAsTypeManager.fNextHintImage.Height), new Rectangle(0, 0, iGSearchAsTypeManager.fNextHintImage.Width, iGSearchAsTypeManager.fNextHintImage.Height), GraphicsUnit.Pixel);
        if (this.fGrid.RightToLeft != RightToLeft.Yes)
          bounds1.X += iGSearchAsTypeManager.fNextHintImage.Width + 2;
        bounds1.Width -= iGSearchAsTypeManager.fNextHintImage.Width + 2;
        this.DrawTextPreciselyAtLeft(e.Graphics, ")", ref bounds1, stringFormat);
        this.DrawTextPreciselyAtLeft(e.Graphics, this.fGrid.fUIStrings.fSearchWindowLabelPrev, ref bounds1, stringFormat);
        this.DrawTextPreciselyAtLeft(e.Graphics, "(Alt+", ref bounds1, stringFormat);
        int y2 = bounds1.Y + (bounds1.Height - iGSearchAsTypeManager.fPrevHintImage.Height) / 2;
        int x2 = this.fGrid.RightToLeft != RightToLeft.Yes ? bounds1.X : bounds1.Right - iGSearchAsTypeManager.fPrevHintImage.Width;
        e.Graphics.DrawImage(iGSearchAsTypeManager.fPrevHintImage, new Rectangle(x2, y2, iGSearchAsTypeManager.fPrevHintImage.Width, iGSearchAsTypeManager.fPrevHintImage.Height), new Rectangle(0, 0, iGSearchAsTypeManager.fPrevHintImage.Width, iGSearchAsTypeManager.fPrevHintImage.Height), GraphicsUnit.Pixel);
        if (this.fGrid.RightToLeft != RightToLeft.Yes)
          bounds1.X += iGSearchAsTypeManager.fPrevHintImage.Width + 2;
        bounds1.Width -= iGSearchAsTypeManager.fPrevHintImage.Width + 2;
        this.DrawTextPreciselyAtLeft(e.Graphics, ")", ref bounds1, stringFormat);
      }
      e.DoDefault = false;
    }

    private void DrawTextPreciselyAtLeft(Graphics g, string text, ref Rectangle bounds, StringFormat stringFormat)
    {
      this.DrawTextPreciselyAtLeft(g, text, ref bounds, stringFormat, this.fGrid.Font, SystemBrushes.InfoText, true);
    }

    private void ShowHideSearchWindow()
    {
      this.AdjustToolTipWindowManager();
      Rectangle searchWindowBounds = this.GetSearchWindowBounds();
      if (this.fText.Length == 0 || searchWindowBounds.IsEmpty)
      {
        this.fToolTipWindowManager.HideToolTipWindow();
      }
      else
      {
        this.fToolTipWindowManager.ShowToolTipWindow(searchWindowBounds.Location, searchWindowBounds.Size, this.fText.ToString());
        this.fToolTipWindowManager.UpdateToolTipWindow();
      }
    }

    private Rectangle GetSearchWindowBounds()
    {
      this.AdjustToolTipWindowManager();
      if (!this.fDisplaySearchText && !this.fDisplayKeyboardHint || (!this.fGrid.Visible || this.fGrid.TopLevelControl == null))
        return Rectangle.Empty;
      using (Graphics graphics = this.fToolTipWindowManager.GetGraphics())
      {
        StringFormat stringFormat = new StringFormat(StringFormatFlags.MeasureTrailingSpaces);
        if (this.fGrid.RightToLeft == RightToLeft.Yes)
          stringFormat.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
        Rectangle bounds = new Rectangle(0, 0, int.MaxValue, int.MaxValue);
        iGCellNavigator fCurCell = this.fGrid.fCurCell;
        Size size1;
        if (this.fDisplaySearchText)
        {
          Size size2;
          if (this.fLastSymbolIncorrect)
          {
            Rectangle rectangle;
            Size size3;
            if (this.fText.Length > 1)
            {
              rectangle = this.MeasureTextPrecisely(graphics, this.fText.ToString(0, this.fText.Length - 1), stringFormat, bounds);
              size3 = rectangle.Size;
            }
            else
              size3 = Size.Empty;
            Size size4;
            using (Font font = new Font(this.fGrid.Font, FontStyle.Bold))
            {
              rectangle = this.MeasureTextPrecisely(graphics, this.fText.ToString(this.fText.Length - 1, 1), font, stringFormat, bounds);
              size4 = rectangle.Size;
            }
            size2 = new Size(size3.Width + size4.Width, Math.Max(size3.Height, size4.Height));
          }
          else
            size2 = this.MeasureTextPrecisely(graphics, this.fText.ToString(), stringFormat, bounds).Size;
          this.AdjustErrorImage();
          Size size5 = iGSearchAsTypeManager.fErrorImage.Size;
          size1 = size2;
          if (this.fLastSymbolIncorrect)
          {
            size1.Width += size5.Width + 2;
            if (size1.Height < size5.Height)
              size1.Height = size5.Height;
          }
        }
        else
          size1 = Size.Empty;
        Rectangle rectangle1;
        int val2;
        int num1;
        if (this.fDisplayKeyboardHint)
        {
          this.AdjustHintImages();
          Size size2 = this.MeasureTextPrecisely(graphics, this.fGrid.fUIStrings.fSearchWindowLabelPrev, stringFormat, bounds).Size;
          Size size3 = this.MeasureTextPrecisely(graphics, this.fGrid.fUIStrings.fSearchWindowLabelNext, stringFormat, bounds).Size;
          rectangle1 = this.MeasureTextPrecisely(graphics, "(Alt+", stringFormat, bounds);
          Size size4 = rectangle1.Size;
          rectangle1 = this.MeasureTextPrecisely(graphics, ")", stringFormat, bounds);
          Size size5 = rectangle1.Size;
          val2 = size2.Width + size3.Width + iGSearchAsTypeManager.fNextHintImage.Width + iGSearchAsTypeManager.fPrevHintImage.Width + 2 * size4.Width + 2 * size5.Width + 14;
          num1 = Math.Max(iGSearchAsTypeManager.fNextHintImage.Height, iGSearchAsTypeManager.fPrevHintImage.Height);
          if (num1 < size3.Height)
            num1 = size3.Height;
          if (num1 < size2.Height)
            num1 = size2.Height;
          if (num1 < size4.Height)
            num1 = size4.Height;
          if (num1 < size5.Height)
            num1 = size5.Height;
        }
        else
        {
          val2 = 0;
          num1 = 0;
        }
        Rectangle areaBoundsNoRowHdr = this.fGrid.GetCellsAreaBoundsNoRowHdr();
        int width = Math.Max(size1.Width, val2) + 4 + 2;
        int x1;
        if (this.fCurSearchColIndex >= 0)
        {
          bool isFirstVisibleCol;
          int x2 = this.fGrid.ColToX(this.fGrid.GetColOrder(this.fCurSearchColIndex), false, out isFirstVisibleCol);
          int num2 = !this.fGrid.IsColVisible(this.fCurSearchColIndex) ? 0 : this.fGrid.GetColDataInternal(this.fCurSearchColIndex).Width;
          x1 = this.fGrid.RightToLeft != RightToLeft.Yes ? x2 : x2 + num2 - width;
        }
        else
          x1 = areaBoundsNoRowHdr.X;
        if (x1 < areaBoundsNoRowHdr.X)
          x1 = areaBoundsNoRowHdr.X;
        if (x1 >= areaBoundsNoRowHdr.Right)
          x1 = areaBoundsNoRowHdr.Right - width;
        int y1 = areaBoundsNoRowHdr.Bottom + 1;
        int startRow;
        int startY;
        int startHeight;
        int endRow;
        int endY;
        int endHeight;
        this.fGrid.GetStartEndVisibleScrollableRow(out startRow, out startY, out startHeight, out endRow, out endY, out endHeight);
        if (endY + endHeight + 1 < y1)
          y1 = endY + endHeight + 1;
        int height1 = 6;
        if (size1.Height > 0)
          height1 += size1.Height;
        if (num1 > 0)
        {
          height1 += num1;
          if (size1.Height > 0)
            height1 += 2;
        }
        Rectangle r = new Rectangle(x1, y1, width, height1);
        Rectangle client = this.fGrid.RectangleToClient(Screen.FromPoint(this.fGrid.PointToScreen(new Point(x1, y1))).Bounds);
        if (r.Y + r.Height > client.Y + client.Height)
          r.Y = client.Y + client.Height - r.Height;
        if (!fCurCell.IsEmpty)
        {
          int y2 = this.fGrid.RowToY(fCurCell.RowIndex);
          int height2 = !this.fGrid.IsRowVisibleInternal(fCurCell.RowIndex) ? 0 : this.fGrid.GetRowDataInternal(fCurCell.RowIndex).Height;
          if (r.IntersectsWith(new Rectangle(areaBoundsNoRowHdr.X, y2, areaBoundsNoRowHdr.Width, height2)))
            r.Y = y2 - r.Height;
        }
        rectangle1 = this.fGrid.RectangleToScreen(r);
        return rectangle1;
      }
    }

    private Rectangle MeasureTextPrecisely(Graphics g, string text, StringFormat stringFormat, Rectangle bounds)
    {
      return this.MeasureTextPrecisely(g, text, this.fGrid.Font, stringFormat, bounds);
    }

    private Rectangle MeasureTextPrecisely(Graphics g, string text, Font font, StringFormat stringFormat, Rectangle bounds)
    {
      if (text != null && text.Length > 0)
      {
        g.TextRenderingHint = this.fGrid.TextRenderingHint;
        stringFormat.SetMeasurableCharacterRanges(new CharacterRange[1]
        {
          new CharacterRange(0, text.Length)
        });
        return Rectangle.Ceiling(g.MeasureCharacterRanges(text, font, (RectangleF) bounds, stringFormat)[0].GetBounds(g));
      }
      if ((stringFormat.FormatFlags & StringFormatFlags.DirectionRightToLeft) == StringFormatFlags.DirectionRightToLeft)
        return new Rectangle(bounds.X + bounds.Width, bounds.Y, 0, 0);
      return new Rectangle(bounds.X, bounds.Y, 0, 0);
    }

    private void DrawTextPreciselyAtLeft(Graphics g, string text, ref Rectangle bounds, StringFormat stringFormat, Font font, Brush brush, bool addIndent)
    {
      if (text == null || text.Length == 0)
        return;
      stringFormat.SetMeasurableCharacterRanges(new CharacterRange[1]
      {
        new CharacterRange(0, text.Length)
      });
      Rectangle rectangle = this.MeasureTextPrecisely(g, text, font, stringFormat, bounds);
      int num1 = (stringFormat.FormatFlags & StringFormatFlags.DirectionRightToLeft) != StringFormatFlags.DirectionRightToLeft ? bounds.X - (rectangle.X - bounds.X) : bounds.Right + (bounds.Right - rectangle.Right) - 1;
      int num2 = stringFormat.LineAlignment != StringAlignment.Center ? bounds.Y : bounds.Y + bounds.Height / 2;
      g.DrawString(text, font, brush, (float) num1, (float) num2, stringFormat);
      if ((stringFormat.FormatFlags & StringFormatFlags.DirectionRightToLeft) != StringFormatFlags.DirectionRightToLeft)
        bounds.X += rectangle.Width + (addIndent ? 2 : 0);
      bounds.Width -= rectangle.Width + (addIndent ? 2 : 0);
    }

    private void AdjustErrorImage()
    {
      if (iGSearchAsTypeManager.fErrorImage != null)
        return;
      iGSearchAsTypeManager.fErrorImage = (Image) new Bitmap(iGrid.GetResourceStream("SearchAsTypeError.png"));
    }

    private void AdjustHintImages()
    {
      if (iGSearchAsTypeManager.fNextHintImage == null)
        iGSearchAsTypeManager.fNextHintImage = (Image) new Bitmap(iGrid.GetResourceStream("SearchAsTypeArrowDown.png"));
      if (iGSearchAsTypeManager.fPrevHintImage != null)
        return;
      iGSearchAsTypeManager.fPrevHintImage = (Image) new Bitmap(iGrid.GetResourceStream("SearchAsTypeArrowUp.png"));
    }

    public bool DisplayKeyboardHint
    {
      get
      {
        return this.fDisplayKeyboardHint;
      }
      set
      {
        if (this.fDisplayKeyboardHint == value)
          return;
        this.fDisplayKeyboardHint = value;
        this.ShowHideSearchWindow();
      }
    }

    public bool DisplaySearchText
    {
      get
      {
        return this.fDisplaySearchText;
      }
      set
      {
        if (value == this.fDisplaySearchText)
          return;
        this.fDisplaySearchText = value;
        this.ShowHideSearchWindow();
      }
    }

    ~iGSearchAsTypeManager()
    {
      this.Dispose(false);
    }

    public void Dispose()
    {
      this.Dispose(true);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!disposing || this.fToolTipWindowManager == null)
        return;
      this.fToolTipWindowManager.Dispose();
      this.fToolTipWindowManager = (iGToolTipWindowManager) null;
    }
  }
}
