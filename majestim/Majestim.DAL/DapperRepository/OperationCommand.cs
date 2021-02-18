using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class OperationCommand : IDapperCommands
	{
		public string SelectCommand => "select Operation.* from Operation $where$;";
		public string InsertCommand => "insert into Operation(id,dateoperation,commentaire,periode,contrat_id,typeoperation_id,exercice_id) values (@id,@dateoperation,@commentaire,@periode,@contrat_id,@typeoperation_id,@exercice_id);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from Operation where id=@id;";
		public string UpdateCommand => "update Operation set dateoperation=@dateoperation,commentaire=@commentaire,periode=@periode,contrat_id=@contrat_id,typeoperation_id=@typeoperation_id,exercice_id=@exercice_id where id=@id;";
		
	}
}
