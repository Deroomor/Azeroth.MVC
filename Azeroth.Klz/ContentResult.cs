using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azeroth.Klz
{
    public class ContentResult:ActionResult
    {
        public string Value { get; set; }
        
        public override void ProcessRequest(System.Web.HttpContext context)
        {
            context.Response.Write(this.Value);
        }
    }
}
