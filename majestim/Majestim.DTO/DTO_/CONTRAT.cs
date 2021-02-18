using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class CONTRAT : IIdentity
	{
		public int ID { get; set; }
		public string NOM { get; set; }
		public string COMMENTAIRE { get; set; }
		public DateTime? DATE_ENTREE_PREVUE { get; set; }
		public DateTime? DATE_SORTIE_PREVUE { get; set; }
		public DateTime? DATE_ENTREE { get; set; }
		public DateTime? DATE_SORTIE { get; set; }
		public bool CHARGES_COMMUNES { get; set; }
		public int TYPE_CONTRAT_ID { get; set; }
	}
}
