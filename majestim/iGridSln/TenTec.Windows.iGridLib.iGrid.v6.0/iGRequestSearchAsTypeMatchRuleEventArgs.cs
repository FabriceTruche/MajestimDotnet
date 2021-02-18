// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGRequestSearchAsTypeMatchRuleEventArgs
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Provides data for the <see cref="E:TenTec.Windows.iGridLib.iGrid.RequestSearchAsTypeMatchRule" /> event of an <see cref="T:TenTec.Windows.iGridLib.iGrid" /> control.</summary>
  public class iGRequestSearchAsTypeMatchRuleEventArgs : EventArgs
  {
    /// <summary>The index of the column which match rule is being requested or -1 if it is a row text column.</summary>
    public readonly int ColIndex;
    /// <summary>The match rule of the column.</summary>
    public iGMatchRule MatchRule;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGRequestSearchAsTypeMatchRuleEventArgs" /> class.</summary>
    /// <param name="colIndex">The index of the column which match rule is being requested.</param>
    /// <param name="matchRule">The match rule of the column.</param>
    public iGRequestSearchAsTypeMatchRuleEventArgs(int colIndex, iGMatchRule matchRule)
    {
      this.ColIndex = colIndex;
      this.MatchRule = matchRule;
    }
  }
}
