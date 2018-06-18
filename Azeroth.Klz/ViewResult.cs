using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azeroth.Klz
{
    public class ViewResult:ActionResult
    {
        static Azeroth.Klz.PageHandlerFactory aspxHandlerFactory = new PageHandlerFactory();

        object model;
        string viewpath;
        public ViewResult(object model)
        {
            this.model = model;
        }

        public ViewResult(object model,string viewpath)
        {
            this.model = model;
            this.viewpath = viewpath;
        }

        public override void ProcessRequest(System.Web.HttpContext context)
        {
            this.viewpath = this.viewpath ?? context.Request.Url.AbsolutePath;
            System.Web.IHttpHandler viewhandler = this.GetHandlerFromWebPage(this.viewpath + ".cshtml");
            if (viewhandler == null)
                viewhandler = this.GetHandlerFromWebForm(this.viewpath + ".aspx", context);
            if (viewhandler == null)
                throw new ArgumentException("未找到视图" + this.viewpath);
            context.Items[HttpContextItemWrapper.ModelFlag] = this.model;
            viewhandler.ProcessRequest(context);
        }

        System.Web.IHttpHandler GetHandlerFromWebForm(string viewpath,System.Web.HttpContext context)
        {
            System.Web.IHttpHandler handler = null;
            try
            {
                handler = aspxHandlerFactory.GetHandler(context, context.Request.RequestType, viewpath, null);
            }
            catch (Exception)
            {

            }
            return handler;
        }

        System.Web.IHttpHandler GetHandlerFromWebPage(string viewpath)
        {
            System.Web.IHttpHandler handler = null;
            try
            {
                handler = System.Web.WebPages.WebPageHttpHandler.CreateFromVirtualPath(viewpath);
            }
            catch (Exception)
            {
            }
            return handler;
        }
    }
}
