// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGControlOpacity
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGControlOpacity : UserControl
  {
    private Label fLabel;
    private TrackBar fTrackBar;
    private const char cPercentage = '%';
    private IWindowsFormsEditorService fService;
    private PropertyDescriptor fProp;
    private object fComponent;
    private double fOldValue;
    private double fValue;

    private void InitializeComponent()
    {
      this.fTrackBar = new TrackBar();
      this.fLabel = new Label();
      this.fTrackBar.BeginInit();
      this.SuspendLayout();
      this.fTrackBar.Dock = DockStyle.Fill;
      this.fTrackBar.LargeChange = 10;
      this.fTrackBar.Location = new Point(0, 16);
      this.fTrackBar.Maximum = 20;
      this.fTrackBar.Name = "fTrackBar";
      this.fTrackBar.Size = new Size(104, 40);
      this.fTrackBar.TabIndex = 0;
      this.fTrackBar.TickFrequency = 2;
      this.fTrackBar.TickStyle = TickStyle.TopLeft;
      this.fTrackBar.ValueChanged += new EventHandler(this.fTrackBar_ValueChanged);
      this.fLabel.Dock = DockStyle.Top;
      this.fLabel.Location = new Point(0, 0);
      this.fLabel.Name = "fLabel";
      this.fLabel.Size = new Size(104, 16);
      this.fLabel.TabIndex = 1;
      this.fLabel.Text = "label1";
      this.fLabel.TextAlign = ContentAlignment.MiddleCenter;
      this.BackColor = SystemColors.Control;
      this.Controls.Add((Control) this.fTrackBar);
      this.Controls.Add((Control) this.fLabel);
      this.Name = "ControlOpacity";
      this.Size = new Size(104, 56);
      this.FontChanged += new EventHandler(this.ControlOpacity_FontChanged);
      this.fTrackBar.EndInit();
      this.ResumeLayout(false);
    }

    public iGControlOpacity()
    {
      this.InitializeComponent();
    }

    public void Start(object component, PropertyDescriptor prop, double value, IWindowsFormsEditorService service)
    {
      this.fComponent = component;
      this.fProp = prop;
      this.fValue = this.fOldValue = value;
      this.fService = service;
      this.fTrackBar.Value = (int) (value * 20.0);
      this.fLabel.Text = (value * 100.0).ToString() + "%";
    }

    public void End()
    {
      this.fComponent = (object) null;
      this.fProp = (PropertyDescriptor) null;
      this.fOldValue = 0.0;
      this.fValue = 0.0;
      this.fService = (IWindowsFormsEditorService) null;
    }

    protected override bool IsInputKey(Keys keyData)
    {
      if (keyData == Keys.Escape)
        return true;
      return base.IsInputKey(keyData);
    }

    protected override bool ProcessDialogKey(Keys keyData)
    {
      if (keyData == Keys.Escape)
      {
        this.fProp.SetValue(this.fComponent, (object) this.fOldValue);
        this.fValue = this.fOldValue;
      }
      return base.ProcessDialogKey(keyData);
    }

    protected override void OnGotFocus(EventArgs e)
    {
      this.fTrackBar.Focus();
      base.OnGotFocus(e);
    }

    public double Value
    {
      get
      {
        return this.fValue;
      }
    }

    private void ControlOpacity_FontChanged(object sender, EventArgs e)
    {
      using (Graphics graphics = this.fLabel.CreateGraphics())
      {
        int num = (int) ((double) this.fLabel.Font.GetHeight(graphics) + 0.99);
        this.Height = num + this.fTrackBar.Height;
        this.fLabel.Height = num;
      }
    }

    private double GetTrackBarValue(TrackBar trackBar)
    {
      return (double) trackBar.Value / 20.0;
    }

    private void fTrackBar_ValueChanged(object sender, EventArgs e)
    {
      this.fValue = this.GetTrackBarValue(sender as TrackBar);
      this.fProp.SetValue(this.fComponent, (object) this.fValue);
      this.fLabel.Text = (this.fValue * 100.0).ToString() + "%";
    }
  }
}
