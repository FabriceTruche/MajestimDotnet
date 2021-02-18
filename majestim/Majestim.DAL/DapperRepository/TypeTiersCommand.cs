using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class TypeTiersCommand : IDapperCommands
	{
		public string SelectCommand => "select TypeTiers.* from TypeTiers $where$;";
		public string InsertCommand => "insert into TypeTiers(id,code,libelle) values (@id,@code,@libelle);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from TypeTiers where id=@id;";
		public string UpdateCommand => "update TypeTiers set code=@code,libelle=@libelle where id=@id;";
		
	}
}
