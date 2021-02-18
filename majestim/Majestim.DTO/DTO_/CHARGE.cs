using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class CHARGE : IIdentity
	{
		public int ID { get; set; }
		public string NOM { get; set; }
		public string LIBELLE { get; set; }
		public bool CHARGE_COMMUNE { get; set; }
		public int COMPTE_ID { get; set; }
		public int BASE_REPART_ID { get; set; }
		public int TYPE_CHARGE_ID { get; set; }
	}
}
