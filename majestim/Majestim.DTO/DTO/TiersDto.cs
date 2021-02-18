using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class TiersDto : IIdentity
	{
		public int ID { get; set; }
		public string Commentaire { get; set; }
		public string Mail { get; set; }
		public string Tel { get; set; }
		public int TypeTiers_ID { get; set; }
	}
}
