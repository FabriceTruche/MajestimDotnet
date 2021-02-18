using System;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Majestim.DTO.Enum;

namespace Majestim.BO.OperationBase.Contrat
{
    [Serializable]
    public class ContratRo
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Commentaire { get; set; }
        public bool ApplicationChargesCommunes { get; set; }
        public TypeContrat TypeContrat { get; set; }

        [OLVColumn(AspectToStringFormat = "{0:dd/MM/yyyy}", TextAlign = HorizontalAlignment.Center)]
        public DateTime? DateEntreePrevue { get; set; }

        [OLVColumn(AspectToStringFormat = "{0:dd/MM/yyyy}", TextAlign = HorizontalAlignment.Center)]
        public DateTime? DateEntree { get; set; }

        [OLVColumn(AspectToStringFormat = "{0:dd/MM/yyyy}", TextAlign = HorizontalAlignment.Center)]
        public DateTime? DateSortiePrevue { get; set; }

        //private DateTime? _dateSortiePrevi;
        //[OLVColumn(AspectToStringFormat = "{0:dd/MM/yyyy}", TextAlign = HorizontalAlignment.Center)]
        //public DateTime? DateSortiePrevi
        //{
        //    get => _dateSortiePrevi == DateTime.MinValue ? null : _dateSortiePrevi;
        //    set => _dateSortiePrevi = value;
        //}

        [OLVColumn(AspectToStringFormat = "{0:dd/MM/yyyy}", TextAlign = HorizontalAlignment.Center)]
        public DateTime? DateSortie { get; set; }

        public bool IsActif => this.DateSortie == null;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Nom;
        }

        /// <summary>
        /// return vrai si le contrat est actif pour une période
        /// </summary>
        /// <param name="periode"></param>
        /// <returns></returns>
        public bool IsActifForPeriode(DateTime periode)
        {
            if (this.DateSortie != null)
                return periode < this.DateSortie;

            if (this.DateSortiePrevue != null)
                return periode < this.DateSortiePrevue;

            return true;
        }
    }
}

