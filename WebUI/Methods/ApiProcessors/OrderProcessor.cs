using Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebUI.Methods.ApiProcessors
{
    public class OrderProcessor
    {
        string _url;
        public static HttpClient ApiClient { get; private set; }

        public OrderProcessor(string url)
        {
            _url = url + "api/orders/";
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            string currentUrl = _url + "getall";
            return await ApiMethods.GetApiResponse<List<Order>>(ApiClient, currentUrl);
        }
        public async Task<decimal> GetOrdersAmountAsync()
        {
            string currentUrl = _url + "getordersamount";
            return await ApiMethods.GetApiResponse<decimal>(ApiClient, currentUrl);
        }
        public async Task<List<Order>> GetLastOrders(int takeValue = 10)
        {
            string currentUrl = _url + "getlastorders?takeValue=" + takeValue;
            return await ApiMethods.GetApiResponse<List<Order>>(ApiClient, currentUrl);
        }

    }
}
