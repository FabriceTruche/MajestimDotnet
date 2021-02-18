using System;
using System.Collections.Generic;
using Majestim.BO.OperationBase.Contrat;
using Majestim.BO.OperationGestion.AppelLoyer;

namespace Majestim.BL.Interface.OperationGestion.AppelLoyer.Compta
{
    public interface ILignesAppelsService
    {
        /// <summary>
        /// retourne les lignes d'appels d'un contrat pour une période
        /// </summary>
        /// <param name="baux"></param>
        /// <param name="periode"></param>
        /// <returns></returns>
        IList<LigneAppel> CreateLignesAppel(IList<ContratRo> baux, DateTime periode);

        /// <summary>
        /// retourn les lignes d'appels pour une période , pour tous les contrats (actifs)
        /// </summary>
        /// <param name="periode"></param>
        /// <returns></returns>
        IList<LigneAppel> CreateLignesAppel(DateTime periode);
    }
}