// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGImageIndexEditor
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGImageIndexEditor : UITypeEditor
  {
    private UITypeEditor fImageEditor;

    public iGImageIndexEditor()
    {
      this.fImageEditor = (UITypeEditor) TypeDescriptor.GetEditor(typeof (Image), typeof (UITypeEditor));
    }

    public override bool GetPaintValueSupported(ITypeDescriptorContext context)
    {
      if (this.fImageEditor != null)
        return this.fImageEditor.GetPaintValueSupported(context);
      return false;
    }

    public override void PaintValue(PaintValueEventArgs e)
    {
      try
      {
        if (this.fImageEditor == null || !(e.Value is int))
          return;
        int index = (int) e.Value;
        ImageList imageList = this.GetImageList(e.Context);
        if (imageList == null || index < 0 || index >= imageList.Images.Count)
          return;
        this.fImageEditor.PaintValue(new PaintValueEventArgs(e.Context, (object) imageList.Images[index], e.Graphics, e.Bounds));
      }
      catch (Exception ex)
      {
      }
    }

    private ImageList GetImageList(ITypeDescriptorContext context)
    {
      return iGInternalInfrastructure.GetImageList(context);
    }
  }
}
