using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class PlanChargesDto : IIdentity
	{
		public int ID { get; set; }
		public double Montant { get; set; }
		public string Commentaire { get; set; }
		public int Exercice_ID { get; set; }
		public int Charge_ID { get; set; }
	}
}
