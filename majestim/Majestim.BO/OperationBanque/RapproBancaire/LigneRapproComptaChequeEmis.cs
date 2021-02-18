using Majestim.DTO.DTO;

namespace Majestim.BO.OperationBanque.RapproBancaire
{
    public class LigneRapproComptaChequeEmis : LigneRapproCompta
    {
        public ChequeEmisDto ChequeEmisDto { get; set; }

        public LigneRapproComptaChequeEmis(RegleRapproDto regle) : base(regle)
        {
        }
    }
}