
using System;
using System.Collections.Generic;
using Majestim.BL.Interface.OperationBase.Contrat;
using Majestim.BO;
using Majestim.BO.OperationBase.Contrat;
using Majestim.BO.OperationBase.Patrimoine;
using Majestim.BO.OperationBase.Tiers;
using Majestim.View.Interface.View;

namespace Majestim.Presenters
{
    public class ContratPresenter
    {
        private readonly IMainView _mainView;
        private readonly IContratView _contratView;
        private readonly IContratService _contratService;

        public ContratPresenter(
            IMainView mainView, 
            IContratView contratView,
            IContratService contratService)
        {
            this._mainView = mainView;
            this._contratView = contratView;
            this._contratService = contratService;

            this._contratView.OnShowView += this.OnContratsDisplayed;
            this._contratView.OnContratSelected += this.OnContratSelected;
        }

        /// <summary>
        /// Un contrat vient d'être sélectionné dans l'UI
        /// </summary>
        /// <param name="contrat"></param>
        private void OnContratSelected(ContratRo contrat)
        {
            //IEnumerable<Lot> lots = this._contratService.LotsOfContrat(contrat);
            //IEnumerable<Preneur> preneurs = this._contratService.PreneursOfContrat(contrat);

            //this._contratView.ShowContratDetail(contrat, lots, preneurs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void OnContratsDisplayed(object sender, EventArgs eventArgs)
        {
            IEnumerable<ContratRo> res = this._contratService.ContratsActif();

            this._contratView.ShowContrats(res);
        }
    }
}