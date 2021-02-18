using System.Collections.Generic;
using System.Web.Mvc;
using Majestim.BL.Interface.OperationBase.Contrat;
using Majestim.BO.OperationBase.Contrat;
using Majestim.Web.UI.Interface;

namespace Majestim.Web.UI.Controllers
{
    public class ContratController : Controller
    {
        private readonly IContratWebView _contratView;
        private readonly IContratService _contratService;

        public ContratController(
            IContratWebView contratView,
            IContratService contratService )
        {
            this._contratView = contratView;
            this._contratService = contratService;
        }

        // GET
        public ActionResult All()
        {
            string ls = "";

            foreach (string param in this.Request.Params.AllKeys)
            {
                ls += param + " = " + this.Request.Params[param] + "<br>";
            }

            // prépare les données
            IEnumerable<ContratRo> res = this._contratService.ContratsActif();

            // les envoie à la vue
            return this.Content(ls + this._contratView.ViewContrats(res));
        }
    }
}