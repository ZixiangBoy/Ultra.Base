using System;
using System.Collections.Generic;

namespace Ultra.Web.Core.Cache
{   
    public class CacheBase : ICache
    {
        protected Dictionary<string, object> dic = new Dictionary<string, object>(30);

        public T Get<T>(string cachekey)
        {
            if (!this.dic.ContainsKey(cachekey))
            {
                return default(T);
            }
            return (T) this.dic[cachekey];
        }

        public ICache Put<T>(string cacheKey, T val)
        {
            if (!this.dic.ContainsKey(cacheKey))
            {
                this.dic.Add(cacheKey, val);
            }
            else
            {
                this.dic[cacheKey] = val;
            }
            return this;
        }
    }
}

