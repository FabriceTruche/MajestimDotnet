using System;
using System.Data;
using Majestim.DTO.Interface;

namespace Majestim.DAL.Interface.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        // connexion
        IDbConnection DbConnection { get; }
        IDbTransaction Transaction { get; }

        // repositories
        IRepository<T> Repository<T>();

        // commit/rollback
        void Commit();
        void Rollback();

        // specials queries
        OneMany<TMaster, TSlave> QueryOneMany<TMaster, TSlave>(string query, object param = null)
            where TMaster : IIdentity 
            where TSlave : IIdentity
            ;
    }
}
