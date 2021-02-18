using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class ParamGenerauxDto : IIdentity
	{
		public int ID { get; set; }
		public string Cle { get; set; }
		public string Valeur { get; set; }
		public string Commentaire { get; set; }
	}
}
