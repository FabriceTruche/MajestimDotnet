//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Majestim.BL.Interface.Tiers;
//using Majestim.BO.Compta;
//using Majestim.View.Interface.View;

//namespace Majestim.Presenters
//{
//    public class ComptaPresenter
//    {
//        private readonly IMainView _mainView;
//        private readonly IComptaView _comptaView;
//        private readonly ISituationLocataireService _clService;

//        public ComptaPresenter(
//            IMainView mainView,
//            IComptaView comptaView,
//            ISituationLocataireService clService)
//        {
//            _mainView = mainView;
//            _comptaView = comptaView;
//            _clService = clService;

//            _comptaView.OnShowView += ComptaViewOnOnShowView;
//        }

//        /// <summary>
//        /// affiche la compta pour l'instant ...
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="eventArgs"></param>
//        private void ComptaViewOnOnShowView(object sender, EventArgs eventArgs)
//        {
//            IEnumerable<LigneEcriture> lignes = _clService.SelectEcritures(0, DateTime.Now, "0");

//            _comptaView.ShowCompteLocataire(lignes, null);
//        }
//    }
//}