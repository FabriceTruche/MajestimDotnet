using System;
using System.Configuration;
using System.Data;
using System.Reflection;
using log4net;
using Majestim.Interface;
using Majestim.View.Interface.App;
using MySql.Data.MySqlClient;
using Unity;

namespace Majestim.Application.Conf
{
    public class Context : IContext
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Context(IUnityContainer container)
        {
            this.Container = container;
            this.ConnectionString = ConfigurationManager.ConnectionStrings["majestim"].ConnectionString;
        }

        public string ConnectionString { get; }
        public IUnityContainer Container { get; }
    }
}




//public IDbConnection Connection { get; private set; }
/// <summary>
/// 
/// </summary>
/// <param name="sender"></param>
/// <param name="eventArgs"></param>
//private void OnStopped(object sender, EventArgs eventArgs)
//{
//    this.Connection.Dispose();
//}


//this._app.AppStoppedEvent += this.OnStopped;
//this.Connection = new MySqlConnection("server=localhost;uid=root;pwd=;database=majestim;Allow Zero Datetime=True;Convert Zero Datetime=False;");
