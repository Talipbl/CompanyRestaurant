using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models.DataTransferObjects;

namespace WebUI.Methods
{
    public static class SessionExtension
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            string jsonValue = JsonConvert.SerializeObject(value);
            session.SetString(key, jsonValue);
        }
        public static ResponseDTO<T> GetObject<T>(this ISession session, string key) where T:class, new()
        {
            ResponseDTO<T> response = new ResponseDTO<T>();

            string jsonValue = session.GetString(key);
            if (string.IsNullOrEmpty(jsonValue)) return null;
            response.Entity = JsonConvert.DeserializeObject<T>(jsonValue);
            return response;
        }
    }
}
