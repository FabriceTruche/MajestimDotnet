using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Majestim.DAL.Interface.DAL
{
    public interface IRepository<T> 
    {
        dynamic Query(string query);
        IEnumerable<TOut> Query<TOut>(string query);
        IEnumerable<T> GetAll(string where = "");
        T Single(string whereClause);
        T GetById(int id);
        int Update(T obj);
        int Insert(T obj);
        int Delete(T obj);
        int Delete(int id);
    }
}


