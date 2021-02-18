// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGFormAutoFit
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System.Drawing;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGFormAutoFit : Form
  {
    private GroupBox fGroupBoxOptions;
    private Button fButtonOK;
    private Button fButtonCancel;
    private RadioButton fRadioButtonColsWidth;
    private RadioButton fRadioButtonRowsHeight;
    private RadioButton fRadioButtonHeaderHeight;
    private RadioButton fRadioButtonAll;

    private void InitializeComponent()
    {
      this.fGroupBoxOptions = new GroupBox();
      this.fRadioButtonColsWidth = new RadioButton();
      this.fRadioButtonRowsHeight = new RadioButton();
      this.fRadioButtonHeaderHeight = new RadioButton();
      this.fRadioButtonAll = new RadioButton();
      this.fButtonOK = new Button();
      this.fButtonCancel = new Button();
      this.fGroupBoxOptions.SuspendLayout();
      this.SuspendLayout();
      this.fGroupBoxOptions.Controls.Add((Control) this.fRadioButtonColsWidth);
      this.fGroupBoxOptions.Controls.Add((Control) this.fRadioButtonRowsHeight);
      this.fGroupBoxOptions.Controls.Add((Control) this.fRadioButtonHeaderHeight);
      this.fGroupBoxOptions.Controls.Add((Control) this.fRadioButtonAll);
      this.fGroupBoxOptions.Location = new Point(8, 8);
      this.fGroupBoxOptions.Name = "fGroupBoxOptions";
      this.fGroupBoxOptions.Size = new Size(156, 126);
      this.fGroupBoxOptions.TabIndex = 0;
      this.fGroupBoxOptions.TabStop = false;
      this.fGroupBoxOptions.Text = "Options";
      this.fRadioButtonColsWidth.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.fRadioButtonColsWidth.Checked = true;
      this.fRadioButtonColsWidth.FlatStyle = FlatStyle.System;
      this.fRadioButtonColsWidth.Location = new Point(10, 18);
      this.fRadioButtonColsWidth.Name = "fRadioButtonColsWidth";
      this.fRadioButtonColsWidth.Size = new Size(136, 20);
      this.fRadioButtonColsWidth.TabIndex = 0;
      this.fRadioButtonColsWidth.TabStop = true;
      this.fRadioButtonColsWidth.Text = "Width of the Columns";
      this.fRadioButtonRowsHeight.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.fRadioButtonRowsHeight.FlatStyle = FlatStyle.System;
      this.fRadioButtonRowsHeight.Location = new Point(10, 44);
      this.fRadioButtonRowsHeight.Name = "fRadioButtonRowsHeight";
      this.fRadioButtonRowsHeight.Size = new Size(136, 20);
      this.fRadioButtonRowsHeight.TabIndex = 1;
      this.fRadioButtonRowsHeight.Text = "Height of the Rows";
      this.fRadioButtonHeaderHeight.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.fRadioButtonHeaderHeight.FlatStyle = FlatStyle.System;
      this.fRadioButtonHeaderHeight.Location = new Point(10, 70);
      this.fRadioButtonHeaderHeight.Name = "fRadioButtonHeaderHeight";
      this.fRadioButtonHeaderHeight.Size = new Size(136, 20);
      this.fRadioButtonHeaderHeight.TabIndex = 2;
      this.fRadioButtonHeaderHeight.Text = "Header Height";
      this.fRadioButtonAll.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.fRadioButtonAll.FlatStyle = FlatStyle.System;
      this.fRadioButtonAll.Location = new Point(10, 96);
      this.fRadioButtonAll.Name = "fRadioButtonAll";
      this.fRadioButtonAll.Size = new Size(136, 20);
      this.fRadioButtonAll.TabIndex = 3;
      this.fRadioButtonAll.Text = "All the Above";
      this.fButtonOK.DialogResult = DialogResult.OK;
      this.fButtonOK.FlatStyle = FlatStyle.System;
      this.fButtonOK.Location = new Point(8, 142);
      this.fButtonOK.Name = "fButtonOK";
      this.fButtonOK.Size = new Size(73, 23);
      this.fButtonOK.TabIndex = 1;
      this.fButtonOK.Text = "OK";
      this.fButtonCancel.DialogResult = DialogResult.Cancel;
      this.fButtonCancel.FlatStyle = FlatStyle.System;
      this.fButtonCancel.Location = new Point(90, 142);
      this.fButtonCancel.Name = "fButtonCancel";
      this.fButtonCancel.Size = new Size(73, 23);
      this.fButtonCancel.TabIndex = 2;
      this.fButtonCancel.Text = "Cancel";
      this.AcceptButton = (IButtonControl) this.fButtonOK;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.CancelButton = (IButtonControl) this.fButtonCancel;
      this.ClientSize = new Size(172, 175);
      this.Controls.Add((Control) this.fButtonOK);
      this.Controls.Add((Control) this.fGroupBoxOptions);
      this.Controls.Add((Control) this.fButtonCancel);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (iGFormAutoFit);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Auto Fit";
      this.fGroupBoxOptions.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public iGFormAutoFit()
    {
      this.InitializeComponent();
      this.Icon = new Icon(ResourceLoader.GetResourceStream("iGridFormIcon.ico"));
    }

    public iGAutoFitAction SelectedAction
    {
      get
      {
        if (this.fRadioButtonColsWidth.Checked)
          return iGAutoFitAction.AutoWidthCols;
        if (this.fRadioButtonRowsHeight.Checked)
          return iGAutoFitAction.AutoHeightRows;
        return this.fRadioButtonHeaderHeight.Checked ? iGAutoFitAction.AutoHeightHeader : iGAutoFitAction.All;
      }
    }
  }
}
