using Majestim.DTO.Enum;

namespace Majestim.BO.OperationBase.Patrimoine
{
    public class Lot : Bien
    {
        public Immeuble Immeuble { get; set; }
        public string Entree { get; set; }
        public string Etage { get; set; }
        public TypeLot TypeLot { get; set; }
    }
}