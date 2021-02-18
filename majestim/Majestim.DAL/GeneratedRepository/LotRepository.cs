
using System.Data;
using Majestim.DAL.DapperRepository;
using Majestim.DTO.DTO;
using Majestim.Interface;
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace Majestim.DAL.Repository
{
    public partial class LotRepository : Repository<LotCommand, LotDto>
    {
        public LotRepository(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}
