using System;
using System.Collections.Generic;
using BrightIdeasSoftware;

namespace Majestim._TestObjectListView.TestOLV.BO
{
    public class Bien
    {
        public int Id { get; set; }
        public int ImmeubleId { get; set; }
        public string Nom { get; set; }
        public int Surface { get; set; }
        public TypeBien TypeBien { get; set; }
        public DateTime Creation { get; set; }
        public Immeuble ImmeubleObject { get; set; }

        [OLVColumn(IsVisible = false)]
        public List<Tiers> Tiers { get; set; }
    }
}