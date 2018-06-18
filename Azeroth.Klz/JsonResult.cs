using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azeroth.Klz
{
    public class JsonResult:ActionResult
    {
        public object value;

        public JsonResult(object value)
        {
            this.value = value;
        }

        public override void ProcessRequest(System.Web.HttpContext context)
        {
            var rst= new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(this.value);
            context.Response.Write(rst);
        }
    }
}
