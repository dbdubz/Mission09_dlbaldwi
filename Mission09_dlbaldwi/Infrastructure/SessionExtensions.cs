using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mission09_dlbaldwi.Infrastructure
{
    public static class SessionExtensions
    {
        public static void SetJSON(this ISession session, string key, object val)
        {
            session.SetString(key, JsonSerializer.Serialize(val));
        }

        public static T GetJSON<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}
