using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class LigneAppelLotDto : IIdentity
	{
		public int ID { get; set; }
		public double? Debit { get; set; }
		public double? Credit { get; set; }
		public int Lot_ID { get; set; }
		public int LigneAppelDefinition_ID { get; set; }
	}
}
