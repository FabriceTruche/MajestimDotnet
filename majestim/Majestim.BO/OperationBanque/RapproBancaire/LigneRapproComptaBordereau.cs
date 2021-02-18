using Majestim.DAL.Interface.DAL;
using Majestim.DTO.DTO;

namespace Majestim.BO.OperationBanque.RapproBancaire
{
    public class LigneRapproComptaBordereau : LigneRapproCompta
    {
        public BordereauDto Bordereau { get; set; }
        public ChequeDto Cheque { get; set; }

        public LigneRapproComptaBordereau(RegleRapproDto regle) : base(regle)
        {
        }
    }
}