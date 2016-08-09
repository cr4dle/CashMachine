﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CashMachine
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{quantity}",
                defaults: new { quantity = RouteParameter.Optional }
            );
        }
    }
}
