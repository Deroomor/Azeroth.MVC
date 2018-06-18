using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azeroth.Klz
{
    public class HttpHandler : System.Web.IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        static string controllerFlag = "controller";
        static string actionFlag = "action";
        static System.Type controllerMETA = typeof(Controller);
        public const string RoutDataValueFlag = "@@dictUrlSegment@@";


        static Dictionary<string, System.RuntimeTypeHandle> dictController =
            ConcatDict(System.AppDomain.CurrentDomain.GetAssemblies().ToDictionary(x => x.FullName,
            x => x.GetTypes().Where(y => y.IsClass && y.IsPublic && y.IsSubclassOf(controllerMETA)).ToDictionary(a => a.FullName, a => a.TypeHandle)));

        static Dictionary<string, System.RuntimeTypeHandle> ConcatDict(Dictionary<string, Dictionary<string, System.RuntimeTypeHandle>> kvkv)
        {
            var dict = new Dictionary<string, System.RuntimeTypeHandle>();
            foreach (var kv in kvkv)
            {
                foreach (var v in kv.Value)
                {
                    dict.Add(v.Key.ToLower(), v.Value);
                }
            }
            return dict;
        }
            
        public bool IsReusable { set; get; }

        Dictionary<string, string> dictUrlSegment;
        

        public HttpHandler(Dictionary<string,string> dictUrlSegment)
        {
            if (!dictUrlSegment.ContainsKey(controllerFlag))
                throw new ArgumentException("路由配置必须包含controller段");
            if (!dictUrlSegment.ContainsKey(actionFlag))
                throw new ArgumentException("路由配置必须包含action段");
            this.dictUrlSegment = dictUrlSegment;
        }


        /// <summary>
        /// 重写这个去处理依赖注入相关的功能
        /// </summary>
        /// <param name="controllerTH"></param>
        /// <returns></returns>
        protected virtual Controller CreateController(RuntimeTypeHandle controllerTH)
        {
            return  (Controller)System.Activator.CreateInstance(System.Type.GetTypeFromHandle(controllerTH));
        }

        public void ProcessRequest(System.Web.HttpContext context)
        {
            string controllerName = dictUrlSegment[controllerFlag];
            var controllers = dictController.Where(x => x.Key.IndexOf(controllerName) >= 0).ToDictionary(kv => kv.Key, kv => kv.Value);
            System.RuntimeTypeHandle controllerTH;
            if (controllers.Count < 1)
                throw new ArgumentException("未找到指定的控制器" + controllerName);
            else if (controllers.Count == 1)
                controllerTH = controllers.First().Value;
            else
                controllerTH = controllers[controllers.ToDictionary(kv => kv.Key, kv => dictUrlSegment.Values.Count(a => kv.Key.IndexOf(a) >= 0)).OrderBy(kv => kv.Value).First().Key];
            Controller controllerInstance = CreateController(controllerTH);
            var method = System.Type.GetTypeFromHandle(controllerTH).GetMethod(this.dictUrlSegment[actionFlag], System.Reflection.BindingFlags.IgnoreCase| System.Reflection.BindingFlags.Instance| System.Reflection.BindingFlags.Public);
            if (method == null)
                throw new ArgumentException("未找到指定的方法" + dictUrlSegment[actionFlag]);
            controllerInstance.OnExecute();//调用方法之前，先统一调用OnExecute
            var parameters = method.GetParameters().Select(x => controllerInstance.ResolveRequestParameter(x.ParameterType)).ToArray();
            var rst = method.Invoke(controllerInstance, parameters) as ActionResult;
            if (rst == null)
                throw new ArgumentException("控制器方法必须返回ActionResult");
            context.Items[RoutDataValueFlag] = this.dictUrlSegment;
            rst.ProcessRequest(context);
        }
    }
}
