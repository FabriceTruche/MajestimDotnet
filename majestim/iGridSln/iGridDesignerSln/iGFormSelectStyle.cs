// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGFormSelectStyle
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGFormSelectStyle : Form
  {
    private ArrayList fStyles = new ArrayList();
    private ListBox fListBox;
    private Button fButtonOK;
    private Button fButtonCancel;

    private void InitializeComponent()
    {
      this.fListBox = new ListBox();
      this.fButtonOK = new Button();
      this.fButtonCancel = new Button();
      this.SuspendLayout();
      this.fListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.fListBox.IntegralHeight = false;
      this.fListBox.Location = new Point(8, 8);
      this.fListBox.Name = "fListBox";
      this.fListBox.SelectionMode = SelectionMode.MultiSimple;
      this.fListBox.Size = new Size(178, 136);
      this.fListBox.TabIndex = 0;
      this.fButtonOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.fButtonOK.DialogResult = DialogResult.OK;
      this.fButtonOK.FlatStyle = FlatStyle.System;
      this.fButtonOK.Location = new Point(19, 152);
      this.fButtonOK.Name = "fButtonOK";
      this.fButtonOK.Size = new Size(75, 23);
      this.fButtonOK.TabIndex = 1;
      this.fButtonOK.Text = "OK";
      this.fButtonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.fButtonCancel.DialogResult = DialogResult.Cancel;
      this.fButtonCancel.FlatStyle = FlatStyle.System;
      this.fButtonCancel.Location = new Point(99, 152);
      this.fButtonCancel.Name = "fButtonCancel";
      this.fButtonCancel.Size = new Size(75, 23);
      this.fButtonCancel.TabIndex = 2;
      this.fButtonCancel.Text = "Cancel";
      this.AcceptButton = (IButtonControl) this.fButtonOK;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.CancelButton = (IButtonControl) this.fButtonCancel;
      this.ClientSize = new Size(194, 183);
      this.Controls.Add((Control) this.fButtonCancel);
      this.Controls.Add((Control) this.fButtonOK);
      this.Controls.Add((Control) this.fListBox);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (iGFormSelectStyle);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Select Styles From List";
      this.ResumeLayout(false);
    }

    public iGFormSelectStyle()
    {
      this.InitializeComponent();
    }

    public void Initialize(IServiceProvider provider)
    {
      if (provider == null)
        return;
      IReferenceService service = (IReferenceService) provider.GetService(typeof (IReferenceService));
      if (service == null)
        return;
      foreach (iGCellStyle reference in service.GetReferences(typeof (iGCellStyle)))
      {
        this.fStyles.Add((object) reference);
        this.fListBox.Items.Add((object) TypeDescriptor.GetConverter((object) reference).ConvertToString((object) reference));
      }
    }

    public iGCellStyle[] SelectedStyles
    {
      get
      {
        iGCellStyle[] iGcellStyleArray = new iGCellStyle[this.fListBox.SelectedItems.Count];
        for (int index = 0; index < this.fListBox.SelectedIndices.Count; ++index)
          iGcellStyleArray[index] = this.fStyles[this.fListBox.SelectedIndices[index]] as iGCellStyle;
        return iGcellStyleArray;
      }
    }
  }
}
