// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGControlPaint3D
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  internal class iGControlPaint3D : IiGControlPaintInternal, IiGControlPaint
  {
    private const int cTreeButtonSize = 11;
    private Color fBackColor;
    private Color fForeColor;
    private Color fColorLight;
    private Color fColorLightLight;
    private Color fColorDark;
    private Color fColorDarkDark;

    public iGControlPaint3D()
    {
      this.ControlsForeColor = iGControlPaintStyle.cDefaultForeColor;
      this.ControlsBackColor = iGControlPaintStyle.cDefaultBackColor;
    }

    public void AdjustColors()
    {
      this.fColorLight = iGColorManager.GetColorControlLight(this.fBackColor);
      this.fColorLightLight = iGColorManager.GetColorControlLightLight(this.fBackColor);
      this.fColorDark = iGColorManager.GetColorControlDark(this.fBackColor);
      this.fColorDarkDark = iGColorManager.GetColorControlDarkDark(this.fBackColor);
    }

    public void OnSettingChange()
    {
      this.AdjustColors();
    }

    public void DrawHeader(Graphics g, int x, int y, int width, int height, iGHeaderPart headerPart, iGControlState controlState, bool rightToLeft)
    {
      if (headerPart == iGHeaderPart.SortArrowDown)
      {
        Pen pen1;
        using (pen1 = new Pen(this.fColorDark))
        {
          g.DrawLine(pen1, x, y, x + 7, y);
          g.DrawLine(pen1, x, y + 1, x + 3, y + 6);
          g.DrawLine(pen1, x + 1, y + 1, x + 3, y + 5);
        }
        Pen pen2;
        using (pen2 = new Pen(this.fColorLightLight))
        {
          g.DrawLine(pen2, x + 7, y + 1, x + 4, y + 6);
          g.DrawLine(pen2, x + 6, y + 1, x + 4, y + 5);
        }
      }
      else if (headerPart == iGHeaderPart.SortArrowUp)
      {
        Pen pen1;
        using (pen1 = new Pen(this.fColorLightLight))
        {
          int num = y + 6;
          g.DrawLine(pen1, x + 1, num, x + 7, num);
          g.DrawLine(pen1, x + 4, y, x + 7, y + 6);
          g.DrawLine(pen1, x + 5, y + 1, x + 7, y + 5);
        }
        Pen pen2;
        using (pen2 = new Pen(this.fColorDark))
        {
          g.DrawLine(pen2, x, y + 6, x + 3, y);
          g.DrawLine(pen2, x, y + 5, x + 2, y + 1);
        }
      }
      else
      {
        using (Brush brush = (Brush) new SolidBrush(this.fBackColor))
          g.FillRectangle(brush, x, y, width, height);
        if (controlState == iGControlState.Pressed)
        {
          using (Brush brush = (Brush) new SolidBrush(this.fColorDark))
            iGDrawGridItem.DrawRectangleWithBrush(g, brush, x, y, width, height);
        }
        else if (headerPart == iGHeaderPart.ItemRight)
          this.DrawBorder(g, x, y, width, height, true, true, false, rightToLeft);
        else
          this.DrawBorder(g, x, y, width, height, true, true, true, rightToLeft);
      }
    }

    public Size GetHeaderSortIconSize()
    {
      return new Size(8, 7);
    }

    private void DrawBorder(Graphics g, int x, int y, int width, int height, bool single, bool raised, bool drawRight, bool rightToLeft)
    {
      --height;
      --width;
      bool flag = false;
      Brush brush1;
      Brush brush2;
      Brush brush3;
      Brush brush4;
      if (raised)
      {
        if (single)
        {
          brush1 = (Brush) new SolidBrush(this.fColorLightLight);
          if (rightToLeft)
          {
            flag = true;
            if (drawRight)
              ++x;
            else
              ++width;
          }
        }
        else
          brush1 = (Brush) new SolidBrush(this.fColorLight);
        brush2 = (Brush) new SolidBrush(this.fColorLightLight);
        brush3 = (Brush) new SolidBrush(this.fColorDarkDark);
        brush4 = (Brush) new SolidBrush(this.fColorDark);
      }
      else
      {
        brush1 = (Brush) new SolidBrush(this.fColorDark);
        brush2 = (Brush) new SolidBrush(this.fColorDarkDark);
        brush3 = (Brush) new SolidBrush(this.fColorLightLight);
        brush4 = (Brush) new SolidBrush(this.fColorLight);
      }
      int num = 0;
      g.FillRectangle(brush1, x, y, width, 1);
      if (drawRight || !rightToLeft)
        g.FillRectangle(brush1, x, y, 1, height);
      else
        num = 1;
      if (!single)
      {
        g.FillRectangle(brush2, x + 1, y + 1, width - 2, 1);
        g.FillRectangle(brush2, x + 1, y + 1, 1, height - 2);
      }
      if (drawRight | rightToLeft)
      {
        g.FillRectangle(brush4, x + width - 1, y + 1, 1, height - 1);
        if (flag)
        {
          if (drawRight)
            g.FillRectangle(brush3, x - 1, y, 1, height + 1);
        }
        else
          g.FillRectangle(brush3, x + width, y, 1, height + 1);
        g.FillRectangle(brush4, x + 1 - num, y + height - 1, width - 1 + num, 1);
      }
      else
        g.FillRectangle(brush4, x + 1, y + height - 1, width, 1);
      g.FillRectangle(brush3, x, y + height, width, 1);
      brush1.Dispose();
      brush2.Dispose();
      brush3.Dispose();
      brush4.Dispose();
    }

    public void DrawButtonBorder(Graphics g, ref int x, ref int y, int width, int height, iGControlState controlState)
    {
      if (width <= 0 || height <= 0)
        return;
      using (Brush brush = (Brush) new SolidBrush(this.fBackColor))
        g.FillRectangle(brush, x, y, width, height);
      if (controlState == iGControlState.HotPressed)
      {
        using (Brush brush = (Brush) new SolidBrush(this.fColorDark))
          iGDrawGridItem.DrawRectangleWithBrush(g, brush, x, y, width, height);
        x = x + 1;
        y = y + 1;
      }
      else
        this.DrawBorder(g, x, y, width, height, false, true, true, false);
    }

    public void DrawScrollBar(Graphics g, int x, int y, int width, int height, iGScrollBarPart scrollPart, iGControlState controlState)
    {
      Color color = controlState != iGControlState.Disabled ? this.fForeColor : this.fColorDark;
      switch (scrollPart)
      {
        case iGScrollBarPart.ButtonUp:
          this.DrawButtonBorder(g, ref x, ref y, width, height, controlState);
          iGDrawGridItem.DrawArrowOnButton(g, color, x, y, width, height, iGArrowDirection.Up, false);
          break;
        case iGScrollBarPart.ButtonDown:
          this.DrawButtonBorder(g, ref x, ref y, width, height, controlState);
          iGDrawGridItem.DrawArrowOnButton(g, color, x, y, width, height, iGArrowDirection.Down, false);
          break;
        case iGScrollBarPart.ButtonLeft:
          this.DrawButtonBorder(g, ref x, ref y, width, height, controlState);
          iGDrawGridItem.DrawArrowOnButton(g, color, x, y, width, height, iGArrowDirection.Left, false);
          break;
        case iGScrollBarPart.ButtonRight:
          this.DrawButtonBorder(g, ref x, ref y, width, height, controlState);
          iGDrawGridItem.DrawArrowOnButton(g, color, x, y, width, height, iGArrowDirection.Right, false);
          break;
        case iGScrollBarPart.ThumbHorz:
        case iGScrollBarPart.ThumbVert:
          Brush brush1;
          using (brush1 = (Brush) new SolidBrush(this.fBackColor))
            g.FillRectangle(brush1, x, y, width, height);
          this.DrawBorder(g, x, y, width, height, false, true, true, false);
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
      this.DrawBorder(g, x, y, width, height, false, false, true, false);
      if (checkState == CheckState.Unchecked)
        return;
      Color color = checkState == CheckState.Indeterminate || controlState == iGControlState.Disabled ? this.fColorDark : this.fForeColor;
      iGDrawGridItem.DrawCheck(g, color, x, y, width - 6);
    }

    public Size GetCheckBoxSize()
    {
      return new Size(13, 13);
    }

    public void DrawComboButton(Graphics g, int x, int y, int width, int height, iGControlState controlState, bool isHeader)
    {
      this.DrawButtonBorder(g, ref x, ref y, width, height, controlState);
      Color color = controlState != iGControlState.Disabled ? this.fForeColor : this.fColorDark;
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
      using (Pen pen1 = new Pen(this.fColorDark))
      {
        using (Pen pen2 = new Pen(this.fColorLightLight))
        {
          for (int index = 0; index < num1; ++index)
          {
            g.DrawLine(pen1, x, y1, x2, y);
            x += num2;
            --y;
            g.DrawLine(pen1, x, y1, x2, y);
            x += num2;
            --y;
            g.DrawLine(pen2, x, y1, x2, y);
            x += 2 * num2;
            y -= 2;
          }
        }
      }
    }

    public void DrawScrollBarCustomButton(Graphics g, int x, int y, int width, int height, iGControlState controlState)
    {
      this.DrawButtonBorder(g, ref x, ref y, width, height, controlState);
    }

    public void DrawEllipsisButton(Graphics g, int x, int y, int width, int height, iGControlState controlState)
    {
      this.DrawButtonBorder(g, ref x, ref y, width, height, controlState);
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
      this.DrawBorder(g, x, y, 11, 11, true, true, true, false);
      using (Brush brush = (Brush) new SolidBrush(this.fBackColor))
        g.FillRectangle(brush, x + 1, y + 1, 9, 9);
      using (Brush brush = (Brush) new SolidBrush(this.fForeColor))
      {
        g.FillRectangle(brush, x + 3, y + 5, 5, 1);
        if (!expanded)
          g.FillRectangle(brush, x + 5, y + 3, 1, 5);
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

    public iGInternalControlPaintStyle GetStyle()
    {
      return iGInternalControlPaintStyle.Style3D;
    }

    public iGIndent GetHeaderIndent(bool rightToLeft)
    {
      if (rightToLeft)
        return new iGIndent(2, 1, 1, 2);
      return new iGIndent(1, 1, 2, 2);
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

    public iGIndent GetScrollBarCustomButtonIndent
    {
      get
      {
        return new iGIndent(2, 2, 2, 2);
      }
    }

    public bool OffsetScrollBarCustomButtonImageWhenPressed
    {
      get
      {
        return true;
      }
    }

    public Color ControlsDisabledForeColor
    {
      get
      {
        return this.fColorDark;
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
