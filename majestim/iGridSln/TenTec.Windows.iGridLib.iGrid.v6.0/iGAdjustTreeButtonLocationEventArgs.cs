// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGAdjustTreeButtonLocationEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.AdjustTreeButtonLocation" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGAdjustTreeButtonLocationEventArgs : EventArgs
  {
    /// <summary>The Y-coordinate of the top edge of the tree button.</summary>
    public int ButtonY;
    /// <summary>The height of the tree button.</summary>
    public readonly int ButtonHeight;
    /// <summary>The Y-coordinate of the top edge of the rectangle area available for the tree button placement.</summary>
    public readonly int PlaceRectY;
    /// <summary>The height of the rectangle area available for the tree button placement.</summary>
    public readonly int PlaceRectHeight;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGAdjustTreeButtonLocationEventArgs" /> class.</summary>
    /// <param name="buttonY">The Y-coordinate of the top edge of the tree button.</param>
    /// <param name="buttonHeight">The height of the tree button.</param>
    /// <param name="placeY">The Y-coordinate of the top edge of the rectangle area available for the tree button placement.</param>
    /// <param name="placeHeight">The height of the rectangle area available for the tree button placement.</param>
    public iGAdjustTreeButtonLocationEventArgs(int buttonY, int buttonHeight, int placeY, int placeHeight)
    {
      this.ButtonY = buttonY;
      this.ButtonHeight = buttonHeight;
      this.PlaceRectY = placeY;
      this.PlaceRectHeight = placeHeight;
    }
  }
}
