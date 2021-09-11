using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Concrete.DataTransferObject;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebUI.Methods;
using WebUI.Models.DataTransferObjects;

namespace WebUI.ApiControllers.ApiProcessors
{
    public class OrderProcessor
    {
        string _url;
        public static HttpClient ApiClient { get; private set; }

        public OrderProcessor(string url, string accessToken)
        {
            _url = url + "orders/";
            ApiClient = ApiClientHelper.CreateApiClientWithBearerHeader(ApiClient, accessToken);
        }

        public async Task<ResponseDTO<string>> AddOrderAsync(Order order)
        {
            string currentUrl = _url + "add";
            return await ApiHelper.PostApiResponse<string, Order>(ApiClient, currentUrl, order);
        }

        public async Task<ResponseDTO<List<Order>>> GetOrdersAsync()
        {
            string currentUrl = _url + "getall";
            return await ApiHelper.GetApiResponse<List<Order>>(ApiClient, currentUrl);
        }

        public async Task<ResponseDTO<Order>> GetOrderAsync(int id)
        {
            string currentUrl = _url + "get/" + id;
            return await ApiHelper.GetApiResponse<Order>(ApiClient, currentUrl);
        }

        //public async Task<ResponseDTO<Order>> GetOrderByDateTime(DateTimeDTO dateTime)
        //{
        //    string currentUrl = _url + "getorderbytime";
        //    return await ApiHelper.GetApiResponse<Order, DateTimeDTO>(ApiClient, currentUrl, dateTime);
        //}

        public async Task<ResponseDTO<decimal>> GetOrdersAmountAsync()
        {
            string currentUrl = _url + "getordersamount";
            return await ApiHelper.GetApiResponse<decimal>(ApiClient, currentUrl);
        }

        public async Task<ResponseDTO<List<Order>>> GetLastOrdersAsync(int takeValue = 10)
        {
            string currentUrl = _url + "getlastorders?takeValue=" + takeValue;
            return await ApiHelper.GetApiResponse<List<Order>>(ApiClient, currentUrl);
        }

        public async Task<ResponseDTO<List<Order>>> GetLastOrdersWithOrderBy()
        {
            string currentUrl = _url + "getlastorderswithorderby";
            return await ApiHelper.GetApiResponse<List<Order>>(ApiClient, currentUrl);
        }

        public async Task<ResponseDTO<Order>> GetLastOrderAsync()
        {
            string currentUrl = _url + "getlastorder";
            return await ApiHelper.GetApiResponse<Order>(ApiClient, currentUrl);
        }

    }
}
