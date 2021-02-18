using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class OperationDto : IIdentity
	{
		public int ID { get; set; }
		public DateTime DateOperation { get; set; }
		public string Commentaire { get; set; }
		public DateTime Periode { get; set; }
		public int? Contrat_ID { get; set; }
		public int TypeOperation_ID { get; set; }
		public int Exercice_ID { get; set; }
	}
}
