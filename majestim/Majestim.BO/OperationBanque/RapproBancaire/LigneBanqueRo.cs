using System;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace Majestim.BO.OperationBanque.RapproBancaire
{
    public class LigneBanqueRo
    {
        private readonly LigneBanque _ligneBanque;

        public LigneBanqueRo(LigneBanque ligneBanque)
        {
            this._ligneBanque = ligneBanque;
        }

        [OLVColumn("Id", Width = 30)]
        public int Id { get; set; }

        [OLVColumn("Date", Width = 100, AspectToStringFormat = "{0:MMMM yyyy}", TextAlign = HorizontalAlignment.Center)]
        public DateTime Date => this._ligneBanque.Date;

        [OLVColumn("Libellé", Width = 150)]
        public string Libelle => this._ligneBanque.Libelle;

        [OLVColumn("Montant", AspectToStringFormat = "{0:C}", Width = 80, TextAlign = HorizontalAlignment.Right)]
        public double Montant => this._ligneBanque.Montant;

        [OLVColumn(IsVisible = true)]
        public LigneBanqueType LigneBanqueType => this._ligneBanque.LigneBanqueType;
    }
}