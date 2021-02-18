// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGColCollectionSerializer
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System.CodeDom;
using System.ComponentModel.Design.Serialization;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGColCollectionSerializer : iGSerializerBase
  {
    public const string cSetColsCount = "Set cols count";
    private const string cSetColCellStyleMethodName = "SetColCellStyle";
    private const string cSetColColHdrStyleMethodName = "SetColColHdrStyle";

    public override object Deserialize(IDesignerSerializationManager manager, object codeObject)
    {
      return (object) null;
    }

    public override object Serialize(IDesignerSerializationManager manager, object value)
    {
      try
      {
        iGColCollection iGcolCollection = value as iGColCollection;
        if (iGcolCollection == null)
          return (object) null;
        CodeExpression referenceExpression = (CodeExpression) iGSerializerBase.GetPropertyReferenceExpression(manager);
        if (referenceExpression == null)
          return (object) null;
        CodeStatementCollection statementCollection = new CodeStatementCollection();
        if (iGcolCollection.Count > 0)
        {
          CodeExpression[] codeExpressionArray1 = new CodeExpression[iGcolCollection.Count];
          for (int index = 0; index < iGcolCollection.Count; ++index)
          {
            iGColPattern pattern = iGcolCollection[index].Pattern;
            codeExpressionArray1[index] = this.SerializeToExpression(manager, (object) pattern);
          }
          CodeExpression[] codeExpressionArray2 = new CodeExpression[1]
          {
            (CodeExpression) new CodeArrayCreateExpression(typeof (iGColPattern), codeExpressionArray1)
          };
          CodeStatement codeStatement = (CodeStatement) new CodeExpressionStatement((CodeExpression) new CodeMethodInvokeExpression(referenceExpression, "AddRange", codeExpressionArray2));
          statementCollection.Add(codeStatement);
        }
        if (iGSerializerBase.ShouldClearCollection(manager, (object) iGcolCollection))
          statementCollection.Add((CodeExpression) new CodeMethodInvokeExpression(referenceExpression, "ShiftNearAndTrim", new CodeExpression[1]
          {
            (CodeExpression) new CodePrimitiveExpression((object) iGcolCollection.Count)
          }));
        return (object) statementCollection;
      }
      catch
      {
      }
      return (object) null;
    }
  }
}
