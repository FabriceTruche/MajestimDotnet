using System;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace Majestim.BO.Rapport.CompteLocataire
{
    public class LigneComptesLocataireRo
    {
        [OLVColumn(Width = 100, AspectToStringFormat = "{0:MMMM yyyy}", TextAlign = HorizontalAlignment.Center)]
        public DateTime? Periode { get; set; }

        [OLVColumn(Width = 100, IsVisible = false)]
        public string Contrat { get; set; }

        [OLVColumn(Width = 85, IsVisible = true)]
        public string Operation { get; set; }

        [OLVColumn(Width = 80, AspectToStringFormat = "{0:dd/MM/yyyy}", TextAlign = HorizontalAlignment.Center)]
        public DateTime? Date { get; set; }

        [OLVColumn(Width = 80, TextAlign = HorizontalAlignment.Center)]
        public string Compte { get; set; }

        [OLVColumn("Libellé", Width = 200)]
        public string Libelle { get; set; }

        [OLVColumn("Débit", AspectToStringFormat = "{0:C}", Width = 80, TextAlign = HorizontalAlignment.Right)]
        public double? Debit { get; set; }

        [OLVColumn("Crédit", AspectToStringFormat = "{0:C}", Width = 80, TextAlign = HorizontalAlignment.Right)]
        public double? Credit { get; set; }

        [OLVColumn("Solde", AspectToStringFormat = "{0:C}", Width = 80, TextAlign = HorizontalAlignment.Right)]
        public double? Solde { get; set; }

        [OLVColumn(IsVisible = false)]
        public LigneComptesLocataireRoType LigneComptesLocataireReportType { get; set; }

    }
}
