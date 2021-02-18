using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class LienIndividuDto : IIdentity
	{
		public int ID { get; set; }
		public string Commentaire { get; set; }
		public int Individu_ID { get; set; }
		public int IndividuLie_ID { get; set; }
		public int TypeLienIndividu_ID { get; set; }
	}
}
