using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class OPERATION : IIdentity
	{
		public int ID { get; set; }
		public int NUM_OPERATION { get; set; }
		public DateTime DATE_OPERATION { get; set; }
		public DateTime? PERIODE { get; set; }
		public int? CONTRAT_ID { get; set; }
		public int TYPE_OPERATION_ID { get; set; }
		public int EXERCICE_ID { get; set; }
	}
}
