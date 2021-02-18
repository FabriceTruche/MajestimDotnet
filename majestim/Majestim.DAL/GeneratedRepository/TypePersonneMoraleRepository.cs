
using System.Data;
using Majestim.DAL.DapperRepository;
using Majestim.DTO.DTO;
using Majestim.Interface;
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace Majestim.DAL.Repository
{
    public partial class TypePersonneMoraleRepository : Repository<TypePersonneMoraleCommand, TypePersonneMoraleDto>
    {
        public TypePersonneMoraleRepository(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}
