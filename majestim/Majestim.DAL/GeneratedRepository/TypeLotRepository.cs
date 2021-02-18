
using System.Data;
using Majestim.DAL.DapperRepository;
using Majestim.DTO.DTO;
using Majestim.Interface;
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace Majestim.DAL.Repository
{
    public partial class TypeLotRepository : Repository<TypeLotCommand, TypeLotDto>
    {
        public TypeLotRepository(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}
