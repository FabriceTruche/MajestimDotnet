﻿// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGRequestAutoCompleteControlEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.RequestAutoCompleteControl" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGRequestAutoCompleteControlEventArgs : EventArgs
  {
    /// <summary>The row index of the cell for which the auto-complete control is being requested.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the cell for which the auto-complete control is being requested, or -1 if it is a row text column.</summary>
    public readonly int ColIndex;
    /// <summary>The auto-complete control to be used in the cell.</summary>
    public IiGAutoCompleteControl Control;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGRequestAutoCompleteControlEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the cell for which the auto-complete control is being requested.</param>
    /// <param name="colIndex">The column index of the cell for which the auto-complete control is being requested, or -1 if it is a row text cell.</param>
    /// <param name="control">The auto-complete control to be used in the cell.</param>
    public iGRequestAutoCompleteControlEventArgs(int rowIndex, int colIndex, IiGAutoCompleteControl control)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
      this.Control = control;
    }
  }
}
