using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class ExerciceDto : IIdentity
	{
		public int ID { get; set; }
		public string Nom { get; set; }
		public DateTime DateDebut { get; set; }
		public DateTime DateFin { get; set; }
		public string Commentaire { get; set; }
	}
}
