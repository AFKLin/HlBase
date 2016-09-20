using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.Core.Cache
{
    public static class ICacheManagerExtensions
    {
        public static T Get<T>(this ICacheManager cacheManger,string key,Func<T> func)
        {
            return cacheManger.Get<T>(key, 60, func);
        }


        public static T Get<T>(this ICacheManager cacheManger, string key,int cachetime,Func<T> func)
        {
            if (cacheManger.IsSet(key))
            {
                return cacheManger.Get<T>(key);
            }
            else
            {
                T data = func();
                cacheManger.Set(key, data, cachetime);
                return data;
            }
        }
    }
}
