// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGPatternConverter
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
  internal class iGPatternConverter : ExpandableObjectConverter
  {
    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
      if (destinationType == typeof (InstanceDescriptor))
        return true;
      return base.CanConvertTo(context, destinationType);
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (destinationType == typeof (InstanceDescriptor))
        return (object) new InstanceDescriptor((MemberInfo) value.GetType().GetConstructor(Type.EmptyTypes), (ICollection) new object[0], false);
      return base.ConvertTo(context, culture, value, destinationType);
    }
  }
}
