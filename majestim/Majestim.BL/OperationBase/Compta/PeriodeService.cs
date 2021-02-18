using System;
using System.Collections.Generic;
using Majestim.BL.Interface.OperationBase.Compta;

namespace Majestim.BL.OperationBase.Compta
{
    public class PeriodeService : IPeriodeService
    {
        public bool SamePeriode(DateTime? d1, DateTime? d2)
        {
            return d1 != null && d2 != null && this.SamePeriode(d1.Value, d2.Value);
        }

        public bool SamePeriode(DateTime d1, DateTime d2)
        {
            return d1.Year == d2.Year && d1.Month == d2.Month;
        }

        public DateTime DernieJourMois(DateTime date)
        {
            return 
                new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1);
        }

        public int NbJoursMois(DateTime date)
        {
            return this.DernieJourMois(date).Day;
        }

        public int DiffMois(DateTime d1, DateTime d2)
        {
            return (d2.Year - d1.Year) * 12 + (d2.Month - d1.Month) + 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="minFromOrigin"></param>
        /// <param name="maxFromOrigin"></param>
        /// <returns></returns>
        public IList<DateTime> CreatePeriodes(int minFromOrigin, int maxFromOrigin)
        {
            List<DateTime> list = new List<DateTime>();
            DateTime currPeriode = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            minFromOrigin = Math.Max(minFromOrigin, -10);
            maxFromOrigin = Math.Min(maxFromOrigin, 10);

            for (int i = minFromOrigin; i <= maxFromOrigin; i++)
                list.Add(currPeriode.AddMonths(i));

            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public bool PeriodeLowerThan(DateTime d1, DateTime d2)
        {
            if (d1.Year < d2.Year) return true;
            if (d1.Year > d2.Year) return false;

            if (d1.Month < d2.Month) return true;
            return false;
        }
    }
}