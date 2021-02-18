// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGImageIndexConverter
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGImageIndexConverter : iGTypeConverter
  {
    private const string cNone = "(none)";

    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
      if (sourceType == typeof (string) || sourceType == typeof (int))
        return true;
      return base.CanConvertFrom(context, sourceType);
    }

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      string s = value as string;
      if (s == null)
        return base.ConvertFrom(context, culture, value);
      if (s == "(none)")
        return (object) -1;
      return (object) int.Parse(s);
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (!(destinationType == typeof (string)) || !(value is int))
        return base.ConvertTo(context, culture, value, destinationType);
      int num = (int) value;
      if (num == -1)
        return (object) "(none)";
      return (object) num.ToString((IFormatProvider) culture);
    }

    public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
    {
      return true;
    }

    public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
    {
      return false;
    }

    public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
    {
      try
      {
        ImageList imageList = this.GetImageList(context);
        int length = 1;
        if (imageList != null)
          length += imageList.Images.Count;
        int[] numArray = new int[length];
        numArray[0] = -1;
        for (int index = 1; index < length; ++index)
          numArray[index] = index - 1;
        return new TypeConverter.StandardValuesCollection((ICollection) numArray);
      }
      catch (Exception ex)
      {
        return (TypeConverter.StandardValuesCollection) null;
      }
    }

    private ImageList GetImageList(ITypeDescriptorContext context)
    {
      return iGInternalInfrastructure.GetImageList(context);
    }
  }
}
