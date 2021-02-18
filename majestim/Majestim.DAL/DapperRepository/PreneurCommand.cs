using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class PreneurCommand : IDapperCommands
	{
		public string SelectCommand => "select Preneur.* from Preneur $where$;";
		public string InsertCommand => "insert into Preneur(id,commentaire,contrat_id,tiers_id,typepreneur_id) values (@id,@commentaire,@contrat_id,@tiers_id,@typepreneur_id);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from Preneur where id=@id;";
		public string UpdateCommand => "update Preneur set commentaire=@commentaire,contrat_id=@contrat_id,tiers_id=@tiers_id,typepreneur_id=@typepreneur_id where id=@id;";
		
	}
}
