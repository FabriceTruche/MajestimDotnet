// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGHierarchicalRowNavigatorComparer
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.Collections.Generic;

namespace TenTec.Windows.iGridLib
{
  internal class iGHierarchicalRowNavigatorComparer : IComparer<iGHierarchicalRowNavigator>
  {
    private readonly iGRowNavigatorMapComparer fRowNavigatorMapComparer;

    public iGHierarchicalRowNavigatorComparer(iGRowNavigatorMapComparer rowNavigatorMapComparer)
    {
      this.fRowNavigatorMapComparer = rowNavigatorMapComparer;
    }

    public int Compare(iGHierarchicalRowNavigator x, iGHierarchicalRowNavigator y)
    {
      return this.fRowNavigatorMapComparer.Compare(x.RowNavigatorMap, y.RowNavigatorMap);
    }
  }
}
