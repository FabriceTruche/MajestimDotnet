namespace Majestim.BO.OperationBase.Compta
{
    public class ChoixCompte
    {
        public ChoixCompte(string numeroCompte, string libelle)
        {
            this.NumeroCompte = numeroCompte;
            this.Libelle = libelle;
        }

        public string NumeroCompte { get;  }
        public string Libelle { get;  }

        public override string ToString() => this.NumeroCompte + " - " + this.Libelle;
    }
}