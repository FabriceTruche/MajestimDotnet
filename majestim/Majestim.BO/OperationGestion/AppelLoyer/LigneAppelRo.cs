using System;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Majestim.DTO.Enum;

namespace Majestim.BO.OperationGestion.AppelLoyer
{
    public class LigneAppelRo
    {
        [OLVColumn(Width = 100)]
        public string Contrat { get; set; }

        [OLVColumn(Width = 65)]
        public TypeAppel? TypeAppel { get; set; }

        [OLVColumn(IsVisible = false, Width = 80, AspectToStringFormat = "{0:dd/MM/yyyy}", TextAlign = HorizontalAlignment.Center)]
        public DateTime? Periode { get; set; }

        [OLVColumn("Libellé", Width = 250)]
        public string Libelle { get; set; }

        [OLVColumn(Width = 80, TextAlign = HorizontalAlignment.Center)]
        public string Compte { get; set; }

        [OLVColumn("Débit", AspectToStringFormat = "{0:C}", Width = 80, TextAlign = HorizontalAlignment.Right)]
        public double? Debit { get; set; }

        [OLVColumn("Crédit", AspectToStringFormat = "{0:C}", Width = 80, TextAlign = HorizontalAlignment.Right)]
        public double? Credit { get; set; }

        [OLVColumn("Etat de l'appel", IsVisible = false, Width = 65, TextAlign = HorizontalAlignment.Center)]
        public bool? Exists { get; set; }

        [OLVColumn(IsVisible = false)]
        public LigneAppelRoType LigneAppelLoyerReportType { get; set; }

        [OLVColumn(IsVisible = false)]
        public bool DejaAppele { get; set; }
    }
}