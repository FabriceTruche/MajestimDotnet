﻿// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGDropDownListItemConverter
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
  internal class iGDropDownListItemConverter : iGTypeConverter
  {
    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
      if (destinationType == typeof (InstanceDescriptor))
        return true;
      return base.CanConvertTo(context, destinationType);
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (!(destinationType == typeof (InstanceDescriptor)) || value == null)
        return base.ConvertTo(context, culture, value, destinationType);
      ConstructorInfo constructor;
      object[] @params;
      iGTypeConverter.GetConstructorAndParams(typeof (iGDropDownListItem), (MemberInfo[]) typeof (iGDropDownListItem).GetProperties(), value, out constructor, out @params);
      return (object) new InstanceDescriptor((MemberInfo) constructor, (ICollection) @params);
    }
  }
}
