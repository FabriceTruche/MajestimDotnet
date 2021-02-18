using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Majestim.BL.Interface.Rapport.SituationLocataire.Compta;
using Majestim.BO.OperationBase.Compta;
using Majestim.DAL.Interface.DAL;
using Majestim.DTO.DTO;
using Majestim.Web.UI.Interface;
using Majestim.Web.UI.Views;

namespace Majestim.Web.UI.ControllersApi
{
    public class SituationLocataireApiController : ApiController
    {
        private readonly ISituationLocataireService _situationLocataireService;
        private readonly ISituationLocataireWebView _situationLocataireWebView;

        public SituationLocataireApiController(
            ISituationLocataireService situationLocataireService,
            ISituationLocataireWebView situationLocataireWebView)
        {
            this._situationLocataireService = situationLocataireService;
            this._situationLocataireWebView = situationLocataireWebView;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contrats"></param>
        /// <param name="nbMois"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetSitu(string contrats="")
        {
            IEnumerable<int> contratIds = this.ContratIds(contrats);
            //ChoixNbMois choixNbMois = new ChoixNbMois(nbMois);

            // query des data situation selon les contrats sélectionnés
            OneMany<OperationDto, EcritureDto> rows =
                this._situationLocataireService.SelectLigneSituation(contratIds.ToList());

            // transmission de report à la vue
            return new SituationLocataireView().GetView2(rows);
        }

        /// <summary>
        /// retourne la liste des ID de contrat
        /// </summary>
        /// <param name="contrats"></param>
        /// <returns></returns>
        private IEnumerable<int> ContratIds(string contrats)
        {
            List<int> list = new List<int>();

            if (string.IsNullOrEmpty(contrats))
                return list;

            string[] contratsIds = contrats.Split(',');

            foreach (string id in contratsIds)
            {
                if (!int.TryParse(id, out int idRes))
                    continue;

                if (!list.Exists(x => x == idRes))
                    list.Add(idRes);
            }

            return list;
        }
    }
}