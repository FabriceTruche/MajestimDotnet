using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class TypeLotDto : IIdentity, IDico
	{
		public int ID { get; set; }
		public string Code { get; set; }
		public string Libelle { get; set; }
	}
}
