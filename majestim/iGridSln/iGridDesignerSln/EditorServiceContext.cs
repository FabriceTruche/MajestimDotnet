// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.EditorServiceContext
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace TenTec.Windows.iGridLib.Design
{
  internal class EditorServiceContext : IWindowsFormsEditorService, ITypeDescriptorContext, IServiceProvider
  {
    private ComponentDesigner _designer;
    private IComponentChangeService _componentChangeSvc;
    private PropertyDescriptor _targetProperty;

    private IComponentChangeService ChangeService
    {
      get
      {
        if (this._componentChangeSvc == null)
          this._componentChangeSvc = (IComponentChangeService) ((IServiceProvider) this).GetService(typeof (IComponentChangeService));
        return this._componentChangeSvc;
      }
    }

    IContainer ITypeDescriptorContext.Container
    {
      get
      {
        if (this._designer.Component.Site != null)
          return this._designer.Component.Site.Container;
        return (IContainer) null;
      }
    }

    object ITypeDescriptorContext.Instance
    {
      get
      {
        return (object) this._designer.Component;
      }
    }

    PropertyDescriptor ITypeDescriptorContext.PropertyDescriptor
    {
      get
      {
        return this._targetProperty;
      }
    }

    internal EditorServiceContext(ComponentDesigner designer)
    {
      this._designer = designer;
    }

    internal EditorServiceContext(ComponentDesigner designer, PropertyDescriptor prop)
    {
      this._designer = designer;
      this._targetProperty = prop;
      if (prop != null)
        return;
      prop = TypeDescriptor.GetDefaultProperty((object) designer.Component);
      if (prop == null || !typeof (ICollection).IsAssignableFrom(prop.PropertyType))
        return;
      this._targetProperty = prop;
    }

    internal EditorServiceContext(ComponentDesigner designer, PropertyDescriptor prop, string newVerbText)
      : this(designer, prop)
    {
      this._designer.Verbs.Add(new DesignerVerb(newVerbText, new EventHandler(this.OnEditItems)));
    }

    public static object EditValue(ComponentDesigner designer, object objectToChange, string propName)
    {
      PropertyDescriptor property = TypeDescriptor.GetProperties(objectToChange)[propName];
      EditorServiceContext editorServiceContext1 = new EditorServiceContext(designer, property);
      UITypeEditor editor = property.GetEditor(typeof (UITypeEditor)) as UITypeEditor;
      object obj1 = property.GetValue(objectToChange);
      EditorServiceContext editorServiceContext2 = editorServiceContext1;
      EditorServiceContext editorServiceContext3 = editorServiceContext1;
      object obj2 = obj1;
      object obj3 = editor.EditValue((ITypeDescriptorContext) editorServiceContext2, (IServiceProvider) editorServiceContext3, obj2);
      if (obj3 != obj1)
      {
        try
        {
          property.SetValue(objectToChange, obj3);
        }
        catch (CheckoutException ex)
        {
        }
      }
      return obj3;
    }

    void ITypeDescriptorContext.OnComponentChanged()
    {
      this.ChangeService.OnComponentChanged((object) this._designer.Component, (MemberDescriptor) this._targetProperty, (object) null, (object) null);
    }

    bool ITypeDescriptorContext.OnComponentChanging()
    {
      try
      {
        this.ChangeService.OnComponentChanging((object) this._designer.Component, (MemberDescriptor) this._targetProperty);
      }
      catch (CheckoutException ex)
      {
        CheckoutException canceled = CheckoutException.Canceled;
        if (ex == canceled)
          return false;
        throw;
      }
      return true;
    }

    object IServiceProvider.GetService(Type serviceType)
    {
      if (serviceType == typeof (ITypeDescriptorContext) || serviceType == typeof (IWindowsFormsEditorService))
        return (object) this;
      if (this._designer.Component != null && this._designer.Component.Site != null)
        return this._designer.Component.Site.GetService(serviceType);
      return (object) null;
    }

    void IWindowsFormsEditorService.CloseDropDown()
    {
    }

    void IWindowsFormsEditorService.DropDownControl(Control control)
    {
    }

    DialogResult IWindowsFormsEditorService.ShowDialog(Form dialog)
    {
      IUIService service = (IUIService) ((IServiceProvider) this).GetService(typeof (IUIService));
      if (service != null)
        return service.ShowDialog(dialog);
      return dialog.ShowDialog(this._designer.Component as IWin32Window);
    }

    private void OnEditItems(object sender, EventArgs e)
    {
      object component = this._targetProperty.GetValue((object) this._designer.Component);
      if (component == null)
        return;
      CollectionEditor editor = TypeDescriptor.GetEditor(component, typeof (UITypeEditor)) as CollectionEditor;
      if (editor == null)
        return;
      editor.EditValue((ITypeDescriptorContext) this, (IServiceProvider) this, component);
    }
  }
}
