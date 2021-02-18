// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGDesigner
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.Design.Behavior;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGDesigner : ControlDesigner, IServiceProvider
  {
    private static bool fComponentChangeEventsHandled;
    private DesignerActionListCollection fActionList;
    private Adorner fAdorner;

    internal static iGStyleBase CreateStyleDesignTime(IDesignerHost host, string name, Type type, iGStyleBase baseStyle)
    {
      if (host == null)
        return (iGStyleBase) null;
      INameCreationService service = (INameCreationService) host.GetService(typeof (INameCreationService));
      if (name == null)
        name = service.CreateName(host.Container, type);
      if (!service.IsValidName(name))
      {
        int num;
        for (num = 1; !service.IsValidName(name + num.ToString()); ++num)
        {
          if (num >= 100)
            return (iGStyleBase) null;
        }
        name += num.ToString();
      }
      iGStyleBase component = host.CreateComponent(type, name) as iGStyleBase;
      if (baseStyle != null && component != null)
        component.CloneProperties(baseStyle);
      return component;
    }

    public override void Initialize(IComponent component)
    {
      base.Initialize(component);
      iGrid grid = component as iGrid;
      if (grid == null)
        return;
      // ISSUE: method pointer
        grid.ColWidthStartChange += this.Grid_ColWidthStartChange;

            //grid.add_ColWidthStartChange(new iGColWidthEventHandler((object) this, __methodptr(Grid_ColWidthStartChange)));


            // ISSUE: method pointer
        //grid.add_ColWidthEndChange(new iGColWidthEventHandler((object)this, __methodptr(Grid_ColWidthEndChange)));
        grid.ColWidthEndChange += this.Grid_ColWidthEndChange;

      // ISSUE: method pointer
        //grid.add_RowHeightStartChange(new iGRowHeightEventHandler((object) this, __methodptr(Grid_RowHeightStartChange)));
        grid.RowHeightStartChange += this.Grid_RowHeightStartChange;


        // ISSUE: method pointer
            //grid.add_RowHeightEndChange(new iGRowHeightEventHandler((object) this, __methodptr(Grid_RowHeightEndChange)));
        grid.RowHeightEndChange += this.Grid_RowHeightEndChange;

      if (!iGDesigner.fComponentChangeEventsHandled && ((Component)grid).Site != null)
      {
        IComponentChangeService service = (IComponentChangeService) ((Component) grid).Site.GetService(typeof (IComponentChangeService));
        if (service != null)
        {
          service.ComponentRemoved += new ComponentEventHandler(iGDesigner.IComponentChangeService_ComponentRemoved);
          service.ComponentRename += new ComponentRenameEventHandler(iGDesigner.IComponentChangeService_ComponentRename);
          iGDesigner.fComponentChangeEventsHandled = true;
        }
      }
      this.fAdorner = new Adorner();
      this.BehaviorService.Adorners.Add(this.fAdorner);
      this.fAdorner.Glyphs.Add((Glyph) new iGGlyphHeaders(this.BehaviorService, grid));
      this.fAdorner.Glyphs.Add((Glyph) new iGGlyphScrollBar(this.BehaviorService, grid, true));
      this.fAdorner.Glyphs.Add((Glyph) new iGGlyphScrollBar(this.BehaviorService, grid, false));
      ISelectionService service1 = (ISelectionService) this.GetService(typeof (ISelectionService));
      if (service1 == null)
        return;
      service1.SelectionChanged += new EventHandler(this.ISelectionService_SelectionChanged);
    }

    protected override void Dispose(bool disposing)
    {
      iGrid control = this.Control as iGrid;
      if (control != null)
      {
        // ISSUE: method pointer
        //control.remove_ColWidthStartChange(new iGColWidthEventHandler((object) this, __methodptr(Grid_ColWidthStartChange)));
          control.ColWidthStartChange -= this.Grid_ColWidthStartChange;

                // ISSUE: method pointer
          //control.remove_ColWidthEndChange(new iGColWidthEventHandler((object)this, __methodptr(Grid_ColWidthEndChange)));
          control.ColWidthEndChange -= this.Grid_ColWidthEndChange;

        // ISSUE: method pointer
        //        control.remove_RowHeightStartChange(new iGRowHeightEventHandler((object) this, __methodptr(Grid_RowHeightStartChange)));
          control.RowHeightStartChange -= this.Grid_RowHeightStartChange;

        // ISSUE: method pointer
          //control.remove_RowHeightEndChange(new iGRowHeightEventHandler((object) this, __methodptr(Grid_RowHeightEndChange)));
                control.RowHeightEndChange -= this.Grid_RowHeightEndChange;
            }
            if (this.BehaviorService != null && this.BehaviorService.Adorners != null)
        this.BehaviorService.Adorners.Remove(this.fAdorner);
      base.Dispose(disposing);
    }

    public override void InitializeNewComponent(IDictionary defaultValues)
    {
      iGrid component = this.Component as iGrid;
      if (component != null && ((Component) component).Site != null)
      {
        IDesignerHost service = (IDesignerHost) ((Component) component).Site.GetService(typeof (IDesignerHost));
        if (service != null)
        {
          component.DefaultCol.CellStyle=((iGCellStyle) iGDesigner.CreateStyleDesignTime(service, ((Control) component).Name + "DefaultCellStyle", typeof (iGCellStyle), (iGStyleBase) component.DefaultCol.CellStyle));
          component.DefaultCol.ColHdrStyle=((iGColHdrStyle) iGDesigner.CreateStyleDesignTime(service, ((Control) component).Name + "DefaultColHdrStyle", typeof (iGColHdrStyle), (iGStyleBase) component.DefaultCol.ColHdrStyle));
          component.RowTextCol.CellStyle=((iGCellStyle) iGDesigner.CreateStyleDesignTime(service, ((Control) component).Name + "RowTextColCellStyle", typeof (iGCellStyle), (iGStyleBase) component.RowTextCol.CellStyle));
        }
      }
      base.InitializeNewComponent(defaultValues);
    }

    private PropertyDescriptor DescriptorGetCols()
    {
      return TypeDescriptor.GetProperties(typeof (iGrid)).Find("Cols", false);
    }

    private void Grid_ColWidthStartChange(object sender, iGColWidthEventArgs e)
    {
      PropertyDescriptor cols = this.DescriptorGetCols();
      if (cols == null)
        return;
      this.RaiseComponentChanging((MemberDescriptor) cols);
    }

    private void Grid_ColWidthEndChange(object sender, iGColWidthEventArgs e)
    {
      PropertyDescriptor cols = this.DescriptorGetCols();
      if (cols == null)
        return;
      this.RaiseComponentChanged((MemberDescriptor) cols, (object) null, (object) null);
    }

    private PropertyDescriptor DescriptorGetRows()
    {
      return TypeDescriptor.GetProperties(typeof (iGrid)).Find("Rows", false);
    }

    private void Grid_RowHeightStartChange(object sender, iGRowHeightEventArgs e)
    {
      PropertyDescriptor rows = this.DescriptorGetRows();
      if (rows == null)
        return;
      this.RaiseComponentChanging((MemberDescriptor) rows);
    }

    private void Grid_RowHeightEndChange(object sender, iGRowHeightEventArgs e)
    {
      PropertyDescriptor rows = this.DescriptorGetRows();
      if (rows == null)
        return;
      this.RaiseComponentChanged((MemberDescriptor) rows, (object) null, (object) null);
    }

    private void ISelectionService_SelectionChanged(object sender, EventArgs e)
    {
      BehaviorService behaviorService = this.BehaviorService;
      if (behaviorService == null)
        return;
      int index = behaviorService.Adorners.IndexOf(this.fAdorner);
      if (index <= 0)
        return;
      ISelectionService service = (ISelectionService) this.GetService(typeof (ISelectionService));
      if (service == null)
        return;
      behaviorService.Adorners[index].Enabled = service.PrimarySelection == this.Component;
    }

    private static void IComponentChangeService_ComponentRemoved(object sender, ComponentEventArgs e)
    {
      iGrid component = e.Component as iGrid;
      if (component == null || ((Component) component).Site == null)
        return;
      IReferenceService service = (IReferenceService) ((Component) component).Site.GetService(typeof (IReferenceService));
      iGInternalInfrastructure.ClearNonUsedDesignCellStyles(service);
      iGInternalInfrastructure.ClearNonUsedDesignColHdrStyles(service);
    }

    private static void IComponentChangeService_ComponentRename(object sender, ComponentRenameEventArgs e)
    {
      iGrid component = e.Component as iGrid;
      if (component == null)
        return;
      ((Control) component).Invalidate();
    }

    object IServiceProvider.GetService(Type serviceType)
    {
      return this.GetService(serviceType);
    }

    protected override object GetService(Type serviceType)
    {
      if (serviceType == typeof (IWindowsFormsEditorService))
        return (object) new iGDesigner.iGWindowsFormsEditorService(this);
      return base.GetService(serviceType);
    }

    protected override void PostFilterProperties(IDictionary properties)
    {
      base.PostFilterProperties(properties);
      properties.Add((object) "LayoutFlags", (object) new iGDesigner.iGLayoutPropertyDescriptor(this));
    }

    public override DesignerActionListCollection ActionLists
    {
      get
      {
        if (this.fActionList == null)
        {
          this.fActionList = base.ActionLists;
          if (this.fActionList == null)
            this.fActionList = new DesignerActionListCollection();
          iGrid component = this.Component as iGrid;
          if (component != null)
            this.fActionList.Add((DesignerActionList) new iGDesignerActionList(component, this));
        }
        return this.fActionList;
      }
    }

    private class iGWindowsFormsEditorService : IWindowsFormsEditorService
    {
      private iGDesigner fDesigner;

      public iGWindowsFormsEditorService(iGDesigner designer)
      {
        this.fDesigner = designer;
      }

      public void CloseDropDown()
      {
        throw new NotSupportedException();
      }

      public void DropDownControl(Control control)
      {
        throw new NotSupportedException();
      }

      public DialogResult ShowDialog(Form dialog)
      {
        if (this.fDesigner != null)
        {
          IUIService service = (IUIService) this.fDesigner.GetService(typeof (IUIService));
          if (service != null)
            return service.ShowDialog(dialog);
        }
        return dialog.ShowDialog();
      }
    }

    private class iGLayoutPropertyDescriptor : PropertyDescriptor
    {
      private PropertyDescriptor fLayoutFlagsDescriptor;
      private iGDesigner fDesigner;

      public iGLayoutPropertyDescriptor(iGDesigner designer)
        : base("Flags", (Attribute[]) null)
      {
        this.fDesigner = designer;
        this.fLayoutFlagsDescriptor = TypeDescriptor.GetProperties(typeof (iGLayout))["Flags"];
      }

      public override bool CanResetValue(object component)
      {
        iGrid iGrid = component as iGrid;
        if (iGrid != null)
          return this.fLayoutFlagsDescriptor.CanResetValue((object) iGrid.LayoutObject);
        return false;
      }

      public override void ResetValue(object component)
      {
        iGrid iGrid = component as iGrid;
        if (iGrid == null)
          return;
        this.RaiseChanging();
        this.fLayoutFlagsDescriptor.ResetValue((object) iGrid.LayoutObject);
        this.RaiseChanged();
      }

      public override bool ShouldSerializeValue(object component)
      {
        iGrid iGrid = component as iGrid;
        if (iGrid != null)
          return this.fLayoutFlagsDescriptor.ShouldSerializeValue((object) iGrid.LayoutObject);
        return false;
      }

      public override object GetValue(object component)
      {
        iGrid iGrid = component as iGrid;
        if (iGrid != null)
          return this.fLayoutFlagsDescriptor.GetValue((object) iGrid.LayoutObject);
        return (object) null;
      }

      public override void SetValue(object component, object value)
      {
        iGrid iGrid = component as iGrid;
        if (iGrid == null)
          return;
        this.RaiseChanging();
        this.fLayoutFlagsDescriptor.SetValue((object) iGrid.LayoutObject, value);
        this.RaiseChanged();
      }

      private void RaiseChanged()
      {
        this.fDesigner.RaiseComponentChanged(this.GetLayoutProperty(), (object) null, (object) null);
      }

      private void RaiseChanging()
      {
        try
        {
          this.fDesigner.RaiseComponentChanging(this.GetLayoutProperty());
        }
        catch (CheckoutException ex)
        {
          if (ex != CheckoutException.Canceled)
            throw ex;
        }
      }

      private MemberDescriptor GetLayoutProperty()
      {
        return (MemberDescriptor) TypeDescriptor.GetProperties(typeof (iGrid))["LayoutObject"];
      }

      public override AttributeCollection Attributes
      {
        get
        {
          AttributeCollection attributes = this.fLayoutFlagsDescriptor.Attributes;
          Attribute[] attributeArray1 = new Attribute[attributes.Count + 1];
          Attribute[] attributeArray2 = attributeArray1;
          int index = 1;
          attributes.CopyTo((Array) attributeArray2, index);
          attributeArray1[0] = (Attribute) DesignerSerializationVisibilityAttribute.Hidden;
          return new AttributeCollection(attributeArray1);
        }
      }

      public override Type ComponentType
      {
        get
        {
          return typeof (iGLayout);
        }
      }

      public override bool IsReadOnly
      {
        get
        {
          return false;
        }
      }

      public override Type PropertyType
      {
        get
        {
          return this.fLayoutFlagsDescriptor.PropertyType;
        }
      }

      public override string DisplayName
      {
        get
        {
          return "LayoutFlags";
        }
      }
    }
  }
}
