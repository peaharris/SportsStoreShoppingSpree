using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace LabSportsStore.Infrastructure
{
    public static class SessionExtensions
    {
        public static T GetJson<T>(this ISession session, string key)
        {
            string sessionJsonString = session.GetString(key);
            if (sessionJsonString == null)
            {
                return default(T);
            }
            return
               JsonConvert.DeserializeObject<T>(sessionJsonString);
        }

        public static void SetJson(this ISession session, string key, object value)
        {
            string valueJsonString = JsonConvert.SerializeObject(value);
            session.SetString(key, valueJsonString);
        }
    }

}
