namespace Majestim.BO.OperationBase.Patrimoine
{
    public class Adresse
    {
        public int Id { get; set; }
        public string Adr1 { get; set; }
        public string Adr2 { get; set; }
        public string Complement { get; set; }
        public string Cp { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }

        public override string ToString()
        {
            return $"{this.Adr1} {this.Adr2} {this.Cp} {this.Ville}";
        }
    }
}