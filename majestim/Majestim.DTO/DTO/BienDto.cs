using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class BienDto : IIdentity
	{
		public int ID { get; set; }
		public string Description { get; set; }
		public string Numero { get; set; }
		public int? Adresse_ID { get; set; }
	}
}
