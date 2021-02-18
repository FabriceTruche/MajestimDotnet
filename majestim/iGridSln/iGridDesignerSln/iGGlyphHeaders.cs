// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGGlyphHeaders
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design.Behavior;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGGlyphHeaders : Glyph
  {
    private BehaviorService behaviorService;
    private iGrid grid;

    public iGGlyphHeaders(BehaviorService behaviorService, iGrid grid)
      : base((System.Windows.Forms.Design.Behavior.Behavior) new iGBehaviorHeaders(behaviorService, grid))
    {
      this.behaviorService = behaviorService;
      this.grid = grid;
    }

    public override void Paint(PaintEventArgs pe)
    {
    }

    public override Cursor GetHitTest(Point p)
    {
      Point adornerWindow = this.behaviorService.ControlToAdornerWindow((Control) this.grid);
      p.X = p.X - adornerWindow.X;
      p.Y = p.Y - adornerWindow.Y;
      if ((iGInternalInfrastructure.IsMouseCapturedByGrid(this.grid) || this.grid.IsPointOverHeader(p.X, p.Y) ? 1 : (this.grid.IsPointOverRowHeader(p.X, p.Y) ? 1 : 0)) != 0)
        return ((Control) this.grid).Cursor;
      return (Cursor) null;
    }
  }
}
