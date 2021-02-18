using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class ChargeDto : IIdentity
	{
		public int ID { get; set; }
		public string Nom { get; set; }
		public string Libelle { get; set; }
		public bool ChargeCommune { get; set; }
		public int Compte_ID { get; set; }
		public int BaseRepart_ID { get; set; }
		public int TypeCharge_ID { get; set; }
	}
}
