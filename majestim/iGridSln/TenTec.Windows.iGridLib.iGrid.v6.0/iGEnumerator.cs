// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGEnumerator
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.Collections;

namespace TenTec.Windows.iGridLib
{
  internal class iGEnumerator : IEnumerator
  {
    private int fIndex = -1;
    private IiGEnumerableCollection fCollection;

    public iGEnumerator(IiGEnumerableCollection collection)
    {
      this.fCollection = collection;
    }

    public void Reset()
    {
      this.fIndex = -1;
    }

    public bool MoveNext()
    {
      if (this.fIndex >= this.fCollection.Count - 1)
        return false;
      this.fIndex = this.fIndex + 1;
      return true;
    }

    public object Current
    {
      get
      {
        if (this.fIndex < 0 || this.fIndex >= this.fCollection.Count)
          return (object) null;
        return this.fCollection[this.fIndex];
      }
    }
  }
}
