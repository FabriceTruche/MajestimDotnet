using System;
using System.Collections.Generic;
using Majestim.BO.OperationBase.Compta;
using Majestim.DTO.DTO;

namespace Majestim.BL.OperationBase.Compta
{
    public class LigneEcritureComparer : IComparer<OperationDto>
    {
        public int Compare(OperationDto x, OperationDto y)
        {
            int comparison = string.Compare(x.Contrat, y.Contrat, StringComparison.InvariantCultureIgnoreCase);
            if (comparison != 0)
                return comparison;

            // même contrat
            if (x.Periode < y.Periode)
                return -1;

            if (x.Periode > y.Periode)
                return 1;

            // même période
            return x.DateOperation < y.DateOperation ? -1 : 1;
        }
    }
}
