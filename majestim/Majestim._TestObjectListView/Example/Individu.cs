using Majestim.DTO.DTO;

namespace Majestim._TestObjectListView.Example
{
    public class Individu
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }
        public string Tel { get; set; }
        public string Commentaire { get; set; }
        //public TypeTiers TypeTiersEnum { get; set; }

        //[OLVColumn("Civilité")]
        //public TypeCivilite type_civilite { get; set; }
    }
}