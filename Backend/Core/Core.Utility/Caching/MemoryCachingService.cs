using Core.Utility.Caching.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Core.Utility.Caching
{
    public class MemoryCachingService : IMemoryCachingService
    {
        // Limit 100 connection to memory cache
        private static Semaphore _pool = new Semaphore(0, 100);

        private readonly IMemoryCache _cache;
        public MemoryCachingService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void SetValue<T>(T data, string key, int minutes)
        {
            try
            {
                _pool.WaitOne(1);

                RemoveCache(key);

                var cacheOption = new MemoryCacheEntryOptions();
                cacheOption.SetAbsoluteExpiration(DateTime.Now.AddMinutes(minutes));
                cacheOption.Priority = CacheItemPriority.Normal;

                _cache.Set(key, data, cacheOption);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _pool.Release();
            }
        }

        public void SetValue<T>(List<T> data, string key, int minutes)
        {
            try
            {
                _pool.WaitOne(1);

                RemoveCache(key);

                var cacheOption = new MemoryCacheEntryOptions();
                cacheOption.SetAbsoluteExpiration(DateTime.Now.AddMinutes(minutes));
                cacheOption.Priority = CacheItemPriority.Normal;

                _cache.Set(key, data, cacheOption);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _pool.Release();
            }
        }

        public void SetValue<T>(T data, string key, int hours, int minutes)
        {
            try
            {
                _pool.WaitOne(1);

                RemoveCache(key);

                var cacheOption = new MemoryCacheEntryOptions();
                cacheOption.SetAbsoluteExpiration(DateTime.Now.AddHours(hours).AddMinutes(minutes));
                cacheOption.Priority = CacheItemPriority.Normal;

                _cache.Set(key, data, cacheOption);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _pool.Release();
            }
        }

        public void SetValue<T>(List<T> data, string key, int hours, int minutes)
        {
            try
            {
                _pool.WaitOne(1);

                RemoveCache(key);

                var cacheOption = new MemoryCacheEntryOptions();
                cacheOption.SetAbsoluteExpiration(DateTime.Now.AddHours(hours).AddMinutes(minutes));
                cacheOption.Priority = CacheItemPriority.Normal;

                _cache.Set(key, data, cacheOption);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _pool.Release();
            }
        }

        public void SetValue<T>(T data, string key, int days, int hours, int minutes)
        {
            try
            {
                _pool.WaitOne(1);

                RemoveCache(key);

                var cacheOption = new MemoryCacheEntryOptions();
                cacheOption.SetAbsoluteExpiration(DateTime.Now.AddDays(days).AddHours(hours).AddMinutes(minutes));
                cacheOption.Priority = CacheItemPriority.Normal;

                _cache.Set(key, data, cacheOption);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _pool.Release();
            }
        }

        public void SetValue<T>(List<T> data, string key, int days, int hours, int minutes)
        {
            try
            {
                _pool.WaitOne(1);

                RemoveCache(key);

                var cacheOption = new MemoryCacheEntryOptions();
                cacheOption.SetAbsoluteExpiration(DateTime.Now.AddDays(days).AddHours(hours).AddMinutes(minutes));
                cacheOption.Priority = CacheItemPriority.Normal;

                _cache.Set(key, data, cacheOption);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _pool.Release();
            }
        }

        public T GetValue<T>(string key)
        {
            return _cache.Get<T>(key);
        }

        public List<T> GetList<T>(string key)
        {
            return _cache.Get<List<T>>(key);
        }

        public void RemoveCache(string key)
        {
            _cache.Remove(key);
        }
    }
}
