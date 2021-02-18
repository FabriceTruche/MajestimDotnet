// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGIndent
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.ComponentModel;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents the indents of a cell or column header contents.</summary>
  [TypeConverter("TenTec.Windows.iGridLib.Design.iGIndentConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
  public struct iGIndent
  {
    internal static iGIndent fNotSetIndent = new iGIndent(-1, -1, -1, -1);
    /// <summary>A special value used to indicate that an indent isn't specified.</summary>
    public const int ConstNotSetFieldValue = -1;
    internal int fLeft;
    internal int fTop;
    internal int fRight;
    internal int fBottom;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGIndent" /> structure that has the specified uniform indent on each side.</summary>
    /// <param name="uniformIndent">The uniform indent applied to all four sides of the bounding rectangle.</param>
    public iGIndent(int uniformIndent)
    {
      if (uniformIndent < 0)
        uniformIndent = -1;
      this.fLeft = uniformIndent;
      this.fRight = uniformIndent;
      this.fTop = uniformIndent;
      this.fBottom = uniformIndent;
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGIndent" /> structure that has specific indents applied to each side of the rectangle.</summary>
    /// <param name="left">Specifies the left indent of cell or column header contents.</param>
    /// <param name="top">Specifies the top indent of cell or column header contents.</param>
    /// <param name="right">Specifies the right indent of cell or column header contents.</param>
    /// <param name="bottom">Specifies the bottom indent of cell or column header contents.</param>
    public iGIndent(int left, int top, int right, int bottom)
    {
      if (left < 0)
        left = -1;
      if (right < 0)
        right = -1;
      if (top < 0)
        top = -1;
      if (bottom < 0)
        bottom = -1;
      this.fLeft = left;
      this.fRight = right;
      this.fTop = top;
      this.fBottom = bottom;
    }

    /// <summary>Returns a value indicating whether this instance is equal to the specified object.</summary>
    /// <param name="obj">An object to compare this instance to.</param>
    /// <returns>True if obj is an <see cref="T:TenTec.Windows.iGridLib.iGIndent" /> and has the same value as this instance; otherwise, False.</returns>
    public override bool Equals(object obj)
    {
      if (obj == null || obj.GetType() != typeof (iGIndent))
        return base.Equals(obj);
      return this.EqualsTo((iGIndent) obj);
    }

    /// <summary>Returns a hash code for this <see cref="T:TenTec.Windows.iGridLib.iGIndent" />.</summary>
    /// <returns>An integer value that specifies a hash value for this <see cref="T:TenTec.Windows.iGridLib.iGIndent" />.</returns>
    public override int GetHashCode()
    {
      return this.fLeft ^ this.fRight ^ this.fTop ^ this.fBottom;
    }

    /// <summary>Returns a value indicating whether this instance is equal to the specified <see cref="T:TenTec.Windows.iGridLib.iGIndent" /> object.</summary>
    /// <param name="value">An <see cref="T:TenTec.Windows.iGridLib.iGIndent" /> object to compare this instance to.</param>
    /// <returns>True if this instance and the specified value are equal; otherwise, False.</returns>
    public bool EqualsTo(iGIndent value)
    {
      if (this.fLeft == value.fLeft && this.fRight == value.fRight && this.fTop == value.fTop)
        return this.fBottom == value.fBottom;
      return false;
    }

    /// <summary>Retrieves the string representation of the indent.</summary>
    /// <returns>A string that represents the indent.</returns>
    public override string ToString()
    {
      return string.Format("{{Left={0},Top={1},Right={2},Bottom={3}}}", (object) this.fLeft, (object) this.fTop, (object) this.fRight, (object) this.fBottom);
    }

    /// <summary>The value is not assigned and inherited from the parent property.</summary>
    /// <value>An instance if the <see cref="T:TenTec.Windows.iGridLib.iGIndent" /> class with all properties equal to -1.</value>
    [Browsable(false)]
    public static iGIndent NotSet
    {
      get
      {
        return iGIndent.fNotSetIndent;
      }
    }

    /// <summary>Gets or sets the left indent of the cell or column header contents.</summary>
    /// <value>An integer value. The default is 0.</value>
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGIndentFieldConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Description("The left indent of the cell or column header contents.")]
    public int Left
    {
      get
      {
        return this.fLeft;
      }
      set
      {
        if (value < 0)
          value = -1;
        this.fLeft = value;
      }
    }

    /// <summary>Gets or sets the top indent of the cell or column header contents.</summary>
    /// <value>An integer value. The default is 0.</value>
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGIndentFieldConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Description("The top indent of the cell or column header contents.")]
    public int Top
    {
      get
      {
        return this.fTop;
      }
      set
      {
        if (value < 0)
          value = -1;
        this.fTop = value;
      }
    }

    /// <summary>Gets or sets the right indent of the cell or column header contents.</summary>
    /// <value>An integer value. The default is 0.</value>
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGIndentFieldConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Description("The right indent of the cell or column header contents.")]
    public int Right
    {
      get
      {
        return this.fRight;
      }
      set
      {
        if (value < 0)
          value = -1;
        this.fRight = value;
      }
    }

    /// <summary>Gets or sets the bottom indent of the cell or column header contents.</summary>
    /// <value>An integer value. The default is 0.</value>
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGIndentFieldConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Description("The bottom indent of the cell or column header contents.")]
    public int Bottom
    {
      get
      {
        return this.fBottom;
      }
      set
      {
        if (value < 0)
          value = -1;
        this.fBottom = value;
      }
    }
  }
}
