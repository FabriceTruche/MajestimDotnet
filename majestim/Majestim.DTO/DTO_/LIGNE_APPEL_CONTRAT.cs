using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class LIGNE_APPEL_CONTRAT : IIdentity
	{
		public int ID { get; set; }
		public DateTime? PERIODE_DEBUT { get; set; }
		public DateTime? PERIODE_FIN { get; set; }
		public string LIBELLE { get; set; }
		public bool ACTIVE { get; set; }
		public double DEBIT { get; set; }
		public double CREDIT { get; set; }
		public int LIGNE_APPEL_DEFINITION_ID { get; set; }
		public int CONTRAT_ID { get; set; }
	}
}
