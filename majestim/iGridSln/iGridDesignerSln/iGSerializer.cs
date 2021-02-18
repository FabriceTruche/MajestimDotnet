// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGSerializer
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGSerializer : iGSerializerBase
  {
    public override object Deserialize(IDesignerSerializationManager manager, object codeObject)
    {
      object obj = ((CodeDomSerializer) manager.GetSerializer(typeof (iGrid).BaseType, typeof (CodeDomSerializer))).Deserialize(manager, codeObject);
      iGrid iGrid = obj as iGrid;
      if (iGrid != null && ((Component) iGrid).Site != null)
      {
        IDesignerHost service = (IDesignerHost) ((Component) iGrid).Site.GetService(typeof (IDesignerHost));
        iGrid.DefaultCol.CellStyle=(this.IfNotComponentCreateComponent(service, (iGStyleBase) iGrid.DefaultCol.CellStyle, true) as iGCellStyle);
        iGrid.RowTextCol.CellStyle=(this.IfNotComponentCreateComponent(service, (iGStyleBase) iGrid.RowTextCol.CellStyle, true) as iGCellStyle);
        if (iGInternalInfrastructure.ShouldSerializeGroupRowLevelStyles(iGrid))
        {
          for (int index = 0; index < iGrid.GroupRowLevelStyles.Length; ++index)
            iGrid.GroupRowLevelStyles[index] = this.IfNotComponentCreateComponent(service, (iGStyleBase) iGrid.GroupRowLevelStyles[index], false) as iGCellStyle;
        }
        foreach (iGCol col in (IEnumerable) iGrid.Cols)
          col.CellStyle=(this.IfNotComponentCreateComponent(service, (iGStyleBase) col.CellStyle, true) as iGCellStyle);
        foreach (iGCell cell in (IEnumerable) iGrid.Cells)
          cell.Style=(this.IfNotComponentCreateComponent(service, (iGStyleBase) cell.Style, true) as iGCellStyle);
        iGrid.DefaultCol.ColHdrStyle=(this.IfNotComponentCreateComponent(service, (iGStyleBase) iGrid.DefaultCol.ColHdrStyle, true) as iGColHdrStyle);
        foreach (iGCol col in (IEnumerable) iGrid.Cols)
          col.ColHdrStyle=(this.IfNotComponentCreateComponent(service, (iGStyleBase) col.ColHdrStyle, true) as iGColHdrStyle);
      }
      return obj;
    }

    public override object Serialize(IDesignerSerializationManager manager, object value)
    {
      return ((CodeDomSerializer) manager.GetSerializer(typeof (Control), typeof (CodeDomSerializer))).Serialize(manager, value);
    }

    private iGStyleBase IfNotComponentCreateComponent(IDesignerHost host, iGStyleBase style, bool checkShouldSerialize)
    {
      if (host == null)
        throw new ArgumentNullException(nameof (host));
      if (style == null)
        return (iGStyleBase) null;
      if (((Component) style).Container == null && (!checkShouldSerialize || iGInternalInfrastructure.iGSerializeManager.ShouldSerialize((object) style)))
        return iGDesigner.CreateStyleDesignTime(host, (string) null, ((object) style).GetType(), style);
      return style;
    }
  }
}
