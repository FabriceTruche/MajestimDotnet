using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Majestim.BL.Interface.OperationBanque.RapproBancaire;
using Majestim.BO.OperationBanque.RapproBancaire;
using Majestim.DTO.DTO;
using Majestim.Helpers;
using Majestim.View.Interface.View;

namespace Majestim.Presenters
{
    public class RapproBancairePresenter
    {
        private readonly IMainView _mainView;
        private readonly IRapproBancaireView _rapproBancaireView;
        private readonly IRapproBancaireService _rapproBancaireService;

        public RapproBancairePresenter(
            IMainView mainView,
            IRapproBancaireView rapproBancaireView,
            IRapproBancaireService rapproBancaireService)
        {
            this._mainView = mainView;
            this._rapproBancaireView = rapproBancaireView;
            this._rapproBancaireService = rapproBancaireService;
            this._rapproBancaireView.ImportAutoDataClick += this.RapproBancaireViewOnImportAutoDataClick;
            this._rapproBancaireView.ImportManuelDataClick += this.RapproBancaireViewOnImportManuelDataClick;
        }

        /// <summary>
        /// 
        /// </summary>
        private void RapproBancaireViewOnImportManuelDataClick()
        {
            // import manuel => réciupére les data de l'UI
            string data = this._rapproBancaireView.GetData;

            this.ImportDataClick(data);
        }

        /// <summary>
        /// 
        /// </summary>
        private void RapproBancaireViewOnImportAutoDataClick()
        {
            // import auto => récup les data du clipboard
            string data = ClipboardHelper.ClipboarData();

            this.ImportDataClick(data);
        }

        private void ImportDataClick(string data)
        {
            // initialiser les données de la view
            this._rapproBancaireView.ProvideLignesBanque(null);
            this._rapproBancaireView.ProvideLignesCompta(null);

            // 1. récupérer les données du presse-papier
            //string data = ClipboardHelper.ClipboarData();

            if (string.IsNullOrEmpty(data))
                return;

            // 2. les transmettre au pilote de banque (CA en l'occurence) qui va analyser et produire des lignes de banque
            IList<LigneBanque> lines = this._rapproBancaireService.ImportData(data);

            if (!lines.Any())
                return;

            // 3. converti les lignes de banques en listelignes de banques à afficher
            IList<LigneBanqueRo> linesRo = this._rapproBancaireService.Convert(lines);

            // 3. fournir les lignes de banque à la vue
            this._rapproBancaireView.ProvideLignesBanque(linesRo);

            if (!linesRo.Any())
                return;

            // 4. analyser les lignes de banques lues pour déduire les lignes comptables
            IList<LigneRapproCompta> ecritures = this._rapproBancaireService.AnalyzeLignesBanque(lines);

            if (!ecritures.Any())
                return;

            // 5. convertir les lignes de rappro compta en liste d'éléments à afficher
            IList< LigneRapproComptaRo> ligneRapproComptaRo = this._rapproBancaireService.Convert(ecritures);

            // 6. afficher les lignes comptas déduites des lignes de banque
            this._rapproBancaireView.ProvideLignesCompta(ligneRapproComptaRo);
        }
    }
}



/*            await this._mainView.RunProgress(() =>
            {
                this.DoImport(data);
            });
        }

        private void DoImport(string data)
        {
*/