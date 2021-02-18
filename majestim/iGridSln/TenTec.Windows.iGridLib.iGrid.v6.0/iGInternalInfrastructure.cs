// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGInternalInfrastructure
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  /// <summary>The members of this class are intended to support the internal infrastructure and should not be used directly from your code.</summary>
  public static class iGInternalInfrastructure
  {
    internal static iGCellStyle cDefaultGroupRowStyle = new iGCellStyle(true);

    static iGInternalInfrastructure()
    {
      iGInternalInfrastructure.cDefaultGroupRowStyle.BackColor = SystemColors.Control;
    }

    /// <param name="grid" />
    /// <param name="data" />
    /// <param name="rowIndex" />
    /// <param name="checkAllLevels" />
    /// <param name="isRowVisible" />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void FillTreeBranchData(iGrid grid, List<iGTreeBranchState> data, int rowIndex, bool checkAllLevels, iGIsRowVisibleDelegate isRowVisible)
    {
      grid.FillTreeBranchData(data, rowIndex, checkAllLevels, isRowVisible);
    }

    /// <summary>This member is intended to support the internal infrastructure and should not be used directly from your code.</summary>
    /// <param name="grid">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <returns>This member is intended to support the internal infrastructure and should not be used directly from your code.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool ShouldSerializeGroupRowLevelStyles(iGrid grid)
    {
      return grid.ShouldSerializeGroupRowLevelStyles();
    }

    /// <summary>This member is intended to support the internal infrastructure and should not be used directly from your code.</summary>
    /// <param name="grid">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <param name="cellStyle">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <param name="rowStyle">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <param name="colStyle">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <returns>This member is intended to support the internal infrastructure and should not be used directly from your code.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static ImageList GetCellImageList(iGrid grid, iGStyleBase cellStyle, iGStyleBase rowStyle, iGStyleBase colStyle)
    {
      return grid.GetUniCellImageList(iGGridSection.Cells, cellStyle, rowStyle, colStyle);
    }

    /// <summary>This member is intended to support the internal infrastructure and should not be used directly from your code.</summary>
    /// <param name="context">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <returns>This member is intended to support the internal infrastructure and should not be used directly from your code.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static ImageList GetImageList(ITypeDescriptorContext context)
    {
      if (context == null || context.Instance == null)
        return (ImageList) null;
      IiGImageListProvider instance = context.Instance as IiGImageListProvider;
      if (instance == null)
        return (ImageList) null;
      return instance.GetImageList(context.PropertyDescriptor.Name);
    }

    /// <summary>This member is intended to support the internal infrastructure and should not be used directly from your code.</summary>
    /// <returns>This member is intended to support the internal infrastructure and should not be used directly from your code.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static iGCellStyle GetDefaultGroupRowStyle()
    {
      return iGInternalInfrastructure.cDefaultGroupRowStyle;
    }

    /// <summary>This member is intended to support the internal infrastructure and should not be used directly from your code.</summary>
    /// <param name="service">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void ClearNonUsedDesignColHdrStyles(IReferenceService service)
    {
      if (service == null)
        return;
      object[] references = service.GetReferences(typeof (iGColHdrStyle));
      if (references == null || references.Length == 0)
        return;
      bool[] usage = new bool[references.Length];
      foreach (object reference in service.GetReferences(typeof (iGrid)))
      {
        iGrid iGrid = reference as iGrid;
        if (iGrid != null)
        {
          iGInternalInfrastructure.SetStyleUsage(references, (object) iGrid.DefaultCol.ColHdrStyle, usage);
          foreach (iGCol col in (IEnumerable) iGrid.Cols)
            iGInternalInfrastructure.SetStyleUsage(references, (object) col.ColHdrStyle, usage);
        }
      }
      for (int index = 0; index < references.Length; ++index)
      {
        if (!usage[index])
        {
          IComponent component = service.GetComponent(references[index]);
          if (!(component.GetType() == typeof (iGColHdrStyleDesign)) && component != null)
            component.Dispose();
        }
      }
    }

    /// <summary>This member is intended to support the internal infrastructure and should not be used directly from your code.</summary>
    /// <param name="service">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void ClearNonUsedDesignCellStyles(IReferenceService service)
    {
      if (service == null)
        return;
      object[] references = service.GetReferences(typeof (iGCellStyle));
      if (references == null || references.Length == 0)
        return;
      bool[] usage = new bool[references.Length];
      foreach (object reference in service.GetReferences(typeof (iGrid)))
      {
        iGrid iGrid = reference as iGrid;
        if (iGrid != null)
        {
          iGInternalInfrastructure.SetStyleUsage(references, (object) iGrid.DefaultRow.CellStyle, usage);
          iGInternalInfrastructure.SetStyleUsage(references, (object) iGrid.DefaultCol.CellStyle, usage);
          iGInternalInfrastructure.SetStyleUsage(references, (object) iGrid.RowTextCol.CellStyle, usage);
          foreach (iGCellStyle groupRowLevelStyle in iGrid.GroupRowLevelStyles)
            iGInternalInfrastructure.SetStyleUsage(references, (object) groupRowLevelStyle, usage);
          foreach (iGCol col in (IEnumerable) iGrid.Cols)
            iGInternalInfrastructure.SetStyleUsage(references, (object) col.CellStyle, usage);
          foreach (iGRow row in (IEnumerable) iGrid.Rows)
            iGInternalInfrastructure.SetStyleUsage(references, (object) row.CellStyle, usage);
          foreach (iGCell cell in (IEnumerable) iGrid.Cells)
            iGInternalInfrastructure.SetStyleUsage(references, (object) cell.Style, usage);
        }
      }
      for (int index = 0; index < references.Length; ++index)
      {
        if (!usage[index])
        {
          IComponent component = service.GetComponent(references[index]);
          if (!(component.GetType() == typeof (iGCellStyleDesign)) && component != null)
            component.Dispose();
        }
      }
    }

    private static void SetStyleUsage(object[] styles, object style, bool[] usage)
    {
      if (style == null)
        return;
      int index = Array.IndexOf<object>(styles, style);
      if (index < 0)
        return;
      usage[index] = true;
    }

    /// <summary>This member is intended to support the internal infrastructure and should not be used directly from your code.</summary>
    /// <param name="grid">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void ResetMouseData(iGrid grid)
    {
      grid.EmptyMouse();
    }

    /// <summary>This member is intended to support the internal infrastructure and should not be used directly from your code.</summary>
    /// <param name="grid">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <param name="x">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <param name="y">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <param name="button">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void ProcessMouseMoveForGrid(iGrid grid, int x, int y, MouseButtons button)
    {
      grid.ProcessMouseMove(x, y, button);
    }

    /// <summary>This member is intended to support the internal infrastructure and should not be used directly from your code.</summary>
    /// <param name="grid">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <param name="x">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <param name="y">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <param name="button">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void ProcessMouseDownForGrid(iGrid grid, int x, int y, MouseButtons button)
    {
      grid.ProcessMouseDown(x, y, button);
    }

    /// <summary>This member is intended to support the internal infrastructure and should not be used directly from your code.</summary>
    /// <param name="grid">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <param name="x">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <param name="y">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <param name="button">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void ProcessMouseUpForGrid(iGrid grid, int x, int y, MouseButtons button)
    {
      grid.ProcessMouseUp(x, y, button);
    }

    /// <summary>This member is intended to support the internal infrastructure and should not be used directly from your code.</summary>
    /// <param name="grid">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void ProcessDoubleClickForGrid(iGrid grid)
    {
      grid.ProcessDoubleClick();
    }

    /// <summary>This member is intended to support the internal infrastructure and should not be used directly from your code.</summary>
    /// <param name="grid">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <param name="vertical">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <param name="xGrid">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <param name="yGrid">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <param name="button">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void ProcessMouseMoveForScrollBar(iGrid grid, bool vertical, int xGrid, int yGrid, MouseButtons button)
    {
      if (vertical)
        grid.fVScrollBar.ProcessMouseMove(new MouseEventArgs(button, 0, xGrid - grid.fVScrollBar.Left, yGrid - grid.fVScrollBar.Top, 0));
      else
        grid.fHScrollBar.ProcessMouseMove(new MouseEventArgs(button, 0, xGrid - grid.fHScrollBar.Left, yGrid - grid.fHScrollBar.Top, 0));
    }

    /// <summary>This member is intended to support the internal infrastructure and should not be used directly from your code.</summary>
    /// <param name="grid">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <param name="vertical">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <param name="xGrid">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <param name="yGrid">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <param name="button">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void ProcessMouseDownForScrollBar(iGrid grid, bool vertical, int xGrid, int yGrid, MouseButtons button)
    {
      if (vertical)
        grid.fVScrollBar.ProcessMouseDown(new MouseEventArgs(button, 1, xGrid - grid.fVScrollBar.Left, yGrid - grid.fVScrollBar.Top, 0));
      else
        grid.fHScrollBar.ProcessMouseDown(new MouseEventArgs(button, 1, xGrid - grid.fHScrollBar.Left, yGrid - grid.fHScrollBar.Top, 0));
    }

    /// <summary>This member is intended to support the internal infrastructure and should not be used directly from your code.</summary>
    /// <param name="grid">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <param name="vertical">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <param name="xGrid">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <param name="yGrid">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <param name="button">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void ProcessMouseUpForScrollBar(iGrid grid, bool vertical, int xGrid, int yGrid, MouseButtons button)
    {
      if (vertical)
        grid.fVScrollBar.ProcessMouseUp(new MouseEventArgs(button, 1, xGrid - grid.fVScrollBar.Left, yGrid - grid.fVScrollBar.Top, 0));
      else
        grid.fHScrollBar.ProcessMouseUp(new MouseEventArgs(button, 1, xGrid - grid.fHScrollBar.Left, yGrid - grid.fHScrollBar.Top, 0));
    }

    /// <summary>This member is intended to support the internal infrastructure and should not be used directly from your code.</summary>
    /// <param name="grid">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <param name="vertical">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <param name="e">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void ProcessMouseLeaveForScrollBar(iGrid grid, bool vertical, EventArgs e)
    {
      if (vertical)
        grid.fVScrollBar.ProcessMouseLeave(e);
      else
        grid.fHScrollBar.ProcessMouseLeave(e);
    }

    /// <summary>This member is intended to support the internal infrastructure and should not be used directly from your code.</summary>
    /// <param name="grid">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <returns>This member is intended to support the internal infrastructure and should not be used directly from your code.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool IsMouseCapturedByGrid(iGrid grid)
    {
      return grid.IsMouseCapturedByGrid();
    }

    /// <summary>This member is intended to support the internal infrastructure and should not be used directly from your code.</summary>
    /// <param name="grid">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <param name="vertical">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
    /// <returns>This member is intended to support the internal infrastructure and should not be used directly from your code.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool IsMouseCapturedByScrollBar(iGrid grid, bool vertical)
    {
      if (vertical)
        return grid.IsMouseCapturedByVScrollBar();
      return grid.IsMouseCapturedByHScrollBar();
    }

    /// <summary>The members of this class are intended to support the internal infrastructure and should not be used directly from your code.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class iGSerializeManager
    {
      /// <summary>This member is intended to support the internal infrastructure and should not be used directly from your code.</summary>
      /// <param name="value">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
      /// <returns>This member is intended to support the internal infrastructure and should not be used directly from your code.</returns>
      public static bool ShouldSerialize(object value)
      {
        if (value == null)
          return false;
        foreach (PropertyInfo property in value.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
        {
          try
          {
            if (iGInternalInfrastructure.iGSerializeManager.IsBrowsable(property))
            {
              object[] customAttributes = property.GetCustomAttributes(typeof (DefaultValueAttribute), true);
              if (customAttributes.Length != 0)
              {
                DefaultValueAttribute defaultValueAttribute = customAttributes[0] as DefaultValueAttribute;
                if (defaultValueAttribute != null)
                {
                  if (!object.Equals(defaultValueAttribute.Value, property.GetValue(value, (object[]) null)))
                    return true;
                  continue;
                }
              }
              MethodInfo method = property.DeclaringType.GetMethod(nameof (ShouldSerialize) + property.Name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
              if (method != (MethodInfo) null)
              {
                if ((bool) method.Invoke(value, (object[]) null))
                  return true;
              }
            }
          }
          catch (Exception ex)
          {
          }
        }
        return false;
      }

      private static bool IsBrowsable(PropertyInfo prop)
      {
        object[] customAttributes = prop.GetCustomAttributes(typeof (BrowsableAttribute), true);
        if (customAttributes.Length != 0)
        {
          BrowsableAttribute browsableAttribute = customAttributes[0] as BrowsableAttribute;
          if (browsableAttribute != null && !browsableAttribute.Browsable)
            return false;
        }
        return true;
      }

      /// <summary>This member is intended to support the internal infrastructure and should not be used directly from your code.</summary>
      /// <param name="component">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
      /// <param name="prop">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
      public static void ResetProperty(object component, PropertyInfo prop)
      {
        try
        {
          if (!iGInternalInfrastructure.iGSerializeManager.IsBrowsable(prop))
            return;
          object[] customAttributes = prop.GetCustomAttributes(typeof (DefaultValueAttribute), true);
          if (customAttributes.Length != 0)
          {
            DefaultValueAttribute defaultValueAttribute = customAttributes[0] as DefaultValueAttribute;
            if (defaultValueAttribute != null)
            {
              prop.SetValue(component, defaultValueAttribute.Value, (object[]) null);
              return;
            }
          }
          MethodInfo method = prop.DeclaringType.GetMethod("Reset" + prop.Name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
          if (!(method != (MethodInfo) null))
            return;
          method.Invoke(component, (object[]) null);
        }
        catch (Exception ex)
        {
        }
      }

      /// <summary>This member is intended to support the internal infrastructure and should not be used directly from your code.</summary>
      /// <param name="value">This member is intended to support the internal infrastructure and should not be used directly from your code.</param>
      public static void Reset(object value)
      {
        if (value == null)
          return;
        foreach (PropertyInfo property in value.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
          iGInternalInfrastructure.iGSerializeManager.ResetProperty(value, property);
      }
    }
  }
}
