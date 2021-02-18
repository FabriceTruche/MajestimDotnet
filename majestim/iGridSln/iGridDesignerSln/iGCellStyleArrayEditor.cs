// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGCellStyleArrayEditor
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
  internal class iGCellStyleArrayEditor : UITypeEditor
  {
    private iGGroupRowLevelStylesDialog fDialog;

    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
    {
      return UITypeEditorEditStyle.Modal;
    }

    public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
    {
      if (provider != null)
      {
        DesignerTransaction designerTransaction = (DesignerTransaction) null;
        IDesignerHost service1 = (IDesignerHost) provider.GetService(typeof (IDesignerHost));
        if (service1 != null)
        {
          if (context != null)
          {
            try
            {
              designerTransaction = service1.CreateTransaction("Change " + (context.Instance as Control).Name + "." + context.PropertyDescriptor.Name);
            }
            catch (CheckoutException ex)
            {
              if (ex != CheckoutException.Canceled)
                throw ex;
              return value;
            }
          }
        }
        bool flag = false;
        try
        {
          iGCellStyle[] styles = value as iGCellStyle[];
          if (this.fDialog == null)
            this.fDialog = new iGGroupRowLevelStylesDialog();
          this.fDialog.Initialize(provider, styles);
          IWindowsFormsEditorService service2 = (IWindowsFormsEditorService) provider.GetService(typeof (IWindowsFormsEditorService));
          if ((service2 == null ? this.fDialog.ShowDialog() : service2.ShowDialog((Form) this.fDialog)) == DialogResult.OK)
          {
            if (context != null && context.Instance != null)
            {
              iGCellStyle[] iGcellStyleArray = this.fDialog.Styles;
              if (iGcellStyleArray.Length == 0)
                iGcellStyleArray = new iGCellStyle[1]
                {
                  iGInternalInfrastructure.GetDefaultGroupRowStyle().Clone()
                };
              context.PropertyDescriptor.SetValue(context.Instance, (object) iGcellStyleArray);
              iGInternalInfrastructure.ClearNonUsedDesignCellStyles((IReferenceService) provider.GetService(typeof (IReferenceService)));
            }
            flag = true;
          }
        }
        finally
        {
          if (designerTransaction != null)
          {
            if (flag)
              designerTransaction.Commit();
            else
              designerTransaction.Cancel();
          }
        }
      }
      return value;
    }
  }
}
