// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGIndentFieldConverter
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.ComponentModel;
using System.Globalization;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGIndentFieldConverter : iGTypeConverter
  {
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
      if (sourceType == typeof (string))
        return true;
      return base.CanConvertFrom(context, sourceType);
    }

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      string str = value as string;
      if (str == null)
        return base.ConvertFrom(context, culture, value);
      string s = str.Trim();
      if (s.ToUpper() == "NotSet".ToUpper() || s.Length == 0)
        return (object) -1;
      return (object) int.Parse(s);
    }

    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
      if (destinationType == typeof (string))
        return true;
      return base.CanConvertTo(context, destinationType);
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (!(destinationType == typeof (string)))
        return base.ConvertTo(context, culture, value, destinationType);
      int num = (int) value;
      if (num == -1)
        return (object) "NotSet";
      return (object) num.ToString();
    }
  }
}
