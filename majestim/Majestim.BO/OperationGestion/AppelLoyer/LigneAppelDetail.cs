using System;
using Majestim.DTO.DTO;

namespace Majestim.BO.OperationGestion.AppelLoyer
{
    public class LigneAppelDetail
    {
        public string TypeLigne { get; set; }
        public string Libelle { get; set; }
        public string Compte { get; set; }
        public int CompteId { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public double? DebitInitial { get; set; }
        public double? CreditInitial { get; set; }
        public double? Debit { get; set; }
        public double? Credit { get; set; }
    }
}