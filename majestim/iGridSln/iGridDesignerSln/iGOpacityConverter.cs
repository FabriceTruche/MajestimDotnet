// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGOpacityConverter
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.ComponentModel;
using System.Globalization;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGOpacityConverter : TypeConverter
  {
    private const char cPercentage = '%';

    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
      if (sourceType == typeof (string))
        return true;
      return base.CanConvertFrom(context, sourceType);
    }

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      string str = value as string;
      if (str != null)
      {
        string s = str.Trim();
        if (s.Length > 0)
        {
          if ((int) s[s.Length - 1] == 37)
            s = s.Substring(0, s.Length - 1);
          return (object) (double.Parse(s) / 100.0);
        }
      }
      return base.ConvertFrom(context, culture, value);
    }

    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
      if (destinationType == typeof (string))
        return true;
      return base.CanConvertTo(context, destinationType);
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (destinationType == typeof (string))
        return (object) (((double) value * 100.0).ToString() + "%");
      return base.ConvertTo(context, culture, value, destinationType);
    }
  }
}
