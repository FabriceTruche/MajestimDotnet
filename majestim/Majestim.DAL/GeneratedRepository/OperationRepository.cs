
using System.Data;
using Majestim.DAL.DapperRepository;
using Majestim.DTO.DTO;
using Majestim.Interface;
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace Majestim.DAL.Repository
{
    public partial class OperationRepository : Repository<OperationCommand, OperationDto>
    {
        public OperationRepository(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}
