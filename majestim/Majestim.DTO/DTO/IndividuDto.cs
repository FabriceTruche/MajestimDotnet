using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class IndividuDto : TiersDto
	{
		public string Nom { get; set; }
		public string Prenom { get; set; }
		public int TypeCivilite_ID { get; set; }
	}
}
