using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Majestim.Application.App;
using Majestim.BL.Interface.OperationBanque.RapproBancaire;
using Majestim.DAL;
using Majestim.DAL.Interface.DAL;
using Majestim.Interface;
using Majestim.View.Interface.App;
using Unity;
using Unity.Lifetime;

namespace Majestim.Application.Conf
{
    public class MajestimStarter  : IStarter
    {
        private readonly IThemeSelector _selector;

        private static IUnityContainer _container;

        public static IUnityContainer Container => _container;

        /// <summary>
        /// 
        /// </summary>
        public MajestimStarter(IThemeSelector selector) 
        {
            // container IoC
            MajestimStarter._container = new UnityContainer().AddExtension(new Diagnostic());

            // selector of all views
            this._selector = selector;
            this._selector.InitializeViewsTypes(MajestimStarter.Container);

            // context général (DAL repo etc...)
            MajestimStarter.Container.RegisterType<IContext, Context>(/*new ContainerControlledLifetimeManager()*/);

            // Services 
            foreach (string assyName in new[] { "Majestim.BL" , "Majestim.Mapper"})
            {
                Assembly assyServices = Assembly.Load(assyName);
                IEnumerable<Type> typeServices =
                    assyServices.GetTypes().Where(x => x.Name.EndsWith("Service") && x.IsClass);

                foreach (Type type in typeServices)
                {
                    Type iface = type.GetInterfaces().Single(x => x.IsInterface && x.Name.EndsWith("Service"));

                    if (iface != null)
                        MajestimStarter.Container.RegisterType(iface, type , new ContainerControlledLifetimeManager());
                }
            }

            // Reposiotry
            // typeof(MyType).GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMyInterface<>))
            Assembly assy = Assembly.Load("Majestim.DAL");
            IEnumerable<Type> types = assy.GetTypes().Where(x => x.Name.EndsWith("Repository"));

            foreach (Type type in types)
            {
                Type iface = type.GetInterface(typeof(IRepository<>).Name);

                if (iface != null)
                    MajestimStarter.Container.RegisterType(iface, type, new ContainerControlledLifetimeManager());
            }

            //// presenters (auto)
            //Assembly assyPresenters = Assembly.Load("Majestim.Presenters");

            //foreach (Type type in assyPresenters.GetTypes().Where(x => x.Name.EndsWith("Presenter")))
            //{
            //    MajestimStarter.Container.RegisterType(type, new ContainerControlledLifetimeManager());
            //}
            
            // regles de rappro
            Assembly assyRegleRappro = Assembly.Load("Majestim.BL");

            foreach (Type type in assyRegleRappro.GetTypes().Where(x => typeof(IAnalyzerRappro).IsAssignableFrom(x)))
            {
                string name = type.Name.Replace("AnalyzerRappro", "Rapp_"); // pour compatibilité avec Version Excel
                MajestimStarter.Container.RegisterType(typeof(IAnalyzerRappro), type, name); // , ContainerControlledLifetimeManager());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        void IStarter.Start()
        {
            this._selector.Start();
        }
    }
}