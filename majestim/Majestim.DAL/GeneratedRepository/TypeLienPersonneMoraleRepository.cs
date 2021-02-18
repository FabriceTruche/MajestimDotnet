
using System.Data;
using Majestim.DAL.DapperRepository;
using Majestim.DTO.DTO;
using Majestim.Interface;
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace Majestim.DAL.Repository
{
    public partial class TypeLienPersonneMoraleRepository : Repository<TypeLienPersonneMoraleCommand, TypeLienPersonneMoraleDto>
    {
        public TypeLienPersonneMoraleRepository(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}
