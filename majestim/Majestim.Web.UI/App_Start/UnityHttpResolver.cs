using Unity;

namespace Majestim.Web.UI
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http.Dependencies;

    public class UnityHttpResolver : IDependencyResolver
    {
        protected IUnityContainer container;

        public UnityHttpResolver(IUnityContainer container)
        {
            this.container = container ?? throw new ArgumentNullException("container");
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return this.container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this.container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()
        {
            IUnityContainer child = this.container.CreateChildContainer();
            return new UnityHttpResolver(child);
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            this.container.Dispose();
        }
    }
}

