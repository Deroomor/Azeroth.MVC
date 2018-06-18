using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azeroth.Klz
{
    public class HtmlHelper
    {
        public System.Web.IHtmlString Raw(string value)
        {
            return new System.Web.HtmlString(value);
        }

        public System.Web.IHtmlString Space(int number)
        {
            return new System.Web.HtmlString(string.Concat(System.Linq.Enumerable.Repeat("&nbsp;", number)));
        }

    }
}
