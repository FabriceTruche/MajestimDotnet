//using System;
//using System.Collections.Generic;
//using System.Data;
//using Dapper;
//using Majestim.DAL.DapperRepository;
//using Majestim.DAL.Interface.DAL;
//using Majestim.DAL.Interface.Repository;
//using Majestim.DTO.DTO;
//using Majestim.DTO.DTOView;
//using Majestim.Interface;
//// ReSharper disable InconsistentNaming

//namespace Majestim.DAL.Repository
//{
//    public class LIGNE_ECRITURE_VIEW_Repository : Repository<LIGNE_ECRITURE_VIEW>, ILIGNE_ECRITURE_VIEW_Repository
//    {
//        public LIGNE_ECRITURE_VIEW_Repository(IContext context) : base(context) {}

//        /// <summary>
//        /// récupérer toutes les écritures selon le contexte
//        /// </summary>
//        /// <param name="contratId"></param>
//        /// <param name="periode"></param>
//        /// <param name="noCompte"></param>
//        /// <returns></returns>
//        public IEnumerable<LIGNE_ECRITURE_VIEW> SelectEcritures(int contratId, DateTime? periode, string noCompte)
//        {
//            return this.Query<LIGNE_ECRITURE_VIEW>("select * from ecriture_view");
//        }
//    }
//}