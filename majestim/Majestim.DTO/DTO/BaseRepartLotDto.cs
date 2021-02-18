using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class BaseRepartLotDto : IIdentity
	{
		public int ID { get; set; }
		public double Valeur { get; set; }
		public int BaseRepart_ID { get; set; }
		public int Lot_ID { get; set; }
	}
}
