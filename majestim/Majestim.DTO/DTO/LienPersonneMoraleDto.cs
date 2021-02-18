using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class LienPersonneMoraleDto : IIdentity
	{
		public int ID { get; set; }
		public string Commentaire { get; set; }
		public int Individu_ID { get; set; }
		public int TypeLienPersonneMorale_ID { get; set; }
		public int PersonneMorale_ID { get; set; }
	}
}
