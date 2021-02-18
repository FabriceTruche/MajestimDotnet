using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class CompteDto : IIdentity
	{
		public int ID { get; set; }
		public string Numero { get; set; }
		public string Libelle { get; set; }
	}
}
