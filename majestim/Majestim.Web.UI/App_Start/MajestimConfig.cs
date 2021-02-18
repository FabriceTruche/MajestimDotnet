using System.Web.Mvc;
using Majestim.Application.Conf;
using Majestim.Interface;
using Unity.AspNet.Mvc;

namespace Majestim.Web.UI
{
    public class MajestimConfig
    {
        public static void Initialize(IThemeSelector selector)
        {
            IStarter starter = new MajestimStarter(selector);

            starter.Start();
        }
    }
}