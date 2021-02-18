using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class LIEN_PERSONNE_MORALE : IIdentity
	{
		public int ID { get; set; }
		public string COMMENTAIRE { get; set; }
		public int INDIVIDU_ID { get; set; }
		public int TYPE_LIEN_PERSONNE_MORALE_ID { get; set; }
		public int PERSONNE_MORALE_ID { get; set; }
	}
}
