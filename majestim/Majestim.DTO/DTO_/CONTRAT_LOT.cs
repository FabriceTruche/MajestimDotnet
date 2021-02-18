using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class CONTRAT_LOT : IIdentity
	{
		public int ID { get; set; }
		public int CONTRAT_ID { get; set; }
		public int LOT_ID { get; set; }
	}
}
