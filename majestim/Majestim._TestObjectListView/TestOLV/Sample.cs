using System.Collections.Generic;
using System.Linq;
using Majestim._TestObjectListView.TestOLV.BO;

namespace Majestim._TestObjectListView.TestOLV
{
    public class Sample
    {
        public Immeuble[] immeubles;
        public Bien[] biens;
        public Tiers[] Tiers;

        public Sample()
        {
            this.immeubles = new Immeuble[]
            {
                new Immeuble
                {
                    Id = 1,
                    Adr1 = "14 rue Henri Dunant",
                    Cp = "38180",
                    Ville = "SEYSSINS",
                },
                new Immeuble
                {
                    Id = 2,
                    Adr1 = "Hameau Truchere",
                    Cp = "38360",
                    Ville = "NOYAREY",
                },
                new Immeuble
                {
                    Id = 3,
                    Adr1 = "333",
                    Cp = "38360",
                    Ville = "NOYAREY",
                },
                new Immeuble
                {
                    Id = 4,
                    Adr1 = "444",
                    Cp = "38360",
                    Ville = "NOYAREY",
                },
                new Immeuble
                {
                    Id = 5,
                    Adr1 = "555",
                    Cp = "38360",
                    Ville = "NOYAREY",
                },

            };

            this.biens = new Bien[]
            {
                new Bien {Nom = "Studio RC", Surface = 23, TypeBien = TypeBien.Studio, ImmeubleObject=this.immeubles[0]},
                new Bien {Nom = "F1 1er étage", Surface = 33, TypeBien = TypeBien.F1, ImmeubleObject=this.immeubles[0]},
                new Bien {Nom = "F3 RC Montée droite", Surface = 51, TypeBien = TypeBien.F3, ImmeubleObject=this.immeubles[0]},
                new Bien {Nom = "Maison principale", Surface = 300, TypeBien = TypeBien.Maison, ImmeubleObject=this.immeubles[1]},
                new Bien {Nom = "Garage", Surface = 40, TypeBien = TypeBien.Garage, ImmeubleObject=this.immeubles[1]},
            };

            this.Tiers = new []
            {
                new Tiers {Id = 1, Nom = "Jupiter", Prenom = "Fabrice", Tel="0612356", TypeCivilite = TypeCivilite.Mr},
                new Tiers {Id = 2, Nom = "Mars", Prenom = "Erci", Tel="0612356", TypeCivilite = TypeCivilite.Mme},
                new Tiers {Id = 3, Nom = "Lune", Prenom = "Jean", Tel="4444444", TypeCivilite = TypeCivilite.SCI},
                new Tiers {Id = 4, Nom = "Mars", Prenom = "Michel", Tel="789987987", TypeCivilite = TypeCivilite.SCI},
                new Tiers {Id = 5, Nom = "Uranus", Prenom = "Paul", Tel="123456", TypeCivilite = TypeCivilite.Mr},
            };

            biens[0].Tiers = CreateList(new [] { 1, 2, 3 });
            biens[1].Tiers = CreateList(new[] { 2, 3 });
            biens[2].Tiers = CreateList(new[] { 2, 3,4 });
            biens[3].Tiers = CreateList(new[] { 2, 5 });
            biens[4].Tiers = CreateList(new[] { 1, 2, 3, 4, 5 });
        }

        private List<Tiers> CreateList(int[] ids)
        {
            List<Tiers> list = new List<Tiers>();

            foreach (int id in ids)
            {
                list.Add(this.Tiers.Single(x => x.Id==id));    
            }

            return list;
        }
    }
}