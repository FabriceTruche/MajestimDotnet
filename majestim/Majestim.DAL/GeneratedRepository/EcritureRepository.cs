
using System.Data;
using Majestim.DAL.DapperRepository;
using Majestim.DTO.DTO;
using Majestim.Interface;
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace Majestim.DAL.Repository
{
    public partial class EcritureRepository : Repository<EcritureCommand, EcritureDto>
    {
        public EcritureRepository(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}
