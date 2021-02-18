// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGExpandableTypeConverter
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGExpandableTypeConverter : iGTypeConverter
  {
    public override bool GetPropertiesSupported(ITypeDescriptorContext context)
    {
      return true;
    }

    public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
    {
      if (context == null)
        return base.GetProperties(context, value, attributes);
      iGExpandableTypeConverter.iGExpandablePropertyDescriptor propertyDescriptor = context.PropertyDescriptor as iGExpandableTypeConverter.iGExpandablePropertyDescriptor;
      object rootComponent;
      PropertyDescriptor rootPropDescriptor;
      if (propertyDescriptor == null)
      {
        rootComponent = context.Instance;
        rootPropDescriptor = context.PropertyDescriptor;
      }
      else
      {
        rootComponent = propertyDescriptor.RootComponent;
        rootPropDescriptor = propertyDescriptor.RootPropDescriptor;
      }
      Type type = value.GetType();
      PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
      PropertyDescriptorCollection descriptorCollection = new PropertyDescriptorCollection((PropertyDescriptor[]) null);
      foreach (PropertyInfo prop in properties)
      {
        if (this.IsBrowsable(prop) && this.FilterProperties(prop.Name))
        {
          object[] customAttributes = prop.GetCustomAttributes(true);
          Attribute[] attributes1 = (Attribute[]) null;
          if (customAttributes != null)
          {
            attributes1 = new Attribute[customAttributes.Length];
            customAttributes.CopyTo((Array) attributes1, 0);
          }
          descriptorCollection.Add((PropertyDescriptor) new iGExpandableTypeConverter.iGExpandablePropertyDescriptor(type, prop.Name, prop.PropertyType, attributes1, rootComponent, rootPropDescriptor));
        }
      }
      return descriptorCollection;
    }

    private bool IsBrowsable(PropertyInfo prop)
    {
      foreach (BrowsableAttribute customAttribute in prop.GetCustomAttributes(typeof (BrowsableAttribute), true))
      {
        if (!customAttribute.Browsable)
          return false;
      }
      return true;
    }

    public virtual bool FilterProperties(string propertyName)
    {
      return true;
    }

    protected class iGExpandablePropertyDescriptor : TypeConverter.SimplePropertyDescriptor
    {
      private static object fNoValue = new object();
      private readonly object fRootComponent;
      private readonly PropertyDescriptor fRootPropDescriptor;

      public iGExpandablePropertyDescriptor(Type componentType, string name, Type propertyType, Attribute[] attributes, object rootComponent, PropertyDescriptor rootPropDescriptor)
        : base(componentType, name, propertyType, attributes)
      {
        this.fRootComponent = rootComponent;
        this.fRootPropDescriptor = rootPropDescriptor;
      }

      private ISite GetSite()
      {
        IComponent fRootComponent = this.fRootComponent as IComponent;
        if (fRootComponent == null)
          return (ISite) null;
        return fRootComponent.Site;
      }

      private IComponentChangeService GetChangeService()
      {
        ISite site = this.GetSite();
        if (site == null)
          return (IComponentChangeService) null;
        return (IComponentChangeService) site.GetService(typeof (IComponentChangeService));
      }

      private IDesignerHost GetDesignerHost()
      {
        ISite site = this.GetSite();
        if (site == null)
          return (IDesignerHost) null;
        return (IDesignerHost) site.GetService(typeof (IDesignerHost));
      }

      public override void SetValue(object component, object value)
      {
        IDesignerHost designerHost = this.GetDesignerHost();
        DesignerTransaction designerTransaction = (DesignerTransaction) null;
        try
        {
          if (designerHost != null)
            designerTransaction = designerHost.CreateTransaction(this.Name);
          IComponentChangeService changeService = this.GetChangeService();
          if (changeService != null)
            changeService.OnComponentChanging(this.fRootComponent, (MemberDescriptor) this.fRootPropDescriptor);
          PropertyInfo property = this.ComponentType.GetProperty(this.Name);
          int num = property.PropertyType.IsSubclassOf(typeof (iGStyleBase)) ? 1 : 0;
          if (num != 0)
          {
            iGStyleConverterBase.iGCellStyleNew iGcellStyleNew = value as iGStyleConverterBase.iGCellStyleNew;
            if (iGcellStyleNew != null)
              value = (object) iGDesigner.CreateStyleDesignTime(iGcellStyleNew.Host, (string) null, typeof (iGCellStyleDesign), (iGStyleBase) null);
            if (value is iGStyleConverterBase.iGColHdrStyleNew)
              value = (object) iGDesigner.CreateStyleDesignTime(designerHost, (string) null, typeof (iGColHdrStyleDesign), (iGStyleBase) null);
          }
          property.SetValue(component, value, (object[]) null);
          if (num != 0 && designerHost != null)
          {
            IReferenceService service = (IReferenceService) designerHost.GetService(typeof (IReferenceService));
            iGInternalInfrastructure.ClearNonUsedDesignCellStyles(service);
            iGInternalInfrastructure.ClearNonUsedDesignColHdrStyles(service);
          }
          if (changeService == null)
            return;
          changeService.OnComponentChanged(this.fRootComponent, (MemberDescriptor) this.fRootPropDescriptor, (object) null, (object) null);
        }
        catch (CheckoutException ex)
        {
          CheckoutException canceled = CheckoutException.Canceled;
          if (ex != canceled || designerTransaction == null)
            return;
          designerTransaction.Cancel();
        }
        finally
        {
          if (designerTransaction != null)
            designerTransaction.Commit();
        }
      }

      public override object GetValue(object component)
      {
        return this.ComponentType.GetProperty(this.Name).GetValue(component, (object[]) null);
      }

      public override bool CanResetValue(object component)
      {
        return this.ShouldSerializeValue(component);
      }

      public override void ResetValue(object component)
      {
        if (this.IsReadOnly)
        {
          this.InvokeReset(component);
        }
        else
        {
          object valueAttributeValue = this.GetDefaultValueAttributeValue();
          try
          {
            if (valueAttributeValue == iGExpandableTypeConverter.iGExpandablePropertyDescriptor.fNoValue)
              this.InvokeReset(component);
            else
              this.SetValue(component, valueAttributeValue);
          }
          catch (Exception ex)
          {
          }
        }
      }

      public override bool ShouldSerializeValue(object component)
      {
        if (this.IsReadOnly)
          return this.InvokeShouldSerialize(component);
        object valueAttributeValue = this.GetDefaultValueAttributeValue();
        try
        {
          if (valueAttributeValue == iGExpandableTypeConverter.iGExpandablePropertyDescriptor.fNoValue)
            return this.InvokeShouldSerialize(component);
          return !object.Equals(valueAttributeValue, this.GetValue(component));
        }
        catch (Exception ex)
        {
          return true;
        }
      }

      private bool InvokeShouldSerialize(object component)
      {
        MethodInfo method = this.ComponentType.GetMethod("ShouldSerialize" + this.Name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        if (method == (MethodInfo) null)
          return true;
        try
        {
          return (bool) method.Invoke(component, (object[]) null);
        }
        catch (Exception ex)
        {
          return true;
        }
      }

      private object GetDefaultValueAttributeValue()
      {
        DefaultValueAttribute attribute = this.Attributes[typeof (DefaultValueAttribute)] as DefaultValueAttribute;
        if (attribute != null)
          return attribute.Value;
        return iGExpandableTypeConverter.iGExpandablePropertyDescriptor.fNoValue;
      }

      private void InvokeReset(object component)
      {
        IDesignerHost designerHost = this.GetDesignerHost();
        DesignerTransaction designerTransaction = (DesignerTransaction) null;
        try
        {
          if (designerHost != null)
            designerTransaction = designerHost.CreateTransaction(this.Name);
          IComponentChangeService changeService = this.GetChangeService();
          if (changeService != null)
            changeService.OnComponentChanging(this.fRootComponent, (MemberDescriptor) this.fRootPropDescriptor);
          MethodInfo method = this.ComponentType.GetMethod("Reset" + this.Name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
          if (method == (MethodInfo) null)
            return;
          try
          {
            method.Invoke(component, (object[]) null);
          }
          catch (Exception ex)
          {
          }
          if (changeService == null)
            return;
          changeService.OnComponentChanged(this.fRootComponent, (MemberDescriptor) this.fRootPropDescriptor, (object) null, (object) null);
        }
        catch (CheckoutException ex)
        {
          CheckoutException canceled = CheckoutException.Canceled;
          if (ex != canceled || designerTransaction == null)
            return;
          designerTransaction.Cancel();
        }
        finally
        {
          if (designerTransaction != null)
            designerTransaction.Commit();
        }
      }

      public object RootComponent
      {
        get
        {
          return this.fRootComponent;
        }
      }

      public PropertyDescriptor RootPropDescriptor
      {
        get
        {
          return this.fRootPropDescriptor;
        }
      }
    }
  }
}
