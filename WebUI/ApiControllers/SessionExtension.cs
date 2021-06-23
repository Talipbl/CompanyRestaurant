using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Methods
{
    public static class SessionExtension
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            string jsonValue = JsonConvert.SerializeObject(value);
            session.SetString(key, jsonValue);
        }
        public static T GetObject<T>(this ISession session, string key) where T:class
        {
            string jsonValue = session.GetString(key);
            if (string.IsNullOrEmpty(jsonValue)) return null;
            T value = JsonConvert.DeserializeObject<T>(jsonValue);
            return value;
        }
    }
}
