// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGFormClear
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System.Drawing;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGFormClear : Form
  {
    private Button buttonOK;
    private RadioButton fRadioButtonEntireGrid;
    private RadioButton fRadioButtonRowOnly;
    private GroupBox fGroupBoxOptions;
    private Button buttonCancel;

    private void InitializeComponent()
    {
      this.buttonOK = new Button();
      this.buttonCancel = new Button();
      this.fRadioButtonEntireGrid = new RadioButton();
      this.fRadioButtonRowOnly = new RadioButton();
      this.fGroupBoxOptions = new GroupBox();
      this.fGroupBoxOptions.SuspendLayout();
      this.SuspendLayout();
      this.buttonOK.DialogResult = DialogResult.OK;
      this.buttonOK.Location = new Point(8, 90);
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.Size = new Size(74, 23);
      this.buttonOK.TabIndex = 1;
      this.buttonOK.Text = "OK";
      this.buttonCancel.DialogResult = DialogResult.Cancel;
      this.buttonCancel.Location = new Point(90, 90);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new Size(74, 23);
      this.buttonCancel.TabIndex = 2;
      this.buttonCancel.Text = "Cancel";
      this.fRadioButtonEntireGrid.Checked = true;
      this.fRadioButtonEntireGrid.Location = new Point(10, 18);
      this.fRadioButtonEntireGrid.Name = "fRadioButtonEntireGrid";
      this.fRadioButtonEntireGrid.Size = new Size(142, 20);
      this.fRadioButtonEntireGrid.TabIndex = 0;
      this.fRadioButtonEntireGrid.TabStop = true;
      this.fRadioButtonEntireGrid.Text = "Entire Grid";
      this.fRadioButtonRowOnly.Location = new Point(10, 44);
      this.fRadioButtonRowOnly.Name = "fRadioButtonRowOnly";
      this.fRadioButtonRowOnly.Size = new Size(142, 20);
      this.fRadioButtonRowOnly.TabIndex = 1;
      this.fRadioButtonRowOnly.Text = "Rows Only";
      this.fGroupBoxOptions.Controls.Add((Control) this.fRadioButtonEntireGrid);
      this.fGroupBoxOptions.Controls.Add((Control) this.fRadioButtonRowOnly);
      this.fGroupBoxOptions.Location = new Point(8, 8);
      this.fGroupBoxOptions.Name = "fGroupBoxOptions";
      this.fGroupBoxOptions.Size = new Size(156, 74);
      this.fGroupBoxOptions.TabIndex = 0;
      this.fGroupBoxOptions.TabStop = false;
      this.fGroupBoxOptions.Text = "Options";
      this.AcceptButton = (IButtonControl) this.buttonOK;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.CancelButton = (IButtonControl) this.buttonCancel;
      this.ClientSize = new Size(172, 121);
      this.Controls.Add((Control) this.fGroupBoxOptions);
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.buttonOK);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (iGFormClear);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Clear";
      this.fGroupBoxOptions.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public iGFormClear()
    {
      this.InitializeComponent();
      this.Icon = new Icon(ResourceLoader.GetResourceStream("iGridFormIcon.ico"));
    }

    public iGClearAction Action
    {
      get
      {
        return this.fRadioButtonEntireGrid.Checked ? iGClearAction.EntireGrid : iGClearAction.RowsOnly;
      }
    }
  }
}
