using System;
using System.Configuration;
using System.Web.Script.Serialization;

using StackExchange.Redis;
using StackExchange.Redis.Extensions.Core;
using StackExchange.Redis.Extensions.Protobuf;

using Tools = Appius.Azure.Configuration;
using Utility = Appius.Core.Utility.Tools;

namespace Appius.Azure.Redis
{
    public class Cache : IDisposable,ICache
    {
        private static Lazy<ConnectionMultiplexer> _lazyConnection;

        private IDatabase _Database;
        private StackExchangeRedisCacheClient _Cache;
        private bool _bUseLocalCache;

        /// <summary>
        /// 
        /// </summary>
        public Cache()
        {
            var settings = new Tools.Settings();

            _lazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(settings.CacheConnection));

            var serializer = new ProtobufSerializer();

            _bUseLocalCache = settings.UseLocalCache;

            _Cache = new StackExchangeRedisCacheClient(_lazyConnection.Value, serializer, "__");

            _Database = _Cache.Database;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Add<T>(string Key, T Entity) where T : class
        {
            var entity = Serialise(Entity);

            if (_bUseLocalCache)
            {
                Utility.Cache.Store<T>(Entity, Key, DateTime.Now.AddMinutes(60), true);
                return true;
            }

            return _Cache.Add(Key, entity);
        }

        /// <summary>
        /// 
        /// </summary>
        public T Get<T>(string Key) where T : class
        {
            if(_bUseLocalCache)
            {
                return Utility.Cache.Retrieve<T>(Key);
            }

            var entity = _Cache.Get<string>(Key);

            return entity != null ? Deserialise<T>(entity) : default(T);
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Update<T>(string Key, T Entity) where T : class
        {
            if (_bUseLocalCache)
            {
                Utility.Cache.Clear(Key);
                Utility.Cache.Store<T>(Entity, Key, DateTime.Now.AddMinutes(60), true);

                return true;
            }

            if (_Cache.Exists(Key))
            {
                if (_Cache.Remove(Key))
                {
                    var entity = Serialise(Entity);

                    return _Cache.Add(Key, entity);
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Delete(string Key)
        {
            if (_bUseLocalCache)
            {
                Utility.Cache.Clear(Key);

                return true;
            }

            if (_Cache.Exists(Key))
            {
                return _Cache.Remove(Key);
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        private string Serialise(object Entity)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(Entity);
        }

        /// <summary>
        /// 
        /// </summary>
        private T Deserialise<T>(string Entity)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(Entity);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
        }
    }
}
