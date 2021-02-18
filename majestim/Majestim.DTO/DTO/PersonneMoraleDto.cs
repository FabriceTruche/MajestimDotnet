using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class PersonneMoraleDto : TiersDto
	{
		public string RaisonSociale { get; set; }
		public int? TypePersonneMorale_ID { get; set; }
		public int? Adresse_ID { get; set; }
	}
}
