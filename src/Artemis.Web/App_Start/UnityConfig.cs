using Artemis.Common;
using Artemis.Data;
using Artemis.Web.ViewModels;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Artemis.Web
{
    public static class UnityConfig
    {
        public static void EnableUnity(this HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterTypes();
            config.DependencyResolver = new UnityResolver(container);
        }

        private static void RegisterTypes(this UnityContainer container)
        {
            container.RegisterType<IUnitOfWork, CarAdvertUnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepository<CarAdvert>, CarAdvertRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IViewModel<CarAdvert>, CarAdvertViewModel>(new HierarchicalLifetimeManager());
            container.RegisterInstance(AutoMapperConfig.Create());
        }
    }
}