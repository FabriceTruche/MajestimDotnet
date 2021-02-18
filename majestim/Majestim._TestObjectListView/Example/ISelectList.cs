using System.Collections.Generic;
using Majestim._TestObjectListView.TestOLV;

namespace Majestim._TestObjectListView.Example
{
    public interface ISelectList
    {
        IEnumerable<object> SelectItems(object rowObject);
    }
}