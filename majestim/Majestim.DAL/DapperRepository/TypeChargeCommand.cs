using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class TypeChargeCommand : IDapperCommands
	{
		public string SelectCommand => "select TypeCharge.* from TypeCharge $where$;";
		public string InsertCommand => "insert into TypeCharge(id,code,libelle) values (@id,@code,@libelle);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from TypeCharge where id=@id;";
		public string UpdateCommand => "update TypeCharge set code=@code,libelle=@libelle where id=@id;";
		
	}
}
