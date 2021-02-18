using System;

namespace Majestim._TestBlocks.Resource
{
    public class CssAttribute : Attribute
    {
        public string[] CssClass { get; }

        public CssAttribute(params string[] cssClass)
        {
            this.CssClass = cssClass;
        }
    }
}