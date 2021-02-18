// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGDrawGridItem
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  internal class iGDrawGridItem
  {
    public static void DrawRectangleWithBrush(Graphics g, Brush brush, int x, int y, int width, int height)
    {
      g.FillRectangle(brush, x, y, width, 1);
      g.FillRectangle(brush, x + width - 1, y, 1, height);
      g.FillRectangle(brush, x, y, 1, height);
      g.FillRectangle(brush, x, y + height - 1, width, 1);
    }

    public static int DrawArrow(Graphics g, Color color, int x, int y, int size, iGArrowDirection direction)
    {
      if (size <= 0)
        return 0;
      using (Brush brush = (Brush) new SolidBrush(color))
      {
        if (direction == iGArrowDirection.Up || direction == iGArrowDirection.Down)
        {
          int num1 = x + 2 * (size - 1);
          int num2;
          if (direction == iGArrowDirection.Up)
          {
            num2 = -1;
            y += size - 1;
          }
          else
            num2 = 1;
          while (x <= num1)
          {
            g.FillRectangle(brush, x, y, num1 - x + 1, 1);
            ++x;
            --num1;
            y += num2;
          }
        }
        else
        {
          int num1 = y + 2 * (size - 1);
          int num2;
          if (direction == iGArrowDirection.Left)
          {
            num2 = -1;
            x += size - 1;
          }
          else
            num2 = 1;
          while (y <= num1)
          {
            g.FillRectangle(brush, x, y, 1, num1 - y + 1);
            ++y;
            --num1;
            x += num2;
          }
        }
      }
      return 2 * (size - 1) + 1;
    }

    public static int GetArrowSize(ref int x, ref int y, int width, int height, iGArrowDirection direction, bool doubleArrow)
    {
      int num1 = width > height ? height : width;
      int num2 = !doubleArrow ? num1 / 2 | 1 : num1 / 3 | 1;
      int num3 = (num2 - 1) / 2 + 1;
      int num4 = doubleArrow ? num3 + num3 : num3;
      if ((uint) direction > 1U)
      {
        if ((uint) (direction - 2) <= 1U)
        {
          x = direction != iGArrowDirection.Left ? x + width - (width - num4) / 2 - num4 : x + (width - num4) / 2;
          y = y + (height - num2) / 2;
        }
      }
      else
      {
        y = direction != iGArrowDirection.Up ? y + height - (height - num4) / 2 - num4 : y + (height - num4) / 2;
        x = x + (width - num2) / 2;
      }
      return num3;
    }

    public static void DrawArrowOnButton(Graphics g, Color color, int x, int y, int width, int height, iGArrowDirection direction, bool doubleArrow)
    {
      width -= 4;
      height -= 4;
      x += 2;
      y += 2;
      if (width <= 0 || height <= 0)
        return;
      int arrowSize = iGDrawGridItem.GetArrowSize(ref x, ref y, width, height, direction, doubleArrow);
      iGDrawGridItem.DrawArrow(g, color, x, y, arrowSize, direction);
      if (!doubleArrow)
        return;
      if (direction == iGArrowDirection.Up || direction == iGArrowDirection.Down)
        y += arrowSize;
      else
        x += arrowSize;
      iGDrawGridItem.DrawArrow(g, color, x, y, arrowSize, direction);
    }

    public static void DrawEllipsisOnButton(Graphics g, Color color, int x, int y, int width, int height)
    {
      width -= 6;
      x += 3;
      int num = width / 5;
      if (num <= 0)
        return;
      y += 2 * height / 3;
      x += width % 5 / 2;
      Brush brush = (Brush) new SolidBrush(color);
      for (int index = 0; index < 3; ++index)
      {
        g.FillRectangle(brush, x, y, num, num);
        x += 2 * num;
      }
    }

    public static void DrawCheck(Graphics g, Color color, int x, int y, int size)
    {
      if (size <= 0)
        return;
      float num = (float) size / 7f;
      using (Pen pen = new Pen(color))
      {
        x += 3;
        y += 3;
        g.DrawLines(pen, new PointF[3]
        {
          new PointF((float) x, (float) y + 2f * num),
          new PointF((float) x + 2f * num, (float) y + 4f * num),
          new PointF((float) x + 6f * num, (float) y)
        });
        g.DrawLines(pen, new PointF[3]
        {
          new PointF((float) x, (float) y + 3f * num),
          new PointF((float) x + 2f * num, (float) y + 5f * num),
          new PointF((float) x + 6f * num, (float) y + 1f * num)
        });
        g.DrawLines(pen, new PointF[3]
        {
          new PointF((float) x, (float) y + 4f * num),
          new PointF((float) x + 2f * num, (float) y + 6f * num),
          new PointF((float) x + 6f * num, (float) y + 2f * num)
        });
      }
    }
  }
}
