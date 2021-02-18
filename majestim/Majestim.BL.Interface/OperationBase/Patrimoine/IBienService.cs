using System.Collections.Generic;
using Majestim.BO.OperationBase.Patrimoine;

namespace Majestim.BL.Interface.OperationBase.Patrimoine
{
    public interface IBienService
    {
        IEnumerable<Bien> GetBiens();
    }
}