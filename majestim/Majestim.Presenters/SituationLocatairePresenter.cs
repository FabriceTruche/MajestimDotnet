using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using log4net;
using Majestim.BL.Interface.OperationBase.Contrat;
using Majestim.BL.Interface.Rapport.SituationLocataire.Compta;
using Majestim.BL.Rapport.SituationLocataire.Compta;
using Majestim.BO;
using Majestim.BO.OperationBase.Compta;
using Majestim.BO.OperationBase.Contrat;
using Majestim.BO.Rapport.SituationLocataire;
using Majestim.DAL;
using Majestim.DAL.Interface.DAL;
using Majestim.DTO.DTO;
using Majestim.View.Interface.View;

namespace Majestim.Presenters
{
    public class SituationLocatairePresenter
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly ISituationLocataireView _situationLocataireView;
        private readonly IContratService _contratService;
        private readonly ISituationLocataireService _situationLocataireService;

        public SituationLocatairePresenter(
            ISituationLocataireView situationLocataireView,
            IContratService contratService,
            ISituationLocataireService comptaService)
        {
            this._situationLocataireView = situationLocataireView;
            this._contratService = contratService;
            this._situationLocataireService = comptaService;
            this._situationLocataireView.UpdateReportClick += this.SituationLocataireView_OnUpdateReport;
            this._situationLocataireView.Load += this.SituationLocataireView_OnLoad;
            this._situationLocataireView.ContratSelected += this.SituationLocataireView_OnContratSelected;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contrat"></param>
        private void SituationLocataireView_OnContratSelected(ContratRo contrat)
        {
            //log.Info($"Contrat selected : {contrat.Id} -{contrat.Nom}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void SituationLocataireView_OnLoad(object sender, EventArgs eventArgs)
        {
            // fournir la liste des contrats
            IList<ContratRo> contrats = this._contratService.Contrats();

            this._situationLocataireView.ProvideContrats(contrats);
        }

        /// <summary>
        /// levé lorque click sur maj du report
        /// </summary>
        /// <param name="nbMois"></param>
        /// <param name="contrats"></param>
        private void SituationLocataireView_OnUpdateReport(ChoixNbMois nbMois, IEnumerable<ContratRo> contrats)
        {
            // query des data situation selon les contrats sélectionnés
            OneMany<OperationDto, EcritureDto> rows = this._situationLocataireService.SelectLigneSituation(contrats.Select(x=>x.Id).ToList());

            // conversion vers un tableau pour le report
            SituationLocataireVisitor visitor = new SituationLocataireVisitor(nbMois);
            this._situationLocataireService.Visit(rows, visitor);

            IList<LigneSituationRo> reportRows = visitor.Report;

            // transmission de report à la vue
            this._situationLocataireView.ProvideReport(reportRows);
        }
    }
}