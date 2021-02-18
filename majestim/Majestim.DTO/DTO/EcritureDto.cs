using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class EcritureDto : IIdentity
	{
		public int ID { get; set; }
		public string Libelle { get; set; }
		public double? Debit { get; set; }
		public double? Credit { get; set; }
		public int Compte_ID { get; set; }
		public int Operation_ID { get; set; }
	}
}
