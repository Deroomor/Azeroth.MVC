using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azeroth.Klz
{
    public abstract class ActionResult
    {

        public abstract void ProcessRequest(System.Web.HttpContext context);

    }
}
