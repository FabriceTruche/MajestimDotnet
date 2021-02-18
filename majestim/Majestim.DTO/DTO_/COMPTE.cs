using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class COMPTE : IIdentity
	{
		public int ID { get; set; }
		public string NUMERO { get; set; }
		public string LIBELLE { get; set; }
	}
}
