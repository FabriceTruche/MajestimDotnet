// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGPenStyleConverter
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGPenStyleConverter : iGCustomObjectConverter
  {
    public iGPenStyleConverter()
      : base(typeof (iGPenStyle))
    {
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (!(destinationType == typeof (string)) || !(value is iGPenStyle))
        return base.ConvertTo(context, culture, value, destinationType);
      iGPenStyle iGpenStyle = (iGPenStyle) value;
      return (object) string.Join("][", new string[3]
      {
        "[" + TypeDescriptor.GetConverter(typeof (Color)).ConvertToString(context, culture, (object) (ValueType) iGpenStyle.Color),
        TypeDescriptor.GetConverter(typeof (DashStyle)).ConvertToString(context, culture, (object) (DashStyle) iGpenStyle.DashStyle),
        TypeDescriptor.GetConverter(typeof (int)).ConvertToString(context, culture, (object) (int) iGpenStyle.Width) + "]"
      });
    }

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      string str1 = value as string;
      if (str1 == null)
        return base.ConvertFrom(context, culture, value);
      char[] chArray = new char[1]{ ']' };
      string[] strArray = str1.Split(chArray);
      int index1 = 0;
      string str2 = strArray[index1].Trim();
      Color color = (Color) TypeDescriptor.GetConverter(typeof (Color)).ConvertFromString(context, culture, str2.Substring(1, str2.Length - 1));
      int index2 = 1;
      string str3 = strArray[index2].Trim();
      DashStyle dashStyle = (DashStyle) TypeDescriptor.GetConverter(typeof (DashStyle)).ConvertFromString(context, culture, str3.Substring(1, str3.Length - 1));
      int index3 = 2;
      string str4 = strArray[index3].Trim();
      int num = (int) TypeDescriptor.GetConverter(typeof (int)).ConvertFromString(context, culture, str4.Substring(1, str4.Length - 1));
      return (object) new iGPenStyle(color, num, dashStyle);
    }

    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
      if (sourceType == typeof (string))
        return true;
      return base.CanConvertFrom(context, sourceType);
    }

    public override bool IsProperties
    {
      get
      {
        return false;
      }
    }
  }
}
