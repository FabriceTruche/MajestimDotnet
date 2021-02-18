// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGTextBoxKeyEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.TextBoxKeyDown" /> and <see cref="E:TenTec.Windows.iGridLib.iGrid.TextBoxKeyUp" /> events of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGTextBoxKeyEventArgs : EventArgs
  {
    /// <summary>The row index of the cell being edited.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the cell being edited, or -1 if it is a row text cell.</summary>
    public readonly int ColIndex;
    /// <summary>The key data.</summary>
    public readonly Keys KeyData;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGTextBoxKeyEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the cell being edited.</param>
    /// <param name="colIndex">The column index of the cell being edited, or -1 if it is a row text cell.</param>
    /// <param name="keyData">The key data.</param>
    public iGTextBoxKeyEventArgs(int rowIndex, int colIndex, Keys keyData)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
      this.KeyData = keyData;
    }

    /// <summary>Gets a value indicating whether the ALT key is pressed.</summary>
    /// <value>True if the ALT key was pressed; otherwise, False.</value>
    public bool Alt
    {
      get
      {
        return (this.KeyData & Keys.Alt) == Keys.Alt;
      }
    }

    /// <summary>Gets a value indicating whether the CTRL key is pressed.</summary>
    /// <value>True if the CTRL key was pressed; otherwise, False.</value>
    public bool Control
    {
      get
      {
        return (this.KeyData & Keys.Control) == Keys.Control;
      }
    }

    /// <summary>Gets a value indicating whether the SHIFT key is pressed.</summary>
    /// <value>True if the SHIFT key was pressed; otherwise, False.</value>
    public bool Shift
    {
      get
      {
        return (this.KeyData & Keys.Shift) == Keys.Shift;
      }
    }

    /// <summary>Gets the keyboard value.</summary>
    /// <value>The integer representation of the <see cref="F:TenTec.Windows.iGridLib.iGTextBoxKeyEventArgs.KeyData" /> field.</value>
    public Keys KeyValue
    {
      get
      {
        return this.KeyData & Keys.KeyCode;
      }
    }

    /// <summary>Indicates which of the modifier keys (SHIFT, CTRL, and ALT) was in a pressed state.</summary>
    /// <value>A <see cref="T:System.Windows.Forms.Keys" /> value representing one or more modifier flags.</value>
    public Keys Modifiers
    {
      get
      {
        return this.KeyData & Keys.Modifiers;
      }
    }
  }
}
