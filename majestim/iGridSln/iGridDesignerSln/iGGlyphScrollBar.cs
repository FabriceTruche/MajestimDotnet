// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGGlyphScrollBar
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design.Behavior;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGGlyphScrollBar : Glyph
  {
    private BehaviorService behaviorService;
    private iGrid grid;
    private bool vertical;

    public iGGlyphScrollBar(BehaviorService behaviorService, iGrid grid, bool vertical)
      : base((System.Windows.Forms.Design.Behavior.Behavior) new iGBehaviorScrollBar(behaviorService, grid, vertical))
    {
      this.behaviorService = behaviorService;
      this.grid = grid;
      this.vertical = vertical;
    }

    public override void Paint(PaintEventArgs pe)
    {
    }

    public override Cursor GetHitTest(Point p)
    {
      Point adornerWindow = this.behaviorService.ControlToAdornerWindow((Control) this.grid);
      p.X = p.X - adornerWindow.X;
      p.Y = p.Y - adornerWindow.Y;
      if ((iGInternalInfrastructure.IsMouseCapturedByScrollBar(this.grid, this.vertical) ? 1 : (this.vertical ? (this.grid.IsPointOverVScrollBar(p.X, p.Y) ? 1 : 0) : (this.grid.IsPointOverHScrollBar(p.X, p.Y) ? 1 : 0))) != 0)
        return ((Control) this.grid).Cursor;
      return (Cursor) null;
    }
  }
}
