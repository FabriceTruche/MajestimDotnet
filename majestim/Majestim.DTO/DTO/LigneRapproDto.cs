using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class LigneRapproDto : IIdentity
	{
		public int ID { get; set; }
		public string RePattern { get; set; }
		public double? Montant { get; set; }
		public string Libelle { get; set; }
		public bool Active { get; set; }
		public int CompteDebit_ID { get; set; }
		public int CompteCredit_ID { get; set; }
	}
}
