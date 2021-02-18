using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class CategorieChequeEmisCommand : IDapperCommands
	{
		public string SelectCommand => "select CategorieChequeEmis.* from CategorieChequeEmis $where$;";
		public string InsertCommand => "insert into CategorieChequeEmis(id,nom,libelle,comptecredit_id,comptedebit_id) values (@id,@nom,@libelle,@comptecredit_id,@comptedebit_id);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from CategorieChequeEmis where id=@id;";
		public string UpdateCommand => "update CategorieChequeEmis set nom=@nom,libelle=@libelle,comptecredit_id=@comptecredit_id,comptedebit_id=@comptedebit_id where id=@id;";
		
	}
}
