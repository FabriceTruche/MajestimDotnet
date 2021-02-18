// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGScrollBarCustomButtonConverter
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
  internal class iGScrollBarCustomButtonConverter : iGTypeConverter
  {
    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
      if (destinationType == typeof (InstanceDescriptor))
        return true;
      return base.CanConvertTo(context, destinationType);
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (!(destinationType == typeof (InstanceDescriptor)))
        return base.ConvertTo(context, culture, value, destinationType);
      ConstructorInfo constructor = typeof (iGScrollBarCustomButton).GetConstructor(new Type[6]
      {
        typeof (iGScrollBarCustomButtonAlign),
        typeof (iGActions),
        typeof (int),
        typeof (string),
        typeof (bool),
        typeof (object)
      });
      iGScrollBarCustomButton gscrollBarCustomButton = (iGScrollBarCustomButton) value;
      object[] objArray = new object[6]
      {
        (object) gscrollBarCustomButton.Alignment,
        (object) gscrollBarCustomButton.Action,
        (object) gscrollBarCustomButton.ImageIndex,
        (object) gscrollBarCustomButton.ToolTipText,
        (object) gscrollBarCustomButton.Enabled,
        null
      };
      int num = 1;
      return (object) new InstanceDescriptor((MemberInfo) constructor, (ICollection) objArray, num != 0);
    }
  }
}
