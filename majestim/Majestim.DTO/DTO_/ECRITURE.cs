using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class ECRITURE : IIdentity
	{
		public int ID { get; set; }
		public int NUM_ECRITURE { get; set; }
		public string LIBELLE { get; set; }
		public double DEBIT { get; set; }
		public double CREDIT { get; set; }
		public int COMPTE_ID { get; set; }
		public int OPERATION_ID { get; set; }
	}
}
