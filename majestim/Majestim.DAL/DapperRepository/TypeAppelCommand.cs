using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class TypeAppelCommand : IDapperCommands
	{
		public string SelectCommand => "select TypeAppel.* from TypeAppel $where$;";
		public string InsertCommand => "insert into TypeAppel(id,code,libelle) values (@id,@code,@libelle);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from TypeAppel where id=@id;";
		public string UpdateCommand => "update TypeAppel set code=@code,libelle=@libelle where id=@id;";
		
	}
}
