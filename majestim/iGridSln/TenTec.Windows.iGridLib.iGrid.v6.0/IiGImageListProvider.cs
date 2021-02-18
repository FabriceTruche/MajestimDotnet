// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.IiGImageListProvider
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  /// <summary>This interface is intended to support the internal infrastructure and should not be used directly from your code.</summary>
  public interface IiGImageListProvider
  {
    /// <summary>When implemented in a class, returns an instance of the <see cref="T:System.Windows.Forms.ImageList" /> class which implements the image list functionality.</summary>
    /// <param name="propertyName">The requested property name.</param>
    /// <returns>A <see cref="T:System.Windows.Forms.ImageList" /> object.</returns>
    ImageList GetImageList(string propertyName);
  }
}
