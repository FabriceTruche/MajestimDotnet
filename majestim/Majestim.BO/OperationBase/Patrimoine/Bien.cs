namespace Majestim.BO.OperationBase.Patrimoine
{
    public class Bien
    {
        public int Id { get; set; }
        public string Nom { get; }
        public string Numero { get; set; }
        public string Description { get; set; }
        public Adresse Adresse { get; set; }
    }
}
