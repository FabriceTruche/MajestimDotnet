using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class BaseRepartDto : IIdentity
	{
		public int ID { get; set; }
		public string Nom { get; set; }
		public string Libelle { get; set; }
		public double Total { get; set; }
	}
}
