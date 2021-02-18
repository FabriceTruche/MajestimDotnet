using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class Contrat_LotDto : IIdentity
	{
		public int ID { get; set; }
		public int Contrat_ID { get; set; }
		public int Lot_ID { get; set; }
	}
}
