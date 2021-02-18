using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class INDIVIDU : TIERS
	{
		public string NOM { get; set; }
		public string PRENOM { get; set; }
		public int TYPE_CIVILITE_ID { get; set; }
	}
}
