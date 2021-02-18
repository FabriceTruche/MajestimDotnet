using System;
using System.Collections.Generic;
using Majestim.DTO.Interface;

namespace Majestim.DTO.DTO
{
	public partial class MappingDto : IIdentity
	{
		public int ID { get; set; }
		public int Col1 { get; set; }
		public int Col2 { get; set; }
		public int Col3 { get; set; }
		public string Txt1 { get; set; }
		public string Txt2 { get; set; }
	}
}
