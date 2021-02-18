using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class LigneAppelContratDto : IIdentity
	{
		public int ID { get; set; }
		public DateTime? PeriodeDebut { get; set; }
		public DateTime? PeriodeFin { get; set; }
		public string Libelle { get; set; }
		public bool Active { get; set; }
		public double? Debit { get; set; }
		public double? Credit { get; set; }
		public int LigneAppelDefinition_ID { get; set; }
		public int Contrat_ID { get; set; }
	}
}
