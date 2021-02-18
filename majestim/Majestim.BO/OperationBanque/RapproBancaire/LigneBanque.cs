using System;

namespace Majestim.BO.OperationBanque.RapproBancaire
{
    public class LigneBanque
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Libelle { get; set; }
        public double Montant { get; set; }
        public LigneBanqueType LigneBanqueType { get; set; }
    }
}