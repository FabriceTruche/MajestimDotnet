using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class AdresseDto : IIdentity
	{
		public int ID { get; set; }
		public string Adr1 { get; set; }
		public string Adr2 { get; set; }
		public string Complement { get; set; }
		public string Cp { get; set; }
		public string Ville { get; set; }
		public string Pays { get; set; }
	}
}
