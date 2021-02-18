//using System;
//using System.Data;
//using System.Reflection;
//using Majestim.DAL.Interface.DAL;

//namespace Majestim.DAL
//{
//    public static class RepoFactory
//    {
//        public static IRepositoryCrud<T> CreateFactory<T>(IDbConnection cnx)
//        {
//            string name = $"Majestim.DAL.POCO.Dapper.{typeof(T).Name}_Command";
//            Assembly assy = Assembly.Load("Majestim.DAL");
//            Type repo = assy.GetType(name);
//            object obj = Activator.CreateInstance(repo,cnx);

//            return obj as IRepositoryCrud<T>;
//        }
//    }
//}