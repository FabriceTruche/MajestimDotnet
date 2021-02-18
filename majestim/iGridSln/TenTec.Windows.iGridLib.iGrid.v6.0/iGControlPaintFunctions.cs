// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGControlPaintFunctions
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Specifies the drawing of what items is redefined in an object that implements the <see cref="T:TenTec.Windows.iGridLib.IiGControlPaint" /> interface.</summary>
  [Flags]
  public enum iGControlPaintFunctions
  {
    None = 0,
    All = 65535,
    ScrollBar = 1,
    ScrollBarCustomButton = 2,
    CheckBox = 4,
    ComboButton = 8,
    EllipsisButton = 16,
    TreeButton = 32,
    Header = 64,
    RowHdr = 128,
    SizeBox = 256,
    GroupBoxBackground = 512,
    ControlsColors = 1024,
  }
}
