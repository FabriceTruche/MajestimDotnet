using System;

namespace Majestim._TestBlocks.Resource
{
    public class LabelAttribute : Attribute
    {
        public string Label { get; }

        public LabelAttribute(string label)
        {
            this.Label = label;
        }
    }
}