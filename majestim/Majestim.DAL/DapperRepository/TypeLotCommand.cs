using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class TypeLotCommand : IDapperCommands
	{
		public string SelectCommand => "select TypeLot.* from TypeLot $where$;";
		public string InsertCommand => "insert into TypeLot(id,code,libelle) values (@id,@code,@libelle);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from TypeLot where id=@id;";
		public string UpdateCommand => "update TypeLot set code=@code,libelle=@libelle where id=@id;";
		
	}
}
