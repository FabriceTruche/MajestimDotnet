// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGValueTypeConverter
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGValueTypeConverter : iGTypeConverter
  {
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
      if (sourceType == typeof (string))
        return true;
      return base.CanConvertFrom(context, sourceType);
    }

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      try
      {
        string strA = value as string;
        if (strA == null)
          return base.ConvertFrom(context, culture, value);
        if (strA.Length == 0 || string.Compare(strA, "NotSet", true) == 0)
          return (object) null;
        return (object) this.GetTypeFromCode((TypeCode) Enum.Parse(typeof (TypeCode), strA, true));
      }
      catch (Exception ex)
      {
        return (object) null;
      }
    }

    private Type GetTypeFromCode(TypeCode code)
    {
      switch (code)
      {
        case TypeCode.Empty:
          return (Type) null;
        case TypeCode.Object:
          return typeof (object);
        case TypeCode.DBNull:
          return typeof (DBNull);
        case TypeCode.Boolean:
          return typeof (bool);
        case TypeCode.Char:
          return typeof (char);
        case TypeCode.SByte:
          return typeof (sbyte);
        case TypeCode.Byte:
          return typeof (byte);
        case TypeCode.Int16:
          return typeof (short);
        case TypeCode.UInt16:
          return typeof (ushort);
        case TypeCode.Int32:
          return typeof (int);
        case TypeCode.UInt32:
          return typeof (uint);
        case TypeCode.Int64:
          return typeof (long);
        case TypeCode.UInt64:
          return typeof (ulong);
        case TypeCode.Single:
          return typeof (float);
        case TypeCode.Double:
          return typeof (double);
        case TypeCode.Decimal:
          return typeof (Decimal);
        case TypeCode.DateTime:
          return typeof (DateTime);
        case TypeCode.String:
          return typeof (string);
        default:
          return (Type) null;
      }
    }

    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
      if (destinationType == typeof (string))
        return true;
      return base.CanConvertTo(context, destinationType);
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      try
      {
        if (!(destinationType == typeof (string)))
          return base.ConvertTo(context, culture, value, destinationType);
        Type type = value as Type;
        if (type == (Type) null)
          return (object) "NotSet";
        return (object) Type.GetTypeCode(type).ToString();
      }
      catch (Exception ex)
      {
        return (object) null;
      }
    }

    public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
    {
      return true;
    }

    public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
    {
      TypeCode[] values = (TypeCode[]) Enum.GetValues(typeof (TypeCode));
      Type[] typeArray = new Type[values.Length];
      for (int index = 0; index < values.Length; ++index)
        typeArray[index] = this.GetTypeFromCode(values[index]);
      return new TypeConverter.StandardValuesCollection((ICollection) typeArray);
    }
  }
}
