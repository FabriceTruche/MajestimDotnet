using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using Majestim.BL.Interface.Rapport.SituationLocataire.Compta;
using Majestim.BO.OperationBase.Compta;
using Majestim.BO.OperationBase.Contrat;
using Majestim.BO.OperationBase.Patrimoine;
using Majestim.BO.OperationBase.Tiers;
using Majestim.BO.OperationGestion.AppelLoyer;
using Majestim.BO.Rapport.SituationLocataire;
using Majestim.DAL.Interface.DAL;
using Majestim.DTO.DTO;
using Majestim.View.Interface.View;
using Majestim.Web.UI.Interface;

namespace Majestim.Web.UI.Controllers
{
    public class SituationLocataireController : Controller
    {
        private readonly ISituationLocataireService _situationLocataireService;
        private readonly ISituationLocataireWebView _situationLocataireWebView;

        public SituationLocataireController(
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
        public ActionResult All(string contrats, string nbMois)
        {
            IEnumerable<int> contratIds = this.ContratIds(contrats);
            ChoixNbMois choixNbMois = new ChoixNbMois(nbMois);

            // query des data situation selon les contrats sélectionnés
            OneMany<OperationDto, EcritureDto> rows =
                this._situationLocataireService.SelectLigneSituation(contratIds.ToList());

            // déléguer la création de la vue
            string data = this._situationLocataireWebView.GetView(rows, choixNbMois);

            // transmission de report à la vue
            return this.Content(data);
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

                if (!list.Exists(x=>x==idRes))
                    list.Add(idRes);
            }

            return list;
        }
    }
}