
using System.Data;
using Majestim.DAL.DapperRepository;
using Majestim.DTO.DTO;
using Majestim.Interface;
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace Majestim.DAL.Repository
{
    public partial class TypeCiviliteRepository : Repository<TypeCiviliteCommand, TypeCiviliteDto>
    {
        public TypeCiviliteRepository(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}
