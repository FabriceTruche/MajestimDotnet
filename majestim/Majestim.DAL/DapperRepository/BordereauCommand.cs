using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class BordereauCommand : IDapperCommands
	{
		public string SelectCommand => "select Bordereau.* from Bordereau $where$;";
		public string InsertCommand => "insert into Bordereau(id,numero,datecreation,libelle) values (@id,@numero,@datecreation,@libelle);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from Bordereau where id=@id;";
		public string UpdateCommand => "update Bordereau set numero=@numero,datecreation=@datecreation,libelle=@libelle where id=@id;";
		
	}
}
