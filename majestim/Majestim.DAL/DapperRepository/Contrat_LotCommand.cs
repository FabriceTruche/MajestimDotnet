using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class Contrat_LotCommand : IDapperCommands
	{
		public string SelectCommand => "select Contrat_Lot.* from Contrat_Lot $where$;";
		public string InsertCommand => "insert into Contrat_Lot(id,contrat_id,lot_id) values (@id,@contrat_id,@lot_id);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from Contrat_Lot where id=@id;";
		public string UpdateCommand => "update Contrat_Lot set contrat_id=@contrat_id,lot_id=@lot_id where id=@id;";
		
	}
}
