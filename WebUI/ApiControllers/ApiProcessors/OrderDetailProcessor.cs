using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebUI.Methods;

namespace WebUI.ApiControllers.ApiProcessors
{
    public class OrderDetailProcessor
    {
        string _url;
        public static HttpClient ApiClient { get; private set; }

        public OrderDetailProcessor(string url, string accessToken)
        {
            _url = url + "orderdetails/";
            ApiClient = ApiClientHelper.CreateApiClientWithBearerHeader(ApiClient, accessToken);
        }

        public async void AddOrderDetailAsync(OrderDetail orderDetail)
        {
            string currentUrl = _url + "add";
            await ApiHelper.PostApiResponse<string, OrderDetail>(ApiClient, currentUrl, orderDetail);
        }

    }
}
