using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Appius.Mvc.Extensions
{
    public static class DataCountExtensions
    {
        public static IHtmlString DataCount(this HtmlHelper helper, int count)
        {
            if (count == 0)
            {
                return MvcHtmlString.Empty;
            }

            return MvcHtmlString.Create($" data-count=\"{count}\" ");
        }
    }
}
