using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class LigneAppelGlobalCommand : IDapperCommands
	{
		public string SelectCommand => "select LigneAppelGlobal.* from LigneAppelGlobal $where$;";
		public string InsertCommand => "insert into LigneAppelGlobal(id,typeappel_id,ligneappeldefinition_id) values (@id,@typeappel_id,@ligneappeldefinition_id);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from LigneAppelGlobal where id=@id;";
		public string UpdateCommand => "update LigneAppelGlobal set typeappel_id=@typeappel_id,ligneappeldefinition_id=@ligneappeldefinition_id where id=@id;";
		
	}
}
