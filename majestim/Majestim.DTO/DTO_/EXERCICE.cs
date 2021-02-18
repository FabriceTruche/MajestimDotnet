using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class EXERCICE : IIdentity
	{
		public int ID { get; set; }
		public string NOM { get; set; }
		public DateTime? DATE_DEBUT { get; set; }
		public DateTime? DATE_FIN { get; set; }
		public string COMMENTAIRE { get; set; }
	}
}
