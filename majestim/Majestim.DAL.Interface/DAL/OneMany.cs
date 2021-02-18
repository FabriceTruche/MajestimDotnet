using Majestim.DTO.Interface;
using System.Collections.Generic;

namespace Majestim.DAL.Interface.DAL
{
    public class OneMany<TMaster, TSlave> : Dictionary<TMaster, IList<TSlave>>
        where TMaster : IIdentity
        where TSlave : IIdentity
    {
        public OneMany(IEqualityComparer<TMaster> comparer) : base(comparer)
        {
        }
    }
}
