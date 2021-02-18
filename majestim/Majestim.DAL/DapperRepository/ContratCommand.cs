using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class ContratCommand : IDapperCommands
	{
		public string SelectCommand => "select Contrat.* from Contrat $where$;";
		public string InsertCommand => "insert into Contrat(id,nom,commentaire,dateentreeprevue,datesortieprevue,dateentree,datesortie,chargescommunes,typecontrat_id) values (@id,@nom,@commentaire,@dateentreeprevue,@datesortieprevue,@dateentree,@datesortie,@chargescommunes,@typecontrat_id);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from Contrat where id=@id;";
		public string UpdateCommand => "update Contrat set nom=@nom,commentaire=@commentaire,dateentreeprevue=@dateentreeprevue,datesortieprevue=@datesortieprevue,dateentree=@dateentree,datesortie=@datesortie,chargescommunes=@chargescommunes,typecontrat_id=@typecontrat_id where id=@id;";
		
	}
}
