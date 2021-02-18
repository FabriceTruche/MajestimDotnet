using System.Collections.Generic;
using Dapper;
using Majestim.DAL.Interface.Repository;
using Majestim.DTO.DTO;

namespace Majestim.DAL.Repository
{
    public partial class ContratRepository : IContratRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contratId"></param>
        /// <returns></returns>
        public IEnumerable<LotDto> GetLots(int contratId)
        {
            IEnumerable<LotDto> lots = this.Query<LotDto>($@"
select l.*
from contrat as c , lot as l, contratLot as cl
where c.id = cl.CONTRAT_ID
and l.id = cl.LOT_ID
and c.ID = {contratId}
");

            return lots;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contratId"></param>
        /// <returns></returns>
//        public IEnumerable<TIERS_PRENEUR> GetPreneurs(int contratId)
//        {
//            IEnumerable<TIERS_PRENEUR> preneurs = this.Query<TIERS_PRENEUR>($@"
//select tv.id, tv.nom, tv.type_tiers, p.commentaire, p.type_preneur_id
//from preneur as p, tiers_view as tv
//where p.CONTRAT_ID = {contratId}
//and p.tiers_id = tv.id");

//            return preneurs;
//        }
    }
}