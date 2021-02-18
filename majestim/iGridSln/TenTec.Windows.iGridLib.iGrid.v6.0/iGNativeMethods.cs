// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGNativeMethods
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace TenTec.Windows.iGridLib
{
  internal class iGNativeMethods
  {
    public const int TTS_ALWAYSTIP = 1;
    public const uint TTN_SHOW = 4294966775;
    public const int TTF_IDISHWND = 1;
    public const int TTF_SUBCLASS = 16;
    public const int TTF_TRANSPARENT = 256;
    public const int TTF_RTLREADING = 4;
    public const int TTF_TRACK = 32;
    public const int TTF_ABSOLUTE = 128;
    public const int TTM_SETTOOLINFOA = 1033;
    public const int TTM_SETTOOLINFOW = 1078;
    public static int TTM_SETTOOLINFO;
    public const int TTM_ADDTOOLA = 1028;
    public const int TTM_ADDTOOLW = 1074;
    public static int TTM_ADDTOOL;
    public const int TTM_ACTIVATE = 1025;
    public const int TTM_WINDOWFROMPOINT = 1040;
    public const int TTM_GETTEXTA = 1025;
    public const int TTM_GETTEXTW = 1080;
    public static int TTM_GETTEXT;
    public const int TTM_UPDATETIPTEXTA = 1036;
    public const int TTM_UPDATETIPTEXTW = 1081;
    public static int TTM_UPDATETIPTEXT;
    public const int TTM_UPDATE = 1053;
    public const int TTM_DELTOOLA = 1029;
    public const int TTM_DELTOOLW = 1075;
    public static int TTM_DELTOOL;
    public const int TTM_SETMAXTIPWIDTH = 1048;
    public const int TTM_TRACKACTIVATE = 1041;
    public const int TTM_TRACKPOSITION = 1042;
    public const int EM_GETPASSWORDCHAR = 210;
    public const int SW_SHOWNORMAL = 1;
    public const int SW_SHOWNOACTIVATE = 4;
    public const int SW_HIDE = 0;
    public const int HWND_TOP = 0;
    public const int HWND_TOPMOST = -1;
    public const int SWP_NOSIZE = 1;
    public const int SWP_NOMOVE = 2;
    public const int SWP_NOACTIVATE = 16;
    public const int SWP_NOZORDER = 4;
    public const int SWP_SHOWWINDOW = 64;
    public const int CS_VREDRAW = 1;
    public const int CS_HREDRAW = 2;
    public const int WM_SETTINGCHANGE = 26;
    public const int WM_MOUSEWHEEL = 522;
    public const int WM_CANCELMODE = 31;
    public const int WM_THEMECHANGED = 794;
    public const int WM_NCHITTEST = 132;
    public const int WM_NOTIFY = 78;
    public const int WM_USER = 1024;
    public const int WM_MOUSEMOVE = 512;
    public const int WM_LBUTTONDOWN = 513;
    public const int WM_LBUTTONUP = 514;
    public const int WM_LBUTTONDBLCLK = 515;
    public const int WM_RBUTTONDOWN = 516;
    public const int WM_RBUTTONUP = 517;
    public const int WM_RBUTTONDBLCLK = 518;
    public const int WM_MBUTTONDOWN = 519;
    public const int WM_MBUTTONUP = 520;
    public const int WM_MBUTTONDBLCLK = 521;
    public const int WM_CAPTURECHANGED = 533;
    public const int WM_ACTIVATE = 6;
    public const int WM_KILLFOCUS = 8;
    public const int WM_NCACTIVATE = 134;
    public const int WM_MOUSEACTIVATE = 33;
    public const int MA_NOACTIVATE = 3;
    public const int MA_NOACTIVATEANDEAT = 4;
    public const int WS_VSCROLL = 2097152;
    public const int WS_HSCROLL = 1048576;
    public const int WS_POPUP = -2147483648;
    public const int WS_VISIBLE = 268435456;
    public const int WS_DISABLED = 134217728;
    public const int WS_THICKFRAME = 262144;
    public const int WS_EX_TRANSPARENT = 32;
    public const int WS_EX_TOPMOST = 8;
    public const int WS_EX_LAYERED = 524288;
    public const int WS_EX_TOOLWINDOW = 128;
    public const int WS_EX_NOACTIVATE = 134217728;
    public const int HTBOTTOMRIGHT = 17;
    public const int HTBOTTOMLEFT = 16;
    public const int HTCLIENT = 1;
    public const int HTHSCROLL = 6;
    public const int HTVSCROLL = 7;
    public const int HTSIZE = 4;
    public const int HTTRANSPARENT = -1;
    public const int GWL_STYLE = -16;
    public const int CS_DROPSHADOW = 131072;
    public const int SW_INVALIDATE = 2;
    public const int DWMWA_NCRENDERING_POLICY = 2;
    public const int DWMNCRP_USEWINDOWSTYLE = 0;
    public const int DWMNCRP_DISABLED = 1;
    public const int DWMNCRP_ENABLED = 2;

    static iGNativeMethods()
    {
      if (Marshal.SystemDefaultCharSize == 1)
      {
        iGNativeMethods.TTM_SETTOOLINFO = 1033;
        iGNativeMethods.TTM_ADDTOOL = 1028;
        iGNativeMethods.TTM_GETTEXT = 1025;
        iGNativeMethods.TTM_UPDATETIPTEXT = 1036;
        iGNativeMethods.TTM_DELTOOL = 1029;
      }
      else
      {
        iGNativeMethods.TTM_SETTOOLINFO = 1078;
        iGNativeMethods.TTM_ADDTOOL = 1074;
        iGNativeMethods.TTM_GETTEXT = 1080;
        iGNativeMethods.TTM_UPDATETIPTEXT = 1081;
        iGNativeMethods.TTM_DELTOOL = 1075;
      }
    }

    [DllImport("user32.dll")]
    public static extern int ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("user32.dll")]
    public static extern bool GetUpdateRect(IntPtr hwnd, IntPtr rc, bool fErase);

    [DllImport("user32.dll")]
    public static extern bool ScrollWindowEx(IntPtr hWnd, int nXAmount, int nYAmount, ref iGNativeMethods.iGRECT rectScrollRegion, ref iGNativeMethods.iGRECT rectClip, IntPtr hrgnUpdate, IntPtr prcUpdate, int flags);

    public static IntPtr MakeLong(int x, int y)
    {
      return (IntPtr) (x & (int) ushort.MaxValue | (y & (int) ushort.MaxValue) << 16);
    }

    [DllImport("user32.dll")]
    public static extern bool IsWindowVisible(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref iGNativeMethods.iGTOOLINFO lParam);

    [DllImport("user32.dll")]
    public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr GetParent(IntPtr hWnd);

    [DllImport("comctl32.dll")]
    public static extern bool InitCommonControlsEx(ref iGNativeMethods.iGINITCOMMONCONTROLSEX icc);

    [DllImport("comctl32")]
    public static extern int ImageList_DrawIndirect(ref iGNativeMethods.IMAGELISTDRAWPARAMS pimldp);

    [DllImport("gdi32.dll")]
    public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

    [DllImport("gdi32.dll")]
    public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

    [DllImport("gdi32.dll")]
    public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hGdiObject);

    [DllImport("gdi32.dll")]
    public static extern bool DeleteObject(IntPtr hGdiObject);

    [DllImport("gdi32.dll")]
    public static extern int IntersectClipRect(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

    [DllImport("gdi32.dll")]
    public static extern int GetClipRgn(IntPtr hdc, IntPtr hrgn);

    [DllImport("gdi32.dll")]
    public static extern int SelectClipRgn(IntPtr hdc, IntPtr hrgn);

    [DllImport("gdi32.dll")]
    public static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

    [DllImport("uxtheme.dll")]
    public static extern int GetThemePartSize(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, ref iGNativeMethods.iGRECT prc, iGNativeMethods.iGTHEME_SIZE eSize, out Size psz);

    [DllImport("uxtheme.dll")]
    public static extern int DrawThemeBackground(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, ref iGNativeMethods.iGRECT pRect, ref iGNativeMethods.iGRECT pClipRect);

    [DllImport("uxtheme.dll")]
    public static extern IntPtr OpenThemeData(IntPtr hwnd, [MarshalAs(UnmanagedType.LPWStr)] string pszClassList);

    [DllImport("uxtheme.dll")]
    public static extern IntPtr CloseThemeData(IntPtr hTheme);

    [DllImport("dwmapi.dll")]
    public static extern int DwmIsCompositionEnabled(out bool enabled);

    [DllImport("dwmapi.dll")]
    public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

    [DllImport("dwmapi.dll")]
    public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref iGNativeMethods.MARGINS pMarInset);

    [DllImport("ntdll.dll")]
    public static extern int RtlGetVersion([In, Out] iGNativeMethods.RTL_OSVERSIONINFOEXW PRTL_OSVERSIONINFOW);

    public struct iGRECT
    {
      public int Left;
      public int Top;
      public int Right;
      public int Bottom;

      public iGRECT(int left, int top, int width, int height)
      {
        this.Left = left;
        this.Top = top;
        this.Right = left + width;
        this.Bottom = top + height;
      }

      public iGRECT(Rectangle rect)
      {
        this.Left = rect.Left;
        this.Top = rect.Top;
        this.Right = rect.Left + rect.Width;
        this.Bottom = rect.Top + rect.Height;
      }

      public Rectangle ToRectangle()
      {
        return new Rectangle(this.Left, this.Top, this.Right - this.Left, this.Bottom - this.Top);
      }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct iGTOOLINFO
    {
      internal int cbSize;
      internal int uFlags;
      internal IntPtr hwnd;
      internal IntPtr uId;
      internal iGNativeMethods.iGRECT rect;
      internal IntPtr hinst;
      internal string lpszText;
      internal IntPtr lParam;
    }

    public enum iGTHEME_SIZE
    {
      TS_MIN,
      TS_TRUE,
      TS_DRAW,
    }

    internal struct iGPOINT
    {
      public int X;
      public int Y;

      public iGPOINT(int x, int y)
      {
        this.X = x;
        this.Y = y;
      }
    }

    public struct iGINITCOMMONCONTROLSEX
    {
      public int dwICC;
      public int dwSize;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class RTL_OSVERSIONINFOEXW
    {
      public uint dwOSVersionInfoSize;
      public uint dwMajorVersion;
      public uint dwMinorVersion;
      public uint dwBuildNumber;
      public uint dwPlatformId;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
      public string szCSDVersion;
      public ushort wServicePackMajor;
      public ushort wServicePackMinor;
      public ushort wSuiteMask;
      public byte bProductType;
      public byte bReserved;
    }

    public struct IMAGELISTDRAWPARAMS
    {
      public int cbSize;
      public IntPtr himl;
      public int i;
      public IntPtr hdcDst;
      public int x;
      public int y;
      public int cx;
      public int cy;
      public int xBitmap;
      public int yBitmap;
      public int rgbBk;
      public int rgbFg;
      public int fStyle;
      public int dwRop;
      public int fState;
      public int Frame;
      public int crEffect;
    }

    public struct MARGINS
    {
      public int leftWidth;
      public int rightWidth;
      public int topHeight;
      public int bottomHeight;
    }
  }
}
