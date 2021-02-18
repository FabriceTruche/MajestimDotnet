using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class PLAN_CHARGES : IIdentity
	{
		public int ID { get; set; }
		public double MONTANT { get; set; }
		public string COMMENTAIRE { get; set; }
		public int EXERCICE_ID { get; set; }
		public int CHARGE_ID { get; set; }
	}
}
