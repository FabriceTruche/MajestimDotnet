// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGColorManager
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  internal class iGColorManager
  {
    private static void AdjustColorPart(ref int aColorPart)
    {
      if (aColorPart > (int) byte.MaxValue)
      {
        aColorPart = (int) byte.MaxValue;
      }
      else
      {
        if (aColorPart >= 0)
          return;
        aColorPart = 0;
      }
    }

    public static Color Lighten(Color color, int value)
    {
      int aColorPart1 = (int) color.R + value;
      int aColorPart2 = (int) color.G + value;
      int aColorPart3 = (int) color.B + value;
      iGColorManager.AdjustColorPart(ref aColorPart1);
      iGColorManager.AdjustColorPart(ref aColorPart2);
      iGColorManager.AdjustColorPart(ref aColorPart3);
      return Color.FromArgb((int) color.A, aColorPart1, aColorPart2, aColorPart3);
    }

    public static Color GetColorControlDark(Color colorControl)
    {
      if (colorControl == SystemColors.Control)
        return SystemColors.ControlDark;
      if (colorControl == SystemColors.ControlDark)
        return SystemColors.ControlDarkDark;
      return iGColorManager.Lighten(colorControl, -40);
    }

    public static Color GetColorControlDarkDark(Color colorControl)
    {
      if (colorControl == SystemColors.Control)
        return SystemColors.ControlDarkDark;
      return iGColorManager.Lighten(colorControl, -80);
    }

    public static Color GetColorControlLight(Color colorControl)
    {
      if (colorControl == SystemColors.Control)
        return SystemColors.ControlLight;
      return iGColorManager.Lighten(colorControl, 30);
    }

    public static Color GetColorControlLightLight(Color colorControl)
    {
      if (colorControl == SystemColors.Control)
        return SystemColors.ControlLightLight;
      return iGColorManager.Lighten(colorControl, 60);
    }
  }
}
