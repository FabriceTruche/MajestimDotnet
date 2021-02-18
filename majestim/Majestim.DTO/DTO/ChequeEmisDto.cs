using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class ChequeEmisDto : IIdentity
	{
		public int ID { get; set; }
		public string Numero { get; set; }
		public DateTime Date { get; set; }
		public string Libelle { get; set; }
		public double Montant { get; set; }
		public int? Contrat_ID { get; set; }
		public int? OpeRetrait_ID { get; set; }
		public int CategorieChequeEmis_ID { get; set; }
	}
}
