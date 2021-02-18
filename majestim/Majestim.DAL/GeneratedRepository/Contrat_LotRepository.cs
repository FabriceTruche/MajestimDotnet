
using System.Data;
using Majestim.DAL.DapperRepository;
using Majestim.DTO.DTO;
using Majestim.Interface;
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace Majestim.DAL.Repository
{
    public partial class Contrat_LotRepository : Repository<Contrat_LotCommand, Contrat_LotDto>
    {
        public Contrat_LotRepository(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}
