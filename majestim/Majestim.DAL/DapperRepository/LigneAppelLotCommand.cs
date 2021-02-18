using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class LigneAppelLotCommand : IDapperCommands
	{
		public string SelectCommand => "select LigneAppelLot.* from LigneAppelLot $where$;";
		public string InsertCommand => "insert into LigneAppelLot(id,debit,credit,lot_id,ligneappeldefinition_id) values (@id,@debit,@credit,@lot_id,@ligneappeldefinition_id);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from LigneAppelLot where id=@id;";
		public string UpdateCommand => "update LigneAppelLot set debit=@debit,credit=@credit,lot_id=@lot_id,ligneappeldefinition_id=@ligneappeldefinition_id where id=@id;";
		
	}
}
