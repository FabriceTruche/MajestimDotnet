using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class LIGNE_APPEL_DEFINITION : IIdentity
	{
		public int ID { get; set; }
		public string CODE { get; set; }
		public string LIBELLE { get; set; }
		public int? COMPTE_ID { get; set; }
	}
}
