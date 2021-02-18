using System.Collections.Generic;
using Majestim.BO.OperationBanque.RapproBancaire;
using Majestim.DTO.DTO;

namespace Majestim.BL.Interface.OperationBanque.RapproBancaire
{
    public interface IRapproBancaireService
    {
        /// <summary>
        /// importe les données. Retourne une liste de ligne de banque
        /// </summary>
        IList<LigneBanque> ImportData(string data);

        /// <summary>
        /// analyse les lignes de banque pour produire des lignes compta à partir des règles
        /// </summary>
        /// <param name="lignesBanque"></param>
        /// <returns></returns>
        IList<LigneRapproCompta> AnalyzeLignesBanque(IList<LigneBanque> lignesBanque);

        /// <summary>
        /// converti les lignes de banque en datagrid d'objet à afficher
        /// </summary>
        /// <param name="lignesBanque"></param>
        /// <returns></returns>
        IList<LigneBanqueRo> Convert(IList<LigneBanque> lignesBanque);

        /// <summary>
        /// convetrions des lignes de compte en lignes de compta à afficher dans l'UI
        /// </summary>
        /// <param name="lignesCompta"></param>
        /// <returns></returns>
        IList<LigneRapproComptaRo> Convert(IList<LigneRapproCompta> lignesCompta);
    }
}