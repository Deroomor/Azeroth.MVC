using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T4.Web
{
    public class Home:Azeroth.Klz.Controller
    {
        public Azeroth.Klz.ActionResult Index()
        {
            this.ViewData["name"] = "hello world";
            return this.View();
        }


        public override object ResolveRequestParameter(Type type)
        {
            throw new NotImplementedException();
        }
    }


}