//using System;
//using System.Data;
//using System.Reflection;
//using log4net;
//using MySql.Data.Types;

//namespace Majestim.DAL
//{
//    public class DateTimeTypeHandler : Dapper.SqlMapper.TypeHandler<DateTime?>
//    {
//        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

//        public override void SetValue(IDbDataParameter parameter, DateTime? value)
//        {
//            if (value.HasValue)
//                parameter.Value = value.Value;
//            else
//                parameter.Value = null;
//        }

//        public override DateTime? Parse(object value)
//        {
//            if (value == null)
//                log.Info($"NULL");
//            else
//                log.Info($"type dt={value.GetType().Name} / {value}");

//            if (value is MySqlDateTime vdt)
//                return vdt.GetDateTime();

//            return Convert.ToDateTime(value);
//        }
//    }
//}