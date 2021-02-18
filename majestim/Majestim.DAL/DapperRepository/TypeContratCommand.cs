using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class TypeContratCommand : IDapperCommands
	{
		public string SelectCommand => "select TypeContrat.* from TypeContrat $where$;";
		public string InsertCommand => "insert into TypeContrat(id,code,libelle) values (@id,@code,@libelle);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from TypeContrat where id=@id;";
		public string UpdateCommand => "update TypeContrat set code=@code,libelle=@libelle where id=@id;";
		
	}
}
