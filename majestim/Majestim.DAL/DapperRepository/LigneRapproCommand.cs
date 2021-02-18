using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class LigneRapproCommand : IDapperCommands
	{
		public string SelectCommand => "select LigneRappro.* from LigneRappro $where$;";
		public string InsertCommand => "insert into LigneRappro(id,repattern,montant,libelle,active,comptedebit_id,comptecredit_id) values (@id,@repattern,@montant,@libelle,@active,@comptedebit_id,@comptecredit_id);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from LigneRappro where id=@id;";
		public string UpdateCommand => "update LigneRappro set repattern=@repattern,montant=@montant,libelle=@libelle,active=@active,comptedebit_id=@comptedebit_id,comptecredit_id=@comptecredit_id where id=@id;";
		
	}
}
