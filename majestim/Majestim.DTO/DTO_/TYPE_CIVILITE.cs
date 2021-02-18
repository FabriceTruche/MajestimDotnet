using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class TYPE_CIVILITE : IIdentity, IDico
	{
		public int ID { get; set; }
		public string CODE { get; set; }
		public string LIBELLE { get; set; }
	}
}
