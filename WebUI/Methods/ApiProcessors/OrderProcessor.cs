using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Concrete.DataTransferObject;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebUI.Models.DataTransferObjects;

namespace WebUI.Methods.ApiProcessors
{
    public class OrderProcessor
    {
        string _url;
        public static HttpClient ApiClient { get; private set; }

        public OrderProcessor(string url, string accessToken)
        {
            _url = url + "api/orders/";
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ApiClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
        }

        public async Task<string> AddOrderAsync(Order order)
        {
            string currentUrl = _url + "add";
            return await ApiMethod.PostApiResponse<string, Order>(ApiClient, currentUrl, order);
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            string currentUrl = _url + "getall";
            return await ApiMethod.GetApiResponse<List<Order>>(ApiClient, currentUrl);
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            string currentUrl = _url + "get/" + id;
            return await ApiMethod.GetApiResponse<Order>(ApiClient, currentUrl);
        }

        public async Task<Order> GetOrderByDateTime(DateTimeDTO dateTime)
        {
            string currentUrl = _url + "getorderbytime";
            return await ApiMethod.PostApiResponse<Order, DateTimeDTO>(ApiClient, currentUrl, dateTime);
        }

        public async Task<decimal> GetOrdersAmountAsync()
        {
            string currentUrl = _url + "getordersamount";
            return await ApiMethod.GetApiResponse<decimal>(ApiClient, currentUrl);
        }

        public async Task<List<Order>> GetLastOrdersAsync(int takeValue = 10)
        {
            string currentUrl = _url + "getlastorders?takeValue=" + takeValue;
            return await ApiMethod.GetApiResponse<List<Order>>(ApiClient, currentUrl);
        }

        public async Task<Order> GetLastOrderAsync()
        {
            string currentUrl = _url + "getlastorder";
            return await ApiMethod.GetApiResponse<Order>(ApiClient, currentUrl);
        }

    }
}
