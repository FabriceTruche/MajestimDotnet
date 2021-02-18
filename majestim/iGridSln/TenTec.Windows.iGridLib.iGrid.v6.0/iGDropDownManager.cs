// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGDropDownManager
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  internal class iGDropDownManager : IDisposable
  {
    private static Dictionary<IntPtr, DisableNCActivateNativeWindow> fHooks = new Dictionary<IntPtr, DisableNCActivateNativeWindow>();
    private Control fOwnerGrid;
    private iGDropDownForm fDropDownForm;
    private IiGDropDownControl fDropDownControl;
    private bool fCancelValueOnHide;

    public iGDropDownManager(Control ownerGrid)
    {
      if (ownerGrid == null)
        throw new ArgumentNullException();
      this.fOwnerGrid = ownerGrid;
    }

    public void ShowDropDown(Rectangle ownerBounds, IiGDropDownControl dropDownControl, Control control, bool canActivate, bool commitOnHide, TextRenderingHint textRenderingHint)
    {
      if (dropDownControl == null || control == null)
        throw new ArgumentNullException();
      this.HideDropDown(true);
      Form form = this.fOwnerGrid.TopLevelControl as Form;
      if (form == null)
      {
        IntPtr num = this.fOwnerGrid.Handle;
        while (true)
        {
          IntPtr parent = iGNativeMethods.GetParent(num);
          if (!(parent == IntPtr.Zero))
            num = parent;
          else
            break;
        }
        form = Control.FromHandle(num) as Form;
      }
      if (canActivate && form != null)
      {
        DisableNCActivateNativeWindow activateNativeWindow = iGDropDownManager.AddHook(form);
        if (activateNativeWindow != null)
          activateNativeWindow.HookActive = true;
      }
      this.fCancelValueOnHide = !commitOnHide;
      this.fDropDownControl = dropDownControl;
      this.fDropDownControl.SetTextRenderingHint(textRenderingHint);
      if (this.fDropDownForm == null)
      {
        this.fDropDownForm = new iGDropDownForm();
        this.fDropDownForm.VisibleChanged += new EventHandler(this.DropDownForm_VisibleChanged);
        this.fDropDownForm.CreateControl();
      }
      this.fDropDownForm.TopLevelOwnerForm = form;
      this.fDropDownForm.DropDownOwnerGrid = this.fOwnerGrid;
      this.fDropDownForm.MakeMainFormInactiveOnHide = true;
      this.fDropDownForm.Sizeable = this.fDropDownControl.Sizeable;
      this.fDropDownForm.Text = this.fDropDownControl.Text;
      this.fDropDownForm.CloseButton = this.fDropDownControl.CloseButton;
      this.AdjustSizeAndLocation(this.fOwnerGrid, ownerBounds);
      control.CreateControl();
      this.fDropDownForm.Controls.Add(control);
      control.Dock = DockStyle.Fill;
      this.OnBeforeDropDownShow(EventArgs.Empty);
      this.fDropDownControl.OnShowing();
      this.fDropDownForm.CanActivate = canActivate;
      this.fDropDownForm.Show();
      this.fDropDownControl.OnShow();
    }

    public void AdjustSizeAndLocation(Control grid, Rectangle ownerBounds)
    {
      if (this.fDropDownForm == null || this.fDropDownControl == null)
        return;
      Size borderSize = this.fDropDownForm.BorderSize;
      int width = this.fDropDownControl.Width;
      if (width < 0)
        width = ownerBounds.Width - 2 * borderSize.Width;
      Size size = new Size(width, this.fDropDownControl.Height);
      size.Width += 2 * borderSize.Width;
      size.Height += 2 * borderSize.Height + this.fDropDownForm.TitleBarHeight();
      Size minSize = this.fDropDownForm.MinSize;
      if (size.Width < minSize.Width)
        size.Width = minSize.Width;
      if (size.Height < minSize.Height)
        size.Height = minSize.Height;
      this.fDropDownForm.EnsureHandleCreated();
      this.fDropDownForm.Bounds = new Rectangle(this.GetLocation(ownerBounds, size, grid.RightToLeft == RightToLeft.Yes), size);
    }

    public void ActivateDropDownWindow()
    {
      if (this.fDropDownForm == null)
        return;
      this.fDropDownForm.Activate();
    }

    public void HideDropDown(bool cancel)
    {
      if (this.fDropDownForm == null)
        return;
      this.fCancelValueOnHide = cancel;
      this.fDropDownForm.MakeMainFormInactiveOnHide = false;
      this.fDropDownForm.Hide();
    }

    private Point GetLocation(Rectangle ownerBounds, Size size, bool rightToLeft)
    {
      Point point = new Point(ownerBounds.X + ownerBounds.Width - size.Width, ownerBounds.Y + ownerBounds.Height);
      if (point.X < ownerBounds.X)
        point.X = ownerBounds.X;
      if (rightToLeft)
        point.X = 2 * ownerBounds.X - point.X + ownerBounds.Width - size.Width;
      Rectangle workingArea = Screen.FromRectangle(ownerBounds).WorkingArea;
      if (point.X + size.Width > workingArea.X + workingArea.Width)
        point.X = workingArea.X + workingArea.Width - size.Width;
      else if (point.X < workingArea.X)
        point.X = workingArea.X;
      if (point.Y + size.Height > workingArea.Y + workingArea.Height)
        point.Y = ownerBounds.Y - size.Height;
      if (point.Y < workingArea.Y)
        point.Y = workingArea.Y;
      return point;
    }

    private static DisableNCActivateNativeWindow GetHook(IntPtr handle)
    {
      DisableNCActivateNativeWindow activateNativeWindow = (DisableNCActivateNativeWindow) null;
      iGDropDownManager.fHooks.TryGetValue(handle, out activateNativeWindow);
      return activateNativeWindow;
    }

    private static DisableNCActivateNativeWindow AddHook(Form form)
    {
      DisableNCActivateNativeWindow activateNativeWindow = iGDropDownManager.GetHook(form.Handle);
      if (activateNativeWindow == null)
      {
        activateNativeWindow = new DisableNCActivateNativeWindow(form);
        activateNativeWindow.HandleDestroyed += new HandleDestroyedEventHandler(iGDropDownManager.DisableNCActivateNativeWindow_HandleDestroyed);
        iGDropDownManager.fHooks.Add(form.Handle, activateNativeWindow);
      }
      return activateNativeWindow;
    }

    private static void RemoveHook(IntPtr handle)
    {
      iGDropDownManager.fHooks.Remove(handle);
    }

    private static void DisableNCActivateNativeWindow_HandleDestroyed(object sender, HandleDestroyedEventArgs e)
    {
      iGDropDownManager.RemoveHook(e.Handle);
    }

    private void OnAfterDropDownHide(AfterDropDownHideEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.AfterDropDownHide == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.AfterDropDownHide((object) this, e);
    }

    private void OnBeforeDropDownShow(EventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.BeforeDropDownShow == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.BeforeDropDownShow((object) this, e);
    }

    private void DropDownForm_VisibleChanged(object sender, EventArgs e)
    {
      if (this.fDropDownForm == null || this.fDropDownForm.Visible)
        return;
      if (this.fDropDownForm.TopLevelOwnerForm != null)
      {
        DisableNCActivateNativeWindow hook = iGDropDownManager.GetHook(this.fDropDownForm.TopLevelOwnerForm.Handle);
        if (hook != null)
          hook.HookActive = false;
      }
      this.OnAfterDropDownHide(new AfterDropDownHideEventArgs(this.fCancelValueOnHide));
      this.fDropDownForm.Controls.Clear();
      if (this.fDropDownControl == null)
        return;
      this.fDropDownControl.OnHide();
      this.fDropDownControl = (IiGDropDownControl) null;
    }

    public bool DoNotHideWhenDeactivate
    {
      get
      {
        if (this.fDropDownForm == null)
          throw new Exception();
        return this.fDropDownForm.DoNotHideWhenDeactivate;
      }
      set
      {
        if (this.fDropDownForm == null)
          throw new Exception();
        this.fDropDownForm.DoNotHideWhenDeactivate = value;
      }
    }

    public bool IsDropDownFormVisible
    {
      get
      {
        if (this.fDropDownForm == null)
          return false;
        return this.fDropDownForm.Visible;
      }
    }

    public event AfterDropDownHideEventHandler AfterDropDownHide;

    public event EventHandler BeforeDropDownShow;

    ~iGDropDownManager()
    {
      this.Dispose(false);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!disposing)
        return;
      this.fDropDownForm.Dispose();
    }

    public void Dispose()
    {
      this.Dispose(true);
    }
  }
}
