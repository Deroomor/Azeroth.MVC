using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azeroth.Klz
{
    public class RedirectResult:ActionResult
    {
        public string url;

        public RedirectResult(string url)
        {
            this.url = url;
        }

        public override void ProcessRequest(System.Web.HttpContext context)
        {
            context.Response.Redirect(this.url);
        }
    }
}
