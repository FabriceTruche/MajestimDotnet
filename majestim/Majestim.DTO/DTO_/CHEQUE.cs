using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class CHEQUE : IIdentity
	{
		public int ID { get; set; }
		public string NOM { get; set; }
		public DateTime? DATE_CREATION { get; set; }
		public DateTime? PERIODE { get; set; }
		public string LIBELLE { get; set; }
		public int BORDEREAU_ID { get; set; }
		public int? OPE_DEPOT_ID { get; set; }
		public int? OPE_ENCAISSEMENT_ID { get; set; }
		public int CONTRAT_ID { get; set; }
	}
}
