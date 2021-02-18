using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class BaseRepartLotCommand : IDapperCommands
	{
		public string SelectCommand => "select BaseRepartLot.* from BaseRepartLot $where$;";
		public string InsertCommand => "insert into BaseRepartLot(id,valeur,baserepart_id,lot_id) values (@id,@valeur,@baserepart_id,@lot_id);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from BaseRepartLot where id=@id;";
		public string UpdateCommand => "update BaseRepartLot set valeur=@valeur,baserepart_id=@baserepart_id,lot_id=@lot_id where id=@id;";
		
	}
}
