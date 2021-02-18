// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGScrollBarCustomButton
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  /// <summary>Represents an additional scroll bar button.</summary>
  [TypeConverter("TenTec.Windows.iGridLib.Design.iGScrollBarCustomButtonConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
  public class iGScrollBarCustomButton : IiGImageListProvider
  {
    internal const int cDefaultImageIndex = -1;
    internal const iGScrollBarCustomButtonAlign cDefaultAlignment = iGScrollBarCustomButtonAlign.Near;
    internal const bool cDefaultEnabled = true;
    internal const iGActions cDefaultAction = iGActions.None;
    internal iGScrollBarCustomButtonSubControl fSubControl;

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGScrollBarCustomButton" /> class.</summary>
    public iGScrollBarCustomButton()
    {
      this.fSubControl = new iGScrollBarCustomButtonSubControl(iGScrollBarCustomButtonAlign.Near, iGActions.None, -1, (string) null, true, (object) null);
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGScrollBarCustomButton" /> class with the specified alignment and image index.</summary>
    /// <param name="alignment">The alignment of the new scroll bar button.</param>
    /// <param name="imageIndex">The index of the image displayed in the new scroll bar button.</param>
    public iGScrollBarCustomButton(iGScrollBarCustomButtonAlign alignment, int imageIndex)
    {
      this.fSubControl = new iGScrollBarCustomButtonSubControl(alignment, iGActions.None, imageIndex, (string) null, true, (object) null);
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGScrollBarCustomButton" /> class with the specified alignment, image index, and tool tip text.</summary>
    /// <param name="alignment">The alignment of the new scroll bar button.</param>
    /// <param name="imageIndex">The index of the image displayed in the new scroll bar button.</param>
    /// <param name="toolTipText">The tool tip text for the new scroll bar button.</param>
    public iGScrollBarCustomButton(iGScrollBarCustomButtonAlign alignment, int imageIndex, string toolTipText)
    {
      this.fSubControl = new iGScrollBarCustomButtonSubControl(alignment, iGActions.None, imageIndex, toolTipText, true, (object) null);
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGScrollBarCustomButton" /> class with the specified alignment, image index, tool tip text, and tag.</summary>
    /// <param name="alignment">The alignment of the new scroll bar button.</param>
    /// <param name="imageIndex">The index of the image displayed in the new scroll bar button.</param>
    /// <param name="toolTipText">The tool tip text for the new scroll bar button.</param>
    /// <param name="tag">An object that contains data about the new scroll bar button.</param>
    public iGScrollBarCustomButton(iGScrollBarCustomButtonAlign alignment, int imageIndex, string toolTipText, object tag)
    {
      this.fSubControl = new iGScrollBarCustomButtonSubControl(alignment, iGActions.None, imageIndex, toolTipText, true, tag);
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGScrollBarCustomButton" /> class with the specified alignment, image index, tool tip text, and enable property value.</summary>
    /// <param name="alignment">The alignment of the new scroll bar button.</param>
    /// <param name="imageIndex">The index of the image displayed in the new scroll bar button.</param>
    /// <param name="toolTipText">The tool tip text for the new scroll bar button.</param>
    /// <param name="enabled">Specifies whether the new scroll bar button can respond to user interaction. True if the button can respond; False, otherwise.</param>
    public iGScrollBarCustomButton(iGScrollBarCustomButtonAlign alignment, int imageIndex, string toolTipText, bool enabled)
    {
      this.fSubControl = new iGScrollBarCustomButtonSubControl(alignment, iGActions.None, imageIndex, toolTipText, enabled, (object) null);
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGScrollBarCustomButton" /> class with the specified alignment, image index, tool tip text, tag, and enabled property value.</summary>
    /// <param name="alignment">The alignment of the new scroll bar button.</param>
    /// <param name="imageIndex">The index of the image displayed in the new scroll bar button.</param>
    /// <param name="toolTipText">The tool tip text for the new scroll bar button.</param>
    /// <param name="enabled">Specifies whether the new scroll bar button can respond to user interaction. True if the button can respond; False, otherwise.</param>
    /// <param name="tag">An object that contains data about the new scroll bar button.</param>
    public iGScrollBarCustomButton(iGScrollBarCustomButtonAlign alignment, int imageIndex, string toolTipText, bool enabled, object tag)
    {
      this.fSubControl = new iGScrollBarCustomButtonSubControl(alignment, iGActions.None, imageIndex, toolTipText, enabled, tag);
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGScrollBarCustomButton" /> class with the specified alignment and action.</summary>
    /// <param name="alignment">The alignment of the new scroll bar button.</param>
    /// <param name="action">The action to perform when the new scroll bar button is clicked.</param>
    public iGScrollBarCustomButton(iGScrollBarCustomButtonAlign alignment, iGActions action)
    {
      this.fSubControl = new iGScrollBarCustomButtonSubControl(alignment, action, -1, (string) null, true, (object) null);
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGScrollBarCustomButton" /> class with the specified alignment, tool tip text, and action.</summary>
    /// <param name="alignment">The alignment of the new scroll bar button.</param>
    /// <param name="action">The action to perform when the new scroll bar button is clicked.</param>
    /// <param name="toolTipText">The tool tip text for the new scroll bar button.</param>
    public iGScrollBarCustomButton(iGScrollBarCustomButtonAlign alignment, iGActions action, string toolTipText)
    {
      this.fSubControl = new iGScrollBarCustomButtonSubControl(alignment, action, -1, toolTipText, true, (object) null);
    }

    /// <summary>Initializes a new instance of the <see cref="T:TenTec.Windows.iGridLib.iGScrollBarCustomButton" /> class with the specified property values.</summary>
    /// <param name="alignment">The alignment of the new scroll bar button.</param>
    /// <param name="action">The action to perform when the new scroll bar button is clicked.</param>
    /// <param name="imageIndex">The index of the image displayed in the new scroll bar button.</param>
    /// <param name="toolTipText">The tool tip text for the new scroll bar button.</param>
    /// <param name="enabled">Specifies whether the new scroll bar button can respond to user interaction. True if the button can respond; False, otherwise.</param>
    /// <param name="tag">An object that contains data about the new scroll bar button.</param>
    public iGScrollBarCustomButton(iGScrollBarCustomButtonAlign alignment, iGActions action, int imageIndex, string toolTipText, bool enabled, object tag)
    {
      this.fSubControl = new iGScrollBarCustomButtonSubControl(alignment, action, imageIndex, toolTipText, enabled, tag);
    }

    internal iGScrollBarCustomButton(iGScrollBarCustomButtonSubControl subControl)
    {
      this.fSubControl = subControl;
    }

    /// <summary>This member overrides <see cref="T:System.Object" />.<see cref="M:System.Object.Equals(System.Object)" />.</summary>
    /// <param name="obj">An object to compare with.</param>
    /// <returns>A Boolean value that indicates whether the objects equal.</returns>
    public override bool Equals(object obj)
    {
      iGScrollBarCustomButton gscrollBarCustomButton = obj as iGScrollBarCustomButton;
      if (obj == null)
        return false;
      return this.fSubControl == gscrollBarCustomButton.fSubControl;
    }

    /// <summary>This member overrides <see cref="T:System.Object" />.<see cref="M:System.Object.GetHashCode" />.</summary>
    /// <returns>A hash code for the object.</returns>
    public override int GetHashCode()
    {
      return this.fSubControl.GetHashCode();
    }

    ImageList IiGImageListProvider.GetImageList(string propertyName)
    {
      if (this.fSubControl.fControl != null)
        return this.fSubControl.fControl.ImageList;
      return (ImageList) null;
    }

    /// <summary>Gets or sets the action to perform when the button is clicked.</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGActions" /> enumeration values. The default is <see cref="F:TenTec.Windows.iGridLib.iGActions.None" />.</value>
    [DefaultValue(iGActions.None)]
    [Category("Behavior")]
    public iGActions Action
    {
      get
      {
        return this.fSubControl.fAction;
      }
      set
      {
        if (this.fSubControl.fAction == value)
          return;
        this.fSubControl.fAction = value;
        if (this.fSubControl.fControl == null)
          return;
        this.fSubControl.fControl.Invalidate();
      }
    }

    /// <summary>Gets or sets the alignment of the scroll bar button.</summary>
    /// <value>One of the <see cref="T:TenTec.Windows.iGridLib.iGScrollBarCustomButtonAlign" /> enumeration values. The default is <see cref="F:TenTec.Windows.iGridLib.iGScrollBarCustomButtonAlign.Near" />.</value>
    [DefaultValue(iGScrollBarCustomButtonAlign.Near)]
    [Category("Appearance")]
    public iGScrollBarCustomButtonAlign Alignment
    {
      get
      {
        return this.fSubControl.fAlignment;
      }
      set
      {
        this.fSubControl.fAlignment = value;
        if (this.fSubControl.fControl == null)
          return;
        this.fSubControl.fControl.SetSubControlsBounds();
        this.fSubControl.fControl.Invalidate();
      }
    }

    /// <summary>Gets or sets the index of the image displayed in the scroll bar button.</summary>
    /// <value>The zero-based index of the image within the image list returned by the <see cref="P:TenTec.Windows.iGridLib.iGScrollBarSettings.ImageList" /> property of the <see cref="P:TenTec.Windows.iGridLib.iGrid.ScrollBarSettings" /> object property. Or -1 if no image is attached to the button. The default is -1.</value>
    [DefaultValue(-1)]
    [Category("Appearance")]
    [TypeConverter("TenTec.Windows.iGridLib.Design.iGImageIndexConverter, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0")]
    [Editor("TenTec.Windows.iGridLib.Design.iGImageIndexEditor, TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0", typeof (UITypeEditor))]
    public int ImageIndex
    {
      get
      {
        return this.fSubControl.fImageIndex;
      }
      set
      {
        this.fSubControl.fImageIndex = value;
        if (this.fSubControl.fControl == null)
          return;
        this.fSubControl.fControl.Invalidate();
      }
    }

    /// <summary>Gets or sets the tool tip text for the scroll bar button.</summary>
    /// <value>A string.</value>
    [DefaultValue(null)]
    [Category("Appearance")]
    public string ToolTipText
    {
      get
      {
        return this.fSubControl.fToolTipText;
      }
      set
      {
        this.fSubControl.fToolTipText = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether the scroll bar button can respond to user interaction.</summary>
    /// <value>True if the button is enabled; otherwise, False. The default is True.</value>
    [DefaultValue(true)]
    [Category("Appearance")]
    public bool Enabled
    {
      get
      {
        return this.fSubControl.Enabled;
      }
      set
      {
        if (value == this.fSubControl.Enabled)
          return;
        this.fSubControl.Enabled = value;
        this.fSubControl.fControl.Invalidate(this.fSubControl.Bounds);
      }
    }

    /// <summary>Gets or sets an object containing data about the scroll bar button.</summary>
    /// <value>An instance of a class.</value>
    [Browsable(false)]
    public object Tag
    {
      get
      {
        return this.fSubControl.fTag;
      }
      set
      {
        this.fSubControl.fTag = value;
      }
    }
  }
}
