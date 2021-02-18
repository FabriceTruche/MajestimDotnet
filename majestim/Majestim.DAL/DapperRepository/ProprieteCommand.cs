using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class ProprieteCommand : IDapperCommands
	{
		public string SelectCommand => "select Propriete.* from Propriete $where$;";
		public string InsertCommand => "insert into Propriete(id,nom,valeur,commentaire,bien_id) values (@id,@nom,@valeur,@commentaire,@bien_id);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from Propriete where id=@id;";
		public string UpdateCommand => "update Propriete set nom=@nom,valeur=@valeur,commentaire=@commentaire,bien_id=@bien_id where id=@id;";
		
	}
}
