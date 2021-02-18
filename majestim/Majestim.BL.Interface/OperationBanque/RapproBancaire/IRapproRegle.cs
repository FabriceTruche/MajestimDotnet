using System.Collections.Generic;
using Majestim.BO.OperationBanque.RapproBancaire;
using Majestim.DTO.DTO;

namespace Majestim.BL.Interface.OperationBanque.RapproBancaire
{
    public interface IAnalyzerRappro
    {
        /// <summary>
        /// règle de rapprochement associée
        /// </summary>
        RegleRapproDto Regle { get; }

        /// <summary>
        /// vérifie si la ligne de banque est validée par la règle métier
        /// </summary>
        /// <param name="lb"></param>
        /// <returns>l'ensemble des lignes compta à écrire</returns>
        IList<LigneRapproCompta> AnalyzeLigneBanque(LigneBanque lb);
    }
}