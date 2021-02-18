using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class TypePreneurCommand : IDapperCommands
	{
		public string SelectCommand => "select TypePreneur.* from TypePreneur $where$;";
		public string InsertCommand => "insert into TypePreneur(id,code,libelle) values (@id,@code,@libelle);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from TypePreneur where id=@id;";
		public string UpdateCommand => "update TypePreneur set code=@code,libelle=@libelle where id=@id;";
		
	}
}
