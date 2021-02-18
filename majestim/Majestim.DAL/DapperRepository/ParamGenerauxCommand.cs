using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class ParamGenerauxCommand : IDapperCommands
	{
		public string SelectCommand => "select ParamGeneraux.* from ParamGeneraux $where$;";
		public string InsertCommand => "insert into ParamGeneraux(id,cle,valeur,commentaire) values (@id,@cle,@valeur,@commentaire);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from ParamGeneraux where id=@id;";
		public string UpdateCommand => "update ParamGeneraux set cle=@cle,valeur=@valeur,commentaire=@commentaire where id=@id;";
		
	}
}
