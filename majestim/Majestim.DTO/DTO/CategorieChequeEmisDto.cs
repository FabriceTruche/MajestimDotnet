using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class CategorieChequeEmisDto : IIdentity
	{
		public int ID { get; set; }
		public string Nom { get; set; }
		public string Libelle { get; set; }
		public int CompteCredit_ID { get; set; }
		public int CompteDebit_ID { get; set; }
	}
}
