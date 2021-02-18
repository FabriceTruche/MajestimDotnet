// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGDropDownListVerbCollection
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGDropDownListVerbCollection : DesignerVerbCollection
  {
    private ComponentDesigner _owner;
    private iGDropDownList fDropDownList;

    public iGDropDownListVerbCollection(ComponentDesigner owner, IComponent component)
    {
      this._owner = owner;
      this.fDropDownList = component as iGDropDownList;
      this.Add(new DesignerVerb("Edit items...", new EventHandler(this.InvokeItemsDialog)));
    }

    public void InvokeItemsDialog(object sender, EventArgs e)
    {
      EditorServiceContext.EditValue(this._owner, (object) this.fDropDownList, "Items");
    }
  }
}
