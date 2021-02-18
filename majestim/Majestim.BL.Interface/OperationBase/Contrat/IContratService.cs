using System;
using System.Collections.Generic;
using Majestim.BO.OperationBase.Contrat;
using Majestim.BO.OperationBase.Patrimoine;
using Majestim.BO.OperationBase.Tiers;
using Majestim.DTO.DTO;
using Majestim.DTO.Enum;

namespace Majestim.BL.Interface.OperationBase.Contrat
{
    public interface IContratService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ContratDto ContratById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ContratDto ContratByName(string name);

        /// <summary>
        /// récupère la liste de tous les contrats en cours
        /// </summary>
        IList<ContratRo> Contrats();

        /// <summary>
        /// contrats actifs
        /// </summary>
        /// <returns></returns>
        IList<ContratRo> ContratsActif();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<ContratDto> ContratsDto();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<ContratDto> ContratsDtoActif();

        /// <summary>
        /// lots d'un contrat
        /// </summary>
        /// <param name="contrat"></param>
        /// <returns></returns>
        IList<Lot> LotsOfContrat(ContratRo contrat);

        /// <summary>
        /// tiers preneurs d'un contrat
        /// </summary>
        /// <param name="contrat"></param>
        /// <returns></returns>
        //IEnumerable<Preneur> PreneursOfContrat(Bail contrat);

        /// <summary>
        /// retourne le type d'appel d'uin contrat
        /// </summary>
        /// <param name="contrat"></param>
        /// <param name="periode"></param>
        /// <returns></returns>
        TypeAppel? TypeDAppel(ContratRo contrat, DateTime periode);
    }
}