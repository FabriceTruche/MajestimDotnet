using System;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Majestim.DTO.DTO;

namespace Majestim.BO.Rapport.SituationLocataire
{
    public class LigneSituationRo
    {
        [OLVColumn(Width = 100)]
        public string Contrat { get; set; }

        [OLVColumn(Width = 100, AspectToStringFormat = "{0:MMMM yyyy}", TextAlign = HorizontalAlignment.Center)]
        public DateTime? Periode { get; set; }

        [OLVColumn(Width = 80, AspectToStringFormat = "{0:dd/MM/yyyy}", TextAlign = HorizontalAlignment.Center)]
        public DateTime? Date { get; set; }

        [OLVColumn("Libellé", Width = 250)]
        public string Libelle { get; set; }

        [OLVColumn("Débit", AspectToStringFormat = "{0:C}", Width = 80, TextAlign = HorizontalAlignment.Right)]
        public double? Debit { get; set; }

        [OLVColumn("Crédit", AspectToStringFormat = "{0:C}", Width = 80, TextAlign = HorizontalAlignment.Right)]
        public double? Credit { get; set; }

        [OLVColumn("Solde", AspectToStringFormat = "{0:C}", Width = 80, TextAlign = HorizontalAlignment.Right)]
        public double? Solde { get; set; }

        [OLVColumn(IsVisible = false)]
        public LigneSituationRoType LigneSituationReportType { get; set; }

        [OLVColumn(IsVisible = false)]
        public string _Contrat { get; set; }

    }
}
