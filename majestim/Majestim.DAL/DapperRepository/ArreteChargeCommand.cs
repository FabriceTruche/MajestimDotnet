using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class ArreteChargeCommand : IDapperCommands
	{
		public string SelectCommand => "select ArreteCharge.* from ArreteCharge $where$;";
		public string InsertCommand => "insert into ArreteCharge(id,datearrete,valeurindex,commentaire,charge_id,bien_id,contrat_id,operation_id) values (@id,@datearrete,@valeurindex,@commentaire,@charge_id,@bien_id,@contrat_id,@operation_id);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from ArreteCharge where id=@id;";
		public string UpdateCommand => "update ArreteCharge set datearrete=@datearrete,valeurindex=@valeurindex,commentaire=@commentaire,charge_id=@charge_id,bien_id=@bien_id,contrat_id=@contrat_id,operation_id=@operation_id where id=@id;";
		
	}
}
