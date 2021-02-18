using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class BASE_REPART_LOT : IIdentity
	{
		public int ID { get; set; }
		public double VALEUR { get; set; }
		public int BASE_REPART_ID { get; set; }
		public int LOT_ID { get; set; }
	}
}
