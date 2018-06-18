using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azeroth.Klz
{
    public class ViewPageCSHtml : System.Web.WebPages.WebPage
    {
        /// <summary>
        /// ViewData中约定的页面标题的键
        /// </summary>
        public string Title { set{
            this.Context.Items["__@@title"] = value;
        }
            get {
                return this.Context.Items["__@@title"] as string; 
            }
        }

        public override void Execute()
        {
            this.ExecutePageHierarchy();
        }

        public new object Model { get { return this.ViewData[HttpContextItemWrapper.ModelFlag]; } }

        public HttpContextItemWrapper ViewData { get; private set; }

        public new HtmlHelper Html { get; private set; }

        protected override void InitializePage()
        {
            this.Html = new HtmlHelper();
            this.ViewData = new HttpContextItemWrapper(this.Context.ApplicationInstance.Context);
        }
    }
}
