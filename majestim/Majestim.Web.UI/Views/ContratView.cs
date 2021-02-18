using System.Collections.Generic;
using Majestim.BO.OperationBase.Contrat;
using Majestim.Web.UI.Interface;

namespace Majestim.Web.UI.Views
{
    public class ContratView : IContratWebView
    {
        public string ViewContrats(IEnumerable<ContratRo> contrats)
        {
            string res = "";

            foreach (ContratRo contrat in contrats)
            {
                res += contrat.Nom + "<br>";
            }

            return res;
        }
    }
}