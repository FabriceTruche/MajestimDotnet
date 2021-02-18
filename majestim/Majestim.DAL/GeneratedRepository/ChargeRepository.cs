
using System.Data;
using Majestim.DAL.DapperRepository;
using Majestim.DTO.DTO;
using Majestim.Interface;
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace Majestim.DAL.Repository
{
    public partial class ChargeRepository : Repository<ChargeCommand, ChargeDto>
    {
        public ChargeRepository(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}
