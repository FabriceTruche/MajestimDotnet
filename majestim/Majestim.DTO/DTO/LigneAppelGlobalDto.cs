using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class LigneAppelGlobalDto : IIdentity
	{
		public int ID { get; set; }
		public int TypeAppel_ID { get; set; }
		public int LigneAppelDefinition_ID { get; set; }
	}
}
