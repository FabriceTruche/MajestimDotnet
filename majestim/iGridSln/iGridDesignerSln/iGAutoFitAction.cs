// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGAutoFitAction
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib.Design
{
  [Flags]
  internal enum iGAutoFitAction
  {
    AutoWidthCols = 1,
    AutoHeightRows = 2,
    AutoHeightHeader = 4,
    All = AutoHeightHeader | AutoHeightRows | AutoWidthCols,
  }
}
