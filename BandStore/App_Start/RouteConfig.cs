using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AbstraktApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //  http://localhotst/
            routes.MapRoute(
                null,
                "",
                new { controller = "NewProduct", action = "List", category = (string)null, page = 1 }
            );

            //  http://localhotst/Strona2
            routes.MapRoute(
                null,
                "Strona{page}",
                new { controller = "NewProduct", action = "List", category = (string)null },
                new { page = @"\d+" }
            );

            //  http://localhotst/Muzyka 
            routes.MapRoute(
                null,
                "{category}",
                new { controller = "NewProduct", action = "List", page = 1}
            );

            //  http://localhotst/Muzyka/Strona1
            routes.MapRoute(
                null,
                "{category}/Strona{page}",                
                new { controller = "NewProduct", action = "List" },
                new { page = @"\d+" }
            );

            //  http://localhotst/NewProduct/List/?category=Muzyka
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "NewProduct", action = "List", id = UrlParameter.Optional }
            );
        }
    }
}
