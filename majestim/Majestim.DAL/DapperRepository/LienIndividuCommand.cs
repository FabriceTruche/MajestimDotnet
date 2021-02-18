using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class LienIndividuCommand : IDapperCommands
	{
		public string SelectCommand => "select LienIndividu.* from LienIndividu $where$;";
		public string InsertCommand => "insert into LienIndividu(id,commentaire,individu_id,individulie_id,typelienindividu_id) values (@id,@commentaire,@individu_id,@individulie_id,@typelienindividu_id);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from LienIndividu where id=@id;";
		public string UpdateCommand => "update LienIndividu set commentaire=@commentaire,individu_id=@individu_id,individulie_id=@individulie_id,typelienindividu_id=@typelienindividu_id where id=@id;";
		
	}
}
