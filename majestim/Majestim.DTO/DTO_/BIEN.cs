using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class BIEN : IIdentity
	{
		public int ID { get; set; }
		public string DESCRIPTION { get; set; }
		public string NUMERO { get; set; }
		public int? ADRESSE_ID { get; set; }
	}
}
