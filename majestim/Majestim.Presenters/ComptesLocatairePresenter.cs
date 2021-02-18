using System;
using System.Collections.Generic;
using System.Linq;
using Majestim.BL.Interface.OperationBase.Compta;
using Majestim.BL.Interface.OperationBase.Contrat;
using Majestim.BL.Interface.Rapport.CompteLocataire.Compta;
using Majestim.BL.Rapport.CompteLocataire.Compta;
using Majestim.BO;
using Majestim.BO.OperationBase.Compta;
using Majestim.BO.OperationBase.Contrat;
using Majestim.BO.Rapport.CompteLocataire;
using Majestim.DAL;
using Majestim.DAL.Interface.DAL;
using Majestim.DTO.DTO;
using Majestim.View.Interface.View;

namespace Majestim.Presenters
{
    public class ComptesLocatairePresenter
    {
        private readonly IComptesLocataireView _comptesLocataireView;
        private readonly IContratService _contratService;
        private readonly IComptaService _comptaService;
        private readonly ICompteLocataireService _compteLocataireService;
        private readonly IPeriodeService _periodeService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comptesLocataireView"></param>
        /// <param name="contratService"></param>
        /// <param name="comptaService"></param>
        /// <param name="compteLocataireService"></param>
        /// <param name="periodeService"></param>
        public ComptesLocatairePresenter(
            IComptesLocataireView comptesLocataireView,
            IContratService contratService,
            IComptaService comptaService,
            ICompteLocataireService compteLocataireService,
            IPeriodeService periodeService
            )
        {
            this._comptesLocataireView = comptesLocataireView;
            this._contratService = contratService;
            this._comptaService = comptaService;
            this._compteLocataireService = compteLocataireService;
            this._periodeService = periodeService;
            this._comptesLocataireView.Load += this.ComptesLocataire_OnLoad;
            this._comptesLocataireView.UpdateReportClicked += this.ComptesLocataireViewOnUpdateReport_Clicked;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contrat"></param>
        /// <param name="periodeDebut"></param>
        /// <param name="periodeFin"></param>
        /// <param name="comptes"></param>
        /// <param name="operations"></param>
        private void ComptesLocataireViewOnUpdateReport_Clicked(
            ContratRo contrat, 
            ChoixPeriode periodeDebut, 
            ChoixPeriode periodeFin, 
            IEnumerable<string> comptes, 
            IEnumerable<string> operations)
        {
            // query des data situation selon les contrats sélectionnés
            OneMany<OperationDto, EcritureDto> rows = this._compteLocataireService.SelectLigneEcritures(
                contrat,
                periodeDebut,
                periodeFin,
                comptes,
                operations);

            // conversion vers un tableau pour le report
            ICompteLocataireVisitor visitor = new CompteLocataireVisitor();
            IEnumerable<LigneComptesLocataireRo> reportRows = this._compteLocataireService.ConvertToReport(rows, visitor);

            // transmission de report à la vue
            this._comptesLocataireView.ProvideReport(reportRows);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void ComptesLocataire_OnLoad(object sender, EventArgs eventArgs)
        {
            // fournir la liste des contrats
            IEnumerable<ContratRo> contrats = this._contratService.Contrats();

            this._comptesLocataireView.ProvideContrats(contrats);

            // fournir la liste des périodes début/fin (pour l'instant 12 derniers mois)
            //List<DateTime> list = new List<DateTime>();

            //list.Add(DateTime.Today);
            //for (int i = 1; i <= 12; i++)
            //    list.Add(new DateTime(DateTime.Today.Year, DateTime.Today.Month,1).AddMonths(-i));
            //this._comptesLocataireView.ProvidePeriodes(list, list);

            List<DateTime> list = this._periodeService.CreatePeriodes(-6,6).ToList();
            this._comptesLocataireView.ProvidePeriodes(list, list);

            // fournir la liste des comptes
            IEnumerable<CompteDto> comptes = this._comptaService.Comptes();

            this._comptesLocataireView.ProvideComptes(comptes);

            // fournir la liste des opérations
            IEnumerable<TypeOperationDto> operations = this._comptaService.TypeOperations();

            this._comptesLocataireView.ProvideTypeOperations(operations);

        }
    }
}