// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGDropDownListDesigner
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System.ComponentModel.Design;

namespace TenTec.Windows.iGridLib.Design
{
  public class iGDropDownListDesigner : ComponentDesigner
  {
    private DesignerVerbCollection verbs;

    public override DesignerVerbCollection Verbs
    {
      get
      {
        if (this.verbs == null)
          this.verbs = (DesignerVerbCollection) new iGDropDownListVerbCollection((ComponentDesigner) this, this.Component);
        return this.verbs;
      }
    }
  }
}
