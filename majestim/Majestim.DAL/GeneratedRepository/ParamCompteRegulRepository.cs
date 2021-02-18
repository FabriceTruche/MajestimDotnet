
using System.Data;
using Majestim.DAL.DapperRepository;
using Majestim.DTO.DTO;
using Majestim.Interface;
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace Majestim.DAL.Repository
{
    public partial class ParamCompteRegulRepository : Repository<ParamCompteRegulCommand, ParamCompteRegulDto>
    {
        public ParamCompteRegulRepository(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}
