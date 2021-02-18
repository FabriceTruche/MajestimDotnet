using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class PERSONNE_MORALE : TIERS
	{
		public string RAISON_SOCIALE { get; set; }
		public int? TYPE_PERSONNE_MORALE_ID { get; set; }
		public int? ADRESSE_ID { get; set; }
	}
}
