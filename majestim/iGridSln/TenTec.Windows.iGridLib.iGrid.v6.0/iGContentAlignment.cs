// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGContentAlignment
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.ComponentModel;
using System.Drawing.Design;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Specifies how to align a content of a cell or column header in an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  [Editor("TenTec.Windows.iGridLib.Design.iGContentAlignmentEditor, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0", typeof (UITypeEditor))]
  public enum iGContentAlignment
  {
    NotSet = 0,
    TopLeft = 1,
    TopCenter = 2,
    TopRight = 4,
    MiddleLeft = 16,
    MiddleCenter = 32,
    MiddleRight = 64,
    BottomLeft = 256,
    BottomCenter = 512,
    BottomRight = 1024,
  }
}
