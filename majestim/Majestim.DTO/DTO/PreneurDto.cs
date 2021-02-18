using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class PreneurDto : IIdentity
	{
		public int ID { get; set; }
		public string Commentaire { get; set; }
		public int Contrat_ID { get; set; }
		public int Tiers_ID { get; set; }
		public int TypePreneur_ID { get; set; }
	}
}
