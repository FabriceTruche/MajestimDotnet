using System.Collections.Generic;
using Majestim.BO.OperationBase.Contrat;

namespace Majestim.Web.UI.Interface
{
    public interface IContratWebView 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contrats"></param>
        /// <returns></returns>
        string ViewContrats(IEnumerable<ContratRo> contrats);
    }
}