using Majestim.Interface;
using Majestim.View.Interface.App;
using Majestim._TestBlocks.App;
using Unity;
using Unity.Lifetime;

namespace Majestim._TestBlocks.Conf
{
    public class ThemeConsoleSelector : IThemeSelector
    {
        private IUnityContainer _container;

        public void InitializeViewsTypes(IUnityContainer container)
        {
            this._container = container;

            container.RegisterType<ConsoleApp>(new ContainerControlledLifetimeManager());
            container.RegisterType<IMainApp, ConsoleApp>(new ContainerControlledLifetimeManager());
            container.RegisterType<IMainAppEventHandler, ConsoleApp>(new ContainerControlledLifetimeManager());
        }

        public void Start()
        {
            IMainApp mainApp = this._container.Resolve<IMainApp>();

            mainApp?.StartApp();
        }
    }
}