using System;
using System.Collections.Generic;

namespace Core.Services.Interfaces
{
    /// <summary>
    /// Memory caching service
    /// </summary>
    public interface IMemoryCachingService
    {
        /// <summary>
        /// Caching object with expiration time as minutes.
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="data">data</param>
        /// <param name="key">key</param>
        /// <param name="minutes">minutes</param>
        void Set<T>(T data, string key, int minutes);

        /// <summary>
        /// Caching list of object with expiration time as minutes.
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="data">data</param>
        /// <param name="key">key</param>
        /// <param name="minutes">minutes</param>
        void Set<T>(List<T> data, string key, int minutes);

        /// <summary>
        /// Caching object with expiration time as hour and minutes.
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="data">data</param>
        /// <param name="key">key</param>
        /// <param name="hours">hours</param>
        /// <param name="minutes">minutes</param>
        void Set<T>(T data, string key, int hours, int minutes);

        /// <summary>
        /// Caching list of object with expiration time as hour and minutes.
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="data">data</param>
        /// <param name="key">key</param>
        /// <param name="hours">hours</param>
        /// <param name="minutes">minutes</param>
        void Set<T>(List<T> data, string key, int hours, int minutes);

        /// <summary>
        /// Caching object with expiration time as days, hour and minutes.
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="data">data</param>
        /// <param name="key">key</param>
        /// <param name="days">days</param>
        /// <param name="hours">hours</param>
        /// <param name="minutes">minutes</param>
        void Set<T>(T data, string key, int days, int hours, int minutes);

        /// <summary>
        /// Caching list of object with expiration time as days, hour and minutes.
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="data">data</param>
        /// <param name="key">key</param>
        /// <param name="days">days</param>
        /// <param name="hours">hours</param>
        /// <param name="minutes">minutes</param>
        void Set<T>(List<T> data, string key, int days, int hours, int minutes);

        /// <summary>
        /// Caching object with expiration time as day and time
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="data">Data</param>
        /// <param name="key">Key</param>
        /// <param name="date">expired datetime</param>
        void Set<T>(T data, string key, DateTime date);

        /// <summary>
        /// Caching list of object with expiration time as day and time
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="data">Data</param>
        /// <param name="key">Key</param>
        /// <param name="date">expired datetime</param>
        void Set<T>(List<T> data, string key, DateTime date);

        /// <summary>
        /// Get object from cache
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="key">key</param>
        /// <returns>T</returns>
        T GetValue<T>(string key);

        /// <summary>
        /// Get list of object from cache
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="key">key</param>
        /// <returns>List<T></returns>
        List<T> GetList<T>(string key);

        /// <summary>
        /// Remove cache by key
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);
    }
}
