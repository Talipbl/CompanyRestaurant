using Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebUI.Methods;

namespace WebUI.Methods.ApiProcessors
{
    public class ProductProcessor
    {
        string _url;
        public static HttpClient ApiClient { get; private set; }

        public ProductProcessor(string url)
        {
            _url = url + "api/products/";
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            string currentUrl = _url + "getall";
            return await ApiMethods.GetApiResponse<List<Product>>(ApiClient, currentUrl);
        }
    }
}
