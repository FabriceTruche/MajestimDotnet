// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGNativeToolTip
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  internal class iGNativeToolTip : IDisposable
  {
    private iGNativeToolTip.iGToolTipNativeWindow fWindow;
    private Control fControl;
    private bool fTracking;
    private bool fDisposed;

    public iGNativeToolTip(Control control, bool tracking)
    {
      this.fControl = control;
      this.fTracking = tracking;
    }

    ~iGNativeToolTip()
    {
      this.Dispose(false);
    }

    public void SetText(string text)
    {
      iGNativeMethods.iGTOOLINFO toolTipInfo = this.GetToolTipInfo(text);
      iGNativeMethods.SendMessage(this.Window.Handle, iGNativeMethods.TTM_UPDATETIPTEXT, IntPtr.Zero, ref toolTipInfo);
    }

    public void Reset()
    {
      if (this.fWindow == null)
        return;
      this.fWindow.DestroyHandle();
      this.fWindow = (iGNativeToolTip.iGToolTipNativeWindow) null;
    }

    public void Dispose()
    {
      this.Dispose(true);
    }

    private void Dispose(bool disposing)
    {
      if (!this.fDisposed && disposing && this.fWindow != null)
        this.fWindow.Dispose();
      this.fDisposed = true;
    }

    protected iGNativeMethods.iGTOOLINFO GetToolTipInfo(string text)
    {
      iGNativeMethods.iGTOOLINFO iGtoolinfo = new iGNativeMethods.iGTOOLINFO();
      iGtoolinfo.uFlags = 273;
      if (this.fTracking)
        iGtoolinfo.uFlags |= 32;
      iGtoolinfo.hwnd = this.fControl.Handle;
      iGtoolinfo.uId = this.fControl.Handle;
      if (this.fControl.RightToLeft == RightToLeft.Yes)
        iGtoolinfo.uFlags |= 4;
      iGtoolinfo.lpszText = text;
      iGtoolinfo.cbSize = Marshal.SizeOf((object) iGtoolinfo);
      return iGtoolinfo;
    }

    public void ShowTracking(int x, int y)
    {
      iGNativeMethods.iGTOOLINFO toolTipInfo = this.GetToolTipInfo((string) null);
      iGNativeMethods.SendMessage(this.Window.Handle, 1041, (IntPtr) 1, ref toolTipInfo);
      iGNativeMethods.SendMessage(this.Window.Handle, 1042, IntPtr.Zero, iGNativeMethods.MakeLong(x, y));
    }

    public void HideTracking()
    {
      iGNativeMethods.SendMessage(this.Window.Handle, 1041, IntPtr.Zero, IntPtr.Zero);
    }

    protected CreateParams CreateParams
    {
      get
      {
        return new CreateParams()
        {
          ClassName = "tooltips_class32",
          Style = 1,
          ExStyle = 8
        };
      }
    }

    protected NativeWindow Window
    {
      get
      {
        if (this.fWindow == null)
        {
                    // FABRICE
            int size;
            unsafe
            {
                size = sizeof(iGNativeMethods.iGINITCOMMONCONTROLSEX);
            }
            var tmp = new iGNativeMethods.iGINITCOMMONCONTROLSEX()
            {
                dwICC = 8,
                dwSize = size // sizeof(iGNativeMethods.iGINITCOMMONCONTROLSEX)
            };


          iGNativeMethods.InitCommonControlsEx(ref tmp);


          this.fWindow = new iGNativeToolTip.iGToolTipNativeWindow(this);
          this.fWindow.CreateHandle(this.CreateParams);
          iGNativeMethods.SetWindowPos(this.fWindow.Handle, (IntPtr) (-1), 0, 0, 0, 0, 19U);
          iGNativeMethods.SendMessage(this.fWindow.Handle, 1048, IntPtr.Zero, (IntPtr) SystemInformation.MaxWindowTrackSize.Width);
          iGNativeMethods.iGTOOLINFO toolTipInfo = this.GetToolTipInfo("");
          iGNativeMethods.SendMessage(this.fWindow.Handle, iGNativeMethods.TTM_ADDTOOL, IntPtr.Zero, ref toolTipInfo);
        }
        return (NativeWindow) this.fWindow;
      }
    }

    public bool Active
    {
      set
      {
        iGNativeMethods.SendMessage(this.Window.Handle, 1025, (IntPtr) Convert.ToInt32(value), IntPtr.Zero);
      }
    }

    public bool Visible
    {
      get
      {
        return iGNativeMethods.IsWindowVisible(this.Window.Handle);
      }
    }

    public IntPtr Handle
    {
      get
      {
        return this.Window.Handle;
      }
    }

    public class iGToolTipNativeWindow : NativeWindow, IDisposable
    {
      private iGNativeToolTip fToolTip;

      public iGToolTipNativeWindow(iGNativeToolTip toolTip)
      {
        this.fToolTip = toolTip;
      }

      ~iGToolTipNativeWindow()
      {
        this.Dispose();
      }

      public void Dispose()
      {
        this.DestroyHandle();
      }
    }
  }
}
