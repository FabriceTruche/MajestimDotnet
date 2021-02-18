// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGBeforeCommitEditEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.BeforeCommitEdit" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGBeforeCommitEditEventArgs : EventArgs
  {
    /// <summary>The row index of the cell being edited.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the cell being edited or -1 if it is a row text cell.</summary>
    public readonly int ColIndex;
    /// <summary>The value indicating whether to cancel, commit or proceed editing.</summary>
    public iGEditResult Result;
    /// <summary>The text entered to the cell being edited.</summary>
    public readonly string NewText;
    /// <summary>The new value of the cell being edited.</summary>
    public object NewValue;
    /// <summary>The new image index of the cell being edited.</summary>
    public int NewImageIndex;
    /// <summary>The item that was selected in the drop-down control and will be attached to the cell being edited.</summary>
    public object NewDropDownControlItem;
    /// <summary>The exception occurred while the grid was trying to parse the entered text.</summary>
    public readonly Exception Exception;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGBeforeCommitEditEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the cell being edited.</param>
    /// <param name="colIndex">The column index of the cell being edited or -1 if it is a row text cell.</param>
    /// <param name="newText">The text entered to the cell being edited.</param>
    /// <param name="newValue">The new value of the cell being edited.</param>
    /// <param name="newImageIndex">The new image index of the cell being edited.</param>
    /// <param name="newDropDownControlItem">The item that was selected in the drop-down control and will be attached to the cell being edited.</param>
    /// <param name="exception">The exception occurred while the grid was trying to parse the entered text.</param>
    public iGBeforeCommitEditEventArgs(int rowIndex, int colIndex, string newText, object newValue, int newImageIndex, object newDropDownControlItem, Exception exception)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
      this.Result = iGEditResult.Commit;
      this.NewText = newText;
      this.NewValue = newValue;
      this.NewImageIndex = newImageIndex;
      this.NewDropDownControlItem = newDropDownControlItem;
      this.Exception = exception;
    }
  }
}
