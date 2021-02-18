using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class LienPersonneMoraleCommand : IDapperCommands
	{
		public string SelectCommand => "select LienPersonneMorale.* from LienPersonneMorale $where$;";
		public string InsertCommand => "insert into LienPersonneMorale(id,commentaire,individu_id,typelienpersonnemorale_id,personnemorale_id) values (@id,@commentaire,@individu_id,@typelienpersonnemorale_id,@personnemorale_id);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from LienPersonneMorale where id=@id;";
		public string UpdateCommand => "update LienPersonneMorale set commentaire=@commentaire,individu_id=@individu_id,typelienpersonnemorale_id=@typelienpersonnemorale_id,personnemorale_id=@personnemorale_id where id=@id;";
		
	}
}
