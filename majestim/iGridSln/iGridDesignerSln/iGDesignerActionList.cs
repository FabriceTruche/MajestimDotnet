// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGDesignerActionList
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGDesignerActionList : DesignerActionList
  {
    private static string[] cLayoutProps = new string[4]
    {
      nameof (Anchor),
      "Dock",
      "Location",
      "Size"
    };
    private const string cDockInParentContainerCaption = "Dock in parent container";
    private const string cDockInParentContainerMethodName = "DockInParentContainer";
    private const string cUndockInParentContainerCaption = "Undock in parent container";
    private const string cUndockInParentContainerMethodName = "UndockInParentContainer";
    private const string cAnchorCaption = "Anchor";
    private const string cAnchorPropertyName = "Anchor";
    private const string cEditColsCaption = "Edit columns...";
    private const string cEditColsMethodName = "EditCols";
    private const string cEditRowsAndCellsCaption = "Edit rows && cells...";
    private const string cEditRowsAndCellsMethodName = "EditRowsAndCells";
    private const string cAutoFitCaption = "Auto fit...";
    private const string cAutoFitMethodName = "AutoFit";
    private const string cClearCaption = "Clear...";
    private const string cClearMethodName = "Clear";
    private const string cResetCaption = "Reset";
    private const string cResetDescription = "Reset all the properties";
    private const string cResetMethodName = "Reset";
    private const string cAboutCaption = "About";
    private const string cAboutMethodName = "About";
    private const string cCellImageListCaption = "Cell image list";
    private const string cCellImageListPropertyName = "CellImageList";
    private const string cHeaderImageListCaption = "Header image list";
    private const string cHeaderImageListPropertyName = "HeaderImageList";
    private const string cNameCaption = "Name";
    private const string cNamePropertyName = "Name";
    private const string cMessageReset = "Do you really want to reset the grid?\n\rAll the columns and rows will be deleted,\n\rand the grid's parameters except the layout properties\n\rwill be reseted to their default values.";
    private iGrid fGrid;
    private iGDesigner fDesigner;

    public iGDesignerActionList(iGrid grid, iGDesigner designer)
      : base((IComponent) grid)
    {
      if (grid == null)
        throw new ArgumentNullException(nameof (grid));
      if (designer == null)
        throw new ArgumentNullException(nameof (designer));
      this.fGrid = grid;
      this.fDesigner = designer;
    }

    public override DesignerActionItemCollection GetSortedActionItems()
    {
      DesignerActionItemCollection actionItemCollection = new DesignerActionItemCollection();
      actionItemCollection.Add((DesignerActionItem) new DesignerActionMethodItem((DesignerActionList) this, "EditCols", "Edit columns...", "Data", true));
      actionItemCollection.Add((DesignerActionItem) new DesignerActionMethodItem((DesignerActionList) this, "EditRowsAndCells", "Edit rows && cells...", "Data", true));
      actionItemCollection.Add((DesignerActionItem) new DesignerActionMethodItem((DesignerActionList) this, "AutoFit", "Auto fit...", "Data", true));
      actionItemCollection.Add((DesignerActionItem) new DesignerActionMethodItem((DesignerActionList) this, "Clear", "Clear...", "Data", true));
      actionItemCollection.Add((DesignerActionItem) new DesignerActionMethodItem((DesignerActionList) this, "Reset", "Reset", "Data", "Reset all the properties", true));
      actionItemCollection.Add((DesignerActionItem) new DesignerActionPropertyItem("Name", "Name", "Design"));
      actionItemCollection.Add((DesignerActionItem) new DesignerActionPropertyItem("HeaderImageList", "Header image list", "Appearance"));
      actionItemCollection.Add((DesignerActionItem) new DesignerActionPropertyItem("CellImageList", "Cell image list", "Appearance"));
      if (((Control) this.fGrid).Dock == DockStyle.None)
        actionItemCollection.Add((DesignerActionItem) new DesignerActionMethodItem((DesignerActionList) this, "DockInParentContainer", "Dock in parent container", "Layout", true));
      else
        actionItemCollection.Add((DesignerActionItem) new DesignerActionMethodItem((DesignerActionList) this, "UndockInParentContainer", "Undock in parent container", "Layout", true));
      actionItemCollection.Add((DesignerActionItem) new DesignerActionPropertyItem("Anchor", "Anchor", "Layout"));
      actionItemCollection.Add((DesignerActionItem) new DesignerActionMethodItem((DesignerActionList) this, "About", "About", "Misc", true));
      return actionItemCollection;
    }

    private bool OnComponentChanging()
    {
      IComponentChangeService service = ((IServiceProvider) this.fDesigner).GetService(typeof (IComponentChangeService)) as IComponentChangeService;
      try
      {
        if (service != null)
          service.OnComponentChanging((object) this.fGrid, (MemberDescriptor) null);
      }
      catch (CheckoutException ex)
      {
        if (ex == CheckoutException.Canceled)
          return false;
        throw ex;
      }
      return true;
    }

    private void OnComponentChanged()
    {
      IComponentChangeService service = ((IServiceProvider) this.fDesigner).GetService(typeof (IComponentChangeService)) as IComponentChangeService;
      if (service == null)
        return;
      service.OnComponentChanged((object) this.fGrid, (MemberDescriptor) null, (object) null, (object) null);
    }

    public void DockInParentContainer()
    {
      if (!this.OnComponentChanging())
        return;
      ((Control) this.fGrid).Dock = DockStyle.Fill;
      this.OnComponentChanged();
      this.UpdateSmartTagPanel();
    }

    public void UndockInParentContainer()
    {
      if (!this.OnComponentChanging())
        return;
      ((Control) this.fGrid).Dock = DockStyle.None;
      this.OnComponentChanged();
      this.UpdateSmartTagPanel();
    }

    private void UpdateSmartTagPanel()
    {
      DesignerActionUIService service = this.GetService(typeof (DesignerActionUIService)) as DesignerActionUIService;
      if (service == null)
        return;
      service.Refresh((IComponent) this.fGrid);
    }

    private void About()
    {
      this.fGrid.About();
    }

    private void AutoFit()
    {
      IWindowsFormsEditorService service1 = ((IServiceProvider) this.fDesigner).GetService(typeof (IWindowsFormsEditorService)) as IWindowsFormsEditorService;
      if (service1 == null)
        return;
      iGFormAutoFit iGformAutoFit = new iGFormAutoFit();
      if (service1.ShowDialog((Form) iGformAutoFit) == DialogResult.Cancel)
        return;
      this.fGrid.BeginUpdate();
      try
      {
        DesignerTransaction designerTransaction = (DesignerTransaction) null;
        IDesignerHost service2 = (IDesignerHost) this.GetService(typeof (IDesignerHost));
        if (service2 != null)
          designerTransaction = service2.CreateTransaction("AutoFit " + ((Control) this.fGrid).Name);
        if (!this.OnComponentChanging())
          return;
        if ((iGformAutoFit.SelectedAction & iGAutoFitAction.AutoWidthCols) != (iGAutoFitAction) 0)
          this.fGrid.Cols.AutoWidth();
        if ((iGformAutoFit.SelectedAction & iGAutoFitAction.AutoHeightRows) != (iGAutoFitAction) 0)
          this.fGrid.Rows.AutoHeight();
        if ((iGformAutoFit.SelectedAction & iGAutoFitAction.AutoHeightHeader) != (iGAutoFitAction) 0)
          this.fGrid.Header.AutoHeight();
        this.OnComponentChanged();
        if (designerTransaction == null)
          return;
        designerTransaction.Commit();
      }
      finally
      {
        this.fGrid.EndUpdate();
      }
    }

    private void Clear()
    {
      IWindowsFormsEditorService service1 = ((IServiceProvider) this.fDesigner).GetService(typeof (IWindowsFormsEditorService)) as IWindowsFormsEditorService;
      if (service1 == null)
        return;
      iGFormClear iGformClear = new iGFormClear();
      if (service1.ShowDialog((Form) iGformClear) != DialogResult.OK)
        return;
      this.fGrid.BeginUpdate();
      try
      {
        DesignerTransaction designerTransaction = (DesignerTransaction) null;
        IDesignerHost service2 = (IDesignerHost) this.GetService(typeof (IDesignerHost));
        if (service2 != null)
          designerTransaction = service2.CreateTransaction("Clear " + ((Control) this.fGrid).Name);
        if (!this.OnComponentChanging())
          return;
        this.fGrid.Rows.Clear();
        if (iGformClear.Action == iGClearAction.EntireGrid)
          this.fGrid.Cols.Clear();
        IReferenceService service3 = (IReferenceService) this.GetService(typeof (IReferenceService));
        iGInternalInfrastructure.ClearNonUsedDesignCellStyles(service3);
        iGInternalInfrastructure.ClearNonUsedDesignColHdrStyles(service3);
        this.OnComponentChanged();
        if (designerTransaction == null)
          return;
        designerTransaction.Commit();
      }
      finally
      {
        this.fGrid.EndUpdate();
      }
    }

    private void Reset()
    {
      if (MessageBox.Show("Do you really want to reset the grid?\n\rAll the columns and rows will be deleted,\n\rand the grid's parameters except the layout properties\n\rwill be reseted to their default values.", ((Control) this.fGrid).Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
        return;
      DesignerTransaction designerTransaction = (DesignerTransaction) null;
      IDesignerHost service1 = (IDesignerHost) this.GetService(typeof (IDesignerHost));
      if (service1 != null)
        designerTransaction = service1.CreateTransaction("Reset " + ((Control) this.fGrid).Name);
      if (!this.OnComponentChanging())
        return;
      foreach (PropertyInfo property in typeof (iGrid).GetProperties(BindingFlags.Instance | BindingFlags.Public))
      {
        if (Array.IndexOf<string>(iGDesignerActionList.cLayoutProps, property.Name) < 0)
          iGInternalInfrastructure.iGSerializeManager.ResetProperty((object) this.fGrid, property);
      }
      IReferenceService service2 = (IReferenceService) this.GetService(typeof (IReferenceService));
      iGInternalInfrastructure.ClearNonUsedDesignCellStyles(service2);
      iGInternalInfrastructure.ClearNonUsedDesignColHdrStyles(service2);
      this.OnComponentChanged();
      if (designerTransaction == null)
        return;
      designerTransaction.Commit();
    }

    private void EditCols()
    {
      UITypeEditor editor = (UITypeEditor) TypeDescriptor.GetEditor((object) this.fGrid.Cols, typeof (UITypeEditor));
      if (editor == null)
        return;
      IContainer container = ((Component) this.fGrid).Site.Container;
      iGDesignerActionList.iGTypeDescriptorContext descriptorContext = new iGDesignerActionList.iGTypeDescriptorContext(this.fDesigner, TypeDescriptor.GetProperties((object) this.fGrid)["Cols"]);
      editor.EditValue((ITypeDescriptorContext) descriptorContext, (IServiceProvider) this.fDesigner, (object) this.fGrid.Cols);
    }

    private void EditRowsAndCells()
    {
      UITypeEditor editor = (UITypeEditor) TypeDescriptor.GetEditor((object) this.fGrid.Rows, typeof (UITypeEditor));
      if (editor == null)
        return;
      IContainer container = ((Component) this.fGrid).Site.Container;
      iGDesignerActionList.iGTypeDescriptorContext descriptorContext = new iGDesignerActionList.iGTypeDescriptorContext(this.fDesigner, TypeDescriptor.GetProperties((object) this.fGrid)["Rows"]);
      editor.EditValue((ITypeDescriptorContext) descriptorContext, (IServiceProvider) this.fDesigner, (object) this.fGrid.Rows);
    }

    public AnchorStyles Anchor
    {
      get
      {
        return ((Control) this.fGrid).Anchor;
      }
      set
      {
        if (!this.OnComponentChanging())
          return;
        ((Control) this.fGrid).Anchor = value;
        this.OnComponentChanged();
      }
    }

    public ImageList CellImageList
    {
      get
      {
        return this.fGrid.ImageList;
      }
      set
      {
        if (!this.OnComponentChanging())
          return;
        this.fGrid.ImageList=(value);
        this.OnComponentChanged();
      }
    }

    public ImageList HeaderImageList
    {
      get
      {
        return this.fGrid.Header.ImageList;
      }
      set
      {
        if (!this.OnComponentChanging())
          return;
        this.fGrid.Header.ImageList=(value);
        this.OnComponentChanged();
      }
    }

    public string Name
    {
      get
      {
        return ((Component) this.fGrid).Site.Name;
      }
      set
      {
        if (!this.OnComponentChanging())
          return;
        ((Component) this.fGrid).Site.Name = value;
        this.OnComponentChanged();
      }
    }

    private class iGTypeDescriptorContext : ITypeDescriptorContext, IServiceProvider
    {
      private iGDesigner fDesigner;
      private PropertyDescriptor fDescriptor;

      public iGTypeDescriptorContext(iGDesigner designer, PropertyDescriptor descriptor)
      {
        if (designer == null)
          throw new ArgumentNullException(nameof (designer));
        if (descriptor == null)
          throw new ArgumentNullException(nameof (descriptor));
        this.fDesigner = designer;
        this.fDescriptor = descriptor;
      }

      private ISite GetSite()
      {
        if (this.fDesigner != null)
        {
          iGrid control = this.fDesigner.Control as iGrid;
          if (control != null)
            return ((Component) control).Site;
        }
        return (ISite) null;
      }

      public object GetService(Type type)
      {
        if (this.fDesigner != null)
          return ((IServiceProvider) this.fDesigner).GetService(type);
        return (object) null;
      }

      public bool OnComponentChanging()
      {
        try
        {
          if (this.fDesigner != null)
          {
            IComponentChangeService service = ((IServiceProvider) this.fDesigner).GetService(typeof (IComponentChangeService)) as IComponentChangeService;
            if (service != null)
            {
              try
              {
                service.OnComponentChanging((object) this.fDesigner.Component, (MemberDescriptor) null);
              }
              catch (CheckoutException ex)
              {
                if (ex == CheckoutException.Canceled)
                  return false;
                throw ex;
              }
            }
          }
        }
        catch
        {
          return false;
        }
        return true;
      }

      public void OnComponentChanged()
      {
        if (this.fDesigner == null)
          return;
        IComponentChangeService service = ((IServiceProvider) this.fDesigner).GetService(typeof (IComponentChangeService)) as IComponentChangeService;
        if (service == null)
          return;
        service.OnComponentChanged((object) this.fDesigner.Component, (MemberDescriptor) null, (object) null, (object) null);
      }

      public IContainer Container
      {
        get
        {
          ISite site = this.GetSite();
          if (site == null)
            return (IContainer) null;
          return site.Container;
        }
      }

      public object Instance
      {
        get
        {
          if (this.fDesigner != null)
            return (object) this.fDesigner.Component;
          return (object) null;
        }
      }

      public PropertyDescriptor PropertyDescriptor
      {
        get
        {
          return this.fDescriptor;
        }
      }
    }
  }
}
