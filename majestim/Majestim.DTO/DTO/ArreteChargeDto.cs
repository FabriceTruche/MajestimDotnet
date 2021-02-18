using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class ArreteChargeDto : IIdentity
	{
		public int ID { get; set; }
		public DateTime DateArrete { get; set; }
		public double ValeurIndex { get; set; }
		public string Commentaire { get; set; }
		public int? Charge_ID { get; set; }
		public int? Bien_ID { get; set; }
		public int? Contrat_ID { get; set; }
		public int? Operation_ID { get; set; }
	}
}
