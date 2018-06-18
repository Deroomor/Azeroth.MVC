using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azeroth.Klz
{
    public class AppSample:MvcApplication
    {
        public void Application_Start()
        {
            //Func<System.Web.Routing.RouteData, Azeroth.Klz.Context> contextHandler = routerdata =>
            //    new Azeroth.Klz.Context(string.Format("Testor.{0}.{1}", routerdata.Values["nav"], routerdata.Values["controller"]), string.Format("/{0}/{1}/{2}", routerdata.Values["nav"], routerdata.Values["controller"], routerdata.Values["action"]),
            //        routerdata.Values["action"].ToString(), "Testor");
            //var httpHandler = new Azeroth.Klz.RouteHandler(contextHandler);
            //System.Web.Routing.Route route = new System.Web.Routing.Route("{nav}/{controller}/{action}", httpHandler);
            //route.Defaults = new System.Web.Routing.RouteValueDictionary();
            //route.Defaults.Add("htt", new { nav = "Borameter", controller = "M1", action = "KPI" });
            //System.Web.Routing.RouteTable.Routes.Add(route);
        }
    }
}
