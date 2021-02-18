using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class ImmeubleCommand : IDapperCommands
	{
		public string SelectCommand => "select Immeuble.*,Bien.* from Immeuble,Bien where Immeuble.ID=Bien.ID $where$;";
		public string InsertCommand => "insert into Immeuble(id,nblots,nbetages,surface,surfacejardin,nbparking) values (@id,@nblots,@nbetages,@surface,@surfacejardin,@nbparking);insert into Bien(id,description,numero,adresse_id,id) values (@id,@description,@numero,@adresse_id,LAST_INSERT_ID());select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from Bien where id=@id;delete from Immeuble where id=@id;";
		public string UpdateCommand => "update Bien set description=@description,numero=@numero,adresse_id=@adresse_id where id=@id;update Immeuble set nblots=@nblots,nbetages=@nbetages,surface=@surface,surfacejardin=@surfacejardin,nbparking=@nbparking where id=@id;";
		
	}
}
