// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGOpacityEditor
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGOpacityEditor : UITypeEditor
  {
    private static iGControlOpacity fControl;

    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
    {
      if (context != null && context.Instance != null)
        return UITypeEditorEditStyle.DropDown;
      return base.GetEditStyle(context);
    }

    public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
    {
      if (provider != null && context != null && (context.Instance != null && value is double))
      {
        IWindowsFormsEditorService service1 = (IWindowsFormsEditorService) provider.GetService(typeof (IWindowsFormsEditorService));
        if (service1 != null)
        {
          DesignerTransaction designerTransaction = (DesignerTransaction) null;
          try
          {
            IDesignerHost service2 = (IDesignerHost) provider.GetService(typeof (IDesignerHost));
            if (service2 != null)
              designerTransaction = service2.CreateTransaction("Opacity");
            IComponentChangeService service3 = (IComponentChangeService) provider.GetService(typeof (IComponentChangeService));
            if (service3 != null)
              service3.OnComponentChanging(context.Instance, (MemberDescriptor) context.PropertyDescriptor);
            if (iGOpacityEditor.fControl == null)
              iGOpacityEditor.fControl = new iGControlOpacity();
            iGOpacityEditor.fControl.Start(context.Instance, context.PropertyDescriptor, (double) value, service1);
            service1.DropDownControl((Control) iGOpacityEditor.fControl);
            if (service3 != null)
              service3.OnComponentChanged(context.Instance, (MemberDescriptor) context.PropertyDescriptor, (object) null, (object) null);
          }
          catch (CheckoutException ex)
          {
            CheckoutException canceled = CheckoutException.Canceled;
            if (ex == canceled)
            {
              if (designerTransaction != null)
                designerTransaction.Cancel();
            }
          }
          finally
          {
            if (designerTransaction != null)
              designerTransaction.Commit();
          }
          return (object) iGOpacityEditor.fControl.Value;
        }
      }
      return base.EditValue(context, provider, value);
    }
  }
}
