
using System.Data;
using Majestim.DAL.DapperRepository;
using Majestim.DTO.DTO;
using Majestim.Interface;
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace Majestim.DAL.Repository
{
    public partial class ArreteChargeRepository : Repository<ArreteChargeCommand, ArreteChargeDto>
    {
        public ArreteChargeRepository(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}
