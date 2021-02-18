using Majestim.Interface;
using Majestim.View.Interface.App;
using Majestim.View.Interface.Command;
using Majestim.Web.UI.Interface;
using Majestim.Web.UI.Views;
using Unity;
using Unity.Lifetime;

namespace Majestim.Web.UI.App_Data
{
    public class ThemeWebSelector : IThemeSelector
    {
        private IUnityContainer _container;

        public void InitializeViewsTypes(IUnityContainer container)
        {
            this._container = container;

            // App : WebForm version
            container.RegisterType<WebMainApp>(new ContainerControlledLifetimeManager());
            container.RegisterType<IMainApp, WebMainApp>(new ContainerControlledLifetimeManager());
            container.RegisterType<IMainAppEventHandler, WebMainApp>(new ContainerControlledLifetimeManager());
            container.RegisterType<ICommand, WebCommand>(new ContainerControlledLifetimeManager());
            container.RegisterType<IContratWebView, ContratView>(new ContainerControlledLifetimeManager());
            container.RegisterType<ISituationLocataireWebView, SituationLocataireView>(new ContainerControlledLifetimeManager());

            // Controller
            // presenters (auto)
            //Assembly assyPresenters = Assembly.Load("Majestim.Web.UI");
            //Assembly assyInterface = Assembly.Load("Majestim.View.Interface");

            //foreach (Type type in assyPresenters.GetTypes().Where(x => x.Name.EndsWith("Controller")))
            //{
            //    string iface = "Majestim.View.Interface.View.I" + type.Name.Replace("Controller", "") + "View";
            //    Type fromType = assyInterface.GetType(iface);

            //    if (fromType != null)
            //    {
            //        MajestimStarter.Container.RegisterType(type);
            //        MajestimStarter.Container.RegisterType(fromType, type);
            //    }
            //}
        }

        public void Start()
        {
            IMainApp mainApp = this._container.Resolve<IMainApp>();

            mainApp?.StartApp();
        }
    }
}