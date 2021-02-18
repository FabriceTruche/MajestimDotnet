// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGDropDownForm
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  internal class iGDropDownForm : Form
  {
    private bool fMakeMainFormInactiveOnHide = true;
    private bool fCanActivate = true;
    private bool fSizeable;
    private bool fCloseButton;
    private Form fTopLevelOwnerForm;
    private Control fDropDownOwnerGrid;
    private bool fDoNotHideWhenDeactivate;

    public iGDropDownForm()
    {
      this.StartPosition = FormStartPosition.Manual;
      this.ShowInTaskbar = false;
      this.SetSizeableCore(false);
      this.CloseButton = false;
      this.Deactivate += new EventHandler(this.DropDownForm_Deactivate);
      this.FormClosing += new FormClosingEventHandler(this.DropDownForm_FormClosing);
    }

    public new void Show()
    {
      this.EnsureHandleCreated();
      this.Owner = this.fTopLevelOwnerForm;
      if (this.fCanActivate)
      {
        iGNativeMethods.ShowWindow(this.Handle, 1);
      }
      else
      {
        iGNativeMethods.ShowWindow(this.Handle, 4);
        iGNativeMethods.SetWindowPos(this.Handle, (IntPtr) (-1), 0, 0, 0, 0, 19U);
      }
    }

    public void EnsureHandleCreated()
    {
      if (this.IsHandleCreated)
        return;
      this.CreateHandle();
    }

    public bool CloseButton
    {
      get
      {
        return this.fCloseButton;
      }
      set
      {
        this.fCloseButton = value;
        this.ControlBox = value;
      }
    }

    public bool Sizeable
    {
      get
      {
        return this.fSizeable;
      }
      set
      {
        if (this.fSizeable == value)
          return;
        this.SetSizeableCore(value);
      }
    }

    private void SetSizeableCore(bool value)
    {
      this.fSizeable = value;
      if (value)
      {
        this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
        this.DockPadding.All = 0;
        this.SetShadowFlag(false);
      }
      else
      {
        this.FormBorderStyle = FormBorderStyle.None;
        this.DockPadding.All = 1;
        this.SetShadowFlag(true);
      }
    }

    private void SetShadowFlag(bool needShadow)
    {
      if (!this.IsAeroThemeEnabled())
        return;
      if (needShadow)
      {
        int attrValue = 2;
        iGNativeMethods.DwmSetWindowAttribute(this.Handle, 2, ref attrValue, 4);
        iGNativeMethods.MARGINS pMarInset = new iGNativeMethods.MARGINS()
        {
          bottomHeight = 1,
          leftWidth = 1,
          rightWidth = 1,
          topHeight = 1
        };
        iGNativeMethods.DwmExtendFrameIntoClientArea(this.Handle, ref pMarInset);
      }
      else
      {
        int attrValue = 0;
        iGNativeMethods.DwmSetWindowAttribute(this.Handle, 2, ref attrValue, 4);
        iGNativeMethods.MARGINS pMarInset = new iGNativeMethods.MARGINS()
        {
          bottomHeight = 0,
          leftWidth = 0,
          rightWidth = 0,
          topHeight = 0
        };
        iGNativeMethods.DwmExtendFrameIntoClientArea(this.Handle, ref pMarInset);
      }
    }

    public int TitleBarHeight()
    {
      if (this.fSizeable && (this.fCloseButton || !string.IsNullOrEmpty(this.Text)))
        return SystemInformation.ToolWindowCaptionHeight;
      return 0;
    }

    public Size BorderSize
    {
      get
      {
        if (this.fSizeable)
          return new Size((this.Size.Width - this.ClientSize.Width) / 2, (this.Size.Height - this.ClientSize.Height - this.TitleBarHeight()) / 2);
        return new Size(1, 1);
      }
    }

    public Size MinSize
    {
      get
      {
        if (this.fSizeable)
          return SystemInformation.MinimumWindowSize;
        return new Size(2, 2);
      }
    }

    public Form TopLevelOwnerForm
    {
      get
      {
        return this.fTopLevelOwnerForm;
      }
      set
      {
        this.fTopLevelOwnerForm = value;
      }
    }

    public Control DropDownOwnerGrid
    {
      get
      {
        return this.fDropDownOwnerGrid;
      }
      set
      {
        this.fDropDownOwnerGrid = value;
      }
    }

    public bool MakeMainFormInactiveOnHide
    {
      get
      {
        return this.fMakeMainFormInactiveOnHide;
      }
      set
      {
        this.fMakeMainFormInactiveOnHide = value;
      }
    }

    public bool CanActivate
    {
      get
      {
        return this.fCanActivate;
      }
      set
      {
        this.fCanActivate = value;
      }
    }

    public bool DoNotHideWhenDeactivate
    {
      get
      {
        return this.fDoNotHideWhenDeactivate;
      }
      set
      {
        this.fDoNotHideWhenDeactivate = value;
      }
    }

    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
      if (this.fSizeable)
        return;
      pevent.Graphics.DrawRectangle(SystemPens.ControlDarkDark, 0, 0, this.Width - 1, this.Height - 1);
    }

    protected override void OnVisibleChanged(EventArgs e)
    {
      if (!this.Visible)
        this.Owner = (Form) null;
      base.OnVisibleChanged(e);
    }

    private void DropDownForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      this.Hide();
      e.Cancel = true;
    }

    private void DropDownForm_Deactivate(object sender, EventArgs e)
    {
      if (this.fDoNotHideWhenDeactivate)
        return;
      int num = this.fMakeMainFormInactiveOnHide ? 1 : 0;
      this.Hide();
      if (num == 0 || this.fTopLevelOwnerForm == null || (!this.fTopLevelOwnerForm.IsHandleCreated || this.fTopLevelOwnerForm.IsDisposed) || Form.ActiveForm == this.fTopLevelOwnerForm)
        return;
      if (this.fDropDownOwnerGrid != null)
        this.fDropDownOwnerGrid.Invalidate();
      iGNativeMethods.SendMessage(this.fTopLevelOwnerForm.Handle, 134, IntPtr.Zero, IntPtr.Zero);
    }

    protected override void WndProc(ref Message m)
    {
      if (!this.fCanActivate && m.Msg == 33)
        m.Result = (IntPtr) 3;
      else
        base.WndProc(ref m);
    }

    private bool IsAeroThemeEnabled()
    {
      if (Environment.OSVersion.Version.Major <= 5)
        return false;
      bool enabled;
      iGNativeMethods.DwmIsCompositionEnabled(out enabled);
      return enabled;
    }
  }
}
