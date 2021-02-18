// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGTextBox
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.ComponentModel;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents the text box used to edit the text and combo box cells in an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGTextBox
  {
    private iGrid fGrid;

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

    internal iGTextBox(iGrid grid)
    {
      this.fGrid = grid;
    }

    /// <summary>Gets or sets the starting point of the text selected in the text box.</summary>
    /// <value>The starting position of text selected in the text box.</value>
    public int SelectionStart
    {
      get
      {
        return this.fGrid.GetTextBoxSelectionStart();
      }
      set
      {
        this.fGrid.SetTextBoxSelectionStart(value);
      }
    }

    /// <summary>Gets or sets the number of characters selected in the text box.</summary>
    /// <value>The number of characters selected in the text box.</value>
    public int SelectionLength
    {
      get
      {
        return this.fGrid.GetTextBoxSelectionLength();
      }
      set
      {
        this.fGrid.SetTextBoxSelectionLength(value);
      }
    }

    /// <summary>Gets or sets the currently selected text in the text box.</summary>
    /// <value>A string that represents the currently selected text in the text box.</value>
    public string SelectedText
    {
      get
      {
        return this.fGrid.GetTextBoxSelectedText();
      }
      set
      {
        this.fGrid.SetTextBoxSelectedText(value);
      }
    }

    /// <summary>Gets or sets the text displayed in the text box.</summary>
    /// <value>The text displayed in the control.</value>
    public string Text
    {
      get
      {
        return this.fGrid.GetTextBoxText();
      }
      set
      {
        this.fGrid.SetTextBoxText(value);
      }
    }
  }
}
