// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGToolTipWindowManager
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  internal class iGToolTipWindowManager : IDisposable
  {
    private iGToolTipWindowManager.iGToolTipWindow fToolTipWindow;
    private iGrid fGrid;

    public iGToolTipWindowManager(iGrid grid)
    {
      if (grid == null)
        throw new ArgumentNullException(nameof (grid));
      this.fGrid = grid;
    }

    private void AdjustToolTipWindow()
    {
      if (this.fToolTipWindow != null)
        return;
      this.fToolTipWindow = new iGToolTipWindowManager.iGToolTipWindow(this.fGrid);
    }

    public void ShowToolTipWindow(Point location, Size size, string text)
    {
      this.AdjustToolTipWindow();
      this.fToolTipWindow.ShowAsToolTip(location, size, text);
      this.fToolTipWindow.Invalidate();
    }

    public void UpdateToolTipWindow()
    {
      this.AdjustToolTipWindow();
      this.fToolTipWindow.Update();
    }

    public void HideToolTipWindow()
    {
      if (this.fToolTipWindow == null)
        return;
      this.fToolTipWindow.Hide();
    }

    public Graphics GetGraphics()
    {
      this.AdjustToolTipWindow();
      return this.fToolTipWindow.CreateGraphics();
    }

    public Font ToolTipWindowFont
    {
      get
      {
        this.AdjustToolTipWindow();
        return this.fToolTipWindow.Font;
      }
      set
      {
        this.AdjustToolTipWindow();
        this.fToolTipWindow.Font = value;
      }
    }

    public event iGToolTipWindowPaintEventHandler Paint
    {
      add
      {
        this.AdjustToolTipWindow();
        this.fToolTipWindow.Paint += value;
      }
      remove
      {
        this.AdjustToolTipWindow();
        this.fToolTipWindow.Paint -= value;
      }
    }

    ~iGToolTipWindowManager()
    {
      this.Dispose(false);
    }

    public void Dispose()
    {
      this.Dispose(true);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!disposing || this.fToolTipWindow == null)
        return;
      this.fToolTipWindow.Dispose();
      this.fToolTipWindow = (iGToolTipWindowManager.iGToolTipWindow) null;
    }

    private class iGToolTipWindow : Form
    {
      private iGrid fGrid;
      public iGToolTipWindowPaintEventHandler Paint;

      public iGToolTipWindow(iGrid grid)
      {
        this.fGrid = grid;
        this.BackColor = SystemColors.Info;
        this.StartPosition = FormStartPosition.Manual;
        this.FormBorderStyle = FormBorderStyle.None;
        this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      }

      protected override CreateParams CreateParams
      {
        get
        {
          CreateParams createParams = base.CreateParams;
          createParams.Style = 0;
          createParams.ExStyle = 134217736;
          createParams.ClassStyle = Environment.OSVersion.Version.CompareTo(new Version(5, 1)) < 0 ? 3 : 131075;
          createParams.Parent = IntPtr.Zero;
          return createParams;
        }
      }

      protected override void WndProc(ref Message m)
      {
        if (m.Msg == 132)
          m.Result = new IntPtr(-1);
        else
          base.WndProc(ref m);
      }

      public void ShowAsToolTip(Point location, Size size, string text)
      {
        Size size1;
        if (size.IsEmpty)
        {
          size1 = new Size(0, 0);
          if (text != null)
          {
            using (Graphics graphics = this.CreateGraphics())
            {
              graphics.TextRenderingHint = this.fGrid.TextRenderingHint;
              size1 = Size.Ceiling(graphics.MeasureString(text, this.Font));
              size1.Width += 2;
              size1.Height += 2;
              this.Size = size1;
            }
          }
        }
        else
          size1 = size;
        Point location1 = location;
        Rectangle bounds = Screen.FromPoint(location).Bounds;
        if (location1.X + size1.Width > bounds.X + bounds.Width)
          location1.X = bounds.X + bounds.Width - size1.Width;
        else if (location1.X < bounds.X)
          location1.X = bounds.X;
        if (location1.Y + size1.Height > bounds.Y + bounds.Height)
          location1.Y = bounds.Y + bounds.Height - size1.Height;
        if (location1.Y < bounds.Y)
          location1.Y = bounds.Y;
        this.Bounds = new Rectangle(location1, size1);
        this.Text = text;
        if (!this.IsHandleCreated)
          this.CreateControl();
        iGNativeMethods.SetWindowPos(this.Handle, (IntPtr) (-1), location1.X, location1.Y, size1.Width, size1.Height, 80U);
      }

      public void HideAsToolTip()
      {
        iGNativeMethods.ShowWindow(this.Handle, 0);
      }

      protected override void OnPaint(PaintEventArgs e)
      {
        e.Graphics.TextRenderingHint = this.fGrid.TextRenderingHint;
        if (!this.DoPaint(e.Graphics))
          return;
        if (this.Text.Length > 0)
        {
          Brush brush = (Brush) new SolidBrush(this.ForeColor);
          e.Graphics.DrawString(this.Text, this.Font, brush, new PointF(1f, 1f));
          brush.Dispose();
        }
        e.Graphics.DrawRectangle(SystemPens.ControlDarkDark, 0, 0, this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);
      }

      protected override void OnPaintBackground(PaintEventArgs e)
      {
      }

      private bool DoPaint(Graphics g)
      {
        iGToolTipWindowPaintEventArgs e = new iGToolTipWindowPaintEventArgs(g, this.ClientRectangle);
        this.OnPaint(e);
        return e.DoDefault;
      }

      protected void OnPaint(iGToolTipWindowPaintEventArgs e)
      {
        if (this.Paint == null)
          return;
        this.Paint((object) this, e);
      }
    }
  }
}
