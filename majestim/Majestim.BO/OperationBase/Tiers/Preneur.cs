using Majestim.DTO.Enum;

namespace Majestim.BO.OperationBase.Tiers
{
    public class Preneur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Commentaire { get; set; }
        public string TypeTiers { get; set; }
        public string CodeTiers { get; set; }
        public TypePreneur TypePreneur { get; set; }
    }
}