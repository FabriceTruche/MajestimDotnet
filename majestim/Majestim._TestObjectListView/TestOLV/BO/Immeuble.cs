namespace Majestim._TestObjectListView.TestOLV.BO
{
    public class Immeuble 
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Adr1 { get; set; }
        public string Adr2 { get; set; }
        public string Cp { get; set; }
        public string Ville { get; set; }

        // texte affiché dans une liste dont l'immeuble est associé
        public override string ToString()
        {
            return Adr1 + " - " + Cp + " - " + Ville;
        }
    }
}