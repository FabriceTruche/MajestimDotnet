using System.Collections.Generic;
using Majestim.BO.OperationBanque.RapproBancaire;
using Majestim.DTO.DTO;
using Majestim.Interface;

namespace Majestim.BL.OperationBanque.RapproBancaire.Analyzer
{
    public class AnalyzerRapproVirementLocataire : AnalyzerRappro
    {
        public AnalyzerRapproVirementLocataire(RegleRapproDto regle, IContext context) : base(regle, context)
        {
        }

        public override IList<LigneRapproCompta> AnalyzeLigneBanque(LigneBanque lb)
        {
            return null;
        }
    }
}