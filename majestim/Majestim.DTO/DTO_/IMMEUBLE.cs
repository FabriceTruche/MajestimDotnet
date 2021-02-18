using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class IMMEUBLE : BIEN
	{
		public int NB_LOTS { get; set; }
		public int NB_ETAGES { get; set; }
		public int SURFACE { get; set; }
		public int SURFACE_JARDIN { get; set; }
		public int NB_PARKING { get; set; }
	}
}
