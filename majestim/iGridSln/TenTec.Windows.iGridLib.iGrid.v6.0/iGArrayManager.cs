// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGArrayManager
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;

namespace TenTec.Windows.iGridLib
{
  internal class iGArrayManager
  {
    public static void MoveElement(Array array, int srcIndex, int dstIndex, int count)
    {
      if (srcIndex == dstIndex)
        return;
      Array instance = Array.CreateInstance(array.GetType().GetElementType(), count);
      Array.Copy(array, srcIndex, instance, 0, count);
      if (srcIndex < dstIndex)
        Array.Copy(array, srcIndex + count, array, srcIndex, dstIndex - srcIndex);
      else
        Array.Copy(array, dstIndex, array, dstIndex + count, srcIndex - dstIndex);
      Array.Copy(instance, 0, array, dstIndex, count);
    }

    public static Array ExtendArray(Array array, Type elementType, int insertIndex, int insertCount, int oldArrayLen, bool exactSize)
    {
      if (array == null)
        return Array.CreateInstance(elementType, insertCount);
      Array destinationArray;
      if (array.Length < oldArrayLen + insertCount)
      {
        int length;
        if (exactSize)
        {
          length = oldArrayLen + insertCount;
        }
        else
        {
          length = array.Length * 2;
          if (length < oldArrayLen + insertCount)
            length = oldArrayLen + insertCount;
        }
        destinationArray = Array.CreateInstance(elementType, length);
        if (insertIndex > 0)
          Array.Copy(array, 0, destinationArray, 0, insertIndex);
      }
      else
        destinationArray = array;
      if (insertIndex != oldArrayLen)
        Array.Copy(array, insertIndex, destinationArray, insertIndex + insertCount, oldArrayLen - insertIndex);
      return destinationArray;
    }

    public static Array ShortenArray(Array array, Type elementType, int removeIndex, int removeCount, int oldArrayLen, bool fixedSize)
    {
      Array destinationArray;
      if (fixedSize)
      {
        destinationArray = Array.CreateInstance(elementType, oldArrayLen - removeCount);
        if (removeIndex > 0)
          Array.Copy(array, 0, destinationArray, 0, removeIndex);
      }
      else
        destinationArray = array;
      if (removeIndex < oldArrayLen - 1)
        Array.Copy(array, removeIndex + removeCount, destinationArray, removeIndex, oldArrayLen - removeIndex - removeCount);
      return destinationArray;
    }

    public static Array ExtendColsOf2DArray(Array array, int arrayColCount, Type elementType, int insertIndex, int insertCount, object[] defaultValues)
    {
      int num1 = arrayColCount + insertCount;
      Array instance = Array.CreateInstance(elementType, num1 * array.Length / arrayColCount);
      int num2 = array.Length - arrayColCount;
      while (num2 >= 0)
      {
        Array.Copy(array, num2, instance, num2, insertIndex);
        Array.Copy((Array) defaultValues, 0, instance, num2 + insertIndex, insertCount);
        Array.Copy(array, num2 + insertIndex, instance, num2 + insertIndex + insertCount, arrayColCount - insertIndex);
        num2 -= arrayColCount;
      }
      return instance;
    }
  }
}
