// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGTypeConverter
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Globalization;
using System.Reflection;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGTypeConverter : TypeConverter
  {
    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (!(destinationType == typeof (string)))
        return base.ConvertTo(context, culture, value, destinationType);
      Type type = value.GetType();
      string str = type.Name;
      if (type.IsNested)
        str = type.DeclaringType.Name + "." + str;
      return (object) str;
    }

    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
      if (destinationType == typeof (string))
        return true;
      return base.CanConvertTo(context, destinationType);
    }

    internal static void GetConstructorAndParams(Type type, MemberInfo[] infoes, object value, out ConstructorInfo constructor, out object[] @params)
    {
      Type[] types = new Type[infoes.Length];
      @params = new object[infoes.Length];
      for (int index = 0; index < infoes.Length; ++index)
      {
        PropertyInfo infoe1 = infoes[index] as PropertyInfo;
        if (infoe1 != (PropertyInfo) null)
        {
          types[index] = infoe1.PropertyType;
          @params[index] = infoe1.GetValue(value, (object[]) null);
        }
        else
        {
          FieldInfo infoe2 = infoes[index] as FieldInfo;
          if (infoe2 != (FieldInfo) null)
          {
            types[index] = infoe2.FieldType;
            @params[index] = infoe2.GetValue(value);
          }
        }
      }
      constructor = type.GetConstructor(types);
    }

    protected abstract class iGSimplePropertyDescriptor : TypeConverter.SimplePropertyDescriptor
    {
      public iGSimplePropertyDescriptor(Type componentType, string name, Type propertyType, Attribute[] attributes)
        : base(componentType, name, propertyType, attributes)
      {
      }

      public iGSimplePropertyDescriptor(Type componentType, string name, Type propertyType)
        : base(componentType, name, propertyType)
      {
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
            this.SetValueMethod(component, value);
            this.OnValueChanged(component, EventArgs.Empty);
            if (service == null)
              return;
            service.OnComponentChanged(component, (MemberDescriptor) this, oldValue, value);
            return;
          }
        }
        this.SetValueMethod(component, value);
      }

      protected abstract void SetValueMethod(object component, object value);
    }
  }
}
