using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class ParamCompteRegulDto : IIdentity
	{
		public int ID { get; set; }
		public string Libelle { get; set; }
		public bool Regul { get; set; }
		public bool Solde { get; set; }
		public int Compte_ID { get; set; }
	}
}
