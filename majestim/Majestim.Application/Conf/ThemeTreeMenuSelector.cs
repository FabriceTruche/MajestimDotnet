//using Majestim.Application.App;
//using Majestim.BL.MapperBO;
//using Majestim.DAL.Interface.Repository;
//using Majestim.DAL.Repository;
//using Majestim.Interface;
//using Majestim.UI.Views;
//using Majestim.UI.Views.ThemeTreeMenu;
//using Majestim.View.Interface.App;
//using Majestim.View.Interface.Command;
//using Majestim.View.Interface.View;
//using Unity;
//using Unity.Lifetime;

//namespace Majestim.Application.Conf
//{
//    public class ThemeTreeMenuSelector : IThemeSelector
//    {
//        private IUnityContainer _container;

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="container"></param>
//        public void InitializeViewsTypes(IUnityContainer container)
//        {
//            _container = container;

//            // App : winForm version
//            container.RegisterType<WinFormApp>(new ContainerControlledLifetimeManager());
//            container.RegisterType<IMainApp, WinFormApp>(new ContainerControlledLifetimeManager());
//            container.RegisterType<IMainAppEventHandler, WinFormApp>(new ContainerControlledLifetimeManager());
//            container.RegisterType<IContext, Context>(new ContainerControlledLifetimeManager());
//            container.RegisterType<IMapperService, MapperService>(new ContainerControlledLifetimeManager());
//            //_container.RegisterType<DapperService>(new ContainerControlledLifetimeManager());

//            // secondaries views
//            container.RegisterType<ITiersView, TiersView>(new ContainerControlledLifetimeManager());
//            container.RegisterType<IContratView, ContratView>(new ContainerControlledLifetimeManager());
//            container.RegisterType<IBienView, BienView>(new ContainerControlledLifetimeManager());
//            container.RegisterType<IComptaView, ComptaView>(new ContainerControlledLifetimeManager());

//            // main view 
//            container.RegisterType<MainMenuFormView>(new ContainerControlledLifetimeManager());
//            container.RegisterType<IMainView, MainMenuFormView>(new ContainerControlledLifetimeManager());
//            container.RegisterType<IPathView, MainMenuFormView>(new ContainerControlledLifetimeManager());

//            // explorer & menu
//            container.RegisterType<ICommandView, MainMenuFormView>(new ContainerControlledLifetimeManager());
//            container.RegisterType<ICommand, MainMenuCommand>(new ContainerControlledLifetimeManager());
//            //_container.RegisterType<IMenuCommand, MainMenu>(new ContainerControlledLifetimeManager());

//            // repos
//            container.RegisterType<ICONTRAT_Repository, CONTRAT_Repository>(new ContainerControlledLifetimeManager());
//            container.RegisterType<ILIGNE_ECRITURE_VIEW_Repository, LIGNE_ECRITURE_VIEW_Repository>(new ContainerControlledLifetimeManager());
//        }

//        void IThemeSelector.Start()
//        {
//            IMainApp mainApp = _container.Resolve<IMainApp>();

//            mainApp?.StartApp();
//        }
//    }
//}
