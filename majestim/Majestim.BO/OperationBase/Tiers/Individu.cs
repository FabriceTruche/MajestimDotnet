using Majestim.DTO.Enum;

namespace Majestim.BO.OperationBase.Tiers
{
    public class Individu : Tiers
    {
        public override string Nom { get; set; }
        public string  Prenom { get; set; }
        public TypeCivilite TypeCivilite { get; set; }
        public string NomLong => this.TypeCivilite + " " + this.Prenom + " " + this.Nom ;
    }
}