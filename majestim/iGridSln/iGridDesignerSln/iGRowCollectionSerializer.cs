// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGRowCollectionSerializer
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.CodeDom;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGRowCollectionSerializer : iGSerializerBase
  {
    public override object Deserialize(IDesignerSerializationManager manager, object codeObject)
    {
      return (object) null;
    }

    public override object Serialize(IDesignerSerializationManager manager, object value)
    {
      try
      {
        iGRowCollection iGrowCollection = value as iGRowCollection;
        if (iGrowCollection == null)
          return (object) null;
        CodeExpression referenceExpression = (CodeExpression) iGSerializerBase.GetPropertyReferenceExpression(manager);
        if (referenceExpression == null)
          return (object) null;
        CodeStatementCollection statementCollection = new CodeStatementCollection();
        iGrid grid = iGrowCollection.Grid;
        CodeExpressionStatement expressionStatement = (CodeExpressionStatement) null;
        if (iGrowCollection.Count > 0)
        {
          CodeExpression[] codeExpressionArray1 = new CodeExpression[iGrowCollection.Count];
          for (int index = 0; index < iGrowCollection.Count; ++index)
            codeExpressionArray1[index] = this.SerializeToExpression(manager, (object) iGrowCollection[index].Pattern);
          CodeExpression[] codeExpressionArray2 = new CodeExpression[iGrowCollection.Count * (grid.Cols.Count + 1)];
          for (int index1 = 0; index1 < iGrowCollection.Count; ++index1)
          {
            codeExpressionArray2[index1 * (grid.Cols.Count + 1)] = this.SerializeToExpression(manager, (object) grid.RowTextCol.Cells[index1].Pattern);
            for (int index2 = 0; index2 < grid.Cols.Count; ++index2)
            {
              iGCellPattern pattern = grid.Cells[index1, index2].Pattern;
              iGRowCollectionSerializer.AdjustCellStyle(pattern);
              codeExpressionArray2[index1 * (grid.Cols.Count + 1) + index2 + 1] = this.SerializeToExpression(manager, (object) pattern);
            }
          }
          expressionStatement = new CodeExpressionStatement((CodeExpression) new CodeMethodInvokeExpression(referenceExpression, "AddRange", new CodeExpression[2]
          {
            (CodeExpression) new CodeArrayCreateExpression(typeof (iGRowPattern), codeExpressionArray1),
            (CodeExpression) new CodeArrayCreateExpression(typeof (iGCellPattern), codeExpressionArray2)
          }));
        }
        if (iGSerializerBase.ShouldClearCollection(manager, (object) iGrowCollection))
          statementCollection.Add((CodeExpression) new CodeMethodInvokeExpression(referenceExpression, "Clear", new CodeExpression[0]));
        if (expressionStatement != null)
          statementCollection.Add((CodeStatement) expressionStatement);
        return (object) statementCollection;
      }
      catch (Exception ex)
      {
      }
      return (object) null;
    }

    private static void AdjustCellStyle(iGCellPattern cell)
    {
      if (cell.Style == null || ((Component) cell.Style).Container != null)
        return;
      cell.Style=((iGCellStyle) null);
    }
  }
}
