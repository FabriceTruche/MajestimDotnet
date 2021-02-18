using Majestim.DAL.Interface.DAL;

namespace Majestim.DAL
{
    /// <summary>
    /// Dapper command vide
    /// </summary>
    public class DefaultDapperCommand : IDapperCommands
    {
        public string SelectCommand { get; }
        public string InsertCommand { get; }
        public string UpdateCommand { get; }
        public string DeleteCommand { get; }
    }
}