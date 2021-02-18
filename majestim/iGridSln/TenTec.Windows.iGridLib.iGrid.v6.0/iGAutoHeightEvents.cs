// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGAutoHeightEvents
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.ComponentModel;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Specifies events when the height of iGrid areas (such as footer, header) should be adjusted automatically.</summary>
  [Flags]
  [TypeConverter("TenTec.Windows.iGridLib.Design.iGFlagsEnumConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
  public enum iGAutoHeightEvents
  {
    None = 0,
    OnAddCol = 1,
    OnRemoveCol = 2,
    OnHideCol = 4,
    OnShowCol = 8,
    OnContentsChange = 16,
    OnThemeChange = 32,
    OnResizeCol = 64,
    OnRemoveRow = 128,
    All = OnRemoveRow | OnResizeCol | OnThemeChange | OnContentsChange | OnShowCol | OnHideCol | OnRemoveCol | OnAddCol,
  }
}
