// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGStyleSerializer
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System.CodeDom;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGStyleSerializer : iGSerializerBase
  {
    public override object Deserialize(IDesignerSerializationManager manager, object codeObject)
    {
      return ((CodeDomSerializer) manager.GetSerializer(typeof (iGrid).BaseType, typeof (CodeDomSerializer))).Deserialize(manager, codeObject);
    }

    public override object Serialize(IDesignerSerializationManager manager, object value)
    {
      object obj = ((CodeDomSerializer) manager.GetSerializer(typeof (Component), typeof (CodeDomSerializer))).Serialize(manager, value);
      CodeStatementCollection statementCollection = obj as CodeStatementCollection;
      iGStyleBase iGstyleBase = value as iGStyleBase;
      if (statementCollection != null && iGstyleBase != null)
      {
        if (!((object) iGstyleBase).GetType().Name.EndsWith("Design"))
        {
          try
          {
            CodeAssignStatement codeAssignStatement = !(statementCollection[0] is CodeVariableDeclarationStatement) ? statementCollection[0] as CodeAssignStatement : statementCollection[1] as CodeAssignStatement;
            if (codeAssignStatement != null)
            {
              CodeObjectCreateExpression right = codeAssignStatement.Right as CodeObjectCreateExpression;
              if (right != null)
                right.Parameters.Add((CodeExpression) new CodePrimitiveExpression((object) true));
            }
          }
          catch
          {
          }
        }
      }
      return obj;
    }
  }
}
