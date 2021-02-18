using System.Collections.Generic;

namespace Majestim._TestObjectListView.TestOLV.BO
{
    public class Tiers
    {
        public int Id { set; get; }
        public string  Nom { get; set; }
        public string Prenom { get; set; }
        public TypeCivilite TypeCivilite { get; set; }
        public string Tel { get; set; }
    }
}