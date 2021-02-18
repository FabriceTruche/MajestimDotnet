using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class LIGNE_RAPPROCHEMENT : IIdentity
	{
		public int ID { get; set; }
		public string TEXT_PATTERN { get; set; }
		public double MONTANT { get; set; }
		public string LIBELLE { get; set; }
		public bool ACTIVE { get; set; }
		public int COMPTE_DEBIT_ID { get; set; }
		public int COMPTE_CREDIT_ID { get; set; }
	}
}
