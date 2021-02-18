// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGDefaultTextEditor
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.Drawing;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  internal class iGDefaultTextEditor : iGCellEditorBase
  {
    private TextBox fTextBox = new TextBox();

    public iGDefaultTextEditor()
    {
      this.fTextBox.AutoSize = false;
      this.fTextBox.BorderStyle = BorderStyle.None;
      this.fTextBox.AcceptsReturn = true;
    }

    public override Control EditControl
    {
      get
      {
        return (Control) this.fTextBox;
      }
    }

    public override void SetBounds(Rectangle textBounds, Rectangle suggestedBounds)
    {
      this.fTextBox.Bounds = suggestedBounds;
    }

    public override int SelectionStart
    {
      get
      {
        return this.fTextBox.SelectionStart;
      }
      set
      {
        this.fTextBox.SelectionStart = value;
      }
    }

    public override int SelectionLength
    {
      get
      {
        return this.fTextBox.SelectionLength;
      }
      set
      {
        this.fTextBox.SelectionLength = value;
      }
    }

    public override string SelectedText
    {
      get
      {
        return this.fTextBox.SelectedText;
      }
      set
      {
        this.fTextBox.SelectedText = value;
      }
    }

    public override int MaxInputLength
    {
      get
      {
        return this.fTextBox.MaxLength;
      }
      set
      {
        this.fTextBox.MaxLength = value;
      }
    }

    public override HorizontalAlignment TextAlign
    {
      get
      {
        return this.fTextBox.TextAlign;
      }
      set
      {
        this.fTextBox.TextAlign = value;
      }
    }

    public override bool WordWrap
    {
      get
      {
        return this.fTextBox.WordWrap;
      }
      set
      {
        this.fTextBox.WordWrap = value;
      }
    }

    public override bool Multiline
    {
      get
      {
        return this.fTextBox.Multiline;
      }
      set
      {
        this.fTextBox.Multiline = value;
      }
    }

    public override char PasswordChar
    {
      get
      {
        return this.fTextBox.PasswordChar;
      }
      set
      {
        this.fTextBox.PasswordChar = value;
      }
    }
  }
}
