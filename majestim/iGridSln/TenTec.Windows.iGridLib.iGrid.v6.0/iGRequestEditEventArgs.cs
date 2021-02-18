// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGRequestEditEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.RequestEdit" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGRequestEditEventArgs : EventArgs
  {
    /// <summary>The row index of the cell to be edited.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the cell to be edited or -1 if it is a row text cell.</summary>
    public readonly int ColIndex;
    /// <summary>The char of the key the user has pressed to start editing.</summary>
    public readonly char KeyChar;
    /// <summary>The text to be placed in the text box. You can use this parameter to change the cell text which will be edited.</summary>
    public string Text;
    /// <summary>Determines whether to start editing.</summary>
    public bool DoDefault;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGRequestEditEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the cell to be edited.</param>
    /// <param name="colIndex">The column index of the cell to be edited.</param>
    /// <param name="keyChar">The char of the key the user has pressed to start editing.</param>
    /// <param name="text">The text to be placed in the text box.</param>
    /// <param name="doDefault">Determines whether to start editing.</param>
    public iGRequestEditEventArgs(int rowIndex, int colIndex, char keyChar, string text, bool doDefault)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
      this.KeyChar = keyChar;
      this.Text = text;
      this.DoDefault = doDefault;
    }
  }
}
