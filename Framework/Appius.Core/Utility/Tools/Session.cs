using System.Web;

namespace Appius.Core.Utility.Tools
{
    public static class Session
    {
        public static void Store<T>(string SessionKey, T Item)
        {
            HttpContext.Current.Session.Add(SessionKey, Item);
        }

        public static T Retrieve<T>(string SessionKey)
        {
            
            return (T)HttpContext.Current.Session[SessionKey];
        }
    }
}
