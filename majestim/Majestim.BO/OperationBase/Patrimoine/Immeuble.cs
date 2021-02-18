namespace Majestim.BO.OperationBase.Patrimoine
{
    public class Immeuble : Bien
    {
        public int NbLots { get; set; }
        public int Surface { get; set; }

        public override string ToString()
        {
            return $"{this.Numero} {this.Nom} {this.Description}";
        }
    }
}