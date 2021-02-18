// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGLayout
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.ComponentModel;
using System.Xml;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents the properties that allow you to save and restore <see cref="T:TenTec.Windows.iGridLib.iGrid" />'s columns layout, sort, and group data.</summary>
  public class iGLayout
  {
    private iGLayoutFlags fFlags = iGLayoutFlags.ColVisibility | iGLayoutFlags.ColWidth | iGLayoutFlags.ColOrder;
    private const iGLayoutFlags cDefaultFlags = iGLayoutFlags.ColVisibility | iGLayoutFlags.ColWidth | iGLayoutFlags.ColOrder;
    private iGrid fGrid;

    /// <summary>Returns the <see cref="T:TenTec.Windows.iGridLib.iGrid" /> object this instance belongs to.</summary>
    /// <value>Returns the <see cref="T:TenTec.Windows.iGridLib.iGrid" /> object this instance belongs to.</value>
    [Browsable(false)]
    public iGrid Grid
    {
      get
      {
        return this.fGrid;
      }
    }

    internal iGLayout(iGrid grid)
    {
      if (grid == null)
        throw new ArgumentNullException();
      this.fGrid = grid;
    }

    /// <summary>Gets or sets a value which indicates which of the layout data to save and restore.</summary>
    /// <value>A set of the <see cref="T:TenTec.Windows.iGridLib.iGLayoutFlags" /> enumeration values. The default is <see cref="F:TenTec.Windows.iGridLib.iGLayoutFlags.ColVisibility" />, <see cref="F:TenTec.Windows.iGridLib.iGLayoutFlags.ColWidth" />, <see cref="F:TenTec.Windows.iGridLib.iGLayoutFlags.ColOrder" />.</value>
    [DefaultValue(iGLayoutFlags.ColVisibility | iGLayoutFlags.ColWidth | iGLayoutFlags.ColOrder)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGFlagsEnumConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Description("A value indicating what information to save and restore using the LayoutString property.")]
    public iGLayoutFlags Flags
    {
      get
      {
        return this.fFlags;
      }
      set
      {
        if (value == (iGLayoutFlags) 0)
          throw new ArgumentException();
        this.fFlags = value;
      }
    }

    /// <summary>Gets or sets a string which represents the layout information in the xml format. The layout root node's name is iGridLayout.</summary>
    /// <value>The string which represents the grid's layout.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public string Text
    {
      get
      {
        return iGManagerLayout.Get(this.fGrid, this.fFlags).OuterXml;
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException();
        try
        {
          XmlDocument xmlDocument = new XmlDocument();
          xmlDocument.LoadXml(value);
          iGManagerLayout.Set(this.fGrid, (XmlNode) xmlDocument.DocumentElement, this.fFlags);
        }
        catch (Exception ex)
        {
          throw new FormatException();
        }
      }
    }
  }
}
