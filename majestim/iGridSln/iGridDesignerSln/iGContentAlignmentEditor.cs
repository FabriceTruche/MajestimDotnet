// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGContentAlignmentEditor
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGContentAlignmentEditor : UITypeEditor
  {
    private static iGContentAlignmentControl fControl;

    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
    {
      return UITypeEditorEditStyle.DropDown;
    }

    public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
    {
      if (provider != null)
      {
        IWindowsFormsEditorService service = (IWindowsFormsEditorService) provider.GetService(typeof (IWindowsFormsEditorService));
        if (service != null)
        {
          if (iGContentAlignmentEditor.fControl == null)
            iGContentAlignmentEditor.fControl = new iGContentAlignmentControl();
          iGContentAlignmentEditor.fControl.AdjustSize();
          iGContentAlignmentEditor.fControl.Start(service, value);
          service.DropDownControl((Control) iGContentAlignmentEditor.fControl);
          value = (object) iGContentAlignmentEditor.fControl.Value;
          iGContentAlignmentEditor.fControl.End();
        }
      }
      return value;
    }
  }
}
