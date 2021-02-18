using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class LotCommand : IDapperCommands
	{
		public string SelectCommand => "select Lot.*,Bien.* from Lot,Bien where Lot.ID=Bien.ID $where$;";
		public string InsertCommand => "insert into Lot(id,etage,orientation,surface,entree,immeuble_id,typelot_id) values (@id,@etage,@orientation,@surface,@entree,@immeuble_id,@typelot_id);insert into Bien(id,description,numero,adresse_id,id) values (@id,@description,@numero,@adresse_id,LAST_INSERT_ID());select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from Bien where id=@id;delete from Lot where id=@id;";
		public string UpdateCommand => "update Bien set description=@description,numero=@numero,adresse_id=@adresse_id where id=@id;update Lot set etage=@etage,orientation=@orientation,surface=@surface,entree=@entree,immeuble_id=@immeuble_id,typelot_id=@typelot_id where id=@id;";
		
	}
}
