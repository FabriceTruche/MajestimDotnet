using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class ProprieteDto : IIdentity
	{
		public int ID { get; set; }
		public string Nom { get; set; }
		public string Valeur { get; set; }
		public string Commentaire { get; set; }
		public int Bien_ID { get; set; }
	}
}
