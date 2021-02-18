//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Reflection;
//using Dapper;
//using log4net;
//using Majestim.BO.OperationBase.Compta;
//using Majestim.DTO.DTO;
//using Majestim.DTO.Interface;
//using MySql.Data.MySqlClient;

//namespace Majestim._Console
//{
//    public class MasterSlave<TMaster, TSlave> : 
//        Dictionary<TMaster, List<TSlave>>
//        where TMaster : IIdentity 
//        where TSlave : IIdentity
//    {
//        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

//        private readonly IDbConnection _cnx;

//        public  class MasterEqualityComparer : IEqualityComparer<TMaster>
//        {
//            public bool Equals(TMaster x, TMaster y)
//            {
//                return x.ID == y.ID;
//            }

//            public int GetHashCode(TMaster obj)
//            {
//                return obj.ID;
//            }
//        }

//        public MasterSlave(IDbConnection cnx)  : base (new MasterEqualityComparer())
//        {
//            this._cnx = cnx;
//        }

//        public void Query(string query)
//        {
//            this.Clear();
//            this._cnx.Query<TMaster, TSlave, object>(
//                query,
//                this.MergeResult);
//        }

//        private object MergeResult(TMaster master, TSlave slave)
//        {
//            //KeyValuePair<TMaster, TSlave> m = this.ContainsKey(master); //    .FirstOrDefault(x => x.Key.ID == master.ID);


//            if (this.ContainsKey(master))
//            {
//                this[master].Add(slave);
//            }
//            else
//            {
//                this.Add(master, new List<TSlave> { slave });
//            }

//            return null;
//        }
//    }
//}