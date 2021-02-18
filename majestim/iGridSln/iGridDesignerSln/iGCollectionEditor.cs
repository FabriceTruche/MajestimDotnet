// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGCollectionEditor
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGCollectionEditor : CollectionEditor
  {
    private const string cRegistryKeyFormPosition = "10Tec iGrid.NET Collection Editor Desktop Bounds";

    public iGCollectionEditor(Type type)
      : base(type)
    {
    }

    public static PropertyGrid GetPropertyGrid(Control container)
    {
      for (int index = container.Controls.Count - 1; index >= 0; --index)
      {
        Control control = container.Controls[index];
        PropertyGrid propertyGrid = control as PropertyGrid ?? iGCollectionEditor.GetPropertyGrid(control);
        if (propertyGrid != null)
          return propertyGrid;
      }
      return (PropertyGrid) null;
    }

    protected override CollectionEditor.CollectionForm CreateCollectionForm()
    {
      CollectionEditor.CollectionForm collectionForm = base.CreateCollectionForm();
      if (this.SupportsApply)
      {
        try
        {
          Button okButton = this.FindOkButton((Control) collectionForm);
          if (okButton != null)
          {
            TableLayoutPanel parent = okButton.Parent as TableLayoutPanel;
            if (parent != null)
            {
              Button button1 = new Button();
              button1.Text = "Apply";
              button1.Click += new EventHandler(this.ApplyButton_Click);
              button1.Anchor = okButton.Anchor;
              Button button2 = button1;
              Padding margin = okButton.Margin;
              int left = margin.Right * 2;
              margin = okButton.Margin;
              int top = margin.Top;
              int right = 0;
              margin = okButton.Margin;
              int bottom = margin.Bottom;
              Padding padding = new Padding(left, top, right, bottom);
              button2.Margin = padding;
              button1.Size = okButton.Size;
              parent.ColumnCount = 3;
              parent.Controls.Add((Control) button1, 2, 0);
            }
          }
        }
        catch
        {
        }
      }
      PropertyGrid propertyGrid = iGCollectionEditor.GetPropertyGrid((Control) collectionForm);
      if (propertyGrid != null)
      {
        propertyGrid.CommandsVisibleIfAvailable = true;
        propertyGrid.HelpVisible = true;
        propertyGrid.PropertySort = PropertySort.CategorizedAlphabetical;
      }
      collectionForm.FormClosing += new FormClosingEventHandler(this.MyForm_FormClosing);
      collectionForm.Load += new EventHandler(this.MyForm_Load);
      return collectionForm;
    }

    private void MyForm_Load(object sender, EventArgs e)
    {
      try
      {
        object obj = Application.UserAppDataRegistry.GetValue("10Tec iGrid.NET Collection Editor Desktop Bounds");
        if (obj == null)
          return;
        Rectangle formRect = (Rectangle) new RectangleConverter().ConvertFromString(obj.ToString());
        if (!this.IsRectOnScreen(formRect))
          return;
        CollectionEditor.CollectionForm collectionForm = (CollectionEditor.CollectionForm) sender;
        int num = 0;
        collectionForm.StartPosition = (FormStartPosition) num;
        Rectangle rectangle = formRect;
        collectionForm.DesktopBounds = rectangle;
      }
      catch (Exception ex)
      {
      }
    }

    private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      try
      {
        Application.UserAppDataRegistry.SetValue("10Tec iGrid.NET Collection Editor Desktop Bounds", (object) new RectangleConverter().ConvertToString((object) ((Form) sender).DesktopBounds));
      }
      catch (Exception ex)
      {
      }
    }

    private bool IsRectOnScreen(Rectangle formRect)
    {
      foreach (Screen allScreen in Screen.AllScreens)
      {
        if (allScreen.WorkingArea.IntersectsWith(formRect))
          return true;
      }
      return false;
    }

    protected Button FindOkButton(Control container)
    {
      if (container == null)
        throw new ArgumentNullException(nameof (container));
      foreach (Control control in (ArrangedElementCollection) container.Controls)
      {
        Button button = control as Button;
        if (button != null && button.DialogResult == DialogResult.OK)
          return button;
        Button okButton = this.FindOkButton(control);
        if (okButton != null)
          return okButton;
      }
      return (Button) null;
    }

    protected virtual void ApplyButton_Click(object sender, EventArgs e)
    {
    }

    protected virtual bool SupportsApply
    {
      get
      {
        return false;
      }
    }
  }
}
