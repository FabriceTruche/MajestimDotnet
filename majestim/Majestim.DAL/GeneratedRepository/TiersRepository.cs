
using System.Data;
using Majestim.DAL.DapperRepository;
using Majestim.DTO.DTO;
using Majestim.Interface;
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace Majestim.DAL.Repository
{
    public partial class TiersRepository : Repository<TiersCommand, TiersDto>
    {
        public TiersRepository(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}