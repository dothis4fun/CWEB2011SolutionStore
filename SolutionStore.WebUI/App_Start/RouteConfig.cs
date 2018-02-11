﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SolutionStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null, "", new
            {
                controller = "Product",
                action = "List",
                category = (string)null,
                //system = (string)null,
                page = 1
            });

            routes.MapRoute(null, "Page{page}", new
            {
                controller = "Product",
                action = "List",
                category = (string)null,
                //system = (string)null
            },
            new { page = @"\d+" });

            routes.MapRoute(null, "{Category}", new
            {
                controller = "Product",
                action = "List",
                //system = (string)null,
                page = 1
            });

            routes.MapRoute(null, "{Category}/Page{page}", new
            {
                controller = "Product",
                action = "List",
                //system = (string)null
            },
            new { page = @"\d+" });

            /*
            routes.MapRoute(null, "{System}", new
            {
                controller = "Product",
                action = "List",
                category = (string)null,
                page = 1
            });
            

            routes.MapRoute(null, "{System}/Page{page}", new
            {
                controller = "Product",
                action = "List",
                category = (string)null
            },
            new { page = @"\d+" });
            
            routes.MapRoute(null, "{Category}/{System}/Page{page}", new
            {
                controller = "Product",
                action = "List"
            },
            new { page = @"\d+" });
            */
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "List", id = UrlParameter.Optional }
            );
        }
    }
}
