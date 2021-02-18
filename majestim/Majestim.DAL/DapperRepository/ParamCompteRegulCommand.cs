using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class ParamCompteRegulCommand : IDapperCommands
	{
		public string SelectCommand => "select ParamCompteRegul.* from ParamCompteRegul $where$;";
		public string InsertCommand => "insert into ParamCompteRegul(id,libelle,regul,solde,compte_id) values (@id,@libelle,@regul,@solde,@compte_id);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from ParamCompteRegul where id=@id;";
		public string UpdateCommand => "update ParamCompteRegul set libelle=@libelle,regul=@regul,solde=@solde,compte_id=@compte_id where id=@id;";
		
	}
}
