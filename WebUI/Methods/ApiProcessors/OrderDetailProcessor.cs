using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebUI.Methods.ApiProcessors
{
    public class OrderDetailProcessor
    {
        string _url;
        public static HttpClient ApiClient { get; private set; }

        public OrderDetailProcessor(string url, string accessToken)
        {
            _url = url + "api/orderdetails/";
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ApiClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
        }

        public async void AddOrderDetailAsync(OrderDetail orderDetail)
        {
            string currentUrl = _url + "add";
            await ApiMethod.PostApiResponse<string, OrderDetail>(ApiClient, currentUrl, orderDetail);
        }

    }
}
