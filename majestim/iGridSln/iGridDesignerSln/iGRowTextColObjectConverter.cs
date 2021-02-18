// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.Design.iGRowTextColObjectConverter
// Assembly: TenTec.Windows.iGridLib.iGrid.Design.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 7D1E160B-C191-4CB3-823A-4AFF0278B228
// Assembly location: C:\Users\Fabrice\source\repos\Majestim\iGridSln\TenTec.Windows.iGridLib.iGrid.Design.v6.0.dll

namespace TenTec.Windows.iGridLib.Design
{
    internal sealed class PrivateImplementationDetails
    {
        internal static uint ComputeStringHash(string s)
        {
            uint num = new uint();
            if (s != null)
            {
                num = 0x811c9dc5;
                for (int i = 0; i < s.Length; i++)
                {
                    num = (s[i] ^ num) * 0x1000193;
                }
            }
            return num;
        }
    }

    internal class iGRowTextColObjectConverter : iGExpandableTypeConverter
  {
    public override bool FilterProperties(string propertyName)
    {
      if (propertyName != null)
      {
        // ISSUE: reference to a compiler-generated method
        //uint stringHash = \u003CPrivateImplementationDetails\u003E.ComputeStringHash(propertyName);
        // FABRICE
        uint stringHash = PrivateImplementationDetails.ComputeStringHash(propertyName);
        if (stringHash <= 1647479251U)
        {
          if (stringHash <= 1041509726U)
          {
            if ((int) stringHash != 994238399)
            {
              if ((int) stringHash != 1041509726 || !(propertyName == "Text"))
                goto label_21;
            }
            else if (!(propertyName == "Width"))
              goto label_21;
          }
          else if ((int) stringHash != 1495943489)
          {
            if ((int) stringHash != 1625709358)
            {
              if ((int) stringHash != 1647479251 || !(propertyName == "MaxWidth"))
                goto label_21;
            }
            else if (!(propertyName == "ColHdrStyle"))
              goto label_21;
          }
          else if (!(propertyName == "Visible"))
            goto label_21;
        }
        else if (stringHash <= 2682127708U)
        {
          if ((int) stringHash != 2041341998)
          {
            if ((int) stringHash != -1612839588 || !(propertyName == "AllowSizing"))
              goto label_21;
          }
          else if (!(propertyName == "ImageIndex"))
            goto label_21;
        }
        else if ((int) stringHash != -899647112)
        {
          if ((int) stringHash != -758080325)
          {
            if ((int) stringHash != -24650279 || !(propertyName == "MinWidth"))
              goto label_21;
          }
          else if (!(propertyName == "AllowGrouping"))
            goto label_21;
        }
        else if (!(propertyName == "AllowMoving"))
          goto label_21;
        return false;
      }
label_21:
      return true;
    }
  }
}
