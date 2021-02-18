// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGClippedCellParts
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Specifies which cell parts should be checked in the <see cref="M:TenTec.Windows.iGridLib.iGCell.IsCellPartClipped(TenTec.Windows.iGridLib.iGClippedCellParts,System.Boolean)" /> method.</summary>
  [Flags]
  public enum iGClippedCellParts
  {
    None = 0,
    Image = 1,
    Text = 2,
    CheckBox = 4,
    All = 65535,
  }
}
