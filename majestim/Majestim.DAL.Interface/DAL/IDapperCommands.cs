namespace Majestim.DAL.Interface.DAL
{
    public interface IDapperCommands
    {
        /// <summary>
        /// 
        /// </summary>
        string SelectCommand { get; }

        /// <summary>
        /// 
        /// </summary>
        string InsertCommand { get;  }

        /// <summary>
        /// 
        /// </summary>
        string UpdateCommand { get;  }

        /// <summary>
        /// 
        /// </summary>
        string DeleteCommand { get;  }
    }
}