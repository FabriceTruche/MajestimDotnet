using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class BienCommand : IDapperCommands
	{
		public string SelectCommand => "select Bien.* from Bien $where$;";
		public string InsertCommand => "insert into Bien(id,description,numero,adresse_id) values (@id,@description,@numero,@adresse_id);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from Bien where id=@id;";
		public string UpdateCommand => "update Bien set description=@description,numero=@numero,adresse_id=@adresse_id where id=@id;";
		
	}
}
