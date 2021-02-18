using System;
using System.Linq;
using System.Reflection;
using Majestim.Application.App;
using Majestim.DAL.Interface.Repository;
using Majestim.Interface;
using Majestim.UI.ThemeExcel.Command;
using Majestim.UI.ThemeExcel.View;
using Majestim.View.Interface.App;
using Majestim.View.Interface.Command;
using Majestim.View.Interface.View;
using Unity;
using Unity.Lifetime;

namespace Majestim.Application.Conf
{
    public class ThemeExcelSelector : IThemeSelector
    {
        private IUnityContainer _container;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        public void InitializeViewsTypes(IUnityContainer container)
        {
            this._container = container;

            // presenters (auto)
            Assembly assyPresenters = Assembly.Load("Majestim.Presenters");

            foreach (Type type in assyPresenters.GetTypes().Where(x => x.Name.EndsWith("Presenter")))
            {
                MajestimStarter.Container.RegisterType(type, new ContainerControlledLifetimeManager());
            }

            // App : winForm version
            container.RegisterType<WinFormApp>(new ContainerControlledLifetimeManager());
            container.RegisterType<IMainApp, WinFormApp>(new ContainerControlledLifetimeManager());
            container.RegisterType<IMainAppEventHandler, WinFormApp>(new ContainerControlledLifetimeManager());

            // secondaries views
            container.RegisterType<ITiersView, TiersView>(new ContainerControlledLifetimeManager());
            container.RegisterType<IContratView, ContratView>(new ContainerControlledLifetimeManager());
            container.RegisterType<IBienView, BienView>(new ContainerControlledLifetimeManager());
            container.RegisterType<IComptaView, ComptaView>(new ContainerControlledLifetimeManager());

            container.RegisterType<ISituationLocataireView, SituationLocataireView>(new ContainerControlledLifetimeManager());
            container.RegisterType<IComptesLocataireView, ComptesLocataireView>(new ContainerControlledLifetimeManager());
            container.RegisterType<IAppelLoyerView, AppelLoyerView>(new ContainerControlledLifetimeManager());
            container.RegisterType<IRapproBancaireView, RapproBancaireView>(new ContainerControlledLifetimeManager());

            // main view 
            container.RegisterType<MainView>(new ContainerControlledLifetimeManager());
            container.RegisterType<IMainView, MainView>(new ContainerControlledLifetimeManager());
            container.RegisterType<IPathView, MainView>(new ContainerControlledLifetimeManager());

            // explorer & menu
            container.RegisterType<ICommandView, MainView>(new ContainerControlledLifetimeManager());
            container.RegisterType<ICommand, MainCommand>(new ContainerControlledLifetimeManager());
        }

        void IThemeSelector.Start()
        {
            IMainApp mainApp = this._container.Resolve<IMainApp>();

            mainApp?.StartApp();
        }
    }
}
