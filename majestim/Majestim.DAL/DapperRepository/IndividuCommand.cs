using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class IndividuCommand : IDapperCommands
	{
		public string SelectCommand => "select Individu.*,Tiers.* from Individu,Tiers where Individu.ID=Tiers.ID $where$;";
		public string InsertCommand => "insert into Individu(id,nom,prenom,typecivilite_id) values (@id,@nom,@prenom,@typecivilite_id);insert into Tiers(id,commentaire,mail,tel,typetiers_id,id) values (@id,@commentaire,@mail,@tel,@typetiers_id,LAST_INSERT_ID());select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from Tiers where id=@id;delete from Individu where id=@id;";
		public string UpdateCommand => "update Tiers set commentaire=@commentaire,mail=@mail,tel=@tel,typetiers_id=@typetiers_id where id=@id;update Individu set nom=@nom,prenom=@prenom,typecivilite_id=@typecivilite_id where id=@id;";
		
	}
}
