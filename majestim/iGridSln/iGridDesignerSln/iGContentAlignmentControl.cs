// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGContentAlignmentControl
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.Layout;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGContentAlignmentControl : UserControl
  {
    private CheckBox checkBoxTopCenter;
    private CheckBox checkBoxTopRight;
    private CheckBox checkBoxTopLeft;
    private CheckBox checkBoxMiddleLeft;
    private CheckBox checkBoxMiddleCenter;
    private CheckBox checkBoxMiddleRight;
    private CheckBox checkBoxBottomRight;
    private CheckBox checkBoxBottomCenter;
    private CheckBox checkBoxBottomLeft;
    private CheckBox checkBoxNotSet;
    private IWindowsFormsEditorService fService;
    private iGContentAlignment fOldAlignment;

    public iGContentAlignmentControl()
    {
      this.InitializeComponent();
    }

    private void InitializeComponent()
    {
      this.checkBoxTopCenter = new CheckBox();
      this.checkBoxTopRight = new CheckBox();
      this.checkBoxTopLeft = new CheckBox();
      this.checkBoxMiddleLeft = new CheckBox();
      this.checkBoxMiddleCenter = new CheckBox();
      this.checkBoxMiddleRight = new CheckBox();
      this.checkBoxBottomRight = new CheckBox();
      this.checkBoxBottomCenter = new CheckBox();
      this.checkBoxBottomLeft = new CheckBox();
      this.checkBoxNotSet = new CheckBox();
      this.SuspendLayout();
      this.checkBoxTopCenter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.checkBoxTopCenter.Appearance = Appearance.Button;
      this.checkBoxTopCenter.AutoCheck = false;
      this.checkBoxTopCenter.Location = new Point(32, 0);
      this.checkBoxTopCenter.Name = "checkBoxTopCenter";
      this.checkBoxTopCenter.Size = new Size(59, 25);
      this.checkBoxTopCenter.TabIndex = 1;
      this.checkBoxTopCenter.Click += new EventHandler(this.checkBox_Click);
      this.checkBoxTopRight.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.checkBoxTopRight.Appearance = Appearance.Button;
      this.checkBoxTopRight.AutoCheck = false;
      this.checkBoxTopRight.Location = new Point(98, 0);
      this.checkBoxTopRight.Name = "checkBoxTopRight";
      this.checkBoxTopRight.Size = new Size(24, 25);
      this.checkBoxTopRight.TabIndex = 2;
      this.checkBoxTopRight.Click += new EventHandler(this.checkBox_Click);
      this.checkBoxTopLeft.Appearance = Appearance.Button;
      this.checkBoxTopLeft.AutoCheck = false;
      this.checkBoxTopLeft.Location = new Point(0, 0);
      this.checkBoxTopLeft.Name = "checkBoxTopLeft";
      this.checkBoxTopLeft.Size = new Size(24, 25);
      this.checkBoxTopLeft.TabIndex = 0;
      this.checkBoxTopLeft.TextAlign = ContentAlignment.MiddleCenter;
      this.checkBoxTopLeft.Click += new EventHandler(this.checkBox_Click);
      this.checkBoxMiddleLeft.Appearance = Appearance.Button;
      this.checkBoxMiddleLeft.AutoCheck = false;
      this.checkBoxMiddleLeft.Location = new Point(0, 32);
      this.checkBoxMiddleLeft.Name = "checkBoxMiddleLeft";
      this.checkBoxMiddleLeft.Size = new Size(24, 25);
      this.checkBoxMiddleLeft.TabIndex = 3;
      this.checkBoxMiddleLeft.Click += new EventHandler(this.checkBox_Click);
      this.checkBoxMiddleCenter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.checkBoxMiddleCenter.Appearance = Appearance.Button;
      this.checkBoxMiddleCenter.AutoCheck = false;
      this.checkBoxMiddleCenter.Location = new Point(32, 32);
      this.checkBoxMiddleCenter.Name = "checkBoxMiddleCenter";
      this.checkBoxMiddleCenter.Size = new Size(59, 25);
      this.checkBoxMiddleCenter.TabIndex = 4;
      this.checkBoxMiddleCenter.Click += new EventHandler(this.checkBox_Click);
      this.checkBoxMiddleRight.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.checkBoxMiddleRight.Appearance = Appearance.Button;
      this.checkBoxMiddleRight.AutoCheck = false;
      this.checkBoxMiddleRight.Location = new Point(98, 32);
      this.checkBoxMiddleRight.Name = "checkBoxMiddleRight";
      this.checkBoxMiddleRight.Size = new Size(24, 25);
      this.checkBoxMiddleRight.TabIndex = 5;
      this.checkBoxMiddleRight.Click += new EventHandler(this.checkBox_Click);
      this.checkBoxBottomRight.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.checkBoxBottomRight.Appearance = Appearance.Button;
      this.checkBoxBottomRight.AutoCheck = false;
      this.checkBoxBottomRight.Location = new Point(98, 64);
      this.checkBoxBottomRight.Name = "checkBoxBottomRight";
      this.checkBoxBottomRight.Size = new Size(24, 25);
      this.checkBoxBottomRight.TabIndex = 8;
      this.checkBoxBottomRight.Click += new EventHandler(this.checkBox_Click);
      this.checkBoxBottomCenter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.checkBoxBottomCenter.Appearance = Appearance.Button;
      this.checkBoxBottomCenter.AutoCheck = false;
      this.checkBoxBottomCenter.Location = new Point(32, 64);
      this.checkBoxBottomCenter.Name = "checkBoxBottomCenter";
      this.checkBoxBottomCenter.Size = new Size(59, 25);
      this.checkBoxBottomCenter.TabIndex = 7;
      this.checkBoxBottomCenter.Click += new EventHandler(this.checkBox_Click);
      this.checkBoxBottomLeft.Appearance = Appearance.Button;
      this.checkBoxBottomLeft.AutoCheck = false;
      this.checkBoxBottomLeft.Location = new Point(0, 64);
      this.checkBoxBottomLeft.Name = "checkBoxBottomLeft";
      this.checkBoxBottomLeft.Size = new Size(24, 25);
      this.checkBoxBottomLeft.TabIndex = 6;
      this.checkBoxBottomLeft.Click += new EventHandler(this.checkBox_Click);
      this.checkBoxNotSet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.checkBoxNotSet.Appearance = Appearance.Button;
      this.checkBoxNotSet.AutoCheck = false;
      this.checkBoxNotSet.Location = new Point(0, 96);
      this.checkBoxNotSet.Name = "checkBoxNotSet";
      this.checkBoxNotSet.Size = new Size(122, 25);
      this.checkBoxNotSet.TabIndex = 9;
      this.checkBoxNotSet.Text = "NotSet";
      this.checkBoxNotSet.TextAlign = ContentAlignment.MiddleCenter;
      this.checkBoxNotSet.Click += new EventHandler(this.checkBox_Click);
      this.BackColor = SystemColors.Control;
      this.Controls.Add((Control) this.checkBoxTopCenter);
      this.Controls.Add((Control) this.checkBoxTopRight);
      this.Controls.Add((Control) this.checkBoxTopLeft);
      this.Controls.Add((Control) this.checkBoxMiddleLeft);
      this.Controls.Add((Control) this.checkBoxMiddleCenter);
      this.Controls.Add((Control) this.checkBoxMiddleRight);
      this.Controls.Add((Control) this.checkBoxBottomRight);
      this.Controls.Add((Control) this.checkBoxBottomCenter);
      this.Controls.Add((Control) this.checkBoxBottomLeft);
      this.Controls.Add((Control) this.checkBoxNotSet);
      this.Name = nameof (iGContentAlignmentControl);
      this.Size = new Size(122, 121);
      this.ResumeLayout(false);
    }

    public void Start(IWindowsFormsEditorService service, object value)
    {
      this.fService = service;
      this.Value = (iGContentAlignment) value;
      this.fOldAlignment = this.Value;
    }

    public void End()
    {
      this.fService = (IWindowsFormsEditorService) null;
    }

    public void AdjustSize()
    {
      this.Size = new Size(122, 121);
    }

    protected override bool ShowFocusCues
    {
      get
      {
        return false;
      }
    }

    private void SetAllNotChecked()
    {
      this.checkBoxTopCenter.Checked = false;
      this.checkBoxTopRight.Checked = false;
      this.checkBoxTopLeft.Checked = false;
      this.checkBoxMiddleLeft.Checked = false;
      this.checkBoxMiddleCenter.Checked = false;
      this.checkBoxMiddleRight.Checked = false;
      this.checkBoxBottomRight.Checked = false;
      this.checkBoxBottomCenter.Checked = false;
      this.checkBoxBottomLeft.Checked = false;
      this.checkBoxNotSet.Checked = false;
    }

    private void checkBox_Click(object sender, EventArgs e)
    {
      this.SetAllNotChecked();
      (sender as CheckBox).Checked = true;
      this.fService.CloseDropDown();
    }

    public iGContentAlignment Value
    {
      get
      {
        if (this.checkBoxTopLeft.Checked)
          return (iGContentAlignment) 1;
        if (this.checkBoxTopCenter.Checked)
          return (iGContentAlignment) 2;
        if (this.checkBoxTopRight.Checked)
          return (iGContentAlignment) 4;
        if (this.checkBoxMiddleLeft.Checked)
          return (iGContentAlignment) 16;
        if (this.checkBoxMiddleCenter.Checked)
          return (iGContentAlignment) 32;
        if (this.checkBoxMiddleRight.Checked)
          return (iGContentAlignment) 64;
        if (this.checkBoxBottomLeft.Checked)
          return (iGContentAlignment) 256;
        if (this.checkBoxBottomCenter.Checked)
          return (iGContentAlignment) 512;
        if (this.checkBoxBottomRight.Checked)
          return (iGContentAlignment) 1024;
        return (iGContentAlignment) 0;
      }
      set
      {
        this.SetAllNotChecked();
        if ((int)value <= 32)
        {
          switch ((int)value - 1)
          {
            case 0:
              this.checkBoxTopLeft.Checked = true;
              return;
            case 1:
              this.checkBoxTopCenter.Checked = true;
              return;
            case 2:
              break;
            case 3:
              this.checkBoxTopRight.Checked = true;
              return;
            default:
              if ((int)value != 16)
              {
                if ((int)value == 32)
                {
                  this.checkBoxMiddleCenter.Checked = true;
                  return;
                }
                break;
              }
              this.checkBoxMiddleLeft.Checked = true;
              return;
          }
        }
        else if ((int)value <= 256)
        {
          if ((int)value != 64)
          {
            if ((int)value == 256)
            {
              this.checkBoxBottomLeft.Checked = true;
              return;
            }
          }
          else
          {
            this.checkBoxMiddleRight.Checked = true;
            return;
          }
        }
        else if ((int)value != 512)
        {
          if ((int)value == 1024)
          {
            this.checkBoxBottomRight.Checked = true;
            return;
          }
        }
        else
        {
          this.checkBoxBottomCenter.Checked = true;
          return;
        }
        this.checkBoxNotSet.Checked = true;
      }
    }

    protected override bool IsInputKey(Keys keyData)
    {
      if (keyData == Keys.Left || keyData == Keys.Right || (keyData == Keys.Up || keyData == Keys.Down) || (keyData == Keys.Tab || keyData == Keys.Escape))
        return true;
      return base.IsInputKey(keyData);
    }

    private CheckBox GetCheckedControl()
    {
      foreach (CheckBox control in (ArrangedElementCollection) this.Controls)
      {
        if (control.Checked)
          return control;
      }
      return this.checkBoxTopLeft;
    }

    private CheckBox GetControlsWithTabIndex(int tabIndex)
    {
      foreach (CheckBox control in (ArrangedElementCollection) this.Controls)
      {
        if (control.TabIndex == tabIndex)
          return control;
      }
      return this.checkBoxTopLeft;
    }

    protected override bool ProcessDialogKey(Keys keyData)
    {
      int tabIndex = this.GetCheckedControl().TabIndex;
      switch (keyData)
      {
        case Keys.Tab:
        case Keys.Right:
          this.SetAllNotChecked();
          CheckBox controlsWithTabIndex1 = this.GetControlsWithTabIndex(tabIndex != 9 ? tabIndex + 1 : 0);
          int num1 = 1;
          controlsWithTabIndex1.Checked = num1 != 0;
          controlsWithTabIndex1.Focus();
          return true;
        case Keys.Escape:
          this.Value = this.fOldAlignment;
          break;
        case Keys.Left:
          this.SetAllNotChecked();
          CheckBox controlsWithTabIndex2 = this.GetControlsWithTabIndex(tabIndex != 0 ? tabIndex - 1 : 9);
          int num2 = 1;
          controlsWithTabIndex2.Checked = num2 != 0;
          controlsWithTabIndex2.Focus();
          return true;
        case Keys.Up:
          this.SetAllNotChecked();
          CheckBox controlsWithTabIndex3 = this.GetControlsWithTabIndex(tabIndex >= 3 ? (tabIndex != 9 ? tabIndex - 3 : 8) : 9);
          int num3 = 1;
          controlsWithTabIndex3.Checked = num3 != 0;
          controlsWithTabIndex3.Focus();
          return true;
        case Keys.Down:
          this.SetAllNotChecked();
          CheckBox controlsWithTabIndex4 = this.GetControlsWithTabIndex(tabIndex != 9 ? (tabIndex <= 6 ? tabIndex + 3 : 9) : 0);
          int num4 = 1;
          controlsWithTabIndex4.Checked = num4 != 0;
          controlsWithTabIndex4.Focus();
          return true;
      }
      return base.ProcessDialogKey(keyData);
    }
  }
}
