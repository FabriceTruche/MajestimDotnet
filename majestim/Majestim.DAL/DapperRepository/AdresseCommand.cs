using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class AdresseCommand : IDapperCommands
	{
		public string SelectCommand => "select Adresse.* from Adresse $where$;";
		public string InsertCommand => "insert into Adresse(id,adr1,adr2,complement,cp,ville,pays) values (@id,@adr1,@adr2,@complement,@cp,@ville,@pays);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from Adresse where id=@id;";
		public string UpdateCommand => "update Adresse set adr1=@adr1,adr2=@adr2,complement=@complement,cp=@cp,ville=@ville,pays=@pays where id=@id;";
		
	}
}
