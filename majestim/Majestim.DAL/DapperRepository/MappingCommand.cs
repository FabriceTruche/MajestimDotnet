using System.Data;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL.DapperRepository
{
	public partial class MappingCommand : IDapperCommands
	{
		public string SelectCommand => "select Mapping.* from Mapping $where$;";
		public string InsertCommand => "insert into Mapping(id,col1,col2,col3,txt1,txt2) values (@id,@col1,@col2,@col3,@txt1,@txt2);select LAST_INSERT_ID() as ID;";
		public string DeleteCommand => "delete from Mapping where id=@id;";
		public string UpdateCommand => "update Mapping set col1=@col1,col2=@col2,col3=@col3,txt1=@txt1,txt2=@txt2 where id=@id;";
		
	}
}
