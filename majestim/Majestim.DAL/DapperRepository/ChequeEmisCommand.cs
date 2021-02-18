using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class ChequeEmisCommand : IDapperCommands
	{
		public string SelectCommand => "select ChequeEmis.* from ChequeEmis $where$;";
		public string InsertCommand => "insert into ChequeEmis(id,numero,date,libelle,montant,contrat_id,operetrait_id,categoriechequeemis_id) values (@id,@numero,@date,@libelle,@montant,@contrat_id,@operetrait_id,@categoriechequeemis_id);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from ChequeEmis where id=@id;";
		public string UpdateCommand => "update ChequeEmis set numero=@numero,date=@date,libelle=@libelle,montant=@montant,contrat_id=@contrat_id,operetrait_id=@operetrait_id,categoriechequeemis_id=@categoriechequeemis_id where id=@id;";
		
	}
}
