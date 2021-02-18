using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class LIGNE_APPEL_GLOBAL : IIdentity
	{
		public int ID { get; set; }
		public int TYPE_APPEL_ID { get; set; }
		public int LIGNE_APPEL_DEFINITION_ID { get; set; }
	}
}
