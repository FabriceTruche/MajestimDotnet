// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGCustomObjectConverter
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace TenTec.Windows.iGridLib.Design
{
  internal abstract class iGCustomObjectConverter : iGTypeConverter
  {
    private string[] fNames;
    private Type fType;

    public iGCustomObjectConverter(Type type)
    {
      MemberInfo[] memberInfoArray = !this.IsProperties ? (MemberInfo[]) type.GetFields() : (MemberInfo[]) type.GetProperties();
      ArrayList arrayList = new ArrayList(memberInfoArray.Length);
      for (int index = 0; index < memberInfoArray.Length; ++index)
      {
        if (this.AddPropertyOrField(memberInfoArray[index].Name))
          arrayList.Add((object) memberInfoArray[index].Name);
      }
      this.fNames = (string[]) arrayList.ToArray(typeof (string));
      this.fType = type;
    }

    protected virtual bool AddPropertyOrField(string name)
    {
      return true;
    }

    protected virtual bool ShowPropertyOrField(string name)
    {
      return true;
    }

    public iGCustomObjectConverter(Type type, string[] names)
    {
      this.fNames = names;
      this.fType = type;
    }

    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
      if (destinationType == typeof (InstanceDescriptor))
        return true;
      return base.CanConvertTo(context, destinationType);
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (!(destinationType == typeof (InstanceDescriptor)) || value == null || !(value.GetType() == this.fType))
        return base.ConvertTo(context, culture, value, destinationType);
      ConstructorInfo constructor;
      object[] @params;
      iGTypeConverter.GetConstructorAndParams(this.fType, this.GetMemberInfoes(), value, out constructor, out @params);
      return (object) new InstanceDescriptor((MemberInfo) constructor, (ICollection) @params);
    }

    private MemberInfo[] GetMemberInfoes()
    {
      MemberInfo[] memberInfoArray = new MemberInfo[this.fNames.Length];
      for (int index = 0; index < this.fNames.Length; ++index)
        memberInfoArray[index] = !this.IsProperties ? (MemberInfo) this.fType.GetField(this.fNames[index]) : (MemberInfo) this.fType.GetProperty(this.fNames[index]);
      return memberInfoArray;
    }

    private Type[] GetTypes()
    {
      Type[] typeArray = new Type[this.fNames.Length];
      for (int index = 0; index < typeArray.Length; ++index)
        typeArray[index] = this.GetType(this.fNames[index]);
      return typeArray;
    }

    protected virtual Type GetType(string name)
    {
      if (this.IsProperties)
        return this.fType.GetProperty(name).PropertyType;
      return this.fType.GetField(name).FieldType;
    }

    public override bool GetPropertiesSupported(ITypeDescriptorContext context)
    {
      return true;
    }

    public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
    {
      ArrayList arrayList = new ArrayList(this.fNames.Length);
      for (int index = 0; index < this.fNames.Length; ++index)
      {
        if (this.ShowPropertyOrField(this.fNames[index]))
        {
          Attribute[] attributes1 = (Attribute[]) null;
          try
          {
            object[] objArray = !this.IsProperties ? this.fType.GetField(this.fNames[index]).GetCustomAttributes(true) : this.fType.GetProperty(this.fNames[index]).GetCustomAttributes(true);
            if (objArray != null)
            {
              attributes1 = new Attribute[objArray.Length];
              objArray.CopyTo((Array) attributes1, 0);
            }
          }
          catch (Exception ex)
          {
          }
          if (this.IsProperties)
            arrayList.Add((object) new iGCustomObjectConverter.iGCustomPropertyDescriptor(this.fType, this.fNames[index], this.GetType(this.fNames[index]), attributes1));
          else
            arrayList.Add((object) new iGCustomObjectConverter.iGCustomFieldDescriptor(this.fType, this.fNames[index], this.GetType(this.fNames[index]), attributes1));
        }
      }
      return new PropertyDescriptorCollection((PropertyDescriptor[]) arrayList.ToArray(typeof (PropertyDescriptor))).Sort();
    }

    public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
    {
      object[] parameters = new object[this.fNames.Length];
      Type[] types = this.GetTypes();
      for (int index = 0; index < this.fNames.Length; ++index)
        parameters[index] = propertyValues[(object) this.fNames[index]];
      return this.fType.GetConstructor(types).Invoke(parameters);
    }

    public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
    {
      return true;
    }

    public abstract bool IsProperties { get; }

    protected class iGCustomFieldDescriptor : iGTypeConverter.iGSimplePropertyDescriptor
    {
      public iGCustomFieldDescriptor(Type componentType, string name, Type propertyType, Attribute[] attributes)
        : base(componentType, name, propertyType, attributes)
      {
      }

      public override object GetValue(object component)
      {
        return component.GetType().GetField(this.Name).GetValue(component);
      }

      protected override void SetValueMethod(object component, object value)
      {
        component.GetType().GetField(this.Name).SetValue(component, value);
      }

      public override string Description
      {
        get
        {
          object[] customAttributes = this.ComponentType.GetField(this.Name).GetCustomAttributes(typeof (DescriptionAttribute), true);
          if (customAttributes != null && customAttributes.Length != 0)
            return (customAttributes[0] as DescriptionAttribute).Description;
          return string.Empty;
        }
      }
    }

    protected class iGCustomPropertyDescriptor : iGTypeConverter.iGSimplePropertyDescriptor
    {
      public iGCustomPropertyDescriptor(Type componentType, string name, Type propertyType, Attribute[] attributes)
        : base(componentType, name, propertyType, attributes)
      {
      }

      public override object GetValue(object component)
      {
        return component.GetType().GetProperty(this.Name).GetValue(component, (object[]) null);
      }

      protected override void SetValueMethod(object component, object value)
      {
        component.GetType().GetProperty(this.Name).SetValue(component, value, (object[]) null);
      }
    }
  }
}
