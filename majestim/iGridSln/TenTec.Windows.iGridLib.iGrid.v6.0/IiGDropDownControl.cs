// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.IiGDropDownControl
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents a control that can be used as a drop-down list in an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public interface IiGDropDownControl
  {
    /// <summary>When implemented in a class, returns the drop-down control item by the value associated with it.</summary>
    /// <param name="value">The value to retrieve the item by.</param>
    /// <param name="firstByOrder">Determines whether the first by order item should be retrieved.</param>
    /// <returns>The drop-down control item that corresponds to the specified value.</returns>
    object GetItemByValue(object value, bool firstByOrder);

    /// <summary>When implemented in a class, returns the drop-down control item by its text representation.</summary>
    /// <param name="text">The text to retrieve the item by.</param>
    /// <returns>The drop-down control item that corresponds to the specified text.</returns>
    object GetItemByText(string text);

    /// <summary>When implemented in a class, returns the index of the image associated with the drop-down control item or -1 if there is no associated image.</summary>
    /// <param name="item">The item which image index to retrieve.</param>
    /// <returns>The image index of the specified item.</returns>
    int GetItemImageIndex(object item);

    /// <summary>When implemented in a class, returns the value that is associated with the drop-down control item.</summary>
    /// <param name="item">The item which value to retrieve.</param>
    /// <returns>The value of the specified item.</returns>
    object GetItemValue(object item);

    /// <summary>When implemented in a class, returns an instance of the <see cref="T:System.Windows.Forms.Control" /> class to be shown in the drop-down form.</summary>
    /// <param name="grid">A grid which the drop-down control is attached to.</param>
    /// <param name="font">The font of the cell which the drop-down control is to be shown for.</param>
    /// <param name="interfaceType">The type of the interface the drop-down control is requested for (either <see cref="T:TenTec.Windows.iGridLib.IiGDropDownControl" /> or <see cref="T:TenTec.Windows.iGridLib.IiGAutoCompleteControl" />)</param>
    /// <returns>The control.</returns>
    Control GetDropDownControl(iGrid grid, Font font, Type interfaceType);

    /// <summary>When implemented in a class, this callback method is invoked by iGrid when it needs to set the rendering mode for the text in the drop-down control.</summary>
    /// <param name="textRenderingHint">The text rendering mode of the parent iGrid control.</param>
    void SetTextRenderingHint(TextRenderingHint textRenderingHint);

    /// <summary>When implemented in a class, this callback method is invoked after the drop-down control is about to be shown.</summary>
    void OnShowing();

    /// <summary>When implemented in a class, this callback method is invoked after the drop-down control has been shown.</summary>
    void OnShow();

    /// <summary>When implemented in a class, this callback method is invoked after the drop-down control has been hidden.</summary>
    void OnHide();

    /// <summary>When implemented in a class, gets or sets the selected item in the drop-down control.</summary>
    /// <value>The selected item in the drop-down control.</value>
    object SelectedItem { get; set; }

    /// <summary>When implemented in a class, gets a value indicating whether to save the drop-down control value to the cell after the drop-down form is hidden owing to losing of the focus (mouse was clicked out of the form or the user switched to other application).</summary>
    /// <value>True if editing should be committed; otherwise, False.</value>
    bool CommitOnHide { get; }

    /// <summary>When implemented in a class, gets the image list used to display the icons in the drop-down control.</summary>
    /// <value>The image list used to display the icons in the drop-down control.</value>
    ImageList ImageList { get; }

    /// <summary>When implemented in a class, gets the width of the drop-down control, or -1 if the drop-down form's width should be calculated according to the width of the cell for which it is shown.</summary>
    /// <value>The width of the drop-down control, or -1 if the drop-down form's width should be calculated according to the width of the cell for which it is shown.</value>
    int Width { get; }

    /// <summary>When implemented in a class, gets the height of the drop-down control.</summary>
    /// <value>The height of the drop-down control.</value>
    int Height { get; }

    /// <summary>When implemented in a class, gets a value indicating whether the drop-down form can be resized by the user. If True, the form will have the sizable border.</summary>
    /// <value>True if the form is sizeable; otherwise, False.</value>
    bool Sizeable { get; }

    /// <summary>When implemented in a class, determines whether the text entered into a combo box cell is substituted with the corresponding item from the drop-down list when you hit the ENTER key.</summary>
    /// <value>A Boolean value that indicates whether to substitute the entered text with the corresponding drop-down list item.</value>
    bool AutoSubstitution { get; }

    /// <summary>When implemented in a class, gets a string used as the title of the drop-down box.</summary>
    /// <value>A string used as the title of the drop-down box.</value>
    string Text { get; }

    /// <summary>When implemented in a class, determines whether the drop-down box will have the close button like a normal window.</summary>
    /// <value>A Boolean value that indicates whether the drop-down box will have the close button like a normal window.</value>
    bool CloseButton { get; }

    /// <summary>When implemented in a class, gets a Boolean value that indicates whether the drop-down control displayed from a column header should be closed while performing some methods (grouping, etc).</summary>
    /// <value>A Boolean value that indicates whether the drop-down control displayed from a column header should be closed while performing some methods (grouping, etc).</value>
    bool HideColHdrDropDown { get; }
  }
}
