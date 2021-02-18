using System.Collections.Generic;
using System.Web.Http;

namespace Majestim.Web.UI.ControllersApi
{
    public class ValuesController : ApiController
    {
        public IEnumerable<string> Action()
        {
            return new string[] { "Hello", "Fabrice" };
        }

        [HttpGet]
        public IEnumerable<string> Toto(string blog)
        {
            return new string[] { "Hello", "Toto" };
        }
    }
}
