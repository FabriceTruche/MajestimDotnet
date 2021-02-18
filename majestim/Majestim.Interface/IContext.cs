using System.Data;
using Unity;

namespace Majestim.Interface
{
    public interface IContext
    {
        string ConnectionString { get; }
        IUnityContainer Container { get; }
        //IDbConnection Connection { get; }
    }
}

