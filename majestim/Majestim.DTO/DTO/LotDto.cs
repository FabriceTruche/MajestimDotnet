using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class LotDto : BienDto
	{
		public string Etage { get; set; }
		public string Orientation { get; set; }
		public int? Surface { get; set; }
		public string Entree { get; set; }
		public int? Immeuble_ID { get; set; }
		public int TypeLot_ID { get; set; }
	}
}
