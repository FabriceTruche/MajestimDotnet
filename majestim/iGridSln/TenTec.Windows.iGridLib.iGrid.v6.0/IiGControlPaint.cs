// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.IiGControlPaint
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.Drawing;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents an object used for custom drawing of the constituent parts of iGrid.</summary>
  public interface IiGControlPaint
  {
    /// <summary>When implemented in a class, indicates which iGrid parts are drawn by the class.</summary>
    /// <value>A set of the flags from the <see cref="T:TenTec.Windows.iGridLib.iGControlPaintFunctions" /> flag enumeration that defines what iGrid parts use custom drawing.</value>
    iGControlPaintFunctions SupportedFunctions { get; }

    /// <summary>When implemented in a class, performs the custom drawing of all parts of iGrid's scroll bars.</summary>
    /// <param name="g">A <see cref="T:System.Drawing.Graphics" /> object to draw on.</param>
    /// <param name="x">The x-coordinate of the top-left corner of the item.</param>
    /// <param name="y">The y-coordinate of the top-left corner of the item.</param>
    /// <param name="width">The width of the item.</param>
    /// <param name="height">The height of the item.</param>
    /// <param name="scrollPart">The constituent part of the scroll bar (see <see cref="T:TenTec.Windows.iGridLib.iGScrollBarPart" />).</param>
    /// <param name="controlState">The look of the item (pressed/disabled/hot/etc, see <see cref="T:TenTec.Windows.iGridLib.iGControlState" />).</param>
    void DrawScrollBar(Graphics g, int x, int y, int width, int height, iGScrollBarPart scrollPart, iGControlState controlState);

    /// <summary>When implemented in a class, returns the internal indent in the scroll bar custom buttons.</summary>
    /// <value>A <see cref="T:TenTec.Windows.iGridLib.iGIndent" /> structure that defines the internal indent in the scroll bar custom buttons.</value>
    iGIndent GetScrollBarCustomButtonIndent { get; }

    /// <summary>When implemented in a class, indicates that the scroll bar custom buttons should be drawn shifted by 1 pixel when pressed.</summary>
    /// <value>A Boolean value that indicates that the scroll bar custom buttons should be drawn shifted by 1 pixel when pressed.</value>
    bool OffsetScrollBarCustomButtonImageWhenPressed { get; }

    /// <summary>When implemented in a class, performs the drawing of the custom buttons on the scroll bars.</summary>
    /// <param name="g">A <see cref="T:System.Drawing.Graphics" /> object to draw on.</param>
    /// <param name="x">The x-coordinate of the top-left corner of the item.</param>
    /// <param name="y">The y-coordinate of the top-left corner of the item.</param>
    /// <param name="width">The width of the item.</param>
    /// <param name="height">The height of the item.</param>
    /// <param name="controlState">The look of the item (pressed/disabled/hot/etc, see <see cref="T:TenTec.Windows.iGridLib.iGControlState" />).</param>
    void DrawScrollBarCustomButton(Graphics g, int x, int y, int width, int height, iGControlState controlState);

    /// <summary>When implemented in a class, returns the size of the custom check box.</summary>
    /// <returns>A <see cref="T:System.Drawing.Size" /> structure that defines the size of the custom check box.</returns>
    Size GetCheckBoxSize();

    /// <summary>When implemented in a class, performs the custom drawing of the cell check box control.</summary>
    /// <param name="g">A <see cref="T:System.Drawing.Graphics" /> object to draw on.</param>
    /// <param name="x">The x-coordinate of the top-left corner of the item.</param>
    /// <param name="y">The y-coordinate of the top-left corner of the item.</param>
    /// <param name="width">The width of the item.</param>
    /// <param name="height">The height of the item.</param>
    /// <param name="checkState">The state of the check box (unchecked/checked/grayed, see the .NET <see cref="T:System.Windows.Forms.CheckState" /> enumeration).</param>
    /// <param name="controlState">The look of the item (pressed/disabled/hot/etc, see <see cref="T:TenTec.Windows.iGridLib.iGControlState" />).</param>
    void DrawCheckBox(Graphics g, int x, int y, int width, int height, CheckState checkState, iGControlState controlState);

    /// <summary>When implemented in a class, performs the custom drawing of the cell combo button control.</summary>
    /// <param name="g">A <see cref="T:System.Drawing.Graphics" /> object to draw on.</param>
    /// <param name="x">The x-coordinate of the top-left corner of the item.</param>
    /// <param name="y">The y-coordinate of the top-left corner of the item.</param>
    /// <param name="width">The width of the item.</param>
    /// <param name="height">The height of the item.</param>
    /// <param name="controlState">The look of the item (pressed/disabled/hot/etc, see <see cref="T:TenTec.Windows.iGridLib.iGControlState" />).</param>
    /// <param name="isHeader">Indicates whether the combo button is drawn in a column header (True if so, False if it is done for normal cells).</param>
    void DrawComboButton(Graphics g, int x, int y, int width, int height, iGControlState controlState, bool isHeader);

    /// <summary>When implemented in a class, performs the custom drawing of the cell ellipsis button control.</summary>
    /// <param name="g">A <see cref="T:System.Drawing.Graphics" /> object to draw on.</param>
    /// <param name="x">The x-coordinate of the top-left corner of the item.</param>
    /// <param name="y">The y-coordinate of the top-left corner of the item.</param>
    /// <param name="width">The width of the item.</param>
    /// <param name="height">The height of the item.</param>
    /// <param name="controlState">The look of the item (pressed/disabled/hot/etc, see <see cref="T:TenTec.Windows.iGridLib.iGControlState" />).</param>
    void DrawEllipsisButton(Graphics g, int x, int y, int width, int height, iGControlState controlState);

    /// <summary>When implemented in a class, returns the size of the custom tree buttons.</summary>
    /// <returns>A <see cref="T:System.Drawing.Size" /> structure that defines the size of the custom tree buttons.</returns>
    Size GetTreeButtonSize();

    /// <summary>When implemented in a class, performs the custom drawing of the tree or plus/minus button.</summary>
    /// <param name="g">A <see cref="T:System.Drawing.Graphics" /> object to draw on.</param>
    /// <param name="x">The x-coordinate of the top-left corner of the item.</param>
    /// <param name="y">The y-coordinate of the top-left corner of the item.</param>
    /// <param name="width">The width of the item.</param>
    /// <param name="height">The height of the item.</param>
    /// <param name="expanded">A Boolean value that indicates whether the row is expanded (the minus sign) or collapsed (the plus sign). The corresponding values are True and False respectively.</param>
    void DrawTreeButton(Graphics g, int x, int y, int width, int height, bool expanded);

    /// <summary>When implemented in a class, returns the size of the sort icon inside column headers.</summary>
    /// <returns>A <see cref="T:System.Drawing.Size" /> structure that defines the size of the sort icon inside column headers.</returns>
    Size GetHeaderSortIconSize();

    /// <summary>When implemented in a class, returns the internal indent in every column header.</summary>
    /// <param name="rightToLeft">A Boolean value that indicates whether the drawing is performed in the right-to-left environment.</param>
    /// <returns>A <see cref="T:TenTec.Windows.iGridLib.iGIndent" /> structure that defines the column header indent.</returns>
    iGIndent GetHeaderIndent(bool rightToLeft);

    /// <summary>When implemented in a class, performs the custom drawing of all parts of iGrid's header.</summary>
    /// <param name="g">A <see cref="T:System.Drawing.Graphics" /> object to draw on.</param>
    /// <param name="x">The x-coordinate of the top-left corner of the item.</param>
    /// <param name="y">The y-coordinate of the top-left corner of the item.</param>
    /// <param name="width">The width of the item.</param>
    /// <param name="height">The height of the item.</param>
    /// <param name="headerPart">The constituent part of the header (see <see cref="T:TenTec.Windows.iGridLib.iGHeaderPart" />).</param>
    /// <param name="controlState">The look of the item (pressed/disabled/hot/etc, see <see cref="T:TenTec.Windows.iGridLib.iGControlState" />).</param>
    /// <param name="rightToLeft">A Boolean value that indicates whether the drawing is performed in the right-to-left environment.</param>
    void DrawHeader(Graphics g, int x, int y, int width, int height, iGHeaderPart headerPart, iGControlState controlState, bool rightToLeft);

    /// <summary>When implemented in a class, returns the internal indent in every row header.</summary>
    /// <param name="rightToLeft">A Boolean value that indicates whether the drawing is performed in the right-to-left environment.</param>
    /// <returns>A <see cref="T:TenTec.Windows.iGridLib.iGIndent" /> structure that defines the row header indent.</returns>
    iGIndent GetRowHdrIndent(bool rightToLeft);

    /// <summary>When implemented in a class, performs the custom drawing of the row header.</summary>
    /// <param name="g">A <see cref="T:System.Drawing.Graphics" /> object to draw on.</param>
    /// <param name="x">The x-coordinate of the top-left corner of the item.</param>
    /// <param name="y">The y-coordinate of the top-left corner of the item.</param>
    /// <param name="width">The width of the item.</param>
    /// <param name="height">The height of the item.</param>
    /// <param name="controlState">The look of the item (pressed/disabled/hot/etc, see <see cref="T:TenTec.Windows.iGridLib.iGControlState" />).</param>
    /// <param name="rightToLeft">A Boolean value that indicates whether the drawing is performed in the right-to-left environment.</param>
    void DrawRowHdr(Graphics g, int x, int y, int width, int height, iGControlState controlState, bool rightToLeft);

    /// <summary>When implemented in a class, performs the custom drawing of the size box (size grip) in the bottom-right corner of iGrid.</summary>
    /// <param name="g">A <see cref="T:System.Drawing.Graphics" /> object to draw on.</param>
    /// <param name="x">The x-coordinate of the top-left corner of the item.</param>
    /// <param name="y">The y-coordinate of the top-left corner of the item.</param>
    /// <param name="width">The width of the item.</param>
    /// <param name="height">The height of the item.</param>
    /// <param name="align">The size box alignment (the bottom-left or bottom-right corner, see the <see cref="T:TenTec.Windows.iGridLib.iGSizeBoxAlign" /> enumeration).</param>
    void DrawSizeBox(Graphics g, int x, int y, int width, int height, iGSizeBoxAlign align);

    /// <summary>When implemented in a class, performs the custom drawing of the background of iGrid's group box.</summary>
    /// <param name="g">A <see cref="T:System.Drawing.Graphics" /> object to draw on.</param>
    /// <param name="x">The x-coordinate of the top-left corner of the item.</param>
    /// <param name="y">The y-coordinate of the top-left corner of the item.</param>
    /// <param name="width">The width of the item.</param>
    /// <param name="height">The height of the item.</param>
    /// <param name="rightToLeft">A Boolean value that indicates whether the drawing is performed in the right-to-left environment.</param>
    void DrawGroupBoxBackground(Graphics g, int x, int y, int width, int height, bool rightToLeft);

    /// <summary>When implemented in a class, returns the color used to draw the main contents of such controls as combo buttons, check boxes, etc.</summary>
    /// <value>A <see cref="T:System.Drawing.Color" /> value used to draw the main contents of such controls as combo buttons, check boxes, etc.</value>
    Color ControlsForeColor { get; }

    /// <summary>When implemented in a class, returns the color used to paint the background of such controls as combo buttons, check boxes, etc.</summary>
    /// <value>A <see cref="T:System.Drawing.Color" /> value used to paint the background of such controls as combo buttons, check boxes, etc.</value>
    Color ControlsBackColor { get; }

    /// <summary>When implemented in a class, returns the color used to draw the main contents of such controls as combo buttons, check boxes, etc in the case when they are disabled.</summary>
    /// <value>A <see cref="T:System.Drawing.Color" /> value used to draw the main contents of such controls as combo buttons, check boxes, etc in the case when they are disabled.</value>
    Color ControlsDisabledForeColor { get; }

    /// <summary>When implemented in a class, this method is raised by iGrid when a system-wide setting was changed.</summary>
    void OnSettingChange();
  }
}
