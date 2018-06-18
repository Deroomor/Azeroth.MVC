using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azeroth.Klz
{
    public class ViewPageAspx : System.Web.UI.Page
    {

        public dynamic Model { get { return this.ViewData[HttpContextItemWrapper.ModelFlag]; } }

        public HttpContextItemWrapper ViewData { get; private set; }

        protected override void OnInit(EventArgs e)
        {
            this.ViewData = new HttpContextItemWrapper(this.Context);
        }
    }
}
