using System.Collections.Generic;
using Majestim.BO.OperationBanque.RapproBancaire;
using Majestim.DTO.DTO;
using Majestim.Interface;

namespace Majestim.BL.OperationBanque.RapproBancaire.Analyzer
{
    // ReSharper disable once InconsistentNaming
    public class AnalyzerRapproVirementCAF: AnalyzerRappro
    {
        public AnalyzerRapproVirementCAF(RegleRapproDto regle, IContext context) : base(regle, context)
        {
        }

        public override IList<LigneRapproCompta> AnalyzeLigneBanque(LigneBanque lb)
        {
            return null;
        }
    }
}