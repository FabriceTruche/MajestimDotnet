using System;
using System.Reflection;
using log4net;
using Majestim.View.Interface.View;

namespace Majestim.Presenters
{
    public class MainPresenter 
    {
        private readonly IMainView _mainView;
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mainView"></param>
        public MainPresenter(IMainView mainView)
        {
            this._mainView = mainView;
            mainView.OnShow += this.MainViewOnLoad;
        }

        private void MainViewOnLoad(object sender, EventArgs eventArgs)
        {
            log.Info($"Démarrage de {this.GetType().Name}");
            log.Info($"Affichage des contrats");

            this._mainView.ShowContratView();
        }
    }
}