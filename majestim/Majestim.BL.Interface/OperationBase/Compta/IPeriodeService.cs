using System;
using System.Collections.Generic;

namespace Majestim.BL.Interface.OperationBase.Compta
{
    public interface IPeriodeService
    {
        /// <summary>
        /// retourne vrai si les 2 date sont de la même période
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        bool SamePeriode(DateTime? d1, DateTime? d2);

        /// <summary>
        /// retourne vrai si les 2 date sont de la même période
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        bool SamePeriode(DateTime d1, DateTime d2);

        /// <summary>
        /// retoure la date du dernier jour du mois de la date passée 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        DateTime DernieJourMois(DateTime date);

        /// <summary>
        /// retouen le nb de jours dans le mois de la date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        int NbJoursMois(DateTime date);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        int DiffMois(DateTime d1, DateTime d2);

        /// <summary>
        /// retourne une liste de période entredabns lintervalle min, max
        /// </summary>
        /// <param name="minFromOrigin"></param>
        /// <param name="maxFromOrigin"></param>
        /// <returns></returns>
        IList<DateTime> CreatePeriodes(int minFromOrigin, int maxFromOrigin);

        /// <summary>
        /// retourne vrai si d1 précède d2 strictement)
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        bool PeriodeLowerThan(DateTime d1, DateTime d2);
    }
}