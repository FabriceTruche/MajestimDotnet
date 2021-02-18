// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGStringConverter
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System.ComponentModel;
using System.Globalization;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGStringConverter : StringConverter
  {
    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      string str = value as string;
      if (str != null && str.Length == 0)
        return (object) null;
      return base.ConvertFrom(context, culture, value);
    }
  }
}
