using System;

namespace Ultra.Web.Core.Cache
{
    public interface ICache
    {
        T Get<T>(string cachekey);
        ICache Put<T>(string cacheKey, T val);
    }
}

