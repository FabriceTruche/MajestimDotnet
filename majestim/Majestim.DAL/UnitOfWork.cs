using System;
using System.Data;
using System.Reflection;
using log4net;
using Majestim.DAL.Interface.DAL;
using Majestim.DTO.Interface;
using Majestim.Interface;
using MySql.Data.MySqlClient;
using Unity;
using Unity.Resolution;

namespace Majestim.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IContext _context;
        private bool _disposed;
        private MySqlConnection _dbConnection;
        private MySqlTransaction _transaction;

        /// <summary>
        /// 
        /// </summary>
        public UnitOfWork(IContext context)
        {
            this._context = context;
            this._dbConnection = new MySqlConnection(context.ConnectionString);
            this._dbConnection.Open();
            this._transaction = this._dbConnection.BeginTransaction();
        }

        IDbConnection IUnitOfWork.DbConnection => this._dbConnection;
        IDbTransaction IUnitOfWork.Transaction => this._transaction;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IRepository<T> IUnitOfWork.Repository<T>()
        {
            ParameterOverride p = new ParameterOverride(typeof(IDbTransaction), this._transaction);

            return this._context.Container.Resolve<IRepository<T>>(p);
        }

        /// <summary>
        /// 
        /// </summary>
        void IUnitOfWork.Commit()
        {
            try
            {
                this._transaction.Commit();
            }
            catch (Exception ex)
            {
                this._transaction.Rollback();
                log.Error($"Transaction error : {ex.Message}");
            }
            finally
            {
                this._transaction.Dispose();
                this._transaction = this._dbConnection.BeginTransaction();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        void IUnitOfWork.Rollback()
        {
            try
            {
                this._transaction.Rollback();
            }
            catch (Exception ex)
            {
                log.Error($"Transaction error : {ex.Message}");
            }
            finally
            {
                this._transaction.Dispose();
                this._transaction = this._dbConnection.BeginTransaction();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TMaster"></typeparam>
        /// <typeparam name="TSlave"></typeparam>
        /// <param name="query"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        OneMany<TMaster, TSlave> IUnitOfWork.QueryOneMany<TMaster, TSlave>(string query, object param)
            //where TMaster : IIdentity where TSlave : IIdentity
        {
            OneManyBuilder<TMaster, TSlave> builder = new OneManyBuilder<TMaster, TSlave>(this._context);

            return builder.QueryOneMany(query, this, param);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            this.DisposeIniternal(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        private void DisposeIniternal(bool disposing)
        {
            if (this._disposed)
                return;

            if (disposing)
            {
                if (this._transaction != null)
                {
                    this._transaction.Dispose();
                    this._transaction = null;
                }
                if (this._dbConnection != null)
                {
                    this._dbConnection.Dispose();
                    this._dbConnection = null;
                }
            }
            this._disposed = true;
        }

        /// <summary>
        /// 
        /// </summary>
        ~UnitOfWork()
        {
            this.DisposeIniternal(false);
        }
    }
}

