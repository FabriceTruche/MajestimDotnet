// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGRowDesignConverter
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.ComponentModel;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGRowDesignConverter : TypeConverter
  {
    public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
    {
      if (value != null)
      {
        iGRowDesign iGrowDesign = value as iGRowDesign;
        if (iGrowDesign != null)
        {
          int length = iGrowDesign.fNormalCells.Length;
          PropertyDescriptorCollection properties1 = TypeDescriptor.GetProperties(typeof (iGRowDesign), attributes);
          PropertyDescriptor[] properties2 = new PropertyDescriptor[properties1.Count + length + 1];
          if (length > 0)
          {
            int totalWidth = (int) Math.Truncate(Math.Log10((double) length)) + 1;
            for (int index = 0; index < length; ++index)
            {
              string description = string.Format("The cell from column {0}.", (object) index);
              properties2[index] = (PropertyDescriptor) new iGRowDesignConverter.iGCustomCellDescriptor(index, "Cell(" + index.ToString().PadLeft(totalWidth, '0') + ")", new Attribute[4]
              {
                (Attribute) new CategoryAttribute("[Cells]"),
                (Attribute) new DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content),
                (Attribute) new TypeConverterAttribute(typeof (iGExpandableTypeConverter)),
                (Attribute) new DescriptionAttribute(description)
              });
            }
          }
          properties2[length] = (PropertyDescriptor) new iGRowDesignConverter.iGCustomCellDescriptor(iGrowDesign.fGrid.RowTextCol.Index, "Cell(" + "RowText" + ")", new Attribute[4]
          {
            (Attribute) new CategoryAttribute("[Cells]"),
            (Attribute) new DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content),
            (Attribute) new TypeConverterAttribute(typeof (iGExpandableTypeConverter)),
            (Attribute) new DescriptionAttribute("The row text cell. The row text cells are displayed in group rows and under the normal cells in normal rows.")
          });
          properties1.CopyTo((Array) properties2, length + 1);
          return new PropertyDescriptorCollection(properties2);
        }
      }
      return base.GetProperties(context, value, attributes);
    }

    public override bool GetPropertiesSupported(ITypeDescriptorContext context)
    {
      return true;
    }

    protected class iGCustomCellDescriptor : TypeConverter.SimplePropertyDescriptor
    {
      private int fIndex;

      public iGCustomCellDescriptor(int index, string name, Attribute[] attributes)
        : base(typeof (iGRow), name, typeof (iGCellDesign), attributes)
      {
        this.fIndex = index;
      }

      public override object GetValue(object component)
      {
        return (object) new iGCellDesign(component as iGRowDesign, this.fIndex);
      }

      public override void SetValue(object component, object value)
      {
      }

      public override bool ShouldSerializeValue(object component)
      {
        return iGInternalInfrastructure.iGSerializeManager.ShouldSerialize((object) (iGCellDesign) this.GetValue(component));
      }

      public override bool IsReadOnly
      {
        get
        {
          return true;
        }
      }
    }
  }
}
