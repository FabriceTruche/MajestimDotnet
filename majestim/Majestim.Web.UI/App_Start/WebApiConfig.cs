
using System.Web.Http;
using System.Web.Http.Dependencies;
using System.Web.Mvc;
using Majestim.Application.Conf;
using Unity;
using Unity.AspNet.Mvc;

namespace Majestim.Web.UI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services API Web

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "SituationLocataireRoute",
                routeTemplate: "api/situ",
                defaults: new { controller = "SituationLocataire", action = "GetSitu" }
            );


            config.Routes.MapHttpRoute(
                name: "Default_Blog",
                routeTemplate: "b/{blog}/archive/{permalink}",
                defaults: new {controller = "Values", action = "Toto"}
            );

            config.Routes.MapHttpRoute(
                name: "Api",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {action = "Toto", id = RouteParameter.Optional}
            );

            // unity ASP MVC 
            UnityDependencyResolver dependencyResolver = new UnityDependencyResolver(MajestimStarter.Container);
            DependencyResolver.SetResolver(dependencyResolver);

            // unity ASP WebAPI MVC
            config.DependencyResolver = new UnityHttpResolver(MajestimStarter.Container);

            // json
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
