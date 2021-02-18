// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGRowCollectionEditor
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGRowCollectionEditor : iGCollectionEditor
  {
    private ArrayList fRowCollectionDesignWrapper;
    private CollectionEditor.CollectionForm fDialog;
    private iGrid Grid;

    public iGRowCollectionEditor()
      : base(typeof (ArrayList))
    {
    }

    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
    {
      if (context != null && context.Instance != null)
        return UITypeEditorEditStyle.Modal;
      return base.GetEditStyle(context);
    }

    public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
    {
      iGRowCollection iGrowCollection = value as iGRowCollection;
      if (iGrowCollection == null)
        return base.EditValue(context, provider, value);
      this.Grid = iGrowCollection.Grid;
      this.fRowCollectionDesignWrapper = new ArrayList(iGrowCollection.Count);
      for (int rowIndex = 0; rowIndex < iGrowCollection.Count; ++rowIndex)
        this.fRowCollectionDesignWrapper.Add((object) new iGRowDesign(this.Grid, iGrowCollection[rowIndex].Pattern, rowIndex, this.fRowCollectionDesignWrapper));
      DesignerTransaction designerTransaction = (DesignerTransaction) null;
      IComponentChangeService service1 = (IComponentChangeService) provider.GetService(typeof (IComponentChangeService));
      try
      {
        IDesignerHost service2 = (IDesignerHost) provider.GetService(typeof (IDesignerHost));
        if (service2 != null)
          designerTransaction = service2.CreateTransaction("Rows");
        if (service1 != null)
          service1.OnComponentChanging(context.Instance, (MemberDescriptor) context.PropertyDescriptor);
      }
      catch (CheckoutException ex)
      {
        if (ex == CheckoutException.Canceled)
          return value;
        throw ex;
      }
      base.EditValue(context, provider, (object) this.fRowCollectionDesignWrapper);
      this.ApplyChanges();
      if (provider != null)
        iGInternalInfrastructure.ClearNonUsedDesignCellStyles((IReferenceService) provider.GetService(typeof (IReferenceService)));
      if (service1 != null)
        service1.OnComponentChanged(context.Instance, (MemberDescriptor) context.PropertyDescriptor, (object) null, (object) null);
      if (designerTransaction != null)
      {
        if (this.fDialog != null && this.fDialog.DialogResult != DialogResult.OK)
          designerTransaction.Cancel();
        else
          designerTransaction.Commit();
      }
      return value;
    }

    protected override Type CreateCollectionItemType()
    {
      return typeof (iGRow);
    }

    protected override object CreateInstance(Type itemType)
    {
      if (this.Context != null)
      {
        iGrid instance = this.Context.Instance as iGrid;
        if (instance != null)
          return (object) new iGRowDesign(instance, this.fRowCollectionDesignWrapper);
      }
      return base.CreateInstance(itemType);
    }

    protected override CollectionEditor.CollectionForm CreateCollectionForm()
    {
      this.fDialog = base.CreateCollectionForm();
      return this.fDialog;
    }

    protected override void ApplyButton_Click(object sender, EventArgs e)
    {
      this.ApplyChanges();
    }

    protected virtual void ApplyChanges()
    {
      this.Grid.BeginUpdate();
      try
      {
        this.Grid.Rows.Count=(0);
        this.Grid.Rows.Count=(this.fRowCollectionDesignWrapper.Count);
        if (this.fRowCollectionDesignWrapper.Count <= 0)
          return;
        for (int index1 = 0; index1 < this.fRowCollectionDesignWrapper.Count; ++index1)
        {
          try
          {
            iGRowDesign iGrowDesign = this.fRowCollectionDesignWrapper[index1] as iGRowDesign;
            if (iGrowDesign != null)
            {
              this.Grid.Rows[index1].Pattern=(iGrowDesign.fPattern);
              for (int index2 = 0; index2 < iGrowDesign.fNormalCells.Length; ++index2)
              {
                this.Grid.Cells[index1, index2].Pattern=(iGrowDesign.fNormalCells[index2]);
                this.Grid.Cells[index1, index2].Value=(iGrowDesign.fNormalCells[index2].Value);
              }
              this.Grid.Rows[index1].RowTextCell.Pattern=(iGrowDesign.fRowTextCell);
              this.Grid.Rows[index1].RowTextCell.Value=(iGrowDesign.fRowTextCell.Value);
            }
          }
          catch (Exception ex)
          {
          }
        }
      }
      finally
      {
        this.Grid.EndUpdate();
      }
    }

    protected override bool SupportsApply
    {
      get
      {
        return true;
      }
    }
  }
}
