//using Majestim.Application.App;
//using Majestim.BL.MapperBO;
//using Majestim.Interface;
//using Majestim.UI.Views;
//using Majestim.View.Interface.App;
//using Majestim.View.Interface.Command;
//using Majestim.View.Interface.View;
//using Unity;
//using Unity.Lifetime;

//namespace Majestim.Application.Conf
//{
//    public class ThemeSimpleSelector : IThemeSelector
//    {
//        private IUnityContainer _container;

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

//            // main view 
//            container.RegisterType<Form1>(new ContainerControlledLifetimeManager());
//            container.RegisterType<IMainView, Form1>(new ContainerControlledLifetimeManager());
//            container.RegisterType<IPathView, Form1>(new ContainerControlledLifetimeManager());

//            container.RegisterType<ITiersView, Form1>(new ContainerControlledLifetimeManager());
//            container.RegisterType<IContratView, Form1>(new ContainerControlledLifetimeManager());
//            container.RegisterType<IBienView, Form1>(new ContainerControlledLifetimeManager());

//            // explorer & menu
//            container.RegisterType<ICommandView, Form1>(new ContainerControlledLifetimeManager());
//            container.RegisterType<ICommand, MainMenuCommand>(new ContainerControlledLifetimeManager());
//            //_container.RegisterType<IMenuCommand, MainMenu>(new ContainerControlledLifetimeManager());
//        }

//        public void Start()
//        {
//            IMainApp mainApp = _container.Resolve<IMainApp>();

//            mainApp?.StartApp();

//        }
//    }
//}