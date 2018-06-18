using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace T4.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            System.Web.Routing.RouteTable.Routes.Add(new System.Web.Routing.Route("{controller}/{action}",new Azeroth.Klz.RouteHandler()));
        }

        public override void Init()
        {
            this.BeginRequest += Global_BeginRequest;
        }

        void Global_BeginRequest(object sender, EventArgs e)
        {
            string tmp=this.Request.Url.AbsolutePath.ToLower();
            if (tmp.EndsWith(".cshtml"))
                this.Response.Redirect(tmp.Substring(0,tmp.Length-7));
            if (tmp.EndsWith(".aspx"))
                this.Response.Redirect(tmp.Substring(0, tmp.Length - 4));
        }
    }
}