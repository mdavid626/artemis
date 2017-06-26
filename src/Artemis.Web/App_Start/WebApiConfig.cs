﻿using Microsoft.Practices.Unity;
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

            config.MapHttpAttributeRoutes();
        }

        private static void AddUnity(this HttpConfiguration config)
        {
            var container = new UnityContainer();
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
