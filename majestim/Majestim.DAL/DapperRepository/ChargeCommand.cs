using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class ChargeCommand : IDapperCommands
	{
		public string SelectCommand => "select Charge.* from Charge $where$;";
		public string InsertCommand => "insert into Charge(id,nom,libelle,chargecommune,compte_id,baserepart_id,typecharge_id) values (@id,@nom,@libelle,@chargecommune,@compte_id,@baserepart_id,@typecharge_id);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from Charge where id=@id;";
		public string UpdateCommand => "update Charge set nom=@nom,libelle=@libelle,chargecommune=@chargecommune,compte_id=@compte_id,baserepart_id=@baserepart_id,typecharge_id=@typecharge_id where id=@id;";
		
	}
}
