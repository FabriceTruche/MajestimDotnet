// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGStyleConverterBase
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Globalization;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGStyleConverterBase : ComponentConverter
  {
    private const string cCreateNew = "Create new ...";
    private const string cDefault = "Default";
    private Type fType;
    private bool fAllowNull;

    internal iGStyleConverterBase(Type type, bool allowNull)
      : base(type)
    {
      this.fType = type;
      this.fAllowNull = allowNull;
    }

    public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
    {
      if (context != null)
      {
        IReferenceService service = (IReferenceService) context.GetService(typeof (IReferenceService));
        if (service != null)
        {
          object[] references = service.GetReferences(this.fType);
          ArrayList arrayList = new ArrayList();
          if (this.fType == typeof (iGCellStyle))
            arrayList.Add((object) new iGStyleConverterBase.iGCellStyleNew((IDesignerHost) context.GetService(typeof (IDesignerHost))));
          else
            arrayList.Add((object) new iGStyleConverterBase.iGColHdrStyleNew((IDesignerHost) context.GetService(typeof (IDesignerHost))));
          if (this.fAllowNull)
            arrayList.Add((object) null);
          foreach (object obj in references)
            arrayList.Add(obj);
          return new TypeConverter.StandardValuesCollection((ICollection) arrayList.ToArray());
        }
      }
      return base.GetStandardValues(context);
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (value != null && destinationType == typeof (string))
      {
        Type type = value.GetType();
        if (type == typeof (iGStyleConverterBase.iGCellStyleNew) || type == typeof (iGStyleConverterBase.iGColHdrStyleNew))
          return (object) "Create new ...";
        if (!this.CanExposeProperties(context, value as Component))
          return (object) "Default";
      }
      return base.ConvertTo(context, culture, value, destinationType);
    }

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      string strA = value as string;
      if (strA != null && string.CompareOrdinal(strA, "Create new ...") == 0 && context != null)
      {
        if (this.fType == typeof (iGCellStyle))
          return (object) new iGStyleConverterBase.iGCellStyleNew((IDesignerHost) context.GetService(typeof (IDesignerHost)));
        if (this.fType == typeof (iGColHdrStyle))
          return (object) new iGStyleConverterBase.iGColHdrStyleNew((IDesignerHost) context.GetService(typeof (IDesignerHost)));
      }
      return base.ConvertFrom(context, culture, value);
    }

    public override bool GetPropertiesSupported(ITypeDescriptorContext context)
    {
      if (!this.CanExposeProperties(context))
        return false;
      return base.GetPropertiesSupported(context);
    }

    public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
    {
      if (!this.CanExposeProperties(context, value as Component))
        return (PropertyDescriptorCollection) null;
      return base.GetProperties(context, value, attributes);
    }

    private bool CanExposeProperties(ITypeDescriptorContext context, Component component)
    {
      return context == null || component == null || (component.Container != null || context.GetService(typeof (IDesignerHost)) == null);
    }

    private bool CanExposeProperties(ITypeDescriptorContext context)
    {
      if (context != null && context.PropertyDescriptor != null && (context.Instance != null && context.Instance.GetType() != this.fType))
        return this.CanExposeProperties(context, context.PropertyDescriptor.GetValue(context.Instance) as Component);
      return true;
    }

    internal class iGCellStyleNew : iGCellStyle
    {
      public IDesignerHost Host;

      public iGCellStyleNew(IDesignerHost host)
      {
                // FABRICE
        //this.\u002Ector();
        this.Host = host;
      }
    }

    internal class iGColHdrStyleNew : iGColHdrStyle
    {
      public IDesignerHost Host;

      public iGColHdrStyleNew(IDesignerHost host)
      {
          // FABRICE
                //this.\u002Ector();
                this.Host = host;
      }
    }
  }
}
