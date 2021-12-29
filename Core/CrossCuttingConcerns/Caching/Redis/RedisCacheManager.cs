using System;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Core.CrossCuttingConcerns.Caching.Redis
{
    public class RedisCacheManager : ICacheManager
    {
        public void Add(string key, object value, int duration)
        {
            // var cacheOptions = new DistributedCacheEntryOptions
            // {
            //     AbsoluteExpiration = DateTime.Now.AddMinutes(duration)
            // };
            //
            // using (var redisCache = new RedisCache(options))
            // {
            //     var valueString = JsonConvert.SerializeObject(value);
            //     redisCache.SetString(key, valueString);
            // }
            throw new System.NotImplementedException();
        }

        public T Get<T>(string key)
        {
            // using (var redisCache = new RedisCache(options))
            // {
            //     var valueString = redisCache.GetString(key);
            //     if (!string.IsNullOrEmpty(valueString))
            //     {
            //         var valueObject = JsonConvert.DeserializeObject<T>(valueString);
            //         return valueObject;
            //     }
            //
            //     return default;
            // }
            throw new System.NotImplementedException();
        }

        public object Get(string key)
        {
            // using (var redisCache = new RedisCache(options))
            // {
            //     var valueString = redisCache.GetString(key);
            //     if (!string.IsNullOrEmpty(valueString))
            //     {
            //         var valueObject = JsonConvert.DeserializeObject(valueString);
            //         return valueObject;
            //     }
            //     return default;
            // }
            throw new System.NotImplementedException();
        }

        public bool IsAdded(string key)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(string key)
        {
            // using (var redisCache = new RedisCache(options))
            // {
            //     redisCache.Remove(key);
            // }
            throw new System.NotImplementedException();
        }

        public void RemoveByPattern(string pattern)
        {
            throw new System.NotImplementedException();
        }
    }
}