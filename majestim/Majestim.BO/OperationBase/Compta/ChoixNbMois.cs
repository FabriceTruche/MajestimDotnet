namespace Majestim.BO.OperationBase.Compta
{
    public class ChoixNbMois
    {
        public ChoixNbMois()
        {
        }

        public ChoixNbMois(string nbMois)
        {
            if (!int.TryParse(nbMois, out int res) || res < -1)
                return;

            this.NbMois = res;
            this.Libelle = $"Détail à {res} mois";
        }

        public int NbMois { get; set; }
        public string Libelle { get; set; }

        public override string ToString() => this.Libelle;
    }
}