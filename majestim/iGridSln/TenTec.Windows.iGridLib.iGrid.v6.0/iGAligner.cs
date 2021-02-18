// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGAligner
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.Drawing;

namespace TenTec.Windows.iGridLib
{
  internal class iGAligner
  {
    public static iGIndent RtlTranslateIndent(iGIndent indent)
    {
      return new iGIndent(indent.fRight, indent.fTop, indent.fLeft, indent.fBottom);
    }

    public static ContentAlignment RtlTranslateContent(ContentAlignment align)
    {
      if (align <= ContentAlignment.MiddleLeft)
      {
        if (align != ContentAlignment.TopLeft)
        {
          if (align != ContentAlignment.TopRight)
          {
            if (align == ContentAlignment.MiddleLeft)
              align = ContentAlignment.MiddleRight;
          }
          else
            align = ContentAlignment.TopLeft;
        }
        else
          align = ContentAlignment.TopRight;
      }
      else if (align != ContentAlignment.MiddleRight)
      {
        if (align != ContentAlignment.BottomLeft)
        {
          if (align == ContentAlignment.BottomRight)
            align = ContentAlignment.BottomLeft;
        }
        else
          align = ContentAlignment.BottomRight;
      }
      else
        align = ContentAlignment.MiddleLeft;
      return align;
    }

    public static void AdjustImageLocation(ref int x, ref int y, int width, int height, int imageWidth, int imageHeight, ContentAlignment align, iGIndent indent, bool rightToLeft)
    {
      if (rightToLeft)
      {
        align = iGAligner.RtlTranslateContent(align);
        indent = iGAligner.RtlTranslateIndent(indent);
      }
      x = x + indent.fLeft;
      y = y + indent.fTop;
      width -= indent.fLeft + indent.fRight;
      height -= indent.fTop + indent.fBottom;
      switch (align)
      {
        case ContentAlignment.BottomLeft:
          y = y + (height - imageHeight);
          break;
        case ContentAlignment.BottomCenter:
          x = x + (width - imageWidth) / 2;
          y = y + (height - imageHeight);
          break;
        case ContentAlignment.BottomRight:
          x = x + (width - imageWidth);
          y = y + (height - imageHeight);
          break;
        case ContentAlignment.TopLeft:
          break;
        case ContentAlignment.TopCenter:
          x = x + (width - imageWidth) / 2;
          break;
        case ContentAlignment.TopRight:
          x = x + (width - imageWidth);
          break;
        case ContentAlignment.MiddleLeft:
          y = y + (height - imageHeight) / 2;
          break;
        case ContentAlignment.MiddleRight:
          x = x + (width - imageWidth);
          y = y + (height - imageHeight) / 2;
          break;
        default:
          x = x + (width - imageWidth) / 2;
          y = y + (height - imageHeight) / 2;
          break;
      }
    }
  }
}
