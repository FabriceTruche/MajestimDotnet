using System;

namespace Majestim.BO.OperationBase.Compta
{
    public class ChoixPeriode
    {
        public ChoixPeriode(string defautLibelle)
        {
            this.Periode = DateTime.MinValue;
            this.Libelle = defautLibelle;
        }

        public ChoixPeriode(DateTime periode)
        {
            this.Periode = periode;
            this.Libelle = $"{periode:MMMM yyyy}";
        }

        public ChoixPeriode(DateTime periode, string libelle)
        {
            this.Periode = periode;
            this.Libelle = libelle;
        }

        public DateTime Periode { get; }
        public string Libelle { get; }

        public override string ToString() => this.Libelle;
    }
}