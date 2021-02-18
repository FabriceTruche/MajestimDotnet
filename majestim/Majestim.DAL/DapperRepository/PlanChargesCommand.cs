using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class PlanChargesCommand : IDapperCommands
	{
		public string SelectCommand => "select PlanCharges.* from PlanCharges $where$;";
		public string InsertCommand => "insert into PlanCharges(id,montant,commentaire,exercice_id,charge_id) values (@id,@montant,@commentaire,@exercice_id,@charge_id);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from PlanCharges where id=@id;";
		public string UpdateCommand => "update PlanCharges set montant=@montant,commentaire=@commentaire,exercice_id=@exercice_id,charge_id=@charge_id where id=@id;";
		
	}
}
