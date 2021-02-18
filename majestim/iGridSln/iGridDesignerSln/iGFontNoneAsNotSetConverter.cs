﻿// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGFontNoneAsNotSetConverter
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGFontNoneAsNotSetConverter : FontConverter
  {
    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      if (string.Compare(value as string, "NotSet", true) == 0)
        return (object) null;
      return base.ConvertFrom(context, culture, value);
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (destinationType == typeof (string) && value == null)
        return (object) "NotSet";
      return base.ConvertTo(context, culture, value, destinationType);
    }
  }
}
