using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class TiersCommand : IDapperCommands
	{
		public string SelectCommand => "select Tiers.* from Tiers $where$;";
		public string InsertCommand => "insert into Tiers(id,commentaire,mail,tel,typetiers_id) values (@id,@commentaire,@mail,@tel,@typetiers_id);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from Tiers where id=@id;";
		public string UpdateCommand => "update Tiers set commentaire=@commentaire,mail=@mail,tel=@tel,typetiers_id=@typetiers_id where id=@id;";
		
	}
}
