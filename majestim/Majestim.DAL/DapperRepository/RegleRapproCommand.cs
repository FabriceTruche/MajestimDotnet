using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class RegleRapproCommand : IDapperCommands
	{
		public string SelectCommand => "select RegleRappro.* from RegleRappro $where$;";
		public string InsertCommand => "insert into RegleRappro(id,nom,libelle,actif) values (@id,@nom,@libelle,@actif);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from RegleRappro where id=@id;";
		public string UpdateCommand => "update RegleRappro set nom=@nom,libelle=@libelle,actif=@actif where id=@id;";
		
	}
}
