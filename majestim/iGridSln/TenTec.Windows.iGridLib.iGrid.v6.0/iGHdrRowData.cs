﻿// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGHdrRowData
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

namespace TenTec.Windows.iGridLib
{
  internal struct iGHdrRowData
  {
    internal const int cDefaultHeight = 19;
    internal const bool cDefaultVisible = true;
    public int Height;
    public bool Visible;

    public iGHdrRowData(int height, bool visible)
    {
      this.Height = height;
      this.Visible = visible;
    }
  }
}
