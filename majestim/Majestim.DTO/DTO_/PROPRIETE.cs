using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class PROPRIETE : IIdentity
	{
		public int ID { get; set; }
		public string NOM { get; set; }
		public string VALEUR { get; set; }
		public string COMMENTAIRE { get; set; }
		public int BIEN_ID { get; set; }
	}
}
