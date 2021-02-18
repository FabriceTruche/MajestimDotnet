using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class LIEN_INDIVIDU : IIdentity
	{
		public int ID { get; set; }
		public string COMMENTAIRE { get; set; }
		public int INDIVIDU_ID { get; set; }
		public int INDIVIDU_LIE_ID { get; set; }
		public int TYPE_LIEN_INDIVIDU_ID { get; set; }
	}
}
