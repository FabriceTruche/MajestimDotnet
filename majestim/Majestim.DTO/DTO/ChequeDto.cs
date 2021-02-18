using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class ChequeDto : IIdentity
	{
		public int ID { get; set; }
		public string Nom { get; set; }
		public DateTime DateCreation { get; set; }
		public DateTime Periode { get; set; }
		public double Montant { get; set; }
		public string Libelle { get; set; }
		public int Bordereau_ID { get; set; }
		public int? OpeDepot_ID { get; set; }
		public int? OpeEncaissement_ID { get; set; }
		public int? Contrat_ID { get; set; }
	}
}
