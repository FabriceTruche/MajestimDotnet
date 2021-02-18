// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGControlPaintFlat
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  internal class iGControlPaintFlat : IiGControlPaintInternal, IiGControlPaint
  {
    private const int cTreeButtonSize = 11;
    private Color fForeColor;
    private Color fBackColor;
    private Color fColorBorder;
    private Color fColorPressed;
    private Color fColorHot;
    private Color fColorLightLight;

    public iGControlPaintFlat()
    {
      this.ControlsForeColor = iGControlPaintStyle.cDefaultForeColor;
      this.ControlsBackColor = iGControlPaintStyle.cDefaultBackColor;
    }

    public void AdjustColors()
    {
      this.fColorBorder = iGColorManager.GetColorControlDark(this.fBackColor);
      this.fColorLightLight = iGColorManager.GetColorControlLightLight(this.fBackColor);
      this.fColorPressed = iGColorManager.GetColorControlDark(this.fBackColor);
      this.fColorHot = iGColorManager.Lighten(this.fBackColor, 10);
    }

    public void OnSettingChange()
    {
      this.AdjustColors();
    }

    public void DrawHeader(Graphics g, int x, int y, int width, int height, iGHeaderPart headerPart, iGControlState controlState, bool rightToLeft)
    {
      Color color = controlState != iGControlState.Disabled ? this.fForeColor : this.fColorPressed;
      if (headerPart == iGHeaderPart.SortArrowDown)
        iGDrawGridItem.DrawArrow(g, color, x, y, 5, iGArrowDirection.Down);
      else if (headerPart == iGHeaderPart.SortArrowUp)
      {
        iGDrawGridItem.DrawArrow(g, color, x, y, 5, iGArrowDirection.Up);
      }
      else
      {
        using (Brush brush = (Brush) new SolidBrush(controlState != iGControlState.Pressed ? (controlState != iGControlState.Hot ? this.fBackColor : this.fColorHot) : this.fColorPressed))
          g.FillRectangle(brush, x, y, width, height - 1);
        using (Brush brush = (Brush) new SolidBrush(this.fColorBorder))
        {
          g.FillRectangle(brush, x, y + height - 1, width, 1);
          if (headerPart == iGHeaderPart.ItemRight)
            return;
          if (rightToLeft)
            g.FillRectangle(brush, x, y, 1, height);
          else
            g.FillRectangle(brush, x + width - 1, y, 1, height);
        }
      }
    }

    public Size GetHeaderSortIconSize()
    {
      return new Size(9, 5);
    }

    private void DrawButtonInternal(Graphics g, int x, int y, int width, int height, iGControlState controlState, bool borderHotIndication)
    {
      if (width <= 0 || height <= 0)
        return;
      Color color = controlState != iGControlState.HotPressed ? (controlState == iGControlState.Pressed || controlState == iGControlState.Hot ? this.fColorHot : this.fBackColor) : this.fColorPressed;
      if (width > 2 && height > 2)
      {
        using (Brush brush = (Brush) new SolidBrush(color))
          g.FillRectangle(brush, x + 1, y + 1, width - 2, height - 2);
      }
      using (Brush brush = (Brush) new SolidBrush(this.fColorBorder))
        iGDrawGridItem.DrawRectangleWithBrush(g, brush, x, y, width, height);
      if (!borderHotIndication || controlState != iGControlState.Hot)
        return;
      using (Brush brush = (Brush) new SolidBrush(this.fColorBorder))
        iGDrawGridItem.DrawRectangleWithBrush(g, brush, x + 1, y + 1, width - 2, height - 2);
    }

    public void DrawScrollBar(Graphics g, int x, int y, int width, int height, iGScrollBarPart scrollPart, iGControlState controlState)
    {
      Color color = controlState != iGControlState.Disabled ? this.fForeColor : this.fColorPressed;
      switch (scrollPart)
      {
        case iGScrollBarPart.ButtonUp:
          this.DrawButtonInternal(g, x, y, width, height, controlState, false);
          iGDrawGridItem.DrawArrowOnButton(g, color, x, y, width, height, iGArrowDirection.Up, false);
          break;
        case iGScrollBarPart.ButtonDown:
          this.DrawButtonInternal(g, x, y, width, height, controlState, false);
          iGDrawGridItem.DrawArrowOnButton(g, color, x, y, width, height, iGArrowDirection.Down, false);
          break;
        case iGScrollBarPart.ButtonLeft:
          this.DrawButtonInternal(g, x, y, width, height, controlState, false);
          iGDrawGridItem.DrawArrowOnButton(g, color, x, y, width, height, iGArrowDirection.Left, false);
          break;
        case iGScrollBarPart.ButtonRight:
          this.DrawButtonInternal(g, x, y, width, height, controlState, false);
          iGDrawGridItem.DrawArrowOnButton(g, color, x, y, width, height, iGArrowDirection.Right, false);
          break;
        case iGScrollBarPart.ThumbHorz:
        case iGScrollBarPart.ThumbVert:
          Brush brush1;
          using (brush1 = (Brush) new SolidBrush(this.fBackColor))
            g.FillRectangle(brush1, x, y, width, height);
          this.DrawButtonInternal(g, x, y, width, height, controlState, false);
          break;
        case iGScrollBarPart.UpperTrackHorz:
        case iGScrollBarPart.LowerTrackHorz:
        case iGScrollBarPart.UpperTrackVert:
        case iGScrollBarPart.LowerTrackVert:
          Brush brush2 = controlState != iGControlState.HotPressed ? (Brush) new HatchBrush(HatchStyle.Percent50, this.fBackColor, this.fColorLightLight) : (Brush) new SolidBrush(this.fForeColor);
          g.FillRectangle(brush2, x, y, width, height);
          brush2.Dispose();
          break;
      }
    }

    public void DrawCheckBox(Graphics g, int x, int y, int width, int height, CheckState checkState, iGControlState controlState)
    {
      if (width > height)
        width = height;
      else
        height = width;
      if ((uint) (controlState - 3) <= 1U)
      {
        Brush brush;
        using (brush = (Brush) new SolidBrush(this.fBackColor))
          g.FillRectangle(brush, x, y, width, height);
      }
      else if (checkState == CheckState.Indeterminate)
      {
        Brush brush;
        using (brush = (Brush) new HatchBrush(HatchStyle.Percent50, SystemColors.Window, this.fBackColor))
          g.FillRectangle(brush, x, y, width, height);
      }
      else
        g.FillRectangle(SystemBrushes.Window, x, y, width, height);
      Brush brush1;
      using (brush1 = (Brush) new SolidBrush(this.fColorBorder))
      {
        iGDrawGridItem.DrawRectangleWithBrush(g, brush1, x, y, width, height);
        if (controlState == iGControlState.Hot)
          iGDrawGridItem.DrawRectangleWithBrush(g, brush1, x + 1, y + 1, width - 2, height - 2);
      }
      if (checkState == CheckState.Unchecked)
        return;
      Color color = checkState == CheckState.Indeterminate || controlState == iGControlState.Disabled ? this.fColorPressed : this.fForeColor;
      iGDrawGridItem.DrawCheck(g, color, x, y, width - 6);
    }

    public Size GetCheckBoxSize()
    {
      return new Size(13, 13);
    }

    public void DrawComboButton(Graphics g, int x, int y, int width, int height, iGControlState controlState, bool isHeader)
    {
      this.DrawButtonInternal(g, x, y, width, height, controlState, true);
      Color color = controlState != iGControlState.Disabled ? this.fForeColor : this.fColorPressed;
      iGDrawGridItem.DrawArrowOnButton(g, color, x, y, width, height, iGArrowDirection.Down, false);
    }

    public void DrawSizeBox(Graphics g, int x, int y, int width, int height, iGSizeBoxAlign align)
    {
      int num1 = ((width >= height ? height : width) - 3) / 4;
      int y1 = y + height - 1;
      y = y + height - 4;
      int x2;
      int num2;
      if (align == iGSizeBoxAlign.Right)
      {
        x2 = x + width - 1;
        x = x + width - 4;
        num2 = -1;
      }
      else
      {
        x2 = x;
        x += 3;
        num2 = 1;
      }
      using (Pen pen = new Pen(this.fColorBorder))
      {
        for (int index = 0; index < num1; ++index)
        {
          g.DrawLine(pen, x, y1, x2, y);
          x += num2;
          --y;
          g.DrawLine(pen, x, y1, x2, y);
          x += 3 * num2;
          y -= 3;
        }
      }
    }

    public iGInternalControlPaintStyle GetStyle()
    {
      return iGInternalControlPaintStyle.Flat;
    }

    public void DrawScrollBarCustomButton(Graphics g, int x, int y, int width, int height, iGControlState controlState)
    {
      this.DrawButtonInternal(g, x, y, width, height, controlState, false);
    }

    public void DrawEllipsisButton(Graphics g, int x, int y, int width, int height, iGControlState controlState)
    {
      this.DrawButtonInternal(g, x, y, width, height, controlState, true);
    }

    public iGIndent GetHeaderIndent(bool rightToLeft)
    {
      if (rightToLeft)
        return new iGIndent(1, 0, 0, 1);
      return new iGIndent(0, 0, 1, 1);
    }

    public void DrawTreeButton(Graphics g, int x, int y, int width, int height, bool expanded)
    {
      if (width <= 0 || height <= 0)
        return;
      Region region1 = (Region) null;
      Region region2 = (Region) null;
      if (width < 11 || height < 11)
      {
        region1 = g.Clip;
        region2 = region1.Clone();
        region2.Intersect(new Rectangle(x, y, width, height));
        g.Clip = region2;
      }
      Brush brush1;
      using (brush1 = (Brush) new SolidBrush(this.fColorBorder))
        iGDrawGridItem.DrawRectangleWithBrush(g, brush1, x, y, 11, 11);
      Brush brush2;
      using (brush2 = (Brush) new SolidBrush(this.fBackColor))
        g.FillRectangle(brush2, x + 1, y + 1, 9, 9);
      Brush brush3;
      using (brush3 = (Brush) new SolidBrush(this.fForeColor))
      {
        g.FillRectangle(brush3, x + 3, y + 5, 5, 1);
        if (!expanded)
          g.FillRectangle(brush3, x + 5, y + 3, 1, 5);
      }
      if (region1 == null)
        return;
      g.Clip = region1;
      region2.Dispose();
      region1.Dispose();
    }

    public Size GetTreeButtonSize()
    {
      return new Size(11, 11);
    }

    public void DrawRowHdr(Graphics g, int x, int y, int width, int height, iGControlState controlState, bool rightToLeft)
    {
      this.DrawHeader(g, x, y, width, height, iGHeaderPart.Item, controlState, rightToLeft);
    }

    public iGIndent GetRowHdrIndent(bool rightToLeft)
    {
      return this.GetHeaderIndent(rightToLeft);
    }

    public void DrawGroupBoxBackground(Graphics g, int x, int y, int width, int height, bool rightToLeft)
    {
      throw new NotImplementedException();
    }

    public Color ControlsForeColor
    {
      get
      {
        return this.fForeColor;
      }
      set
      {
        this.fForeColor = value;
      }
    }

    public Color ControlsBackColor
    {
      get
      {
        return this.fBackColor;
      }
      set
      {
        this.fBackColor = value;
        this.AdjustColors();
      }
    }

    public Color ControlsDisabledForeColor
    {
      get
      {
        return this.fColorPressed;
      }
    }

    public iGIndent GetScrollBarCustomButtonIndent
    {
      get
      {
        return new iGIndent(1, 1, 1, 1);
      }
    }

    public bool OffsetScrollBarCustomButtonImageWhenPressed
    {
      get
      {
        return false;
      }
    }

    public iGControlPaintFunctions SupportedFunctions
    {
      get
      {
        return (iGControlPaintFunctions) 65023;
      }
    }
  }
}
