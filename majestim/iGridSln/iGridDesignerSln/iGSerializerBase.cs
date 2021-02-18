// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGSerializerBase
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.CodeDom;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Reflection;

namespace TenTec.Windows.iGridLib.Design
{
  internal abstract class iGSerializerBase : CodeDomSerializer
  {
    public static CodePropertyReferenceExpression GetPropertyReferenceExpression(IDesignerSerializationManager manager)
    {
      if (manager.Context.Current.GetType() == typeof (ExpressionContext))
        return (manager.Context.Current as ExpressionContext).Expression as CodePropertyReferenceExpression;
      return manager.Context.Current as CodePropertyReferenceExpression;
    }

    public static bool ShouldClearCollection(IDesignerSerializationManager manager, object collection)
    {
      PropertyDescriptor property = manager.Properties["ClearCollections"];
      if (property != null && property.PropertyType == typeof (bool) && (bool) property.GetValue((object) manager))
        return true;
      Type type = typeof (CodeDomSerializer).Assembly.GetType("System.ComponentModel.Design.Serialization.SerializeAbsoluteContext");
      if (type != (Type) null)
      {
        object obj = manager.Context[type];
        PropertyDescriptor propertyDescriptor = manager.Context[typeof (PropertyDescriptor)] as PropertyDescriptor;
        if (obj != null)
        {
          if ((bool) type.GetMethod("ShouldSerialize", BindingFlags.Instance | BindingFlags.Public).Invoke(obj, new object[1]
          {
            (object) propertyDescriptor
          }))
            return true;
        }
      }
      return false;
    }
  }
}
