using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class TypeCiviliteCommand : IDapperCommands
	{
		public string SelectCommand => "select TypeCivilite.* from TypeCivilite $where$;";
		public string InsertCommand => "insert into TypeCivilite(id,code,libelle) values (@id,@code,@libelle);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from TypeCivilite where id=@id;";
		public string UpdateCommand => "update TypeCivilite set code=@code,libelle=@libelle where id=@id;";
		
	}
}
