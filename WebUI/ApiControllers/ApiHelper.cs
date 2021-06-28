using Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebUI.Models.DataTransferObjects;

namespace WebUI.Methods
{
    public class ApiHelper
    {
        public static HttpClient ApiClient { get; private set; }

        public static async Task<ResponseDTO<T>> GetApiResponse<T>(HttpClient apiClient, string currentUrl)
        {
            ApiClient = apiClient;
            ResponseDTO<T> response = new ResponseDTO<T>
            {
                ResponseMessage = await ApiClient.GetAsync(currentUrl)
            };
            var result = await response.ResponseMessage.Content.ReadAsStringAsync();
            T value = JsonConvert.DeserializeObject<T>(result);
            response.Entity = value;
            return response;
        }
        public static async Task<ResponseDTO<TEntity>> PostApiResponse<TEntity, T>(HttpClient apiClient, string currentUrl, T entity)
        {
            ApiClient = apiClient;
            ResponseDTO<TEntity> response = new ResponseDTO<TEntity>();

            var jsonFormat = JsonConvert.SerializeObject(entity);
            HttpContent content = new StringContent(jsonFormat, Encoding.UTF8, "application/json");
            response.ResponseMessage = await ApiClient.PostAsync(currentUrl, content);
            string result = await response.ResponseMessage.Content.ReadAsStringAsync();
            response.Entity = JsonConvert.DeserializeObject<TEntity>(result);
            return response;
        }
    }
}
