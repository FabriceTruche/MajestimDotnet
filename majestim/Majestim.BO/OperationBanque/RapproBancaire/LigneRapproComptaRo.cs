using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Majestim.DTO.DTO;
using Majestim.DTO.Enum;

namespace Majestim.BO.OperationBanque.RapproBancaire
{
    public class LigneRapproComptaRo
    {
        private readonly LigneRapproCompta _rapproCompta;

        public LigneRapproComptaRo(LigneRapproCompta rapproCompta)
        {
            this._rapproCompta = rapproCompta;
        }

        [OLVColumn("Id", Width = 30)]
        public int Id { get; set; }

        [OLVColumn("Sél.", Width = 20)]
        public bool Selection { get; set; }

        [OLVColumn("Type de règle levée", Width = 160)]
        public string Regle => this._rapproCompta.Regle.Nom;

        [OLVColumn("Date", Width = 80, AspectToStringFormat = "{0:dd-MMM-yyyy}", TextAlign = HorizontalAlignment.Center)]
        public DateTime Date => this._rapproCompta.Date;

        [OLVColumn("Période", Width = 80, AspectToStringFormat = "{0:MMMM yyyy}", TextAlign = HorizontalAlignment.Center)]
        public DateTime? Periode => this._rapproCompta.Periode;

        [OLVColumn("Libellé", Width = 150)]
        public string Libelle => this._rapproCompta.Libelle;

        [OLVColumn("Opération", Width = 100)]
        public TypeOperation Operation => this._rapproCompta.Operation;

        [OLVColumn("Contrat", Width = 100)]
        public string Contrat => this._rapproCompta.Contrat;

        [OLVColumn("Montant", AspectToStringFormat = "{0:C}", Width = 80, TextAlign = HorizontalAlignment.Right)]
        public double Montant => this._rapproCompta.Montant;

    }
}