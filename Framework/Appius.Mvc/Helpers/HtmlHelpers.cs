using System;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace Appius.Mvc.Helpers
{
    public static class HtmlHelpers
    {
        public static IHtmlString GoogleMapsAPIKey(this HtmlHelper helper)
        {
            var googleMapsApiKey = (string)ConfigurationManager.AppSettings["GoogleMapsAPIKey"];

            return new MvcHtmlString(googleMapsApiKey);
        }
    }
}