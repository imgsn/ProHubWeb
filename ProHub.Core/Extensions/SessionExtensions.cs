﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ProHub.Core.Extensions
{
    public static class SessionExtensions
    {
        /// <summary>
        /// Set value to Session
        /// </summary>
        /// <typeparam name="T">Type of value</typeparam>
        /// <param name="session">Session</param>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        /// <summary>
        /// Get value from session
        /// </summary>
        /// <typeparam name="T">Type of value</typeparam>
        /// <param name="session">Session</param>
        /// <param name="key">Key</param>
        /// <returns>Value</returns>
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            if (value == null)
                return default;

            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
