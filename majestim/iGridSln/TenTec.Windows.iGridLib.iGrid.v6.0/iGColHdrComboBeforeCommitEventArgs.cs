// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGColHdrComboBeforeCommitEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.ColHdrComboBeforeCommit" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGColHdrComboBeforeCommitEventArgs : EventArgs
  {
    /// <summary>The row index of the edited column header.</summary>
    public readonly int RowIndex;
    /// <summary>The column index of the edited column header.</summary>
    public readonly int ColIndex;
    /// <summary>The value indicating whether to cancel, commit or proceed editing.</summary>
    public iGEditResult Result;
    /// <summary>The value of the selected drop-down control item.</summary>
    public object NewValue;
    /// <summary>The image index of the selected drop-down control item.</summary>
    public int NewImageIndex;
    /// <summary>The selected drop-down control item.</summary>
    public object NewDropDownControlItem;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGColHdrComboBeforeCommitEventArgs" /> class.</summary>
    /// <param name="rowIndex">The row index of the edited column header.</param>
    /// <param name="colIndex">The column index of the edited column header.</param>
    /// <param name="newValue">The value of the selected drop-down control item.</param>
    /// <param name="newImageIndex">The image index of the selected drop-down control item.</param>
    /// <param name="newDropDownControlItem">The selected drop-down control item.</param>
    public iGColHdrComboBeforeCommitEventArgs(int rowIndex, int colIndex, object newValue, int newImageIndex, object newDropDownControlItem)
    {
      this.RowIndex = rowIndex;
      this.ColIndex = colIndex;
      this.Result = iGEditResult.Commit;
      this.NewValue = newValue;
      this.NewImageIndex = newImageIndex;
      this.NewDropDownControlItem = newDropDownControlItem;
    }
  }
}
