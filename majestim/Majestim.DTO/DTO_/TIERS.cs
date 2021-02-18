using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class TIERS : IIdentity
	{
		public int ID { get; set; }
		public string COMMENTAIRE { get; set; }
		public string MAIL { get; set; }
		public string TEL { get; set; }
		public int TYPE_TIERS_ID { get; set; }
	}
}
