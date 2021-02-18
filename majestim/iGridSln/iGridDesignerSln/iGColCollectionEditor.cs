// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGColCollectionEditor
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
  internal class iGColCollectionEditor : iGCollectionEditor
  {
    private ArrayList fWrapper;
    private CollectionEditor.CollectionForm fDialog;
    private iGrid fGrid;

    public iGColCollectionEditor()
      : base(typeof (ArrayList))
    {
    }

    internal static iGCellPattern CreateNewCellForColumn(iGColPattern col)
    {
      iGCellPattern iGcellPattern = new iGCellPattern();
      object defaultCellValue = col.DefaultCellValue;
      iGcellPattern.Value=(defaultCellValue);
      int defaultCellImageIndex = col.DefaultCellImageIndex;
      iGcellPattern.ImageIndex=(defaultCellImageIndex);
      object defaultCellAuxValue = col.DefaultCellAuxValue;
      iGcellPattern.AuxValue=(defaultCellAuxValue);
      return iGcellPattern;
    }

    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
    {
      if (context != null && context.Instance != null)
        return UITypeEditorEditStyle.Modal;
      return base.GetEditStyle(context);
    }

    public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
    {
      iGColCollection iGcolCollection = value as iGColCollection;
      if (iGcolCollection == null)
        return base.EditValue(context, provider, value);
      this.fGrid = iGcolCollection.Grid;
      this.fWrapper = new ArrayList(iGcolCollection.Count);
      for (int colIndex = 0; colIndex < iGcolCollection.Count; ++colIndex)
      {
        bool isTreeCol = false;
        if (this.fGrid.TreeCol != null)
          isTreeCol = this.fGrid.TreeCol.Index == colIndex;
        bool isSearchCol = false;
        if (this.fGrid.SearchAsType.SearchCol != null)
          isSearchCol = this.fGrid.SearchAsType.SearchCol.Index == colIndex;
        this.fWrapper.Add((object) new iGColDesign(this.fGrid, iGcolCollection[colIndex].Pattern, colIndex, isTreeCol, isSearchCol, this.fWrapper));
      }
      DesignerTransaction designerTransaction = (DesignerTransaction) null;
      IComponentChangeService service1 = (IComponentChangeService) provider.GetService(typeof (IComponentChangeService));
      try
      {
        IDesignerHost service2 = (IDesignerHost) provider.GetService(typeof (IDesignerHost));
        if (service2 != null)
          designerTransaction = service2.CreateTransaction("Cols");
        if (service1 != null)
        {
          service1.OnComponentChanging(context.Instance, (MemberDescriptor) context.PropertyDescriptor);
          service1.OnComponentChanging(context.Instance, (MemberDescriptor) TypeDescriptor.GetProperties(context.Instance)["Rows"]);
        }
      }
      catch (CheckoutException ex)
      {
        if (ex == CheckoutException.Canceled)
          return value;
        throw ex;
      }
      base.EditValue(context, provider, (object) this.fWrapper);
      this.ApplyChanges();
      if (provider != null)
      {
        IReferenceService service2 = (IReferenceService) provider.GetService(typeof (IReferenceService));
        iGInternalInfrastructure.ClearNonUsedDesignCellStyles(service2);
        iGInternalInfrastructure.ClearNonUsedDesignColHdrStyles(service2);
      }
      if (service1 != null)
      {
        service1.OnComponentChanged(context.Instance, (MemberDescriptor) context.PropertyDescriptor, (object) null, (object) null);
        service1.OnComponentChanged(context.Instance, (MemberDescriptor) TypeDescriptor.GetProperties(context.Instance)["Rows"], (object) null, (object) null);
      }
      if (designerTransaction != null)
      {
        if (this.fDialog != null && this.fDialog.DialogResult != DialogResult.OK)
          designerTransaction.Cancel();
        else
          designerTransaction.Commit();
      }
      this.fWrapper = (ArrayList) null;
      return value;
    }

    protected override Type CreateCollectionItemType()
    {
      return typeof (iGColDesign);
    }

    protected override object CreateInstance(Type itemType)
    {
      if (this.Context != null)
      {
        iGrid instance = this.Context.Instance as iGrid;
        if (instance != null)
          return (object) new iGColDesign(instance, this.fWrapper);
      }
      return base.CreateInstance(itemType);
    }

    protected override object SetItems(object editValue, object[] value)
    {
      return base.SetItems(editValue, value);
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
      iGCellPattern[,] iGcellPatternArray = new iGCellPattern[this.fGrid.Rows.Count, this.fGrid.Cols.Count];
      for (int index1 = 0; index1 < this.fGrid.Rows.Count; ++index1)
      {
        for (int index2 = 0; index2 < this.fGrid.Cols.Count; ++index2)
          iGcellPatternArray[index1, index2] = this.fGrid.Cells[index1, index2].Pattern;
      }
      this.fGrid.BeginUpdate();
      try
      {
        this.fGrid.Cols.Count=(0);
        this.fGrid.Cols.Count=(this.fWrapper.Count);
        for (int index1 = 0; index1 < this.fWrapper.Count; ++index1)
        {
          iGColDesign iGcolDesign = this.fWrapper[index1] as iGColDesign;
          this.fGrid.Cols[index1].Pattern=(iGcolDesign.fPattern);
          if (iGcolDesign.fColIndex >= 0)
          {
            for (int index2 = 0; index2 < this.fGrid.Rows.Count; ++index2)
              this.fGrid.Cells[index2, index1].Pattern=(iGcellPatternArray[index2, iGcolDesign.fColIndex]);
          }
          else
          {
            for (int index2 = 0; index2 < this.fGrid.Rows.Count; ++index2)
              this.fGrid.Cells[index2, index1].Pattern=(iGColCollectionEditor.CreateNewCellForColumn(iGcolDesign.fPattern));
          }
          iGcolDesign.fColIndex = index1;
          if (iGcolDesign.fIsTreeCol)
            this.fGrid.TreeCol=(this.fGrid.Cols[index1]);
          if (iGcolDesign.fIsSearchCol)
            this.fGrid.SearchAsType.SearchCol=(this.fGrid.Cols[index1]);
        }
      }
      finally
      {
        this.fGrid.EndUpdate();
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
