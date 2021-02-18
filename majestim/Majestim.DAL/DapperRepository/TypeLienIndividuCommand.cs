using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class TypeLienIndividuCommand : IDapperCommands
	{
		public string SelectCommand => "select TypeLienIndividu.* from TypeLienIndividu $where$;";
		public string InsertCommand => "insert into TypeLienIndividu(id,code,libelle) values (@id,@code,@libelle);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from TypeLienIndividu where id=@id;";
		public string UpdateCommand => "update TypeLienIndividu set code=@code,libelle=@libelle where id=@id;";
		
	}
}
