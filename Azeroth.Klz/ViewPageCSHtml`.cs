using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azeroth.Klz
{
    public class ViewPageCSHtml<T>:ViewPageCSHtml where T:class
    {
        public new T Model { get { return this.ViewData[HttpContextItemWrapper.ModelFlag] as T; } }
    }
}
