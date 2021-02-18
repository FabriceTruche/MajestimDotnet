using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class LigneAppelDefinitionCommand : IDapperCommands
	{
		public string SelectCommand => "select LigneAppelDefinition.* from LigneAppelDefinition $where$;";
		public string InsertCommand => "insert into LigneAppelDefinition(id,code,libelle,compte_id) values (@id,@code,@libelle,@compte_id);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from LigneAppelDefinition where id=@id;";
		public string UpdateCommand => "update LigneAppelDefinition set code=@code,libelle=@libelle,compte_id=@compte_id where id=@id;";
		
	}
}
