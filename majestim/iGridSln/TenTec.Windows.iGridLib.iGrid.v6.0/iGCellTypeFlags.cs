// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCellTypeFlags
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.ComponentModel;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Specifies the additional flags used to modify some aspects of a cell type.</summary>
  [Flags]
  [TypeConverter("TenTec.Windows.iGridLib.Design.iGFlagsEnumWithNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
  public enum iGCellTypeFlags
  {
    None = 0,
    NotSet = 1,
    CheckThreeState = 2,
    NoTextEdit = 4,
    ComboPreferValue = 8,
    HasEllipsisButton = 16,
    HideComboButton = 32,
    MultilineEdit = 64,
    Password = 128,
  }
}
