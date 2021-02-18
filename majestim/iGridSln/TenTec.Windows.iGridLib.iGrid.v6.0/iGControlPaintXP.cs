// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGControlPaintXP
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using Microsoft.Win32;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  internal class iGControlPaintXP : IiGControlPaintInternal, IiGControlPaint, IDisposable
  {
    private static IntPtr[] ThemeData = new IntPtr[23];
    private static readonly Pen fExtraHeaderLinePen = new Pen(System.Drawing.Color.FromArgb(229, 229, 229));
    private System.Drawing.Color fForeColor = iGControlPaintStyle.cDefaultForeColor;
    public const int COMBOBOX_PART_DROPDOWNBUTTON = 1;
    public const int DROPDOWNBUTTON_STATE_NORMAL = 1;
    public const int DROPDOWNBUTTON_STATE_HOT = 2;
    public const int DROPDOWNBUTTON_STATE_PRESSED = 3;
    public const int DROPDOWNBUTTON_STATE_DISABLED = 4;
    public const int BUTTON_PART_PUSHBUTTON = 1;
    public const int BUTTON_PART_RADIOBUTTON = 2;
    public const int BUTTON_PART_CHECKBOX = 3;
    public const int BUTTON_PART_GROUPBOX = 4;
    public const int PUSHBUTTON_STATE_NORMAL = 1;
    public const int PUSHBUTTON_STATE_HOT = 2;
    public const int PUSHBUTTON_STATE_PRESSED = 3;
    public const int PUSHBUTTON_STATE_DISABLED = 4;
    public const int PUSHBUTTON_STATE_DEFAULTED = 5;
    public const int BUTTON_RADIO_STATE_UNCHECKEDNORMAL = 1;
    public const int BUTTON_RADIO_STATE_UNCHECKEDHOT = 2;
    public const int BUTTON_RADIO_STATE_UNCHECKEDPRESSED = 3;
    public const int BUTTON_RADIO_STATE_UNCHECKEDDISABLED = 4;
    public const int BUTTON_RADIO_STATE_CHECKEDNORMAL = 5;
    public const int BUTTON_RADIO_STATE_CHECKEDHOT = 6;
    public const int BUTTON_RADIO_STATE_CHECKEDPRESSED = 7;
    public const int BUTTON_RADIO_STATE_CHECKEDDISABLED = 8;
    public const int BUTTON_CHECK_STATE_UNCHECKEDNORMAL = 1;
    public const int BUTTON_CHECK_STATE_UNCHECKEDHOT = 2;
    public const int BUTTON_CHECK_STATE_UNCHECKEDPRESSED = 3;
    public const int BUTTON_CHECK_STATE_UNCHECKEDDISABLED = 4;
    public const int BUTTON_CHECK_STATE_CHECKEDNORMAL = 5;
    public const int BUTTON_CHECK_STATE_CHECKEDHOT = 6;
    public const int BUTTON_CHECK_STATE_CHECKEDPRESSED = 7;
    public const int BUTTON_CHECK_STATE_CHECKEDDISABLED = 8;
    public const int BUTTON_CHECK_STATE_MIXEDNORMAL = 9;
    public const int BUTTON_CHECK_STATE_MIXEDHOT = 10;
    public const int BUTTON_CHECK_STATE_MIXEDPRESSED = 11;
    public const int BUTTON_CHECK_STATE_MIXEDDISABLED = 12;
    public const int BUTTON_GROUPBOX_STATE_NORMAL = 1;
    public const int BUTTON_GROUPBOX_STATE_DISABLED = 2;
    public const int SCROLLBAR_PART_ARROWBTN = 1;
    public const int SCROLLBAR_PART_THUMBBTNHORZ = 2;
    public const int SCROLLBAR_PART_THUMBBTNVERT = 3;
    public const int SCROLLBAR_PART_LOWERTRACKHORZ = 4;
    public const int SCROLLBAR_PART_UPPERTRACKHORZ = 5;
    public const int SCROLLBAR_PART_LOWERTRACKVERT = 6;
    public const int SCROLLBAR_PART_UPPERTRACKVERT = 7;
    public const int SCROLLBAR_PART_GRIPPERHORZ = 8;
    public const int SCROLLBAR_PART_GRIPPERVERT = 9;
    public const int SCROLLBAR_PART_SIZEBOX = 10;
    public const int SCROLLBAR_ARROWBTN_STATE_UPNORMAL = 1;
    public const int SCROLLBAR_ARROWBTN_STATE_UPHOT = 2;
    public const int SCROLLBAR_ARROWBTN_STATE_UPPRESSED = 3;
    public const int SCROLLBAR_ARROWBTN_STATE_UPDISABLED = 4;
    public const int SCROLLBAR_ARROWBTN_STATE_DOWNNORMAL = 5;
    public const int SCROLLBAR_ARROWBTN_STATE_DOWNHOT = 6;
    public const int SCROLLBAR_ARROWBTN_STATE_DOWNPRESSED = 7;
    public const int SCROLLBAR_ARROWBTN_STATE_DOWNDISABLED = 8;
    public const int SCROLLBAR_ARROWBTN_STATE_LEFTNORMAL = 9;
    public const int SCROLLBAR_ARROWBTN_STATE_LEFTHOT = 10;
    public const int SCROLLBAR_ARROWBTN_STATE_LEFTPRESSED = 11;
    public const int SCROLLBAR_ARROWBTN_STATE_LEFTDISABLED = 12;
    public const int SCROLLBAR_ARROWBTN_STATE_RIGHTNORMAL = 13;
    public const int SCROLLBAR_ARROWBTN_STATE_RIGHTHOT = 14;
    public const int SCROLLBAR_ARROWBTN_STATE_RIGHTPRESSED = 15;
    public const int SCROLLBAR_ARROWBTN_STATE_RIGHTDISABLED = 16;
    public const int SCROLLBAR_BUTTON_STATE_NORMAL = 1;
    public const int SCROLLBAR_BUTTON_STATE_HOT = 2;
    public const int SCROLLBAR_BUTTON_STATE_PRESSED = 3;
    public const int SCROLLBAR_BUTTON_STATE_DISABLED = 4;
    public const int SCROLLBAR_SIZEBOX_STATE_RIGHTALIGN = 1;
    public const int SCROLLBAR_SIZEBOX_STATE_LEFTALIGN = 2;
    public const int PROGRESS_PART_BAR = 1;
    public const int PROGRESS_PART_BARVERT = 2;
    public const int PROGRESS_PART_CHUNK = 3;
    public const int PROGRESS_PART_CHUNKVERT = 4;
    public const int TRACKBAR_PART_TRACK = 1;
    public const int TRACKBAR_PART_TRACKVERT = 2;
    public const int TRACKBAR_PART_THUMB = 3;
    public const int TRACKBAR_PART_THUMBBOTTOM = 4;
    public const int TRACKBAR_PART_THUMBTOP = 5;
    public const int TRACKBAR_PART_THUMBVERT = 6;
    public const int TRACKBAR_PART_THUMBLEFT = 7;
    public const int TRACKBAR_PART_THUMBRIGHT = 8;
    public const int TRACKBAR_PART_TICS = 9;
    public const int TRACKBAR_PART_TICSVERT = 10;
    public const int TRACKBAR_TICK_STATE_NORMAL = 1;
    public const int TRACKBAR_TRACK_STATE_NORMAL = 1;
    public const int TRACKBAR_THUMB_STATE_NORMAL = 1;
    public const int TRACKBAR_THUMB_STATE_HOT = 2;
    public const int TRACKBAR_THUMB_STATE_PRESSED = 3;
    public const int TRACKBAR_THUMB_STATE_FOCUSED = 4;
    public const int TRACKBAR_THUMB_STATE_DISABLED = 5;
    public const int TOOLBAR_PART_BUTTON = 1;
    public const int TOOLBAR_PART_DROPDOWNBUTTON = 2;
    public const int TOOLBAR_PART_SPLITBUTTON = 3;
    public const int TOOLBAR_PART_SPLITBUTTONDROPDOWN = 4;
    public const int TOOLBAR_PART_SEPARATOR = 5;
    public const int TOOLBAR_PART_SEPARATORVERT = 6;
    public const int TOOLBAR_STATE_NORMAL = 1;
    public const int TOOLBAR_STATE_HOT = 2;
    public const int TOOLBAR_STATE_PRESSED = 3;
    public const int TOOLBAR_STATE_DISABLED = 4;
    public const int TOOLBAR_STATE_CHECKED = 5;
    public const int TOOLBAR_STATE_HOTCHECKED = 6;
    public const int TAB_PART_TABITEM = 1;
    public const int TAB_PART_TABITEMLEFTEDGE = 2;
    public const int TAB_PART_TABITEMRIGHTEDGE = 3;
    public const int TAB_PART_TABITEMBOTHEDGE = 4;
    public const int TAB_PART_TOPTABITEM = 5;
    public const int TAB_PART_TOPTABITEMLEFTEDGE = 6;
    public const int TAB_PART_TOPTABITEMRIGHTEDGE = 7;
    public const int TAB_PART_TOPTABITEMBOTHEDGE = 8;
    public const int TAB_PART_PANE = 9;
    public const int TAB_PART_BODY = 10;
    public const int TAB_STATE_NORMAL = 1;
    public const int TAB_STATE_HOT = 2;
    public const int TAB_STATE_SELECTED = 3;
    public const int TAB_STATE_DISABLED = 4;
    public const int TAB_STATE_FOCUSED = 5;
    public const int SPIN_PART_UP = 1;
    public const int SPIN_PART_DOWN = 2;
    public const int SPIN_PART_UPHORZ = 3;
    public const int SPIN_PART_DOWNHORZ = 4;
    public const int SPIN_STATE_NORMAL = 1;
    public const int SPIN_STATE_HOT = 2;
    public const int SPIN_STATE_PRESSED = 3;
    public const int SPIN_STATE_DISABLED = 4;
    public const int WINDOW_PART_CAPTION = 1;
    public const int WINDOW_PART_SMALLCAPTION = 2;
    public const int WINDOW_PART_MINCAPTION = 3;
    public const int WINDOW_PART_SMALLMINCAPTION = 4;
    public const int WINDOW_PART_MAXCAPTION = 5;
    public const int WINDOW_PART_SMALLMAXCAPTION = 6;
    public const int WINDOW_PART_FRAMELEFT = 7;
    public const int WINDOW_PART_FRAMERIGHT = 8;
    public const int WINDOW_PART_FRAMEBOTTOM = 9;
    public const int WINDOW_PART_SMALLFRAMELEFT = 10;
    public const int WINDOW_PART_SMALLFRAMERIGHT = 11;
    public const int WINDOW_PART_SMALLFRAMEBOTTOM = 12;
    public const int WINDOW_PART_SYSBUTTON = 13;
    public const int WINDOW_PART_MDISYSBUTTON = 14;
    public const int WINDOW_PART_MINBUTTON = 15;
    public const int WINDOW_PART_MDIMINBUTTON = 16;
    public const int WINDOW_PART_MAXBUTTON = 17;
    public const int WINDOW_PART_CLOSEBUTTON = 18;
    public const int WINDOW_PART_SMALLCLOSEBUTTON = 19;
    public const int WINDOW_PART_MDICLOSEBUTTON = 20;
    public const int WINDOW_PART_RESTOREBUTTON = 21;
    public const int WINDOW_PART_MDIRESTOREBUTTON = 22;
    public const int WINDOW_PART_HELPBUTTON = 23;
    public const int WINDOW_PART_MDIHELPBUTTON = 24;
    public const int WINDOW_PART_HORZSCROLL = 25;
    public const int WINDOW_PART_HORZTHUMB = 26;
    public const int WINDOW_PART_VERTSCROLL = 27;
    public const int WINDOW_PART_VERTTHUMB = 28;
    public const int WINDOW_PART_DIALOG = 29;
    public const int WINDOW_PART_CAPTIONSIZINGTEMPLATE = 30;
    public const int WINDOW_PART_SMALLCAPTIONSIZINGTEMPLATE = 31;
    public const int WINDOW_PART_FRAMELEFTSIZINGTEMPLATE = 32;
    public const int WINDOW_PART_SMALLFRAMELEFTSIZINGTEMPLATE = 33;
    public const int WINDOW_PART_FRAMERIGHTSIZINGTEMPLATE = 34;
    public const int WINDOW_PART_SMALLFRAMERIGHTSIZINGTEMPLATE = 35;
    public const int WINDOW_PART_FRAMEBOTTOMSIZINGTEMPLATE = 36;
    public const int WINDOW_PART_SMALLFRAMEBOTTOMSIZINGTEMPLATE = 37;
    public const int WINDOW_FRAME_STATE_ACTIVE = 1;
    public const int WINDOW_FRAME_STATE_INACTIVE = 2;
    public const int WINDOW_CAPTION_STATE_ACTIVE = 1;
    public const int WINDOW_CAPTION_STATE_INACTIVE = 2;
    public const int WINDOW_CAPTION_STATE_DISABLED = 3;
    public const int HEADER_PART_ITEM = 1;
    public const int HEADER_PART_ITEM_LEFT = 2;
    public const int HEADER_PART_ITEM_RIGHT = 3;
    public const int HEADER_STATE_NORMAL = 1;
    public const int HEADER_STATE_HOT = 2;
    public const int HEADER_STATE_PRESSED = 3;
    public const int TREE_PART_TREEITEM = 1;
    public const int TREE_PART_GLYPH = 2;
    public const int TREE_PART_BRANCH = 3;
    public const int TREE_ITEM_STATE_NORMAL = 1;
    public const int TREE_ITEM_STATE_HOT = 2;
    public const int TREE_ITEM_STATE_SELECTED = 3;
    public const int TREE_ITEM_STATE_DISABLED = 4;
    public const int TREE_ITEM_STATE_SELECTEDNOTFOCUS = 5;
    public const int TREE_GLYPH_STATE_CLOSED = 1;
    public const int TREE_GLYPH_STATE_OPENED = 2;
    public const int TREE_BRANCH_STATE_NORMAL = 1;
    private Bitmap fCachedRowHdr;
    private bool fIsCachedRowHdrRTL;
    private bool fExtraHeaderLineVisible;
    private bool fDisposed;

    public iGControlPaintXP()
    {
      this.SetExtraHeaderLineVisible();
      SystemEvents.UserPreferenceChanged += new UserPreferenceChangedEventHandler(this.SystemEvents_UserPreferenceChanged);
    }

    private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
    {
      if (e.Category != UserPreferenceCategory.VisualStyle)
        return;
      if (this.fCachedRowHdr != null)
      {
        this.fCachedRowHdr.Dispose();
        this.fCachedRowHdr = (Bitmap) null;
      }
      lock (iGControlPaintXP.ThemeData)
      {
        for (int index = 0; index < iGControlPaintXP.ThemeData.GetLength(0); ++index)
        {
          if (iGControlPaintXP.ThemeData[index] != IntPtr.Zero)
          {
            iGNativeMethods.CloseThemeData(iGControlPaintXP.ThemeData[index]);
            iGControlPaintXP.ThemeData[index] = IntPtr.Zero;
          }
        }
      }
      this.SetExtraHeaderLineVisible();
    }

    private void SetExtraHeaderLineVisible()
    {
      iGNativeMethods.RTL_OSVERSIONINFOEXW PRTL_OSVERSIONINFOW = new iGNativeMethods.RTL_OSVERSIONINFOEXW();
      PRTL_OSVERSIONINFOW.dwOSVersionInfoSize = Convert.ToUInt32(Marshal.SizeOf((object) PRTL_OSVERSIONINFOW));
      iGNativeMethods.RtlGetVersion(PRTL_OSVERSIONINFOW);
      this.fExtraHeaderLineVisible = PRTL_OSVERSIONINFOW.dwMajorVersion >= 10U;
    }

    public Size GetHeaderSortIconSize()
    {
      return new Size(9, 5);
    }

    public void DrawHeader(Graphics g, int x, int y, int width, int height, iGHeaderPart headerPart, iGControlState controlState, bool rightToLeft)
    {
      int themePart;
      switch (headerPart)
      {
        case iGHeaderPart.Item:
          themePart = 1;
          break;
        case iGHeaderPart.ItemLeft:
          themePart = 2;
          break;
        case iGHeaderPart.SortArrowUp:
          iGDrawGridItem.DrawArrow(g, this.fForeColor, x, y, 5, iGArrowDirection.Up);
          return;
        case iGHeaderPart.SortArrowDown:
          iGDrawGridItem.DrawArrow(g, this.fForeColor, x, y, 5, iGArrowDirection.Down);
          return;
        default:
          themePart = 3;
          break;
      }
      int themeState;
      switch (controlState)
      {
        case iGControlState.Normal:
        case iGControlState.Disabled:
          themeState = 1;
          break;
        case iGControlState.Hot:
          themeState = 2;
          break;
        case iGControlState.Pressed:
        case iGControlState.HotPressed:
          themeState = 3;
          break;
        default:
          themeState = 1;
          break;
      }
      if (!rightToLeft)
      {
        this.DrawTheme(g, iGXPThemeClasses.header, themePart, themeState, x, y, width, height);
      }
      else
      {
        using (Bitmap bitmap = new Bitmap(width, height, g))
        {
          using (Graphics graphics = Graphics.FromImage((Image) bitmap))
            this.DrawTheme(graphics, iGXPThemeClasses.header, themePart, themeState, 0, 0, width, height);
          bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
          g.DrawImage((Image) bitmap, x, y);
        }
      }
      if (!this.fExtraHeaderLineVisible)
        return;
      int num = y + height - 1;
      g.DrawLine(iGControlPaintXP.fExtraHeaderLinePen, x, num, x + width - 1, num);
    }

    public void DrawSizeBox(Graphics g, int x, int y, int width, int height, iGSizeBoxAlign align)
    {
      int themeState = align != iGSizeBoxAlign.Left ? 1 : 2;
      this.DrawTheme(g, iGXPThemeClasses.scrollbar, 10, themeState, x, y, width, height);
    }

    public void DrawScrollBar(Graphics g, int x, int y, int width, int height, iGScrollBarPart scrollPart, iGControlState controlState)
    {
      int themePart1 = -1;
      int themePart2;
      int themeState;
      switch (scrollPart)
      {
        case iGScrollBarPart.ButtonUp:
          themePart2 = 1;
          themeState = controlState != iGControlState.HotPressed ? (controlState == iGControlState.Hot || controlState == iGControlState.Pressed ? 2 : (controlState != iGControlState.Disabled ? 1 : 4)) : 3;
          break;
        case iGScrollBarPart.ButtonDown:
          themePart2 = 1;
          themeState = controlState != iGControlState.HotPressed ? (controlState == iGControlState.Hot || controlState == iGControlState.Pressed ? 6 : (controlState != iGControlState.Disabled ? 5 : 8)) : 7;
          break;
        case iGScrollBarPart.ButtonLeft:
          themePart2 = 1;
          themeState = controlState != iGControlState.HotPressed ? (controlState == iGControlState.Hot || controlState == iGControlState.Pressed ? 10 : (controlState != iGControlState.Disabled ? 9 : 12)) : 11;
          break;
        case iGScrollBarPart.ButtonRight:
          themePart2 = 1;
          themeState = controlState != iGControlState.HotPressed ? (controlState == iGControlState.Hot || controlState == iGControlState.Pressed ? 14 : (controlState != iGControlState.Disabled ? 13 : 16)) : 15;
          break;
        case iGScrollBarPart.ThumbHorz:
          themePart2 = 2;
          themeState = this.GetScrollThumbState(controlState);
          if (controlState != iGControlState.Disabled && width >= 12)
          {
            themePart1 = 8;
            break;
          }
          break;
        case iGScrollBarPart.ThumbVert:
          themePart2 = 3;
          themeState = this.GetScrollThumbState(controlState);
          if (controlState != iGControlState.Disabled && height >= 12)
          {
            themePart1 = 9;
            break;
          }
          break;
        case iGScrollBarPart.UpperTrackHorz:
          themePart2 = 5;
          themeState = this.GetScrollTrackState(controlState);
          break;
        case iGScrollBarPart.LowerTrackHorz:
          themePart2 = 4;
          themeState = this.GetScrollTrackState(controlState);
          break;
        case iGScrollBarPart.UpperTrackVert:
          themePart2 = 7;
          themeState = this.GetScrollTrackState(controlState);
          break;
        default:
          themePart2 = 6;
          themeState = this.GetScrollTrackState(controlState);
          break;
      }
      this.DrawTheme(g, iGXPThemeClasses.scrollbar, themePart2, themeState, x, y, width, height);
      if (themePart1 == -1)
        return;
      this.DrawTheme(g, iGXPThemeClasses.scrollbar, themePart1, 0, x, y, width, height);
    }

    private int GetScrollThumbState(iGControlState controlState)
    {
      if (controlState == iGControlState.Hot)
        return 2;
      if (controlState == iGControlState.Pressed)
        return 3;
      return controlState == iGControlState.Disabled ? 4 : 1;
    }

    private int GetScrollTrackState(iGControlState controlState)
    {
      if (controlState == iGControlState.Pressed || controlState == iGControlState.Hot)
        return 2;
      if (controlState == iGControlState.HotPressed)
        return 3;
      return controlState == iGControlState.Disabled ? 4 : 1;
    }

    public void DrawCheckBox(Graphics g, int x, int y, int width, int height, CheckState checkState, iGControlState controlState)
    {
      int themeState;
      switch (controlState)
      {
        case iGControlState.Hot:
        case iGControlState.Pressed:
          themeState = checkState != CheckState.Checked ? (checkState != CheckState.Indeterminate ? 2 : 10) : 6;
          break;
        case iGControlState.HotPressed:
          themeState = checkState != CheckState.Checked ? (checkState != CheckState.Indeterminate ? 3 : 11) : 7;
          break;
        case iGControlState.Disabled:
          themeState = checkState != CheckState.Checked ? (checkState != CheckState.Indeterminate ? 4 : 12) : 8;
          break;
        default:
          themeState = checkState != CheckState.Checked ? (checkState != CheckState.Indeterminate ? 1 : 9) : 5;
          break;
      }
      this.DrawTheme(g, iGXPThemeClasses.button, 3, themeState, x, y, width, height);
    }

    public Size GetCheckBoxSize()
    {
      Size size;
      this.GetThemePartSize(iGXPThemeClasses.button, 3, 5, Rectangle.Empty, iGNativeMethods.iGTHEME_SIZE.TS_TRUE, out size);
      return size;
    }

    public void DrawComboButton(Graphics g, int x, int y, int width, int height, iGControlState controlState, bool isHeader)
    {
      int themeState;
      switch (controlState)
      {
        case iGControlState.Hot:
        case iGControlState.Pressed:
          themeState = 2;
          break;
        case iGControlState.HotPressed:
          themeState = 3;
          break;
        case iGControlState.Disabled:
          themeState = 4;
          break;
        default:
          themeState = 1;
          break;
      }
      this.DrawTheme(g, iGXPThemeClasses.combobox, 1, themeState, x, y, width, height);
    }

    public iGInternalControlPaintStyle GetStyle()
    {
      return iGInternalControlPaintStyle.StyleXP;
    }

    private IntPtr GetThemeData(iGXPThemeClasses aThemeClass)
    {
      try
      {
        if (iGControlPaintXP.ThemeData[(int) aThemeClass] == IntPtr.Zero)
          iGControlPaintXP.ThemeData[(int) aThemeClass] = iGNativeMethods.OpenThemeData(IntPtr.Zero, aThemeClass.ToString());
        return iGControlPaintXP.ThemeData[(int) aThemeClass];
      }
      catch
      {
        return IntPtr.Zero;
      }
    }

    private bool GetThemePartSize(iGXPThemeClasses themeClass, int themePart, int themeState, Rectangle rect, iGNativeMethods.iGTHEME_SIZE themeSize, out Size size)
    {
      iGNativeMethods.iGRECT prc = new iGNativeMethods.iGRECT(rect);
      return iGNativeMethods.GetThemePartSize(this.GetThemeData(themeClass), IntPtr.Zero, themePart, themeState, ref prc, themeSize, out size) >= 0;
    }

    private bool DrawTheme(Graphics graphics, iGXPThemeClasses themeClass, int themePart, int themeState, int x, int y, int width, int height)
    {
      IntPtr hdc = graphics.GetHdc();
      try
      {
        iGNativeMethods.iGRECT iGrect = new iGNativeMethods.iGRECT(x, y, width, height);
        return 0 <= iGNativeMethods.DrawThemeBackground(this.GetThemeData(themeClass), hdc, themePart, themeState, ref iGrect, ref iGrect);
      }
      catch
      {
        return false;
      }
      finally
      {
        graphics.ReleaseHdc(hdc);
      }
    }

    public void OnSettingChange()
    {
    }

    public void DrawScrollBarCustomButton(Graphics g, int x, int y, int width, int height, iGControlState controlState)
    {
      int themeState = controlState != iGControlState.HotPressed ? (controlState == iGControlState.Hot || controlState == iGControlState.Pressed ? 2 : (controlState != iGControlState.Disabled ? 1 : 4)) : 3;
      this.DrawTheme(g, iGXPThemeClasses.button, 1, themeState, x, y, width, height);
    }

    public void DrawEllipsisButton(Graphics g, int x, int y, int width, int height, iGControlState controlState)
    {
      int themeState;
      switch (controlState)
      {
        case iGControlState.Hot:
          themeState = 2;
          break;
        case iGControlState.Pressed:
        case iGControlState.HotPressed:
          themeState = 3;
          break;
        case iGControlState.Disabled:
          themeState = 4;
          break;
        default:
          themeState = 1;
          break;
      }
      this.DrawTheme(g, iGXPThemeClasses.button, 1, themeState, x, y, width, height);
    }

    public iGIndent GetHeaderIndent(bool rightToLeft)
    {
      return new iGIndent(2, 1, 2, 3);
    }

    public void DrawTreeButton(Graphics g, int x, int y, int width, int height, bool expanded)
    {
      int themeState = expanded ? 2 : 1;
      Size treeButtonSize = this.GetTreeButtonSize();
      if (width > treeButtonSize.Width)
        width = treeButtonSize.Width;
      if (height > treeButtonSize.Height)
        height = treeButtonSize.Height;
      this.DrawTheme(g, iGXPThemeClasses.treeview, 2, themeState, x, y, width, height);
    }

    public Size GetTreeButtonSize()
    {
      Size size;
      this.GetThemePartSize(iGXPThemeClasses.treeview, 2, 2, Rectangle.Empty, iGNativeMethods.iGTHEME_SIZE.TS_TRUE, out size);
      return size;
    }

    public void DrawRowHdr(Graphics g, int x, int y, int width, int height, iGControlState controlState, bool rightToLeft)
    {
      if (width <= 0 || height <= 0)
        return;
      Bitmap bitmap = (Bitmap) null;
      if (this.fCachedRowHdr != null && this.fCachedRowHdr.Width == width && (this.fCachedRowHdr.Height == height && rightToLeft == this.fIsCachedRowHdrRTL) && controlState == iGControlState.Normal)
        bitmap = this.fCachedRowHdr;
      if (bitmap == null)
      {
        bitmap = new Bitmap(height, width, g);
        using (Graphics g1 = Graphics.FromImage((Image) bitmap))
        {
          this.DrawHeader(g1, 0, 0, bitmap.Width, bitmap.Height, iGHeaderPart.Item, controlState, false);
          if (rightToLeft)
            bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
          else
            bitmap.RotateFlip(RotateFlipType.Rotate90FlipX);
        }
        if (controlState == iGControlState.Normal)
        {
          if (this.fCachedRowHdr != null)
            this.fCachedRowHdr.Dispose();
          this.fCachedRowHdr = bitmap;
          this.fIsCachedRowHdrRTL = rightToLeft;
        }
      }
      g.DrawImage((Image) bitmap, x, y);
      if (bitmap == this.fCachedRowHdr)
        return;
      bitmap.Dispose();
    }

    public iGIndent GetRowHdrIndent(bool rightToLeft)
    {
      if (rightToLeft)
        return new iGIndent(3, 1, 1, 2);
      return new iGIndent(1, 1, 3, 2);
    }

    public void DrawGroupBoxBackground(Graphics g, int x, int y, int width, int height, bool rightToLeft)
    {
      throw new NotImplementedException();
    }

    public System.Drawing.Color ControlsForeColor
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

    public System.Drawing.Color ControlsBackColor
    {
      get
      {
        return iGControlPaintStyle.cDefaultBackColor;
      }
      set
      {
      }
    }

    public iGIndent GetScrollBarCustomButtonIndent
    {
      get
      {
        return new iGIndent(2, 2, 1, 1);
      }
    }

    public bool OffsetScrollBarCustomButtonImageWhenPressed
    {
      get
      {
        return false;
      }
    }

    public System.Drawing.Color ControlsDisabledForeColor
    {
      get
      {
        return SystemColors.ControlDark;
      }
    }

    public iGControlPaintFunctions SupportedFunctions
    {
      get
      {
        return (iGControlPaintFunctions) 65023;
      }
    }

    protected virtual void Dispose(bool disposing)
    {
      if (this.fDisposed)
        return;
      if (disposing)
        SystemEvents.UserPreferenceChanged -= new UserPreferenceChangedEventHandler(this.SystemEvents_UserPreferenceChanged);
      this.fDisposed = true;
    }

    public void Dispose()
    {
      this.Dispose(true);
    }
  }
}
