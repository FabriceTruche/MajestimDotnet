using System;
using System.Data;
using System.Linq;
using Dapper;

namespace Majestim.DAL
{
    public static class EnumHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cnx"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ValueOf<T>(IDbConnection cnx, T value)
        {
            string table = typeof(T).Name;
            string code = value.ToString();

            table = table.Substring(0, table.Length - 5);
            dynamic r = cnx.Query($"select * from {table} where code='{code}'").Single();

            return r.ID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cnx"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T ValueOf<T>(IDbConnection cnx, int id)
        {
            string table = typeof(T).Name;

            table = table.Substring(0, table.Length - 5);
            dynamic r = cnx.Query($"select * from {table} where id={id}").Single();

            return (T) Enum.Parse(typeof(T),(string) r.CODE);
        }
    }
}