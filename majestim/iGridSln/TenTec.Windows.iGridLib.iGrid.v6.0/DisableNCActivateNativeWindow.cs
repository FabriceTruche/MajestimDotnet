// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.DisableNCActivateNativeWindow
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  internal class DisableNCActivateNativeWindow : NativeWindow
  {
    public bool HookActive;

    public DisableNCActivateNativeWindow(Form form)
    {
      form.HandleDestroyed += new EventHandler(this.control_HandleDestroyed);
      this.AssignHandle(form.Handle);
    }

    private void control_HandleDestroyed(object sender, EventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.HandleDestroyed != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.HandleDestroyed((object) this, new HandleDestroyedEventArgs(this.Handle));
      }
      this.ReleaseHandle();
    }

    protected override void WndProc(ref Message m)
    {
      if (this.HookActive && m.Msg == 134 && m.WParam == IntPtr.Zero)
        m.WParam = new IntPtr(1);
      base.WndProc(ref m);
    }

    public event HandleDestroyedEventHandler HandleDestroyed;
  }
}
