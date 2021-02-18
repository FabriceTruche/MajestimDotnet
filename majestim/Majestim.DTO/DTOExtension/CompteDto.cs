namespace Majestim.DTO.DTO
{
    public partial class CompteDto
    {
        public override string ToString() => this.Numero + " - " + this.Libelle;
    }
}