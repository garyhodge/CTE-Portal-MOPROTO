using System;
using System.Web;

namespace Appius.Core.Utility.Extensions
{
    public static class CookieHelper
    {
        public static void Create(string Name, string SessionId)
        {
            if (HttpContext.Current.Response.Cookies[Name] != null)
            {
                var cookie = HttpContext.Current.Response.Cookies[Name];
                cookie.Expires = DateTime.Now.AddDays(365);
                cookie.Value = SessionId.ToString();

                HttpContext.Current.Response.Cookies.Remove(Name);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            else
            {
                var cookie = new HttpCookie(Name);

                cookie.Expires = DateTime.Now.AddDays(365);
                cookie.Value = SessionId;

                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        public static void Create(string Name, string SessionId, DateTime EndDate)
        {
            if (HttpContext.Current.Response.Cookies[Name] != null)
            {
                var cookie = HttpContext.Current.Response.Cookies[Name];
                cookie.Expires = EndDate;
                cookie.Value = SessionId.ToString();

                HttpContext.Current.Response.Cookies.Remove(Name);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            else
            {
                var cookie = new HttpCookie(Name);

                cookie.Expires = DateTime.Now.AddDays(365);
                cookie.Value = SessionId;

                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        public static bool Exists(string Name)
        {
            if (HttpContext.Current.Request.Cookies[Name] != null)
            {
                return true;
            }

            return false;
        }
    }
}
