// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGIndentConverter
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.ComponentModel;
using System.Globalization;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGIndentConverter : iGCustomObjectConverter
  {
    public iGIndentConverter()
      : base(typeof (iGIndent))
    {
    }

    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
      if (sourceType == typeof (string))
        return true;
      return base.CanConvertFrom(context, sourceType);
    }

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      if (!(value is string))
        return base.ConvertFrom(context, culture, value);
      string str = ((string) value).Trim();
      if (str.Length == 0 || string.Compare(str, "NotSet", true) == 0)
        return (object) iGIndent.NotSet;
      if (culture == null)
        culture = CultureInfo.CurrentCulture;
      char[] chArray = new char[1]
      {
        culture.TextInfo.ListSeparator[0]
      };
      string[] strArray = str.Split(chArray);
      int[] numArray = new int[strArray.Length];
      TypeConverter typeConverter = (TypeConverter) new iGIndentFieldConverter();
      for (int index = 0; index < strArray.Length; ++index)
        numArray[index] = (int) typeConverter.ConvertFromString(context, culture, strArray[index]);
      if (numArray.Length == 4)
        return (object) new iGIndent(numArray[0], numArray[1], numArray[2], numArray[3]);
      throw new ArgumentException("Failed to parse Text", str);
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (!(destinationType == typeof (string)))
        return base.ConvertTo(context, culture, value, destinationType);
      iGIndent iGindent = (iGIndent) value;
      // ISSUE: explicit reference operation
      if (((iGIndent) @iGindent).EqualsTo(iGIndent.NotSet))
        return (object) "NotSet";
      if (culture == null)
        culture = CultureInfo.CurrentCulture;
      string separator = culture.TextInfo.ListSeparator + " ";
      TypeConverter typeConverter = (TypeConverter) new iGIndentFieldConverter();
      // ISSUE: explicit reference operation
      // ISSUE: explicit reference operation
      // ISSUE: explicit reference operation
      // ISSUE: explicit reference operation
      string[] strArray = new string[4]
      {
        typeConverter.ConvertToString(context, culture, (object) ((iGIndent) @iGindent).Left),
        typeConverter.ConvertToString(context, culture, (object) ((iGIndent) @iGindent).Top),
        typeConverter.ConvertToString(context, culture, (object) ((iGIndent) @iGindent).Right),
        typeConverter.ConvertToString(context, culture, (object) ((iGIndent) @iGindent).Bottom)
      };
      return (object) string.Join(separator, strArray);
    }

    protected override bool AddPropertyOrField(string name)
    {
      if (name != null && (name == "IsNotSet" || name == "NotSet"))
        return false;
      return base.AddPropertyOrField(name);
    }

    public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
    {
      return base.GetProperties(context, value, attributes).Sort(new string[4]
      {
        "Left",
        "Top",
        "Right",
        "Bottom"
      });
    }

    public override bool IsProperties
    {
      get
      {
        return true;
      }
    }
  }
}
