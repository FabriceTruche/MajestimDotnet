using System.Collections.Generic;
using Majestim.BL.Interface.OperationBanque.RapproBancaire;
using Majestim.BO.OperationBanque.RapproBancaire;
using Majestim.DTO.DTO;
using Majestim.Interface;

namespace Majestim.BL.OperationBanque.RapproBancaire
{
    public abstract class AnalyzerRappro : IAnalyzerRappro
    {
        protected IContext Context { get; }

        protected AnalyzerRappro(RegleRapproDto regle, IContext context)
        {
            this.Context = context;
            this.Regle = regle;
        }

        public RegleRapproDto Regle { get; }

        public abstract IList<LigneRapproCompta> AnalyzeLigneBanque(LigneBanque lb);
    }
}