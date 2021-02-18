// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGManagerCompare
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>A service class that implements the algorithm used by iGrid to compare two cell values.</summary>
  public class iGManagerCompare
  {
    private iGManagerCompare()
    {
    }

    /// <summary>Implements the algorithm used by iGrid to compare two cell values while sorting and grouping.</summary>
    /// <param name="valueX">Specifies the first value to compare.</param>
    /// <param name="valueY">Specifies the second value to compare.</param>
    /// <returns>An integer indicating the result of comparison.
    /// <list type="table">
    ///   <listheader>
    ///     <term>Value</term>
    ///     <description>Condition</description>
    ///   </listheader>
    ///   <item>
    ///     <term>
    ///       Less than zero
    ///     </term>
    ///     <description>
    ///       <paramref name="valueX" /> is "less" than <paramref name="valueY" />.
    ///     </description>
    ///   </item>
    ///   <item>
    ///     <term>
    ///       Zero
    ///     </term>
    ///     <description>
    ///       <paramref name="valueX" /> and <paramref name="valueY" /> are equal.
    ///     </description>
    ///   </item>
    ///   <item>
    ///     <term>
    ///       Greater than zero
    ///     </term>
    ///     <description>
    ///       <paramref name="valueX" /> is "greater" than <paramref name="valueY" />.
    ///     </description>
    ///   </item>
    /// </list></returns>
    public static int CompareObjects(object valueX, object valueY)
    {
      IComparable comparable1 = valueX as IComparable;
      IComparable comparable2 = valueY as IComparable;
      if (comparable1 == null)
        return comparable2 == null ? 0 : -1;
      if (comparable2 == null)
        return 1;
      Type type1 = comparable1.GetType();
      Type type2 = comparable2.GetType();
      if (type1 != type2)
        return string.CompareOrdinal(type1.Name, type2.Name);
      return comparable1.CompareTo((object) comparable2);
    }
  }
}
