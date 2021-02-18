using System;
using System.Collections.Generic;
using System.Linq;
using Majestim.BL.Interface.OperationBase.Compta;
using Majestim.BL.Interface.OperationBase.Contrat;
using Majestim.BL.Interface.OperationGestion.AppelLoyer.Compta;
using Majestim.BL.OperationBase.Compta;
using Majestim.BO.OperationBase.Contrat;
using Majestim.BO.OperationGestion.AppelLoyer;
using Majestim.DTO.Enum;
using Majestim.View.Interface.View;

namespace Majestim.Presenters
{
    public class AppelLoyerPresenter
    {
        private readonly IAppelLoyerView _appelLoyerView;
        private readonly ILignesAppelsService _lignesAppelsService;
        private readonly ILignesComptablesService _lignesComptablesService;
        private readonly IContratService _contratService;
        private readonly IPeriodeService _periodeService;

        public AppelLoyerPresenter(
            IAppelLoyerView appelLoyerView,
            ILignesAppelsService lignesAppelsService,
            ILignesComptablesService lignesComptablesService,
            IContratService contratService,
            IPeriodeService periodeService)
        {
            this._appelLoyerView = appelLoyerView;
            this._lignesAppelsService = lignesAppelsService;
            this._lignesComptablesService = lignesComptablesService;
            this._contratService = contratService;
            this._periodeService = periodeService;
            this._appelLoyerView.Load += this.AppelLoyerView_OnLoad;
            this._appelLoyerView.UpdateReportClicked += this.AppelLoyerViewOnUpdateReport_Clicked;
            this._appelLoyerView.CreerLignesComptablesClicked += this.AppelLoyerViewOnCreerLignesComptables_Clicked;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appels"></param>
        private void AppelLoyerViewOnCreerLignesComptables_Clicked(IList<LigneAppel> appels)
        {
            this._lignesComptablesService.CreateLignesComptables(appels);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contrats"></param>
        /// <param name="periode"></param>
        private void AppelLoyerViewOnUpdateReport_Clicked(IList<ContratRo> contrats, DateTime periode)
        {
            IList<LigneAppel> lignesAppels = this._lignesAppelsService.CreateLignesAppel(contrats, periode);
            IList<LigneAppelRo> lignesReport = this.CreateLignesReport(lignesAppels, periode);
            this._appelLoyerView.ProvideReport(lignesAppels, lignesReport);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="periode"></param>
        /// <returns></returns>
        private IList<LigneAppelRo> CreateLignesReport(IList<LigneAppel> rows, DateTime periode)
        {
            List<LigneAppelRo> report = new List<LigneAppelRo>();

            foreach (LigneAppel row in rows)
            {
                if (!row.AppelLoyerDetail.Any())
                    continue;

                string contrat = row.Bail.Nom;
                TypeAppel? typeAppel = row.TypeAppel;
                bool? exists = false;
                DebitCreditHelper dcHelper = new DebitCreditHelper();
                DateTime? lignePeriode = periode;

                foreach (LigneAppelDetail detail in row.AppelLoyerDetail)
                {
                    LigneAppelRo lar = new LigneAppelRo();

                    report.Add(lar);
                    lar.Contrat = contrat;
                    lar.TypeAppel = typeAppel;
                    lar.Periode = lignePeriode;
                    lar.Compte = detail.Compte;
                    lar.Credit = detail.Credit;
                    lar.Debit = detail.Debit;
                    lar.Libelle = detail.Libelle;
                    lar.Exists = exists;
                    lar.DejaAppele = row.DejaAppele;
                    lar.LigneAppelLoyerReportType = LigneAppelRoType.Row;

                    dcHelper.Add(0, (lar.Debit, lar.Credit));

                    typeAppel = null;
                    contrat = null;
                    exists = null;
                    lignePeriode = null;
                }
                (double? debit, double? credit) res = dcHelper.Solde(0);

                // totaux
                report.Add(new LigneAppelRo
                {
                    Debit = res.debit,
                    Credit = res.credit,
                    LigneAppelLoyerReportType = LigneAppelRoType.Total,
                    DejaAppele = row.DejaAppele
                });

                // empty row
                report.Add(new LigneAppelRo
                {
                    LigneAppelLoyerReportType = LigneAppelRoType.EmptyRow
                });
            }

            return report;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void AppelLoyerView_OnLoad(object sender, EventArgs eventArgs)
        {
            IList<ContratRo> contrats = this._contratService.Contrats();
            this._appelLoyerView.ProvideContrats(contrats);

            IList<DateTime> periodes = this._periodeService.CreatePeriodes(-3, 3);
            this._appelLoyerView.ProvidePeriode(periodes);
        }
    }
}
