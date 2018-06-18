using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azeroth.Klz
{
    public class HttpContextItemWrapper
    {
        public const string ModelFlag = "___@@model";
        System.Web.HttpContext context;

        public HttpContextItemWrapper(System.Web.HttpContext context)
        {
            this.context = context;
        }

        public object this[object index]
        {
            get
            {
                return this.context.Items[index];
            }
            set
            {
                this.context.Items[index] = value;
            }
        }
    }
}
