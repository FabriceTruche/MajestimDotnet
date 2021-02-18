using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class BASE_REPART : IIdentity
	{
		public int ID { get; set; }
		public string NOM { get; set; }
		public string LIBELLE { get; set; }
		public double TOTAL { get; set; }
	}
}
