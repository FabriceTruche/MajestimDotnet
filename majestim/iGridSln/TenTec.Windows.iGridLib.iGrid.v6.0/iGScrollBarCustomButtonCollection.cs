// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGScrollBarCustomButtonCollection
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Collections;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents the collection of a scroll bar's custom buttons.</summary>
  public class iGScrollBarCustomButtonCollection : IList, ICollection, IEnumerable, IiGEnumerableCollection
  {
    internal iGScrollBarBase fScrollBar;

    internal iGScrollBarCustomButtonCollection(iGScrollBarBase scrollBar)
    {
      this.fScrollBar = scrollBar;
    }

    private void CheckIndex(int index)
    {
      if (index < 0 || index >= this.fScrollBar.fSubCount - 5)
        throw new ArgumentOutOfRangeException();
    }

    private int GetSubControlIndex(int index)
    {
      return index + 5;
    }

    /// <summary>Removes the custom button with the specified index.</summary>
    /// <param name="index">The zero-based index of the scroll bar custom button to remove.</param>
    public void RemoveAt(int index)
    {
      this.CheckIndex(index);
      index = this.GetSubControlIndex(index);
      iGScrollBarCustomButtonSubControl fSubControl = (iGScrollBarCustomButtonSubControl) this.fScrollBar.fSubControls[index];
      this.fScrollBar.RemoveSubControlAt(index);
            // ISSUE: variable of the null type

            //FABRICE
            //__Null local = null;
        object local = null;


      fSubControl.fControl = (iGScrollBarBase) local;
      this.AdjustScroll();
    }

    /// <summary>Inserts the specified custom button to the specified position.</summary>
    /// <param name="index">The zero-based index at which the button should be inserted.</param>
    /// <param name="value">The scroll bar custom button to insert.</param>
    public void Insert(int index, iGScrollBarCustomButton value)
    {
      if (value == null)
        throw new ArgumentNullException();
      this.CheckIndex(index);
      if (value.fSubControl.fControl != null)
      {
        if (value.fSubControl.fControl != this.fScrollBar)
          throw new Exception("Cannot add one button to several scroll bars");
      }
      else
      {
        this.fScrollBar.InsertSubControl(this.GetSubControlIndex(index), (iGSubControl) value.fSubControl);
        value.fSubControl.fControl = this.fScrollBar;
        this.AdjustScroll();
      }
    }

    private void AdjustScroll()
    {
      this.fScrollBar.AdjustKoef();
      this.fScrollBar.SetSubControlsBounds();
      this.fScrollBar.Invalidate();
    }

    /// <summary>Removes the specified custom button.</summary>
    /// <param name="value">The scroll bar custom button to remove.</param>
    public void Remove(iGScrollBarCustomButton value)
    {
      if (value == null)
        throw new ArgumentNullException();
      int index = this.fScrollBar.IndexOfSubControl((iGSubControl) value.fSubControl);
      if (index < 0)
        return;
      this.fScrollBar.RemoveSubControlAt(index);
      this.AdjustScroll();
    }

    /// <summary>Retrieves a value indicating whether the scroll bar contains the specified custom button.</summary>
    /// <param name="value">The scroll bar custom button to locate.</param>
    /// <returns>True if the scroll bar contains the specified button; otherwise, False.</returns>
    public bool Contains(iGScrollBarCustomButton value)
    {
      if (value == null)
        throw new ArgumentNullException();
      return value.fSubControl.fControl == this.fScrollBar;
    }

    /// <summary>Retrieves the index of the specified custom button.</summary>
    /// <param name="value">The scroll bar custom button to locate.</param>
    /// <returns>The zero-based index of the button to locate, or -1 if the button is not found.</returns>
    public int IndexOf(iGScrollBarCustomButton value)
    {
      if (value == null)
        throw new ArgumentNullException();
      int num = this.fScrollBar.IndexOfSubControl((iGSubControl) value.fSubControl);
      if (num >= 0)
        num += 5;
      return num;
    }

    /// <summary>Adds the range of custom buttons to the scroll bar.</summary>
    /// <param name="value">The scroll bar custom buttons to add.</param>
    public void AddRange(iGScrollBarCustomButton[] value)
    {
      for (int index = 0; index < value.Length; ++index)
      {
        iGScrollBarCustomButton gscrollBarCustomButton = value[index];
        if (gscrollBarCustomButton == null)
          throw new ArgumentNullException();
        iGScrollBarCustomButtonSubControl fSubControl = gscrollBarCustomButton.fSubControl;
        if (fSubControl.fControl != null && fSubControl.fControl != this.fScrollBar)
          throw new ArgumentException("Cannot add one button to several scroll bars");
      }
      for (int index = 0; index < value.Length; ++index)
      {
        iGScrollBarCustomButtonSubControl fSubControl = value[index].fSubControl;
        if (fSubControl.fControl != this.fScrollBar)
        {
          this.fScrollBar.AddSubControl((iGSubControl) fSubControl);
          fSubControl.fControl = this.fScrollBar;
        }
      }
      this.AdjustScroll();
    }

    /// <summary>Removes all the custom buttons from the scroll bar.</summary>
    public void Clear()
    {
      while (this.fScrollBar.fSubCount > 5)
      {
        iGSubControl[] fSubControls = this.fScrollBar.fSubControls;
        iGScrollBarBase fScrollBar = this.fScrollBar;
        int num1 = fScrollBar.fSubCount - 1;
        int num2 = num1;
        fScrollBar.fSubCount = num2;
        int index = num1;
        ((iGScrollBarCustomButtonSubControl) fSubControls[index]).fControl = (iGScrollBarBase) null;
        this.fScrollBar.fSubControls[this.fScrollBar.fSubCount] = (iGSubControl) null;
      }
      this.AdjustScroll();
    }

    /// <summary>Adds the specified custom button to the scroll bar.</summary>
    /// <param name="value">The scroll bar custom button to add.</param>
    /// <returns>The index of the added button within this collection.</returns>
    public int Add(iGScrollBarCustomButton value)
    {
      if (value == null)
        throw new ArgumentNullException();
      if (value.fSubControl.fControl != null)
      {
        if (value.fSubControl.fControl == this.fScrollBar)
          return this.IndexOf(value);
        throw new ArgumentException("Cannot add one button to several scroll bars");
      }
      int num = this.fScrollBar.AddSubControl((iGSubControl) value.fSubControl);
      value.fSubControl.fControl = this.fScrollBar;
      this.AdjustScroll();
      return num;
    }

    /// <summary>Adds a new custom button to the scroll bar.</summary>
    /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGScrollBarCustomButton" /> object that represents the new button.</returns>
    public iGScrollBarCustomButton Add()
    {
      return this.Add(iGScrollBarCustomButtonAlign.Near);
    }

    /// <summary>Adds a new custom button with the specified alignment to the scroll bar.</summary>
    /// <param name="align">The alignment of the new scroll bar custom button.</param>
    /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGScrollBarCustomButton" /> object that represents the new button.</returns>
    public iGScrollBarCustomButton Add(iGScrollBarCustomButtonAlign align)
    {
      return this.Add(align, -1);
    }

    /// <summary>Adds a new custom button with the specified alignment and image index to the scroll bar.</summary>
    /// <param name="align">The alignment of the new scroll bar custom button.</param>
    /// <param name="imageIndex">The zero-based index of the image displayed in the new scroll bar custom button.</param>
    /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGScrollBarCustomButton" /> object that represents the new button.</returns>
    public iGScrollBarCustomButton Add(iGScrollBarCustomButtonAlign align, int imageIndex)
    {
      return this.Add(align, imageIndex, (string) null);
    }

    /// <summary>Adds a new custom button with the specified alignment, image index, and tool tip text to the scroll bar.</summary>
    /// <param name="align">The alignment of the new scroll bar custom button.</param>
    /// <param name="imageIndex">The zero-based index of the image displayed in the new scroll bar custom button.</param>
    /// <param name="toolTipText">The tool tip text for the new scroll bar custom button.</param>
    /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGScrollBarCustomButton" /> object that represents the new button.</returns>
    public iGScrollBarCustomButton Add(iGScrollBarCustomButtonAlign align, int imageIndex, string toolTipText)
    {
      return this.Add(align, imageIndex, toolTipText, (object) null);
    }

    /// <summary>Adds a new custom button with the specified alignment, image index, tool tip text, and tag to the scroll bar.</summary>
    /// <param name="align">The alignment of the new scroll bar custom button.</param>
    /// <param name="imageIndex">The zero-based index of the image displayed in the new scroll bar custom button.</param>
    /// <param name="toolTipText">The tool tip text for the new scroll bar custom button.</param>
    /// <param name="tag">An object that contains data about the new scroll bar button.</param>
    /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGScrollBarCustomButton" /> object that represents the new button.</returns>
    public iGScrollBarCustomButton Add(iGScrollBarCustomButtonAlign align, int imageIndex, string toolTipText, object tag)
    {
      return this.Add(align, imageIndex, toolTipText, true, tag);
    }

    /// <summary>Adds a new custom button with the specified alignment, image index, tool tip text, and enabled property to the scroll bar.</summary>
    /// <param name="align">The alignment of the new scroll bar custom button.</param>
    /// <param name="imageIndex">The zero-based index of the image displayed in the new scroll bar custom button.</param>
    /// <param name="toolTipText">The tool tip text for the new scroll bar custom button.</param>
    /// <param name="enabled">Specifies whether the new scroll bar custom button can respond to user interaction. True can respond; False, otherwise.</param>
    /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGScrollBarCustomButton" /> object that represents the new button.</returns>
    public iGScrollBarCustomButton Add(iGScrollBarCustomButtonAlign align, int imageIndex, string toolTipText, bool enabled)
    {
      return this.Add(align, imageIndex, toolTipText, enabled, (object) null);
    }

    /// <summary>Adds a new custom button with the specified alignment, image index, tool tip text, enabled property, and tag to the scroll bar.</summary>
    /// <param name="align">The alignment of the new scroll bar custom button.</param>
    /// <param name="imageIndex">The zero-based index of the image displayed in the new scroll bar custom button.</param>
    /// <param name="toolTipText">The tool tip text for the new scroll bar custom button.</param>
    /// <param name="enabled">Specifies whether the new scroll bar custom button can respond to user interaction. True can respond; False, otherwise.</param>
    /// <param name="tag">An object that contains data about the new scroll bar button.</param>
    /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGScrollBarCustomButton" /> object that represents the new button.</returns>
    public iGScrollBarCustomButton Add(iGScrollBarCustomButtonAlign align, int imageIndex, string toolTipText, bool enabled, object tag)
    {
      iGScrollBarCustomButton gscrollBarCustomButton = new iGScrollBarCustomButton(align, imageIndex, toolTipText, enabled, tag);
      this.Add(gscrollBarCustomButton);
      return gscrollBarCustomButton;
    }

    /// <summary>Adds a new custom button with the specified alignment and action to the scroll bar.</summary>
    /// <param name="align">The alignment of the new scroll bar custom button.</param>
    /// <param name="action">The action to perform when the new scroll bar custom button is clicked.</param>
    /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGScrollBarCustomButton" /> object that represents the new button.</returns>
    public iGScrollBarCustomButton Add(iGScrollBarCustomButtonAlign align, iGActions action)
    {
      return this.Add(align, action, (string) null);
    }

    /// <summary>Adds a new custom button with the specified alignment, action, and tooltip text to the scroll bar.</summary>
    /// <param name="align">The alignment of the new scroll bar custom button.</param>
    /// <param name="action">The action to perform when the new scroll bar custom button is clicked.</param>
    /// <param name="toolTipText">The tool tip text for the new scroll bar custom button.</param>
    /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGScrollBarCustomButton" /> object that represents the new button.</returns>
    public iGScrollBarCustomButton Add(iGScrollBarCustomButtonAlign align, iGActions action, string toolTipText)
    {
      return this.Add(align, action, -1, toolTipText, true, (object) null);
    }

    /// <summary>Adds a new custom button with the specified property values.</summary>
    /// <param name="align">The alignment of the new scroll bar custom button.</param>
    /// <param name="action">The action to perform when the new scroll bar custom button is clicked.</param>
    /// <param name="imageIndex">The zero-based index of the image displayed in the new scroll bar custom button.</param>
    /// <param name="toolTipText">The tool tip text for the new scroll bar custom button.</param>
    /// <param name="enabled">Specifies whether the new scroll bar custom button can respond to user interaction. True can respond; False, otherwise.</param>
    /// <param name="tag">An object that contains data about the new scroll bar button.</param>
    /// <returns>The <see cref="T:TenTec.Windows.iGridLib.iGScrollBarCustomButton" /> object that represents the new button.</returns>
    public iGScrollBarCustomButton Add(iGScrollBarCustomButtonAlign align, iGActions action, int imageIndex, string toolTipText, bool enabled, object tag)
    {
      iGScrollBarCustomButton gscrollBarCustomButton = new iGScrollBarCustomButton(align, action, imageIndex, toolTipText, enabled, tag);
      this.Add(gscrollBarCustomButton);
      return gscrollBarCustomButton;
    }

    /// <summary>Gets the custom button with the specified index.</summary>
    /// <param name="index">The zero-based index of the scroll custom button to retrieve.</param>
    /// <value>The <see cref="T:TenTec.Windows.iGridLib.iGScrollBarCustomButton" /> object that represents the retrieved button.</value>
    public iGScrollBarCustomButton this[int index]
    {
      get
      {
        this.CheckIndex(index);
        return new iGScrollBarCustomButton((iGScrollBarCustomButtonSubControl) this.fScrollBar.fSubControls[this.GetSubControlIndex(index)]);
      }
      set
      {
        this.CheckIndex(index);
        if (value == null)
          throw new ArgumentNullException();
        if (value.fSubControl.fControl != null)
        {
          if (value.fSubControl.fControl != this.fScrollBar)
            throw new ArgumentException("Cannot add one button to several scroll bars");
        }
        else
        {
          index = this.GetSubControlIndex(index);
          ((iGScrollBarCustomButtonSubControl) this.fScrollBar.fSubControls[index]).fControl = (iGScrollBarBase) null;
          this.fScrollBar.fSubControls[index] = (iGSubControl) value.fSubControl;
        }
      }
    }

    /// <summary>Gets the number of the custom buttons in the scroll bar.</summary>
    /// <value>A numeric value.</value>
    public int Count
    {
      get
      {
        return this.fScrollBar.fSubCount - 5;
      }
    }

    bool IList.IsReadOnly
    {
      get
      {
        return false;
      }
    }

    object IList.this[int index]
    {
      get
      {
        return (object) this[index];
      }
      set
      {
        this[index] = (iGScrollBarCustomButton) value;
      }
    }

    void IList.Insert(int index, object value)
    {
      this.Insert(index, (iGScrollBarCustomButton) value);
    }

    void IList.Remove(object value)
    {
      this.Remove((iGScrollBarCustomButton) value);
    }

    bool IList.Contains(object value)
    {
      return this.Contains((iGScrollBarCustomButton) value);
    }

    int IList.IndexOf(object value)
    {
      return this.IndexOf((iGScrollBarCustomButton) value);
    }

    int IList.Add(object value)
    {
      return this.Add((iGScrollBarCustomButton) value);
    }

    bool IList.IsFixedSize
    {
      get
      {
        return false;
      }
    }

    bool ICollection.IsSynchronized
    {
      get
      {
        return false;
      }
    }

    void ICollection.CopyTo(Array array, int index)
    {
      if (array == null)
        throw new ArgumentNullException();
      if (index < 0)
        throw new ArgumentOutOfRangeException();
      if (array.Rank > 1 || index >= array.Length || this.Count > array.Length - index)
        throw new Exception();
      if (array.GetType().GetElementType() != typeof (iGScrollBarCustomButton))
        throw new InvalidCastException();
      for (int index1 = this.Count - 1; index1 >= 0; --index1)
        array.SetValue((object) this[index1], index + index1);
    }

    object ICollection.SyncRoot
    {
      get
      {
        return (object) this;
      }
    }

    /// <summary>Returns an enumerator that can be used to iterate through the collection.</summary>
    /// <returns>An <see cref="T:System.Collections.IEnumerator" /> for this collection.</returns>
    public IEnumerator GetEnumerator()
    {
      return (IEnumerator) new iGEnumerator((IiGEnumerableCollection) this);
    }

    object IiGEnumerableCollection.this[int index]
    {
      get
      {
        return (object) this[index];
      }
    }
  }
}
