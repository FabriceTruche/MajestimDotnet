// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGRowHeader
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  /// <summary>This class allows you to set up the appearance and behavior of the whole row header of an iGrid control.</summary>
  public class iGRowHeader : IDisposable
  {
    private static readonly Color cDefaultBackColor = Color.Empty;
    internal static readonly iGPenStyle cDefaultGridLinesStyle = new iGPenStyle(SystemColors.ControlDark, 0, DashStyle.Solid);
    private static bool fAreGlyphsFlipped = false;
    private int fWidth = 19;
    private bool fHotTracking = true;
    private bool fDrawSystem = true;
    private Color fBackColor = iGRowHeader.cDefaultBackColor;
    private const bool cDefaultVisible = false;
    private const int cDefaultWidth = 19;
    private const bool cDefaultHotTracking = true;
    private const bool cDefaultDrawSystem = true;
    private const iGRowHdrGlyph cDefaultCurRowGlyph = iGRowHdrGlyph.CurRow;
    private const int cGlyphAreaWidth = 15;
    private const int cGlyphAreaHeight = 13;
    private iGrid fGrid;
    private bool fVisible;
    private iGControlPaintStyle fControlPaintStyle;
    private iGPenStyle fHGridLinesStyle;
    private iGPenStyle fVGridLinesStyle;
    private static Image fGlyphCurRow;
    private static Image fGlyphEditing;
    private static Image fGlyphError;
    private static Image fGlyphCurRowError;
    private static Image fGlyphUncommitedChanges;
    private static Image fGlyphNewRow;
    private bool fDisposed;

    /// <summary>Returns the <see cref="T:TenTec.Windows.iGridLib.iGrid" /> object this instance belongs to.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGrid" /> object.</value>
    [Browsable(false)]
    public iGrid Grid
    {
      get
      {
        return this.fGrid;
      }
    }

    internal iGRowHeader(iGrid grid)
    {
      if (grid == null)
        throw new ArgumentNullException(nameof (grid));
      this.fGrid = grid;
      this.fControlPaintStyle = new iGControlPaintStyle();
      this.fHGridLinesStyle = iGRowHeader.cDefaultGridLinesStyle.Clone();
      this.fVGridLinesStyle = iGRowHeader.cDefaultGridLinesStyle.Clone();
    }

    /// <summary>Releases all the resources used by the object.</summary>
    /// <param name="disposing">The Boolean <b>disposing</b> tells the code whether your code initiated the object's disposal (True) or whether the .NET Garbage Collector did it (as part of the Finalize method).</param>
    protected virtual void Dispose(bool disposing)
    {
      if (this.fDisposed)
        return;
      if (disposing && this.fControlPaintStyle != null)
      {
        this.fControlPaintStyle.Dispose();
        this.fControlPaintStyle = (iGControlPaintStyle) null;
      }
      this.fDisposed = true;
    }

    /// <summary>Releases all the resources used by the object.</summary>
    public void Dispose()
    {
      this.Dispose(true);
    }

    internal int EffectiveWidth()
    {
      if (this.fVisible)
        return this.fWidth;
      return 0;
    }

    internal void DrawRowHdrWithGridLines(Graphics g, int x, int y, int height, int rowIndex, iGControlState state, iGRowHdrGlyph glyph, Color backColor, bool selected, bool rightToLeft)
    {
      if (g == null)
        throw new ArgumentNullException(nameof (g));
      int num1 = this.EffectiveWidth();
      if (num1 <= 0 || height <= 0)
        return;
      iGrid.GridLineParams gridLineStyleParams1 = this.fGrid.GetGridLineStyleParams(this.fHGridLinesStyle, iGOrientation.Horizontal, true);
      iGrid.GridLineParams gridLineStyleParams2 = this.fGrid.GetGridLineStyleParams(this.fVGridLinesStyle, iGOrientation.Vertical, true);
      if (gridLineStyleParams1.Visible)
      {
        int x1 = x;
        int num2 = num1;
        if (gridLineStyleParams2.Visible)
          num2 -= this.fVGridLinesStyle.Width;
        int num3 = y + height;
        if (rightToLeft)
          x1 = 2 * x + num1 - x1 - num2;
        g.DrawLine(gridLineStyleParams1.Pen, x1, num3 - gridLineStyleParams1.PenOffset, x1 + num2 + gridLineStyleParams1.PenExtra, num3 - gridLineStyleParams1.PenOffset);
      }
      if (gridLineStyleParams2.Visible)
      {
        int num2 = x + num1;
        int y1 = y;
        int num3 = height;
        if (rightToLeft)
          num2 = 2 * x + num1 - num2 + this.fVGridLinesStyle.Width;
        g.DrawLine(gridLineStyleParams2.Pen, num2 - gridLineStyleParams2.PenOffset, y1, num2 - gridLineStyleParams2.PenOffset, y1 + num3 + gridLineStyleParams2.PenExtra);
      }
      if (gridLineStyleParams1.Pen != null)
        gridLineStyleParams1.Pen.Dispose();
      if (gridLineStyleParams2.Pen != null)
        gridLineStyleParams2.Pen.Dispose();
      int x2 = x;
      int y2 = y;
      int width = num1;
      if (gridLineStyleParams2.Visible)
        width -= this.fVGridLinesStyle.Width;
      int height1 = height;
      if (gridLineStyleParams1.Visible)
        height1 -= this.fHGridLinesStyle.Width;
      if (rightToLeft)
        x2 = 2 * x - x2 + num1 - width;
      this.DrawRowHdrWithoutGridLines(g, x2, y2, width, height1, rowIndex, state, glyph, backColor, selected, true, this.fDrawSystem, rightToLeft);
    }

    internal void DrawRowHdrWithoutGridLines(Graphics g, int x, int y, int width, int height, int rowIndex, iGControlState state, iGRowHdrGlyph glyph, Color backColor, bool selected, bool drawBackground, bool drawSystemBackground, bool rightToLeft)
    {
      bool useXp = this.fControlPaintStyle.UseXP;
      if (this.fGrid.fAdjustDrawingForPrinter)
        this.fControlPaintStyle.UseXP = false;
      try
      {
        iGIndent contentsIndent = this.GetContentsIndent(rightToLeft, drawSystemBackground);
        int num1 = x;
        int num2 = width;
        int num3 = y;
        int num4 = height;
        int x1 = num1 + contentsIndent.Left;
        int num5 = num2 - (contentsIndent.Left + contentsIndent.Right);
        int y1 = num3 + contentsIndent.Top;
        int height1 = num4 - (contentsIndent.Top + contentsIndent.Bottom);
        iGControlState controlState = !selected ? state : iGControlState.Pressed;
        if (this.fGrid.DoCustomDrawRowHdrBackground(rowIndex, g, new Rectangle(x, y, width, height), state, selected))
        {
          if (drawSystemBackground)
            this.GetEffectiveControlPaintForRowHdr().DrawRowHdr(g, x, y, width, height, controlState, rightToLeft);
          if (drawBackground && (!drawSystemBackground || backColor != this.fControlPaintStyle.BackColor))
          {
            if (this.fHotTracking && state == iGControlState.Hot)
              backColor = iGColorManager.Lighten(backColor, 10);
            using (Brush brush = (Brush) new SolidBrush(backColor))
              g.FillRectangle(brush, x1, y1, num5, height1);
          }
        }
        int num6 = x1;
        int num7 = Math.Min(num5, 15);
        int num8 = y1;
        int num9 = height1;
        if (rightToLeft)
          num6 = 2 * x1 + num5 - num6 - num7;
        if (!this.fGrid.DoCustomDrawRowHdrForeground(rowIndex, g, new Rectangle(num6, num8, num7, num9), new Rectangle(num6 + num7, y1, num5 - num7, height1), state, selected) || glyph == iGRowHdrGlyph.None)
          return;
        iGRowHeader.DrawRowHdrGlyph(g, glyph, num6, num8, num7, num9, rightToLeft);
      }
      finally
      {
        this.fControlPaintStyle.UseXP = useXp;
      }
    }

    private IiGControlPaint GetEffectiveControlPaintForRowHdr()
    {
      if (this.fGrid.fCustomControlPaint != null && (this.fGrid.fCustomControlPaint.SupportedFunctions & iGControlPaintFunctions.RowHdr) == iGControlPaintFunctions.RowHdr)
        return this.fGrid.fCustomControlPaint;
      return (IiGControlPaint) this.fControlPaintStyle.ControlPaint;
    }

    private int GetHGridLinesWidth()
    {
      if (this.fGrid.IsGridLineVisible(this.fHGridLinesStyle, iGOrientation.Horizontal, true))
        return this.fHGridLinesStyle.Width;
      return 0;
    }

    private int GetVGridLinesWidth()
    {
      if (this.fGrid.IsGridLineVisible(this.fVGridLinesStyle, iGOrientation.Vertical, true))
        return this.fVGridLinesStyle.Width;
      return 0;
    }

    private iGIndent GetContentsIndent(bool rightToLeft, bool drawSystem)
    {
      if (drawSystem)
        return this.GetEffectiveControlPaintForRowHdr().GetRowHdrIndent(rightToLeft);
      return new iGIndent();
    }

    internal int GetPreferredHeight(Graphics g, int rowIndex, bool rightToLeft)
    {
      int hgridLinesWidth = this.GetHGridLinesWidth();
      iGIndent contentsIndent = this.GetContentsIndent(rightToLeft, this.fDrawSystem);
      int num1 = hgridLinesWidth + (contentsIndent.Top + contentsIndent.Bottom);
      int glyphAreaHeight = 13;
      int customAreaHeight;
      bool includeIndents;
      this.fGrid.DoCustomDrawRowHdrGetHeight(rowIndex, g, ref glyphAreaHeight, out customAreaHeight, out includeIndents);
      int num2 = customAreaHeight > glyphAreaHeight ? customAreaHeight : glyphAreaHeight;
      if (!includeIndents)
        num2 += num1;
      return num2;
    }

    internal static void DrawRowHdrGlyph(Graphics g, iGRowHdrGlyph glyph, int glyphAreaX, int glyphAreaY, int glyphAreaWidth, int glyphAreaHeight, bool rightToLeft)
    {
      if (g == null)
        throw new ArgumentNullException(nameof (g));
      if (glyphAreaWidth <= 0 || glyphAreaHeight <= 0)
        return;
      if (iGRowHeader.fGlyphCurRow == null)
      {
        iGRowHeader.fGlyphCurRow = (Image) new Bitmap(iGrid.GetResourceStream("RowHdrImageCurRow.gif"));
        iGRowHeader.fGlyphEditing = (Image) new Bitmap(iGrid.GetResourceStream("RowHdrImageEditing.gif"));
        iGRowHeader.fGlyphUncommitedChanges = (Image) new Bitmap(iGrid.GetResourceStream("RowHdrImageUncommitedChanges.gif"));
        iGRowHeader.fGlyphError = (Image) new Bitmap(iGrid.GetResourceStream("RowHdrImageError.png"));
        iGRowHeader.fGlyphNewRow = (Image) new Bitmap(iGrid.GetResourceStream("RowHdrImageNewRow.gif"));
        iGRowHeader.fGlyphCurRowError = (Image) new Bitmap(iGrid.GetResourceStream("RowHdrImageCurRowError.png"));
      }
      Image image;
      switch (glyph)
      {
        case iGRowHdrGlyph.Editing:
          image = iGRowHeader.fGlyphEditing;
          break;
        case iGRowHdrGlyph.UncommittedChanges:
          image = iGRowHeader.fGlyphUncommitedChanges;
          break;
        case iGRowHdrGlyph.NewRow:
          image = iGRowHeader.fGlyphNewRow;
          break;
        case iGRowHdrGlyph.Error:
          image = iGRowHeader.fGlyphError;
          break;
        case iGRowHdrGlyph.CurRowError:
          image = iGRowHeader.fGlyphCurRowError;
          break;
        default:
          image = iGRowHeader.fGlyphCurRow;
          break;
      }
      if (rightToLeft)
      {
        if (!iGRowHeader.fAreGlyphsFlipped)
        {
          iGRowHeader.fGlyphCurRow.RotateFlip(RotateFlipType.RotateNoneFlipX);
          iGRowHeader.fGlyphEditing.RotateFlip(RotateFlipType.RotateNoneFlipX);
          iGRowHeader.fGlyphError.RotateFlip(RotateFlipType.RotateNoneFlipX);
          iGRowHeader.fGlyphCurRowError.RotateFlip(RotateFlipType.RotateNoneFlipX);
          iGRowHeader.fGlyphUncommitedChanges.RotateFlip(RotateFlipType.RotateNoneFlipX);
          iGRowHeader.fAreGlyphsFlipped = true;
        }
      }
      else if (iGRowHeader.fAreGlyphsFlipped)
      {
        iGRowHeader.fGlyphCurRow.RotateFlip(RotateFlipType.RotateNoneFlipX);
        iGRowHeader.fGlyphEditing.RotateFlip(RotateFlipType.RotateNoneFlipX);
        iGRowHeader.fGlyphError.RotateFlip(RotateFlipType.RotateNoneFlipX);
        iGRowHeader.fGlyphCurRowError.RotateFlip(RotateFlipType.RotateNoneFlipX);
        iGRowHeader.fGlyphUncommitedChanges.RotateFlip(RotateFlipType.RotateNoneFlipX);
        iGRowHeader.fAreGlyphsFlipped = false;
      }
      int width = Math.Min(glyphAreaWidth, image.Width);
      int height = Math.Min(glyphAreaHeight, image.Height);
      g.DrawImage(image, new Rectangle(glyphAreaX + (glyphAreaWidth - width) / 2, glyphAreaY + (glyphAreaHeight - height) / 2, width, height), new Rectangle(0, 0, width, height), GraphicsUnit.Pixel);
    }

    internal void OnSettingChange()
    {
      this.fControlPaintStyle.OnSettingChange();
    }

    internal void OnParentColorChanged()
    {
      if (!this.fBackColor.IsEmpty)
        return;
      this.fControlPaintStyle.BackColor = this.fGrid.GetRowHdrParentBackColor();
    }

    /// <summary>Adjusts the width of the row header to fit its contents.</summary>
    public void AutoWidth()
    {
      int vgridLinesWidth = this.GetVGridLinesWidth();
      iGIndent contentsIndent = this.GetContentsIndent(this.fGrid.RightToLeft == RightToLeft.Yes, this.fDrawSystem);
      int num1 = vgridLinesWidth + (contentsIndent.Left + contentsIndent.Right);
      int num2 = 0;
      using (Graphics graphics = this.fGrid.CreateGraphics())
      {
        for (int rowIndex = 0; rowIndex < this.fGrid.Rows.Count; ++rowIndex)
        {
          int glyphAreaWidth = 15;
          int customAreaWidth;
          bool includeIndents;
          this.fGrid.DoCustomDrawRowHdrGetWidth(rowIndex, graphics, ref glyphAreaWidth, out customAreaWidth, out includeIndents);
          int num3 = glyphAreaWidth + customAreaWidth;
          if (!includeIndents)
            num3 += num1;
          if (num3 > num2)
            num2 = num3;
        }
      }
      this.Width = num2;
    }

    private bool ShouldSerializeBackColor()
    {
      return this.BackColor != iGRowHeader.cDefaultBackColor;
    }

    private void ResetBackColor()
    {
      this.BackColor = iGRowHeader.cDefaultBackColor;
    }

    private bool ShouldSerializeHGridLinesStyle()
    {
      return !this.HGridLinesStyle.Equals(iGRowHeader.cDefaultGridLinesStyle);
    }

    private void ResetHGridLinesStyle()
    {
      this.HGridLinesStyle = iGRowHeader.cDefaultGridLinesStyle.Clone();
    }

    private bool ShouldSerializeVGridLinesStyle()
    {
      return !this.VGridLinesStyle.Equals(iGRowHeader.cDefaultGridLinesStyle);
    }

    private void ResetVGridLinesStyle()
    {
      this.VGridLinesStyle = iGRowHeader.cDefaultGridLinesStyle.Clone();
    }

    /// <summary>Gets or sets a value indicating whether the row header is visible.</summary>
    /// <value>True if the row header is visible; otherwise, False. The default is False.</value>
    [DefaultValue(false)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines whether the row header is visible or not.")]
    public bool Visible
    {
      get
      {
        return this.fVisible;
      }
      set
      {
        if (this.fVisible == value)
          return;
        this.fVisible = value;
        if (this.fWidth <= 0)
          return;
        if (this.fGrid.fAutoResizeCols)
          this.fGrid.DoAutoResizeCols(0, 0, false, value, value);
        this.fGrid.RefreshGridAndScrollBarsIfRedraw();
      }
    }

    /// <summary>Gets or sets the width of the row header.</summary>
    /// <value>The wdth of the row header. The default is 19.</value>
    [DefaultValue(19)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The width of the row header.")]
    public int Width
    {
      get
      {
        return this.fWidth;
      }
      set
      {
        if (this.fWidth == value)
          return;
        if (this.fWidth < 0)
          throw new ArgumentOutOfRangeException("cRowHdrWidthLessThanZero");
        this.fWidth = value;
        if (!this.fVisible)
          return;
        if (this.fGrid.fAutoResizeCols)
          this.fGrid.DoAutoResizeCols(0, 0, false, true, true);
        this.fGrid.RefreshGridAndScrollBarsIfRedraw();
      }
    }

    /// <summary>Retrieves the bounds of the row header area. The coordinates are relative to the upper left corner of the grid.</summary>
    /// <value>A <see cref="T:System.Drawing.Rectangle" /> that represents the size and location of the header area. The coordinates are relative to the upper left corner of the grid.</value>
    [Browsable(false)]
    public Rectangle Bounds
    {
      get
      {
        return this.fGrid.GetRowHeaderAreaBounds();
      }
    }

    /// <summary>Gets or sets a value determining whether the headers of separate rows should indicate their hot state.</summary>
    /// <value>True if the hot tracking is active; otherwise, False. The default is True.</value>
    [DefaultValue(true)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines whether the row headers should indicate the hot state.")]
    public bool HotTracking
    {
      get
      {
        return this.fHotTracking;
      }
      set
      {
        if (this.fHotTracking == value)
          return;
        this.fHotTracking = value;
      }
    }

    /// <summary>Gets or sets the style of the row header (3D or Flat). Acts only if <see cref="P:TenTec.Windows.iGridLib.iGRowHeader.DrawSystem" /> is True.</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGControlPaintAppearance" /> enumeration values. The default is <see cref="F:TenTec.Windows.iGridLib.iGControlPaintAppearance.Style3D" />.</value>
    [DefaultValue(iGControlPaintAppearance.Style3D)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The style of the row header (3D or Flat). Acts only if the DrawSystem is True.")]
    public iGControlPaintAppearance Appearance
    {
      get
      {
        return this.fControlPaintStyle.Appearance;
      }
      set
      {
        if (this.fControlPaintStyle.Appearance == value)
          return;
        this.fControlPaintStyle.Appearance = value;
        if (!this.fGrid.fRedraw)
          return;
        this.fGrid.Invalidate();
      }
    }

    /// <summary>Gets or sets a value indicating whether to use the OS visual styles if they are available to display the row header. Acts only if the <see cref="P:TenTec.Windows.iGridLib.iGRowHeader.DrawSystem" /> property is True.</summary>
    /// <value>True if the OS styles are used; otherwise, False. The default is True.</value>
    [DefaultValue(true)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines whether to use the WindowsXP visual styles if they are available to display the row header. Acts only if the DrawSystem is True.")]
    public bool UseXPStyles
    {
      get
      {
        return this.fControlPaintStyle.UseXP;
      }
      set
      {
        if (this.fControlPaintStyle.UseXP == value)
          return;
        this.fControlPaintStyle.UseXP = value;
        if (!this.fGrid.fRedraw)
          return;
        this.fGrid.Invalidate();
      }
    }

    /// <summary>Gets or sets a value indicating whether to display the row header using the system styles. Use in conjunction with the <see cref="P:TenTec.Windows.iGridLib.iGRowHeader.UseXPStyles" /> and <see cref="P:TenTec.Windows.iGridLib.iGRowHeader.Appearance" /> properties.</summary>
    /// <value>True if the row header is drawn using the system styles; otherwise, False. The default is True.</value>
    [DefaultValue(true)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("Determines whether to display the row header using the system styles. Use in conjunction with the the UseXPStyles and Appearance properties.")]
    public bool DrawSystem
    {
      get
      {
        return this.fDrawSystem;
      }
      set
      {
        if (this.fDrawSystem == value)
          return;
        this.fDrawSystem = value;
        if (!this.fGrid.fRedraw)
          return;
        this.fGrid.Invalidate();
      }
    }

    /// <summary>Gets or sets the background color of the row header.</summary>
    /// <value>A color. The default is <see cref="F:System.Drawing.Color.Empty" />, which means that the value is taken from the <see cref="P:TenTec.Windows.iGridLib.iGrid.CellCtrlBackColor" /> property of iGrid.</value>
    [Description("The background color of the row header. If not set, the CellCtrlBackColor is used.")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGColorEmptyAsNotSetConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    public Color BackColor
    {
      get
      {
        return this.fBackColor;
      }
      set
      {
        if (this.BackColor == value)
          return;
        this.fBackColor = value;
        this.fControlPaintStyle.BackColor = !this.fBackColor.IsEmpty ? this.fBackColor : this.fGrid.GetRowHdrParentBackColor();
        if (!this.fGrid.fRedraw)
          return;
        this.fGrid.Invalidate();
      }
    }

    internal Color EffectiveBackColor
    {
      get
      {
        return this.fControlPaintStyle.BackColor;
      }
    }

    /// <summary>Gets or sets the style of the row header's horizontal grid lines. Use this property when <see cref="P:TenTec.Windows.iGridLib.iGRowHeader.DrawSystem" /> is False.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGPenStyle" /> object.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The style of the row header's horizontal grid lines. Use this property when the DrawSystem is False.")]
    public iGPenStyle HGridLinesStyle
    {
      get
      {
        return this.fHGridLinesStyle;
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException();
        if (object.Equals((object) this.fHGridLinesStyle, (object) value))
          return;
        if (value.Width < 0)
          throw new ArgumentOutOfRangeException();
        this.fHGridLinesStyle = value;
        if (!this.fGrid.fRedraw)
          return;
        this.fGrid.Invalidate();
      }
    }

    /// <summary>Gets or sets the style of the row header's vertical grid lines. Use this property when <see cref="P:TenTec.Windows.iGridLib.iGRowHeader.DrawSystem" /> is False.</summary>
    /// <value>An <see cref="T:TenTec.Windows.iGridLib.iGPenStyle" /> object.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Description("The style of the row header's vertical grid lines. Use this property when the DrawSystem is False.")]
    public iGPenStyle VGridLinesStyle
    {
      get
      {
        return this.fVGridLinesStyle;
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException();
        if (object.Equals((object) this.fVGridLinesStyle, (object) value))
          return;
        if (value.Width < 0)
          throw new ArgumentOutOfRangeException();
        this.fVGridLinesStyle = value;
        if (!this.fGrid.fRedraw)
          return;
        this.fGrid.Invalidate();
      }
    }
  }
}
