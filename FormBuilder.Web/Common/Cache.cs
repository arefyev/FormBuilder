using System;
using System.Collections.Generic;
using System.Web;

namespace FormBuilder.Common
{
    /// <summary>
    /// Represents interface to storage data to cache for performance
    /// </summary>
    public interface ICacheService
    {
        T Get<T>(string cacheId, Func<T> getItemCallback, bool forceUpdate = false) where T : class;

        T Get<T>(string cacheId) where T : class;

        void Push<T>(string cacheId, T item) where T : class;

        void Update<T>(string cacheId, T item) where T : class;
    }

    public class InMemoryCache : ICacheService
    {
        #region - Methods -
        /// <summary>
        /// Stores a data from callback
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheId"></param>
        /// <param name="getItemCallback">Items to store</param>
        /// <param name="forceUpdate"></param>
        /// <returns></returns>
        public T Get<T>(string cacheId, Func<T> getItemCallback, bool forceUpdate) where T : class
        {
            // HttpRuntime.Cache is thread safe
            var item = HttpRuntime.Cache.Get(cacheId) as T;
            if (forceUpdate || item == null)
            {
                item = getItemCallback();
                HttpRuntime.Cache.Insert(cacheId, item, null, DateTime.Now.AddMinutes(Constants.AbsoluteCacheExpiration),
                                         System.Web.Caching.Cache.NoSlidingExpiration);
            }
            return item;
        }
        /// <summary>
        /// Returns an item from cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheId"></param>
        /// <returns></returns>
        public T Get<T>(string cacheId) where T : class
        {
            return HttpRuntime.Cache.Get(cacheId) as T;
        }
        /// <summary>
        /// REmoves aol data and put to cache new data
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="cacheId">Cache id</param>
        /// <param name="item">Item to storage into cache</param>
        public void Push<T>(string cacheId, T item) where T : class
        {
            HttpRuntime.Cache.Remove(cacheId);
            HttpRuntime.Cache.Insert(cacheId, item, null, DateTime.Now.AddMinutes(Constants.AbsoluteCacheExpiration),
                                         System.Web.Caching.Cache.NoSlidingExpiration);
        }
        /// <summary>
        /// Adds new element to cache if one exists
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="cacheId">Cache id</param>
        /// <param name="item">Item to add</param>
        public void Update<T>(string cacheId, T item) where T : class
        {
            var cache = HttpRuntime.Cache.Get(cacheId) as List<T>;
            if (cache == null)
                return;
            cache.Add(item);
            Push(cacheId, cache);
        }
        #endregion
    }
}