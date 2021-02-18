using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class LigneAppelContratCommand : IDapperCommands
	{
		public string SelectCommand => "select LigneAppelContrat.* from LigneAppelContrat $where$;";
		public string InsertCommand => "insert into LigneAppelContrat(id,periodedebut,periodefin,libelle,active,debit,credit,ligneappeldefinition_id,contrat_id) values (@id,@periodedebut,@periodefin,@libelle,@active,@debit,@credit,@ligneappeldefinition_id,@contrat_id);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from LigneAppelContrat where id=@id;";
		public string UpdateCommand => "update LigneAppelContrat set periodedebut=@periodedebut,periodefin=@periodefin,libelle=@libelle,active=@active,debit=@debit,credit=@credit,ligneappeldefinition_id=@ligneappeldefinition_id,contrat_id=@contrat_id where id=@id;";
		
	}
}
