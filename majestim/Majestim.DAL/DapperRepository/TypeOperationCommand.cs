using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class TypeOperationCommand : IDapperCommands
	{
		public string SelectCommand => "select TypeOperation.* from TypeOperation $where$;";
		public string InsertCommand => "insert into TypeOperation(id,code,libelle) values (@id,@code,@libelle);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from TypeOperation where id=@id;";
		public string UpdateCommand => "update TypeOperation set code=@code,libelle=@libelle where id=@id;";
		
	}
}
