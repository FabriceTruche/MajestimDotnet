using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class ARRETE_CHARGE : IIdentity
	{
		public int ID { get; set; }
		public DateTime? DATE_ARRETE { get; set; }
		public double VALEUR_INDEX { get; set; }
		public string COMMENTAIRE { get; set; }
		public int? CHARGE_ID { get; set; }
		public int? BIEN_ID { get; set; }
		public int? CONTRAT_ID { get; set; }
		public int? OPERATION_ID { get; set; }
	}
}
