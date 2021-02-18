namespace Majestim.BO.OperationBase.Tiers
{
    public abstract class Tiers
    {
        public int Id { get; set; }
        public abstract string Nom { get; set; }
        public string Commentaire { get; set; }
        public string Mail { get; set; }
        public string Tel { get; set; }
    }
}