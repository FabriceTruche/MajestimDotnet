// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGHdrRowPattern
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents a nameable preset that stores all header row properties and can be applied to new or existing header rows.</summary>
  public class iGHdrRowPattern
  {
    internal iGHdrRowData fData;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGHdrRowPattern" /> class.</summary>
    public iGHdrRowPattern()
    {
      this.fData.Height = 19;
      this.fData.Visible = true;
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGHdrRowPattern" /> class with the specified height and visible property values.</summary>
    /// <param name="height">Specifies the height of the header row.</param>
    /// <param name="visible">Specifies whether the header row is visible or hidden. True if the header row is visible; False, otherwise.</param>
    public iGHdrRowPattern(int height, bool visible)
    {
      this.fData.Height = height;
      this.fData.Visible = visible;
    }

    internal iGHdrRowPattern(iGHdrRowData data)
    {
      this.fData = data;
    }

    /// <summary>Gets or sets the height of the header row.</summary>
    /// <value>The height of the header row. The default is 18.</value>
    public int Height
    {
      get
      {
        return this.fData.Height;
      }
      set
      {
        iGrid.CheckRowHeight(value);
        this.fData.Height = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether the header row is visible or not.</summary>
    /// <value>True is the header row is visible; otherwise, False. The default value is True.</value>
    public bool Visible
    {
      get
      {
        return this.fData.Visible;
      }
      set
      {
        this.fData.Visible = value;
      }
    }
  }
}
