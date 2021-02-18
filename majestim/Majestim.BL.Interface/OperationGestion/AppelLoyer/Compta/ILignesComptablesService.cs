using System;
using System.Collections.Generic;
using Majestim.BO.OperationGestion.AppelLoyer;

namespace Majestim.BL.Interface.OperationGestion.AppelLoyer.Compta
{
    public interface ILignesComptablesService
    {
        /// <summary>
        /// créer les mouvements comptables des lignes d'appel pour la période donnée
        /// </summary>
        /// <param name="appels"></param>
        /// <returns>retourne crai si compta générée, faux sinon</returns>
        bool CreateLignesComptables(IList<LigneAppel> appels);
    }
}