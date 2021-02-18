// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGRowNavigatorMapItem
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

namespace TenTec.Windows.iGridLib
{
  internal struct iGRowNavigatorMapItem
  {
    public iGRowNavigator Navigator;
    public int InitialRowIndex;

    public static unsafe void SetRowNavigatorArray(iGRowNavigatorMapItem[] value, iGRowNavigator[] navigatorArray, int index)
    {
      fixed (iGRowNavigator* iGrowNavigatorPtr = &navigatorArray[index])
        fixed (iGRowNavigatorMapItem* navigatorMapItemPtr = &value[0])
        {
          for (int index1 = value.Length - 1; index1 >= 0; --index1)
            iGrowNavigatorPtr[index1] = navigatorMapItemPtr[index1].Navigator;
        }
    }

    public static unsafe iGRowNavigatorMapItem[] FromRowNavigatorArray(iGRowNavigator[] value, int index, int count)
    {
      iGRowNavigatorMapItem[] navigatorMapItemArray = new iGRowNavigatorMapItem[count];
      fixed (iGRowNavigatorMapItem* navigatorMapItemPtr = &navigatorMapItemArray[0])
        fixed (iGRowNavigator* iGrowNavigatorPtr = &value[index])
        {
          for (int index1 = count - 1; index1 >= 0; --index1)
          {
            navigatorMapItemPtr[index1].Navigator = iGrowNavigatorPtr[index1];
            navigatorMapItemPtr[index1].InitialRowIndex = index1 + index;
          }
        }
      return navigatorMapItemArray;
    }
  }
}
