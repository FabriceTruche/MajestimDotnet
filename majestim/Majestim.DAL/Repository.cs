using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Majestim.DAL.DapperRepository;
using Majestim.DAL.Interface.DAL;
using Majestim.DTO;
using Majestim.DTO.Interface;
using Majestim.Interface;

namespace Majestim.DAL
{
    public class Repository<TCommand, T> : IRepository<T>
        where T : IIdentity
        where TCommand : IDapperCommands, new()
    {
        //protected readonly IContext _context;
        private readonly IDapperCommands _commands = new TCommand();
        private readonly IDbTransaction _transaction;

        protected string SelectCommand => this._commands.SelectCommand;
        protected string InsertCommand => this._commands.InsertCommand;
        protected string DeleteCommand => this._commands.DeleteCommand;
        protected string UpdateCommand => this._commands.UpdateCommand;

        protected IDbConnection Connection => this._transaction.Connection;

        /// <summary>
        /// 
        /// </summary>
        public Repository(IDbTransaction transaction)
        {
            this._transaction = transaction;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public dynamic Query(string query)
        {
            return this.Connection.Query(query, this._transaction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IEnumerable<TOut> Query<TOut>(string query)
        {
            IEnumerable<TOut> res = this.Connection.Query<TOut>(query/*, this._transaction*/);

            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll(string whereClause = "")
        {
            string cmd = this.SelectCommand;

            if (!string.IsNullOrEmpty(whereClause))
                whereClause = $" where {whereClause}";

            cmd = cmd.Replace("$where$", whereClause);

            return this.Connection.Query<T>(cmd, this._transaction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T Single(string whereClause)
        {
            string cmd = this.SelectCommand;

            if (!string.IsNullOrEmpty(whereClause))
                whereClause = $" where {whereClause}";

            cmd = cmd.Replace("$where$", whereClause);

            T res = this.Connection.Query<T>(cmd, this._transaction).FirstOrDefault();

            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(int id)
        {
            string cmd = this.SelectCommand;

            cmd = cmd.Replace("$where$", $"where id={id}");

            T res = this.Connection.QuerySingle<T>(cmd, this._transaction);

            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int Update(T obj)
        {
            return this.Connection.Execute(this.SelectCommand, obj, this._transaction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int Insert(T obj)
        {
            dynamic res = this.Connection.Query(this.InsertCommand, obj, this._transaction).Single();
            int id = Convert.ToInt32(res.ID);
            IIdentity identity = obj;
            identity.ID = id;

            return id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int Delete(T obj)
        {
            return this.Connection.Execute(this.DeleteCommand, obj, this._transaction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            return this.Connection.Execute(this.DeleteCommand, new {id},this._transaction);
        }
    }
}

