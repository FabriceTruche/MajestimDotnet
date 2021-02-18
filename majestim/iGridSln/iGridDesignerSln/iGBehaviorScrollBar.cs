// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGBehaviorScrollBar
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design.Behavior;

namespace TenTec.Windows.iGridLib.Design
{
  internal class iGBehaviorScrollBar : System.Windows.Forms.Design.Behavior.Behavior
  {
    private BehaviorService behaviorService;
    private iGrid grid;
    private int mouseMoveX;
    private int mouseMoveY;
    private bool vertical;

    public iGBehaviorScrollBar(BehaviorService behaviorService, iGrid grid, bool vertical)
    {
      this.behaviorService = behaviorService;
      this.grid = grid;
      this.vertical = vertical;
    }

    public override bool OnMouseMove(Glyph g, MouseButtons button, Point mouseLoc)
    {
      Point adornerWindow = this.behaviorService.ControlToAdornerWindow((Control) this.grid);
      this.mouseMoveX = mouseLoc.X - adornerWindow.X;
      this.mouseMoveY = mouseLoc.Y - adornerWindow.Y;
      iGInternalInfrastructure.ProcessMouseMoveForScrollBar(this.grid, this.vertical, this.mouseMoveX, this.mouseMoveY, button);
      return base.OnMouseMove(g, button, mouseLoc);
    }

    public override bool OnMouseDown(Glyph g, MouseButtons button, Point mouseLoc)
    {
      iGInternalInfrastructure.ProcessMouseDownForScrollBar(this.grid, this.vertical, this.mouseMoveX, this.mouseMoveY, button);
      return base.OnMouseDown(g, button, mouseLoc);
    }

    public override bool OnMouseUp(Glyph g, MouseButtons button)
    {
      iGInternalInfrastructure.ProcessMouseUpForScrollBar(this.grid, this.vertical, this.mouseMoveX, this.mouseMoveY, button);
      return base.OnMouseUp(g, button);
    }

    public override bool OnMouseLeave(Glyph g)
    {
      iGInternalInfrastructure.ProcessMouseLeaveForScrollBar(this.grid, this.vertical, EventArgs.Empty);
      return base.OnMouseLeave(g);
    }
  }
}
