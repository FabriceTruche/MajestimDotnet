using System;
using System.Reflection;
using log4net;
using Majestim.DAL;
using Majestim.Interface;
using Majestim.View.Interface.App;
using Majestim.View.Interface.View;
using Unity;

namespace Majestim.Application.App
{
    public abstract class BaseMainApp : IMainApp
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected IUnityContainer Container { get; }
        public IMainView MainView { get; protected set; }

        protected BaseMainApp(IUnityContainer container)
        {
            this.Container = container;
        }

        public abstract void ShowMainView();

        public event EventHandler AppStartingEvent;
        public event EventHandler AppStartedEvent;
        public event EventHandler AppStoppedEvent;


        /// <summary>
        /// 
        /// </summary>
        public void StartApp()
        {
            // trapp de démarrage de l'appli
            this.AppStarting();

            // instancier les presenters
            this.InstanciatePresenters();

            // instancier les mappers
            this.InstanciateMappers();

            // tout a été initilaisé 
            this.AppStarted();

            // view main  
            this.MainView = this.Container.Resolve<IMainView>();

            // afficher la view pricipale
            this.ShowMainView();
        }

        /// <summary>
        /// Un seul mapper
        /// </summary>
        private void InstanciateMappers()
        {
            this.Container.Resolve(typeof(IMapperService));
            //Container.Resolve(typeof(DapperService));
        }

        /// <summary>
        /// 
        /// </summary>
        private void InstanciatePresenters()
        {
            foreach (IContainerRegistration registration in this.Container.Registrations)
            {
                Type registeredType = registration.RegisteredType;
                if (registeredType.Name.EndsWith("Presenter"))
                    this.Container.Resolve(registeredType);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected void AppStarting()
        {
            log.Info($"App starting...");
            this.AppStartingEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// 
        /// </summary>
        protected void AppStarted()
        {
            log.Info($"App started.");
            this.AppStartedEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// 
        /// </summary>
        protected void AppStopped()
        {
            log.Info($"App stopped.");
            this.AppStoppedEvent?.Invoke(this, new EventArgs());
        }
    }
}

