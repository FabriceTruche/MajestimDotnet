using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class LOT : BIEN
	{
		public string ETAGE { get; set; }
		public string ORIENTATION { get; set; }
		public int SURFACE { get; set; }
		public string ENTREE { get; set; }
		public int? IMMEUBLE_ID { get; set; }
		public int TYPE_LOT_ID { get; set; }
	}
}
