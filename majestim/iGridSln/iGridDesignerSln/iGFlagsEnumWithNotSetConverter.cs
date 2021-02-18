// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGFlagsEnumWithNotSetConverter
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.ComponentModel;
using System.Reflection;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGFlagsEnumWithNotSetConverter : iGFlagsEnumConverter
  {
    public iGFlagsEnumWithNotSetConverter(Type type)
      : base(type)
    {
    }

    protected override PropertyDescriptor GetEnumFieldDescriptor(Type type, string name, ITypeDescriptorContext context)
    {
      return (PropertyDescriptor) new iGFlagsEnumWithNotSetConverter.iGEnumWithNotSetFieldDescriptor(type, name, context);
    }

    protected class iGEnumWithNotSetFieldDescriptor : iGFlagsEnumConverter.iGEnumFieldDescriptor
    {
      public iGEnumWithNotSetFieldDescriptor(Type componentType, string name, ITypeDescriptorContext context)
        : base(componentType, name, context)
      {
      }

      protected override void SetFieldValue(object component, object value)
      {
        int fieldValue = this.GetFieldValue(component, "NotSet");
        if ((bool) value)
        {
          if (this.Name == "NotSet")
          {
            if ((bool) value)
            {
              this.SetEnumValue(fieldValue, component);
              return;
            }
          }
          else if ((fieldValue & (int) component) == fieldValue)
          {
            this.SetEnumValue((int) component & ~fieldValue | (int) Enum.Parse(this.ComponentType, this.Name), component);
            return;
          }
        }
        base.SetFieldValue(component, value);
      }

      private int GetFieldValue(object component, string fieldName)
      {
        return (int) component.GetType().GetField(fieldName, BindingFlags.Static | BindingFlags.Public).GetValue((object) null);
      }
    }
  }
}
