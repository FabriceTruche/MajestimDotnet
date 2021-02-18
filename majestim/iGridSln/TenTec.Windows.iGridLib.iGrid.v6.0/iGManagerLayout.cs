// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGManagerLayout
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Xml;

namespace TenTec.Windows.iGridLib
{
  internal class iGManagerLayout
  {
    private const string cRootNodeName = "iGridLayout";
    private const string cNameNodeCol = "Col";
    private const string cNameAttrKey = "Key";
    private const string cNameAttrIndex = "Index";
    private const string cNameNodeOrder = "Order";
    private const string cNameNodeVisible = "Visible";
    private const string cNameNodeWidth = "Width";
    private const string cNameNodeGroupIndex = "GroupIndex";
    private const string cNameNodeGroupOrder = "GroupOrder";
    private const string cNameNodeSortIndex = "SortIndex";
    private const string cNameNodeSortOrder = "SortOrder";
    private const string cInvalidLayout = "Invalid layout.";

    private iGManagerLayout()
    {
    }

    public static XmlNode Get(iGrid grid, iGLayoutFlags flags)
    {
      if (grid == null)
        throw new ArgumentNullException();
      XmlDocument xmlDocument = new XmlDocument();
      XmlNode element = (XmlNode) xmlDocument.CreateElement("iGridLayout");
      xmlDocument.AppendChild(element);
      for (int index = -1; index < grid.Cols.Count; ++index)
      {
        iGCol col = grid.Cols[index];
        XmlNode parentNode;
        if ((flags & iGLayoutFlags.UseColKeys) == iGLayoutFlags.UseColKeys)
        {
          if (col.Key != null && col.Key.Length != 0)
            parentNode = iGXmlManager.AddProp(element, "Col", "Key", col.Key, (string) null);
          else
            continue;
        }
        else
          parentNode = iGXmlManager.AddProp(element, "Col", "Index", col.Index.ToString(), (string) null);
        if ((flags & iGLayoutFlags.ColOrder) == iGLayoutFlags.ColOrder)
          iGXmlManager.AddProp(parentNode, "Order", (string) null, (string) null, col.Order.ToString());
        if ((flags & iGLayoutFlags.ColVisibility) == iGLayoutFlags.ColVisibility)
          iGXmlManager.AddProp(parentNode, "Visible", (string) null, (string) null, col.Visible.ToString());
        if ((flags & iGLayoutFlags.ColWidth) == iGLayoutFlags.ColWidth)
          iGXmlManager.AddProp(parentNode, "Width", (string) null, (string) null, col.Width.ToString());
        if ((flags & iGLayoutFlags.Sorting) == iGLayoutFlags.Sorting)
        {
          iGColSortParams fParam = grid.SortObject.fParams[col.Index + 1];
          iGXmlManager.AddProp(parentNode, "SortIndex", (string) null, (string) null, fParam.SortIndex.ToString());
          iGXmlManager.AddProp(parentNode, "SortOrder", (string) null, (string) null, fParam.SortOrder.ToString());
        }
        if ((flags & iGLayoutFlags.Grouping) == iGLayoutFlags.Grouping)
        {
          iGColSortParams fParam = grid.GroupObject.fParams[col.Index + 1];
          iGXmlManager.AddProp(parentNode, "GroupIndex", (string) null, (string) null, fParam.SortIndex.ToString());
          iGXmlManager.AddProp(parentNode, "GroupOrder", (string) null, (string) null, fParam.SortOrder.ToString());
        }
      }
      return (XmlNode) xmlDocument.DocumentElement;
    }

    public static void Set(iGrid grid, XmlNode value, iGLayoutFlags flags)
    {
      if (value == null)
        return;
      try
      {
        iGManagerLayout.iGLayoutCol[] iGlayoutColArray = new iGManagerLayout.iGLayoutCol[grid.Cols.Count + 1];
        int colIndex;
        for (colIndex = -1; colIndex < grid.Cols.Count; ++colIndex)
        {
          iGCol col = grid.Cols[colIndex];
          int index = colIndex + 1;
          XmlNode parentNode = (flags & iGLayoutFlags.UseColKeys) != iGLayoutFlags.UseColKeys ? iGXmlManager.ReadProp(value, "Col", "Index", colIndex.ToString()) : (col.Key == null || col.Key.Length == 0 ? (XmlNode) null : iGXmlManager.ReadProp(value, "Col", "Key", col.Key));
          XmlNode xmlNode = (XmlNode) null;
          if ((flags & iGLayoutFlags.ColOrder) == iGLayoutFlags.ColOrder)
          {
            if (parentNode != null)
              xmlNode = iGXmlManager.ReadProp(parentNode, "Order", (string) null, (string) null);
            iGlayoutColArray[index].Order = xmlNode == null ? int.MinValue : int.Parse(xmlNode.InnerText);
          }
          if ((flags & iGLayoutFlags.ColVisibility) == iGLayoutFlags.ColVisibility)
          {
            if (parentNode != null)
              xmlNode = iGXmlManager.ReadProp(parentNode, "Visible", (string) null, (string) null);
            iGlayoutColArray[index].Visible = xmlNode == null || bool.Parse(xmlNode.InnerText);
          }
          if ((flags & iGLayoutFlags.ColWidth) == iGLayoutFlags.ColWidth)
          {
            if (parentNode != null)
              xmlNode = iGXmlManager.ReadProp(parentNode, "Width", (string) null, (string) null);
            iGlayoutColArray[index].Width = xmlNode == null ? int.MinValue : int.Parse(xmlNode.InnerText);
          }
          if ((flags & iGLayoutFlags.Sorting) == iGLayoutFlags.Sorting)
          {
            if (parentNode != null)
              xmlNode = iGXmlManager.ReadProp(parentNode, "SortIndex", (string) null, (string) null);
            iGlayoutColArray[index].SortIndex = xmlNode == null ? int.MinValue : int.Parse(xmlNode.InnerText);
            if (parentNode != null)
              xmlNode = iGXmlManager.ReadProp(parentNode, "SortOrder", (string) null, (string) null);
            iGlayoutColArray[index].SortOrder = xmlNode == null ? col.SortOrder : (iGSortOrder) Enum.Parse(typeof (iGSortOrder), xmlNode.InnerText);
          }
          if ((flags & iGLayoutFlags.Grouping) == iGLayoutFlags.Grouping)
          {
            if (parentNode != null)
              xmlNode = iGXmlManager.ReadProp(parentNode, "GroupIndex", (string) null, (string) null);
            iGlayoutColArray[index].GroupIndex = xmlNode == null ? int.MinValue : int.Parse(xmlNode.InnerText);
            if (parentNode != null)
              xmlNode = iGXmlManager.ReadProp(parentNode, "GroupOrder", (string) null, (string) null);
            iGlayoutColArray[index].GroupOrder = xmlNode == null ? col.SortOrder : (iGSortOrder) Enum.Parse(typeof (iGSortOrder), xmlNode.InnerText);
          }
        }
        grid.BeginUpdate();
        try
        {
          if ((flags & iGLayoutFlags.ColOrder) == iGLayoutFlags.ColOrder)
          {
            for (int index1 = 0; index1 < grid.Cols.Count; ++index1)
            {
              for (colIndex = 0; colIndex < grid.Cols.Count; ++colIndex)
              {
                int index2 = colIndex + 1;
                if (iGlayoutColArray[index2].Order == index1)
                  grid.Cols[colIndex].Order = index1;
              }
            }
          }
          for (colIndex = -1; colIndex < grid.Cols.Count; ++colIndex)
          {
            int index = colIndex + 1;
            if ((flags & iGLayoutFlags.ColVisibility) == iGLayoutFlags.ColVisibility)
              grid.Cols[colIndex].Visible = iGlayoutColArray[index].Visible;
            if ((flags & iGLayoutFlags.ColWidth) == iGLayoutFlags.ColWidth && iGlayoutColArray[index].Width != int.MinValue)
              grid.Cols[colIndex].Width = iGlayoutColArray[index].Width;
          }
          if ((flags & iGLayoutFlags.Grouping) != iGLayoutFlags.Grouping && (flags & iGLayoutFlags.Sorting) != iGLayoutFlags.Sorting)
            return;
          if ((flags & iGLayoutFlags.Sorting) == iGLayoutFlags.Sorting)
            grid.SortObject.Clear();
          if ((flags & iGLayoutFlags.Grouping) == iGLayoutFlags.Grouping)
            grid.GroupObject.Clear();
          for (int index1 = 0; index1 < grid.Cols.Count; ++index1)
          {
            for (colIndex = -1; colIndex < grid.Cols.Count; ++colIndex)
            {
              int index2 = colIndex + 1;
              if ((flags & iGLayoutFlags.Sorting) == iGLayoutFlags.Sorting && iGlayoutColArray[index2].SortIndex == index1)
                grid.SortObject.Add(colIndex, iGlayoutColArray[index2].SortOrder);
              if ((flags & iGLayoutFlags.Grouping) == iGLayoutFlags.Grouping && iGlayoutColArray[index2].GroupIndex == index1)
                grid.GroupObject.Add(colIndex, iGlayoutColArray[index2].GroupOrder);
            }
          }
          if ((flags & iGLayoutFlags.Grouping) == iGLayoutFlags.Grouping)
            grid.Group();
          else
            grid.Sort();
        }
        finally
        {
          grid.EndUpdate();
        }
      }
      catch (Exception ex)
      {
        throw new ArgumentException("Invalid layout.", ex);
      }
    }

    private struct iGLayoutCol
    {
      public int Order;
      public int Width;
      public int SortIndex;
      public int GroupIndex;
      public iGSortOrder SortOrder;
      public iGSortOrder GroupOrder;
      public bool Visible;
    }
  }
}
