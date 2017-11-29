using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ManageSystem
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Student", action = "ClassManage", id = UrlParameter.Optional }
                );
            routes.MapRoute("StudentRollCallUI", "Student/StudentRollCallUI");
            routes.MapRoute("StudentMainUI", "Student/StudentMainUI");
            routes.MapRoute("Score", "Student/Score");
        }
    }
}
