using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class LIGNE_APPEL_LOT : IIdentity
	{
		public int ID { get; set; }
		public double DEBIT { get; set; }
		public double CREDIT { get; set; }
		public int LOT_ID { get; set; }
		public int LIGNE_APPEL_DEFINITION_ID { get; set; }
	}
}
