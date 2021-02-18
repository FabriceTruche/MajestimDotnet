using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class ChequeCommand : IDapperCommands
	{
		public string SelectCommand => "select Cheque.* from Cheque $where$;";
		public string InsertCommand => "insert into Cheque(id,nom,datecreation,periode,montant,libelle,bordereau_id,opedepot_id,opeencaissement_id,contrat_id) values (@id,@nom,@datecreation,@periode,@montant,@libelle,@bordereau_id,@opedepot_id,@opeencaissement_id,@contrat_id);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from Cheque where id=@id;";
		public string UpdateCommand => "update Cheque set nom=@nom,datecreation=@datecreation,periode=@periode,montant=@montant,libelle=@libelle,bordereau_id=@bordereau_id,opedepot_id=@opedepot_id,opeencaissement_id=@opeencaissement_id,contrat_id=@contrat_id where id=@id;";
		
	}
}
