// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGFlagsEnumConverter
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGFlagsEnumConverter : EnumConverter
  {
    public iGFlagsEnumConverter(Type type)
      : base(type)
    {
    }

    public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
    {
      if (context != null)
      {
        Type type = value.GetType();
        string[] names = Enum.GetNames(type);
        Array values = Enum.GetValues(type);
        if (names != null)
        {
          PropertyDescriptorCollection descriptorCollection = new PropertyDescriptorCollection((PropertyDescriptor[]) null);
          for (int index = 0; index < names.Length; ++index)
          {
            if ((int) values.GetValue(index) != 0 && names[index] != "All")
              descriptorCollection.Add(this.GetEnumFieldDescriptor(type, names[index], context));
          }
          return descriptorCollection;
        }
      }
      return base.GetProperties(context, value, attributes);
    }

    protected virtual PropertyDescriptor GetEnumFieldDescriptor(Type type, string name, ITypeDescriptorContext context)
    {
      return (PropertyDescriptor) new iGFlagsEnumConverter.iGEnumFieldDescriptor(type, name, context);
    }

    public override bool GetPropertiesSupported(ITypeDescriptorContext context)
    {
      if (context != null)
        return true;
      return base.GetPropertiesSupported(context);
    }

    public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
    {
      return false;
    }

    protected class iGEnumFieldDescriptor : TypeConverter.SimplePropertyDescriptor
    {
      private const string cDefValueMethodPrefix = "FlagsEnumDefaultValue";
      private ITypeDescriptorContext fContext;

      public iGEnumFieldDescriptor(Type componentType, string name, ITypeDescriptorContext context)
        : base(componentType, name, typeof (bool))
      {
        this.fContext = context;
      }

      public override object GetValue(object component)
      {
        return (object) ((uint) ((int) component & (int) Enum.Parse(this.ComponentType, this.Name)) > 0U);
      }

      public override void SetValue(object component, object value)
      {
        if (component == null)
          return;
        IComponent component1 = component as IComponent;
        if (component1 != null)
        {
          ISite site = component1.Site;
          if (site != null)
          {
            IComponentChangeService service = (IComponentChangeService) site.GetService(typeof (IComponentChangeService));
            if (service != null)
            {
              try
              {
                service.OnComponentChanging(component, (MemberDescriptor) this);
              }
              catch (CheckoutException ex)
              {
                if (ex == CheckoutException.Canceled)
                  return;
                throw ex;
              }
            }
            object oldValue = this.GetValue(component);
            this.SetFieldValue(component, value);
            this.OnValueChanged(component, EventArgs.Empty);
            if (service == null)
              return;
            service.OnComponentChanged(component, (MemberDescriptor) this, oldValue, value);
            return;
          }
        }
        this.SetFieldValue(component, value);
        this.OnValueChanged(component, EventArgs.Empty);
      }

      protected virtual void SetFieldValue(object component, object value)
      {
        this.SetEnumValue(!(bool) value ? (int) component & ~(int) Enum.Parse(this.ComponentType, this.Name) : (int) component | (int) Enum.Parse(this.ComponentType, this.Name), component);
      }

      protected virtual void SetEnumValue(int value, object component)
      {
        component.GetType().GetField("value__", BindingFlags.Instance | BindingFlags.Public).SetValue(component, (object) value);
        this.fContext.PropertyDescriptor.SetValue(this.fContext.Instance, component);
      }

      public override bool ShouldSerializeValue(object component)
      {
        return (bool) this.GetValue(component) != this.GetDefaultValue();
      }

      public override void ResetValue(object component)
      {
        this.SetValue(component, (object) this.GetDefaultValue());
      }

      public override bool CanResetValue(object component)
      {
        return this.ShouldSerializeValue(component);
      }

      private bool GetDefaultValue()
      {
        object obj = (object) null;
        string name = this.fContext.PropertyDescriptor.Name;
        Type componentType = this.fContext.PropertyDescriptor.ComponentType;
        DefaultValueAttribute customAttribute = (DefaultValueAttribute) Attribute.GetCustomAttribute((MemberInfo) componentType.GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic), typeof (DefaultValueAttribute));
        if (customAttribute != null)
          obj = customAttribute.Value;
        if (obj == null)
        {
          MethodInfo method = componentType.GetMethod("FlagsEnumDefaultValue" + name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
          if (method != (MethodInfo) null)
            obj = method.Invoke(this.fContext.Instance, (object[]) null);
        }
        if (obj != null)
          return (uint) ((int) obj & (int) Enum.Parse(this.ComponentType, this.Name)) > 0U;
        return false;
      }

      public override AttributeCollection Attributes
      {
        get
        {
          return new AttributeCollection(new Attribute[1]
          {
            (Attribute) RefreshPropertiesAttribute.Repaint
          });
        }
      }
    }
  }
}
