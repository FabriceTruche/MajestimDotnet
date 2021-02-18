// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGXmlManager
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Xml;

namespace TenTec.Windows.iGridLib
{
  internal class iGXmlManager
  {
    private iGXmlManager()
    {
    }

    private static void CheckParameters(XmlNode parentNode, string name, string nameKeyAttr, string valueKeyAttr)
    {
      if (parentNode == null || name == null)
        throw new ArgumentNullException();
      if (name.Length == 0 || nameKeyAttr != null && (nameKeyAttr.Length == 0 || valueKeyAttr == null || valueKeyAttr.Length == 0))
        throw new ArgumentException();
    }

    public static XmlNode AddProp(XmlNode parentNode, string name, string nameKeyAttr, string valueKeyAttr, string value)
    {
      iGXmlManager.CheckParameters(parentNode, name, nameKeyAttr, valueKeyAttr);
      XmlDocument ownerDocument = parentNode.OwnerDocument;
      XmlNode element = (XmlNode) ownerDocument.CreateElement(name);
      parentNode.AppendChild(element);
      if (nameKeyAttr != null)
      {
        XmlAttribute attribute = ownerDocument.CreateAttribute(nameKeyAttr);
        attribute.Value = valueKeyAttr;
        element.Attributes.Append(attribute);
      }
      if (value != null)
        element.InnerText = value;
      return element;
    }

    public static XmlNode ReadProp(XmlNode parentNode, string name, string nameKeyAttr, string valueKeyAttr)
    {
      iGXmlManager.CheckParameters(parentNode, name, nameKeyAttr, valueKeyAttr);
      if (nameKeyAttr != null)
        return parentNode.SelectSingleNode(string.Format("{0}[@{1}='{2}']", (object) name, (object) nameKeyAttr, (object) valueKeyAttr));
      return parentNode.SelectSingleNode(name);
    }
  }
}
