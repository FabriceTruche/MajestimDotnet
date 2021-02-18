using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class PARAM_COMPTE_REGUL : IIdentity
	{
		public int ID { get; set; }
		public string LIBELLE { get; set; }
		public bool REGUL { get; set; }
		public bool SOLDE { get; set; }
		public int COMPTE_ID { get; set; }
	}
}
