using System;
using Majestim.Interface;
using Majestim.View.Interface.App;
using Majestim.View.Interface.View;
using Unity;

namespace Majestim._TestBlocks.App
{
    public class ConsoleApp : IMainApp
    {
        public event EventHandler AppStartingEvent;
        public event EventHandler AppStartedEvent;
        public event EventHandler AppStoppedEvent;

        public ConsoleApp(IUnityContainer container)
        {
            this.Container = container;
            this.MainView = null;
        }

        public void ShowMainView()
        {
        }

        public IMainView MainView { get; }


        protected IUnityContainer Container { get; }


        public void StartApp()
        {
            this.AppStartingEvent?.Invoke(this, new EventArgs());

            this.Container.Resolve(typeof(IMapperService));

            this.AppStartedEvent?.Invoke(this, new EventArgs());
        }
    }
}