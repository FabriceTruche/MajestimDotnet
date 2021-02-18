// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGCellEditorBase
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  /// <summary>The base class used for all custom cell editors for iGrid cells.</summary>
  public abstract class iGCellEditorBase
  {
    /// <summary>When implemented in a derived class, returns the control used as the custom cell edit control.</summary>
    /// <value>An instance of the <see cref="T:System.Windows.Forms.Control" /> class used as the edit control for the cell.</value>
    public abstract Control EditControl { get; }

    /// <summary>This method is called by iGrid when it needs to position the custom cell editor in the edited cell.</summary>
    /// <param name="textBounds">The whole rectangle available for displaying cell text.</param>
    /// <param name="suggestedBounds">The suggested cell text rectangle for 1-line cell text that takes into account the vertical cell contents alignment.</param>
    public abstract void SetBounds(Rectangle textBounds, Rectangle suggestedBounds);

    /// <summary>This method is called by iGrid when it needs to set the rendering mode for the text in the custom cell editor.</summary>
    /// <param name="textRenderingHint">The text rendering mode of the parent iGrid control.</param>
    public virtual void SetTextRenderingHint(TextRenderingHint textRenderingHint)
    {
    }

    /// <summary>When overridden in a derived class, gets or sets a Boolean value that indicates whether the value of the edited cell is passed as text to the custom cell editor.</summary>
    /// <value>A Boolean value that indicates whether the value of the edited cell is passed as text to the custom cell editor.</value>
    public virtual bool PassValueAsText
    {
      get
      {
        return true;
      }
    }

    /// <summary>When implemented in a derived class, gets or sets the cell value for editing.</summary>
    /// <value>The value of the edited cell.</value>
    public virtual object Value { get; set; }

    /// <summary>When implemented in a derived class, gets or sets a character index for the beginning of the current selection in the custom cell editor.</summary>
    /// <value>A character index for the beginning of the current selection in the custom cell editor.</value>
    public virtual int SelectionStart { get; set; }

    /// <summary>When implemented in a derived class, gets or sets a value indicating the number of characters in the current selection in the custom cell editor.</summary>
    /// <value>The length of the selected text in the custom cell editor.</value>
    public virtual int SelectionLength { get; set; }

    /// <summary>When implemented in a derived class, gets or sets the selected text in the custom cell editor.</summary>
    /// <value>A string that represents the selected text in the custom cell editor.</value>
    public virtual string SelectedText { get; set; }

    /// <summary>When implemented in a derived class, gets or sets the maximum number of characters that can be entered into the cell.</summary>
    /// <value>The maximum number of characters that can be entered into the cell.</value>
    public virtual int MaxInputLength { get; set; }

    /// <summary>When implemented in a derived class, gets or sets the horizontal alignment of the contents in the custom cell edit control.</summary>
    /// <value>The horizontal alignment of the contents in the custom cell edit control.</value>
    public virtual HorizontalAlignment TextAlign { get; set; }

    /// <summary>When implemented in a derived class, gets or sets the vertical alignment of the contents in the custom cell edit control.</summary>
    /// <value>The vertical alignment of the contents in the custom cell edit control.</value>
    public virtual StringAlignment LineAlign { get; set; }

    /// <summary>When implemented in a derived class, gets or sets a Boolean value that indicates whether word wrapping is allowed in the cell editor.</summary>
    /// <value>A Boolean value that indicates whether word wrapping is allowed in the cell editor.</value>
    public virtual bool WordWrap { get; set; }

    /// <summary>When implemented in a derived class, gets or sets a Boolean value that indicates whether the cell contents can be edited as multiline text.</summary>
    /// <value>A Boolean value that indicates whether the cell contents can be edited as multiline text.</value>
    public virtual bool Multiline { get; set; }

    /// <summary>When implemented in a derived class, gets or sets the password character for the cell editor.</summary>
    /// <value>The password character for the cell editor.</value>
    public virtual char PasswordChar { get; set; }
  }
}
