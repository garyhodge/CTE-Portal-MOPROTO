using System;
using System.Web;

namespace Appius.Core.Utility.Tools
{
    public static class Cache
    {
        public static void Store<T>(T Item, string Key, DateTime Expiry, bool SlidingExpiration) where T : class
        {
            var cache = HttpContext.Current.Cache;

            cache.Remove(Key);

            //if (cache[Key] != null)
            //{
                //cache.Remove(Key);
            //}

            cache.Add(Key, Item, null, Expiry, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
        }

        public static T Retrieve<T>(string Key) where T : class
        {
            var cache = HttpContext.Current.Cache;

            if (cache[Key] != null)
            {
                return (T)cache[Key];
            }

            return null;
        }

        public static void Clear(string Key)
        {
            var cache = HttpContext.Current.Cache;
            cache.Remove(Key);
        }
    }
}
