using System;
using Majestim.Application.App;
using Majestim.Interface;
using Majestim.View.Interface.App;
using Majestim.View.Interface.View;
using Unity;

namespace Majestim.Web.UI.App_Data
{
    public class WebMainApp : IMainApp
    {
        protected IUnityContainer Container { get; }

        public WebMainApp(IUnityContainer container)
        {
            this.Container = container;
            this.MainView = null;
        }

        public void StartApp()
        {
            this.AppStartingEvent?.Invoke(this, new EventArgs());

            this.Container.Resolve(typeof(IMapperService));

            this.AppStartedEvent?.Invoke(this, new EventArgs());
        }

        public virtual void ShowMainView()
        {
            // nothing to show ?!
        }

        public IMainView MainView { get; }

        public event EventHandler AppStartingEvent;
        public event EventHandler AppStartedEvent;
        public event EventHandler AppStoppedEvent;
    }
}