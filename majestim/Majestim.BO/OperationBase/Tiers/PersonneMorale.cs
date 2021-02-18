using Majestim.BO.OperationBase.Patrimoine;
using Majestim.DTO.Enum;

namespace Majestim.BO.OperationBase.Tiers
{
    public class PersonneMorale : Tiers
    {
        public override string Nom { get; set; }
        public TypePersonneMorale TypePersonneMorale { get; set; }
        public Adresse Adresse { get; set; }
        public string NomLong => this.TypePersonneMorale + " " + this.Nom;
    }
}