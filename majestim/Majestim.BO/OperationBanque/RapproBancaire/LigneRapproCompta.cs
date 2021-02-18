using System;
using System.Collections.Generic;
using Majestim.DTO.DTO;
using Majestim.DTO.Enum;

namespace Majestim.BO.OperationBanque.RapproBancaire
{
    public class LigneRapproCompta
    {
        public RegleRapproDto Regle;

        public LigneRapproCompta(RegleRapproDto regle)
        {
            this.Regle = regle;
        }

        public int Id { get; set; }
        public LigneBanque LigneBanque { get; set; }
        public DateTime Date { get; set; }
        public DateTime? Periode { get; set; }
        public string Libelle { get; set; }
        public TypeOperation Operation { get; set; }
        public string Contrat { get; set; }
        public double Montant { get; set; }
        public string CompteDebit { get; set; }
        public string CompteCredit { get; set; }
    }
}