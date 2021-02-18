using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class EcritureCommand : IDapperCommands
	{
		public string SelectCommand => "select Ecriture.* from Ecriture $where$;";
		public string InsertCommand => "insert into Ecriture(id,libelle,debit,credit,compte_id,operation_id) values (@id,@libelle,@debit,@credit,@compte_id,@operation_id);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from Ecriture where id=@id;";
		public string UpdateCommand => "update Ecriture set libelle=@libelle,debit=@debit,credit=@credit,compte_id=@compte_id,operation_id=@operation_id where id=@id;";
		
	}
}
