// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGKeyManager
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.Collections.Generic;

namespace TenTec.Windows.iGridLib
{
  internal class iGKeyManager
  {
    private Dictionary<string, int> fKeys;
    private int fDefaultCapacity;

    public iGKeyManager(int defaultCapacity)
    {
      this.fDefaultCapacity = defaultCapacity;
    }

    private string AdjustKey(string key)
    {
      if (key == null)
        return (string) null;
      return key.ToUpper();
    }

    public static bool IsKeySpecified(string key)
    {
      return !iGrid.IsStringNullOrWhiteSpace(key);
    }

    public void SetItemKey(int itemIndex, string key, string oldKey, int itemCount)
    {
      if (this.fKeys == null)
        this.fKeys = new Dictionary<string, int>(Math.Max(itemCount, this.fDefaultCapacity));
      if (iGKeyManager.IsKeySpecified(oldKey))
        this.fKeys.Remove(this.AdjustKey(oldKey));
      key = this.AdjustKey(key);
      if (!iGKeyManager.IsKeySpecified(key))
        return;
      try
      {
        this.fKeys.Add(key, itemIndex);
      }
      catch (ArgumentException ex)
      {
        throw new ArgumentException("Key already exists");
      }
      catch
      {
        throw;
      }
    }

    public bool SomeKeysDefined()
    {
      if (this.fKeys != null)
        return this.fKeys.Count > 0;
      return false;
    }

    public void SetItemIndexForKey(int itemIndex, string key)
    {
      this.fKeys[this.AdjustKey(key)] = itemIndex;
    }

    public int GetItemIndexFromKey(string key)
    {
      int num;
      if (this.fKeys == null || !this.fKeys.TryGetValue(this.AdjustKey(key), out num))
        return -1;
      return num;
    }

    public void AfterItemIndicesChanged(int itemCount, int changedIndex, int changedCount, int newIndex)
    {
      if (this.fKeys == null)
        return;
      foreach (string index in new List<string>((IEnumerable<string>) this.fKeys.Keys))
      {
        int fKey = this.fKeys[index];
        if (fKey >= changedIndex && fKey < changedIndex + changedCount)
          this.fKeys[index] = newIndex + (fKey - changedIndex);
        else if (fKey >= newIndex && fKey < changedIndex)
          this.fKeys[index] = fKey + changedCount;
        else if (fKey >= changedIndex + changedCount && fKey <= newIndex)
          this.fKeys[index] = fKey - changedCount;
      }
    }

    public void BeforeAddItems(int index, int count)
    {
      if (this.fKeys == null)
        return;
      foreach (string index1 in new List<string>((IEnumerable<string>) this.fKeys.Keys))
      {
        int fKey = this.fKeys[index1];
        if (fKey >= index)
          this.fKeys[index1] = fKey + count;
      }
    }

    public void BeforeRemoveItems(int index, int count)
    {
      if (this.fKeys == null)
        return;
      int num = index + count;
      foreach (string key in new List<string>((IEnumerable<string>) this.fKeys.Keys))
      {
        int fKey = this.fKeys[key];
        if (fKey >= num)
          this.fKeys[key] = fKey - count;
        else if (fKey >= index)
          this.fKeys.Remove(key);
      }
    }

    public void RemoveKey(string key)
    {
      this.fKeys.Remove(this.AdjustKey(key));
    }

    public void Clear()
    {
      this.fKeys = (Dictionary<string, int>) null;
    }
  }
}
