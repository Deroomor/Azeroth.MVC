using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Azeroth.Klz
{
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// 各个控制器的类型元数据
        /// </summary>
        public Dictionary<string, RuntimeTypeHandle> DictController { get; set; }

        /// <summary>
        /// 各个控制器的方法的委托
        /// </summary>
        //public Dictionary<RuntimeTypeHandle, Dictionary<string,Delegate>> DictAction { set; get; }

        //public FactoryAspx FactoryAspx { set; get; }

        #region 阻止微软程序集自启动注册cshtml的handler
        //protected static object webPageHttpModuleEnable = null;
        //public virtual void StopWebPageHttpModuleRegisterHandler()
        //{
        //    IHttpModule m = null;
        //    foreach (var item in this.Modules.AllKeys)
        //    {
        //        if (this.Modules[item].GetType().Name == "WebPageHttpModule")
        //        {
        //            m = this.Modules[item];
        //            break;
        //        }
        //    }
        //    if (m != null)
        //    {
        //        var value = m.GetType().GetField("_hasBeenRegisteredKey", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
        //        if (value != null)
        //            webPageHttpModuleEnable = value.GetValue(null);
        //    }
        //}
        //public override void Init()
        //{
        //    if (webPageHttpModuleEnable != null)
        //        this.Context.Items[webPageHttpModuleEnable] = 1;
        //}
        #endregion
    }
}
