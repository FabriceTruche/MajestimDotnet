using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class PRENEUR : IIdentity
	{
		public int ID { get; set; }
		public string COMMENTAIRE { get; set; }
		public int CONTRAT_ID { get; set; }
		public int TIERS_ID { get; set; }
		public int TYPE_PRENEUR_ID { get; set; }
	}
}
