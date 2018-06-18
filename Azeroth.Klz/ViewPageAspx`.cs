using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azeroth.Klz
{
    public class ViewPageAspx<T>:ViewPageAspx where T:class
    {
        public new T Model { get { return this.ViewData[HttpContextItemWrapper.ModelFlag] as T; } }
    }
}
