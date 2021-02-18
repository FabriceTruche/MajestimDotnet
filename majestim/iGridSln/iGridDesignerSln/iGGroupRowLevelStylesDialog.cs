// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGGroupRowLevelStylesDialog
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGGroupRowLevelStylesDialog : Form
  {
    private ArrayList fStyles = new ArrayList();
    private Label fLabelStyles;
    private ListBox fListBoxStyles;
    private Label fLabelProps;
    private Button fButtonAddNew;
    private Button fButtonAddExisting;
    private Button fButtonRemove;
    private PropertyGrid fPropertyGrid;
    private Button fButtonCancel;
    private Panel fPanelBottom;
    private Splitter fSplitter;
    private Button fButtonDown;
    private Button fButtonUp;
    private Button fButtonOK;
    private IServiceProvider fProvider;
    private bool fIsSelectedChangedLocked;

    private void InitializeComponent()
    {
      this.fListBoxStyles = new ListBox();
      this.fPropertyGrid = new PropertyGrid();
      this.fLabelStyles = new Label();
      this.fLabelProps = new Label();
      this.fButtonAddNew = new Button();
      this.fButtonAddExisting = new Button();
      this.fButtonRemove = new Button();
      this.fButtonCancel = new Button();
      this.fButtonOK = new Button();
      this.fPanelBottom = new Panel();
      this.fSplitter = new Splitter();
      this.fButtonDown = new Button();
      this.fButtonUp = new Button();
      this.fPanelBottom.SuspendLayout();
      this.SuspendLayout();
      this.fListBoxStyles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.fListBoxStyles.IntegralHeight = false;
      this.fListBoxStyles.Location = new Point(8, 24);
      this.fListBoxStyles.Name = "fListBoxStyles";
      this.fListBoxStyles.Size = new Size(136, 199);
      this.fListBoxStyles.TabIndex = 0;
      this.fListBoxStyles.SelectionMode = SelectionMode.MultiExtended;
      this.fListBoxStyles.SelectedIndexChanged += new EventHandler(this.fListBoxStyles_SelectedIndexChanged);
      this.fPropertyGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.fPropertyGrid.CommandsVisibleIfAvailable = true;
      this.fPropertyGrid.Cursor = Cursors.HSplit;
      this.fPropertyGrid.LargeButtons = false;
      this.fPropertyGrid.LineColor = SystemColors.ScrollBar;
      this.fPropertyGrid.Location = new Point(184, 24);
      this.fPropertyGrid.Name = "fPropertyGrid";
      this.fPropertyGrid.Size = new Size(226, 295);
      this.fPropertyGrid.TabIndex = 1;
      this.fPropertyGrid.Text = "PropertyGrid";
      this.fPropertyGrid.ToolbarVisible = false;
      this.fPropertyGrid.ViewBackColor = SystemColors.Window;
      this.fPropertyGrid.ViewForeColor = SystemColors.WindowText;
      this.fLabelStyles.Location = new Point(8, 8);
      this.fLabelStyles.Name = "fLabelStyles";
      this.fLabelStyles.TabIndex = 2;
      this.fLabelStyles.Text = "Styles:";
      this.fLabelProps.Location = new Point(184, 8);
      this.fLabelProps.Name = "fLabelProps";
      this.fLabelProps.TabIndex = 3;
      this.fLabelProps.Text = "Style Properties:";
      this.fButtonAddNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.fButtonAddNew.FlatStyle = FlatStyle.System;
      this.fButtonAddNew.Location = new Point(8, 231);
      this.fButtonAddNew.Name = "fButtonAddNew";
      this.fButtonAddNew.Size = new Size(136, 23);
      this.fButtonAddNew.TabIndex = 4;
      this.fButtonAddNew.Text = "Add New";
      this.fButtonAddNew.Click += new EventHandler(this.fButtonAddNew_Click);
      this.fButtonAddExisting.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.fButtonAddExisting.FlatStyle = FlatStyle.System;
      this.fButtonAddExisting.Location = new Point(8, 263);
      this.fButtonAddExisting.Name = "fButtonAddExisting";
      this.fButtonAddExisting.Size = new Size(136, 23);
      this.fButtonAddExisting.TabIndex = 5;
      this.fButtonAddExisting.Text = "Add Existing...";
      this.fButtonAddExisting.Click += new EventHandler(this.fButtonAddExisting_Click);
      this.fButtonRemove.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.fButtonRemove.FlatStyle = FlatStyle.System;
      this.fButtonRemove.Location = new Point(8, 295);
      this.fButtonRemove.Name = "fButtonRemove";
      this.fButtonRemove.Size = new Size(136, 23);
      this.fButtonRemove.TabIndex = 6;
      this.fButtonRemove.Text = "Remove";
      this.fButtonRemove.Click += new EventHandler(this.fButtonRemove_Click);
      this.fButtonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.fButtonCancel.DialogResult = DialogResult.Cancel;
      this.fButtonCancel.FlatStyle = FlatStyle.System;
      this.fButtonCancel.Location = new Point(330, 336);
      this.fButtonCancel.Name = "fButtonCancel";
      this.fButtonCancel.Size = new Size(80, 23);
      this.fButtonCancel.TabIndex = 8;
      this.fButtonCancel.Text = "Cancel";
      this.fButtonOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.fButtonOK.DialogResult = DialogResult.OK;
      this.fButtonOK.FlatStyle = FlatStyle.System;
      this.fButtonOK.Location = new Point(242, 336);
      this.fButtonOK.Name = "fButtonOK";
      this.fButtonOK.Size = new Size(80, 23);
      this.fButtonOK.TabIndex = 9;
      this.fButtonOK.Text = "OK";
      this.fPanelBottom.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.fPanelBottom.Controls.Add((Control) this.fSplitter);
      this.fPanelBottom.Location = new Point(0, 327);
      this.fPanelBottom.Name = "fPanelBottom";
      this.fPanelBottom.Size = new Size(418, 1);
      this.fPanelBottom.TabIndex = 10;
      this.fSplitter.BackColor = SystemColors.ControlDark;
      this.fSplitter.Dock = DockStyle.Top;
      this.fSplitter.Enabled = false;
      this.fSplitter.Location = new Point(0, 0);
      this.fSplitter.Name = "fSplitter";
      this.fSplitter.Size = new Size(418, 1);
      this.fSplitter.TabIndex = 10;
      this.fSplitter.TabStop = false;
      this.fButtonDown.Anchor = AnchorStyles.Left;
      this.fButtonDown.Location = new Point(152, 131);
      this.fButtonDown.Name = "fButtonDown";
      this.fButtonDown.Size = new Size(24, 23);
      this.fButtonDown.TabIndex = 11;
      this.fButtonDown.Click += new EventHandler(this.fButtonDown_Click);
      this.fButtonUp.Anchor = AnchorStyles.Left;
      this.fButtonUp.Location = new Point(152, 100);
      this.fButtonUp.Name = "fButtonUp";
      this.fButtonUp.Size = new Size(24, 23);
      this.fButtonUp.TabIndex = 12;
      this.fButtonUp.Click += new EventHandler(this.fButtonUp_Click);
      this.AutoScaleBaseSize = new Size(5, 13);
      this.ClientSize = new Size(418, 367);
      this.Controls.Add((Control) this.fButtonOK);
      this.Controls.Add((Control) this.fButtonCancel);
      this.Controls.Add((Control) this.fButtonUp);
      this.Controls.Add((Control) this.fButtonDown);
      this.Controls.Add((Control) this.fButtonRemove);
      this.Controls.Add((Control) this.fButtonAddExisting);
      this.Controls.Add((Control) this.fButtonAddNew);
      this.Controls.Add((Control) this.fPropertyGrid);
      this.Controls.Add((Control) this.fListBoxStyles);
      this.Controls.Add((Control) this.fLabelStyles);
      this.Controls.Add((Control) this.fLabelProps);
      this.Controls.Add((Control) this.fPanelBottom);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (iGGroupRowLevelStylesDialog);
      this.ShowInTaskbar = false;
      this.SizeGripStyle = SizeGripStyle.Show;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Group Row Level Styles";
      this.Load += new EventHandler(this.iGGroupRowLevelStylesDialog_Load);
      this.fPanelBottom.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public iGGroupRowLevelStylesDialog()
    {
      this.InitializeComponent();
      this.fPropertyGrid.CommandsVisibleIfAvailable = false;
    }

    private void iGGroupRowLevelStylesDialog_Load(object sender, EventArgs e)
    {
      this.fButtonUp.Image = (Image) new Bitmap(ResourceLoader.GetResourceStream("DesignerArrowUp.gif"));
      this.fButtonDown.Image = (Image) new Bitmap(ResourceLoader.GetResourceStream("DesignerArrowDown.gif"));
    }

    public void Initialize(IServiceProvider provider, iGCellStyle[] styles)
    {
      this.fProvider = provider;
      this.Styles = styles;
    }

    private void ListBoxAdjust()
    {
      this.fListBoxStyles.BeginUpdate();
      this.LockSelectedChanged();
      try
      {
        this.fListBoxStyles.Items.Clear();
        for (int index = 0; index < this.fStyles.Count; ++index)
        {
          TypeConverter converter = TypeDescriptor.GetConverter(this.fStyles[index]);
          string str1 = "Level " + index.ToString();
          object fStyle = this.fStyles[index];
          string str2 = converter.ConvertToString(fStyle);
          if (str2 != null && str2.Length > 0)
            str1 = str1 + ": " + str2;
          this.fListBoxStyles.Items.Add((object) str1);
        }
        if (this.fListBoxStyles.Items.Count <= 0)
          return;
        this.fListBoxStyles.SelectedIndex = 0;
      }
      finally
      {
        this.UnlockSelectedChanged();
        this.fListBoxStyles.EndUpdate();
        this.OnSelectedItemChanged();
      }
    }

    private void SelectLastItem()
    {
      if (this.fListBoxStyles.Items.Count <= 0)
        return;
      this.SetSelectedIndex(this.fListBoxStyles.Items.Count - 1);
    }

    private void SetSelectedIndex(int index)
    {
      this.LockSelectedChanged();
      try
      {
        this.fListBoxStyles.SelectedIndices.Clear();
        this.fListBoxStyles.SelectedIndices.Add(index);
      }
      finally
      {
        this.UnlockSelectedChanged();
        this.OnSelectedItemChanged();
      }
    }

    private void LockSelectedChanged()
    {
      this.fIsSelectedChangedLocked = true;
    }

    private void UnlockSelectedChanged()
    {
      this.fIsSelectedChangedLocked = false;
    }

    private void OnSelectedItemChanged()
    {
      if (this.fIsSelectedChangedLocked)
        return;
      if (this.fListBoxStyles.SelectedIndices.Count > 0)
      {
        iGCellStyle[] iGcellStyleArray = new iGCellStyle[this.fListBoxStyles.SelectedIndices.Count];
        for (int index = 0; index < this.fListBoxStyles.SelectedIndices.Count; ++index)
          iGcellStyleArray[index] = (iGCellStyle) this.fStyles[this.fListBoxStyles.SelectedIndices[index]];
        this.fPropertyGrid.SelectedObjects = (object[]) iGcellStyleArray;
        if (!this.fButtonRemove.Enabled)
          this.fButtonRemove.Enabled = true;
        if (!this.fButtonUp.Enabled)
          this.fButtonUp.Enabled = true;
        if (this.fButtonDown.Enabled)
          return;
        this.fButtonDown.Enabled = true;
      }
      else
      {
        this.fPropertyGrid.SelectedObject = (object) null;
        if (this.fButtonRemove.Enabled)
          this.fButtonRemove.Enabled = false;
        if (this.fButtonUp.Enabled)
          this.fButtonUp.Enabled = false;
        if (!this.fButtonDown.Enabled)
          return;
        this.fButtonDown.Enabled = false;
      }
    }

    private void fListBoxStyles_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.OnSelectedItemChanged();
    }

    private void fButtonAddExisting_Click(object sender, EventArgs e)
    {
      iGFormSelectStyle gformSelectStyle = new iGFormSelectStyle();
      gformSelectStyle.Initialize(this.fProvider);
      IWindowsFormsEditorService formsEditorService = (IWindowsFormsEditorService) null;
      if (this.fProvider != null)
        formsEditorService = (IWindowsFormsEditorService) this.fProvider.GetService(typeof (IWindowsFormsEditorService));
      if ((formsEditorService == null ? gformSelectStyle.ShowDialog() : formsEditorService.ShowDialog((Form) gformSelectStyle)) != DialogResult.OK)
        return;
      foreach (object selectedStyle in gformSelectStyle.SelectedStyles)
        this.fStyles.Add(selectedStyle);
      this.ListBoxAdjust();
      this.SelectLastItem();
    }

    private void fButtonAddNew_Click(object sender, EventArgs e)
    {
      iGCellStyle iGcellStyle = (iGCellStyle) null;
      if (this.fProvider != null)
      {
        IDesignerHost service = (IDesignerHost) this.fProvider.GetService(typeof (IDesignerHost));
        if (service != null)
          iGcellStyle = (iGCellStyle) iGDesigner.CreateStyleDesignTime(service, (string) null, typeof (iGCellStyleDesign), (iGStyleBase) null);
      }
      if (iGcellStyle == null)
        iGcellStyle = (iGCellStyle) new iGCellStyleDesign();
      this.fStyles.Add((object) iGcellStyle);
      this.ListBoxAdjust();
      this.SelectLastItem();
    }

    private void fButtonRemove_Click(object sender, EventArgs e)
    {
      if (this.fListBoxStyles.SelectedIndices.Count <= 0)
        return;
      this.fListBoxStyles.BeginUpdate();
      try
      {
        for (int index = this.fListBoxStyles.SelectedIndices.Count - 1; index >= 0; --index)
        {
          int selectedIndex = this.fListBoxStyles.SelectedIndices[index];
          this.fStyles.RemoveAt(selectedIndex);
          this.fListBoxStyles.Items.RemoveAt(selectedIndex);
          if (index == 0)
          {
            if (selectedIndex < this.fListBoxStyles.Items.Count)
              this.SetSelectedIndex(selectedIndex);
            else if (selectedIndex > 0)
              this.SetSelectedIndex(selectedIndex - 1);
          }
        }
      }
      finally
      {
        this.fListBoxStyles.EndUpdate();
      }
    }

    private void fButtonUp_Click(object sender, EventArgs e)
    {
      if (this.fListBoxStyles.SelectedIndex < 1)
        return;
      int selectedIndex = this.fListBoxStyles.SelectedIndex;
      iGCellStyle fStyle = this.fStyles[selectedIndex] as iGCellStyle;
      this.fStyles.RemoveAt(selectedIndex);
      this.fStyles.Insert(selectedIndex - 1, (object) fStyle);
      this.ListBoxAdjust();
      this.SetSelectedIndex(selectedIndex - 1);
    }

    private void fButtonDown_Click(object sender, EventArgs e)
    {
      if (this.fListBoxStyles.SelectedIndex < 0 || this.fListBoxStyles.SelectedIndex >= this.fListBoxStyles.Items.Count - 1)
        return;
      int selectedIndex = this.fListBoxStyles.SelectedIndex;
      iGCellStyle fStyle = this.fStyles[selectedIndex] as iGCellStyle;
      this.fStyles.RemoveAt(selectedIndex);
      this.fStyles.Insert(selectedIndex + 1, (object) fStyle);
      this.ListBoxAdjust();
      this.SetSelectedIndex(selectedIndex + 1);
    }

    public iGCellStyle[] Styles
    {
      get
      {
        return (iGCellStyle[]) this.fStyles.ToArray(typeof (iGCellStyle));
      }
      set
      {
        this.fStyles.Clear();
        if (value != null)
        {
          foreach (iGCellStyle iGcellStyle in value)
          {
            if (this.fProvider == null || this.fProvider.GetService(typeof (IDesignerHost)) == null || ((Component) iGcellStyle).Container != null)
              this.fStyles.Add((object) iGcellStyle);
          }
        }
        this.ListBoxAdjust();
      }
    }
  }
}
