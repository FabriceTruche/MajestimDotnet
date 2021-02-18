using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class ImmeubleDto : BienDto
	{
		public int? NbLots { get; set; }
		public int? NbEtages { get; set; }
		public int? Surface { get; set; }
		public int? SurfaceJardin { get; set; }
		public int? NbParking { get; set; }
	}
}
