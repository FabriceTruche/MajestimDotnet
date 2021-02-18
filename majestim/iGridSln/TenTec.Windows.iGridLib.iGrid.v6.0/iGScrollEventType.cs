// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGScrollEventType
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

namespace TenTec.Windows.iGridLib
{
  /// <summary>Specifies the type of action used to raise the <see cref="E:TenTec.Windows.iGridLib.iGrid.VScrollBarScroll" /> and <see cref="E:TenTec.Windows.iGridLib.iGrid.HScrollBarScroll" /> events of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public enum iGScrollEventType
  {
    SmallDecrement = 0,
    SmallIncrement = 1,
    LargeDecrement = 2,
    LargeIncrement = 3,
    ThumbPosition = 4,
    ThumbTrack = 5,
    EndScroll = 8,
  }
}
