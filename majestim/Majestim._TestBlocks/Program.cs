using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Config;
using Majestim.Application.Conf;
using Majestim.Interface;
using Majestim._TestBlocks.Conf;
using Unity;

namespace Majestim._TestBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlConfigurator.Configure();

            IThemeSelector selector = new ThemeConsoleSelector();
            IStarter starter = new MajestimStarter(selector);

            starter.Start();

            Situation test = MajestimStarter.Container.Resolve<Situation>();

            test.Run();

            Console.ReadKey();
        }
    }
}
