// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGColSerializer
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System.CodeDom;
using System.ComponentModel.Design.Serialization;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGColSerializer : iGSerializerBase
  {
    public override object Deserialize(IDesignerSerializationManager manager, object codeObject)
    {
      return (object) null;
    }

    public override object Serialize(IDesignerSerializationManager manager, object value)
    {
      try
      {
        iGCol iGcol = value as iGCol;
        if (iGcol == null)
          return (object) null;
        CodePropertyReferenceExpression referenceExpression = iGSerializerBase.GetPropertyReferenceExpression(manager);
        if (referenceExpression == null)
          return (object) null;
        if (referenceExpression.PropertyName != "SearchCol" && referenceExpression.PropertyName != "TreeCol")
          return base.Serialize(manager, value);
        CodeExpression targetObject1;
        if (referenceExpression.PropertyName == "SearchCol")
        {
          CodePropertyReferenceExpression targetObject2 = referenceExpression.TargetObject as CodePropertyReferenceExpression;
          if (targetObject2 == null)
            return (object) null;
          targetObject1 = targetObject2.TargetObject;
        }
        else
          targetObject1 = referenceExpression.TargetObject;
        if (targetObject1 == null)
          return (object) null;
        CodeStatementCollection statementCollection = new CodeStatementCollection();
        if (iGcol == null)
          statementCollection.Add((CodeStatement) new CodeAssignStatement((CodeExpression) referenceExpression, (CodeExpression) new CodePrimitiveExpression((object) null)));
        else if (iGcol.IsRowText)
        {
          statementCollection.Add((CodeStatement) new CodeAssignStatement((CodeExpression) referenceExpression, (CodeExpression) new CodePropertyReferenceExpression(targetObject1, "RowTextCol")));
        }
        else
        {
          CodeExpression right = (CodeExpression) new CodeMethodInvokeExpression((CodeExpression) new CodePropertyReferenceExpression(targetObject1, "Cols"), "FromIndex", new CodeExpression[1]
          {
            (CodeExpression) new CodePrimitiveExpression((object) iGcol.Index)
          });
          statementCollection.Add((CodeStatement) new CodeAssignStatement((CodeExpression) referenceExpression, right));
        }
        return (object) statementCollection;
      }
      catch
      {
        return (object) null;
      }
    }
  }
}
