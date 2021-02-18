// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGDropDownListItemCollectionEditor
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGDropDownListItemCollectionEditor : CollectionEditor
  {
    private const string cNewValuePrefex = "Value";
    private iGDropDownList.iGDropDownListItemCollection fCollection;

    public iGDropDownListItemCollectionEditor()
      : base(typeof (iGDropDownList.iGDropDownListItemCollection))
    {
    }

    public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
    {
      this.fCollection = value as iGDropDownList.iGDropDownListItemCollection;
      return base.EditValue(context, provider, value);
    }

    protected override CollectionEditor.CollectionForm CreateCollectionForm()
    {
      CollectionEditor.CollectionForm collectionForm = base.CreateCollectionForm();
      for (int index = collectionForm.Controls.Count - 1; index >= 0; --index)
      {
        PropertyGrid control = collectionForm.Controls[index] as PropertyGrid;
        if (control != null)
        {
          control.CommandsVisibleIfAvailable = true;
          control.HelpVisible = true;
          control.PropertySort = PropertySort.Alphabetical;
        }
      }
      return collectionForm;
    }

    protected override string GetDisplayText(object value)
    {
      string str = base.GetDisplayText(value);
      iGDropDownListItem gdropDownListItem = value as iGDropDownListItem;
      if (gdropDownListItem != null && (gdropDownListItem.Value != null || gdropDownListItem.Text != null))
        str = string.Format("({0})({1})", gdropDownListItem.Value, (object) gdropDownListItem.Text);
      return str;
    }

    protected override Type CreateCollectionItemType()
    {
      return typeof (iGDropDownListItem);
    }

    protected override object CreateInstance(Type itemType)
    {
      if (itemType == typeof (iGDropDownListItem))
        return (object) new iGDropDownListItem((object) this.GenerateNewValue());
      return base.CreateInstance(itemType);
    }

    public string GenerateNewValue()
    {
      int num = 1;
      string str;
      while (true)
      {
        bool flag = false;
        str = "Value" + num.ToString();
        foreach (iGDropDownListItem f in (IEnumerable) this.fCollection)
        {
          if (f.Value != null && f.Value.ToString() == str)
          {
            flag = true;
            break;
          }
        }
        if (flag)
          ++num;
        else
          break;
      }
      return str;
    }
  }
}
