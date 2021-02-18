using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class ADRESSE : IIdentity
	{
		public int ID { get; set; }
		public string ADR1 { get; set; }
		public string ADR2 { get; set; }
		public string COMPLEMENT { get; set; }
		public string CP { get; set; }
		public string VILLE { get; set; }
		public string PAYS { get; set; }
	}
}
