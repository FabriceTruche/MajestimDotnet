// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.IiGAutoCompleteControl
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents a control that can be used as an auto-complete list in an iGrid control.</summary>
  public interface IiGAutoCompleteControl : IiGDropDownControl
  {
    /// <summary>When implemented in a derived class, is invoked by iGrid when the text in a cell is changed while editing this cell as text.</summary>
    /// <param name="text">Provides you with the text entered to the cell which is being edited.</param>
    /// <returns>Indicates whether the auto-complete control has items which match the entered text and it should be displayed.</returns>
    bool OnCellTextChange(string text);

    /// <summary>When implemented in a derived class, processes the key down event when a cell is being edited as text.</summary>
    /// <param name="e">The arguments of the text box's key down event.</param>
    void ProcessKeyDown(KeyEventArgs e);

    /// <summary>When implemented in a derived class, processes the key press event when a cell is being edited as text.</summary>
    /// <param name="e">The arguments of the text box's key press event.</param>
    void ProcessKeyPress(KeyPressEventArgs e);

    /// <summary>When implemented in a derived class, processes the key up event when a cell is being edited as text.</summary>
    /// <param name="e">The arguments of the text box's key up event.</param>
    void ProcessKeyUp(KeyEventArgs e);

    /// <summary>When implemented in a derived class, occurs when a value in the auto-complete control is selected and editing should be finished.</summary>
    event iGAutoCompleteControlValueSelectedEventHandler ValueSelected;
  }
}
