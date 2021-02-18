using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class ContratDto : IIdentity
	{
		public int ID { get; set; }
		public string Nom { get; set; }
		public string Commentaire { get; set; }
		public DateTime? DateEntreePrevue { get; set; }
		public DateTime? DateSortiePrevue { get; set; }
		public DateTime? DateEntree { get; set; }
		public DateTime? DateSortie { get; set; }
		public bool ChargesCommunes { get; set; }
		public int TypeContrat_ID { get; set; }
	}
}
