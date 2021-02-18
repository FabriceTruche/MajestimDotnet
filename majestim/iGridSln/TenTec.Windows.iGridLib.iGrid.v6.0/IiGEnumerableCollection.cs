// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.IiGEnumerableCollection
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

namespace TenTec.Windows.iGridLib
{
  /// <summary>Contains the definition of common members used in iGrid's collections. This interface is intended to support the internal infrastructure and should not be used directly from your code.</summary>
  public interface IiGEnumerableCollection
  {
    /// <summary>When implemented in a class, returns the collection item by its numeric index.</summary>
    /// <param name="index">The index of the collection item.</param>
    /// <value>The collection item with the specified index.</value>
    object this[int index] { get; }

    /// <summary>When implemented in a class, returns the total number of collection items.</summary>
    /// <value>The number of items in the collection.</value>
    int Count { get; }
  }
}
