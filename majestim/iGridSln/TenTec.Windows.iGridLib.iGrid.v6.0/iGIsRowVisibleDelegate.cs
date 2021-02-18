// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGIsRowVisibleDelegate
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

namespace TenTec.Windows.iGridLib
{
  /// <summary>This delegate is used by the PrintManager add-on in the <see cref="M:TenTec.Windows.iGridLib.iGInternalInfrastructure.FillTreeBranchData(TenTec.Windows.iGridLib.iGrid,System.Collections.Generic.List{TenTec.Windows.iGridLib.iGTreeBranchState},System.Int32,System.Boolean,TenTec.Windows.iGridLib.iGIsRowVisibleDelegate)" /> method. This member is intended to support the internal infrastructure and should not be used directly from your code.</summary>
  /// <param name="rowIndex">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
  public delegate bool iGIsRowVisibleDelegate(int rowIndex);
}
