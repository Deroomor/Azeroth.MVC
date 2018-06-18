using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Helpers;

namespace Azeroth.Klz
{
    public abstract class Controller : System.Web.SessionState.IRequiresSessionState
    {
        public System.Web.HttpContext Context { get; private set; }

        public HttpContextItemWrapper ViewData {private set; get; }

        public Controller()
        {
            this.Context = System.Runtime.Remoting.Messaging.CallContext.HostContext as System.Web.HttpContext;
            if (Context == null)
                throw new ArgumentException("无法获取web请求上下文信息");
            this.ViewData = new HttpContextItemWrapper(this.Context);
        }

        public virtual void OnExecute()
        {
            
        }

        protected ActionResult View()
        {
            return View(null);
        }

        protected ActionResult View(object model)
        {
            return View(model);
        }

        protected ActionResult View(string viewPath)
        {
            return View(null, viewPath);
        }

        protected virtual ActionResult View(object model, string viewPath)
        {
            return new ViewResult(model,viewPath);
        }

        protected virtual ActionResult Content(string value)
        {
            var rst= new ContentResult();
            rst.Value = value;
            return rst;
        }

        protected virtual ActionResult Redirect(string url)
        {
            var rst = new RedirectResult(url);
            return rst;
        }

        protected virtual Azeroth.Klz.ActionResult Json(object value)
        {
            return new JsonResult(value);
        }

        public abstract object ResolveRequestParameter(Type type);
    }
}
