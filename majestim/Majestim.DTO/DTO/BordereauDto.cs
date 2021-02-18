using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class BordereauDto : IIdentity
	{
		public int ID { get; set; }
		public string Numero { get; set; }
		public DateTime DateCreation { get; set; }
		public string Libelle { get; set; }
	}
}
