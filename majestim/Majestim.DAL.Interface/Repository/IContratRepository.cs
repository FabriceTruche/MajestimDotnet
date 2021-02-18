using System.Collections.Generic;
using Majestim.DAL.Interface.DAL;
using Majestim.DTO.DTO;

namespace Majestim.DAL.Interface.Repository
{
    public interface IContratRepository : IRepository<ContratDto>
    {
        IEnumerable<LotDto> GetLots(int contratId);
        //IEnumerable<Tier> GetPreneurs(int contratId);
    }
}