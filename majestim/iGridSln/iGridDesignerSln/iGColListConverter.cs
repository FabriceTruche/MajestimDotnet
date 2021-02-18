// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGColListConverter
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGColListConverter : iGTypeConverter
  {
    private const string cNone = "(none)";
    private const string cRowTextCol = "(Row Text Column)";

    public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
    {
      return true;
    }

    private iGrid GetGrid(ITypeDescriptorContext context)
    {
      iGrid instance1 = context.Instance as iGrid;
      if (instance1 != null)
        return instance1;
      IiGridProvider instance2 = context.Instance as IiGridProvider;
      if (instance2 != null)
        return instance2.Grid;
      return (iGrid) null;
    }

    public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
    {
      if (context != null)
      {
        iGrid grid = this.GetGrid(context);
        if (grid != null)
        {
          iGCol[] iGcolArray = new iGCol[grid.Cols.Count + 2];
          iGcolArray[0] = (iGCol) null;
          iGcolArray[1] = grid.RowTextCol;
          for (int index = 0; index < grid.Cols.Count; ++index)
            iGcolArray[index + 2] = grid.Cols[index];
          return new TypeConverter.StandardValuesCollection((ICollection) iGcolArray);
        }
      }
      return base.GetStandardValues(context);
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (!(destinationType == typeof (string)))
        return base.ConvertTo(context, culture, value, destinationType);
      if (value == null)
        return (object) "(none)";
      iGCol iGcol = value as iGCol;
      if (iGcol.IsRowText)
        return (object) "(Row Text Column)";
      string str = iGcol.Index.ToString();
      if (iGcol.Text != null && iGcol.Text.ToString().Length > 0 || iGcol.Key != null && iGcol.Key.Length > 0)
        str += ": ";
      if (iGcol.Text != null && iGcol.Text.ToString().Length > 0)
        str = str + iGcol.Text.ToString() + " ";
      if (iGcol.Key != null && iGcol.Key.Length > 0)
        str = str + "[" + iGcol.Key + "]";
      return (object) str;
    }

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      if (context != null)
      {
        iGrid grid = this.GetGrid(context);
        if (grid != null)
        {
          string s = value as string;
          if (s != null)
          {
            if (s == "(none)")
              return (object) null;
            if (s == "(Row Text Column)")
              return (object) grid.RowTextCol;
            int length = s.IndexOf(":");
            int num = length <= 0 ? int.Parse(s) : int.Parse(s.Substring(0, length));
            return (object) grid.Cols[num];
          }
        }
      }
      return base.ConvertFrom(context, culture, value);
    }

    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
      if (sourceType == typeof (string))
        return true;
      return base.CanConvertFrom(context, sourceType);
    }
  }
}
