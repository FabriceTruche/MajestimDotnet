using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class ExerciceCommand : IDapperCommands
	{
		public string SelectCommand => "select Exercice.* from Exercice $where$;";
		public string InsertCommand => "insert into Exercice(id,nom,datedebut,datefin,commentaire) values (@id,@nom,@datedebut,@datefin,@commentaire);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from Exercice where id=@id;";
		public string UpdateCommand => "update Exercice set nom=@nom,datedebut=@datedebut,datefin=@datefin,commentaire=@commentaire where id=@id;";
		
	}
}
