using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azeroth.Klz
{
    public class RouteHandler:System.Web.Routing.IRouteHandler
    {
        

        public System.Web.IHttpHandler GetHttpHandler(System.Web.Routing.RequestContext requestContext)
        {
           
            return new HttpHandler(requestContext.RouteData.Values.ToDictionary(x=>x.Key.ToLower(),x=>x.Value.ToString().ToLower()));
        }

    }
}
