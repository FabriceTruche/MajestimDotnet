// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGStringFormatFlags
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.ComponentModel;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Specifies display and layout information for a cell or column header text.</summary>
  [Flags]
  [TypeConverter("TenTec.Windows.iGridLib.Design.iGFlagsEnumWithNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
  public enum iGStringFormatFlags
  {
    NotSet = 32768,
    None = 0,
    DirectionRightToLeft = 1,
    DirectionVertical = 2,
    FitBlackBox = 4,
    DisplayFormatControl = 32,
    NoFontFallback = 1024,
    MeasureTrailingSpaces = 2048,
    WordWrap = 4096,
    LineLimit = 8192,
    Rotate180 = 65536,
  }
}
