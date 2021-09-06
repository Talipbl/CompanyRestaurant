using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebUI.ApiControllers
{
    public class ApiClientHelper
    {
        public static string ApiConnectUrl
        {
            get
            {
                return "https://localhost:44396/";
            }
            private set { }
        }
        public static HttpClient CreateApiClient(HttpClient ApiClient)
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return ApiClient;
        }
        public static HttpClient CreateApiClientWithBearerHeader(HttpClient ApiClient, string accessToken)
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ApiClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            return ApiClient;
        }
    }
}
