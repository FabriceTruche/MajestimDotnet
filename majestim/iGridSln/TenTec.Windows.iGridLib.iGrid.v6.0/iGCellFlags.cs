// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCellFlags
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.ComponentModel;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Specifies some options of the cell.</summary>
  [Flags]
  [TypeConverter("TenTec.Windows.iGridLib.Design.iGFlagsEnumWithNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
  public enum iGCellFlags
  {
    None = 0,
    NotSet = 1,
    DisplayText = 2,
    DisplayImage = 4,
  }
}
