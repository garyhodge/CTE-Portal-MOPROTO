using System;
using System.Configuration;
using System.Web;

using Tools = Appius.Core.Utility.Tools;

namespace Appius.Core.Utility.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class Request
    {
        /// <summary>
        /// Get current page, or 1
        /// </summary>
        public static int CurrentPage(this HttpRequestBase Request)
        {
            var page = 1;

            if (Request.QueryString["page"] != null)
            {
                var requestedPage = page;

                if (int.TryParse(Request.QueryString["page"], out requestedPage))
                {
                    return requestedPage;
                }
            }

            return page;
        }

        /// <summary>
        /// Get current page, or 1
        /// </summary>
        public static int PageSize(this HttpRequestBase Request)
        {
            return (Request.QueryString["pagesize"] != null) ? Convert.ToInt32(Request.QueryString["pagesize"]) : 1;
        }

        public static HttpCookie GetCookie(this HttpRequestBase Request, string Name)
        {
            var cookie = Request.Cookies[Name];

            if (cookie != null)
            {
                return cookie;
            }

            return null;
        }
    }
}
