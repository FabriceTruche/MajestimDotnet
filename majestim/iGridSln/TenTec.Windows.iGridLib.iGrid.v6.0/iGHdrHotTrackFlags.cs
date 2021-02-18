// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGHdrHotTrackFlags
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.ComponentModel;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Specifies the parts of the column header to indicate the hot state.</summary>
  [Flags]
  [TypeConverter("TenTec.Windows.iGridLib.Design.iGFlagsEnumConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
  public enum iGHdrHotTrackFlags
  {
    None = 0,
    Icon = 1,
    Text = 2,
    SortInfo = 4,
    Background = 8,
  }
}
