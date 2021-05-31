using Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Methods
{
    public class ApiMethods
    {
        public static HttpClient ApiClient { get; private set; }

        public static async Task<T> GetApiResponse<T>(HttpClient apiClient, string currentUrl)
        {
            ApiClient = apiClient;
            HttpResponseMessage response = await ApiClient.GetAsync(currentUrl);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                T value = JsonConvert.DeserializeObject<T>(result);
                return value;
            }
            throw new Exception(response.ReasonPhrase);
        }
        public static async Task<TEntity> PostApiResponse<TEntity>(HttpClient apiClient, string currentUrl, TEntity entity)
        {
            ApiClient = apiClient;
            var jsonFormat = JsonConvert.SerializeObject(entity);
            HttpContent content = new StringContent(jsonFormat, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await ApiClient.PostAsync(currentUrl, content);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                TEntity value = JsonConvert.DeserializeObject<TEntity>(result);
                return value;
            }
            throw new Exception(response.ReasonPhrase);
        }
    }
}
