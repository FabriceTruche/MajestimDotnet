using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class TypeLienPersonneMoraleCommand : IDapperCommands
	{
		public string SelectCommand => "select TypeLienPersonneMorale.* from TypeLienPersonneMorale $where$;";
		public string InsertCommand => "insert into TypeLienPersonneMorale(id,code,libelle) values (@id,@code,@libelle);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from TypeLienPersonneMorale where id=@id;";
		public string UpdateCommand => "update TypeLienPersonneMorale set code=@code,libelle=@libelle where id=@id;";
		
	}
}
