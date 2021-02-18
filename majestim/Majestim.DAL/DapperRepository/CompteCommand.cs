using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class CompteCommand : IDapperCommands
	{
		public string SelectCommand => "select Compte.* from Compte $where$;";
		public string InsertCommand => "insert into Compte(id,numero,libelle) values (@id,@numero,@libelle);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from Compte where id=@id;";
		public string UpdateCommand => "update Compte set numero=@numero,libelle=@libelle where id=@id;";
		
	}
}
