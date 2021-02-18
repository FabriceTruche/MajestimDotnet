// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.ResourceLoader
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System.IO;
using System.Reflection;

namespace TenTec.Windows.iGridLib.Design
{
  internal class ResourceLoader
  {
    public static Stream GetResourceStream(string resourceName)
    {
      return Assembly.GetExecutingAssembly().GetManifestResourceStream("TenTec.Windows.iGridLib.Design.Resources." + resourceName);
    }
  }
}
