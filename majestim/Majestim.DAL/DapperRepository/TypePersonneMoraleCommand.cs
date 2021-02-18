using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class TypePersonneMoraleCommand : IDapperCommands
	{
		public string SelectCommand => "select TypePersonneMorale.* from TypePersonneMorale $where$;";
		public string InsertCommand => "insert into TypePersonneMorale(id,code,libelle) values (@id,@code,@libelle);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from TypePersonneMorale where id=@id;";
		public string UpdateCommand => "update TypePersonneMorale set code=@code,libelle=@libelle where id=@id;";
		
	}
}
