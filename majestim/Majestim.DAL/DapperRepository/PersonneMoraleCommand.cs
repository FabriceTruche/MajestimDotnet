using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class PersonneMoraleCommand : IDapperCommands
	{
		public string SelectCommand => "select PersonneMorale.*,Tiers.* from PersonneMorale,Tiers where PersonneMorale.ID=Tiers.ID $where$;";
		public string InsertCommand => "insert into PersonneMorale(id,raisonsociale,typepersonnemorale_id,adresse_id) values (@id,@raisonsociale,@typepersonnemorale_id,@adresse_id);insert into Tiers(id,commentaire,mail,tel,typetiers_id,id) values (@id,@commentaire,@mail,@tel,@typetiers_id,LAST_INSERT_ID());select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from Tiers where id=@id;delete from PersonneMorale where id=@id;";
		public string UpdateCommand => "update Tiers set commentaire=@commentaire,mail=@mail,tel=@tel,typetiers_id=@typetiers_id where id=@id;update PersonneMorale set raisonsociale=@raisonsociale,typepersonnemorale_id=@typepersonnemorale_id,adresse_id=@adresse_id where id=@id;";
		
	}
}
