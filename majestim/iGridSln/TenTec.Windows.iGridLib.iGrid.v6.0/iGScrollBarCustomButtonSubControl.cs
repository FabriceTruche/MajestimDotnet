// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGScrollBarCustomButtonSubControl
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

namespace TenTec.Windows.iGridLib
{
  internal class iGScrollBarCustomButtonSubControl : iGSubControl
  {
    internal iGScrollBarCustomButtonAlign fAlignment;
    internal int fImageIndex;
    internal iGActions fAction;
    internal string fToolTipText;
    internal iGScrollBarBase fControl;
    internal object fTag;

    internal iGScrollBarCustomButtonSubControl(iGScrollBarCustomButtonAlign alignment, iGActions action, int imageIndex, string toolTipText, bool enabled, object tag)
      : base(iGMouseProcessingStyle.PushButton, enabled)
    {
      this.fAlignment = alignment;
      this.fImageIndex = imageIndex;
      this.fAction = action;
      this.fToolTipText = toolTipText;
      this.fTag = tag;
    }
  }
}
