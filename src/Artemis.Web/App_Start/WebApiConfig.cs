using Artemis.Common;
using Artemis.Data;
using Atermis.Data;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.ModelBinding.Binders;

namespace Artemis.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.AddUnity();

            config.EnableCors();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static void AddUnity(this HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<ICarAdvertDbContextProvider, CarAdvertDbContextProvider>(new HierarchicalLifetimeManager());
            container.RegisterType<ICarAdvertRepository, CarAdvertRepository>(new HierarchicalLifetimeManager());
            container.RegisterInstance(AutoMapperConfig.Create());
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
