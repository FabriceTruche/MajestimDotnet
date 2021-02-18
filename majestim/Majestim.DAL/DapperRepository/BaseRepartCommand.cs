using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class BaseRepartCommand : IDapperCommands
	{
		public string SelectCommand => "select BaseRepart.* from BaseRepart $where$;";
		public string InsertCommand => "insert into BaseRepart(id,nom,libelle,total) values (@id,@nom,@libelle,@total);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from BaseRepart where id=@id;";
		public string UpdateCommand => "update BaseRepart set nom=@nom,libelle=@libelle,total=@total where id=@id;";
		
	}
}
