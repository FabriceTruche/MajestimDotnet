using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Dapper;
using log4net;
using Majestim.DAL.Interface.DAL;
using Majestim.DTO.Interface;
using Majestim.Interface;

namespace Majestim.DAL
{
    internal class OneManyBuilder<TMaster, TSlave>  
        where TMaster : IIdentity 
        where TSlave : IIdentity
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IContext _context;

        //public IDictionary<TMaster, IList<TSlave>> Dictionary { get; }
        private OneMany<TMaster, TSlave> Dictionary { get; }

        private class MasterEqualityComparer : IEqualityComparer<TMaster>
        {
            public bool Equals(TMaster x, TMaster y)
            {
                return x.ID == y.ID;
            }

            public int GetHashCode(TMaster obj)
            {
                return obj.ID;
            }
        }

        /// <summary>
        /// injecter le cnx par le ctor
        /// </summary>
        /// <param name="context"></param>
        public OneManyBuilder(IContext context)
        {
            this.Dictionary = new OneMany<TMaster, TSlave>(new MasterEqualityComparer());
            this._context = context;
        }

        /// <summary>
        /// query
        /// </summary>
        /// <param name="query"></param>
        /// <param name="uow"></param>
        /// <param name="param"></param>
        public OneMany<TMaster, TSlave> QueryOneMany(string query, IUnitOfWork uow, object param = null)
        {
            this.Dictionary.Clear();
            uow.DbConnection.Query<TMaster, TSlave, object>(
                query,
                this.MergeResult,
                param,
                uow.Transaction);

            return this.Dictionary;
        }

        /// <summary>
        /// aiguiller
        /// </summary>
        /// <param name="master"></param>
        /// <param name="slave"></param>
        /// <returns></returns>
        private object MergeResult(TMaster master, TSlave slave)
        {
            if (this.Dictionary.ContainsKey(master))
                this.Dictionary[master].Add(slave);
            else
                this.Dictionary.Add(master, new List<TSlave> { slave });

            return null;
        }
    }
}