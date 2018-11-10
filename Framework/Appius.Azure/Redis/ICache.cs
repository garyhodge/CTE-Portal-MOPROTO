using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appius.Azure.Redis
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICache
    {
        bool Add<T>(string key, T Entity) where T : class;

        T Get<T>(string Key) where T : class;

        bool Update<T>(string Key, T Entity) where T : class;

        bool Delete(string Key); 
    }
}
