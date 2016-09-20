using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace HL.Core.Cache
{
    public class MemoryCacheManager : ICacheManager
    {
        private MemoryCache Cache
        {
            get
            {
                return MemoryCache.Default;
            }
        }

        public void Clear()
        {
            foreach (var item in Cache)
            {
                Cache.Remove(item.Key);
            }   
        }

        public T Get<T>(string key)
        {
            return (T)Cache.Get(key);
        }

        public bool IsSet(string key)
        {
            return Cache.Contains(key);
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        public void Set(string key, object value,int cachetime)
        {
            var caheplicy = new CacheItemPolicy();
            caheplicy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cachetime);
            Cache.Set(key, value, caheplicy);
        }
    }
}
