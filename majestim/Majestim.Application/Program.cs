using System;
using System.Reflection;
using log4net;
using log4net.Config;
using Majestim.Application.Conf;
using Majestim.Interface;
using Majestim.View.Interface.App;
using Unity;

namespace Majestim.Application
{
    static class Program
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            XmlConfigurator.Configure();

            //IThemeSelector selector = new ThemeTreeMenuSelector();
            //IThemeSelector selector = new ThemeSimpleSelector();
            IThemeSelector selector = new ThemeExcelSelector();
            IStarter starter = new MajestimStarter(selector);

            starter.Start();
        }
    }
}
